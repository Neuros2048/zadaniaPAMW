﻿using System.Text.RegularExpressions;

namespace WebLiblary.Models
{
    public class Pager
    {
        public int TotalItems {  get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }

        public Pager() { 
        }

        public Pager(int totalItems,int page, int pagesize =6)
        {
            TotalItems = totalItems;
            TotalPages = totalItems/pagesize + ( totalItems%pagesize >0 ? 1 : 0);
            CurrentPage = page;

            PageSize = pagesize;
            StartPage = page - 2;
            EndPage = page + 2;

            if(StartPage < 1)
            {
                EndPage =  Math.Min(5,TotalPages);
                StartPage = 1;
            }

            if(EndPage > TotalPages)
            {
                EndPage = TotalPages;
                StartPage = Math.Max(1, EndPage - 4);
                
            }
        }
    }
}
