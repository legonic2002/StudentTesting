namespace ShoppingWebAPI.Model
{
    public class ResponseHandler
    {
        public static ApiResponse GetExceptionResponse(Exception ex)
        {
            ApiResponse response = new ApiResponse();
            response.code = "1";
            response.Message = ex.Message;
            
            return response;
        }
        public static ApiResponse GetAppResponse(ResponseType type, object? contract)
        {

            ApiResponse response;
            response = new ApiResponse { ResponseData = contract };
            switch (type)
            {
                case ResponseType.Success:
                    response.code = "0";
                    response.Message = "Success";
                    break;
                case ResponseType.NotFound:
                    response.code = "2";
                    response.Message = "No record Avaiable";
                    break;
                case ResponseType.Error:
                    response.code = "3";
                    response.Message = "Some field is empty";
                    break;
            }

            return response;
        }


    }
}
