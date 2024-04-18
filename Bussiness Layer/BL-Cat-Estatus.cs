using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    public class BL_Cat_Estatus
    {
        public static Model_Layer.Result GetAll()
        {
            Model_Layer.Result result = new Model_Layer.Result();

            try
            {
                using (Data_Layer.Models.TaskProyectContext context = new Data_Layer.Models.TaskProyectContext())
                {
                    var query = context.CatEstatuses.FromSqlRaw($"GET_Cat_Estatus").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            Model_Layer.Cat_Estatus cat = new Model_Layer.Cat_Estatus();

                            cat.IdEstatus = item.IdEstatus;
                            cat.Nombre_Estatus = item.NombreEstatos;

                            result.Objects.Add(cat);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "El catalogo de estatus se encuentra vacia por el momento";
                    }

                }

            }catch (Exception ex)
            {
                result.Correct = false;
                result.exception = ex;
                result.ErrorMessage = "Ocurrio un error al realizar la operacion de busqueda de Catalogo: " + ex.Message;
            }

            return result;
        }
    }
}
