using Microsoft.EntityFrameworkCore;
using TestDot1_DOT.Models;
using TestDot1_DOT.Repositories.Entities;
using TestDot1_DOT.Repositories.Interface;

namespace TestDot1_DOT.Repositories.Repositories
{
    public class DataPinjamanRepository: IDataPinjamanRepository
    {
        private readonly Test_DOTContext _contex;

        public DataPinjamanRepository(Test_DOTContext context) =>
            _contex = context;
        public void Create(TbliDataPinjaman entity)
        {
            _contex.Set<TbliDataPinjaman>().Add(entity);
            _contex.SaveChanges();
        }

        //Action Eager Loading
        public List<TbliDataPinjaman> GetAllDataPinjamanByKodeSiswa(string kodeSiswa)
        {
            var result = _contex.TbliDataPinjamen
                .Include(a => a.PinjamanBuku)
                .Include(b => b.User)
                .Where(a => a.KodeSiswa == kodeSiswa).ToList();

            if(result == null)
            {
                var bukuSiswa = _contex.TbliDataPinjamen.Where(x=>x.KodeSiswa == kodeSiswa).ToList();
                return bukuSiswa;
            }
            return result;
        }

        public TbliDataPinjaman GetDataPinjamanByKodeSiswaBuku(string KodeSiswa, string KodeBuku)
        {
            var getBuku = _contex.TbliDataPinjamen.Where(x => x.KodeBuku ==KodeBuku && x.KodeSiswa == KodeSiswa).FirstOrDefault();
            return getBuku;
        }
        public void Delete(TbliDataPinjaman entity)
        {
            _contex.Set<TbliDataPinjaman>().Remove(entity);
            _contex.SaveChanges();
        }



    }
}
