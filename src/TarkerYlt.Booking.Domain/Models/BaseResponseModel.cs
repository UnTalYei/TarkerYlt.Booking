namespace TarkerYlt.Booking.Domain.Models
{
    public class BaseResponseModel
    {
        public int StatusCode { get; set; } //Codigo de estado
        public bool Success { get; set; } //Si se ejecuto o no
        public string Message { get; set; }
        public dynamic Data { get; set; } //setear cualquier dato, puedo acceder a propiedades sin necesidad de instanciar
    }
}
