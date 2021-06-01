using System.Threading.Tasks;

namespace PP.Core.Data
{
    public interface IUnitOfWork {
        Task<bool> Commit();
    }
}