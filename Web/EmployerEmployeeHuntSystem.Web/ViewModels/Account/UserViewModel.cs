namespace EmployerEmployeeHuntSystem.Web.ViewModels.Account
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public DeveloperProfile DeveloperProfile { get; set; }

        public HeadhunterProfile HeadhunterProfile { get; set; }
    }
}
