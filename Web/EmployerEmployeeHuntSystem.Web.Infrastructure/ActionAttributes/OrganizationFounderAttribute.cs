namespace EmployerEmployeeHuntSystem.Web.Infrastructure.ActionAttributes
{
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;

    public class OrganizationFounderAttribute : AuthorizeAttribute
    {
        public string OrganizationIdKey { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            var context = filterContext.HttpContext;

            int organizationId = int.Parse(context.Request.Params[this.OrganizationIdKey]);

            if (context.User.Identity.GetUserId() != DependencyResolver.Current.GetService<IOrganizationsService>().GetById(organizationId).Founder.Id)
            {
                filterContext.Result = new RedirectResult("/");
            }
        }
    }
}
