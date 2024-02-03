using BeautySalon.DAL.DTO;

namespace BeautySalon.DAL.IRepositories;

public interface IUserRepository
{
    public List<UsersDTO> AddUserByChatId(int chatId,string userName ,string name, string phone, string mail, int roleId, decimal salary,int isBlocked, int isDeleted);
    public List<UsersDTO> GetClientByNameAndId(string name, int id);
    public List<UsersDTO> GetClientByNameAndPhone(string name, string phone);
    public List<UsersDTO> GetMasterByNameAndId(string name, int id);
<<<<<<< HEAD
    public List<UsersDTO> GetMasterByNameAndPhone(string name, string phone);
    public List<UsersDTO> GetAllWorkersByRoleId();
    public List<UsersDTO> GetAllWorkersWithContactsByUserId();
    public void AddWorkerByRoleId(int role, string name, string phone, string mail);
    public void RemoveUserById(int id);
    public void GetAllShiftsOnToday();
    public void GetAllShiftsWithFreeIntervalsOnCurrentService();
    public void AddMasterToShift(int masterId, int shiftId);
=======
    public List<GetAllWorkersWithContactsByUserIdDTO> GetAllWorkersWithContactsByUserId();
>>>>>>> TatianaYstinova/Task_GetAllWorkersWithContactsByUserId
}