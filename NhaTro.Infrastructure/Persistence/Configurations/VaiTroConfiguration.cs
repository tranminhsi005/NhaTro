using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaTro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaTro.Infrastructure.Persistence.Configurations
{
    public class VaiTroConfiguration : IEntityTypeConfiguration<VaiTro>
    {
        public void Configure(EntityTypeBuilder<VaiTro> builder)
        {
            builder.ToTable("vai_tro");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.MaVaiTro).HasColumnName("ma_vai_tro").IsRequired();
            builder.HasIndex(x => x.MaVaiTro).IsUnique();
            builder.Property(x => x.TenVaiTro).HasColumnName("ten_vai_tro").IsRequired();
            builder.Property(x => x.NgayTao).HasColumnName("ngay_tao");
        }
    }
}
