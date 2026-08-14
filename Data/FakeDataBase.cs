using SistemaChamados.Models;

namespace SistemaChamados.Data
{
    public class FakeDatabase
    {
        public static List<Ticket> Tickets { get; set; } = new List<Ticket>
        {
            new Ticket
            {
                Id = 1,
                Title = "Abrir chamado Mimaki",
                Description = "O Ton pediu para abrir chamado para a mesa Mimaki"
            },

            new Ticket
            {
                Id = 2,
                Title = "Solicitação de cabo de rede",
                Description = "O funcionário X pediu um cabo RJ45"
            }
        };
    }
}