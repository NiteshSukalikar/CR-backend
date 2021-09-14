namespace Shared.Utility
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Primitives;
    using IEH_Shared.Model;
    using System;
    using System.Reflection;
    using System.Threading.Tasks;
    using Shared.Model;

    /// <summary>
    /// Defines the <see cref="LogApiFilter" />
    /// </summary>
    public class LogApiFilter<TController> : IAsyncActionFilter where TController:class
    {
        /// <summary>
        /// The OnActionExecutionAsync
        /// </summary>
        /// <param name="requestContext">The requestContext<see cref="ActionExecutingContext"/></param>
        /// <param name="next">The next<see cref="ActionExecutionDelegate"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext requestContext, ActionExecutionDelegate next)
        {
            requestContext.HttpContext.Request.Headers.TryGetValue("UserId", out StringValues user_id);
            requestContext.HttpContext.Request.Headers.TryGetValue("CreatedOn", out StringValues created_On);
            // Do something before the action executes.
            ActionExecutedContext resultContext = await next();

            AuditLogModel auditLogVM = new AuditLogModel();

            if (resultContext.Exception != null)
            {
                // Exception thrown by action or action filter.
                auditLogVM.Response = resultContext.Exception.Message;
            }
            else
            {
                auditLogVM.Response = "Success";
            }

            if (resultContext.Canceled == true)
            {
                auditLogVM.Response = resultContext.Canceled.ToString();
            }

            var abc = requestContext.HttpContext.Items.ContainsKey("Payload");

            auditLogVM.Payload = requestContext.HttpContext.Items.ContainsKey("Payload") ? requestContext.HttpContext.Items["Payload"].ToString() : string.Empty;
            auditLogVM.Endpoint = requestContext.HttpContext.Request.Path;
            auditLogVM.Method = requestContext.HttpContext.Request.Method;
            auditLogVM.CreatedBy = requestContext.HttpContext.Items.ContainsKey("CreatedBy") ? Convert.ToInt64(requestContext.HttpContext.Items["CreatedBy"]) : requestContext.HttpContext.Request.Headers.ContainsKey("userid") ? Convert.ToInt64(requestContext.HttpContext.Request.Headers["userid"].ToString()) : 0;
            auditLogVM.CreatedOn = requestContext.HttpContext.Request.Headers.ContainsKey("createdOn") ? Convert.ToInt64(requestContext.HttpContext.Request.Headers["createdOn"].ToString()) : 0;

            TController controller = requestContext.Controller as TController;
            
            controller.GetType().InvokeMember("AuditApi",  BindingFlags.Instance | BindingFlags.InvokeMethod, null, null, new object[] { auditLogVM });
        }
    }
}
