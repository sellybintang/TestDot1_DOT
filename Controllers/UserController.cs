using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TestDot1_DOT.Models;
using TestDot1_DOT.Service.Interfaces;

namespace TestDot1_DOT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUserService service)
        {
            _logger = logger;
            _service = service;
        }
        
        [HttpPost("CreateUser")]
        public IActionResult Createuser(string NamaLengkap, DateTime TanggalLahir, string NoTelp, string AlamatRumah, string KodeSiswa)
        {
            try
            {
                UserViewModel user = new UserViewModel();
                user = _service.Create(NamaLengkap, TanggalLahir, NoTelp, AlamatRumah, KodeSiswa);
                if(user == null)
                {
                    return Conflict("Kode sudah terpakai");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }

        }

        [HttpGet("GetAllUser")]
        public IActionResult GetAllUser(string kodeSiswa)
        {
            try
            {
                List<UserViewModel> users = new List<UserViewModel>();
                users = _service.GetUsers(kodeSiswa);
                if (users== null)
                {
                    return Conflict("Kode anda salah, silahkan masukkan kode dengan benar");
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }

        }

    }
}
