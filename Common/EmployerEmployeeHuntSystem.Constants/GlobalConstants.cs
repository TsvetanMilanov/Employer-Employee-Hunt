namespace EmployerEmployeeHuntSystem.Constants
{
    public class GlobalConstants
    {
        public const string AdministratorRoleName = "Administrator";
        public const string HeadhunterRoleName = "Headhunter";
        public const string UserRoleName = "User";

        public const string SuccessMessageTempDataKey = "SuccessMessageTempData";
        public const string ErrorMessageTempDataKey = "ErrorMessageTempData";

#if DEBUG
        public const string SkillsApiEndpoint = "http://localhost:2509/api/Skills/Names";
#else
        public const string SkillsApiEndpoint = "http://employer-employee-hunt.apphb.com/api/Skills/Names";
#endif
    }
}
