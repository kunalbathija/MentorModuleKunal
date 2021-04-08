using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class PaymentManager: IPaymentManager
    {
        public bool checkPayment()
        {
            Random rand = new Random();

            if (rand.Next(0, 2) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        
    }
}
