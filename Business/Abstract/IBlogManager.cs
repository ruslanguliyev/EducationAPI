using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlogManager
    {
        IResult AddBlog(BlogDTO blogDTO);
        IResult UpdateBlog(BlogDTO blogDTO);
        IResult DeleteBlog(int Id);
        IDataResult<Blog>  GetById(int Id);
        IDataResult <List<Blog>> GetAllBlog();

    }
}
