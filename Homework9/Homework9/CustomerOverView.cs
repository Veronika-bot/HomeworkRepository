namespace Linq
{
    public class CustomerOverView
    {
        public CustomerOverView(string name, int totalProductsPurchased, string favoriteProductName, decimal maxAmountSpentPerProducts, decimal totalMoneySpent)
        {
            Name = name;
            TotalProductsPurchased = totalProductsPurchased;
            FavoriteProductName = favoriteProductName;
            MaxAmountSpentPerProducts = maxAmountSpentPerProducts;
            TotalMoneySpent = totalMoneySpent;
        }

        public string Name { get; set; }

        public int TotalProductsPurchased { get; set; }
        
        public string FavoriteProductName { get; set; }
        
        public decimal MaxAmountSpentPerProducts { get; set; }
        
        public decimal TotalMoneySpent { get; set; }
    }
}
