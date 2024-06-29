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
            try
            {
                DataPinjamanViewModel dataPinjaman = new DataPinjamanViewModel();
                dataPinjaman = _service.Create(KodeSiswa, KodeBuku, WaktuPinjaman, WaktuPengembalian);
                if (dataPinjaman == null)
                {
                    return Conflict("Buku sudah pernah dipesan");
                }
                return Ok(dataPinjaman);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }

        }
        [HttpGet("GetBukuByKodeSiswa")]
        public IActionResult GetAllBukuByKodeSiswa(string kodeSiswa)
        {
            try
            {
                List<DataPinjamanViewModel> getBuku = new List<DataPinjamanViewModel>();
                getBuku = _service.GetBukuByKodeSiswa(kodeSiswa);
                if (getBuku == null || getBuku.Count==0)
                {
                    return NotFound("Data tidak ada");
                };
                return Ok(getBuku);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }
        }

        [HttpDelete("DeleteBuku")]
        public IActionResult Delete(string KodeSiswa, string KodeBuku)
        {
            try
            {
                DataPinjamanViewModel buku = new DataPinjamanViewModel();
                bool delete = _service.delete(KodeSiswa, KodeBuku);
                if (delete)
                {
                    return Ok(delete);
                }
                return NotFound("Data Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }
        }

    }
}
