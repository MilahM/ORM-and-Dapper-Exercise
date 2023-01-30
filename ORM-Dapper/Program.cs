using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            #region Departments
            var departmentRepo = new DapperDepartmentRepository(conn);

            var departments = departmentRepo.GetAllDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine(department.DepartmentID);
                Console.WriteLine(department.Name);
            }
            #endregion
            Console.WriteLine();
            Console.WriteLine();

            #region Products

            //Get All Products
            var productsRepo = new DapperProductRepository(conn);
            var products = productsRepo.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine(product.OnSale);
                Console.WriteLine(product.StockLevel);
            }

            Console.WriteLine();
            Console.WriteLine();

            //Create Product
            Console.WriteLine("Enter Name of product to create.");
            var productName = Console.ReadLine();

            Console.WriteLine("Enter Price of the product.");
            var prodPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter CategoryID of the product.");
            var cateID = int.Parse(Console.ReadLine());

            productsRepo.CreateProduct(productName, prodPrice, cateID);

            products = productsRepo.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine(product.OnSale);
                Console.WriteLine(product.StockLevel);
            }

            Console.WriteLine();
            Console.WriteLine();

            //Update Product
            Console.WriteLine("Enter ProductID you want to update.");
            var prodID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the new Product Name.");
            var prodName = Console.ReadLine();

            productsRepo.UpdateProduct(prodID, prodName);

            products = productsRepo.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine(product.OnSale);
                Console.WriteLine(product.StockLevel);
            }

            //Delete Product
            Console.WriteLine("Enter ProductID you want to DELETE.");
            prodID = int.Parse(Console.ReadLine());

            productsRepo.DeleteProduct(prodID);

            products = productsRepo.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine(product.OnSale);
                Console.WriteLine(product.StockLevel);
            }

            #endregion
        }
    }
}
