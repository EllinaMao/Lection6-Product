namespace Lection1.Models
{

    public class ProductRepository
    {
        private static List<Product> products = new List<Product>();


        public IEnumerable<Product> GetAll()
        {
            return products;
        }
        public void Add(Product product)
        {
            if (product.Id == 0)
            {
                int nextId = products.Any() ? products.Max(p => p.Id) + 1 : 1;
                product.Id = nextId;
            }

            if (product.Id == GetById(product.Id)?.Id)
            {
                throw new ArgumentException($"Product with Id {product.Id} already exists.");
            }

            products.Add(product);
        }
        public IEnumerable<Product> Search(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                throw new ArgumentException("Keyword cannot be null or empty.", nameof(keyword));
            }
            return products.Where(p => p.Name.Contains(keyword.Trim(), StringComparison.OrdinalIgnoreCase) ||
                                       p.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }
        public Product GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be a positive integer.", nameof(id));
            }
            return products.FirstOrDefault(p => p.Id == id);
        }
        public Product Delete(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be a positive integer.", nameof(id));
            }
            var product = GetById(id);
            if (product != null)
            {
                products.Remove(product);
            }
            return product;
        }
    }


}
