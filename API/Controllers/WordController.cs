using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        [HttpPost("TimKiemVaThayThe")]
        public async Task<IActionResult> TimKiemVaThayThe(IFormFile file, string noiDungCanTim, string noiDungThayThe)
        {

            var result = await _evi.TimKiemVaThayThe(file, noiDungCanTim, noiDungThayThe);
            return Ok(result);
        }

        [HttpGet("ThemHinhAnh")]
        public async Task<IActionResult> ThemHinhAnh([FromForm] UploadFile model)
        {
            var result = _evi.ThemHinhAnh();
            return Ok(result);
        }

        [HttpGet("TrichXuatHinhAnh")]
        public async Task<IActionResult> TrichXuatHinhAnh([FromForm] UploadFile model)
        {
            var result = _evi.TrichXuatHinhAnh();
            return Ok(result);
        }

        [HttpGet("ChenVaThaoTacBieuDo")]
        public async Task<IActionResult> ChenVaThaoTacBieuDo([FromForm] UploadFile model)
        {
            var result = _evi.ChenVaThaoTacBieuDo();
            return Ok(result);
        }

        [HttpPost("BaoMat")]
        public async Task<IActionResult> BaoMat([FromForm] UploadFile model)
        {
            var result = await _evi.BaoMat(model);
            return Ok(result);
        }

        [HttpGet("BaoMatVoiCHUKISO")]
        public async Task<IActionResult> BaoMatVoiCHUKISO([FromForm] UploadFile model)
        {
            var result = _evi.BaoMatVoiCHUKISO();
            return Ok(result);
        }
    }
}