using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wizitka.Models
{
    public class Performance
    {
        // ID спектакля
        public int Id { get; set; }
        // название
        public string Name { get; set; }
        // актеры
        //public List<Actor> Actors { get; set; }
        // цена
        public int Price { get; set; }
        // время начала + длительность
        public List<Tuple<DateTime, DateTime>> DateTimeTuples { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
        public Performance()
        {
            Actors = new List<Actor>();
        }
    }
}