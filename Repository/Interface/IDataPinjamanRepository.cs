using TestDot1_DOT.Repositories.Entities;

namespace TestDot1_DOT.Repositories.Interface
{
    public interface IDataPinjamanRepository
    {
        void Create(TbliDataPinjaman entity);
        List<TbliDataPinjaman> GetAllDataPinjamanByKodeSiswa(string kodeSiswa);
        TbliDataPinjaman GetDataPinjamanByKodeSiswaBuku(string KodeSiswa, string KodeBuku);
        void Delete(TbliDataPinjaman entity);
    }
}
