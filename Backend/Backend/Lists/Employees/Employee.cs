using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Enums;

namespace Backend.Lists.Employees;

public class Employee
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
}