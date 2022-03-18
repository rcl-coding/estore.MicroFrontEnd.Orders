#nullable disable
using estore.MicroFrontEnd.Orders.Models;
using estore.MicroFrontEnd.Orders.Options;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace estore.MicroFrontEnd.Orders.Services
{
    public class OrderService : IOrderService
    {
        private static readonly HttpClient _httpClient;
        private readonly IOptions<ApiOptions> _apiOptions;

        public OrderService(IOptions<ApiOptions> apiOptions)
        {
            _apiOptions = apiOptions;
        }

        static OrderService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Add(_apiOptions.Value.UserName, _apiOptions.Value.Password);
                var response = await _httpClient.GetAsync($"{_apiOptions.Value.Endpoint}/orders-api/v1/order/all");
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Order>>(json);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return new List<Order>();
            }
        }

        public async Task<Order> GetOrderByIdAsync(int? id)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Add(_apiOptions.Value.UserName, _apiOptions.Value.Password);
                var response = await _httpClient.GetAsync($"{_apiOptions.Value.Endpoint}/orders-api/v1/order/id/{id}");
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Order>(json);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return new Order();
            }
        }

        public async Task<List<Order>> GetOrdersByCustomerAsync(string id)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Add(_apiOptions.Value.UserName, _apiOptions.Value.Password);
                var response = await _httpClient.GetAsync($"{_apiOptions.Value.Endpoint}/orders-api/v1/order/customer/{id}");
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Order>>(json);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return new List<Order>();
            }
        }

        public async Task DeleteOrderAsync(int? id)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Add(_apiOptions.Value.UserName, _apiOptions.Value.Password);
                var response = await _httpClient.DeleteAsync($"{_apiOptions.Value.Endpoint}/orders-api/v1/order/id/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }
    }
}
