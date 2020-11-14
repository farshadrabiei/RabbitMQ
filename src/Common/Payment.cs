using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Common
{
    [Serializable]
    public class Payment
    {
        public decimal AmountToPay;
        public string CardNumber;
        public string Name;
    }
}
