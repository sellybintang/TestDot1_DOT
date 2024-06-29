using AutoMapper;
using TestDot1_DOT.Models;
using TestDot1_DOT.Repositories.Entities;
using TestDot1_DOT.Repositories.Interface;
using TestDot1_DOT.Service.Interfaces;

namespace TestDot1_DOT.Service.Service
{
    public class BukuService: IBukuService
    {
        IBukuRepository _repository;
        IMapper _mapper;
        public BukuService(IBukuRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public BukuViewModel Create(string NamaBuku, string KodeBuku, string Penerbit, string TahunPenerbit)
        {
            bool checkKodeBuku = _repository.getBukuByKodeBuku(KodeBuku);
            if(!checkKodeBuku)
            {
                BukuViewModel model = new BukuViewModel();
                model.Id = Guid.NewGuid();
                model.CreatedDate = DateTime.Now;
                model.NamaBuku = NamaBuku;
                model.KodeBuku = KodeBuku;
                model.Penerbit = Penerbit;
                model.TahunPenerbit = TahunPenerbit;
                _repository.Create(_mapper.Map<TblsBuku>(model));
                return model;
            }
            
            return null;
        }

        public List<BukuViewModel> GetAllBuku()
        {
            List<BukuViewModel> buku = new List<BukuViewModel>();
            buku = _repository.getAllBuku();
            return buku;
        }
        public BukuViewModel UpdateByKodeBuku(string NamaBuku, string KodeBuku, string Penerbit, string TahunPenerbit)
        {

            BukuViewModel model = new BukuViewModel();
            bool IsExist = _repository.getBukuByKodeBuku(KodeBuku);
            if (IsExist)
            {
                model.UpdatedDate = DateTime.Now;
                model.Penerbit = Penerbit;
                model.NamaBuku= NamaBuku;
                model.TahunPenerbit= TahunPenerbit;
            }
            return model;
        }
        public bool Delete(string KodeBuku)
        {
            bool delete =_repository.Delete(KodeBuku);
            return delete;

        }
    }
}
