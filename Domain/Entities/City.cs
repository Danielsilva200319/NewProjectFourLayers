using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class City : BaseEntity
{
    public string Name { get; set; } = null!;

    public int IdStateFk { get; set; }

    public virtual ICollection<Costumer> Costumers { get; set; } = new List<Costumer>();

    public virtual State IdStateFkNavigation { get; set; } = null!;
}
