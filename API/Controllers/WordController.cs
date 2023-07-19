using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API._Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WordController : ControllerBase
    {
         private readonly IWordServices _evi;
        private readonly IWebHostEnvironment _environment;
        private readonly string fileFolder;
        public WordController(IWordServices evi, IWebHostEnvironment environment)
        {
            _evi = evi;
            _environment = environment;
            fileFolder = Path.Combine(_environment.ContentRootPath, @"wwwroot/output/");
        }

        [HttpPost("ConvertToPDF")]
        public async Task<IActionResult> ConvertToPDF(IFormFile file)
        {
            var pdfData = await _evi.ChuyenDoiSangPDF(file);
            return Ok(pdfData);
        }

        [HttpPost("DownloadFile")]
        public async Task<IActionResult> DownloadConvertToPDF(string fileName)
        {
            string filePath = Path.Combine(fileFolder, fileName);
            string mimeType = "application/octet.stream";
            byte[] filePaths = System.IO.File.ReadAllBytes(filePath);
            return File(filePaths, mimeType, fileName);
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