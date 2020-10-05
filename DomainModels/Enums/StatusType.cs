using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.Enums
{
    public enum StatusType
    {
        Init,
        Processing,
        Confirmed,
        Declined,
        Delivered,
        Canceled,
        Paid
    }
}
