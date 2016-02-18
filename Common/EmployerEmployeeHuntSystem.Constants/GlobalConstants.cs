namespace EmployerEmployeeHuntSystem.Constants
{
    public class GlobalConstants
    {
        public const string AdministratorRoleName = "Administrator";
        public const string HeadhunterRoleName = "Headhunter";
        public const string UserRoleName = "User";

        public const string SuccessMessageTempDataKey = "SuccessMessageTempData";
        public const string ErrorMessageTempDataKey = "ErrorMessageTempData";

        public const int DefaultPageSize = 10;

        public const int DefaultTopEntriesCount = 10;

#if DEBUG
        public const string SkillsApiEndpoint = "http://localhost:2509/Skills/Names";
        public const string RolesApiEndpoint = "http://localhost:2509/Administration/Roles/Names";
        public const string UsersApiEndpoint = "http://localhost:2509/Administration/Users/Names";
#else
        public const string SkillsApiEndpoint = "http://employer-employee-hunt.apphb.com/Skills/Names";
        public const string RolesApiEndpoint = "http://employer-employee-hunt.apphb.com/Administration/Roles/Names";
        public const string UsersApiEndpoint = "http://employer-employee-hunt.apphb.com/Administration/Users/Names";
#endif
    }
}
