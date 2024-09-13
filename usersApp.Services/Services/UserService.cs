using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using UsersApp.Application.ViewModels;
using UsersApp.Domain.Entities;
using UsersApp.Infra.Repositories;

namespace UsersApp.Application.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddUserAsync(UserViewModel userViewModel)
        {
            var user = _mapper.Map<User>(userViewModel);

            if (user.CPF.IsNullOrEmpty() || user.FullName.IsNullOrEmpty() 
                    || user.Income <= 0 || user.BirthDate <= DateTime.MinValue
                    || user.CPF.Length != 11 || !user.CPF.All(char.IsDigit))
                return false;

            var existentUser = await _userRepository.GetUserByCpfAsync(user.CPF);

            if (existentUser is { })
                return false;

            var result = await _userRepository.InsertUserAsync(user);
            return result > 0;
        }

        public async Task<bool> UpdateUserAsync(string cpf, UserViewModel userViewModel)
        {
            var user = _mapper.Map<User>(userViewModel);

            if (user.CPF.IsNullOrEmpty() || user.FullName.IsNullOrEmpty()
                    || user.Income <= 0 || user.BirthDate <= DateTime.MinValue)
                return false;

            var result = await _userRepository.UpdateUserAsync(cpf, user);
            return result > 0;
        }

        public async Task<bool> DeleteUserAsync(string cpf)
        {
            var result = await _userRepository.DeleteUserAsync(cpf);
            return result > 0;
        }

        public async Task<UserViewModel> GetUserByCpfAsync(string cpf)
        {
            var user = await _userRepository.GetUserByCpfAsync(cpf);

            return user == null ? null : _mapper.Map<UserViewModel>(user);
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();

            return _mapper.Map<IEnumerable<UserViewModel>>(users);
        }
    }
}
