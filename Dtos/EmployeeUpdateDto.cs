namespace EmployeeAPI.Dtos
{
    public class EmployeeUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}