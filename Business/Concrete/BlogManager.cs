using Business.Abstract;
using Business.Constans;
using Core.Helpers.Results;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete.ErrorResult;
using Core.Helpers.Results.Concrete.SuccessResult;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogManager : IBlogManager
    {
        private readonly IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public IResult AddBlog(BlogDTO blogDTO)
        {
            try
            {
                Blog blog = new Blog()
                {
                    Image= blogDTO.Image,
                    Id=blogDTO.Id,
                    Title = blogDTO.Title,
                    DateTimeUpdate = DateTime.Now,
                    IsDelete = false,
                    DateTime=DateTime.Now,
                    Description = blogDTO.Description,
                };
                _blogDal.Add(blog);
                return new SuccessResult(Message.AddBlog);
            }
            catch (Exception)
            {
              return new ErrorResults(Message.BlogNotAdd);
            }
        }

        public IResult DeleteBlog(int Id)
        {

            try
            {
                var blog = _blogDal.Get(x => x.Id == Id);
                blog.IsDelete = true;
                _blogDal.Update(blog);
                return new SuccessResult(Message.DeleteBlog);

            }
            catch (Exception)
            {

                return new ErrorResults(Message.DeleteBlog);
            }
        }

        public IDataResult<List<Blog>> GetAllBlog()
        {
            try
            {
               var blogs= _blogDal.GetAll();
                return new SuccessDataResult<List<Blog>>(blogs);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Blog>>();

            }
        }

        IDataResult<Blog> IBlogManager.GetById(int Id)
        {
            try
            {
                var blog = _blogDal.Get(x => x.Id == Id);
                return new SuccessDataResult<Blog>(blog);
            }
            catch (Exception)
            {

                return new ErrorDataResult<Blog>();
            }
        }

        IResult IBlogManager.UpdateBlog(BlogDTO blogDTO)
        {
            try
            {
                var blogDate = _blogDal.Get(x => x.Id == blogDTO.Id);
                Blog blog = new Blog()
                {
                    Image = blogDTO.Image,
                    Id = blogDTO.Id,
                    Title = blogDTO.Title,
                    DateTimeUpdate = DateTime.Now,
                    IsDelete = false,
                    DateTime = blogDate.DateTime,
                    Description = blogDTO.Description,
                };
                _blogDal.Update(blog);
                return new SuccessResult(Message.UpdateBlog);
            }
            catch (Exception)
            {
                return new ErrorResults(Message.BlogNotAdd);
            }


        }
    }
}
