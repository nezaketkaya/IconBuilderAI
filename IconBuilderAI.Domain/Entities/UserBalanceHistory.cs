﻿using IconBuilderAI.Domain.Common;
using IconBuilderAI.Domain.Enums;

namespace IconBuilderAI.Domain.Entities
{
    public class UserBalanceHistory : EntityBase<Guid>
    {
        public Guid UserBalanceId { get; set; }
        public UserBalance UserBalance { get; set; }
        public UserBalanceHistoryType Type { get; set; }
        public int Amount { get; set; } // Increasing or decreasing credit amount.
        public int PreviousCredits { get; set; }
        public int CurrentCredits { get; set; }
    }
}
