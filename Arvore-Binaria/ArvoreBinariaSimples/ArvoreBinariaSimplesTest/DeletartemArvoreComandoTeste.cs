using ArvoreBinariaSimples;
namespace ArvoreBinariaSimplesTest;

public class DeletartemArvoreComandoTeste
{
    [Fact]
    public void DeletartemArvoreComandoTeste_DeletandoNoArvoreVazia_Sucesso()
    {
        //Arrange
        var comando = new DeletartemArvoreComando();
        var valor = 50;

        //Act
        var result = comando.Executar(default, valor);

        //Assert
        Assert.Null(result?.Valor);
    }
}