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

    [Fact]
    public void DeletartemArvoreComandoTeste_DeletandoNoRaiz_Sucesso()
    {
        //Arrange
        var comando = new DeletartemArvoreComando();
        No no = new()
        {
            Valor = 50,
            Tipo = TipoNo.Raiz
        };
        var valor = 50;

        //Act
        var result = comando.Executar(no, valor);

        //Assert
        Assert.Null(result?.Valor);
    }

    [Fact]
    public void DeletartemArvoreComandoTeste_DeletandoFilhoDoNoRaiz_Sucesso()
    {
        //Arrange
        var comando = new DeletartemArvoreComando();
        No no = new()
        {
            Valor = 50,
            Tipo = TipoNo.RaizDireita,
            Direito = new No
            {
                Valor = 60,
                Tipo = TipoNo.Folha,
                Pai = 50
            }
        };
        var valor = 60;

        //Act
        var result = comando.Executar(no, valor);

        //Assert
        Assert.Null(result?.Direito);
        Assert.Equal(TipoNo.Raiz, result?.Tipo);
    }

    [Fact]
    public void DeletartemArvoreComandoTeste_DeletandoFilhoDoNoFilhoDireito_Sucesso()
    {
        //Arrange
        var comando = new DeletartemArvoreComando();
        No no = new()
        {
            Valor = 50,
            Tipo = TipoNo.RaizDireita,
            Direito = new No
            {
                Valor = 60,
                Tipo = TipoNo.FilhoDireito,
                Pai = 50,
                Direito = new No
                {
                    Valor = 70,
                    Tipo = TipoNo.Folha,
                    Pai = 60,
                }
            }
        };
        var valor = 70;

        //Act
        var result = comando.Executar(no, valor);

        //Assert
        Assert.Null(result?.Direito?.Direito);
        Assert.NotNull(result?.Direito);
        Assert.Equal(TipoNo.RaizDireita, result?.Tipo);
        Assert.Equal(TipoNo.Folha, result?.Direito?.Tipo);
    }

    [Fact]
    public void DeletartemArvoreComandoTeste_DeletandoRaizComFilhosFolhas_Sucesso()
    {
        //Arrange
        var comando = new DeletartemArvoreComando();
        const int valorFilho = 40;
        No no = new()
        {
            Valor = 50,
            Tipo = TipoNo.RaizDireitaEsquerda,
            Direito = new No
            {
                Valor = 60,
                Tipo = TipoNo.Folha,
                Pai = 50
            },
            Esquerdo = new No
            {
                Valor = valorFilho,
                Tipo = TipoNo.Folha,
                Pai = 50
            }
        };
        var valor = 50;

        //Act
        var result = comando.Executar(no, valor);

        //Assert
        Assert.Null(result?.Esquerdo);
        Assert.NotNull(result?.Direito);
        Assert.Equal(TipoNo.RaizDireita, result?.Tipo);
        Assert.Equal(TipoNo.Folha, result?.Direito?.Tipo);
        Assert.Equal(valorFilho, result?.Valor);
    }

    [Fact]
    public void DeletartemArvoreComandoTeste_DeletandoRaizComFilhoEsquerdaFolha_Sucesso()
    {
        //Arrange
        var comando = new DeletartemArvoreComando();
        const int valorFilho = 40;
        No no = new()
        {
            Valor = 50,
            Tipo = TipoNo.RaizEsquerda,
            Esquerdo = new No
            {
                Valor = valorFilho,
                Tipo = TipoNo.Folha,
                Pai = 50
            }
        };
        var valor = 50;

        //Act
        var result = comando.Executar(no, valor);

        //Assert
        Assert.Null(result?.Esquerdo);
        Assert.Null(result?.Direito);
        Assert.Equal(TipoNo.Raiz, result?.Tipo);
        Assert.Equal(valorFilho, result?.Valor);
    }

    [Fact]
    public void DeletartemArvoreComandoTeste_DeletandoRaizComFilhoDireitoFolha_Sucesso()
    {
        //Arrange
        var comando = new DeletartemArvoreComando();
        const int valorFilho = 60;
        No no = new()
        {
            Valor = 50,
            Tipo = TipoNo.RaizDireitaEsquerda,
            Direito = new No
            {
                Valor = valorFilho,
                Tipo = TipoNo.Folha,
                Pai = 50
            }
        };
        var valor = 50;

        //Act
        var result = comando.Executar(no, valor);

        //Assert
        Assert.Null(result?.Esquerdo);
        Assert.Null(result?.Direito);
        Assert.Equal(TipoNo.Raiz, result?.Tipo);
        Assert.Equal(valorFilho, result?.Valor);
    }

    [Fact]
    public void DeletartemArvoreComandoTeste_DeletandoFilhoEsquerdoComFilhosFolhas_Sucesso()
    {
        //Arrange
        var comando = new DeletartemArvoreComando();
        const int valorFilho = 43;
        No no = new()
        {
            Valor = 50,
            Tipo = TipoNo.RaizEsquerda,
            Esquerdo = new No
            {
                Valor = 45,
                Tipo = TipoNo.FilhoDireitoEsquerdo,
                Pai = 50,
                Direito = new No
                {
                    Valor = 47,
                    Tipo = TipoNo.Folha,
                    Pai = 45
                },
                Esquerdo = new No
                {
                    Valor = valorFilho,
                    Tipo = TipoNo.Folha,
                    Pai = 45
                },
            }
        };
        var valor = 45;

        //Act
        var result = comando.Executar(no, valor);

        //Assert
        Assert.Null(result?.Direito);
        Assert.NotNull(result?.Esquerdo);
        Assert.Equal(TipoNo.RaizEsquerda, result?.Tipo);
        Assert.Equal(TipoNo.FilhoDireito, result?.Esquerdo?.Tipo);
        Assert.Equal(valorFilho, result?.Esquerdo?.Valor);
    }
}