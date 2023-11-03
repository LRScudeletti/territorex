using Microsoft.Extensions.Localization;
using System.Net;
using TerritorEx.Api.Localize;

namespace TerritorEx.Api.Middlewares
{
    public class RateLimitMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly IStringLocalizer<Resources> _localizer;

        public RateLimitMiddleware(RequestDelegate next, IConfiguration configuration, IStringLocalizer<Resources> localizer)
        {
            _next = next;
            _configuration = configuration;
            _localizer = localizer;
        }

        public async Task Invoke(HttpContext context)
        {
            var ip = context.Connection.RemoteIpAddress;
            var dns = await GetDnsNameAsync(ip);

            var applicationDns = _configuration["ApplicationDns"];

            if (dns.Equals(applicationDns))
                await _next(context);
            else
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync(_localizer["app_sem_permissao_para_solicitacao"]);
            }
        }

        private static async Task<string> GetDnsNameAsync(IPAddress ipAddress)
        {
            try
            {
                var hostEntry = await Dns.GetHostEntryAsync(ipAddress);
                return hostEntry.HostName;
            }
            catch
            {
                return "Não foi possível obter o DNS.";
            }
        }
    }
}
