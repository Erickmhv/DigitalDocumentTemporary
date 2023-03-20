using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Optional;
using Shared.Enums;
using Triplex.Validations;

namespace DataAccess.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly SqlServerContext _context;

        public RoleRepository(SqlServerContext context)
        {
            _context = context;
        }

        async Task IRoleRepository.Create(RoleDbModel roleDbModel)
        {
            roleDbModel.Id = Guid.NewGuid();

            await _context.Roles.AddAsync(roleDbModel);
            await _context.SaveChangesAsync();
        }

        async Task<Option<RoleDbModel?>> IRoleRepository.GetById(Guid id)
        {
            Arguments.NotEmpty(id, nameof(id));

            Option<RoleDbModel?> role = (await _context.Roles.AsNoTracking().FirstOrDefaultAsync(role =>
                                               role.Id == id)).SomeNotNull();

            return role;
        }

        async Task IRoleRepository.Update(RoleDbModel role)
        {
            Arguments.NotNull(role, nameof(role));

            _context.Roles.Update(role);

            await _context.SaveChangesAsync();
        }

    }
}
