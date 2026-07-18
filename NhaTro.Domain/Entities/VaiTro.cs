using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaTro.Domain.Entities
{
    public class VaiTro
    {
        public Guid Id { get; set; }
        public string MaVaiTro { get; set; } = default!;
        public string TenVaiTro { get; set; } = default!;
        public DateTime NgayTao { get; set; }

        public ICollection<NguoiDung> NguoiDungs { get; set; } = new List<NguoiDung>();
    }
}
