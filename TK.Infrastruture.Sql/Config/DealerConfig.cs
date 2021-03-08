using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TK.Core.Entites;

namespace TK.Infrastruture.Sql.Config
{
    public class DealerConfig : IEntityTypeConfiguration<Dealer>
    {
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            builder.Property(a => a.phoneNumber).HasAnnotation("RegularExpression",
            @"0 |\+98) ? ([ ] |,| -|[()]){ 0,2}
            9[1 | 2 | 3 | 4]([ ] |,| -|[()]){ 0,2}
            (?:[0 - 9]([ ] |,| -|[()]){ 0,2}){ 8}");
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Surname).IsRequired();
        }
    }
}
