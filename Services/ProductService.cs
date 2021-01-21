using AutoMapper;
using DataAccess.Interfaces;
using DomainModels.Models;
using Microsoft.AspNetCore.Hosting;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebModels.ViewModels;


namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _hostingEnviroment;

        public ProductService(IRepository<Product> productRepo, IMapper mapper, IHostingEnvironment hostingEnviroment)
        {
            _productRepository = productRepo;
            _mapper = mapper;
            _hostingEnviroment = hostingEnviroment;
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
            PhotoUpload(product);

            _productRepository.Insert(_mapper.Map<Product>(product));
        }

               
        public void UpdateProduct(ProductViewModel product)
        {
            if(product.Photo != null)
            {
                //  Product removePreviousImage = _productRepository.GetById(product.ProductId);
                // DeletePhoto(removePreviousImage.PhotoPath); for theese two to work we need to add .AsNoTracking() method to the product repository and i don't know if it is a good idea at the moment.
                PhotoUpload(product);
            }
            
            _productRepository.Update(_mapper.Map<Product>(product));
        }

        public void RemoveProduct(int id)
        {
            _productRepository.Delete(id);
        }


        private void PhotoUpload(ProductViewModel model)
        {
             string uploadsForlder = Path.Combine(_hostingEnviroment.WebRootPath, "images/products");
             model.PhotoPath = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
             string filePath = Path.Combine(uploadsForlder, model.PhotoPath);

             model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
            

        }

        private void DeletePhoto(string photoPath)
        {
            var imagePathForRemoving = Path.Combine(_hostingEnviroment.WebRootPath, "images/products", photoPath);

            if (System.IO.File.Exists(imagePathForRemoving))
                System.IO.File.Delete(imagePathForRemoving);
        }

        // napravih update: rezultat slikta uste stoe vo proektot no e izbrisana od photopath vo databaza. nastanave nekoa zabuda so modelto za upload i delete mislam trebe dobar debug.
    }
}
