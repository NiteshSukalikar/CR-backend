namespace Shared.Utility
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Primitives;
    using Newtonsoft.Json;
    using Serilog;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Shared.Model;
    using Shared.StaticConstants;

    /// <summary>
    /// Defines the <see cref="RequestTokenFilter" />
    /// </summary>
    public class RequestTokenFilter : IAsyncActionFilter
    {
        /// <summary>
        /// Defines the _configuration
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestTokenFilter"/> class.
        /// </summary>
        /// <param name="Configuration">The Configuration<see cref="IConfiguration"/></param>
        public RequestTokenFilter(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        /// <summary>
        /// The OnActionExecutionAsync
        /// </summary>
        /// <param name="requestContext">The requestContext<see cref="ActionExecutingContext"/></param>
        /// <param name="next">The next<see cref="ActionExecutionDelegate"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext requestContext, ActionExecutionDelegate next)
        {
            requestContext.HttpContext.Request.Headers.TryGetValue("access_token", out StringValues access_token);
            requestContext.HttpContext.Request.Headers.TryGetValue("refresh_token", out StringValues refresh_token);
            TokenResponseModel TokenResponseModel = new TokenResponseModel();
            try
            {
                if (access_token.ToString() != null && refresh_token.ToString() != null)
                {
                    HttpClient _httpClient = new HttpClient();


                    Dictionary<string, string> val = new Dictionary<string, string>
                        {
                            { "refresh_token", refresh_token},
                        };

                    // get access token

                    _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    _httpClient.DefaultRequestHeaders.Add("access_token", access_token.ToString());

                    FormUrlEncodedContent getAccessTokenContent = new FormUrlEncodedContent(val);

                    HttpResponseMessage getAccessTokenResponse = await _httpClient.PostAsync(_configuration["OsApi:OsApiCheckAccessToken"].ToString(), getAccessTokenContent);

                    string getAccessTokenResponseString = await getAccessTokenResponse.Content.ReadAsStringAsync();

                    TokenResponseModel getAccessTokendata = JsonConvert.DeserializeObject<TokenResponseModel>(getAccessTokenResponseString);

                    if (getAccessTokendata.Code.Equals((int)SharedStatusCode.Ok))
                    {
                        if (Object.Equals(getAccessTokendata.Token, ""))
                        {
                            TokenResponseModel.HasUpdatedToken = false;
                            TokenResponseModel.StatusCode = (int)(int)SharedStatusCode.Ok;
                        }
                        else
                        {
                            TokenResponseModel.HasUpdatedToken = true;
                            TokenResponseModel.Token = getAccessTokendata.Token;
                            TokenResponseModel.StatusCode = (int)SharedStatusCode.Ok;
                        }
                    }
                    else
                    {
                        TokenResponseModel.StatusCode = (int)SharedStatusCode.BadRequest;
                        TokenResponseModel.Message = SharedStatusCode.BadRequest.ToString();
                    }
                }
                else
                {
                    TokenResponseModel.StatusCode = (int)SharedStatusCode.BadRequest;
                    TokenResponseModel.Message = SharedStatusCode.BadRequest.ToString();
                }

            }
            catch (System.Exception ex)
            {
                Log.Error(ex.ToString());
                TokenResponseModel.StatusCode = (int)SharedStatusCode.publicServerError;
                TokenResponseModel.Message = SharedStatusCode.publicServerError.ToString();
            }

            requestContext.HttpContext.Items["responseVM"] = TokenResponseModel;
            requestContext.HttpContext.Items["Payload"] = JsonConvert.SerializeObject(requestContext.ActionArguments);
            //HttpContext.Items["CreatedBy"] = filterParams.CreatedBy;

            ActionExecutedContext resultContext = await next();
        }
    }
}
