using System;

namespace BankLibrary
{
    public class Bank<T> where T : Account
    {
        private readonly AccountsCollection _accounts = new();

        private void CreateAccount(OpenAccountParameters parameters, Func<T> creator)
        {
            var account = creator();

            AddSubscriptions(parameters, account);

            account.Open();
            _accounts.Add(account);
        }

        private static void AddSubscriptions(OpenAccountParameters parameters, T account)
        {
            account.Created += parameters.AccountCreated;
            account.Closed += parameters.AccountClosed;
            account.PutMoney += parameters.MoneyPut;
            account.Withdrawn += parameters.MoneyWithdrawn;
        }

        private void AssertValidId(int id)
        {
            if (id < 0 || id >= _accounts.GetCount())
            {
                throw new InvalidOperationException("An account with this number does not exist");
            }
        }

        private static void AssertValidAccount
            (OpenAccountParameters parameters)
        {
            var bankType = typeof(T);

            if ((parameters.Type == AccountType.Deposit && typeof(OnDemandAccount) == bankType) ||
                (parameters.Type == AccountType.OnDemand && typeof(DepositAccount) == bankType))
            {
                throw new InvalidOperationException("An account with this type can not create");
            }
        }

        private static void ClearSubscriptions(CloseAccountParameters parameters, T account)
        {
            account.Created -= parameters.AccountCreated;
            account.Closed -= parameters.AccountClosed;
            account.PutMoney -= parameters.MoneyPut;
            account.Withdrawn -= parameters.MoneyWithdrawn;
        }

        public void OpenAccount(OpenAccountParameters parameters)
        {
            AssertValidAccount(parameters);

            CreateAccount(parameters, () => parameters.Type == AccountType.Deposit
                   ? new DepositAccount(parameters.Amount, parameters.Percentage) as T
                   : new OnDemandAccount(parameters.Amount, parameters.Percentage) as T);
        }

        public void ClosedAccount(CloseAccountParameters parameters)
        {
            AssertValidId(parameters.Id);

            var account = _accounts.GetItem(parameters.Id);
            account.Close();
            ClearSubscriptions(parameters, (T)account);
        }

        public void PutAmount(PutAccountParameters parameters)
        {
            AssertValidId(parameters.Id);

            var account = _accounts.GetItem(parameters.Id);
            account.Put(parameters.Amount);
        }

        public void WithdrawMoney(WithdrawAccountParameters parameters)
        {
            AssertValidId(parameters.Id);

            var account = _accounts.GetItem(parameters.Id);
            account.Withdraw(parameters.Amount);
        }

        public void IncrementDay()
        {
            for (int i = 0; i < _accounts.GetCount(); i++)
            {
                _accounts.GetItem(i).IncrementDays();
                _accounts.GetItem(i).CalculatePercentage();
            }
        }
    }
}