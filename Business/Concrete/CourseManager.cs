using Business.Abstract;
using Business.Constans;
using Core.Helpers.Results;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete.ErrorResult;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CourseManager : ICourseService
    {
        private readonly ICourseDal _courseDal;

        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public IResult Add(Course course)
        {
            try
            {
                _courseDal.Add(course);
                return new SuccessResult(Message.Added);
            }
            catch (Exception error)
            {

                return new ErrorResults(error.Message);   
            }
        }

        public IResult Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Course>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Course> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
