using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaTro.Domain.Entities;

namespace NhaTro.Infrastructure.Persistence.Configurations;

public class NguoiDungConfiguration : IEntityTypeConfiguration<NguoiDung>
{
    public void Configure(EntityTypeBuilder<NguoiDung> builder)
    {
        builder.ToTable("nguoi_dung");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Email).HasColumnName("email");
        builder.Property(x => x.MatKhauHash).HasColumnName("mat_khau_hash");
        builder.Property(x => x.SecurityStamp).HasColumnName("security_stamp");
        builder.Property(x => x.HoTen).HasColumnName("ho_ten");
        builder.Property(x => x.SoDienThoai).HasColumnName("so_dien_thoai");
        builder.Property(x => x.DuongDanAvatar).HasColumnName("duong_dan_avatar");
        builder.Property(x => x.IdVaiTro).HasColumnName("id_vai_tro");
        builder.Property(x => x.LaHoatDong).HasColumnName("la_hoat_dong");
        builder.Property(x => x.EmailDaXacNhan).HasColumnName("email_da_xac_nhan");
        builder.Property(x => x.SoLanDangNhapSai).HasColumnName("so_lan_dang_nhap_sai");
        builder.Property(x => x.KhoaDen).HasColumnName("khoa_den");
        builder.Property(x => x.NgayDangNhapCuoi).HasColumnName("ngay_dang_nhap_cuoi");
        builder.Property(x => x.NgayTao).HasColumnName("ngay_tao");
        builder.Property(x => x.NgayCapNhat).HasColumnName("ngay_cap_nhat");
        builder.Property(x => x.NgayXoa).HasColumnName("ngay_xoa");

        builder.HasOne(x => x.VaiTro)
               .WithMany()
               .HasForeignKey(x => x.IdVaiTro)
               .OnDelete(DeleteBehavior.Restrict);
    }
}