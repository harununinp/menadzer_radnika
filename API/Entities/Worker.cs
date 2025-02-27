namespace API.Entities
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string HireDate { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public int ProjectId { get; set; }
        public Project? Project { get; set; }

    }

   
}
