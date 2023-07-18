using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API._Services.Interfaces
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