using EmergencyManagementSystem.Common.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmergencyManagementSystem.Common.DAL.Mapping
{
    public class RequesterMapping : IEntityTypeConfiguration<Requester>
    {
        public void Configure(EntityTypeBuilder<Requester> builder)
        {
            builder.ToTable("Requesters", "dbo");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Guid)
                .HasColumnName("Guid")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(d => d.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(d => d.Telephone)
                .HasColumnName("Telephone")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            builder.HasOne(d => d.Address)
                .WithMany()
                .HasForeignKey(d => d.AddressId);
        }
    }
}
