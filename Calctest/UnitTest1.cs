using TDDeTestesUnitarios;

namespace Calctest //Calctest;
{
    public class UnitTest1
    {
        private Calculator _calc;

        public UnitTest1()
        {
            _calc = new Calculator();
        }

        [Fact] // Teste unitário.
        public void TestSomar2()
        {
            int result = _calc.Somar(1, 2);
            Assert.Equal(3, result);
        }

        [Theory] // testa várias hipóteses. Várias InlineData com valores diversos.
        [InlineData(1, 2, 3)]
        [InlineData(4, 5, 9)] 
        [InlineData(8, 7, 15)]
        public void TestSomar(int val1, int val2, int valreal)
        {
            int result = _calc.Somar(val1, val2);
            Assert.Equal(valreal, result);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(4, 5, 20)]
        [InlineData(1, 3, 3)]
        public void TestMultiplicar(int val1, int val2, int valreal)
        {
            int result = _calc.Multiplicar(val1, val2);

            Assert.Equal(valreal, result);
        }

        [Theory]
        [InlineData(5, 2, 3)]
        [InlineData(7, 5, 2)]
        [InlineData(4, 5, -1)]
        public void TestSubtrair(int val1, int val2, int valreal)
        {
            int result = _calc.Subtrair(val1, val2);

            Assert.Equal(valreal, result);
        }

        [Theory]
        [InlineData(10, 2, 5)]
        [InlineData(12, 4, 3)]
        [InlineData(21, 3, 7)]
        public void TestDividir(int val1, int val2, int valreal)
        {
            int result = _calc.Dividir(val1, val2);

            Assert.Equal(valreal, result);
        }

        [Fact]
        public void TestarDivisaoPorZero()
        {
            Assert.Throws<DivideByZeroException>(() => _calc.Dividir(3, 0));
        }

        [Fact]
        public void TestarHistorico()
        {
            _calc.Somar(1, 2);
            _calc.Somar(3, 5);
            _calc.Somar(4, 7);
            _calc.Somar(8, 6);

            var lista = _calc.Historico();

            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);
        }

    }
}