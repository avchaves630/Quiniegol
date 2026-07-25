using ClassExampleController;

namespace ClassExampleControllerTest
{
    /// <summary>
    /// Test class for <see cref="ClassExampleController.Examples"/>.
    /// </summary>
    [TestClass]
    public class ExamplesTest
    {
        /// <summary>
        /// Characters the count should return correct count.
        /// </summary>
        [TestMethod]
        public void CharCountShouldReturnCorrectCount()
        {
            // AAA  => Arrange, Act, Assert.
            // BDD  => behavioral driven development. Given , when , then.
            // Arrange => Given
            // precondiciones para ejecutar una accion
            var input = "conectividad";  // => c => 2 ; o => 1 ; n => 1 ; e => 1 ; t => 1 ; i => 2 ; v => 1 ; d => 2 ; a => 1 
            var examples = new Examples();

            // Act => When
            // Ejecuto la accion que quiero probar. => el metodo que quiero probar.
            var result = examples.CharCount(input);

            // Assert => Then
            // valido el comportamiento esperado. => el resultado que espero obtener.
            Assert.IsNotNull(result);
            Assert.AreEqual(9, result.Count);
            Assert.IsTrue(result.ContainsKey('c'));
            Assert.AreEqual(2, result['c']);
            Assert.IsTrue(result.ContainsKey('o'));
            Assert.AreEqual(1, result['o']);
            Assert.IsTrue(result.ContainsKey('n'));
            Assert.AreEqual(1, result['n']);
            Assert.AreEqual(1, result['e']);
            Assert.AreEqual(1, result['t']);
            Assert.AreEqual(2, result['i']);
            Assert.AreEqual(1, result['v']);
            Assert.AreEqual(2, result['d']);
            Assert.AreEqual(1, result['a']);
        }
    }
}
