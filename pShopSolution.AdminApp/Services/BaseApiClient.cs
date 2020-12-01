using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using pShopSolution.Utilities.Constants;
using PShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace pShopSolution.AdminApp.Services
{
    public class BaseApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory; //tạo ra đối tượng client.
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        protected async Task<TResponse> GetAsync<TResponse>(string url)
        {
            var bearerToken = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BassAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                TResponse myDeserializedObjList = (TResponse)JsonConvert.DeserializeObject(content, typeof(TResponse));
                return myDeserializedObjList;
            }
            return JsonConvert.DeserializeObject<TResponse>(content);
        }

        protected async Task<List<T>> GetListAsync<T>(string url, bool requiredLogin = false)
        {
            var bearerToken = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BassAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var data = (List<T>)JsonConvert.DeserializeObject(content, typeof(List<T>));
                return data;
            }
            throw new Exception(content);
        }

        protected async Task<TResponse> PostAsync<TResponse>(string url, StringContent httpContent)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BassAddress]);

            var bearerToken = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            var response = await client.PostAsync(url, httpContent);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<TResponse>(content);
            return JsonConvert.DeserializeObject<TResponse>(content);
        }

        protected async Task<TResponse> PutAsync<TResponse>(string url, StringContent httpContent)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BassAddress"]);

            var bearerToken = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            var response = await client.PutAsync(url, httpContent);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<TResponse>(content);
            return JsonConvert.DeserializeObject<TResponse>(content);
        }

        protected async Task<TResponse> DeleteAsync<TResponse>(string url)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BassAddress"]);

            var bearerToken = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            var response = await client.DeleteAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<TResponse>(content);
            return JsonConvert.DeserializeObject<TResponse>(content);
        }

        protected async Task<TResponse> AssignRolePutAsync<TResponse>(string url, StringContent httpContent)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BassAddress"]);

            var bearerToken = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            var response = await client.PutAsync(url, httpContent);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                TResponse myDeserializedObjList = (TResponse)JsonConvert.DeserializeObject(content, typeof(TResponse));
                return myDeserializedObjList;
            }
            return JsonConvert.DeserializeObject<TResponse>(content);
        }

        protected async Task<TResponse> AssignCategoryPutAsync<TResponse>(string url, StringContent httpContent)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BassAddress"]);

            var bearerToken = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            var response = await client.PutAsync(url, httpContent);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                TResponse myDeserializedObjList = (TResponse)JsonConvert.DeserializeObject(content, typeof(TResponse));
                return myDeserializedObjList;
            }
            return JsonConvert.DeserializeObject<TResponse>(content);
        }
    }
}