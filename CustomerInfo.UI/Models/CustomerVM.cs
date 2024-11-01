using CustomerInfo.UI.Enums;
using System.ComponentModel.DataAnnotations;

namespace CustomerInfo.UI.Models
{
    public class CustomerVM
    {
        public string Id { get; set; }
        public string NameSurname { get; set; }

        public string Address { get; set; }

        public int Price { get; set; }
        public string FiltreType { get; set; }
        public string Note { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

        public DateTime InstallationDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

        public DateTime FiltreDegisimTarihi { get; set; }
    }
}
