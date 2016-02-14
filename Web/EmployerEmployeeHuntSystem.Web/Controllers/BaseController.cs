namespace EmployerEmployeeHuntSystem.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Services.Web;
    using ViewModels.Account;
    public abstract class BaseController : Controller
    {
        public ICacheService Cache { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }

        protected UserViewModel GetCurrentUser(string id)
        {
            User user = System.Web.HttpContext.Current
                .GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(id);

            return AutoMapperConfig.Configuration.CreateMapper().Map<UserViewModel>(user);
        }
    }
}
