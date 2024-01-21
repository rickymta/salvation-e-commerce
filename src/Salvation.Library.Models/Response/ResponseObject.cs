namespace Salvation.Library.Models.Response
{
    public class ResponseObject
    {
        public int Code { get; set; }

        public string? Message { get; set; }

        public object? Data { get; set; }
    }

    public class ResponseObject<T>
    {
        public int Code { get; set; }

        public string? Message { get; set; }

        public T? Data { get; set; }
    }
}
