using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationServices.DTOs.Currency
{
    public class GetCurrenciesDTO
    {
        public Guid IdDto { get; set; }
        public string DescriptionDto { get; set; }
        public string CodeDto { get; set; }
    }
}
