using System.ComponentModel.DataAnnotations;

namespace e.Domain.Entities
{
    public class Contato
    {
        public int CdContato { get; set; }
        [Required]
        public int CdUsuario { get; set; }
        public string NrTelefone { get; set; }
        public string NrCelular { get; set; }

        // 1:1
        public Usuario Usuario { get; set; }

    }
}
