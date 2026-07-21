using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaTro.Application.DTOs.Auth
{
    public class RegisterRequestDto
    {
        public string Email { get; set; } = default!;
        public string HoTen { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string ConfirmPassword { get; set; } = default!;
    }
}
