namespace QA___Catalogo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Model_Layer.Result result = Bussiness_Layer.BL_Cat_Estatus.GetAll();
            Assert.IsTrue(result.Correct);

        }
    }
}