namespace LoginJWT.Services.CouponAPI.Models.DTO
{
    public class ResponseDTO
    {
        public object? Result { get; set; }
        public bool isSuccess { get; set; } = true;
        public string Message { get; set; }
    }
}
