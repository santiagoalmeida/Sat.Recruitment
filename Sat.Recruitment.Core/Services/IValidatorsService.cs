using Sat.Recruitment.Core.DTOs;

namespace Sat.Recruitment.Core.Services
{
    public interface IValidatorsService
    {
        string ValidateErrors(UserDTO usr);
        bool ValidateDuplicity(UserDTO usr);
    }
}