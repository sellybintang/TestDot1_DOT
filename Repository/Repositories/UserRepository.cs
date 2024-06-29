using TestDot1_DOT.Models;
using TestDot1_DOT.Repositories.Entities;
using TestDot1_DOT.Repositories.Interface;

namespace TestDot1_DOT.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Test_DOTContext _contex;

        public UserRepository(Test_DOTContext context) =>
            _contex = context;
        public void  Create(TblsUser entity)
        {
            
            //entity = model;
            _contex.Set<TblsUser>().Add(entity);
            _contex.SaveChanges();
        }

        public bool GetUser(string kodeSiswa)
        {
            var result = true;
            var query = _contex.TblsUsers.Where(x=>x.KodeSiswa == kodeSiswa && x.DeletedDate == null).FirstOrDefault();
            if (query == null)
            {
                result = false;
                return result;
            }
            return result;
        }
        public List<TblsUser> GetAllUser()
        {
            var query = _contex.TblsUsers.Where(x => x.DeletedDate == null).ToList();
            
            return query;
        }



    }
}
