using AutoMapper;
using DataAccess.Interfaces;
using DomainModels.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using WebModels.ViewModels;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> productRepo, IMapper mapper)
        {
            _productRepository = productRepo;
            _mapper = mapper;
        }

              

        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(_productRepository.GetAll());
        }

        public ProductViewModel GetProductById(int id)
        {
            Product product = _productRepository.GetById(id);
            if (product == null) throw new Exception("The product does noe exist.");

            return _mapper.Map<ProductViewModel>(product);
        }

        public void CreateProduct(ProductViewModel product)
        {
            _productRepository.Insert(_mapper.Map<Product>(product));
        }
               
        public void UpdateProduct(ProductViewModel product)
        {
            _productRepository.Update(_mapper.Map<Product>(product));
        }

        public void RemoveProduct(int id)
        {
            _productRepository.Delete(id);
        }
    }
}
