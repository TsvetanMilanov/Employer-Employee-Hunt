namespace EmployerEmployeeHuntSystem.Web.ViewModels
{
    using System.Web;
    using Account;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    public class BaseViewModel
    {
        public BaseViewModel()
        {
            var user = HttpContext.Current
                .GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(HttpContext.Current.User.Identity.GetUserId());

            this.CurrentUser = AutoMapperConfig.Configuration.CreateMapper().Map<UserViewModel>(user);
        }

        public UserViewModel CurrentUser { get; set; }
    }
}
