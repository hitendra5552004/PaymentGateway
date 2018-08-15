using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using PaymentGatewayDomain.Interfaces;

namespace PaymentGatewayDomain
{

    public class SaleMockStone : ISale
    {

        public bool Execute()
        {
            return true;
        }

    }

}
