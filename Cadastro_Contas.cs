using System;
using System.Collections.Generic;

class Cadastro_Contas
{
    private Dictionary<string, string> contas = new Dictionary<string, string>()
    {
        {"teste", "1234"} // Conta fictícia para testes
    };
    private const int MaxTentativas = 3;

    public bool AcessarOuCriarConta()
    {
        while (true)
        {
            Console.WriteLine("Primeiro vamos acessar sua conta..");
            Console.WriteLine(" [1] Acessar Conta");
            Console.WriteLine(" [2] Criar Conta");
            Console.WriteLine(" [3] Sair");
            Console.Write("Digite a opção desejada: ");

            if (int.TryParse(Console.ReadLine(), out int opcao_conta))
            {
                switch (opcao_conta)
                {
                    case 1:
                        if (AcessarConta()) return true;
                        break;
                    case 2:
                        CriarConta();
                        return true;
                    case 3:
                        Console.WriteLine("Saindo...");
                        return false;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida, por favor, digite um número.");
            }
        }
    }

    private bool AcessarConta()
    {
        int tentativas = 0;
        while (tentativas < MaxTentativas)
        {
            Console.Write("Digite seu nome de usuário: ");
            string usuario = Console.ReadLine();

            Console.Write("Digite sua senha: ");
            string senha = Console.ReadLine();

            if (contas.ContainsKey(usuario) && contas[usuario] == senha)
            {
                Console.WriteLine($"Bem-vindo, {usuario}!");
                return true;
            }
            else
            {
                tentativas++;
                Console.WriteLine($"Login ou senha incorretos. Tentativa {tentativas} de {MaxTentativas}.");
            }
        }

        Console.WriteLine("Acesso bloqueado devido a múltiplas tentativas falhas.");
        return false;
    }

    private void CriarConta()
    {
        Console.Write("Digite um nome de usuário: ");
        string usuario = Console.ReadLine();

        Console.Write("Digite uma senha: ");
        string senha = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(usuario) && !string.IsNullOrWhiteSpace(senha))
        {
            contas[usuario] = senha;
            Console.WriteLine("Conta criada com sucesso!");
        }
        else
        {
            Console.WriteLine("Nome de usuário ou senha inválidos.");
        }
    }
}
