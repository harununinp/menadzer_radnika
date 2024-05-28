public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Manager { get; set; } = string.Empty;
    public List<API.Entities.Worker> Workers { get; set; } = new();
}