using Dapper;
using e.Domain.Entities;
using e.Domain.IRepositories;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace e.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public UsuarioRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SQLite");
        }

        public Task<IEnumerable<Usuario>> Get()
        {
            using (var con = new SqliteConnection(_connectionString))
            {

            }

            throw new NotImplementedException();
        }

        public async Task<Usuario> GetByIdOneToOne(int id)
        {
            var query = @"
                        SELECT 
	                        U.CD_USUARIO AS CdUsuario,
	                        U.NM_USUARIO AS NmUsuario,
	                        U.E_MAIL AS Email,
	                        U.TP_SEXO AS TpSexo,
	                        U.NR_RG AS NrRG,
	                        U.NR_CPF AS NrCPF,
	                        U.NM_MAE AS NmMae,
	                        U.DS_SITUACAO_CADASTRO AS DsSituacaoCadastro,
	                        U.CREATED_AT AS CreatedAt,
	                        U.UPDATE_AT AS UpdateAt,
	                        C.CD_CONTATO AS CdContato,
	                        C.CD_USUARIO AS CdUsuario,
	                        C.NR_TELEFONE AS NrTelefone,
	                        C.NR_CELULAR AS NrCelular
                        FROM USUARIOS U	
	                        LEFT JOIN CONTATOS C ON U.CD_USUARIO = C.CD_CONTATO
                        WHERE U.CD_USUARIO = :Id";

            using (var con = new SqliteConnection(_connectionString))
            {
                return con.Query<Usuario, Contato, Usuario>(query, (usuario, contato) =>
                {
                    usuario.Contato = contato;
                    return usuario;
                }, 
                new { Id = id }, 
                splitOn: "CdContato").SingleOrDefault();
            }
        }

        public async Task<Usuario> GetByIdOneToMany(int id)
        {
            var query = @"
                        SELECT 
	                        U.CD_USUARIO AS CdUsuario,
	                        U.NM_USUARIO AS NmUsuario,
	                        U.E_MAIL AS Email,
	                        U.TP_SEXO AS TpSexo,
	                        U.NR_RG AS NrRG,
	                        U.NR_CPF AS NrCPF,
	                        U.NM_MAE AS NmMae,
	                        U.DS_SITUACAO_CADASTRO AS DsSituacaoCadastro,
	                        U.CREATED_AT AS CreatedAt,
	                        U.UPDATE_AT AS UpdateAt,
	                        C.CD_USUARIO AS CdUsuario,
	                        C.CD_CONTATO AS CdContato,
	                        C.NR_TELEFONE AS NrTelefone,
	                        C.NR_CELULAR AS NrCelular,
	                        E.CD_ENDERECOS_ENTREGA AS CdEnderecosEntrega,
	                        E.CD_USUARIO AS CdUsuario,
	                        E.NM_ENDERECO AS NmEndereco,
	                        E.DS_CEP AS DsCep,
	                        E.DS_CIDADE AS DsCidade,
	                        E.DS_ESTADO AS DsEstado,
	                        E.DS_BAIRRO AS DsBairro,
	                        E.DS_ENDERECO AS DsEndereco,
	                        E.DS_NUMERO AS DsNumero,
	                        E.DS_COMPLEMENTO AS DsComplemento
                        FROM USUARIOS U	
	                        LEFT JOIN CONTATOS C ON U.CD_USUARIO = C.CD_CONTATO
	                        LEFT JOIN ENDERECOS_ENTREGA E ON C.CD_CONTATO = E.CD_USUARIO 
                        WHERE U.CD_USUARIO = :Id";

           
            //List<Usuario> usuarios = new List<Usuario>();

            using (var con = new SqliteConnection(_connectionString))
            {
                /*
                con.Query<Usuario, Contato, EnderecoEntrega, Usuario>(query, (usuario, contato, enderecoEntrega) =>
                {
                    if (usuarios.SingleOrDefault(a => a.CdUsuario == usuario.CdUsuario) == null)
                    {
                        usuario.EnderecosEntrega = new List<EnderecoEntrega>();
                        usuario.Contato = contato;
                        usuarios.Add(usuario);
                    }
                    else
                    {
                        usuario = usuarios.SingleOrDefault(a => a.CdUsuario == usuario.CdUsuario);
                    }

                    usuario.EnderecosEntrega.Add(enderecoEntrega);
                    return usuario;
                });

                return usuarios.SingleOrDefault();
                */

                var usuarioDict = new Dictionary<int, Usuario>();
                con.Query<Usuario, Contato, EnderecoEntrega, Usuario>(query, (usuario, contato, enderecoEntrega) =>
                {
                    // Se o usuário ainda não foi adicionado, adicione
                    if (!usuarioDict.TryGetValue(usuario.CdUsuario, out var usuarioAtual))
                    {
                        usuarioAtual = usuario;
                        usuarioAtual.EnderecosEntrega = new List<EnderecoEntrega>();
                        usuarioAtual.Contato = contato;
                        usuarioDict.Add(usuarioAtual.CdUsuario, usuarioAtual);
                    }

                    // Adiciona o endereço de entrega ao usuário atual
                    if (enderecoEntrega is null)
                    {
                        usuarioAtual.EnderecosEntrega.Add(enderecoEntrega);
                    }

                    return usuarioAtual;
                },
                new { Id = id },
                splitOn: "CdContato, CdEnderecosEntrega");

                return usuarioDict.Values.SingleOrDefault();
            }
        }

        public Task<Usuario> GetByIdManyToMany(int id)
        {
            using (var con = new SqliteConnection(_connectionString))
            {

            }

            throw new NotImplementedException();
        }

        public Task<Usuario> Add(Usuario usuario)
        {
            using (var con = new SqliteConnection(_connectionString))
            {

            }

            throw new NotImplementedException();
        }

        public Task<Usuario> Update(Usuario usuario)
        {
            using (var con = new SqliteConnection(_connectionString))
            {

            }

            throw new NotImplementedException();
        }

        public Task<Usuario> UpdateById(int id)
        {
            using (var con = new SqliteConnection(_connectionString))
            {

            }

            throw new NotImplementedException();
        }

        public Task<Usuario> Delete(int id)
        {
            using (var con = new SqliteConnection(_connectionString))
            {

            }

            throw new NotImplementedException();
        }
    }
}
