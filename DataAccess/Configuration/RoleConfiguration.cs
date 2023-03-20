using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Enums;
using Shared.ViewModels.Dropdowns;

namespace DataAccess.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<RoleDbModel>
    {
        void IEntityTypeConfiguration<RoleDbModel>.Configure(EntityTypeBuilder<RoleDbModel> builder)
        {
            builder.HasData(this.BuildRoleList());
        }

        private IEnumerable<RoleDbModel> BuildRoleList()
        {
            return new List<RoleDbModel>()
            {
                new RoleDbModel()
                {
                    Id = Guid.Parse("3a1760d7-20a2-4a05-8939-497984e38cf4"),
                    Name = "Administrador",
                    RoleType = RoleType.Administrator
                },
                 new RoleDbModel()
                {
                    Id = Guid.Parse("b6c977e9-09da-4454-94b1-58c22a7da7ab"),
                    Name = "Student",
                    RoleType = RoleType.Student
                }

            };
        }

    }
}
