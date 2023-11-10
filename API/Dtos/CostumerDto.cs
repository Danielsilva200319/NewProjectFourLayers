using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class CostumerDto : BaseDto
    {
        public string Name { get; set; } = null!;

        public string IdCustomer { get; set; } = null!;

        public int IdPersonTypeFk { get; set; }

        public DateOnly DateRegister { get; set; }

        public int IdCityFk { get; set; }
    }
}