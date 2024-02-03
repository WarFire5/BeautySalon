using BeautySalon.DAL.DTO;

namespace BeautySalon.DAL.IRepositories;

public interface IIntervalsRepository
{
    public List<IntеrvalsDTO> GetAllShiftsWithFreeIntervalsOnCurrentService();
}