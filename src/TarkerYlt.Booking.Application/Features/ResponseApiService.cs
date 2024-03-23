﻿using TarkerYlt.Booking.Domain.Models;

namespace TarkerYlt.Booking.Application.Features
{
    public static class  ResponseApiService //Static para no tener necesidad de instanciar metodos o la clase
    {
        public static BaseResponseModel Response(
            int statusCode, string message = null, dynamic data = null)
        {
            bool success = false; 

            if (statusCode >= 200 && statusCode < 300)
                success = true;

            var result = new BaseResponseModel
            {
                StatusCode = statusCode,
                Success = success,
                Message = message,
                Data = data
            };
            return result;
        }
    }
}
