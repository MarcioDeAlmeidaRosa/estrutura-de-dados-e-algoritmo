using ArvoceBinariaRubroNegra;

namespace ArvoceBinariaRubroNegraTest;

public class AdicionarItemComandoTeste
{
    [Fact]
    public void AdicionarItemComandoTeste_InicializandoArvore_Sucesso()
    {
        //Arrange
        var comando = new AdicionarComando();
        var valor = 50;

        //Act
        var result = comando.Executar(default, valor);

        //Assert
        Assert.Equal(valor, result?.Valor);
        Assert.Equal(Tipo.Raiz, result?.Tipo);
    }
}