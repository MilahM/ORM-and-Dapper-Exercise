using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;

        public DapperProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _conn.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @categoryID);", new {@name =name, @price= price, @categoryID = categoryID});
        }

        public void DeleteProduct(int productID)
        {
            _conn.Execute("DELETE FROM products WHERE productID = @productID;", new {productID});   
        }

        public IEnumerable<Products> GetAllProducts()
        {
            return _conn.Query<Products>("SELECT * FROM products;");
        }

        public void UpdateProduct(int productID, string name)
        {
            _conn.Execute("UPDATE products SET Name = @name WHERE ProductID= @productID;", new { productID, name });
        }
    }
}
