using ArvoreBinariaSimples;
using ExecutorGenerico;

Console.WriteLine("Utilizando árvore binária...");

ControladorDeComandos<No> controlador = new(new List<IComando<No>>()
{
    new AdicionarNovoItemArvoreComando(),
    new GerarArvoreDinamicaComando(),
    new DeletartemArvoreComando(),
 });

No? no = default;

Executor.Executar(controlador, no);