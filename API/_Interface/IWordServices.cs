namespace API._Interface
{
    public interface IWordServices
    {
        Task ChuyenDoiSangPDF();
        Task TimKiemVaThayThe();
        Task ChenVanBan();
        Task ThemHinhAnh();
        Task TrichXuatHinhAnh();

        Task ChenVaThaoTacBieuDo();

        Task BaoMat();
        Task BaoMatVoiCHUKISO();
    }
}