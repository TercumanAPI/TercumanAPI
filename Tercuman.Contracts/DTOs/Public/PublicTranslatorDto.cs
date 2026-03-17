
namespace Tercuman.Contracts.DTOs.Public
{
    public class PublicTranslatorDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? City { get; set; }
        public string? Bio { get; set; }
        public string? ProfileImage { get; set; }
        public bool IsAvailable { get; set; }
        public List<string> Languages { get; set; } = new();
    }
}