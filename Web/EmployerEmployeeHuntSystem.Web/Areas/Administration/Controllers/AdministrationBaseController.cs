namespace EmployerEmployeeHuntSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using Constants;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationBaseController : BaseController
    {
    }
}
