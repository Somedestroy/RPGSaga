namespace Application.Exceptions
{
    using System;

    public class ProductBadRequestException : Exception
    {
        public ProductBadRequestException(string message)
            : base(message)
        {
        }
    }
}
