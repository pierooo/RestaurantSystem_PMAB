﻿namespace RestaurantSystem.Contracts;

public class ResponseBase<T> : ErrorResponseBase
{
    public T? Data { get; set; }
}
