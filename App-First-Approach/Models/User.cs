﻿using System;
using System.Collections.Generic;

namespace App_First_Approach.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string? CardNumber { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Basket> Baskets { get; } = new List<Basket>();
}
