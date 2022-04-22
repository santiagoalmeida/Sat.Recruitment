using Sat.Recruitment.Core.DTOs;
using Sat.Recruitment.Core.Services;
using Sat.Recruitment.Service.Logic;

namespace Sat.Recruitment.Service.Services
{
    public class MoneyServices: IMoneyServices
    {
        public void SetMoneyByUserType(UserDTO user) => MoneyLogic.SetMoney(user);
    }
}
