using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthManager>();
            builder.RegisterType<UserManager>().As<IUserManager>();
            builder.RegisterType<UserDal>().As<IUserDal>();
            builder.RegisterType<BlogDal>().As<IBlogDal>();
            builder.RegisterType<BlogManager>().As<IBlogManager>();
            builder.RegisterType<CourseManager>().As<ICourseService>();
            builder.RegisterType<CourseDal>().As<ICourseDal>();
            builder.RegisterType<ColorManager>().As<IColorService>();
            builder.RegisterType<ColorDal>().As<IColorDal>();
            builder.RegisterType<ChooseManager>().As<IChooseService>();
            builder.RegisterType<ChooseDal>().As<IChooseDal>();
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<ProductDal>().As<IProductDal>();
        }
    }
}
