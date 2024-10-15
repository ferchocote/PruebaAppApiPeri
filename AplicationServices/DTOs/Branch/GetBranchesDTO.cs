using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationServices.DTOs.Branch
{
    public class GetBranchesDTO
    {
        public Guid IdDto { get; set; }
        public int CodeDto { get; set; }
        public string DescriptionDto { get; set; }
        public string AddressDto { get; set; }
        public string IdentificationDto { get; set; }
        public DateTime CreationDateDto { get; set; }
        public Guid IdCurrencyDto { get; set; }
        public string CurrencyDescriptionDto { get; set; }
    }
}
