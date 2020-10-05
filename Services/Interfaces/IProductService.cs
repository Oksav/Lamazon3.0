using System;
using System.Collections.Generic;
using System.Text;
using WebModels.ViewModels;

namespace Services.Interfaces
{
   public interface IProductService
    {
        IEnumerable<ProductViewModel> GetAllProducts();
        ProductViewModel GetProductById(int id);
        void CreateProduct(ProductViewModel product);
        void UpdateProduct(ProductViewModel product);
        void RemoveProduct(int id);
    }
}
