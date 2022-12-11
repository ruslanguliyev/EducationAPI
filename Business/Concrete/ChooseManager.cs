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
    public class ChooseManager : IChooseService
    {
        private readonly IChooseDal? _chooseDal;

        public ChooseManager(IChooseDal? chooseDal)
        {
            _chooseDal = chooseDal;
        }

        public IResult AddChoose(Choose choose)
        {
            try
            {
                _chooseDal.Add(choose);
                return new SuccessResult(Message.CourseSuccessAdd);
            }
            catch (Exception error)
            {

                return new ErrorResults(error.Message);
            }

        }
    }
}
