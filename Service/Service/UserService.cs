using AutoMapper;
using TestDot1_DOT.Models;
using TestDot1_DOT.Repositories.Entities;
using TestDot1_DOT.Repositories.Interface;
using TestDot1_DOT.Service.Interfaces;

namespace TestDot1_DOT.Service.Service
{
    public class UserService : IUserService
    {
        IUserRepository _repository;
        IMapper _mapper;
        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public UserViewModel Create (string NamaLengkap, DateTime TanggalLahir, string NoTelp, string AlamatRumah, string KodeSiswa)
        {
            UserViewModel model = new UserViewModel();
            bool getUser = _repository.GetUser(KodeSiswa);
            if(!getUser)
            {
                model.Id = Guid.NewGuid();
                model.CreatedDate = DateTime.Now;
                model.NamaLengkap = NamaLengkap;
                model.TanggalLahir = TanggalLahir;
                model.NoTelp = NoTelp;
                model.AlamatRumah = AlamatRumah;
                model.KodeSiswa = KodeSiswa;
                _repository.Create(_mapper.Map<TblsUser>(model));
                return model;
            }
            return null;
        }
        public List<UserViewModel> GetUsers (string kodeSiswa)
        {
            List<UserViewModel> users = new List<UserViewModel>();
            bool getUser = _repository.GetUser(kodeSiswa);
            if(!getUser)
            {
                return null;
            }
            List<TblsUser>  entitys = _repository.GetAllUser();
            users = _mapper.Map<List<UserViewModel>>(entitys);
            return users;
        }
        
    }


}
