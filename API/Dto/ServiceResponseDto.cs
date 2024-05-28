namespace API.Dto
{
    public class ServiceResponseDto
    {
        public object? Data { get; set; }
        public bool ISuccess { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
