using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdStateFk { get; set; }

    public virtual ICollection<Costumer> Costumers { get; set; } = new List<Costumer>();

    public virtual State IdStateFkNavigation { get; set; } = null!;
}
