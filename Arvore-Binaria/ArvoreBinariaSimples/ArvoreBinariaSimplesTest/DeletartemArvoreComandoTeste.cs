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
    public void DeletartemArvoreComandoTeste_DeletandoFiloDoNoRaiz_Sucesso()
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
    public void DeletartemArvoreComandoTeste_DeletandoFiloDoNoFilhoDireito_Sucesso()
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
}