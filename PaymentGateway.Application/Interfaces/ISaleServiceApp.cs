using PaymentGateway.Domain.Entities;

namespace PaymentGateway.Application.Interfaces
{
    public interface ISaleServiceApp
    {
        void CreateSale(Sale sale);
    }
}