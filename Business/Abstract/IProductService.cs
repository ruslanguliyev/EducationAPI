using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService 
    {
        IResult AddProduct(Product product);
        IResult UpdateProduct(Product product);
        IResult DeleteProduct(int Id);
        IDataResult<Product> GetById(int Id);
        IDataResult<List<Product>> GetAllProduct();
    }
}
