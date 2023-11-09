using System;
using System.Collections.Generic;
namespace Domain.Entities;

public partial class PersonType : BaseEntity
{
    public string Name { get; set; } = null!;

    public virtual ICollection<Costumer> Costumers { get; set; } = new List<Costumer>();
}
