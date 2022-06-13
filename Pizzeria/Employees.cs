using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    public class Employees
    {
        public int cooks { get; set; }
        public CourierJson[] couriers { get; set; }
    }

    public class CourierJson
    {
        public int id { get; set; }
        public int bagpack_size { get; set; }
    }

}
