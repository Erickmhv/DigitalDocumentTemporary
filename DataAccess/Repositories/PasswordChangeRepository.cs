using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Optional;
using Triplex.Validations;

namespace DataAccess.Repositories
{
    public class PasswordChangeRepository : IPasswordChangeRepository
    {
        private readonly SqlServerContext _context;

        public PasswordChangeRepository(SqlServerContext context)
        {
            _context = context;
        }

        async Task IPasswordChangeRepository.Create(PasswordChangeDbModel passwordChangeDbModel)
        {
            Arguments.NotNull(passwordChangeDbModel, nameof(passwordChangeDbModel));

            await _context.PasswordChanges.AddAsync(passwordChangeDbModel);

            await _context.SaveChangesAsync();
        }

        async Task<Option<PasswordChangeDbModel>> IPasswordChangeRepository.ValidateIfExsits(Guid id)
        {
            Arguments.NotEmpty(id, nameof(id));

            Option<PasswordChangeDbModel> passwordChangeOption = (await _context.PasswordChanges.AsNoTracking()
                                                        .Include(pwd => pwd.User)
                                                        .FirstOrDefaultAsync(pwd => pwd.Id == id && DateTime.Now < pwd.ExpireDate)).SomeNotNull()!;

            return passwordChangeOption;
        }
    }
}
