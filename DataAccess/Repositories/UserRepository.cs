using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Optional;
using Shared.Enums;
using Shared.ViewModels;
using Triplex.Validations;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlServerContext _context;

        public UserRepository(SqlServerContext context)
        {
            _context = context;
        }

        async Task IUserRepository.Create(UserDbModel userDbModel)
        {
            userDbModel.Id = Guid.NewGuid();

            await _context.Users.AddAsync(userDbModel);
            await _context.SaveChangesAsync();
        }

        async Task<bool> IUserRepository.ValidateIfExsits(string identification, IdentificationType identificationType, string email, Guid id)
        {
            Arguments.NotNullEmptyOrWhiteSpaceOnly(identification, nameof(identification));
            Arguments.NotNullEmptyOrWhiteSpaceOnly(email, nameof(email));

            bool exists = await _context.Users.AsNoTracking()
                                    .AnyAsync(user => ((user.Identification.ToLower() == identification.ToLower()
                                                            && user.IdentificationType == identificationType) || user.Email.ToLower() == email.ToLower()) && user.Id != id);

            return exists;
        }

        async Task<Option<UserDbModel?>> IUserRepository.Login(UserDbModel userParam)
        {
            Arguments.NotNull(userParam, nameof(userParam));

            Option<UserDbModel?> exists = (await _context.Users.AsNoTracking().Include(user => user.Role).FirstOrDefaultAsync(
                                               user => user.Password == userParam.Password &&
                                               user.Email.ToLower() == userParam.Email.ToLower()
                                               )).SomeNotNull();

            return exists;
        }

        async Task<Option<UserDbModel?>> IUserRepository.GetByEmail(string email)
        {
            Arguments.NotNullOrEmpty(email, nameof(email));

            Option<UserDbModel> user = (await _context.Users.AsNoTracking().FirstOrDefaultAsync(user =>
                                               user.Email.ToLower() == email.ToLower())).SomeNotNull()!;

            return user!;
        }

        async Task<Option<UserDbModel?>> IUserRepository.GetById(Guid id)
        {
            Arguments.NotEmpty(id, nameof(id));

            Option<UserDbModel?> user = (await _context.Users.AsNoTracking().FirstOrDefaultAsync(user =>
                                               user.Id == id)).SomeNotNull();

            return user;
        }

        async Task IUserRepository.Update(UserDbModel user)
        {
            Arguments.NotNull(user, nameof(user));

            _context.Users.Update(user);

            await _context.SaveChangesAsync();
        }

        async Task<Option<UserDbModel?>> IUserRepository.ValidateUserPasswordById(Guid userId, string oldPassword) 
        {
            Arguments.NotNullEmptyOrWhiteSpaceOnly(oldPassword, nameof(oldPassword));
            Arguments.NotEmpty(userId, nameof(userId));

            Option<UserDbModel?> user = (await _context.Users.FirstOrDefaultAsync(user => user.Password == oldPassword && user.Id == userId)).SomeNotNull();

            return user;
        }
    }
}
