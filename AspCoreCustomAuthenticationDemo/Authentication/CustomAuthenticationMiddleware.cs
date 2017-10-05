using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CustomAuthenticationDemo.Authentication
{
	public class CustomAuthenticationMiddleware : AuthenticationMiddleware<CustomAuthenticationOptions>
	{
		public CustomAuthenticationMiddleware(RequestDelegate next, IOptions<CustomAuthenticationOptions> options, ILoggerFactory loggerFactory, UrlEncoder encoder) : base(next, options, loggerFactory, encoder)
		{
		}

		protected override AuthenticationHandler<CustomAuthenticationOptions> CreateHandler()
		{
			return new CustomAuthenticationHandler();
		}
	}
}