namespace EmployerEmployeeHuntSystem.Web.Areas.Headhunter.Controllers
{
    using System.Web.Mvc;
    using Constants;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.HeadhunterRoleName + ", " + GlobalConstants.AdministratorRoleName)]
    public class HeadhuntersBaseController : BaseController
    {
    }
}
