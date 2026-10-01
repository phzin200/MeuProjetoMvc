using MeuProjetoMvc.Models;

namespace MeuProjetoMvc.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario? ObterPorEmail(string email);
        void Adicionar(Usuario usuario);
        void SalvarAlteracoes();
    }
}