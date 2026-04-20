using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tercuman.Mobile.Features.Home.Models
{
    public class TranslatorModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string ProfileImage { get; set; }
        public string NativeLanguage { get; set; }
        public string TargetLanguages { get; set; }
        public double Rating { get; set; }
        public string ExperienceLevel { get; set; }
        public string City { get; set; }
        public bool IsVerified { get; set; }
    }
}
