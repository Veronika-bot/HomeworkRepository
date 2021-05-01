namespace Linq
{
    class CustomerOverView
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
        // return maximum number of purchases for a single product
        
        public string FavoriteProductName { get; set; }
        // max amount of money spent for a single product
        
        public decimal MaxAmountSpentPerProducts { get; set; }
        
        public decimal TotalMoneySpent { get; set; }
    }
}
