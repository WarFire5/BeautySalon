using System.Data;
using BeautySalon.DAL.DTO;
using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.StoredProcedures;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BeautySalon.DAL.Repositories;

public class IntervalsRepository:IIntervalsRepository
{
    public List<IntеrvalsDTO> GetAllShiftsWithFreeIntervalsOnCurrentService()
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new {Id = 4};
            return connection.Query<IntеrvalsDTO>(Procedures.GetAllShiftsWithFreeIntervalsOnCurrentService,parameters).ToList();
        }
    }
}