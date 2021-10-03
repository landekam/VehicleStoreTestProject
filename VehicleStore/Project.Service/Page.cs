using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service
{
    public class Page : IPage
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalSize { get; set; }
    }
}
