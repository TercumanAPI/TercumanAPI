namespace Tercuman.Admin.Models
{
    public class ApiResponse<T>
    {
        public List<T> data { get; set; }
        public int totalCount { get; set; }
    }
}
