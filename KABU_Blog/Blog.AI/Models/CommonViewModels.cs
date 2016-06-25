using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Models;

namespace Blog.AI.Models
{
    public class ContactViewModel
    {
        public int TotalContact { get; set; }
        public int UnReadCount { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
