using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            //DB'den gelen veri
            _products = new List<Product> {
                new Product{ProcutId =1, CategoryId =1, ProductName = "Tablet", UnitPrice =7500, UnitInStock = 30},
                new Product{ProcutId =2, CategoryId =1, ProductName = "Kamera", UnitPrice =2200, UnitInStock = 30},
                new Product{ProcutId =3, CategoryId =2, ProductName = "Bardak", UnitPrice =15, UnitInStock = 30}
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p=>p.ProcutId == product.ProcutId);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p=> p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProcutId == product.ProcutId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId= product.CategoryId;
        }
    }
}
