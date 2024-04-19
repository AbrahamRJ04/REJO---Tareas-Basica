namespace QA___Catalogo
{
    [TestClass]
    public class QA___Tarea
    {
        [TestMethod]
        public void Tarea_GetAll()
        {
            Model_Layer.Result result = Bussiness_Layer.BL_Tareas.GetAll();
            Assert.IsTrue(result.Correct);

        }

        [TestMethod]
        public void Tarea_GetById()
        {
            int IdTarea = 4;
            Model_Layer.Result result = Bussiness_Layer.BL_Tareas.GetById(IdTarea);
            Assert.IsTrue(result.Correct);

        }

        [TestMethod]
        public void Tarea_Insert()
        {

            Model_Layer.Tareas task =  new Model_Layer.Tareas();
            task.Cat_Estatus = new Model_Layer.Cat_Estatus();
            task.Usuario = new Model_Layer.Usuario();

            task.Cat_Estatus.IdEstatus = 4;
            task.Descripcion = "Realizacion de Prueba Unitaria";
            task.Usuario.IdUsuario = 1;

            Model_Layer.Result result = Bussiness_Layer.BL_Tareas.Insert(task);
            Assert.IsTrue(result.Correct);

        }

        [TestMethod]
        public void Tarea_Update()
        {

            Model_Layer.Tareas task = new Model_Layer.Tareas();
            task.Cat_Estatus = new Model_Layer.Cat_Estatus();
            task.Usuario = new Model_Layer.Usuario();

            task.IdTarea = 6;
            task.Cat_Estatus.IdEstatus = 1;
            task.Descripcion = "Ejecutar Pruebas Unitarias1";
            task.Usuario.IdUsuario = 1;

            Model_Layer.Result result = Bussiness_Layer.BL_Tareas.Update(task);
            Assert.IsTrue(result.Correct);

        }
    }
}
