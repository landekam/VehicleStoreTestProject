using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service
{
    public interface IPage
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
        int TotalSize { get; set; }
    }
}
