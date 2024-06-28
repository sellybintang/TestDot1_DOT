using TestDot1_DOT.Models;
using TestDot1_DOT.Repositories.Entities;
using TestDot1_DOT.Repositories.Interface;

namespace TestDot1_DOT.Repositories.Repositories
{
    public class BukuRepository : IBukuRepository
    {
        private readonly Test_DOTContext _contex;

        public BukuRepository(Test_DOTContext context) =>
            _contex = context;
        public void Create(TblsBuku entity)
        {
            //entity = model;
            _contex.Set<TblsBuku>().Add(entity);
            _contex.SaveChanges();
        }

        public List<BukuViewModel> getAllBuku()
        {
            var results = _contex.TblsBukus.Select(b=> new BukuViewModel
            {
                Id = b.Id,
                NamaBuku = b.NamaBuku,
                KodeBuku = b.KodeBuku,
                Penerbit = b.Penerbit,
                TahunPenerbit = b.TahunPenerbit,
            }).ToList();
            return results;
        }
        
        public bool getBukuByKodeBuku(string kodeBuku)
        {
            bool result = _contex.TblsBukus.Where(x => x.DeletedDate == null && x.KodeBuku == kodeBuku).Any();
            return result;
        }
        public bool Delete(string kodeBuku)
        {
            bool delete = false;

            TblsBuku? query = _contex.TblsBukus.Where(x => x.KodeBuku == kodeBuku).FirstOrDefault();

            if (query != null)
            {
                delete = true;
                _contex.TblsBukus.Remove(query);
                _contex.SaveChanges();
            }
            return delete;
            
        }

    }
}
