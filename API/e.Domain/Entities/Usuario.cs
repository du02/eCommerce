using System.ComponentModel.DataAnnotations;

namespace e.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public int CdUsuario { get; set; }
        [Required]
        public string NmUsuario { get; set; }
        public string Email { get; set; }
        public char TpSexo { get; set; }
        public string NrRG { get; set; }
        [Required]
        public string NrCPF { get; set; }
        [Required]
        public string NmMae { get; set; }
        public char DsSituacaoCadastro { get; set; }

        // 1:1
        public Contato Contato { get; set; }

        // 1:N
        public ICollection<EnderecoEntrega> EnderecosEntrega { get; set; }

        // N:N
        public ICollection<Departamento> Departamentos { get; set; }
    }
}
