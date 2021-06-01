using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PP.Core.Data;

namespace PP.Usuario.API.Models
{
    public interface IBiometriaRepository : IRepository<Biometria>
    {
        void Adicionar(Biometria biometria);
        void Atualizar(Biometria biometria);
        Task<IEnumerable<Biometria>> ObterTodos();
        Task<Biometria> ObterPorId(Guid id);
    }
}