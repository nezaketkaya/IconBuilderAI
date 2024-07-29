using FluentValidation;
using IconBuilderAI.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IconBuilderAI.Application.Features.Orders.Commands.Delete
{
    public class OrderDeleteCommandValidator : AbstractValidator<OrderDeleteCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        public OrderDeleteCommandValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.Id).NotEmpty()
                              .NotNull()
                              .WithMessage("Please select a valid order.");
        }
    }
}
