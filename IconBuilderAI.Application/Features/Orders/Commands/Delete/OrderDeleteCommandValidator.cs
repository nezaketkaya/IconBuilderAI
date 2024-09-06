using FluentValidation;
using IconBuilderAI.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IconBuilderAI.Application.Features.Orders.Commands.Delete
{
    public class OrderDeleteCommandValidator : AbstractValidator<OrderDeleteCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        public OrderDeleteCommandValidator(IApplicationDbContext dbContext, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;

            RuleFor(x => x.Id).NotEmpty()
                              .NotNull()
                              .WithMessage("Please select a valid order.");

            RuleFor(x => x.Id).MustAsync(IsOrderExistsAsync)
                              .WithMessage("The selected order does not exist in the database.");

            RuleFor(x => x.Id)
              .MustAsync(IsTheSameUserAsync)
              .WithMessage("You are not authorized to delete this order.");
        }

        public Task<bool> IsOrderExistsAsync(Guid id, CancellationToken cancellationToken)
        {
            return _dbContext.Orders.AnyAsync(x  => x.Id == id, cancellationToken);
        }

        private Task<bool> IsTheSameUserAsync(Guid id, CancellationToken cancellationToken)
        {
            return _dbContext
                .Orders
                .Where(x => x.UserId == _currentUserService.UserId)
                .AnyAsync(x => x.Id == id, cancellationToken);
        }
    }
}
