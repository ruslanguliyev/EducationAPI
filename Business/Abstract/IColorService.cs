using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult AddColor(Color color);
        IResult UpdateColor(Color color);
        IResult DeleteColor(int Id);
        IDataResult<Color> GetById(int Id);
        IDataResult<List<Color>> GetAllColor();
    }
}
