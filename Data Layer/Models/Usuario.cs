using System;
using System.Collections.Generic;

namespace Data_Layer.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombres { get; set; }

    public string? Apellido { get; set; }

    public int? NumeroEmpleado { get; set; }

    public string? Contrasena { get; set; }

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
