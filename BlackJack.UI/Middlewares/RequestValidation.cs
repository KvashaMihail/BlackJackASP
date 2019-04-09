using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace BlackJack.UI.Middlewares
{
    public class RequestValidation
    {
        private RequestDelegate _next;

        public RequestValidation(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var gameId = context.Request;
            int id = 1;
            if (id < 0)
            {
                context.Response.StatusCode = 400;
            }
            else
            {
                try
                {
                    await _next.Invoke(context);
                }
                catch (Exception ex)
                {

                }
                //..
            }
        }
    }
}
