namespace EmployerEmployeeHuntSystem.Services.Data.Contracts
{
    using System.Linq;

    public interface IUsersService
    {
        IQueryable<string> GetUsersUserNames(string filter);
    }
}
