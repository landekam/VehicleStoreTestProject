using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service
{
    public class Sort : ISort
    {
        public string Column { get; set; }
        public bool Ascending { get; set; }
    }
}
