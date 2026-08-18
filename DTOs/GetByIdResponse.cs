using System.Reflection.Metadata.Ecma335;

namespace SistemaChamados.DTOs
{
    public class GetByIdResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
