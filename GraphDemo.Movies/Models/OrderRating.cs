using System;
using System.Collections.Generic;
using System.Text;

namespace GraphDemo.Orders.Models
{
    [Flags]
    public enum OrderRating
    {
        Unrated = 0,
        G = 1,
        PG = 2,
        PG13 = 3,
        R = 4,
        NC17 = 5
    }
}
