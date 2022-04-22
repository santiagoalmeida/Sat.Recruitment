using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Sat.Recruitment.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Core.Services;
using Sat.Recruitment.Core;
namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class ReaderController : ControllerBase
    {

        private readonly IValidatorsService _validatorsSvc;
        private readonly IMoneyServices _moneySvc;

        public ReaderController(IValidatorsService validatorsSvc, IMoneyServices moneySvc)
        {
            this._validatorsSvc = validatorsSvc;
            this._moneySvc = moneySvc;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Results> CreateUser(UserDTO newUser)
        {
            var errors = _validatorsSvc.ValidateErrors(newUser);

            if (errors != null && errors != "")
                return new Results()
                {
                    IsSuccess = false,
                    Errors = errors
                };

            _moneySvc.SetMoneyByUserType(newUser);

            if (_validatorsSvc.ValidateDuplicity(newUser))
            {
                Debug.WriteLine("The user is duplicated");
                return new Results()
                {
                    IsSuccess = false,
                    Errors = "The user is duplicated"
                };
            }

            return new Results()
            {
                IsSuccess = true,
                Errors = "User Created"
            };
        }
    }
}
