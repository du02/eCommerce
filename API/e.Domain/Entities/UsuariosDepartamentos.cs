using System.ComponentModel.DataAnnotations;

namespace e.Domain.Entities
{
    public class UsuariosDepartamentos
    {
        public int CdUsuarioDepartamento { get; set; }
        [Required]
        public int Cdusuario { get; set; }
        [Required]
        public int CdDepartamento { get; set; }
    }
}
