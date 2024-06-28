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
        //public TblsUser GetUser(TblsUser user)
        //{

        //}
        //public TblsUser Update(TblsUser user)
        //{

        //}
        //public TblsUser Delete(TblsUser user)
        //{

        //}


    }
}
