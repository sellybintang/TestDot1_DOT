using TestDot1_DOT.Models;

namespace TestDot1_DOT.Service.Interfaces
{
    public interface IUserService
    {
        UserViewModel Create(string NamaLengkap, DateTime TanggalLahir, string NoTelp, string AlamatRumah, string KodeSiswa);
    }
}
