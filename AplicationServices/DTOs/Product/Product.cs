using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationServices.DTOs.Product
{
        public class ProductDto
        {
            public Guid ID { get; set; }
            public string Description { get; set; } = null!;
            public string Code { get; set; } = null!;
            public bool Estado { get; set; }
        }

        public class CreateProductDto
        {
            public string Description { get; set; } = null!;
            public string Code { get; set; } = null!;
            public bool Estado { get; set; }
        }
}
