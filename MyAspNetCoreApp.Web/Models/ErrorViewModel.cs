namespace MyAspNetCoreApp.Web.Models
{
    public class ErrorViewModel
    {
        public List<String>Errors { get; set; }
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

}