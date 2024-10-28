using e.Domain.Entities;

namespace e.Domain.IRepositories
{
    public interface IUsuarioRepository
    {
        public Task<IEnumerable<Usuario>> Get();
        public Task<Usuario> GetByIdOneToOne(int id);
        public Task<Usuario> GetByIdOneToMany(int id);
        public Task<Usuario> GetByIdManyToMany(int id);
        public Task<Usuario> Add(Usuario usuario);
        public Task<Usuario> Update(Usuario usuario);
        public Task<Usuario> UpdateById(int id);
        public Task<Usuario> Delete(int id);
    }
}
