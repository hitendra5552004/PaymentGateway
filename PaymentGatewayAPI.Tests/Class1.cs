using System;
using Xunit;
using Moq;
//using System.Web.Http;
using System.Net.Http;
using PaymentGatewayAPI.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace PaymentGatewayAPI.Tests
{
    public class Class1
    {
        [Fact]
        public void Get()
        {
            var Controller = new ValuesController();
            var Response = Controller.Get();
            IEnumerable<string> Values = Assert.IsAssignableFrom<IEnumerable<string>>(Response.Value);
            Assert.Equal(2,( (string[])Values).Length);
        }
    }
}
