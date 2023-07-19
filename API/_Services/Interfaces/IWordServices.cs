using API.Dtos;

namespace API._Services.Interfaces
{
    public interface IWordServices
    {
        Task<List<FileOutput>> ChuyenDoiSangPDF(IFormFile file, string fileType);
        Task TimKiemVaThayThe();
        Task ChenVanBan();
        Task ThemHinhAnh();
        Task TrichXuatHinhAnh();

        Task ChenVaThaoTacBieuDo();

        Task BaoMat();
        Task BaoMatVoiCHUKISO();
    }
}