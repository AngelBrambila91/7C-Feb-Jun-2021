using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using static System.Console;

namespace WorkingWithEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            // LinQ
            // QueryingCategories();
            //FilterIncludes();
            //QueryingProducts();
            //QueryingWithLike();

            // if(AddProduct(6, "Electrolitos Farmacias del Ahorro", 500M))
            // {
            //     WriteLine("Product added succesfully");
            // }
            // ListProducts();

            // if(IncreaseProductPrice("Electrolitos", 20M))
            // {
            //     WriteLine("Update Successful");
            // }
            // ListProducts();

            int deleted = DeleteProducts("Electrolitos");
            WriteLine($"{deleted} product(s) were deleted.");
            ListProducts();
        }

        #region Read   
        static void QueryingCategories()
        {
            using (var db = new Northwind())
            {
                WriteLine("Categories and how many products they have: ");
                IQueryable<Category> cats = db.Categories
                .Include(c => c.Products); // SELECT * FROM Categories INNER JOIN Products ... ON ...
                foreach (Category c in cats)
                {
                    WriteLine($"{c.CategoryName} has {c.Products.Count} products");
                }
            }
        }

        static void FilterIncludes()
        {
            using (var db = new Northwind())
            {
                Write("enter a minimum for units in stock : ");
                string unitsInStock = ReadLine();
                int stock = int.Parse(unitsInStock);
                IQueryable<Category> cats = db.Categories.Include(c => c.Products.Where(p => p.Stock >= stock)); // SELECT *, UnitsInStock FROM Categories IJ Products ... ON ... WHERE (Products.UnitsInStock >= @StockFromUser)
                WriteLine($"Query to String: {cats.ToQueryString()}");
                foreach (Category c in cats)
                {
                    WriteLine($"{c.CategoryName} has {c.Products.Count} products within a minimum of {stock} units in stock");
                    foreach (Product p in c.Products)
                    {
                        WriteLine($"{p.ProductName} has {p.Stock} units in stock");
                    }
                }
            }
        }

        static void QueryingProducts()
        {
            using (var db = new Northwind())
            {
                WriteLine("Products that cost more than a price, we order the highest at top : ");
                string input;
                decimal price;
                do
                {
                    Write("Enter a product price : ");
                    input = ReadLine();
                } while (!decimal.TryParse(input, out price));
                IQueryable<Product> prods = db.Products.Where(product => product.Cost > price)
                .OrderByDescending(product => product.Cost);
                foreach (Product item in prods)
                {
                    WriteLine($"{item.ProductID} :  {item.ProductName} costs {item.Cost:$#,##0.00} and has {item.Stock}");
                }
            }
        }

        static void QueryingWithLike()
        {
            using (var db = new Northwind())
            {
                Write("Enter a part of a product name : ");
                string input = ReadLine();
                IQueryable<Product> prods = db.Products.Where(p => EF.Functions.Like(p.ProductName, $"%{input}%")); // LIKE "%%"
                foreach (Product item in prods)
                {
                    WriteLine($"{item.ProductName} has {item.Stock} units in stock. Discontinued? {item.Discontinued}");
                }
            }
        }

        static void ListProducts()
        {
            using (var db = new Northwind())
            {
                WriteLine("{0, -3} {1,-35} {2,8} {3,5} {4}",
                "ID", "ProductName", "Cost", "Stock" , "Disc.");
                foreach (var item in db.Products.OrderByDescending(p => p.Cost))
                {
                    WriteLine("{0:000} {1,-35} {2,8:$#,##0.00} {3,5} {4}",
                    item.ProductID, item.ProductName, item.Cost, item.Stock, item.Discontinued);
                }
            }
        }
        #endregion

        #region Create
            static bool AddProduct (int categoryID, string productName, decimal? price)
            {
                using (var db = new Northwind())
                {
                    var newProduct = new Product()
                    {
                        CategoryID = categoryID,
                        ProductName = productName,
                        Cost = price
                    };
                    db.Products.Add(newProduct);
                    // Alert for changes in DB
                    int affected = db.SaveChanges();
                    return (affected == 1);
                }
            }
        #endregion

        #region Update
            static bool IncreaseProductPrice(string name, decimal amount)
            {
                using (var db = new Northwind())
                {
                    Product updateProduct = db.Products.First(p => p.ProductName.StartsWith(name));
                    updateProduct.Cost += amount;
                    int affected = db.SaveChanges();
                    return (affected == 1);
                }
                
            }
        #endregion

        #region Delete
        static int DeleteProducts(string name)
        {
            using (var db = new Northwind())
            {
                IEnumerable<Product> products = db.Products.Where(p => p.ProductName.StartsWith(name));
                db.Products.RemoveRange(products);
                int affected = db.SaveChanges();
                return affected;
            }
        }
        #endregion
    }
}
