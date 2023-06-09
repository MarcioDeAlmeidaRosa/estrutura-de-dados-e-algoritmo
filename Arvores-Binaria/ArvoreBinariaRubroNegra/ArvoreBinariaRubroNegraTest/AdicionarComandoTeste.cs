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
        Assert.Equal(no.Valor, result.Esquerdo.ValorPai);
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
        no.Esquerdo = BaseComando.CriarNovoNo(Tipo.Vermelho, 25, no);

        var valor = 75;

        ImprimeSaida.Imprimir(no);

        //Act
        var result = comando.Executar(no, valor);

        ImprimeSaida.Imprimir(result);

        //Assert
        Assert.Equal(valor, result.Direito.Valor);
        Assert.Equal(no.Valor, result.Direito.ValorPai);
        Assert.Equal(Tipo.Vermelho, result.Direito.Tipo);
        Assert.Equal(Tipo.Nulo, result.Direito.Direito.Tipo);
        Assert.Equal(Tipo.Nulo, result.Direito.Esquerdo.Tipo);
        Assert.Equal(Tipo.Vermelho, result.Esquerdo.Tipo);
        Assert.Equal(Tipo.Nulo, result.Esquerdo.Direito.Tipo);
        Assert.Equal(Tipo.Nulo, result.Esquerdo.Esquerdo.Tipo);
    }

    [Fact]
    public void AdicionarComando_Caso_1_Situacao_1()
    {
        //Arrange
        var comando = new AdicionarComando();
        No no = BaseComando.CriarNovoNo(Tipo.Raiz, 23, default);
        no.Esquerdo = BaseComando.CriarNovoNo(Tipo.Vermelho, 12, no);
        no.Direito = BaseComando.CriarNovoNo(Tipo.Vermelho, 37, no);

        var valor = 5;

        ImprimeSaida.Imprimir(no);

        //Act
        var result = comando.Executar(no, valor);

        ImprimeSaida.Imprimir(result);

        //Assert
        Assert.Equal(valor, result.Esquerdo.Esquerdo.Valor);
        Assert.Equal(no.Esquerdo.Valor, result.Esquerdo.Esquerdo.ValorPai);
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
    public void AdicionarComando_Caso_1_Situacao_2()
    {
        //Arrange
        var comando = new AdicionarComando();
        No no = BaseComando.CriarNovoNo(Tipo.Raiz, 23, default);
        no.Esquerdo = BaseComando.CriarNovoNo(Tipo.Preto, 12, no);
        no.Esquerdo.Esquerdo = BaseComando.CriarNovoNo(Tipo.Vermelho, 6, no.Esquerdo);
        no.Esquerdo.Direito = BaseComando.CriarNovoNo(Tipo.Vermelho, 18, no.Esquerdo);
        no.Direito = BaseComando.CriarNovoNo(Tipo.Preto, 37, no);
        no.Direito.Esquerdo = BaseComando.CriarNovoNo(Tipo.Vermelho, 32, no.Direito);
        no.Direito.Direito = BaseComando.CriarNovoNo(Tipo.Vermelho, 48, no.Direito);

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
        Assert.Equal(no.Esquerdo.Direito.Valor, result.Esquerdo.Direito.Esquerdo.ValorPai);
    }

    [Fact]
    public void AdicionarComando_Caso_1_Situacao_3()
    {
        //Arrange
        var comando = new AdicionarComando();
        No no = BaseComando.CriarNovoNo(Tipo.Raiz, 57, default);
        no.Esquerdo = BaseComando.CriarNovoNo(Tipo.Vermelho, 35, no);
        no.Esquerdo.Esquerdo = BaseComando.CriarNovoNo(Tipo.Preto, 24, no.Esquerdo);
        no.Esquerdo.Esquerdo.Direito = BaseComando.CriarNovoNo(Tipo.Vermelho, 28, no.Esquerdo.Esquerdo);
        no.Esquerdo.Direito = BaseComando.CriarNovoNo(Tipo.Preto, 40, no.Esquerdo);

        no.Direito = BaseComando.CriarNovoNo(Tipo.Vermelho, 70, no);
        no.Direito.Esquerdo = BaseComando.CriarNovoNo(Tipo.Preto, 61, no.Direito);
        no.Direito.Direito = BaseComando.CriarNovoNo(Tipo.Preto, 80, no.Direito);
        no.Direito.Direito.Esquerdo = BaseComando.CriarNovoNo(Tipo.Vermelho, 73, no.Direito.Direito);
        no.Direito.Direito.Direito = BaseComando.CriarNovoNo(Tipo.Vermelho, 90, no.Direito.Direito);

        var valor = 97;

        ImprimeSaida.Imprimir(no);

        //Act
        var result = comando.Executar(no, valor);

        ImprimeSaida.Imprimir(result);

        //Assert
        Assert.Equal(Tipo.Raiz, result.Tipo);

        Assert.Equal(Tipo.Preto, result.Direito.Tipo);

        Assert.Equal(Tipo.Vermelho, result.Direito.Direito.Tipo);
        Assert.Equal(Tipo.Preto, result.Direito.Direito.Direito.Tipo);
        Assert.Equal(Tipo.Preto, result.Direito.Direito.Esquerdo.Tipo);

        Assert.Equal(Tipo.Preto, result.Direito.Esquerdo.Tipo);
        Assert.Equal(Tipo.Nulo, result.Direito.Esquerdo.Direito.Tipo);
        Assert.Equal(Tipo.Nulo, result.Direito.Esquerdo.Esquerdo.Tipo);

        Assert.Equal(Tipo.Preto, result.Esquerdo.Tipo);

        Assert.Equal(Tipo.Preto, result.Esquerdo.Esquerdo.Tipo);

        Assert.Equal(Tipo.Preto, result.Esquerdo.Direito.Tipo);
        Assert.Equal(Tipo.Nulo, result.Esquerdo.Direito.Direito.Tipo);
        Assert.Equal(Tipo.Nulo, result.Esquerdo.Direito.Esquerdo.Tipo);

        Assert.Equal(valor, result.Direito.Direito.Direito.Direito.Valor);
        Assert.Equal(result.Direito.Direito.Direito.Valor, result.Direito.Direito.Direito.Direito.ValorPai);
    }

    [Fact]
    public void AdicionarComando_ArvoreFilhoEsquerdoVermelhoComSeuFilhoDireitoVermelhor()
    {
        //Arrange
        var comando = new AdicionarComando();
        No no = BaseComando.CriarNovoNo(Tipo.Raiz, 23, default);
        no.Esquerdo = BaseComando.CriarNovoNo(Tipo.Vermelho, 12, no);
        no.Esquerdo.Esquerdo = BaseComando.CriarNovoNo(Tipo.Preto, 6, no.Esquerdo);
        no.Esquerdo.Direito = BaseComando.CriarNovoNo(Tipo.Preto, 18, no.Esquerdo);
        no.Esquerdo.Direito.Esquerdo = BaseComando.CriarNovoNo(Tipo.Vermelho, 14, no.Esquerdo.Direito);
        no.Direito = BaseComando.CriarNovoNo(Tipo.Preto, 37, no);
        no.Direito.Esquerdo = BaseComando.CriarNovoNo(Tipo.Vermelho, 32, no.Direito);
        no.Direito.Direito = BaseComando.CriarNovoNo(Tipo.Vermelho, 48, no.Direito);

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
        Assert.Equal(valor, result.Esquerdo.Direito.Valor);

        Assert.Equal(Tipo.Vermelho, result.Esquerdo.Direito.Direito.Tipo);
        Assert.Equal(18, result.Esquerdo.Direito.Direito.Valor);

        Assert.Equal(Tipo.Vermelho, result.Esquerdo.Direito.Esquerdo.Tipo);
        Assert.Equal(no.Esquerdo.Direito.Esquerdo.Valor, result.Esquerdo.Direito.Esquerdo.Valor);

        Assert.Equal(Tipo.Nulo, result.Esquerdo.Direito.Esquerdo.Esquerdo.Tipo);
        Assert.Equal(Tipo.Nulo, result.Esquerdo.Direito.Esquerdo.Direito.Tipo);

        Assert.Equal(no.Esquerdo.Direito.Valor, result.Esquerdo.Direito.Esquerdo.Pai?.Valor);
    }
}