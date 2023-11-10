using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class CityDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public int IdStateFk { get; set; }
    }
}