using API.Dtos;

namespace API._Services.Interfaces
{
    public interface IWordServices
    {
        Task<List<FileOutput>> ChuyenDoiSangPDF(IFormFile file, string fileType);
        Task TimKiemVaThayThe();
        Task ChenVanBan();
        Task<FileOutput> ThemHinhAnh(UploadFile model);
        Task TrichXuatHinhAnh();

        Task ChenVaThaoTacBieuDo();

        Task<FileOutput> BaoMat(UploadFile model);
        Task<FileOutput> BaoMatVoiCHUKISO(UploadFile model);
    }
}