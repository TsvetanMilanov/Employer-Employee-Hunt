namespace EmployerEmployeeHuntSystem.Services.Web.Github
{
    using System.Collections.Generic;

    public interface IGithubService
    {
        IEnumerable<GithubRepoJsonResponseModel> GetAllRepositoriesForUser(string userName);

        Dictionary<string, long> GetAllLanguagesFromGithubReposForUser(string userName);
    }
}
