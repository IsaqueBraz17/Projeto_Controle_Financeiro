using System;
using System.Collections.Generic;

class CadastroSalarios
{
    private List<decimal> salarios = new List<decimal>();

    public void MenuPrincipal()
    {
        bool salarioCadastrado = false;

        while (!salarioCadastrado)
        {
            Console.WriteLine("Como podemos te ajudar hoje?");
            Console.WriteLine("[1] Cadastrar Salário");
            Console.WriteLine("[2] Cadastrar Salário Conjunto");
            Console.WriteLine("[3] Não possuo Salário");
            Console.Write("Digite a opção desejada: ");

            if (int.TryParse(Console.ReadLine(), out int opcaoMenu))
            {
                switch (opcaoMenu)
                {
                    case 1:
                        CadastrarSalario();
                        salarioCadastrado = true;
                        break;
                    case 2:
                        CadastrarSalarioConjunto();
                        salarioCadastrado = true;
                        break;
                    case 3:
                        Console.WriteLine("Você precisa cadastrar pelo menos um salário para continuar.");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Digite um número válido.");
            }
        }

        Console.WriteLine("Salários cadastrados com sucesso! Agora vamos cadastrar suas despesas.");
        Cadastro_Despesas despesas = new Cadastro_Despesas();
        despesas.CalcularDespesas();
    }

    private void CadastrarSalario()
    {
        Console.Write("Digite o valor do salário: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal salario))
        {
            salarios.Add(salario);
            Console.WriteLine("Salário cadastrado com sucesso!");
        }
        else
        {
            Console.WriteLine("Valor inválido. Tente novamente.");
        }
    }

    private void CadastrarSalarioConjunto()
    {
        Console.Write("Digite os salários separados por espaço: ");
        string[] valores = Console.ReadLine().Split(' ');

        foreach (string valor in valores)
        {
            if (decimal.TryParse(valor, out decimal salario))
            {
                salarios.Add(salario);
            }
            else
            {
                Console.WriteLine($"Valor inválido ignorado: {valor}");
            }
        }
        Console.WriteLine("Salários cadastrados com sucesso!");
    }
}