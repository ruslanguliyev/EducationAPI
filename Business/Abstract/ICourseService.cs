using Core.Helpers.Results.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICourseService
    {
        IResult Add(Course course);
        IResult Update(Course course);
        IResult Delete(int Id);
        IDataResult<List<Course>> GetAll();
        IDataResult<Course> GetById(int Id);



    }
}
