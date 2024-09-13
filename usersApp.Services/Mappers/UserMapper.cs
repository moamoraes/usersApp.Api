using AutoMapper;
using UsersApp.Application.ViewModels;
using UsersApp.Domain.Entities;

namespace UsersApp.Application.Mappers
{
    public class UserMapper: Profile
    {
        public UserMapper() {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
        }
    }
}
