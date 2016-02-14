namespace EmployerEmployeeHuntSystem.Services.Web.Github
{
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using Newtonsoft.Json;

    public class GithubService : IGithubService
    {
        private const string GithubApiGetReposForUserUrlFormat = "https://api.github.com/users/{0}/repos";
        private const string GithubApiGetLanguagesForUserReposUrlFormat = "https://api.github.com/repos/{0}/{1}/languages";

        public IEnumerable<GithubRepoJsonResponseModel> GetAllRepositoriesForUser(string userName)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format(GithubApiGetReposForUserUrlFormat, userName));
            request.ContentType = "application/json";
            request.UserAgent =
               "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0;" +
               ".NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.4506.2152; InfoPath.2;" +
               ".NET CLR 3.5.21022; .NET CLR 3.5.30729; .NET4.0C; .NET4.0E)";

            string responseText;
            var response = (HttpWebResponse)request.GetResponse();

            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                responseText = sr.ReadToEnd();
            }

            var deserializedResult = JsonConvert.DeserializeObject<IEnumerable<GithubRepoJsonResponseModel>>(responseText);

            return deserializedResult;
        }

        public Dictionary<string, long> GetAllLanguagesFromGithubReposForUser(string userName)
        {
            Dictionary<string, long> allLanguages = new Dictionary<string, long>();

            var repos = this.GetAllRepositoriesForUser(userName);

            foreach (var repo in repos)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format(GithubApiGetLanguagesForUserReposUrlFormat, userName, repo.Name));
                request.ContentType = "application/json";
                request.UserAgent =
                   "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0;" +
                   ".NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.4506.2152; InfoPath.2;" +
                   ".NET CLR 3.5.21022; .NET CLR 3.5.30729; .NET4.0C; .NET4.0E)";

                string responseText;
                var response = (HttpWebResponse)request.GetResponse();

                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    responseText = sr.ReadToEnd();
                }

                Dictionary<string, long> languages = JsonConvert.DeserializeObject<Dictionary<string, long>>(responseText);

                foreach (var language in languages)
                {
                    if (allLanguages.ContainsKey(language.Key))
                    {
                        allLanguages[language.Key] += language.Value;
                    }
                    else
                    {
                        allLanguages.Add(language.Key, language.Value);
                    }
                }
            }

            return allLanguages;
        }
    }
}
