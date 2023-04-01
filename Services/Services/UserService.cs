using AutoMapper;
using Core.Models;
using Core.Services.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Optional;
using Optional.Unsafe;
using Shared.Enums;
using Shared.ViewModels.PasswordChange;
using Shared.ViewModels.User;
using System.Text.RegularExpressions;
using Triplex.Validations;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IPasswordChangeRepository _passwordChangeRepo;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper, IPasswordChangeRepository passwordChangeRepo)
        {
            _userRepo = userRepository;
            _mapper = mapper;
            _passwordChangeRepo = passwordChangeRepo;
        }

        async Task IUserService.ChangePassword(PasswordChangeResponse passwordChange)
        {
            Arguments.NotNull(passwordChange, nameof(passwordChange));
            State.IsTrue(passwordChange.Password == passwordChange.PasswordConfirmation, "Las contraseñas no coinciden");

            PasswordChangeDbModel passwordChangeDbModel = await this.ValidateIfChangeRequestExists(passwordChange.Id);

            UserDbModel userToUpdate = (await _userRepo.GetById(passwordChangeDbModel.UserId)).ValueOrFailure("Este usuario no existe")!;

            userToUpdate.Password = User.EncryptPassword(passwordChange.Password);

            await _userRepo.Update(userToUpdate);
        }

        async Task IUserService.UpdatePassword(UpdatePassword updatePassword, Guid userId)
        {
            Arguments.NotNull(updatePassword, nameof(updatePassword));
            State.IsTrue(updatePassword.NewPassword == updatePassword.PasswordConfirmation, "Las contraseñas no coinciden");

            UserDbModel userToUpdate = (await _userRepo.ValidateUserPasswordById(userId, User.EncryptPassword(updatePassword.OldPassword))).ValueOrFailure("La contraseña anterior no coincide con la contraseña actual")!;

            userToUpdate.Password = User.EncryptPassword(updatePassword.NewPassword);

            await _userRepo.Update(userToUpdate);
        }

        async Task IUserService.Create(User user)
        {
            Arguments.NotNull(user, nameof(user));

            bool isValidEmail = Regex.IsMatch(user.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            State.IsTrue(isValidEmail, "El Email no es válido");

            bool userExist = await _userRepo.ValidateIfExsits(user.Identification, (IdentificationType)user.IdentificationType, user.Email, user.Id);
            State.IsFalse(userExist, "Ya existe un usuario con este Email o Identificación");

            UserDbModel userDbModel = _mapper.Map<UserDbModel>(user);

            await this._userRepo.Create(userDbModel);
        }

        async Task IUserService.Update(User user)
        {
            Arguments.NotNull(user, nameof(user));

            bool userExist = await _userRepo.ValidateIfExsits(user.Identification, (IdentificationType)user.IdentificationType, user.Email, user.Id);
            State.IsFalse(userExist, "Ya existe un usuario con este Email o Identificación");

            UserDbModel userDbModel = _mapper.Map<UserDbModel>(user);
            UserDbModel userToUpdate = (await _userRepo.GetById(user.Id)).ValueOrFailure("Este usuario no existe")!;

            userToUpdate.Map(userDbModel);

            await this._userRepo.Update(userToUpdate);
        }

        async Task<Guid> IUserService.CreateChangeRequest(string userEmail)
        {
            Arguments.NotNullOrEmpty(userEmail, nameof(userEmail));

            UserDbModel user = (await _userRepo.GetByEmail(userEmail)).ValueOrFailure("El correo electrónico ingresado no existe en el sistema")!;

            PasswordChangeDbModel passwordChange = new PasswordChangeDbModel()
            {
                Id = Guid.NewGuid(),
                UserId = user!.Id,
                ExpireDate = DateTime.Now.AddMinutes(30)
            };

            await _passwordChangeRepo.Create(passwordChange);

            return passwordChange.Id;
        }

        async Task<User> IUserService.Login(User user)
        {
            UserDbModel userDbModel = _mapper.Map<UserDbModel>(user);

            Option<UserDbModel?> userLogged = await _userRepo.Login(userDbModel);

            State.IsTrue(userLogged.HasValue, "Usuario/contraseña incorrectos");

            return _mapper.Map<User>(userLogged.ValueOrFailure());
        }

        async Task IUserService.ValidateChangeRequest(Guid changeRequestId)
        {
            Arguments.NotEmpty(changeRequestId, nameof(changeRequestId));
            await ValidateIfChangeRequestExists(changeRequestId);
        }

        private async Task<PasswordChangeDbModel> ValidateIfChangeRequestExists(Guid changeRequestId)
        {
            Option<PasswordChangeDbModel> changePassword = await _passwordChangeRepo.ValidateIfExsits(changeRequestId);

            State.IsTrue(changePassword.HasValue, "Esta solicitud de cambio de contraseña no existe o extá expirada");

            return changePassword.ValueOrFailure();
        }

        async Task<User> IUserService.GetById(Guid userId) 
        {
            Arguments.NotEmpty(userId, nameof(userId));

            UserDbModel userDbModel = (await _userRepo.GetById(userId)).ValueOrFailure("Este usuario no existe.")!;

            return _mapper.Map<User>(userDbModel);
        }

        public async Task<User> GetByEmail(string studentEmail)
        {
            Arguments.NotNullOrEmpty(studentEmail, nameof(studentEmail));

            UserDbModel userDbModel = (await _userRepo.GetByEmail(studentEmail)).ValueOrFailure("Este usuario no existe.")!;

            return _mapper.Map<User>(userDbModel);
        }
    }
}
