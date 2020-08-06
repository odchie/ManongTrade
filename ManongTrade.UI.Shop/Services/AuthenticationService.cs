using ManongTrade.UI.Shop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ManongTrade.UI.Shop.Services
{
    public class AuthenticationService
    {
        private readonly HttpClient _apiClient;

        //ServiceClient client = new ServiceClient();

        public AuthenticationService(string WebApiUrl)
        {
            _apiClient = new HttpClient
            {
                BaseAddress = new Uri(WebApiUrl)
            };
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<ApiResponseModel<CustomerModel>> CheckLogin(string Username)
        {
            using HttpResponseMessage response = await _apiClient.GetAsync("/api/auth/" + Username).ConfigureAwait(false);
            ApiResponseModel<CustomerModel> apiResponse = new ApiResponseModel<CustomerModel>();
            if (response.IsSuccessStatusCode)
            {
                var cust = await response.Content.ReadAsAsync<CustomerModel>().ConfigureAwait(false);
                apiResponse.IsOk = true;
                apiResponse.ReturnObject = cust;
                return apiResponse;
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                apiResponse.IsOk = false;
                apiResponse.Message = "Username not found";
                return apiResponse;
            }

            throw new Exception(response.ReasonPhrase);
        }
    }
}
