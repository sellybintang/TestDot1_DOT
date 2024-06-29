using AutoMapper;
using TestDot1_DOT.Models;
using TestDot1_DOT.Repositories.Entities;
using TestDot1_DOT.Repositories.Interface;
using TestDot1_DOT.Service.Interfaces;

namespace TestDot1_DOT.Service.Service
{
    public class DataPinjamanService : IDataPinjamanService
    {
        IDataPinjamanRepository _repository;
        IMapper _mapper;
        public DataPinjamanService(IDataPinjamanRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public DataPinjamanViewModel Create(string KodeSiswa,string KodeBuku, DateTime WaktuPinjaman, DateTime WaktuPengembalian)
        {
            DataPinjamanViewModel model = new DataPinjamanViewModel();
            var getBuku = _repository.GetDataPinjamanByKodeSiswaBuku(KodeSiswa, KodeBuku);
            if(getBuku!= null)
            {
                model.Id = Guid.NewGuid();
                model.CreatedDate = DateTime.Now;
                model.KodeSiswa = KodeSiswa;
                model.KodeBuku = KodeBuku;
                model.WaktuPinjaman = WaktuPinjaman;
                model.WaktuPengembalian = WaktuPengembalian;
                _repository.Create(_mapper.Map<TbliDataPinjaman>(model));
            }
            return model;
        }
        public List<DataPinjamanViewModel> GetBukuByKodeSiswa(string kodeSiswa)
        {
            var buku = _repository.GetAllDataPinjamanByKodeSiswa(kodeSiswa);
            var result = _mapper.Map<List<DataPinjamanViewModel>>(buku);
            return result;
        }

        public bool delete(string KodeSiswa, string KodeBuku)
        {
            bool result = false;
            var buku = _repository.GetDataPinjamanByKodeSiswaBuku(KodeSiswa, KodeBuku);
            if(buku != null)
            {
                result = true;
                _repository.Delete(_mapper.Map<TbliDataPinjaman>(buku));
                return result;
            }
            return result;
        }
    }
}
