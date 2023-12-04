using System;
using System.Collections.Generic;

namespace webAPI.Models;

/// <summary>
/// testitaulu
/// </summary>
public partial class Testitaulu
{
    public int? PersonId { get; set; }

    public string? Etunimi { get; set; }

    public string? Sukunimi { get; set; }

    public int? Age { get; set; }
}
