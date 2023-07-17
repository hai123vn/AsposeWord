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

        [HttpPost("ConvertToPDF")]
        public async Task<IActionResult> ConvertToPDF(IFormFile type)
        {
            var pdfData = await _evi.ChuyenDoiSangPDF(type);

            // Nếu không có dữ liệu PDF hoặc có lỗi, bạn có thể trả về một thông báo lỗi hoặc mã lỗi thích hợp.
            return Ok(); // Ví dụ: Trả về mã lỗi 404 Not Found
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