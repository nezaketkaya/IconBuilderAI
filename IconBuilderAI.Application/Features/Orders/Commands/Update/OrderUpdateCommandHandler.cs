﻿using IconBuilderAI.Application.Common.Interfaces;
using IconBuilderAI.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IconBuilderAI.Application.Features.Orders.Commands.Update
{

    public class OrderUpdateCommandHandler : IRequestHandler<OrderUpdateCommand, ResponseDto<Guid>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;

        public OrderUpdateCommandHandler(IApplicationDbContext dbContext, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
        }

        public async Task<ResponseDto<Guid>> Handle(OrderUpdateCommand request, CancellationToken cancellationToken)
        {
            var oldOrder = await _dbContext
                .Orders
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            var updatedOrder = OrderUpdateCommand.MapToOrder(request, oldOrder!, _currentUserService.UserId);

            _dbContext.Orders.Update(updatedOrder);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new ResponseDto<Guid>(updatedOrder.Id, "Order Updated Successfully.");
        }
    }
}