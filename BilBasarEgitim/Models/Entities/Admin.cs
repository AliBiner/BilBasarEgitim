using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Entities
{
    public class Admin:BaseEntity
    {
        public Admin()
        {
            Documents = new List<Document>();
        }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        

        public List<Document> Documents { get; set; }
    }
}