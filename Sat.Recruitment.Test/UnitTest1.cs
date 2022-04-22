using System;
using System.Dynamic;

using Microsoft.AspNetCore.Mvc;

using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Core.Services;
using Sat.Recruitment.Service.Services;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        IValidatorsService validatorsSvc = new ValidatorsService();
        IMoneyServices moneySvc = new MoneyServices();

        [Fact]
        public void Test1()
        {
            var userController = new ReaderController(validatorsSvc, moneySvc);
            var result = userController.CreateUser(
                new()
                {
                    Name = "Mike",
                    Email = "mike@gmail.com",
                    Address = "Av. Juan G",
                    Phone = "+349 1122354215",
                    UserType = "Normal",
                    Money = Convert.ToDecimal(124)
                }).Result;


            Assert.Equal(true, result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
        }

        [Fact]
        public void Test2()
        {
            var userController = new ReaderController(validatorsSvc, moneySvc);

            var result = userController.CreateUser(
                new()
                {
                    Name = "Agustina",
                    Email = "Agustina@gmail.com",
                    Address = "Av.Juan G",
                    Phone = "+349 1122354215",
                    UserType = "Normal",
                    Money = Convert.ToDecimal(124)
                }).Result;
            


            Assert.Equal(false, result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }
    }
}
