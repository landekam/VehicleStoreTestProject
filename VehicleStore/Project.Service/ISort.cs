using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service
{
    public interface ISort
    {
        string Column { get; set; }
        bool Ascending { get; set; }
    }
}
