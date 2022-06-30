using MediatR;

namespace Ordering.Application.Features.Queries.GetOrdersList
{
    public class GetOrderListQuery : IRequest<List<GetOrdersBusinessObject>>
    {
        public string UserName { get; set; }

        public GetOrderListQuery(string userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        }
    }
}
