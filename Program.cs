using ExemploFundamentos;
using System;
using System.Collections.Generic;

class Estacionamento
{
    private decimal precoInicial;
    private decimal precoPorHora;
    private List<string> veiculos;

    public Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        this.precoInicial = precoInicial;
        this.precoPorHora = precoPorHora;
        this.veiculos = new List<string>();
    }

    public void AdicionarVeiculo(string placa)
    {
        veiculos.Add(placa);
        Console.WriteLine($"Veículo de placa {placa} adicionado ao estacionamento.");
    }

    public void RemoverVeiculo(string placa)
    {
        if (veiculos.Contains(placa))
        {
            Console.Write($"Informe o número de horas que o veículo {placa} permaneceu no estacionamento: ");
            if (int.TryParse(Console.ReadLine(), out int horas))
            {
                decimal valorCobrado = CalcularValorCobrado(horas);
                Console.WriteLine($"Veículo de placa {placa} foi removido. Valor cobrado: R$ {valorCobrado}");
                veiculos.Remove(placa);
            }
            else
            {
                Console.WriteLine("Valor de horas inválido. Operação cancelada.");
            }
        }
        else
        {
            Console.WriteLine($"Veículo de placa {placa} não encontrado no estacionamento.");
        }
    }

    public void ListarVeiculos()
    {
        if (veiculos.Count == 0)
        {
            Console.WriteLine("Não há veículos estacionados.");
        }
        else
        {
            Console.WriteLine("Veículos estacionados:");
            foreach (var placa in veiculos)
            {
                Console.WriteLine(placa);
            }
        }
    }

    private decimal CalcularValorCobrado(int horas)
    {
        return precoInicial + (precoPorHora * horas);
    }
}

class Program
{
    static void Main()
    {
        // TODO: Definir preços iniciais e por hora
        decimal precoInicial = 5.0m;
        decimal precoPorHora = 2.0m;

        Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Cadastrar veículo");
            Console.WriteLine("2. Remover veículo");
            Console.WriteLine("3. Listar veículos");
            Console.WriteLine("4. Encerrar");

            Console.Write("Escolha uma opção (1-4): ");
            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    Console.Write("Informe a placa do veículo: ");
                    string placaAdicionar = Console.ReadLine();
                    estacionamento.AdicionarVeiculo(placaAdicionar);
                    break;

                case "2":
                    Console.Write("Informe a placa do veículo a ser removido: ");
                    string placaRemover = Console.ReadLine();
                    estacionamento.RemoverVeiculo(placaRemover);
                    break;

                case "3":
                    estacionamento.ListarVeiculos();
                    break;

                case "4":
                    Console.WriteLine("Encerrando o programa.");
                    return;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
