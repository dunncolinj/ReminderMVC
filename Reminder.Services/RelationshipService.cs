using Reminder.Data;
using Reminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Services
{
    public class RelationshipService
    {
        private readonly Guid _userId;

        public RelationshipService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRelationship(RelationshipCreate model)
        {
            var entity = new Relationship()
            {
                // property = model.property
                Id = model.Id,
                User = _userId,
                RelatedUserId = model.RelatedUserId,
                // RelatedUserName = model.RelatedUserName,
                HowRelated = model.HowRelated,
                Connected = model.Connected
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Relationships.Add(entity);
                return (ctx.SaveChanges() == 1);
            }
        }

        public bool CreateReciprocalRelationship(RelationshipCreate model)
        {
            RelationshipType ReciprocalRelationship = RelationshipType.colleague;

            switch (model.HowRelated)
            {
                case RelationshipType.spouse:
                case RelationshipType.significantOther:
                case RelationshipType.cousin:
                case RelationshipType.friend:
                case RelationshipType.colleague:
                    ReciprocalRelationship = model.HowRelated;
                    break;
                case RelationshipType.grandparent:
                    ReciprocalRelationship = RelationshipType.grandchild;
                    break;
                case RelationshipType.grandchild:
                    ReciprocalRelationship = RelationshipType.grandparent;
                    break;
                case RelationshipType.parent:
                    ReciprocalRelationship = RelationshipType.child;
                    break;
                case RelationshipType.child:
                    ReciprocalRelationship = RelationshipType.parent;
                    break;
                case RelationshipType.auntUncle:
                    ReciprocalRelationship = RelationshipType.nieceNephew;
                    break;
                case RelationshipType.nieceNephew:
                    ReciprocalRelationship = RelationshipType.auntUncle;
                    break;        
            }

            var entity = new Relationship()
            {
                Id = model.Id,
                User = Guid.Parse(model.RelatedUserId),
                RelatedUserId = _userId.ToString("D"),
                // RelatedUserName = model.RelatedUserName,
                HowRelated = ReciprocalRelationship,
                Connected = true
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Relationships.Add(entity);
                return (ctx.SaveChanges() == 1);
            }
        }

        public IEnumerable<Relationship> GetRelationships()
        {
            using (var ctx = new ApplicationDbContext())
            {
                // query for all messages where the related user ID is the currently logged on user
                var query = ctx.Relationships.Where(e => ((Guid.Parse(e.ApplicationUser.Id) == _userId) || (Guid.Parse(e.RelatedUserId) == _userId)));
                return query.ToArray();
            }
        }

        public RelationshipDetails GetRelationshipById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Relationships.Single(e => (e.Id == id) && (Guid.Parse(e.ApplicationUser.Id) == _userId) || (Guid.Parse(e.RelatedUserId) == _userId));

                return new RelationshipDetails
                {
                    // property = entity.property
                    Id = entity.Id,
                    User = _userId,
                    RelatedUserId = entity.RelatedUserId,
                    // RelatedUserName = model.RelatedUserName,
                    HowRelated = entity.HowRelated,
                    Connected = entity.Connected
                };
            }
        }

        public bool UpdateRelationship(RelationshipUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Relationships.Single(e => (e.Id == model.Id) && (e.User == _userId));

                entity.Id = model.Id;
                entity.User = model.User;
                entity.RelatedUserId = model.RelatedUserId;
                // entity.RelatedUserName = model.RelatedUserName;
                entity.HowRelated = model.HowRelated;
                entity.Connected = model.Connected;

                return (ctx.SaveChanges() == 1);
            }
        }


        public bool DeleteRelationship(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Relationships.Single(e => (e.Id == Id) && (Guid.Parse(e.RelatedUserId) == _userId) || (Guid.Parse(e.ApplicationUser.Id) == _userId));
                ctx.Relationships.Remove(entity);
                return (ctx.SaveChanges() == 1);
            }
        }



    }
}
