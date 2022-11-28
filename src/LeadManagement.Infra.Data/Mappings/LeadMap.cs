using LeadManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeadManagement.Infra.Data.Mappings
{
    public class LeadMap : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            // Primary Key.
            builder.HasKey(l => l.Id);

            // Properties.
            builder.Property(l => l.CreationDate)
                .IsRequired();

            builder.Property(l => l.UpdateDate);

            builder.Property(l => l.ContactFirstName)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(l => l.ContactFullName)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(l => l.ContactPhoneNumber)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(l => l.ContactEmail)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(l => l.Suburb)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(l => l.Category)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(l => l.JobId)
                .IsRequired();

            builder.Property(l => l.Description)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(l => l.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(l => l.Status)
                .IsRequired();

            // Table & Column Mappings.
            builder.ToTable("Leads");
        }
    }
}