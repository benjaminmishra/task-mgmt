using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;

namespace TaskManagement.Api;

public class BasicAutheticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly TaskManagementDbContext _dbContext;
    public BasicAutheticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, TaskManagementDbContext dbContext,
        ILoggerFactory logger, 
        UrlEncoder encoder, 
        ISystemClock clock) 
        : base(options, logger, encoder, clock)
    {
        _dbContext = dbContext;
    }

    protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        UserInfo user = new UserInfo();
        if (!Request.Headers.ContainsKey("Authorization"))
            return AuthenticateResult.Fail("Missing Authorization Header");

        try
        {
            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
            var username = credentials[0];
            var password = credentials[1];
            user = await GetUser(username,password);
        }
        catch
        {
            return AuthenticateResult.Fail("Invalid Authorization Header");
        }

        if (user == null)
            return AuthenticateResult.Fail("Invalid Username or Password");

        var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
            };
        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }

    private async Task<UserInfo> GetUser(string email, string password)
    {
        return await _dbContext.UserInfos.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
    }
}
