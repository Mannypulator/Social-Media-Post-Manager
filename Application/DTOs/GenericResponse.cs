namespace Application.DTOs
{
    public class GenericResponse<T>
    {
        public string ResponseCode { get; set; }
        public string ResponseMsg { get; set; }
        public T ResponseDetails { get; set; }

        public static GenericResponse<T> Success(string responseMsg, T responseDetails)
        {
            return new GenericResponse<T>
            {
                ResponseCode = "00",
                ResponseMsg = responseMsg,
                ResponseDetails = responseDetails
            };
        }

        public static GenericResponse<T> Failure(string responseCode, string responseMsg, T responseDetails)
        {
            return new GenericResponse<T>
            {
                ResponseCode = responseCode,
                ResponseMsg = responseMsg,
                ResponseDetails = responseDetails
            };
        }
    }
}