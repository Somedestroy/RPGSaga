namespace Application.Exceptions
{
    using System;

    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(Guid productId)
            : base($"The product with the identifier {productId} was not found.")
        {
        }
    }
}
