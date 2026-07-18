using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaTro.Domain.Entities
{
    public class NguoiDung
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = default!;
        public string MatKhauHash { get; set; } = default!;
        public string SecurityStamp { get; set; } = Guid.NewGuid().ToString();
        public string HoTen { get; set; } = default!;
        public string? SoDienThoai { get; set; }
        public string? DuongDanAvatar { get; set; }
        public Guid IdVaiTro { get; set; }
        public VaiTro? VaiTro { get; set; }

        public bool LaHoatDong { get; set; } = true;
        public bool EmailDaXacNhan { get; set; } = false;
        public int SoLanDangNhapSai { get; set; } = 0;
        public DateTime? KhoaDen { get; set; }
        public DateTime? NgayDangNhapCuoi { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public DateTime? NgayXoa { get; set; }
    }
}
