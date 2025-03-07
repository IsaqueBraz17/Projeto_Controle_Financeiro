using System;

class Program
{
    static void Main()
    {
        Cadastro_Contas cadastroContas = new Cadastro_Contas();
        CadastroSalarios cadastroSalarios = new CadastroSalarios();
        Cadastro_Despesas cadastroDespesas = new Cadastro_Despesas();

        // Inicia o menu de conta (login/criação de conta)
        if (cadastroContas.AcessarOuCriarConta())
        {
            // Após acessar ou criar conta, vai para o menu de cadastro de salários
            if (cadastroSalarios.MenuPrincipal())
            {
                // Depois do cadastro de salários, inicia o menu de cadastro de despesas
                cadastroDespesas.CalcularDespesas();
            }
        }

        Console.WriteLine("Programa finalizado. Obrigado por usar nosso sistema!");
    }
}