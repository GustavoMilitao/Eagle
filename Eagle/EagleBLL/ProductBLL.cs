using EagleEntities;
using EagleDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleBLL
{
    public class ProductBLL
    {
        private ProductDAL productDAL;

        public ProductDAL ProductDAL
        {
            get
            {
                if (productDAL == null)
                    productDAL = new ProductDAL();
                return productDAL;
            }
        }

        public int InsertProduct(Product product)
        {
            return ProductDAL.InsertProduct(product);
        }

        public bool UpdateProduct(Product product)
        {
            return ProductDAL.UpdateProduct(product);
        }

        public Product getProductByID(int id)
        {
            return ProductDAL.getProductByID(id);
        }

        public bool DeleteProductByID(int id)
        {
            return ProductDAL.DeleteProductByID(id);
        }

        public List<Product> ListProducts()
        {
            return ProductDAL.ListProducts();
        }
    }
}

