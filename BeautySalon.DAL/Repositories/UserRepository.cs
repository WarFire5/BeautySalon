using System.Data;
using BeautySalon.DAL.DTO;
using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.StoredProcedures;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BeautySalon.DAL.Repositories;

public class UserRepository : IUserRepository
{
    public List<UsersDTO> GetAllEmployees()
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Query<UsersDTO>(Procedures.GetAllEmployeesProcedure).ToList();
        }
    }

    public List<UsersDTO> GetClientByNameAndId(string name, int id)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
                Id = id,
                Name = name
            };
            return connection.Query<UsersDTO>(Procedures.GetClientByNameAndId, parameters).ToList();
        }
    }

    public List<UsersDTO> GetClientByNameAndPhone(string name, string phone)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
                Name = name,
                Phone = phone
            };
            return connection.Query<UsersDTO>(Procedures.GetClientByNameAndPhone, parameters).ToList();
        }
    }

    public List<UsersDTO> AddUserByChatId(int chatId, string userName, string name, string phone, string mail,
        int roleId, decimal salary, int isBlocked, int isDeleted)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
                ChatId = chatId,
                UserName = userName,
                Name = name,
                Phone = phone,
                Mail = mail,
                RoleID = roleId,
                Salary = salary,
                IsBlocked = isBlocked,
                IsDeleted = isDeleted
            };
            return connection.Query<UsersDTO>(Procedures.AddUserByChatId, parameters).ToList();
        }
    }

    public List<UsersDTO> GetMasterByNameAndId(string name, int id)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
                Name = name,
                Id = id
            };
            return connection.Query<UsersDTO>(Procedures.GetMasterByNameAndId, parameters).ToList();
        }
    }
}