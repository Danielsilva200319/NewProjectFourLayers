using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Persontype
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Costumer> Costumers { get; set; } = new List<Costumer>();
}
