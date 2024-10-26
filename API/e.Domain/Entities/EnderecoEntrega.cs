using System.ComponentModel.DataAnnotations;

namespace e.Domain.Entities
{
    public class EnderecoEntrega
    {
        public int CdEnderecosEntrega { get; set; }
        [Required]
        public int CdUsuario { get; set; }
        public string NmEndereco { get; set; }
        public string DsCep { get; set; }
        [StringLength(2, MinimumLength = 2)]
        public string DsEstado { get; set; }
        public string DsCidade { get; set; }
        public string DsBairro { get; set; }
        public string DsEndereco { get; set; }
        public string DsNumero { get; set; }
        public string DsComplemento { get; set; }

        // 1:1
        public Usuario Usuario { get; set; }
    }
}
