using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ProductDal : EFRepositoryBase<Product, AppDbContext>, IProductDal
    {
        public List<Product> GetByColor(int colorId)
        {
            throw new NotImplementedException();
        }
    }
}
