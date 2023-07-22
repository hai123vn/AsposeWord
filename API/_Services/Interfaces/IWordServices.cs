using API.Dtos;

namespace API._Services.Interfaces
{
    public interface IWordServices
    {
        Task<List<FileOutput>> ChuyenDoiSangPDF(IFormFile file, string fileType);
        Task<FileOutput> TimKiemVaThayThe(IFormFile file, string noiDungCanTim, string noiDungThayThe);
        Task<List<FileOutput>> ChenVanBan(UploadFile file);
        Task ThemHinhAnh();
        Task TrichXuatHinhAnh();

        Task ChenVaThaoTacBieuDo();

        Task<FileOutput> BaoMat(UploadFile model);
        Task BaoMatVoiCHUKISO();
    }
}