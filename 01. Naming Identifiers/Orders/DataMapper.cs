﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using Orders.Models;

namespace Orders
{
	public class DataMapper
	{
		private string categoriesFileName;
		private string productsFileName;
		private string ordersFileName;

		public DataMapper(string categoriesFileName, string productsFileName, string ordersFileName)
		{
			this.categoriesFileName = categoriesFileName;
			this.productsFileName = productsFileName;
			this.ordersFileName = ordersFileName;
		}

		public DataMapper()
			: this("../../Data/categories.txt", "../../Data/products.txt", "../../Data/orders.txt")
		{
		}

		public IEnumerable<Category> GetAllCategories()
		{
			var categories = ReadFileLines(categoriesFileName, true);
			return categories
				.Select(c => c.Split(','))
				.Select(c => new Category
				{
					Id = int.Parse(c[0]),
					Name = c[1],
					Description = c[2]
				});
		}

		public IEnumerable<Product> GetAllProducts()
		{
			var prod = ReadFileLines(productsFileName, true);
			return prod
				.Select(p => p.Split(','))
				.Select(p => new Product
				{
					Id = int.Parse(p[0]),
					Name = p[1],
					CategoryId = int.Parse(p[2]),
					UnitPrice = decimal.Parse(p[3]),
					UnitsInStock = int.Parse(p[4])
				});
		}

		public IEnumerable<Order> GetAllOrders()
		{
			var ord = ReadFileLines(ordersFileName, true);
			return ord
				.Select(p => p.Split(','))
				.Select(p => new Order
				{
					Id = int.Parse(p[0]),
					ProductId = int.Parse(p[1]),
					Quantity = int.Parse(p[2]),
					Discount = decimal.Parse(p[3])
				});
		}

		private List<string> ReadFileLines(string filename, bool hasHeader)
		{
			var allLines = new List<string>();
			using (var reader = new StreamReader(filename))
			{
				string currentLine;
				if (hasHeader)
				{
					reader.ReadLine();
				}

				while ((currentLine = reader.ReadLine()) != null)
				{
					allLines.Add(currentLine);
				}
			}

			return allLines;
		}
	}
}
