using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ContactsModel
    {
        public class Contacts
        {
            public int ID { get; set; }
            public string Fname { get; set; }
            public string Lname { get; set; }
            public string Num { get; set; }
        }
    }
}
