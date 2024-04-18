using System;
using System.Collections.Generic;

namespace Data_Layer.Models;

public partial class Tarea
{
    public int IdTarea { get; set; }

    public int? IdEstatus { get; set; }

    public string? Descripcion { get; set; }

    public int? IdUsuario { get; set; }

    public virtual CatEstatus? IdEstatusNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
