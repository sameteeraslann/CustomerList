using System.ComponentModel.DataAnnotations;

namespace CustomerInfo.UI.Models
{
    public class CustomerVM
    {
        [Required(ErrorMessage = "İsim ve soyisim gereklidir.")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "Adres gereklidir.")]
        public string Address { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Fiyat sıfırdan büyük olmalıdır.")]
        public int Price { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //[RegularExpression(@"\d{2}/\d{2}/\d{4}", ErrorMessage = "Geçersiz tarih formatı. Lütfen dd/MM/yyyy formatında girin.")]

        public DateTime InstallationDate { get; set; }
    }
}
