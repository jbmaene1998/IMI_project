using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Core.Interfaces.Repositories
{
    public interface IMessageRepository : IEntityRepository<Message>
    {
        IEnumerable<Message> GetAllFromRecruiter(string recruiterId, string studentId);
        IEnumerable<Message> GetAllFromStudent(string studentId, string recruiterId);
    }
}
