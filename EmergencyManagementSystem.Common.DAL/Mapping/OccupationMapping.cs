using EmergencyManagementSystem.Common.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmergencyManagementSystem.Common.DAL.Mapping
{
    public class OccupationMapping : IEntityTypeConfiguration<Occupation>
    {
        public void Configure(EntityTypeBuilder<Occupation> builder)
        {
            builder.ToTable("Occupations", "dbo");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Profession)
                .HasColumnName("Profession")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
