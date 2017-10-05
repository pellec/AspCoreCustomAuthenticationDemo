using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace CustomAuthenticationDemo.Authentication
{
    public class CustomAuthenticationOptions : AuthenticationOptions
	{
		public CustomAuthenticationOptions()
		{
			AuthenticationScheme = Scheme.Custom;
		}
	}
}
