using BeautySalon.DAL.DTO;
using BeautySalon.DAL.StoredProcedures;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace BeautySalon.DAL.Repositories
{
    public class ServicesRepository
    {
        public List<ServicesDTO> GetServicesWithPriceAndDuratonByTypeId(int typeId)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<ServicesDTO>(Procedures.GetServicesWithPriceAndDuratonByTypeId).ToList();
            }
        }

    }
}
