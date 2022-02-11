﻿using Reminder.Data;
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
                User = _userId,
                RelatedUserId = model.RelatedUserId,
                HowRelated = model.HowRelated,
                Connected = false
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
                User = Guid.Parse(model.RelatedUserId),
                RelatedUserId = _userId.ToString("D"),
                HowRelated = ReciprocalRelationship,
                Connected = true
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Relationships.Add(entity);
                return (ctx.SaveChanges() == 1);
            }
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

                var entity = ctx.Relationships.Single(e => e.Id == Id && e.User == _userId);
                ctx.Relationships.Remove(entity);
                return (ctx.SaveChanges() == 1);
                // update reciprocal to delete
            }
        }
    }
}
