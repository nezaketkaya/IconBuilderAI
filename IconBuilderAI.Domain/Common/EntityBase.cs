using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IconBuilderAI.Domain.Common
{
    public abstract class EntityBase<TKey> : IEntity<TKey>, ICreatedByEntity, IModifiedByEntity
    {
        public TKey Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }
        public string? LastModifiedByUserId { get; set; }
    }
}
