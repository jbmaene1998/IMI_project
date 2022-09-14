using System;
using System.Collections.Generic;
using System.Linq;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;

namespace Imi.Project.Api.Infrastructure.Data.Repositories
{
    public class MessageRepository : EntityRepository<Message>, IMessageRepository
    {
        public MessageRepository(ITInternshipsContextDb dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Message> GetAllFromRecruiter(string recruiterId, string studentId)
        {
            var results = GetAll().Where(m => m.FromId == recruiterId && m.ToId == studentId).AsEnumerable();
            return results;

        }

        public IEnumerable<Message> GetAllFromStudent(string studentId, string recruiterId)
        {
            var results = GetAll().Where(m => m.FromId == studentId && m.ToId == recruiterId).AsEnumerable();
            return results;
        }
    }
}
