using System.ComponentModel.DataAnnotations;

namespace MoneyKeeper.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}