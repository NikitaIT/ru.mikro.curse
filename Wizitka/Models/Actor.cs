using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wizitka.Models
{
    public class Actor
    {
        // ID
        public int Id { get; set; }
        // имя и фамилия
        public string Name { get; set; }
        // о актёре
        public string Info { get; set; }
        public virtual ICollection<Performance> Performances { get; set; }
        public Actor()
        {
            Performances = new List<Performance>();
        }
    }
}