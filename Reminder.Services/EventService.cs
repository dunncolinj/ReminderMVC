using Reminder.Data;
using Reminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Services
{
    public class EventService
    {
        private readonly Guid _userId;

        public EventService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEvent(EventCreate model)
        {
                var entity = new Event()
                {
                    RelationshipId = model.RelationshipId,
                    Date = model.Date,
                    Description = model.Description,
                    NotifyBefore = model.NotifyBefore
                };
 
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Events.Add(entity);
                return (ctx.SaveChanges() == 1);
            }
        }

        public IEnumerable<EventList> GetEvents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                // var query = query for all events that have a relationship ID that has the currently logged-on user as the owner
                var query = ctx.Events.Where(e => e.Relationship.User == _userId)
                    .Select(
                    e => new EventList
                    {
                        Id=e.Id,
                        Name = e.Relationship.ApplicationUser.FirstName + " " + e.Relationship.ApplicationUser.MiddleName + " " + e.Relationship.ApplicationUser.LastName,
                        RelationshipId = e.RelationshipId,
                        Date = e.Date,
                        Description = e.Description,
                        NotifyBefore = e.NotifyBefore
                    } );
                return query.ToArray();
            }
        }

        public EventDetails GetEventById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Events.Single(e => e.Id == id && e.Relationship.User == _userId);

                return new EventDetails
                {
                    Id = entity.Id,
                    RelationshipId = entity.RelationshipId,
                    Name = entity.Relationship.ApplicationUser.FirstName + " " + entity.Relationship.ApplicationUser.MiddleName + " " + entity.Relationship.ApplicationUser.LastName,
                    Date = entity.Date,
                    Description = entity.Description,
                    NotifyBefore = entity.NotifyBefore
                };
            }
        }

        public bool UpdateEvent(EventUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Events.Single(e => e.Id == model.Id && e.Relationship.User == _userId);

                entity.Date = model.Date;
                entity.Description = model.Description;
                entity.NotifyBefore = model.NotifyBefore;

                return (ctx.SaveChanges() == 1);
            }
        }

        public bool DeleteEvent(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Events.Single(e => e.Id == Id && e.Relationship.User == _userId);
                ctx.Events.Remove(entity);
                return (ctx.SaveChanges() == 1);
            }
        }
    }
}
