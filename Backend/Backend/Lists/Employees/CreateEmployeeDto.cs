namespace Backend.Lists.Employees;

public class CreateEmployeeDto
{
    public string FullName { get; set; }
    public Subdivision? Subdivision { get; set; }
    public Position? Position { get; set; }
    public EmployeeStatus Status { get; set; }
    public int? PeoplePartnerId { get; set; }
    public int OutOfOfficeBalance { get; set; }
    public byte[]? Photo { get; set; }
    public string IdentityId { get; set; }
}