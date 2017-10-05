using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CustomAuthenticationDemo.Authentication
{
	public static class ApplicationBuilderExtensions
	{
		public static IApplicationBuilder UseMyAuthentication(this IApplicationBuilder app, IConfigurationSection config)
		{
			return app.UseMyAuthentication(options => { });
		}

		private static IApplicationBuilder UseMyAuthentication(this IApplicationBuilder app, Action<CustomAuthenticationOptions> configure)
		{
			var options = new CustomAuthenticationOptions();
			configure?.Invoke(options);

			return app.UseMiddleware<CustomAuthenticationMiddleware>(new OptionsWrapper<CustomAuthenticationOptions>(options));
		}
	}
}