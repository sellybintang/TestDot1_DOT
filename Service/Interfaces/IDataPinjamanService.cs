using TestDot1_DOT.Models;

namespace TestDot1_DOT.Service.Interfaces
{
    public interface IDataPinjamanService
    {
        DataPinjamanViewModel Create(string KodeSiswa, string KodeBuku, DateTime WaktuPinjaman, DateTime WaktuPengembalian);
        List<DataPinjamanViewModel> GetBukuByKodeSiswa(string kodeSiswa);
        bool delete(string KodeSiswa, string KodeBuku);
    }
}
