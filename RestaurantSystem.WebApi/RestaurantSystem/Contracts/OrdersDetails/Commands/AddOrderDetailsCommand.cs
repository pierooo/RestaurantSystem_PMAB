﻿using MediatR;

namespace RestaurantSystem.Contracts.OrdersDetails.Commands;

public class AddOrderDetailsCommand : IRequest<CommandResponse>
{
    public int OrderID { get; set; }

    public int ProductID { get; set; }

    public int Quantity { get; set; }

    public string? Notes { get; set; }
}
