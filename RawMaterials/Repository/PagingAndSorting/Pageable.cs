﻿namespace RawMaterials.Repository.PagingAndSorting
{
    public class PageAble
    {
        const int _maxPageSize = 50;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 20;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > _maxPageSize) ? _maxPageSize : value;
            }
        }
    }
}
