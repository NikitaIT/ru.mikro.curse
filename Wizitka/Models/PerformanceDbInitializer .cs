using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Wizitka.Models
{
    public class PerformanceDbInitializer : DropCreateDatabaseAlways<PerformanceContext>
    {
        protected override void Seed(PerformanceContext db)
        {
            List<Tuple<DateTime, DateTime>> dateTimeTuples = new List<Tuple<DateTime, DateTime>>();
            DateTime localDateTime = DateTime.Now;
            dateTimeTuples.Add(new Tuple<DateTime, DateTime>(localDateTime, localDateTime));
            dateTimeTuples.Add(new Tuple<DateTime, DateTime>(localDateTime, localDateTime));
            dateTimeTuples.Add(new Tuple<DateTime, DateTime>(localDateTime, localDateTime));

            List <Actor> actors = new List<Actor>();

            actors.Add(new Actor {Id = 1, Info = "Это первый", Name = "Карл"});
            actors.Add(new Actor { Id = 2, Info = "Это второй", Name = "Клара" });
            actors.Add(new Actor { Id = 3, Info = "Это третий", Name = "Карал" });

            db.Actors.AddRange(actors);

            db.Performances.Add(new Performance { Id = 1, Name = "Война и мир", Price = 220, Actors = new List<Actor>(actors), Info = "Красивый спектакль на Невке", Type = "Балет", Holl = "1й малый зал", DateTimeTuples = new List<Tuple<DateTime, DateTime>>(dateTimeTuples) });
            db.Performances.Add(new Performance { Id = 2, Name = "Отцы и дети", Price = 180, Actors = new List<Actor>(actors), Info = "Красивый спектакль на Невке", Type = "Балет", Holl = "3й малый зал", DateTimeTuples = new List<Tuple<DateTime, DateTime>>(dateTimeTuples) });
            db.Performances.Add(new Performance { Id = 3, Name = "Чайка", Price = 150, Actors = new List<Actor>(actors), Info = "Красивый спектакль на Невке", Type = "Балет", Holl = "3й малый зал", DateTimeTuples =  new List<Tuple<DateTime, DateTime>>(dateTimeTuples) });

            base.Seed(db);
        }
    }
}