namespace ProjectTronic.Backend.Application.Dto;

public class UserDto
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedDatetime { get; set; }
}