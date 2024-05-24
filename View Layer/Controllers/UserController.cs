using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace View_Layer.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            Model_Layer.Result result = Bussiness_Layer.BL_Usuarios.GetAll();
            if (result.Correct)
            {
                Model_Layer.Usuario user = new Model_Layer.Usuario();
                user.Usuarios = result.Objects;
                return View(user);
            }
            else
            {
                ViewBag.Mensaje = "Ocurrio un error al realizar la operacion";
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int IdUsuario)
        {
            Model_Layer.Result result = Bussiness_Layer.BL_Usuarios.Delete(IdUsuario);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Registro eliminado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "Ocurrio un error al eliminar el registro: " + result.ErrorMessage;
            }
            return PartialView("Index");
        }

        [HttpGet]
        public IActionResult Form(int? IdUsuario)
        {

            Model_Layer.Usuario user = new Model_Layer.Usuario();

            if (IdUsuario == null)
            {
                return View(user);
            }
            else
            {
                Model_Layer.Result result = Bussiness_Layer.BL_Usuarios.GetById(IdUsuario.Value);
                if (result.Correct)
                {
                    user = (Model_Layer.Usuario)result.Object;
                    
                    return View(user);
                }
                else
                {
                    return PartialView("Index");
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Form(Model_Layer.Usuario user)
        {
            Model_Layer.Result result = new Model_Layer.Result();

            if (user.IdUsuario == 0)
            {
                result = Bussiness_Layer.BL_Usuarios.Insert(user);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Registro correcto";
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un error al inserta el registro";
                }
            }
            else
            {
                result = Bussiness_Layer.BL_Usuarios.Update(user);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Alumno actualizado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un error al actualizar el equipo";
                }
            }
            return PartialView("Index");
        }



    }
}
