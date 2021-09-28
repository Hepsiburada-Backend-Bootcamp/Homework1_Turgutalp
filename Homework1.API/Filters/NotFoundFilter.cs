using System.Linq;
using System.Threading.Tasks;
using Homework1.API.DTO;
using Homework1.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Homework1.API.Filters
{
    public class NotFoundFilter: ActionFilterAttribute
    {
        private readonly IProductService _productService;

        public NotFoundFilter(IProductService productService)
        {
            _productService = productService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var product = await _productService.GetByIdAsync(id);
            if (product != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 404;
                
                errorDto.Errors.Add($"id => {id} olan urun veritabaninda bulunamadi..");

                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}