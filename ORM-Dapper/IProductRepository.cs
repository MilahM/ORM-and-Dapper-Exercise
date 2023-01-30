using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public interface IProductRepository
    {
        IEnumerable<Products> GetAllProducts();
        public void CreateProduct(string name, double price, int categoryID);

        public void DeleteProduct(int productID);

        public void UpdateProduct(int productID, string name);

    }
}
