namespace EmployerEmployeeHuntSystem.Data.DataImporters
{
    public interface IDataImporter
    {
        void SeedData(EmployerEmployeeHuntDbContext context);
    }
}
