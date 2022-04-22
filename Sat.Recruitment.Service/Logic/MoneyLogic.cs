using Sat.Recruitment.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Service.Logic
{
    internal class MoneyLogic
    {
        public static void SetMoney(UserDTO newUser)
        {
            decimal percentage = 0;
            if (newUser.UserType == "Normal")
            {
                if (newUser.Money > 100)
                    percentage = Convert.ToDecimal(0.12);
                if (newUser.Money < 100)
                {
                    if (newUser.Money > 10)
                        percentage = Convert.ToDecimal(0.8);
                }
            }
            if (newUser.UserType == "SuperUser")
            {
                if (newUser.Money > 100)
                    percentage = Convert.ToDecimal(0.20);
            }
            if (newUser.UserType == "Premium")
            {
                if (newUser.Money > 100)
                    percentage = 2;
            }

            if (percentage > 0)
                newUser.Money += newUser.Money * percentage;
        }
    }
}
