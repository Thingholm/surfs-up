using SurfsUpWebApp.Models;

namespace SurfsUpWebApp.Repositories
{
    public class ProductRepository
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void Update(Product product)
        {
            if (product == null)
                return;

            Product productToUpdate = GetProductById(product.Id);
            if (productToUpdate == null)
                return;

            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.Type = product.Type;
           
        }

        public Product GetProductById(int Id)
        {
            foreach (Product product in products)
            {
                if(product.Id == Id)
                    return product;

            }

            return null;
         
        }

        public List<Product> GetAllProducts()
        {
            
            return new List<Product>(products);
        }


        public Product GetProductByType(string type)
        {
            foreach(Product product in products)
            {
                if(product.Type == type) 
                    return product;
            }

            return null;
        }


        public void DeleteProduct(Product product)
        {
           products.Remove(product);
        }
    }
}

