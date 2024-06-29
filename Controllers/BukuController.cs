using Microsoft.AspNetCore.Mvc;
using TestDot1_DOT.Models;
using TestDot1_DOT.Service.Interfaces;

namespace TestDot1_DOT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BukuController : ControllerBase
    {
        private readonly IBukuService _service;
        private readonly ILogger<BukuController> _logger;
        public BukuController(ILogger<BukuController> logger, IBukuService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost("CreateBuku")]
        public IActionResult CreateBuku(string NamaBuku, string KodeBuku, string Penerbit, string TahunPenerbit)
        {
            BukuViewModel buku = new BukuViewModel();
            buku = _service.Create(NamaBuku, KodeBuku, Penerbit, TahunPenerbit);
            return Ok(buku);
        }

        [HttpGet("GetAllBuku")]
        public IActionResult GetAllBuku()
        {
            try
            {
                List<BukuViewModel> getBuku = new List<BukuViewModel>();
                getBuku = _service.GetAllBuku();

                return Ok(getBuku);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }
        }

        [HttpPut("UpdateBuku")]
        public IActionResult UpdateByKodeBuku(string NamaBuku, string KodeBuku, string Penerbit, string TahunPenerbit)
        {
            try
            {
                BukuViewModel buku = new BukuViewModel();
                buku = _service.UpdateByKodeBuku(NamaBuku, KodeBuku, Penerbit, TahunPenerbit);
                if (buku.NamaBuku == null)
                {
                    return NotFound("Buku tidak ditemukan");
                }
                return Ok(buku);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }

        }

        [HttpDelete("DeleteBuku")]
        public IActionResult DeleteByKodeBuku(string KodeBuku)
        {
            try
            {
                BukuViewModel buku = new BukuViewModel();
                bool delete = _service.Delete(KodeBuku);
                if (delete)
                {
                    return Ok(delete);
                }
                else
                {
                    return BadRequest(400);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }


        }
    }
}
