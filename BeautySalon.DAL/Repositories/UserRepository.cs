using System.Data;
using BeautySalon.DAL.DTO;
using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.StoredProcedures;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BeautySalon.DAL.Repositories;

public class UserRepository : IUserRepository
{
    public List<UsersDTO> AddUserByChatId(UsersDTO usersDTO)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
                ChatId = usersDTO.ChatId,
                UserName = usersDTO.UserName,
                Name = usersDTO.Name,
                Phone = usersDTO.Phone,
                Mail = usersDTO.Mail,
                RoleID = usersDTO.RoleId,
                Salary = usersDTO.Salary,
                IsBlocked = usersDTO.IsBlocked,
                IsDeleted = usersDTO.IsDeleted,
            };
            return connection.Query<UsersDTO>(Procedures.AddUserByChatId, parameters).ToList();
        }
    }

    public List<GetMastersShiftsById> GetMastersShiftsById(int id)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
                Id = id
            };
            return connection
                .Query<GetMastersShiftsById, ShiftsDTO, GetMastersShiftsById>(
                    Procedures.GetMastersShiftsById,
                    (master, shifts) =>
                    {
                        if (master.Shifts == null)
                        {
                            master.Shifts = new List<ShiftsDTO>();
                        }

                        master.Shifts.Add(shifts);
                        return master;
                    }, parameters, splitOn: "Id").ToList();
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

    public List<UsersDTO> GetMasterByNameAndPhone(string name, string phone)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
                Name = name,
                Phone = phone
            };
            return connection.Query<UsersDTO>(Procedures.GetMasterByNameAndPhone, parameters).ToList();
        }
    }

    public List<UsersDTO> GetAllWorkersByRoleId()
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Query<UsersDTO>(Procedures.GetAllWorkersByRoleId).ToList();
        }
    }

    public List<GetAllChatIdDTO> GetAllChatId()
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Query<GetAllChatIdDTO>(Procedures.GetAllChatId).ToList();
        }
    }

    public List<GetAllWorkersWithContactsByUserIdDTO> GetAllWorkersWithContactsByUserId()
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection
                .Query<GetAllWorkersWithContactsByUserIdDTO, RolesDTO, GetAllWorkersWithContactsByUserIdDTO>(
                    Procedures.GetAllWorkersWithContactsByUserId,
                    (users, roles) =>
                    {
                        if (users.Roles == null)
                        {
                            users.Roles = new List<RolesDTO>();
                        }

                        users.Roles.Add(roles);
                        return users;
                    }, splitOn: "Id,Worker").ToList();
        }
    }

    public void AddWorkerByRoleId(AddWorkerByRoleIdDTO addWorkerByRoleIdDTO)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
                WorkerRole = addWorkerByRoleIdDTO.RoleId,
                WorkerName = addWorkerByRoleIdDTO.Name,
                WorkerPhone = addWorkerByRoleIdDTO.Phone,
                WorkerMail = addWorkerByRoleIdDTO.Mail
            };
            connection.Query<UsersDTO>(Procedures.AddWorkerByRoleId, parameters);
        }
    }
    
    public UsersDTO RemoveUserById(int id)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
                Id = id
            };
            var result=connection.QuerySingle<UsersDTO>(Procedures.RemoveUserById, parameters);
            return result;
        }
    }

    public void ChangeMasterInShift(int masterId, int shiftId)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
                MasterId = masterId,
                ShiftId = shiftId
            };
            connection.Query<UsersDTO>(Procedures.ChangeMasterInShift, parameters);
        }
    }

    public void RemoveMasterFromShift(int masterId, int shiftId)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
                MasterId = masterId,
                ShiftId = shiftId
            };
            connection.Query<UsersDTO>(Procedures.RemoveMasterFromShift, parameters);
        }
    }

    public List<GetFreeMastersAndIntervalsOnTodayDTO> GetFreeMastersAndIntervalsOnToday()
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Query<GetFreeMastersAndIntervalsOnTodayDTO, IntеrvalsDTO, GetFreeMastersAndIntervalsOnTodayDTO>(
                Procedures.GetFreeMastersAndIntervalsOnToday,
                (users, intervals) =>
                {
                    if (users.Intervals == null)
                    {
                        users.Intervals = new List<IntеrvalsDTO>();
                    }
                    users.Intervals.Add(intervals);
                    return users;
                }, splitOn: "Id,Title").ToList();
        }
    }
}
