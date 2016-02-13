namespace EmployerEmployeeHuntSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using EmployerEmployeeHuntSystem.Common;
    using EmployerEmployeeHuntSystem.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
    }
}
