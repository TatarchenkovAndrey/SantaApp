using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SantaApi.Models;

namespace SantaApi.Helpers.Configurations
{
    public class EmployeeCardConfiguration : IEntityTypeConfiguration<EmployeeCard>
    {
        public void Configure(EntityTypeBuilder<EmployeeCard> builder)
        {
            builder.Property(s => s.Verdict).HasConversion(new EnumToNumberConverter<Verdict, int>());
        }
    }
}