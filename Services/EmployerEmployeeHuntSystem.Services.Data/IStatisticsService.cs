namespace EmployerEmployeeHuntSystem.Services.Data
{
    using System.Collections.Generic;

    public interface IStatisticsService
    {
        IDictionary<string, int> GetFullStatistics();
    }
}
