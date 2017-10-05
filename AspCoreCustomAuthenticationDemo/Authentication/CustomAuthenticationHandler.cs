using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Authentication;

namespace CustomAuthenticationDemo.Authentication
{
	public class CustomAuthenticationHandler : AuthenticationHandler<CustomAuthenticationOptions>
	{
		protected override Task<AuthenticateResult> HandleAuthenticateAsync()
		{
			var authorizationHeader = Context.Request.Headers["Authorization"];
			if (!authorizationHeader.Any())
				return Task.FromResult(AuthenticateResult.Skip());

			var value = authorizationHeader.ToString();
			if (string.IsNullOrWhiteSpace(value))
				return Task.FromResult(AuthenticateResult.Skip());

			// place logic here to validate the header value (decrypt, call db etc)
			var token = value.Replace(Scheme.Custom, string.Empty).Trim();
			var authorization = Encoding.UTF8.GetString(Convert.FromBase64String(token)).Split(':');
			if(!authorization.Any())
			{
				return Task.FromResult(AuthenticateResult.Skip());
			}

			if(authorization.Length != 2)
			{
				return Task.FromResult(AuthenticateResult.Skip());
			}

			var user = authorization[0];
			var pass = authorization[1];

			var valid = user.Equals("Aladdin") && pass.Equals("open sesame");
			if(!valid)
			{
				return Task.FromResult(AuthenticateResult.Skip());
			}

			// create a new claims identity and return an AuthenticationTicket 
			// with the correct scheme

			var claims = new[]
			{
				new Claim(ClaimTypes.Name, user)
			};

			var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, Scheme.Custom));

			var ticket = new AuthenticationTicket(principal, new AuthenticationProperties(), Scheme.Custom);

			return Task.FromResult(AuthenticateResult.Success(ticket));
		}
	}
}