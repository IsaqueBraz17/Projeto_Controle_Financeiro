using System;
using System.Collections.Generic;

class Cadastro_Despesas
{
    private Dictionary<string, double> despesas = new Dictionary<string, double>();
    private double salario;

    public void CalcularDespesas()
    {
        Console.Write("Digite o valor do seu salário: R$");
        salario = double.Parse(Console.ReadLine());

        AdicionarDespesa("Casa");
        AdicionarDespesa("Carro");
        AdicionarDespesa("Estudos");
        AdicionarDespesa("Transporte");
        AdicionarDespesa("Gastos de lazer");

        ExibirResultados();
    }

    private void AdicionarDespesa(string categoria)
    {
        Console.Write($"Você possui despesas com {categoria}? (S/N): ");
        string resposta = Console.ReadLine().Trim().ToUpper();

        if (resposta == "S")
        {
            Console.Write($"Digite o valor gasto com {categoria}: R$");
            double valor = double.Parse(Console.ReadLine());
            despesas[categoria] = valor;
        }
    }

    private void ExibirResultados()
    {
        double totalDespesas = 0;
        Console.WriteLine("\nResumo das despesas:");
        foreach (var item in despesas)
        {
            Console.WriteLine($"{item.Key}: R${item.Value:F2}");
            totalDespesas += item.Value;
        }
        Console.WriteLine($"Total de despesas: R${totalDespesas:F2}");

        double saldo = salario - totalDespesas;
        double porcentagemGasta = (totalDespesas / salario) * 100;

        Console.WriteLine("\nResumo Financeiro:");
        if (saldo < 0)
        {
            Console.WriteLine($"Você está no vermelho! Déficit: R${saldo:F2} ({porcentagemGasta:F2}% do salário). Reduza suas despesas!");
        }
        else
        {
            Console.WriteLine($"Sobrou R${saldo:F2} após pagar todas as despesas. Você utilizou {porcentagemGasta:F2}% do seu salário.");
        }
    }
}
