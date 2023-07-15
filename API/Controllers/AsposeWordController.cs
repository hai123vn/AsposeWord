using API._Interface;
using Aspose.Words;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsposeWordController : ControllerBase
    {
        private readonly IWordServices _evi;

        public AsposeWordController(IWordServices evi)
        {
            _evi = evi;
        }

        [HttpGet("ConvertToPDF")]
        public async Task<IActionResult> ConvertToPDF()
        {
            var result = _evi.ChuyenDoiSangPDF();
            return Ok();
        }

        [HttpGet("TimKiemVaThayThe")]
        public async Task<IActionResult> TimKiemVaThayThe()
        {
            var result = _evi.TimKiemVaThayThe();
            return Ok();
        }

        [HttpGet("ThemHinhAnh")]
        public async Task<IActionResult> ThemHinhAnh()
        {
            var result = _evi.ThemHinhAnh();
            return Ok();
        }

        [HttpGet("TrichXuatHinhAnh")]
        public async Task<IActionResult> TrichXuatHinhAnh()
        {
            var result = _evi.TrichXuatHinhAnh();
            return Ok();
        }

        [HttpGet("ChenVaThaoTacBieuDo")]
        public async Task<IActionResult> ChenVaThaoTacBieuDo()
        {
            var result = _evi.ChenVaThaoTacBieuDo();
            return Ok();
        }

        [HttpGet("BaoMat")]
        public async Task<IActionResult> BaoMat()
        {
            var result = _evi.BaoMat();
            return Ok();
        }

        [HttpGet("BaoMatVoiCHUKISO")]
        public async Task<IActionResult> BaoMatVoiCHUKISO()
        {
            var result = _evi.BaoMatVoiCHUKISO();
            return Ok();
        }

    }
}