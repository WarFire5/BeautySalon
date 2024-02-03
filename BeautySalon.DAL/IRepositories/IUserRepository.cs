using BeautySalon.DAL.DTO;

namespace BeautySalon.DAL.IRepositories;

public interface IUserRepository
{
    public List<UsersDTO> GetAllEmployees();
    public List<UsersDTO> GetClientByNameAndId(string name, int id);
    public List<UsersDTO> GetClientByNameAndPhone(string name, string phone);
    public List<UsersDTO> AddUserByChatId(int chatId,string userName ,string name, string phone, string mail, int roleId, decimal salary,int isBlocked, int isDeleted);
    public List<UsersDTO> GetMasterByNameAndId(string name, int id);
}