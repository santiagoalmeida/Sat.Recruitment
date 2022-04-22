using Sat.Recruitment.Core.DTOs;
using Sat.Recruitment.Core.Services;
using Sat.Recruitment.Service.Logic;

namespace Sat.Recruitment.Service.Services
{
    public class ValidatorsService : IValidatorsService
    {
        public string ValidateErrors(UserDTO usr) => ValidationLogic.ValidateErrors(usr);

        public bool ValidateDuplicity(UserDTO usr) => ValidationLogic.ValidateDuplicity(usr);
    }
}
