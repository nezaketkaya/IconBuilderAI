using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IconBuilderAI.Domain.Common
{
    public interface IModifiedByEntity
    {
        DateTimeOffset? LastModifiedOn { get; set; }
        string? LastModifiedByUserId { get; set; }
    }
}
