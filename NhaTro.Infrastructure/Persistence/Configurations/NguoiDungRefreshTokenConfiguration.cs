using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaTro.Domain.Entities;

namespace NhaTro.Infrastructure.Persistence.Configurations;

public class NguoiDungRefreshTokenConfiguration : IEntityTypeConfiguration<NguoiDungRefreshToken>
{
    public void Configure(EntityTypeBuilder<NguoiDungRefreshToken> builder)
    {
        builder.ToTable("nguoi_dung_refresh_token");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.IdNguoiDung).HasColumnName("id_nguoi_dung");
        builder.Property(x => x.TokenHash).HasColumnName("token_hash");
        builder.Property(x => x.NgayHetHan).HasColumnName("ngay_het_han");
        builder.Property(x => x.NgayThuHoi).HasColumnName("ngay_thu_hoi");
        builder.Property(x => x.NgayTao).HasColumnName("ngay_tao");

        builder.HasOne(x => x.NguoiDung)
               .WithMany()
               .HasForeignKey(x => x.IdNguoiDung)
               .OnDelete(DeleteBehavior.Cascade);
    }
}