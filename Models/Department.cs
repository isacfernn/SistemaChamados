namespace SistemaChamados.Models
{
    public class Department
    {
        public int Id { get; set; }

        public Sectors Sector { get; set; }

        public List<User> Users { get; set; }

        public List<Ticket> Tickets { get; set; } = new();
    }

    public enum Sectors
    {
        Ti = 1,
        Vendas = 2,
        Financeiro = 3,
        Rh = 4,
        Producao = 5,
        Gerencia = 6,
        Layout = 7
    }
}