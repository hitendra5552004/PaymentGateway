using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Application.Interfaces;
using PaymentGateway.WebApi.Models.DTO;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.Interfaces.Services;

namespace PaymentGateway.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {

        private readonly ISaleServiceApp SaleServiceApp;
        private readonly IAcquirerSaleService AcquirerSaleService;

        public SaleController(ISaleServiceApp saleServiceApp, IAcquirerSaleService acquirerSaleService)
        {
            SaleServiceApp = saleServiceApp;
            AcquirerSaleService = acquirerSaleService;
        }

        // GET: api/Sale
        [HttpGet]
        public IEnumerable<AcquirerSale> Get()
        {
            var Sales = AcquirerSaleService.GetAll();
            return Sales;
        }

        // GET: api/Sale/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        //// POST: api/Sale
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // POST: api/Sale
        [HttpPost]
        public void Post([FromBody] DTOSale value)
        {
            Sale Sale = new Sale()
            {
                CreditCardNumber = value.CreditCardNumber,
                AmmountInCents = value.AmmountInCents,
                StoreId = value.StoreId
            };
            SaleServiceApp.CreateSale(Sale);
        }

        // PUT: api/Sale/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
