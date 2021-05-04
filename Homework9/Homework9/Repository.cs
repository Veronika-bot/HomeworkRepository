using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    public class Repository : IRepository
    {
        private readonly Database _db;

        public Repository(Database db)
        {
            _db = db;
        }

        public Order[] GetOrders(int customerId)
        {
            return _db.Orders.Where(order => order.CustomerId == customerId).ToArray();
        }

        public Order GetOrder(int orderId)
        {
            var order = _db.Orders.SingleOrDefault(order => order.Id == orderId);

            if (order == null)
            {
                throw new InvalidOperationException();
            }

            return order;
        }

        public decimal GetMoneySpentBy(int customerId)
        {
            return _db.Orders.Join(_db.Products,
                (o) => o.ProductId,
                (p) => p.Id,
                (o, p) => new
                {
                    p.Price,
                    o.CustomerId
                })
                .Where(x => x.CustomerId == customerId)
                .Sum(x => x.Price);
        }

        public Product[] GetAllProductsPurchased(int customerId)
        {
            return GetOrders(customerId).Join(_db.Products,
                (o) => o.ProductId,
                (p) => p.Id,
                (o, p) => p)
                .ToArray();
        }

        public Product[] GetUniqueProductsPurchased(int customerId)
        {
            return GetOrders(customerId).Join(_db.Products,
                (o) => o.ProductId,
                (p) => p.Id,
                (o, p) => p)
                .Distinct()
                .ToArray();
        }

        public bool HasEverPurchasedProduct(int customerId, int productId)
        {
            return GetOrders(customerId).Any(o => o.ProductId == productId);
        }

        public bool AreAllPurchasesHigherThan(int customerId, decimal targetPrice)
        {
            return GetOrders(customerId).Join(_db.Products,
                 (o) => o.ProductId,
                 (p) => p.Id,
                 (o, p) => new
                 {
                     p.Price
                 })
                .All(x => x.Price > targetPrice);
        }

        public bool DidPurchaseAllProducts(int customerId, params int[] productIds)
        {
            return GetOrders(customerId)
                .Select(o => o.ProductId)
                .Distinct()
                .Intersect(productIds)
                .Count() == productIds.Count();
        }

        public int GetTotalProductsPurchased(int productId)
        {
            return _db.Orders.Where(o => o.ProductId == productId).Count();
        }

        public CustomerOverView GetCustomerOverview(int customerId)
        {
            return new CustomerOverView
            {
                Name = _db.Customers.Single(x => x.Id == customerId).Name,
                TotalProductsPurchased = GetTotalProductsPurchasedByCustomer(customerId),
                FavoriteProductName = GetFavoriteProductName(customerId),
                MaxAmountSpentPerProducts = GetMaxAmountSpentPerProducts(customerId),
                TotalMoneySpent = GetMoneySpentBy(customerId),
            };
        }

        public int GetTotalProductsPurchasedByCustomer(int customerId)
        {
            return _db.Orders.Where(o => o.CustomerId == customerId).Count();
        }

        private decimal GetMaxAmountSpentPerProducts(int customerId)
        {
            return GetOrders(customerId).Join(_db.Products,
                (o) => o.ProductId,
                (p) => p.Id,
                (o, p) => new
                {
                    p.Name,
                    p.Price,
                })
                .GroupBy(x => x.Name)
                .Select(g => new
                {
                    g.Key,
                    SumPrice = g.Sum(x => x.Price)
                })
                .Max(x => x.SumPrice);
        }

        private string GetFavoriteProductName(int customerId)
        {
            var productId = GetOrders(customerId).Join(_db.Products,
                (o) => o.ProductId,
                (p) => p.Id,
                (o, p) => new
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                })
                .GroupBy(x => x.ProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    Count = g.Count()
                })
                .OrderBy(x => x.Count)
                .Last()
                .ProductId;

            return _db.Products.Single(x => x.Id == productId).Name;
        }

        public List<(string productName, int numberOfPurchases)> GetProductsPurchased(int customerId)
        {
            return GetOrders(customerId).Join(_db.Products,
                (o) => o.ProductId,
                (p) => p.Id,
                (o, p) => new
                {
                    ProductName = p.Name,
                })
                .GroupBy(x => x.ProductName)
                .Select(g => new
                {
                    Name = g.Key,
                    Count = g.Count()
                })
                .Select(n => (n.Name, n.Count)).ToList();
        }
    }
}
