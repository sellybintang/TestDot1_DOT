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
            UserViewModel user = new UserViewModel();
            user = _service.Create(NamaLengkap, TanggalLahir, NoTelp, AlamatRumah, KodeSiswa);
            return Ok(user);
        }
        //[HttpDelete("DeleteUser")]
        //public IActionResult DeleteUser()
        //{
            
        //}
        //[HttpGet("GetAllUser")]
        //public IActionResult GetAllUser()
        //{
           
        //}
        //[HttpPut("UpdateUser")]
        //public IActionResult UpdateUser()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
