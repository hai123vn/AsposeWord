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
    }
}