﻿using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistence;

namespace Ordering.Application.Features.Queries.GetOrdersList
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, List<GetOrdersBusinessObject>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<GetOrdersBusinessObject>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrderByUserName(request.UserName);

            return _mapper.Map<List<GetOrdersBusinessObject>>(orders);
        }
    }
}
