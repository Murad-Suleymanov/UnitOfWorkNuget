using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Domain
{
    public class NewCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CategoryConfig : IEntityTypeConfiguration<NewCategory>
    {
        public void Configure(EntityTypeBuilder<NewCategory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Name).HasColumnName("Name");

            builder.ToTable("Category");
        }
    }
}
