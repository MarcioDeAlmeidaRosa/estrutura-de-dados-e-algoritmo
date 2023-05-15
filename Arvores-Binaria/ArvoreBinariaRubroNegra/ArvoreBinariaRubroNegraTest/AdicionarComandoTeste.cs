using ArvoceBinariaRubroNegra;
using Utils;

namespace ArvoceBinariaRubroNegraTest;

public class AdicionarComandoTeste
{
    [Fact]
    public void AdicionarComando_InicializandoArvore()
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
    public void AdicionarComando_InicializandoArvoreFilhoEsquerdo()
    {
        //Arrange
        var comando = new AdicionarComando();
        No no = BaseComando.CriarNovoNo(Tipo.Raiz, 50, default);
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
    public void AdicionarComando_InicializandoArvoreFilhoDireito()
    {
        //Arrange
        var comando = new AdicionarComando();
        No no = BaseComando.CriarNovoNo(Tipo.Raiz, 50, default);
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
    public void AdicionarComando_InicializandoArvoreFilhoDireitoJaComFilhoEsquerdo()
    {
        //Arrange
        var comando = new AdicionarComando();
        No no = BaseComando.CriarNovoNo(Tipo.Raiz, 50, default);
        no.Esquerdo = BaseComando.CriarNovoNo(Tipo.Vermelho, 25, no.Valor);

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
    public void AdicionarComando_ArvoreFilhosDireitoEsquerdoVermelhoAdicionandoNovoEsquerdo()
    {
        //Arrange
        var comando = new AdicionarComando();
        No no = BaseComando.CriarNovoNo(Tipo.Raiz, 23, default);
        no.Esquerdo = BaseComando.CriarNovoNo(Tipo.Vermelho, 12, no.Valor);
        no.Direito = BaseComando.CriarNovoNo(Tipo.Vermelho, 37, no.Valor);

        var valor = 5;

        ImprimeSaida.Imprimir(no);

        //Act
        var result = comando.Executar(no, valor);

        ImprimeSaida.Imprimir(result);

        //Assert
        Assert.Equal(valor, result.Esquerdo.Esquerdo.Valor);
        Assert.Equal(Tipo.Raiz, result.Tipo);
        Assert.Equal(Tipo.Preto, result.Direito.Tipo);
        Assert.Equal(Tipo.Nulo, result.Direito.Direito.Tipo);
        Assert.Equal(Tipo.Nulo, result.Direito.Esquerdo.Tipo);
        Assert.Equal(Tipo.Preto, result.Esquerdo.Tipo);
        Assert.Equal(Tipo.Nulo, result.Esquerdo.Direito.Tipo);
        Assert.Equal(Tipo.Vermelho, result.Esquerdo.Esquerdo.Tipo);
        Assert.Equal(Tipo.Nulo, result.Esquerdo.Esquerdo.Esquerdo.Tipo);
        Assert.Equal(Tipo.Nulo, result.Esquerdo.Esquerdo.Direito.Tipo);
    }

    [Fact]
    public void AdicionarComando_ArvoreFilhosDireitoEsquerdoVermelhoAdicionandoNovoEsquerdo_Caso2()
    {
        //Arrange
        var comando = new AdicionarComando();
        No no = BaseComando.CriarNovoNo(Tipo.Raiz, 23, default);
        no.Esquerdo = BaseComando.CriarNovoNo(Tipo.Preto, 12, no.Valor);
        no.Esquerdo.Esquerdo = BaseComando.CriarNovoNo(Tipo.Vermelho, 6, no.Esquerdo.Valor);
        no.Esquerdo.Direito = BaseComando.CriarNovoNo(Tipo.Vermelho, 18, no.Esquerdo.Valor);
        no.Direito = BaseComando.CriarNovoNo(Tipo.Preto, 37, no.Valor);
        no.Direito.Esquerdo = BaseComando.CriarNovoNo(Tipo.Vermelho, 32, no.Direito.Valor);
        no.Direito.Direito = BaseComando.CriarNovoNo(Tipo.Vermelho, 48, no.Direito.Valor);

        var valor = 14;

        ImprimeSaida.Imprimir(no);

        //Act
        var result = comando.Executar(no, valor);

        ImprimeSaida.Imprimir(result);

        //Assert
        Assert.Equal(Tipo.Raiz, result.Tipo);

        Assert.Equal(Tipo.Preto, result.Direito.Tipo);

        Assert.Equal(Tipo.Vermelho, result.Direito.Direito.Tipo);
        Assert.Equal(Tipo.Nulo, result.Direito.Direito.Direito.Tipo);
        Assert.Equal(Tipo.Nulo, result.Direito.Direito.Esquerdo.Tipo);

        Assert.Equal(Tipo.Vermelho, result.Direito.Esquerdo.Tipo);
        Assert.Equal(Tipo.Nulo, result.Direito.Esquerdo.Direito.Tipo);
        Assert.Equal(Tipo.Nulo, result.Direito.Esquerdo.Esquerdo.Tipo);

        Assert.Equal(Tipo.Vermelho, result.Esquerdo.Tipo);

        Assert.Equal(Tipo.Preto, result.Esquerdo.Esquerdo.Tipo);

        Assert.Equal(Tipo.Preto, result.Esquerdo.Direito.Tipo);
        Assert.Equal(Tipo.Nulo, result.Esquerdo.Direito.Direito.Tipo);

        Assert.Equal(Tipo.Vermelho, result.Esquerdo.Direito.Esquerdo.Tipo);
        Assert.Equal(valor, result.Esquerdo.Direito.Esquerdo.Valor);
    }

    [Fact]
    public void AdicionarComando_ArvoreFilhoEsquerdoVermelhoComSeuFilhoDireitoVermelhor()
    {
        //Arrange
        var comando = new AdicionarComando();
        No no = BaseComando.CriarNovoNo(Tipo.Raiz, 23, default);
        no.Esquerdo = BaseComando.CriarNovoNo(Tipo.Vermelho, 12, no.Valor);
        no.Esquerdo.Esquerdo = BaseComando.CriarNovoNo(Tipo.Preto, 6, no.Esquerdo.Valor);
        no.Esquerdo.Direito = BaseComando.CriarNovoNo(Tipo.Preto, 18, no.Esquerdo.Valor);
        no.Esquerdo.Direito.Esquerdo = BaseComando.CriarNovoNo(Tipo.Vermelho, 14, no.Esquerdo.Direito.Valor);
        no.Direito = BaseComando.CriarNovoNo(Tipo.Preto, 37, no.Valor);
        no.Direito.Esquerdo = BaseComando.CriarNovoNo(Tipo.Vermelho, 32, no.Direito.Valor);
        no.Direito.Direito = BaseComando.CriarNovoNo(Tipo.Vermelho, 48, no.Direito.Valor);

        var valor = 15;

        ImprimeSaida.Imprimir(no);

        //Act
        var result = comando.Executar(no, valor);

        ImprimeSaida.Imprimir(result);

        //Assert
        Assert.Equal(Tipo.Raiz, result.Tipo);

        Assert.Equal(Tipo.Preto, result.Direito.Tipo);

        Assert.Equal(Tipo.Vermelho, result.Direito.Direito.Tipo);
        Assert.Equal(Tipo.Nulo, result.Direito.Direito.Direito.Tipo);
        Assert.Equal(Tipo.Nulo, result.Direito.Direito.Esquerdo.Tipo);

        Assert.Equal(Tipo.Vermelho, result.Direito.Esquerdo.Tipo);
        Assert.Equal(Tipo.Nulo, result.Direito.Esquerdo.Direito.Tipo);
        Assert.Equal(Tipo.Nulo, result.Direito.Esquerdo.Esquerdo.Tipo);

        Assert.Equal(Tipo.Vermelho, result.Esquerdo.Tipo);

        Assert.Equal(Tipo.Preto, result.Esquerdo.Esquerdo.Tipo);

        Assert.Equal(Tipo.Preto, result.Esquerdo.Direito.Tipo);
        Assert.Equal(Tipo.Nulo, result.Esquerdo.Direito.Direito.Tipo);

        Assert.Equal(Tipo.Vermelho, result.Esquerdo.Direito.Esquerdo.Tipo);

        Assert.Equal(Tipo.Vermelho, result.Esquerdo.Direito.Esquerdo.Esquerdo.Tipo);
        Assert.Equal(valor, result.Esquerdo.Direito.Esquerdo.Valor);
    }
}