using shared.Auth;
using shared.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace shared.services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        public async Task<ServiceResponse<string>> Login(UserLoginDTO userLoginDto)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/login/", userLoginDto);

            var data = await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();

            return data;
        }

        public async Task<ServiceResponse<int>> Register(UserRegisterDTO userRegisterDTO)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/register/", userRegisterDTO);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

        public async Task<ServiceResponse<bool>> ChangePassword(string newPassword)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/change-password/", newPassword);

            return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }

        public async Task<ServiceResponse<bool>> GoogleRegister(string newPassword)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/Googlesignit/", newPassword);

            return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }
    }
}
