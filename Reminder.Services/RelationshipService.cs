using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Reminder.Data;
using Reminder.Models;
using Reminder.Models.Relationship;
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

        public IEnumerable<UserList> ListUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                string userIdString = _userId.ToString("D");

                UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));
                var users = userManager.Users.Where(e => e.Id != userIdString).Select(e => new UserList
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    MiddleName = e.MiddleName,
                    LastName = e.LastName,
                    City = e.City,
                    State = e.State,
                    Zip = e.Zip
                });
            
                return users.ToArray();
            }
        }
        public bool CreateRelationship(RelationshipCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            { 

                var entity1 = new Relationship()
                {
                    // property = model.property
                    User = _userId,
                    RelatedUserId = model.RelatedUserId,
                    HowRelated = model.HowRelated,
                    Connected = true
                };

                var entity2 = new Relationship()
                {
                    User = Guid.Parse(model.RelatedUserId),
                    RelatedUserId = _userId.ToString("D"),
                    HowRelated = ReciprocalRelationship(model.HowRelated),
                    Connected = true
                };

                ctx.Relationships.Add(entity1);
                bool returnCode1 = (ctx.SaveChanges() == 1);
                ctx.Relationships.Add(entity2);
                bool returnCode2 = (ctx.SaveChanges() == 1);
                return (returnCode1 && returnCode2);
            }
        }

        public RelationshipType ReciprocalRelationship(RelationshipType howRelated)
        {
            RelationshipType ReciprocalRelationship = RelationshipType.colleague;

                switch (howRelated)
                {
                    case RelationshipType.spouse:
                    case RelationshipType.significantOther:
                    case RelationshipType.cousin:
                    case RelationshipType.friend:
                    case RelationshipType.colleague:
                    case RelationshipType.sibling:
                        ReciprocalRelationship = howRelated;
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
            return ReciprocalRelationship;
        }

        public IEnumerable<RelationshipList> GetRelationships()
        {
            using (var ctx = new ApplicationDbContext())
            {
                // query for all my relationships

                var query = ctx.Relationships.Where(e => e.User == _userId)
                    .Select(
                    e => new RelationshipList
                    {
                        Id = e.Id,
                        RelatedUserId = e.RelatedUserId,
                        RelatedUserName = e.ApplicationUser.FirstName + " " + e.ApplicationUser.MiddleName + " " + e.ApplicationUser.LastName,
                        HowRelated = e.HowRelated,
                        Connected = e.Connected
                    } );
                return query.ToArray();
            }
        }

        public RelationshipDetails GetRelationshipById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Relationships.Single(e => e.User == _userId && e.Id == id);

                return new RelationshipDetails
                {
                    // property = entity.property
                    Id = entity.Id,
                    RelatedUserId = entity.RelatedUserId,
                    RelatedUserName = entity.ApplicationUser.FirstName + " " + entity.ApplicationUser.MiddleName + " " + entity.ApplicationUser.LastName,
                    HowRelated = entity.HowRelated,
                    Connected = entity.Connected
                };
            }
        }

        public bool UpdateRelationship(RelationshipUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Relationships.Single(e => e.User == _userId && e.Id == model.Id);
                entity.HowRelated = model.HowRelated;
                entity.Connected = model.Connected;
                return (ctx.SaveChanges() == 1);
            }
        }

        public bool DeleteRelationship(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity1 = ctx.Relationships.Single(e => e.Id == Id && e.User == _userId);
                string reciprocalUserId = entity1.RelatedUserId;
                Guid reciprocalUserGuid = Guid.Parse(reciprocalUserId);
                string reciprocalRelated = _userId.ToString("D");

                var entity2 = ctx.Relationships.Single(e => e.User == reciprocalUserGuid && e.RelatedUserId == reciprocalRelated);

                ctx.Relationships.Remove(entity1);
                ctx.Relationships.Remove(entity2);

                return (ctx.SaveChanges() == 2);
            }
        }
    }
}
