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
        Assert.Equal(valor, result.Valor);
        Assert.Equal(Tipo.Raiz, result.Tipo);
        Assert.Equal(Tipo.Nulo, result.Esquerdo.Tipo);
        Assert.Equal(Tipo.Nulo, result.Direito.Tipo);
    }

    [Fact]
    public void AdicionarComando_InicializandoArvoreFilhoEsquerdo_Sucesso()
    {
        //Arrange
        var comando = new AdicionarComando();
        No no = BaseComando.CriarNovoNo(Tipo.Raiz, 50);
        var valor = 25;

        ImprimeSaida.Imprimir(no);

        //Act
        var result = comando.Executar(no, valor);

        ImprimeSaida.Imprimir(result);

        //Assert
        Assert.Equal(valor, result.Esquerdo.Valor);
        Assert.Equal(Tipo.Vermelho, result.Esquerdo.Tipo);
        Assert.Equal(Tipo.Nulo, result.Esquerdo.Direito.Tipo);
        Assert.Equal(Tipo.Nulo, result.Esquerdo.Esquerdo.Tipo);
        Assert.Equal(Tipo.Nulo, result.Direito.Tipo);
    }

    [Fact]
    public void AdicionarComando_InicializandoArvoreFilhoDireito_Sucesso()
    {
        //Arrange
        var comando = new AdicionarComando();
        No no = BaseComando.CriarNovoNo(Tipo.Raiz, 50);
        var valor = 75;

        ImprimeSaida.Imprimir(no);

        //Act
        var result = comando.Executar(no, valor);

        ImprimeSaida.Imprimir(result);

        //Assert
        Assert.Equal(valor, result.Direito.Valor);
        Assert.Equal(Tipo.Vermelho, result.Direito.Tipo);
        Assert.Equal(Tipo.Nulo, result.Direito.Direito.Tipo);
        Assert.Equal(Tipo.Nulo, result.Direito.Esquerdo.Tipo);
        Assert.Equal(Tipo.Nulo, result.Esquerdo.Tipo);
    }

    [Fact]
    public void AdicionarComando_InicializandoArvoreFilhoDireitoJaComFilhoEsquerdo_Sucesso()
    {
        //Arrange
        var comando = new AdicionarComando();
        No no = BaseComando.CriarNovoNo(Tipo.Raiz, 50);
        no.Esquerdo = BaseComando.CriarNovoNo(Tipo.Vermelho, 25);

        var valor = 75;

        ImprimeSaida.Imprimir(no);

        //Act
        var result = comando.Executar(no, valor);

        ImprimeSaida.Imprimir(result);

        //Assert
        Assert.Equal(valor, result.Direito.Valor);
        Assert.Equal(Tipo.Vermelho, result.Direito.Tipo);
        Assert.Equal(Tipo.Nulo, result.Direito.Direito.Tipo);
        Assert.Equal(Tipo.Nulo, result.Direito.Esquerdo.Tipo);
        Assert.Equal(Tipo.Vermelho, result.Esquerdo.Tipo);
        Assert.Equal(Tipo.Nulo, result.Esquerdo.Direito.Tipo);
        Assert.Equal(Tipo.Nulo, result.Esquerdo.Esquerdo.Tipo);
    }

    [Fact]
    public void AdicionarComando_ArvoreFilhosDireitoEsquerdoVermelhoAdicionandoNovoEsquerdo_Sucesso()
    {
        //Arrange
        var comando = new AdicionarComando();
        No no = BaseComando.CriarNovoNo(Tipo.Raiz, 23);
        no.Esquerdo = BaseComando.CriarNovoNo(Tipo.Vermelho, 12);
        no.Direito = BaseComando.CriarNovoNo(Tipo.Vermelho, 37);

        var valor = 5;

        ImprimeSaida.Imprimir(no);

        //Act
        var result = comando.Executar(no, valor);

        ImprimeSaida.Imprimir(result);

        //Assert
        Assert.Equal(valor, result.Esquerdo.Esquerdo.Valor);
        Assert.Equal(Tipo.Raiz, result.Tipo);
        Assert.Equal(Tipo.Preto, result.Direito.Tipo);
        Assert.Equal(Tipo.Nulo, result.Direito.Direito?.Tipo);
        Assert.Equal(Tipo.Nulo, result.Direito.Esquerdo?.Tipo);
        Assert.Equal(Tipo.Preto, result.Esquerdo.Tipo);
        Assert.Equal(Tipo.Nulo, result.Esquerdo.Direito?.Tipo);
        Assert.Equal(Tipo.Vermelho, result.Esquerdo.Esquerdo.Tipo);
        Assert.Equal(Tipo.Nulo, result.Esquerdo.Esquerdo.Esquerdo.Tipo);
        Assert.Equal(Tipo.Nulo, result.Esquerdo.Esquerdo.Direito.Tipo);
    }
}