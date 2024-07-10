using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces;

public interface IUserService
{
    int CreateUser(CreateUserInputModel model);
    UserViewModel GetUser(int id);
}