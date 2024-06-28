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
            model.Id = Guid.NewGuid();
            model.CreatedDate = DateTime.Now;
            model.KodeSiswa = KodeSiswa;
            model.KodeBuku = KodeBuku;
            model.WaktuPinjaman = WaktuPinjaman;
            model.WaktuPengembalian = WaktuPengembalian;
            _repository.Create(_mapper.Map<TbliDataPinjaman>(model));
            return model;
        }
    }
}
