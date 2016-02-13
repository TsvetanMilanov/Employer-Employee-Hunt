namespace EmployerEmployeeHuntSystem.Services.Data
{
    using System.Collections.Generic;

    public interface IStatisticsServices
    {
        IDictionary<string, int> GetFullStatistics();
    }
}
