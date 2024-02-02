using System;

class Program
{
    static void Main()
    {
        // Loop principal para permitir várias transações
        while (true)
        {
            try
            {
                Console.WriteLine("Digite o valor do Produto a ser comprado R$: ");
                decimal valorProduto = LerDecimal();

                Console.WriteLine("Digite o valor Pago em dinheiro R$: ");
                decimal valorDinheiro = LerDecimal();

                // Verifica se o valor pago é suficiente
                if (valorDinheiro < valorProduto)
                {
                    Console.WriteLine("O valor em dinheiro pago é menor que o valor do produto.");
                }
                else
                {
                    CalcularEExibirTroco(valorProduto, valorDinheiro);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Por favor, insira um valor válido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }

            // Pergunta ao usuário se deseja realizar outra transação
            Console.WriteLine("\nDeseja realizar outra transação? (S/N)");
            if (Console.ReadLine()?.ToUpper() != "S")
                break;

            Console.Clear(); // Limpa a tela para a próxima transação
        }
    }

    // Função para ler um valor  do console
    static decimal LerDecimal()
    {
        while (true)
        {
            if (decimal.TryParse(Console.ReadLine().Replace('.', ','), out decimal valor))
            {
                return valor;
            }
            else
            {
                Console.WriteLine("Por favor, insira um valor válido.");
            }
        }
    }

    // Função para calcular o troco e exibir
    static void CalcularEExibirTroco(decimal valorProduto, decimal valorDinheiro)
    {
        decimal troco = valorDinheiro - valorProduto;

        Console.WriteLine($"\nTroco a ser dado: R${troco:F2}\n");

        int[] notas = { 100, 50, 20, 10, 5, 2, 1 };
        decimal[] moedas = { 1.0m, 0.5m, 0.25m, 0.1m, 0.05m, 0.01m };

        Console.WriteLine("Notas:");
        foreach (int nota in notas)
        {
            int quantidade = (int)(troco / nota);
            if (quantidade > 0)
            {
                Console.WriteLine($"{QuantidadePorExtenso(quantidade)} de {FormatarMoedaNota(nota)}");
                troco -= quantidade * nota;
            }
        }

        Console.WriteLine("\nMoedas:");
        foreach (decimal moeda in moedas)
        {
            int quantidade = (int)(troco / moeda);
            if (quantidade > 0)
            {
                Console.WriteLine($"{QuantidadePorExtenso(quantidade)} de {FormatarMoedaNota(moeda)}");
                troco -= quantidade * moeda;
            }
        }
    }

    // Função para formatar uma moeda ou nota como string
    static string FormatarMoedaNota(decimal valor)
    {
        return valor >= 1 ? $"R${valor:F2}" : $"R${valor:F2}";
    }

    // Função para formatar a quantidade como string
    static string QuantidadePorExtenso(int quantidade)
    {
        return quantidade > 1 ? $"{quantidade}" : $"{quantidade}";
    }
}
