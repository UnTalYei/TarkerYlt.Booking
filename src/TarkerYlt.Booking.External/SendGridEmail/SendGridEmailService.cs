using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;
using TarkerYlt.Booking.Application.External.SendGridEmail;
using TarkerYlt.Booking.Domain.Models.SendGridEmail;

namespace TarkerYlt.Booking.External.SendGridEmail
{
    public class SendGridEmailService : ISendGridEmailService
    {
        private readonly IConfiguration _configuration;
        public SendGridEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> Execute (SendGridEmailRequestModel model)
        {
            string apiKey = _configuration["SendGridEmailKey"] ?? string.Empty;
            string apiUrl = _configuration["UrlSendGrid"] ?? string.Empty;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
            client.DefaultRequestHeaders.Add("Accept", $"application/json");

            string emailContent = JsonConvert.SerializeObject(model);

            var response = await client.PostAsync (apiUrl, new StringContent(emailContent, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode) 
            {
                return true;
            }
            return false;

        }
    }
}
