namespace BeautySalon.DAL.StoredProcedures;

public class Procedures
{
    public const string GetAllOrdersForClientProcedure = "GetAllOrdersForClient"; //её нет на сервере!
    public const string GetAllEmployeesProcedure = "GetAllEmployees"; //её нет на сервере!
    public const string GetServiceType = "GetServiceType";
    public const string GetServicesWithPriceAndDuratonByTypeId = "GetServicesWithPriceAndDuratonByTypeId";
    public const string GetAllShiftsWithFreeIntervalsOnCurrentService = "GetAllShiftsWithFreeIntervalsOnCurrentService";
    public const string GetAllRolesProcedure = "GetAllRolesProcedure";
    public const string GetClientByNameAndId = "GetClientByNameAndId";
    public const string GetClientByNameAndPhone = "GetClientByNameAndPhone";
    public const string AddUserByChatId = "AddUserByChatId";
    public const string GetMasterByNameAndId = "GetMasterByNameAndId";
}