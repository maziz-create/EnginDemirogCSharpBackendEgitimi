﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                //Oracle, Sql Server, Postgres, MongoDb
                new Product{ProductId=1, CategoryID=1, ProductName="Bardak", UnitPrice=15, UnitsInStock = 15},
                new Product{ProductId=2, CategoryID=1, ProductName="Kamera", UnitPrice=500, UnitsInStock = 3},
                new Product{ProductId=3, CategoryID=2, ProductName="Telefon", UnitPrice=1500, UnitsInStock = 2},
                new Product{ProductId=4, CategoryID=2, ProductName="Klavye", UnitPrice=150, UnitsInStock = 65},
                new Product{ProductId=5, CategoryID=2, ProductName="Fare", UnitPrice=85, UnitsInStock = 1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products; //veritabanına olduğu gibi döndür.
        }

        public void Update(Product product)
        {
            //gönderdiğim ürün id'sine sahip ürünü bul. silmek istediğim ürünün ürün ID ' si ne ?
            Product productToUpdate = _products.FirstOrDefault(p=>p.ProductId==product.ProductId);

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.CategoryID = product.CategoryID;
        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryID == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
