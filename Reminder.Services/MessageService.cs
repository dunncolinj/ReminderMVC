using Reminder.Data;
using Reminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Services
{
    public class MessageService
    {
        private readonly Guid _userId;

        public MessageService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMessage(MessageCreate model)
        {
            var entity = new Message()
            {
                // property = model.property
                Id = model.Id,
                RelationshipId = model.RelationshipId,
                WhenSent = model.WhenSent,
                // RecipientName = model.RecipientName,
                Subject = model.Subject,
                MessageText = model.MessageText,
                WhenRead = model.WhenRead
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Messages.Add(entity);
                return (ctx.SaveChanges() == 1);
            }
        }

        public IEnumerable<Message> GetMessages()
        {
            using (var ctx = new ApplicationDbContext())
            {
                // query for all messages where the related user ID is the currently logged on user
                var query = ctx.Messages.Where(e => (Guid.Parse(e.Relationship.RelatedUserId) == _userId));
                return query.ToArray();
            }
        }

        public MessageDetails GetMessageById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Messages.Single(e => (e.Id == id) && (Guid.Parse(e.Relationship.RelatedUserId) == _userId));

                return new MessageDetails
                {
                    // property = entity.property
                    Id = entity.Id,
                    RelationshipId = entity.RelationshipId,
                    SenderName = (entity.Relationship.ApplicationUser.FirstName + " " + entity.Relationship.ApplicationUser.LastName),
                    WhenSent = entity.WhenSent,
                    Subject = entity.Subject,
                    MessageText = entity.MessageText,
                    WhenRead = entity.WhenRead
                };
            }
        }

        public bool DeleteMessage(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Messages.Single(e => (e.Id == Id) && (Guid.Parse(e.Relationship.RelatedUserId) == _userId));
                ctx.Messages.Remove(entity);
                return (ctx.SaveChanges() == 1);
            }
        }
    }
}
