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
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult AddColor(Color color)
        {
            try
            {
                _colorDal.Add(color);
                return new SuccessResult(Message.Added);
            }
            catch (Exception error)
            {

                return new ErrorResults(error.Message);
            }
        }

        public IResult DeleteColor(int Id)
        {
            try
            {
                var color = _colorDal.Get(x => x.Id == Id);
                _colorDal.Delete(color);
                return new SuccessResult(Message.Deleted);

            }
            catch (Exception)
            {

                return new ErrorResults(Message.Deleted);
            }
        }

        public IDataResult<List<Color>> GetAllColor()
        {
            
            try
            {
                var colors = _colorDal.GetAll();
                return new SuccessDataResult<List<Color>>(colors);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Color>>();
            }
        }

        public IDataResult<Color> GetById(int Id)
        {
            try
            {
                var color = _colorDal.Get(x => x.Id == Id);
                return new SuccessDataResult<Color>(color); 
            }
            catch (Exception)
            {

                return new ErrorDataResult<Color>();
            }
        }

        public IResult UpdateColor(Color color)
        {
            try
            {
                _colorDal.Update(color);
                return new SuccessDataResult<Color>(color);
            }
            catch (Exception)
            {

                return new ErrorDataResult<Color>();
            }
        }
    }
}
