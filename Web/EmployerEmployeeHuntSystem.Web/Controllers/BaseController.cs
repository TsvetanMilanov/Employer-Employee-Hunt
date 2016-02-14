namespace EmployerEmployeeHuntSystem.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using Constants;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Services.Web;

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

        protected User GetCurrentUser()
        {
            var user = System.Web.HttpContext.Current
                .GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            return user;
        }

        protected void SetTempDataSuccessMessage(string message)
        {
            this.TempData[GlobalConstants.SuccessMessageTempDataKey] = message;
        }

        protected void SetTempDataErrorMessage(string message)
        {
            this.TempData[GlobalConstants.ErrorMessageTempDataKey] = message;
        }
    }
}
