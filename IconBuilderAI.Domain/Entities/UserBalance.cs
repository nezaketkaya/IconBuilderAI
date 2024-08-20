using IconBuilderAI.Domain.Common;
using IconBuilderAI.Domain.Identity;

namespace IconBuilderAI.Domain.Entities
{
    public class UserBalance : EntityBase<Guid>
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int Credits { get; set; }
        public ICollection<UserBalanceHistory> Histories { get; set; }
    }
}
