﻿using System.ComponentModel;

namespace TT.Services
{
    public abstract class QueryStringParameters
    {
        
        const int maxPageSize = 50;

        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;

        [DefaultValue(10)]
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
