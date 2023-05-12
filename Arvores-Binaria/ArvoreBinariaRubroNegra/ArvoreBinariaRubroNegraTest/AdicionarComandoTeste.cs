using ArvoceBinariaRubroNegra;
using Utils;

namespace ArvoceBinariaRubroNegraTest;

public class AdicionarComandoTeste
{
    [Fact]
    public void AdicionarComando_InicializandoArvore_Sucesso()
    {
        //Arrange
        var comando = new AdicionarComando();
        var valor = 50;

        //Act
        var result = comando.Executar(default, valor);

        //Assert
        Assert.Equal(valor, result?.Valor);
        Assert.Equal(Tipo.Raiz, result?.Tipo);
        Assert.Equal(Tipo.Nulo, result?.Esquerdo?.Tipo);
        Assert.Equal(Tipo.Nulo, result?.Direito?.Tipo);
    }

    [Fact]
    public void AdicionarComando_InicializandoArvoreFilhoEsquerdo_Sucesso()
    {
        //Arrange
        var comando = new AdicionarComando();
        No no = new()
        {
            Valor = 50,
            Tipo = Tipo.Raiz,
            Direito = BaseComando.NoNulo,
            Esquerdo = BaseComando.NoNulo,
        };
        var valor = 25;

        ImprimeSaida.Imprimir(no);

        //Act
        var result = comando.Executar(no, valor);

        ImprimeSaida.Imprimir(result);

        //Assert
        Assert.Equal(valor, result?.Esquerdo?.Valor);
        Assert.Equal(Tipo.Vermelho, result?.Esquerdo?.Tipo);
        Assert.Equal(Tipo.Nulo, result?.Esquerdo?.Direito?.Tipo);
        Assert.Equal(Tipo.Nulo, result?.Esquerdo?.Esquerdo?.Tipo);
        Assert.Equal(Tipo.Nulo, result?.Direito?.Tipo);
    }
}