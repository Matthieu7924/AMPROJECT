using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AMPROJECT.Models.Configuration
{
    public class AdminConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        private const string adminId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var admin = new ApplicationUser
            {
                Id = adminId,
                UserName = "master",
                NormalizedUserName = "MASTERADMIN",
                Email = "admin@am.com",
                NormalizedEmail = "ADMIN@AM.COM",
                EmailConfirmed = true,
                SecurityStamp = new System.Guid().ToString("D")
            };

            admin.PasswordHash = PassGenerate(admin);
            builder.HasData(admin);
        }

        public string PassGenerate(ApplicationUser user)
        {
            var passHash = new PasswordHasher<ApplicationUser>();
            return passHash.HashPassword(user, "Admin1234");
        }
    }
}