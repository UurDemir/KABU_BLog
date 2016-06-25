using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Resources;

namespace Blog.AI.Models
{
    public class TableViewModel<T>
    {
        public TableViewModel()
        {
            Perpage = 10;
            CurrentPage = 1;
            Search = "";
        }

        public int Perpage { get; set; }
        public int CurrentPage { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "Search")]
        public string Search { get; set; }
        public int TotalCount { get; set; }
        public List<T> Hits { get; set; }

        public int PageCount => TotalCount < Perpage ? 1 : TotalCount / Perpage + (TotalCount % Perpage > 0 ? 1 : 0);
    }
}
