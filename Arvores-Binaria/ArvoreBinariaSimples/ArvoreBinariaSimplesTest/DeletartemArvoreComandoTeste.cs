using ArvoreBinariaSimples;
using Utils;

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

        ImprimeSaida.Imprimir(no);

        //Act
        var result = comando.Executar(no, valor);

        ImprimeSaida.Imprimir(result);

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

        ImprimeSaida.Imprimir(no);

        //Act
        var result = comando.Executar(no, valor);

        ImprimeSaida.Imprimir(result);

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

        ImprimeSaida.Imprimir(no);

        //Act
        var result = comando.Executar(no, valor);

        ImprimeSaida.Imprimir(result);

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

        ImprimeSaida.Imprimir(no);

        //Act
        var result = comando.Executar(no, valor);

        ImprimeSaida.Imprimir(result);

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

        ImprimeSaida.Imprimir(no);

        //Act
        var result = comando.Executar(no, valor);

        ImprimeSaida.Imprimir(result);

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

        ImprimeSaida.Imprimir(no);

        //Act
        var result = comando.Executar(no, valor);

        ImprimeSaida.Imprimir(result);

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

        ImprimeSaida.Imprimir(no);

        //Act
        var result = comando.Executar(no, valor);

        ImprimeSaida.Imprimir(result);

        //Assert
        Assert.Null(result?.Direito);
        Assert.NotNull(result?.Esquerdo);
        Assert.Equal(TipoNo.RaizEsquerda, result?.Tipo);
        Assert.Equal(TipoNo.FilhoDireito, result?.Esquerdo?.Tipo);
        Assert.Equal(valorFilho, result?.Esquerdo?.Valor);
    }

    [Fact]
    public void DeletartemArvoreComandoTeste_DeletandoFilhoDireitoDoFilhoComFilhoFolhaEsquerda_Sucesso()
    {
        //Arrange
        var comando = new DeletartemArvoreComando();
        const int valorFilho = 30;
        No no = new()
        {
            Valor = 15,
            Tipo = TipoNo.RaizDireitaEsquerda,
            Esquerdo = new No
            {
                Valor = 10,
                Tipo = TipoNo.FilhoDireitoEsquerdo,
                Pai = 15,
                Direito = new No
                {
                    Valor = 12,
                    Tipo = TipoNo.Folha,
                    Pai = 10
                },
                Esquerdo = new No
                {
                    Valor = 6,
                    Tipo = TipoNo.FilhoDireitoEsquerdo,
                    Pai = 15,
                    Esquerdo = new No
                    {
                        Valor = 5,
                        Pai = 6,
                        Tipo = TipoNo.Folha
                    },
                    Direito = new No
                    {
                        Valor = 9,
                        Pai = 6,
                        Tipo = TipoNo.FilhoEsquerdo,
                        Esquerdo = new No
                        {
                            Valor = 8,
                            Pai = 9,
                            Tipo = TipoNo.Folha
                        }

                    }
                },
            },
            Direito = new No
            {
                Valor = 20,
                Pai = 15,
                Tipo = TipoNo.FilhoDireitoEsquerdo,
                Esquerdo = new No
                {
                    Valor = 18,
                    Pai = 20,
                    Tipo = TipoNo.FilhoDireitoEsquerdo,
                    Esquerdo = new No
                    {
                        Valor = 16,
                        Pai = 18,
                        Tipo = TipoNo.FilhoDireito,
                        Direito = new No
                        {
                            Valor = 17,
                            Pai = 16,
                            Tipo = TipoNo.Folha
                        }
                    },
                    Direito = new No
                    {
                        Valor = 19,
                        Pai = 18,
                        Tipo = TipoNo.Folha
                    }
                },
                Direito = new No
                {
                    Valor = 25,
                    Pai = 20,
                    Tipo = TipoNo.FilhoDireito,
                    Direito = new No
                    {
                        Valor = valorFilho,
                        Pai = 25,
                        Tipo = TipoNo.FilhoEsquerdo,
                        Esquerdo = new No
                        {
                            Valor = 27,
                            Pai = valorFilho,
                            Tipo = TipoNo.Folha
                        }
                    }
                }
            }
        };
        var valor = 25;

        ImprimeSaida.Imprimir(no);

        //Act
        var result = comando.Executar(no, valor);

        ImprimeSaida.Imprimir(result);

        //Assert
        Assert.NotNull(result?.Direito);
        Assert.NotNull(result?.Esquerdo);
        Assert.Equal(TipoNo.RaizDireitaEsquerda, result?.Tipo);
        Assert.Equal(TipoNo.FilhoDireitoEsquerdo, result?.Direito?.Tipo);
        Assert.Equal(TipoNo.FilhoEsquerdo, result?.Direito?.Direito?.Tipo);
        Assert.Equal(valorFilho, result?.Direito?.Direito?.Valor);
    }

    [Fact]
    public void DeletartemArvoreComandoTeste_DeletandoRaizComFilhosDireitaEsquerda_Sucesso()
    {
        //Arrange
        var comando = new DeletartemArvoreComando();
        const int valorFilho = 12;
        No no = new()
        {
            Valor = 15,
            Tipo = TipoNo.RaizDireitaEsquerda,
            Esquerdo = new No
            {
                Valor = 10,
                Tipo = TipoNo.FilhoDireitoEsquerdo,
                Pai = 15,
                Direito = new No
                {
                    Valor = valorFilho,
                    Tipo = TipoNo.Folha,
                    Pai = 10
                },
                Esquerdo = new No
                {
                    Valor = 6,
                    Tipo = TipoNo.FilhoDireitoEsquerdo,
                    Pai = 15,
                    Esquerdo = new No
                    {
                        Valor = 5,
                        Pai = 6,
                        Tipo = TipoNo.Folha
                    },
                    Direito = new No
                    {
                        Valor = 9,
                        Pai = 6,
                        Tipo = TipoNo.FilhoEsquerdo,
                        Esquerdo = new No
                        {
                            Valor = 8,
                            Pai = 9,
                            Tipo = TipoNo.Folha
                        }

                    }
                },
            },
            Direito = new No
            {
                Valor = 20,
                Pai = 15,
                Tipo = TipoNo.FilhoDireitoEsquerdo,
                Esquerdo = new No
                {
                    Valor = 18,
                    Pai = 20,
                    Tipo = TipoNo.FilhoDireitoEsquerdo,
                    Esquerdo = new No
                    {
                        Valor = 16,
                        Pai = 18,
                        Tipo = TipoNo.FilhoDireito,
                        Direito = new No
                        {
                            Valor = 17,
                            Pai = 16,
                            Tipo = TipoNo.Folha
                        }
                    },
                    Direito = new No
                    {
                        Valor = 19,
                        Pai = 18,
                        Tipo = TipoNo.Folha
                    }
                },
                Direito = new No
                {
                    Valor = 25,
                    Pai = 20,
                    Tipo = TipoNo.FilhoDireito,
                    Direito = new No
                    {
                        Valor = 30,
                        Pai = 25,
                        Tipo = TipoNo.FilhoEsquerdo,
                        Esquerdo = new No
                        {
                            Valor = 27,
                            Pai = 30,
                            Tipo = TipoNo.Folha
                        }
                    }
                }
            }
        };
        var valor = 15;

        ImprimeSaida.Imprimir(no);

        //Act
        var result = comando.Executar(no, valor);

        ImprimeSaida.Imprimir(result);

        //Assert
        Assert.NotNull(result?.Direito);
        Assert.NotNull(result?.Esquerdo);
        Assert.Equal(TipoNo.RaizDireitaEsquerda, result?.Tipo);
        Assert.Equal(valorFilho, result?.Valor);
        Assert.Equal(TipoNo.FilhoEsquerdo, result?.Esquerdo?.Tipo);
        Assert.Equal(TipoNo.FilhoDireitoEsquerdo, result?.Direito?.Tipo);
    }

    [Fact]
    public void DeletartemArvoreComandoTeste_DeletandoRaizComFilhosDireitaEsquerda2_Sucesso()
    {
        //Arrange
        var comando = new DeletartemArvoreComando();
        const int valorFilho = 12;
        No no = new()
        {
            Valor = 15,
            Tipo = TipoNo.RaizDireitaEsquerda,
            Esquerdo = new No
            {
                Valor = 10,
                Tipo = TipoNo.FilhoDireitoEsquerdo,
                Pai = 15,
                Direito = new No
                {
                    Valor = valorFilho,
                    Tipo = TipoNo.FilhoEsquerdo,
                    Pai = 10,
                    Esquerdo = new No
                    {
                        Valor = 11,
                        Pai = valorFilho,
                        Tipo = TipoNo.Folha
                    }
                },
                Esquerdo = new No
                {
                    Valor = 6,
                    Tipo = TipoNo.FilhoDireitoEsquerdo,
                    Pai = 15,
                    Esquerdo = new No
                    {
                        Valor = 5,
                        Pai = 6,
                        Tipo = TipoNo.Folha
                    },
                    Direito = new No
                    {
                        Valor = 9,
                        Pai = 6,
                        Tipo = TipoNo.FilhoEsquerdo,
                        Esquerdo = new No
                        {
                            Valor = 8,
                            Pai = 9,
                            Tipo = TipoNo.Folha
                        }

                    }
                },
            },
            Direito = new No
            {
                Valor = 20,
                Pai = 15,
                Tipo = TipoNo.FilhoDireitoEsquerdo,
                Esquerdo = new No
                {
                    Valor = 18,
                    Pai = 20,
                    Tipo = TipoNo.FilhoDireitoEsquerdo,
                    Esquerdo = new No
                    {
                        Valor = 16,
                        Pai = 18,
                        Tipo = TipoNo.FilhoDireito,
                        Direito = new No
                        {
                            Valor = 17,
                            Pai = 16,
                            Tipo = TipoNo.Folha
                        }
                    },
                    Direito = new No
                    {
                        Valor = 19,
                        Pai = 18,
                        Tipo = TipoNo.Folha
                    }
                },
                Direito = new No
                {
                    Valor = 25,
                    Pai = 20,
                    Tipo = TipoNo.FilhoDireito,
                    Direito = new No
                    {
                        Valor = 30,
                        Pai = 25,
                        Tipo = TipoNo.FilhoEsquerdo,
                        Esquerdo = new No
                        {
                            Valor = 27,
                            Pai = 30,
                            Tipo = TipoNo.Folha
                        }
                    }
                }
            }
        };
        var valor = 15;

        ImprimeSaida.Imprimir(no);

        //Act
        var result = comando.Executar(no, valor);

        ImprimeSaida.Imprimir(result);

        //Assert
        Assert.NotNull(result?.Direito);
        Assert.NotNull(result?.Esquerdo);
        Assert.Equal(TipoNo.RaizDireitaEsquerda, result?.Tipo);
        Assert.Equal(valorFilho, result?.Valor);
        Assert.Equal(TipoNo.FilhoDireitoEsquerdo, result?.Esquerdo?.Tipo);
        Assert.Equal(TipoNo.FilhoDireitoEsquerdo, result?.Direito?.Tipo);
    }

    [Fact]
    public void DeletartemArvoreComandoTeste_DeletandoFilhoComFilhosDireitaEsquerda_Sucesso()
    {
        //Arrange
        var comando = new DeletartemArvoreComando();
        const int valorFilho = 5;
        No no = new()
        {
            Valor = 15,
            Tipo = TipoNo.RaizDireitaEsquerda,
            Esquerdo = new No
            {
                Valor = 10,
                Tipo = TipoNo.FilhoDireitoEsquerdo,
                Pai = 15,
                Direito = new No
                {
                    Valor = 12,
                    Tipo = TipoNo.FilhoEsquerdo,
                    Pai = 10,
                    Esquerdo = new No
                    {
                        Valor = 11,
                        Pai = 12,
                        Tipo = TipoNo.Folha
                    }
                },
                Esquerdo = new No
                {
                    Valor = 6,
                    Tipo = TipoNo.FilhoDireitoEsquerdo,
                    Pai = 15,
                    Esquerdo = new No
                    {
                        Valor = valorFilho,
                        Pai = 6,
                        Tipo = TipoNo.Folha
                    },
                    Direito = new No
                    {
                        Valor = 9,
                        Pai = 6,
                        Tipo = TipoNo.FilhoEsquerdo,
                        Esquerdo = new No
                        {
                            Valor = 8,
                            Pai = 9,
                            Tipo = TipoNo.Folha
                        }

                    }
                },
            },
            Direito = new No
            {
                Valor = 20,
                Pai = 15,
                Tipo = TipoNo.FilhoDireitoEsquerdo,
                Esquerdo = new No
                {
                    Valor = 18,
                    Pai = 20,
                    Tipo = TipoNo.FilhoDireitoEsquerdo,
                    Esquerdo = new No
                    {
                        Valor = 16,
                        Pai = 18,
                        Tipo = TipoNo.FilhoDireito,
                        Direito = new No
                        {
                            Valor = 17,
                            Pai = 16,
                            Tipo = TipoNo.Folha
                        }
                    },
                    Direito = new No
                    {
                        Valor = 19,
                        Pai = 18,
                        Tipo = TipoNo.Folha
                    }
                },
                Direito = new No
                {
                    Valor = 25,
                    Pai = 20,
                    Tipo = TipoNo.FilhoDireito,
                    Direito = new No
                    {
                        Valor = 30,
                        Pai = 25,
                        Tipo = TipoNo.FilhoEsquerdo,
                        Esquerdo = new No
                        {
                            Valor = 27,
                            Pai = 30,
                            Tipo = TipoNo.Folha
                        }
                    }
                }
            }
        };
        var valor = 6;

        ImprimeSaida.Imprimir(no);

        //Act
        var result = comando.Executar(no, valor);

        ImprimeSaida.Imprimir(result);

        //Assert
        Assert.NotNull(result?.Direito);
        Assert.NotNull(result?.Esquerdo);
        Assert.Equal(TipoNo.FilhoDireito, result?.Esquerdo?.Esquerdo?.Tipo);
        Assert.Equal(valorFilho, result?.Esquerdo?.Esquerdo?.Valor);
        Assert.Null(result?.Esquerdo?.Esquerdo?.Esquerdo);
        Assert.Equal(TipoNo.FilhoEsquerdo, result?.Esquerdo?.Esquerdo?.Direito?.Tipo);
    }

    [Fact]
    public void DeletartemArvoreComandoTeste_DeletandoFilhoComFilhosDireitaEsquerda2_Sucesso()
    {
        //Arrange
        var comando = new DeletartemArvoreComando();
        const int valorFilho = 19;
        No no = new()
        {
            Valor = 15,
            Tipo = TipoNo.RaizDireitaEsquerda,
            Esquerdo = new No
            {
                Valor = 10,
                Tipo = TipoNo.FilhoDireitoEsquerdo,
                Pai = 15,
                Direito = new No
                {
                    Valor = 12,
                    Tipo = TipoNo.FilhoEsquerdo,
                    Pai = 10,
                    Esquerdo = new No
                    {
                        Valor = 11,
                        Pai = 12,
                        Tipo = TipoNo.Folha
                    }
                },
                Esquerdo = new No
                {
                    Valor = 6,
                    Tipo = TipoNo.FilhoDireitoEsquerdo,
                    Pai = 15,
                    Esquerdo = new No
                    {
                        Valor = 5,
                        Pai = 6,
                        Tipo = TipoNo.Folha
                    },
                    Direito = new No
                    {
                        Valor = 9,
                        Pai = 6,
                        Tipo = TipoNo.FilhoEsquerdo,
                        Esquerdo = new No
                        {
                            Valor = 8,
                            Pai = 9,
                            Tipo = TipoNo.Folha
                        }

                    }
                },
            },
            Direito = new No
            {
                Valor = 20,
                Pai = 15,
                Tipo = TipoNo.FilhoDireitoEsquerdo,
                Esquerdo = new No
                {
                    Valor = 18,
                    Pai = 20,
                    Tipo = TipoNo.FilhoDireitoEsquerdo,
                    Esquerdo = new No
                    {
                        Valor = 16,
                        Pai = 18,
                        Tipo = TipoNo.FilhoDireito,
                        Direito = new No
                        {
                            Valor = 17,
                            Pai = 16,
                            Tipo = TipoNo.Folha
                        }
                    },
                    Direito = new No
                    {
                        Valor = valorFilho,
                        Pai = 18,
                        Tipo = TipoNo.Folha
                    }
                },
                Direito = new No
                {
                    Valor = 25,
                    Pai = 20,
                    Tipo = TipoNo.FilhoDireito,
                    Direito = new No
                    {
                        Valor = 30,
                        Pai = 25,
                        Tipo = TipoNo.FilhoEsquerdo,
                        Esquerdo = new No
                        {
                            Valor = 27,
                            Pai = 30,
                            Tipo = TipoNo.Folha
                        }
                    }
                }
            }
        };
        var valor = 20;

        ImprimeSaida.Imprimir(no);

        //Act
        var result = comando.Executar(no, valor);

        ImprimeSaida.Imprimir(result);

        //Assert
        Assert.NotNull(result?.Direito);
        Assert.NotNull(result?.Esquerdo);
        Assert.Null(result?.Direito?.Esquerdo?.Direito);
        Assert.Equal(TipoNo.RaizDireitaEsquerda, result?.Tipo);
        Assert.Equal(valorFilho, result?.Direito?.Valor);
        Assert.Equal(TipoNo.FilhoDireitoEsquerdo, result?.Direito?.Tipo);
        Assert.Equal(TipoNo.FilhoDireitoEsquerdo, result?.Esquerdo?.Tipo);
        Assert.Equal(TipoNo.FilhoDireitoEsquerdo, result?.Direito?.Tipo);
    }

    [Fact]
    public void DeletartemArvoreComandoTeste_DeletandoFilhoComFilhosDireitaEsquerda3_Sucesso()
    {
        //Arrange
        var comando = new DeletartemArvoreComando();
        const int valorFilho = 25;
        No no = new()
        {
            Valor = 15,
            Tipo = TipoNo.RaizDireitaEsquerda,
            Esquerdo = new No
            {
                Valor = 10,
                Tipo = TipoNo.FilhoDireitoEsquerdo,
                Pai = 15,
                Direito = new No
                {
                    Valor = 12,
                    Tipo = TipoNo.FilhoEsquerdo,
                    Pai = 10,
                    Esquerdo = new No
                    {
                        Valor = 11,
                        Pai = 12,
                        Tipo = TipoNo.Folha
                    }
                },
                Esquerdo = new No
                {
                    Valor = 6,
                    Tipo = TipoNo.FilhoDireitoEsquerdo,
                    Pai = 15,
                    Esquerdo = new No
                    {
                        Valor = 5,
                        Pai = 6,
                        Tipo = TipoNo.Folha
                    },
                    Direito = new No
                    {
                        Valor = 9,
                        Pai = 6,
                        Tipo = TipoNo.FilhoEsquerdo,
                        Esquerdo = new No
                        {
                            Valor = 8,
                            Pai = 9,
                            Tipo = TipoNo.Folha
                        }

                    }
                },
            },
            Direito = new No
            {
                Valor = 20,
                Pai = 15,
                Tipo = TipoNo.FilhoDireito,
                Direito = new No
                {
                    Valor = valorFilho,
                    Pai = 20,
                    Tipo = TipoNo.FilhoDireito,
                    Direito = new No
                    {
                        Valor = 30,
                        Pai = valorFilho,
                        Tipo = TipoNo.FilhoEsquerdo,
                        Esquerdo = new No
                        {
                            Valor = 27,
                            Pai = 30,
                            Tipo = TipoNo.Folha
                        }
                    }
                }
            }
        };
        var valor = 20;

        ImprimeSaida.Imprimir(no);

        //Act
        var result = comando.Executar(no, valor);

        ImprimeSaida.Imprimir(result);

        //Assert
        Assert.NotNull(result?.Direito);
        Assert.NotNull(result?.Esquerdo);
        Assert.Null(result?.Direito?.Esquerdo);
        Assert.Equal(TipoNo.FilhoEsquerdo, result?.Direito?.Direito?.Tipo);
        Assert.Equal(valorFilho, result?.Direito?.Valor);
    }
}