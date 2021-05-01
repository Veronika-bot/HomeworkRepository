using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    public class Database : IRepository
    {
        public List<Customer> Customers { get; set; } = new();

        public List<Order> Orders { get; set; } = new();

        public List<Product> Products { get; set; } = new();

        public Database()
        {
            Customers.AddRange(new[]
            {
                new Customer(1, "Mike"),
                new Customer(2, "John"),
                new Customer(3, "Bob"),
                new Customer(4, "Nick"),
            });

            Products.AddRange(new[]
            {
                new Product(1, "Phone", 500),
                new Product(2, "Notebook", 1000),
                new Product(3, "PC", 1500),
                new Product(4, "XBox", 800),
            });

            Orders.AddRange(new[]
            {
                new Order(1, 1, 1),
                new Order(2, 1, 1),
                new Order(3, 4, 1),
                new Order(4, 2, 2),
                new Order(5, 3, 2),
                new Order(6, 4, 2),
                new Order(7, 1, 3),
                new Order(8, 2, 3),
                new Order(9, 3, 3),
                new Order(10, 3, 3),
                new Order(11, 2, 4),
                new Order(12, 3, 4),
                new Order(13, 4, 4),
            });
        }

        public Order[] GetOrders(int customerId)
        {
            var selectedOrders = from orders in Orders
                                 where orders.CustomerId == customerId
                                 select orders;

            foreach (Order order in selectedOrders)
            {
                Console.WriteLine($"{order.Id} - {order.ProductId} - {order.CustomerId}");
            }

            return null;
        }

        public Order GetOrder(int orderId)
        {
            var selectedOrder = Orders.Where(o => o.Id == orderId);

            foreach (Order order in selectedOrder)
            {
                Console.WriteLine($"{order.Id} - {order.ProductId} - {order.CustomerId}");
            }

            return null;
        }

        public decimal GetMoneySpentBy(int customerId)
        {
            var productsPrice = from order in Orders
                                join products in Products on order.ProductId equals products.Id
                                where order.CustomerId == customerId
                                select new
                                {
                                    Price = products.Price
                                };

            var sum = productsPrice.Sum(n => n.Price);

            return sum;
        }

        public Product[] GetAllProductsPurchased(int customerId)
        {
            var selectedProducts = from orders in Orders
                                   join products in Products on orders.ProductId equals products.Id
                                   where orders.CustomerId == customerId
                                   select products;

            foreach (Product product in selectedProducts)
            {
                Console.WriteLine($"{product.Id} - {product.Name}");
            }

            return null;
        }

        public Product[] GetUniqueProductsPurchased(int customerId)
        {
            var selectedProducts = from orders in Orders
                                   join products in Products on orders.ProductId equals products.Id
                                   where orders.CustomerId == customerId
                                   select products;

            foreach (Product product in selectedProducts.Distinct())
            {
                Console.WriteLine($"{product.Id} - {product.Name}");
            }

            return null;
        }


        public bool HasEverPurchasedProduct(int customerId, int productId)
        {
            return Orders.Any(o => o.ProductId == productId && o.CustomerId == customerId);
        }

        public bool AreAllPurchasesHigherThan(int customerId, decimal targetPrice)
        {
            var newTable = Orders.Join(Products,
                 o => o.ProductId,
                 p => p.Id,
                 (o, p) => new
                 {
                     Customer = o.CustomerId == customerId,
                     Price = p.Price
                 });

            return newTable.All(n => n.Price > targetPrice);
        }

        public bool DidPurchaseAllProducts(int customerId, params int[] productIds)
        {
            var selectedProducts = (from orders in Orders
                        where orders.CustomerId == customerId
                        select orders.ProductId).ToArray();

            if (selectedProducts.Distinct().Except(productIds).Count() == 0)
            {
                return true;
            }

            return false;
        }
    }
}
