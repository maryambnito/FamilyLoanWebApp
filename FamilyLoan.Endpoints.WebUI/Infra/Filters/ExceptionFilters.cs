using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace FamilyLoan.Endpoints.WebUI.Infra.Filters
{
    public class ExceptionHandelFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionHandelFilter> logger;

        public ExceptionHandelFilter(ILogger<ExceptionHandelFilter> logger)
        {
            this.logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            logger.LogError(context.Exception, "خطا در قسمت ایجاد مشتری ");
        }
    }
}
