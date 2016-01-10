using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Orders
{
	class OrdersMain
	{
		static void Main()
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

			var dataMapper = new DataMapper();
			var categories = dataMapper.GetAllCategories();
			var products = dataMapper.GetAllProducts();
			var orders = dataMapper.GetAllOrders();

			// Names of the 5 most expensive products
			var fiveMostExpensiveProducts = products
				.OrderByDescending(p => p.UnitPrice)
				.Take(5)
				.Select(p => p.Name);

			Console.WriteLine(string.Join(Environment.NewLine, fiveMostExpensiveProducts));

			PrintSeparator();

			// Number of products in each category
			var productsInEachCategory = products
				.GroupBy(p => p.CategoryId)
				.Select(group => new { Category = categories.First(c => c.Id == group.Key).Name, Count = group.Count() })
				.ToList();

			foreach (var item in productsInEachCategory)
			{
				Console.WriteLine("{0}: {1}", item.Category, item.Count);
			}

			PrintSeparator();

			// The 5 top products (by order quantity)
			var topFiveProductsSortedByOrderQuantity = orders
				.GroupBy(o => o.ProductId)
				.Select(grp => new { Product = products.First(p => p.Id == grp.Key).Name, Quantities = grp.Sum(grpgrp => grpgrp.Quantity) })
				.OrderByDescending(q => q.Quantities)
				.Take(5);
			foreach (var item in topFiveProductsSortedByOrderQuantity)
			{
				Console.WriteLine("{0}: {1}", item.Product, item.Quantities);
			}

			PrintSeparator();

			// The most profitable category
			var mostProfitableCategory = orders
				.GroupBy(p => p.ProductId)
				.Select(g => new { catId = products.First(p => p.Id == g.Key).CategoryId, price = products.First(p => p.Id == g.Key).UnitPrice, quantity = g.Sum(p => p.Quantity) })
				.GroupBy(p => p.catId)
				.Select(group => new { category_name = categories.First(c => c.Id == group.Key).Name, TotalQuantity = group.Sum(g => g.quantity * g.price) })
				.OrderByDescending(g => g.TotalQuantity)
				.First();

			Console.WriteLine("{0}: {1}", mostProfitableCategory.category_name, mostProfitableCategory.TotalQuantity);
		}

		private static void PrintSeparator()
		{
			Console.WriteLine(new string('-', 10));
		}
	}
}
