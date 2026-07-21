using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaTro.Domain.Entities
{
    public class NguoiDungRefreshToken
    {
        public Guid Id { get; set; }
        public Guid IdNguoiDung { get; set; }
        public NguoiDung? NguoiDung { get; set; }
        public string TokenHash { get; set; } = default!;
        public DateTime NgayHetHan { get; set; }
        public DateTime? NgayThuHoi { get; set; }
        public DateTime NgayTao { get; set; }
    }
}
