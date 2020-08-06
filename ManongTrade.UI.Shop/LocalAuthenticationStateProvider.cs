using Blazored.LocalStorage;
using ManongTrade.UI.Shop.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ManongTrade.UI.Shop
{
    public class LocalAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _storageService;

        public LocalAuthenticationStateProvider(ILocalStorageService storageService)
        {
            _storageService = storageService;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (await _storageService.ContainKeyAsync("ManongUser").ConfigureAwait(false))
            {
                var userInfo = await _storageService.GetItemAsync<CustomerModel>("ManongUser").ConfigureAwait(false);

                var claims = new[]
                {
                    new Claim("FirstName", userInfo.Firstname),
                    new Claim("LastName", userInfo.Lastname),
                    new Claim("AccessToken", userInfo.Token)
                };

                var identity = new ClaimsIdentity(claims, "BearerToken");
                var user = new ClaimsPrincipal(identity);
                var state = new AuthenticationState(user);
                NotifyAuthenticationStateChanged(Task.FromResult(state));
                return state;
            }

            return new AuthenticationState(new ClaimsPrincipal());
        }

        public async Task LogoutAsync()
        {
            await _storageService.RemoveItemAsync("ManongUser");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal())));
        }
    }
}
