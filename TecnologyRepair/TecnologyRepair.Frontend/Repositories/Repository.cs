﻿using System.Text;
using System.Text.Json;
using TecnologyRepair.Frontend.Repository;
using TecnologyRepair.Shared.Models;

namespace TecnologyRepair.Frontend.Repositories
{
    public class Repository : IRepository
    {
        private readonly HttpClient _httpClient;

        private JsonSerializerOptions _jsonDefaultOptions => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public Repository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<Response<T>> GetAsync<T>(string url)
        {
            var responseHttp = await _httpClient.GetAsync(url);
            if (!responseHttp.IsSuccessStatusCode) 
            {
                return new Response<T>
                {
                    IsSuccess = false,
                    Message = "No results found",
                };
            }

            var responseString = await responseHttp.Content.ReadAsStringAsync();
            var responseJson = JsonSerializer.Deserialize<T>(responseString, _jsonDefaultOptions);
            return new Response<T>
            {
                IsSuccess = true,
                Result = responseJson

            };
        }

        public async Task<Response<T>> DeleteAsync<T>(string url)
        {
			var responseHttp = await _httpClient.DeleteAsync(url);
			if (!responseHttp.IsSuccessStatusCode)
			{
				return new Response<T>
				{
					IsSuccess = false,
					Message = "Fail to delete the object",
				};
			}

			return new Response<T>
			{
				IsSuccess = true,
			};
		}

		public async Task<Response<T>> PostAsync<T>(string url, T model)
        {
            var messageJson = JsonSerializer.Serialize(model, _jsonDefaultOptions);
            var messageContent = new StringContent(messageJson, Encoding.UTF8, "application/json");
            var responseHttp = await _httpClient.PostAsync(url, messageContent);
            if (!responseHttp.IsSuccessStatusCode)
            {
                return new Response<T>
                {
					IsSuccess = false,
					Message = "Fail to post the objet",
				};
            }
			var responseString = await responseHttp.Content.ReadAsStringAsync();
			var responseJson = JsonSerializer.Deserialize<T>(responseString, _jsonDefaultOptions);
			return new Response<T>
			{
				IsSuccess = true,
				Result = responseJson

			};
		}

        public async Task<Response<T>> PutAsync<T>(string url, T model)
        {
			var messageJson = JsonSerializer.Serialize(model, _jsonDefaultOptions);
			var messageContent = new StringContent(messageJson, Encoding.UTF8, "application/json");
			var responseHttp = await _httpClient.PutAsync(url, messageContent);
			if (!responseHttp.IsSuccessStatusCode)
			{
				return new Response<T>
				{
					IsSuccess = false,
					Message = "Fail to put the objet",
				};
			}
			var responseString = await responseHttp.Content.ReadAsStringAsync();
			var responseJson = JsonSerializer.Deserialize<T>(responseString, _jsonDefaultOptions);
			return new Response<T>
			{
				IsSuccess = true,
				Result = responseJson

			};
		}
	}
}
