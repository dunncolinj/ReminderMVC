using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
                WhenSent = DateTime.Now,
                Subject = model.Subject,
                MessageText = model.MessageText,
                WhenRead = null
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Messages.Add(entity);
                return (ctx.SaveChanges() == 1);
            }
        }

        public IEnumerable<MessageListInbox> GetMessagesInbox()
        {
            using (var ctx = new ApplicationDbContext())
            {
                string recipient = _userId.ToString("D");
                // query for all messages where the related user ID is the currently logged on user

                var query = ctx.Messages.Where(e => e.Relationship.RelatedUserId == recipient)
                    .Select(e => new MessageListInbox
                    {
                        RelationshipId = e.RelationshipId,
                        WhenSent = e.WhenSent,
                        SenderName = e.Relationship.ApplicationUser.FirstName + " " + e.Relationship.ApplicationUser.MiddleName + " " + e.Relationship.ApplicationUser.LastName,
                        Subject = e.Subject,
                        MessageText = e.MessageText,
                        WhenRead = e.WhenRead
                    }
                    );
                return query.ToArray();
            }
        }

        public IEnumerable<MessageListOutbox> GetMessagesOutbox()
        {
            using (var ctx = new ApplicationDbContext())
            {
                Guid sender = _userId;
                // query for all messages where the user ID is the currently logged on user


                var query = ctx.Messages.Where(e => e.Relationship.User == sender)
                    .Select(e => new MessageListOutbox
                    {
                        RelationshipId = e.RelationshipId,
                        WhenSent = e.WhenSent,
                        RecipientName = e.Relationship.ApplicationUser.FirstName + " " + e.Relationship.ApplicationUser.MiddleName + " " + e.Relationship.ApplicationUser.LastName,
                        Subject = e.Subject,
                        MessageText = e.MessageText,
                        WhenRead = e.WhenRead
                    }
                    );
                return query.ToArray();
            }
        }

        public MessageDetails GetMessageById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                DateTime? _timeStamp;

                var entity = ctx.Messages.Single(e => (e.Id == id) && ((Guid.Parse(e.Relationship.RelatedUserId) == _userId)) || (e.Relationship.User == _userId));
                UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));
                var user = userManager.FindById(_userId.ToString("D"));

                if (entity.WhenRead == null)
                {
                    _timeStamp = DateTime.Now;
                }
                else {
                    _timeStamp = entity.WhenRead;
                }

                return new MessageDetails
                {
                    // property = entity.property
                    Id = entity.Id,
                    RelationshipId = entity.RelationshipId,
                    SenderName = user.FirstName + " " + user.MiddleName + " " + user.LastName,
                    RecipientName = entity.Relationship.ApplicationUser.FirstName + " " + entity.Relationship.ApplicationUser.MiddleName + " " + entity.Relationship.ApplicationUser.LastName,
                    WhenSent = entity.WhenSent,
                    Subject = entity.Subject,
                    MessageText = entity.MessageText,
                    WhenRead = _timeStamp
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
