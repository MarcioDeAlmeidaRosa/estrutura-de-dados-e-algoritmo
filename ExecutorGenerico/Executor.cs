using System.Text.RegularExpressions;
using Utils;

namespace ExecutorGenerico;

public static class Executor
{
    private static string Pattern = "^[0-9]+$";
    private const int FinalizarExecucao = 99;

    public static void Executar<TypeNo>(ControladorDeComandos<TypeNo> controlador, TypeNo? no)
        where TypeNo : BaseNo
    {
        while (true)
        {
            controlador.ImprimirObjetivos();
            Console.WriteLine($"{FinalizarExecucao} - Para encerrar execução...");
            var comando = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(comando))
            {
                Console.WriteLine("Número do comando não informado...");
                continue;
            }

            if (!Regex.IsMatch(comando, Pattern))
            {
                Console.WriteLine("Número do comando digitado incorretamente...");
                continue;
            }

            var comandoNumerico = int.Parse(comando);

            if (comandoNumerico == FinalizarExecucao)
            {
                Console.WriteLine("Solicitado encerramento do programa...");
                break;
            }

            if (!controlador.ComandoRegistrado(comandoNumerico))
            {
                Console.WriteLine("Comando não encontrado...");
            }

            controlador.ImprimirComando(comandoNumerico);

            var valor = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(valor))
            {
                Console.WriteLine("Valor não informado...");
                continue;
            }

            if (!Regex.IsMatch(valor, Pattern))
            {
                Console.WriteLine("Valor digitado incorretamente...");
                continue;
            }

            var valorNumerico = int.Parse(valor);

            no = controlador.Executar(comandoNumerico, no, valorNumerico);

            ImprimeSaida.Imprimir(no);
        }
    }
}