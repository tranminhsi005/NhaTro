using Microsoft.EntityFrameworkCore;
using NhaTro.Application.DTOs.Auth;
using NhaTro.Application.Interfaces.Services;
using NhaTro.Domain.Entities;
using NhaTro.Infrastructure.Persistence;

namespace NhaTro.Infrastructure.Services;

public class AuthService
{
    private readonly AppDbContext _context;
    private readonly IJwtTokenService _jwtService;

    public AuthService(AppDbContext context, IJwtTokenService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    public async Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto dto)
    {
        var existing = _context.NguoiDungs.FirstOrDefault(u => u.Email.ToLower() == dto.Email.ToLower());
        if (existing != null)
            throw new Exception("Email đã được đăng ký");

        if (dto.Password != dto.ConfirmPassword)
            throw new Exception("Mật khẩu xác nhận không khớp");

        var vaiTro = _context.VaiTros.FirstOrDefault(v => v.MaVaiTro == "chu_tro");
        if (vaiTro == null)
            throw new Exception("Vai trò chu_tro không tồn tại");

        var nguoiDung = new NguoiDung
        {
            Id = Guid.NewGuid(),
            Email = dto.Email,
            HoTen = dto.HoTen,
            MatKhauHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            IdVaiTro = vaiTro.Id,
            LaHoatDong = true,
            NgayTao = DateTime.UtcNow,
            NgayCapNhat = DateTime.UtcNow
        };

        _context.NguoiDungs.Add(nguoiDung);
        await _context.SaveChangesAsync();

        return new RegisterResponseDto
        {
            UserId = nguoiDung.Id,
            Email = nguoiDung.Email,
            HoTen = nguoiDung.HoTen,
            Message = "Đăng ký thành công"
        };
    }

    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto dto)
    {
        var nguoiDung = _context.NguoiDungs.Include(u => u.VaiTro)
            .FirstOrDefault(u => u.Email.ToLower() == dto.Email.ToLower());

        if (nguoiDung == null || !BCrypt.Net.BCrypt.Verify(dto.Password, nguoiDung.MatKhauHash))
            throw new Exception("Email hoặc mật khẩu không chính xác");

        if (!nguoiDung.LaHoatDong)
            throw new Exception("Tài khoản đã bị khóa");

        nguoiDung.NgayDangNhapCuoi = DateTime.UtcNow;
        _context.NguoiDungs.Update(nguoiDung);
        await _context.SaveChangesAsync();

        var accessToken = _jwtService.GenerateAccessToken(nguoiDung.Id, nguoiDung.Email, nguoiDung.HoTen);
        var refreshToken = _jwtService.GenerateRefreshToken();

        return new LoginResponseDto
        {
            UserId = nguoiDung.Id,
            Email = nguoiDung.Email,
            HoTen = nguoiDung.HoTen,
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }
}