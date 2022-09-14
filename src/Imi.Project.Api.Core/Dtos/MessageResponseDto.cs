using System;
using Imi.Project.Api.Core.Dtos.Base;

namespace Imi.Project.Api.Core.Dtos
{
    public class MessageResponseDto : DtoBase
    {
        public string FromId { get; set; }
        public string ToId { get; set; }
        public string TextMessage { get; set; }
        public DateTime DateTimeMessage { get; set; }
    }
}
