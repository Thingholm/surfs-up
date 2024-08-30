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
            if(product == null)
                return;

            Product productToUpdate = GetProductById(product.Id);
            if (productToUpdate == null)
                return;
            productToUpdate = product;   

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
            foreach(Product product in products)
            {
                products.Add(product);
                
            }
            return products;
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

