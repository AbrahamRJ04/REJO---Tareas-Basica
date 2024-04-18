using System;
using System.Collections.Generic;

namespace Data_Layer.Models;

public partial class CatEstatus
{
    public int IdEstatus { get; set; }

    public string? NombreEstatos { get; set; }

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
