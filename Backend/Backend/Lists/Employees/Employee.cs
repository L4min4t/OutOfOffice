using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Lists.Employees;

public class Employee : IEntity
{
    public int Id { get; set; }

    public string FullName { get; set; }

    public Subdivision? Subdivision { get; set; }
    public Position? Position { get; set; }
    public EmployeeStatus Status { get; set; }

    public int? PeoplePartnerId { get; set; }
    public Employee PeoplePartner { get; set; }

    public int OutOfOfficeBalance { get; set; }

    public byte[]? Photo { get; set; }
    
    public string IdentityId { get; set; }
}

public enum EmployeeStatus
{
    Inactive,
    Active
}

public enum Position
{
    Developer,
    Manager,
    QA,
    HRManager,
    Analyst
}

public enum Subdivision
{
    IT,
    HR,
    Finance,
    Marketing,
    Sales
}