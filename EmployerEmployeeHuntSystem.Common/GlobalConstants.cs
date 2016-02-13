namespace EmployerEmployeeHuntSystem.Common
{
    public class GlobalConstants
    {
        public const string AdministratorRoleName = "Administrator";

#if DEBUG
        public const string DbConnectionStringName = "DefaultConnection";
#else
        public const string DbConnectionStringName = "ProductionConnection";
#endif
    }
}
