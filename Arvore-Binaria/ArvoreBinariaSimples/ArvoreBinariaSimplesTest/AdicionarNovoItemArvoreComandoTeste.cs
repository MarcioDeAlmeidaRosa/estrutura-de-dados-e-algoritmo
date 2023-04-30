using ArvoreBinariaSimples;
namespace ArvoreBinariaSimplesTest;

public class AdicionarNovoItemArvoreComandoTeste
{
    [Fact]
    public void AdicionarNovoItemArvoreComando_InicializandoArvore_Sucesso()
    {
        //Arrange
        var comando = new AdicionarNovoItemArvoreComando();
        var valor = 50;

        //Act
        var result = comando.Executar(default, valor);

        //Assert
        Assert.Equal(valor, result?.Valor);
        Assert.Equal(TipoNo.Raiz, result?.Tipo);
    }

    [Fact]
    public void AdicionarNovoItemArvoreComando_AdicionandoFilhoEsquerdo_Sucesso()
    {
        //Arrange
        var comando = new AdicionarNovoItemArvoreComando();
        No no = new()
        {
            Valor = 50,
            Tipo = TipoNo.Raiz
        };
        var valor = 25;

        //Act
        var result = comando.Executar(no, valor);

        //Assert
        Assert.Equal(valor, result?.Esquerdo?.Valor);
        Assert.Equal(TipoNo.RaizEsquerda, result?.Tipo);
    }

    [Fact]
    public void AdicionarNovoItemArvoreComando_AdicionandoFilhoEmFilhoEsquerdo_Sucesso()
    {
        //Arrange
        var comando = new AdicionarNovoItemArvoreComando();
        No no = new()
        {
            Valor = 50,
            Tipo = TipoNo.RaizEsquerda,
            Esquerdo = new No
            {
                Valor = 25,
                Tipo = TipoNo.Folha,
            }
        };
        var valor = 10;

        //Act
        var result = comando.Executar(no, valor);

        //Assert
        Assert.Equal(valor, result?.Esquerdo?.Esquerdo?.Valor);
        Assert.Equal(TipoNo.FilhoEsquerdo, result?.Esquerdo?.Tipo);
        Assert.Equal(TipoNo.Folha, result?.Esquerdo?.Esquerdo?.Tipo);
    }

    [Fact]
    public void AdicionarNovoItemArvoreComando_AdicionandoFilhosEmFilhoEsquerdo_Sucesso()
    {
        //Arrange
        var comando = new AdicionarNovoItemArvoreComando();
        No no = new()
        {
            Valor = 50,
            Tipo = TipoNo.RaizEsquerda,
            Esquerdo = new No
            {
                Valor = 25,
                Tipo = TipoNo.FilhoEsquerdo,
                Esquerdo = new No
                {
                    Valor = 10,
                    Tipo = TipoNo.Folha,
                }
            }
        };
        var valor = 30;

        //Act
        var result = comando.Executar(no, valor);

        //Assert
        Assert.Equal(valor, result?.Esquerdo?.Direito?.Valor);
        Assert.Equal(TipoNo.FilhoDireitoEsquerdo, result?.Esquerdo?.Tipo);
        Assert.Equal(TipoNo.Folha, result?.Esquerdo?.Esquerdo?.Tipo);
        Assert.Equal(TipoNo.Folha, result?.Esquerdo?.Direito?.Tipo);
    }

    [Fact]
    public void AdicionarNovoItemArvoreComando_AdicionandoFilhoDireito_Sucesso()
    {
        //Arrange
        var comando = new AdicionarNovoItemArvoreComando();
        No no = new()
        {
            Valor = 50,
            Tipo = TipoNo.Raiz
        };
        var valor = 70;

        //Act
        var result = comando.Executar(no, valor);

        //Assert
        Assert.Equal(valor, result?.Direito?.Valor);
        Assert.Equal(TipoNo.RaizDireita, result?.Tipo);
    }

    [Fact]
    public void AdicionarNovoItemArvoreComando_AdicionandoFilhoDireitoEmFilhoDireito_Sucesso()
    {
        //Arrange
        var comando = new AdicionarNovoItemArvoreComando();
        No no = new()
        {
            Valor = 50,
            Tipo = TipoNo.RaizDireita,
            Direito = new No
            {
                Valor = 75,
                Tipo = TipoNo.Folha
            }
        };
        var valor = 80;

        //Act
        var result = comando.Executar(no, valor);

        //Assert
        Assert.Equal(valor, result?.Direito?.Direito?.Valor);
        Assert.Equal(TipoNo.FilhoDireito, result?.Direito?.Tipo);
        Assert.Equal(TipoNo.Folha, result?.Direito?.Direito?.Tipo);
    }

    [Fact]
    public void AdicionarNovoItemArvoreComando_AdicionandoFilhosEmFilhoDireito_Sucesso()
    {
        //Arrange
        var comando = new AdicionarNovoItemArvoreComando();
        No no = new()
        {
            Valor = 50,
            Tipo = TipoNo.RaizDireita,
            Direito = new No
            {
                Valor = 75,
                Tipo = TipoNo.FilhoDireito,
                Direito = new No
                {
                    Valor = 80,
                    Tipo = TipoNo.Folha,
                }
            }
        };
        var valor = 70;

        //Act
        var result = comando.Executar(no, valor);

        //Assert
        Assert.Equal(valor, result?.Direito?.Esquerdo?.Valor);
        Assert.Equal(TipoNo.FilhoDireitoEsquerdo, result?.Direito?.Tipo);
        Assert.Equal(TipoNo.Folha, result?.Direito?.Direito?.Tipo);
        Assert.Equal(TipoNo.Folha, result?.Direito?.Esquerdo?.Tipo);
    }
}