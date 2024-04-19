using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_Layer
{
    public class Tareas
    {
        public int IdTarea { get; set; }
        public string Descripcion { get; set; }
        public Model_Layer.Cat_Estatus Cat_Estatus { get; set; }
        public Model_Layer.Usuario Usuario { get; set; }

    }
}
