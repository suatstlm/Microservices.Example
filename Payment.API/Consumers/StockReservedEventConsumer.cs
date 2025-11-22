using MassTransit;
using Shared.Events;

namespace Payment.API.Consumers
{
    public class StockReservedEventConsumer : IConsumer<StockReservedEvent>
    {
        readonly IPublishEndpoint _publishEndpoint;

        public StockReservedEventConsumer(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public Task Consume(ConsumeContext<StockReservedEvent> context)
        {
            //Payment transactions....

            if (true)
            {
                PaymentCompletedEvent paymentCompletedEvent = new()
                {
                    OrderId = context.Message.OrderId
                };
                _publishEndpoint.Publish(paymentCompletedEvent);

                Console.WriteLine("Payment successful...");
            }
            else
            {
                PaymentFailedEvent paymentFailedEvent = new()
                {
                    OrderId = context.Message.OrderId,
                    Message = "Insufficient balance..."
                };

                _publishEndpoint.Publish(paymentFailedEvent);

                Console.WriteLine("Payment failed...");
            }

            return Task.CompletedTask;
        }
    }
}
