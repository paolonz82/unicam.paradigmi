using Unicam.Paradigmi.Application.Models.Responses;

namespace Unicam.Paradigmi.Application.Factories
{
    public class ResponseFactory
    {
        public static BaseResponse<T> WithSuccess<T>(T result)
        {
            var response = new BaseResponse<T>();
            response.Success = true;
            response.Result = result;
            return response;
        }

        public static BaseResponse<T> WithError<T>(T result)
        {
            var response = new BaseResponse<T>();
            response.Success = false;
            response.Result = result;
            return response;
        }

        public static BaseResponse<string?> WithError(Exception exception)
        {
            var response = new BaseResponse<string>();
            response.Success = false;
            response.Errors = new List<string>()
            {
                exception.Message
            };
            return response;
        }
    }
}
