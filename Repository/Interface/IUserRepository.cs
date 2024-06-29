using TestDot1_DOT.Models;
using TestDot1_DOT.Repositories.Entities;

namespace TestDot1_DOT.Repositories.Interface
{
    public interface IUserRepository
    {
        void Create(TblsUser user);
        bool GetUser(string kodeSiswa);
        List<TblsUser> GetAllUser();
    }
}
