using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGatewayDomain.Interfaces
{
    public interface IAcquirer
    {

        void BuildRequest();

        bool Authorize();

        bool MadeTransaction();

    }
}
