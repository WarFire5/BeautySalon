namespace BeautySalon.DAL.DTO;

public class UsersDTO
{
    public int? Id { get; set; }

    public int? ClientsId { get; set; }
    public string? MasterId { get; set; }
    public string? Client { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string? Phone { get; set; }
    public string? Mail { get; set; }
    public int? RoleId { get; set; }
    public string? Master { get; set; }
    public List<RolesDTO> Roles { get; set; }
    public decimal? Salary { get; set; }
    public int ChatId { get; set; }
    public bool? IsBlocked { get; set; }

    public bool? IsDeleted { get; set; }
}