using Challenge.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Challenge.Infra.Data.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(e => e.Name)
                   .HasColumnType("varchar(150)")
                   .IsRequired();

            builder.HasOne(a => a.Product)
                   .WithOne(b => b.Category)
                   .HasForeignKey<Product>(b => b.CategoryId);

            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.CascadeMode);
            builder.ToTable("Categories");
        }
    }
}