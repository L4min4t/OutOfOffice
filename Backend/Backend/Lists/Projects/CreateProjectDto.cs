namespace Backend.Lists.Projects;

public class CreateProjectDto
{
    public int ProjectType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int ProjectManagerId { get; set; }
    public string Comment { get; set; }
    public int Status { get; set; }
}
