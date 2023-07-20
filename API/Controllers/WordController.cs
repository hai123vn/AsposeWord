using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API._Services.Interfaces;
using API.Dtos;
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
        public async Task<IActionResult> ConvertToPDF([FromForm] UploadFile model)
        {
            var pdfData = await _evi.ChuyenDoiSangPDF(model.File, model.FileType);
            return Ok(pdfData);
        }

        [HttpPost("DownloadFile")]
        public async Task<IActionResult> DownloadConvertToPDF([FromBody] FileOutput file)
        {
            string contentType = "application/octet-stream";

            var memory = new MemoryStream();
            var path = Path.Combine(_environment.WebRootPath, file.Url);

            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            // Set vị trí
            memory.Position = 0;

            return File(memory, contentType, file.FileName);

            // byte[] filePaths = System.IO.File.ReadAllBytes(filePath);
            // return File(filePaths, mimeType, file.FileName);
        }

        [HttpGet("TimKiemVaThayThe")]
        public async Task<IActionResult> TimKiemVaThayThe([FromForm] UploadFile model)
        {
            var result = _evi.TimKiemVaThayThe();
            return Ok();
        }

        [HttpGet("ThemHinhAnh")]
        public async Task<IActionResult> ThemHinhAnh([FromForm] UploadFile model)
        {
            var result = _evi.ThemHinhAnh();
            return Ok();
        }

        [HttpGet("TrichXuatHinhAnh")]
        public async Task<IActionResult> TrichXuatHinhAnh([FromForm] UploadFile model)
        {
            var result = _evi.TrichXuatHinhAnh();
            return Ok();
        }

        [HttpGet("ChenVaThaoTacBieuDo")]
        public async Task<IActionResult> ChenVaThaoTacBieuDo([FromForm] UploadFile model)
        {
            var result = _evi.ChenVaThaoTacBieuDo();
            return Ok();
        }

        [HttpPost("BaoMat")]
        public async Task<IActionResult> BaoMat([FromForm] UploadFile model)
        {
            var result = _evi.BaoMat(model);
            return Ok();
        }

        [HttpGet("BaoMatVoiCHUKISO")]
        public async Task<IActionResult> BaoMatVoiCHUKISO([FromForm] UploadFile model)
        {
            var result = _evi.BaoMatVoiCHUKISO();
            return Ok();
        }
    }
}