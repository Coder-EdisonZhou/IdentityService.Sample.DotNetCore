using Manulife.DNC.MSAD.Common;
using System;
using System.Threading.Tasks;

namespace Manulife.DNC.MSAD.NB.ClientService.Services
{
    public class ProductService
    {
        [HystrixCommand(nameof(GetAllProductsFallBackAsync),
            IsEnableCircuitBreaker = true,
            ExceptionsAllowedBeforeBreaking = 3,
            MillisecondsOfBreak = 1000 * 5)]
        public virtual async Task<string> GetAllProductsAsync(string productType)
        {
            Console.WriteLine($"-->>Starting get product type : {productType}");
            string str = null;
            str.ToString();
            
            // to do : using HttpClient to call outer service to get product list

            return $"OK {productType}";
        }

        public virtual async Task<string> GetAllProductsFallBackAsync(string productType)
        {
            Console.WriteLine($"---->>FallBack : Starting get product type : {productType}");

            return $"OK for FallBack  {productType}";
        }
    }
}
