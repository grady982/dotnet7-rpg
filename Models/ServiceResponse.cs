namespace dotnet_rpg.Models
{

    // T => the actual type of data we want to return
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }

        public bool Success { get; set; } = true;

        public string Message { get; set; } = string.Empty;
    }
}