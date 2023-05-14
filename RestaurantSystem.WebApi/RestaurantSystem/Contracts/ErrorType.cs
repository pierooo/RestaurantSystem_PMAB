﻿namespace RestaurantSystem.Contracts;

public static class ErrorType
{
    public const string InternalServerError = "Internal_Server_Error";
    public const string ValidationError = "Validation_Error";
    public const string NotAutenthicated = "Not_Autenthicated";
    public const string Unautorized = "Unautorized";
    public const string NotFound = "Not_Found";
    public const string UnSupportedMediaType = "UnSupported_Media_Type";
    public const string UnSupportedMethod = "UnSupported_Method";
    public const string RequestTooLarge = "Request_Too_Large";
    public const string TooManyRequest = "Too_Many_Request";
    public const string UsernameExists = "Username_Exists";
}
