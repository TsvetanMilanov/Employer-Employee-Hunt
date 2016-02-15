namespace EmployerEmployeeHuntSystem.Services.Data.Contracts
{
    using System.Collections.Generic;

    public interface IStatisticsService
    {
        IDictionary<string, int> GetFullStatistics();
    }
}
