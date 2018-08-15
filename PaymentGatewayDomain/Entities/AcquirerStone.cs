using System;
using System.Collections.Generic;
using System.Text;
using PaymentGatewayDomain.Interfaces;

namespace PaymentGatewayDomain.Entities
{
    public class AcquirerStone : IAcquirer
    {

        public bool Authorize()
        {
            throw new NotImplementedException();
        }

        public void BuildRequest()
        {
            throw new NotImplementedException();
        }

        public bool MadeTransaction()
        {
            throw new NotImplementedException();
        }

    }
}
