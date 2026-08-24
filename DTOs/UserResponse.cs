namespace SistemaChamados.DTOs
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public DepartmentResponse Department { get; set; }
        public List<UserTicketResponse> Tickets { get; set; } = new();
    }
}
