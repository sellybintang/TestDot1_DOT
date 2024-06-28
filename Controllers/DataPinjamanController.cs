using Microsoft.AspNetCore.Mvc;
using TestDot1_DOT.Models;
using TestDot1_DOT.Service.Interfaces;

namespace TestDot1_DOT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataPinjamanController : ControllerBase
    {
        private readonly IDataPinjamanService _service;
        private readonly ILogger<DataPinjamanController> _logger;
        public DataPinjamanController(ILogger<DataPinjamanController> logger, IDataPinjamanService service)
        {
            _logger = logger;
            _service = service;
        }
        [HttpPost("CreateDataPinjaman")]
        public IActionResult CreateDataPinjaman(string KodeSiswa, string KodeBuku, DateTime WaktuPinjaman, DateTime WaktuPengembalian)
        {
            DataPinjamanViewModel dataPinjaman = new DataPinjamanViewModel();
            dataPinjaman = _service.Create(KodeSiswa, KodeBuku, WaktuPinjaman, WaktuPengembalian);
            return Ok(dataPinjaman);
        }
    }
}
