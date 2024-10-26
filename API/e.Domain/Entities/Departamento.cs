namespace e.Domain.Entities
{
    public class Departamento
    {
        public int CdDepartamento { get; set; }
        public string NmDepartamento { get; set; }

        // N:N
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
