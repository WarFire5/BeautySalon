using BeautySalon.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.DAL.IRepositories
{
    public interface IServicesRepository
    {
        public List<ServicesDTO> GetServicesWithPriceAndDuratonByTypeId(int typeId);
    }
}
