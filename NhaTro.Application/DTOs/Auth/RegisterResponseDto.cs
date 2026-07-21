using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaTro.Application.DTOs.Auth
{
    public class RegisterResponseDto
    {
        public Guid UserId { get; set; }
        public string Email { get; set; } = default!;
        public string HoTen { get; set; } = default!;
        public string Message { get; set; } = default!;
    }
}
