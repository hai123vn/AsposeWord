using API.Dtos;

namespace API._Services.Interfaces
{
    public interface IWordServices
    {
        Task<List<FileOutput>> ChuyenDoiSangPDF(IFormFile file, string fileType);
        Task TimKiemVaThayThe();
        Task ChenVanBan();
        Task<FileOutput> ThemHinhAnh(UploadFile model);
        Task<List<FileOutput>> TrichXuatHinhAnh(UploadFile model);

        Task<FileOutput> ChenVaThaoTacBieuDo(UploadFile model);

        Task<FileOutput> BaoMat(UploadFile model);
        Task<FileOutput> BaoMatVoiCHUKISO(UploadFile model);
    }
}