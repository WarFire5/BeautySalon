using BeautySalon.DAL.DTO;

namespace BeautySalon.DAL.IRepositories;

public interface IRolesRepository
{
    public List<RolesDTO> GetAllRoles();
}