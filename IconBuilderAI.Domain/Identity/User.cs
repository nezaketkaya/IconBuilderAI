﻿using IconBuilderAI.Domain.Common;
using IconBuilderAI.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IconBuilderAI.Domain.Identity
{
    public class User : IdentityUser<Guid>, IEntity<Guid>, ICreatedByEntity, IModifiedByEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? ProfileImage { get; set; }

        public UserBalance Balance { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
        public string CreatedByUserId { get; set; }

        public DateTimeOffset? ModifiedOn { get; set; }
        public string? ModifiedByUserId { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}