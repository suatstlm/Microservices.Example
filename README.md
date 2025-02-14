# Microservices.Training.Example
1.Order.API publishes an OrderCreatedEvent when a new order is placed.
2.Stock.API listens for this event and checks the stock availability:
  -If stock is available, it publishes a StockReservedEvent.
  -If stock is insufficient, it publishes a StockNotReservedEvent.
3.Payment.API listens for the StockReservedEvent and processes the payment:
  -If the payment is successful, it publishes a PaymentCompletedEvent.
  -If the payment fails, it publishes a PaymentFailedEvent.
4.Order.API listens for the PaymentCompletedEvent and marks the order as completed.
-If StockNotReservedEvent is triggered, the order is canceled due to insufficient stock.
