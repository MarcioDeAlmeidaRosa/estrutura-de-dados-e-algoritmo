using ArvoceBinariaRubroNegra;
using ExecutorGenerico;

Console.WriteLine("Red Black trees");

ControladorDeComandos<No> controlador = new(new List<IComando<No>>()
{
    // new AdicionarNovoItemArvoreComando(),
    // new GerarArvoreDinamicaComando(),
    // new DeletartemArvoreComando(),
 });

Executor.Executar(controlador, default(No?));