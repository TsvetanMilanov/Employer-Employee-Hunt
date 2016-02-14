namespace EmployerEmployeeHuntSystem.Web.ViewModels.Manage
{
    using System.Collections.Generic;

    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;

    public class ManageLoginsViewModel : BaseViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }

        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }
}
