namespace Mango.Services.CouponAPI.Models.Dto
{
    public class ResponseDto
    {
        /// <summary>
        /// Result
        /// </summary>
        public object? Result {  get; set; }

        /// <summary>
        /// IsSuccess 
        /// </summary>
        public bool IsSuccess { get; set; } = true;

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; } = "";

    }
}
