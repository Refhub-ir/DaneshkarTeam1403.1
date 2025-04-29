using System.ComponentModel.DataAnnotations;

namespace Refhub_Ir.Models.Keyword
{
    public class CreateKeywordVM
    {
        [Required(ErrorMessage = "لطفا کلمه کلیدی را وارد کنید.")]
        public string Word { get; set; }
    }
}
