namespace ShoppingWebAPI.Model
{
    public class ApiResponse
    {
        public string code { get; set; }
        public string Message { get; set; }
        public object? ResponseData { get; set; }
    }
    public enum ResponseType
    {
        Success,
        NotFound,
        Failure,
        Error

    }



}
