using Business.Abstract;
using Business.Constans;
using Core.Helpers.Results;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete.ErrorResult;
using Core.Helpers.Results.Concrete.SuccessResult;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult AddProduct(Product product)
        {
            try
            {
                _productDal.Add(product);
                return new SuccessResult(Message.Added); 
            }
            catch (Exception)
            {
                return new ErrorResults(Message.Deleted);
            }
        }

        public IResult DeleteProduct(int Id)
        {
            try
            {
                var product = _productDal.Get(x => x.Id == Id);
                _productDal.Delete(product);
                return new SuccessResult(Message.Deleted);
            }
            catch (Exception)
            {
                return new ErrorResults(Message.Deleted);    
  
            }
        }

        public IDataResult<List<Product>> GetAllProduct()
        {
            try
            {
                var products = _productDal.GetAll();
                return new SuccessDataResult<List<Product>>(products);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Product>>();
              
            }

        }

        public IDataResult<Product> GetById(int Id)
        {
            try
            {
                var product = _productDal.Get(x => x.Id == Id);
                return new SuccessDataResult<Product>(product); 
            }
            catch (Exception)
            {

               return new ErrorDataResult<Product>();
            }
        }

        public IResult UpdateProduct(Product product)
        {
            try
            {
                _productDal.Update(product);
                return new SuccessDataResult<Product>(product);
            }
            catch (Exception)
            {
                return new ErrorDataResult<Product>();
            }
        }
    }
}
