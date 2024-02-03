using BeautySalon.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.DAL.IRepositories
{
    public interface ITypesRepository
    {
        public List<TypesDTO> GetServiceType();
    }
}
