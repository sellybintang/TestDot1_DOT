using TestDot1_DOT.Models;
using TestDot1_DOT.Repositories.Entities;

namespace TestDot1_DOT.Repositories.Interface
{
    public interface IBukuRepository
    {
        void Create(TblsBuku entity);
        List<BukuViewModel> getAllBuku();
        bool getBukuByKodeBuku(string kodeBuku);
        bool Delete(string kodeBuku);
    }
}
