using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        Product GetByUser(int user);
        Product Create(Product product, string name, string description, int user, int price);
        void Update(Product product, string name, string description, int user, int price);
        void Delete(int id);
    }

    public class ProductService : IProductService
    {
        private DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }


        public  IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public Product Create(Product product, string name, string description, int user, int price)
        {
            // validation
            if (string.IsNullOrWhiteSpace(name))
                throw new AppException("Name is required");

            if (string.IsNullOrWhiteSpace(description))
                throw new AppException("Description is required");
            

            if (_context.Products.Any(x => x.Name == product.Name))
                throw new AppException("Product  \"" + product.Name + "\" already exists");


            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        public void Update(Product productParam, string name, string description, int user, int price)
        {
            var product = _context.Products.Find(productParam.Id);

            if (product == null)
                throw new AppException("Product not found");

            // update productname if it has changed
            if (!string.IsNullOrWhiteSpace(productParam.Name) && productParam.Name != product.Name)
            {
                // throw error if the new Name is already taken
                // if (_context.Products.Any(x => x.Name == productParam.Name))
                //     throw new AppException("Name " + productParam.Name + " is already taken");

                product.Name = productParam.Name;
            }

            // update product properties if provided
            if (!string.IsNullOrWhiteSpace(productParam.Name))
                product.Name = productParam.Name;

            if (!string.IsNullOrWhiteSpace(productParam.Description))
                product.Description = productParam.Description;
                product.User = productParam.User;
                product.Price = productParam.Price;


            

            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public Product GetByUser(int user)
        {
            return _context.Products.Find(user);
        }

        // private helper methods

    }
}