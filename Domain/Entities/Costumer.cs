using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Costumer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string IdCustomer { get; set; } = null!;

    public int IdPersonTypeFk { get; set; }

    public DateOnly DateRegister { get; set; }

    public int IdCityFk { get; set; }

    public virtual City IdCityFkNavigation { get; set; } = null!;

    public virtual Persontype IdPersonTypeFkNavigation { get; set; } = null!;
}
