namespace API._Interface
{
    public interface IWordServices
    {
        Task<List<string>> ChuyenDoiSangPDF(IFormFile file);
        Task TimKiemVaThayThe();
        Task ChenVanBan();
        Task ThemHinhAnh();
        Task TrichXuatHinhAnh();

        Task ChenVaThaoTacBieuDo();

        Task BaoMat();
        Task BaoMatVoiCHUKISO();
    }
}