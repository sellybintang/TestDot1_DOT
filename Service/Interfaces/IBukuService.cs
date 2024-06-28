using TestDot1_DOT.Models;

namespace TestDot1_DOT.Service.Interfaces
{
    public interface IBukuService
    {
        BukuViewModel Create(string NamaBuku, string KodeBuku, string Penerbit, string TahunPenerbit);
        List<BukuViewModel> GetAllBuku();
        BukuViewModel UpdateByKodeBuku(string NamaBuku, string KodeBuku, string Penerbit, string TahunPenerbit);
        bool Delete(string KodeBuku);
    }
}
