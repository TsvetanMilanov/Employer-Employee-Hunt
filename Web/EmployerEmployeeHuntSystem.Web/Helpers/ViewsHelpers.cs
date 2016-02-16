namespace EmployerEmployeeHuntSystem.Web.Helpers
{
    using System.Web;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using ViewModels.Account;

    public static class ViewsHelpers
    {
        public static UserViewModel GetCurrentUser()
        {
            var user = HttpContext.Current
                   .GetOwinContext()
                   .GetUserManager<ApplicationUserManager>()
                   .FindById(HttpContext.Current.User.Identity.GetUserId());

            return AutoMapperConfig.Configuration.CreateMapper().Map<UserViewModel>(user);
        }
    }
}
