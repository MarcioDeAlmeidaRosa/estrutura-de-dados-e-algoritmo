using ArvoreBinariaSimples;
namespace ArvoreBinariaSimplesTest;

public class UnitTest1
{
    [Fact]
    public void AdicionandoNoRaizComSucesso()
    {
        //Arrange
        var comando = new AdicionarNovoItemArvoreComando();


        //Act
        var result = comando.Executar(new No());

        //Assert

    }
}