using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaTro.Application.Interfaces.Services
{
    public interface IJwtTokenService
    {
        string GenerateAccessToken(Guid userId, string email, string hoTen);
        string GenerateRefreshToken();
    }
}
