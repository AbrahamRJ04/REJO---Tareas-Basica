namespace QA___Catalogo
{
    [TestClass]
    public class QA___Usuario
    {
        [TestMethod]
        public void Usuario_GetAll()
        {
            Model_Layer.Result result = Bussiness_Layer.BL_Usuarios.GetAll();
            Assert.IsTrue(result.Correct);

        }

        [TestMethod]
        public void Usuario_GetById()
        {
            int IdUsuario = 1;

            Model_Layer.Result result = Bussiness_Layer.BL_Usuarios.GetById(IdUsuario);
            Assert.IsTrue(result.Correct);

        }

        [TestMethod]
        public void Usuario_Insert()
        {
            Model_Layer.Usuario user = new Model_Layer.Usuario();

            user.Nombres = "Prueba Usuario";
            user.Apellidos = "Apellido Usuario";
            user.NumeroEmpleado = 132092;
            user.Contraseña = "Contraseña123";

            Model_Layer.Result result = Bussiness_Layer.BL_Usuarios.Insert(user);
            Assert.IsTrue(result.Correct);
        }

        [TestMethod]
        public void Usuario_Update()
        {
            Model_Layer.Usuario user = new Model_Layer.Usuario();

            user.IdUsuario = 2;
            user.Nombres = "Actualizacion Usuario";
            user.Apellidos = "Actualizacion Usuario";
            user.NumeroEmpleado = 132092;
            user.Contraseña = "Contraseña456";

            Model_Layer.Result result = Bussiness_Layer.BL_Usuarios.Update(user);
            Assert.IsTrue(result.Correct);
        }

        [TestMethod]
        public void Usuario_Delete()
        {
            int IdUsuario = 2;

            Model_Layer.Result result = Bussiness_Layer.BL_Usuarios.Delete(IdUsuario);
            Assert.IsTrue(result.Correct);
        }
    }
}
//Si se decea ejecutar las pruebas unitarias, de los metodos de Insert Update y Delete, modificar los parametros de entrada 
//que se encuentran por default en estas pruebas.