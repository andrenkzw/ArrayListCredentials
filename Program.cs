using System;
using System.Collections;
namespace ArrayListCredentials;
class Program
{
    static ArrayList nomes = new ArrayList() {
        "admin"
    };
    static ArrayList senhas = new ArrayList() {
        "12345678"
    };
    static ArrayList tentativas = new ArrayList() {
        0
    };

    static void CadastarUsuario() {
        Console.WriteLine("Insira o nome do usuário:");
        string nomeRecebido = Console.ReadLine()!;
        foreach (string nome in nomes) {
            if (nome == nomeRecebido) {
                Console.WriteLine("Usuário já existente!");
                return;
            }
        }        
        Console.WriteLine("Insira a senha do usuário (deve ter entre 4 e 8 caracteres):");
        string senhaRecebida = Console.ReadLine()!;
        while (senhaRecebida.Length < 4 || senhaRecebida.Length > 8) {
            Console.WriteLine("Senha inválida!");
            Console.WriteLine("Insira a senha do usuário (deve ter entre 4 e 8 caracteres):");
            senhaRecebida = Console.ReadLine()!;
        }
        nomes.Add(nomeRecebido);
        senhas.Add(senhaRecebida);
        tentativas.Add(0);
        Console.WriteLine("Usuário cadastrado com sucesso!");
    }

    static void Login() {
        Console.WriteLine("Insira o nome do usuário:");
        string nome = Console.ReadLine()!;
        int indice = -1;
        for (indice = 0; indice < nomes.Count; indice++) {
            if ((string)nomes[indice] == nome) {
                break;
            }
        }
        if (indice == nomes.Count) {
            Console.WriteLine("Usuário não cadastrado!");
            return;
        }
        else if ((int)tentativas[indice] == 3) {
            Console.WriteLine("Usuário bloqueado!");
            return;
        }
        Console.WriteLine($"Insira a senha para {nome}:");
        string senha = Console.ReadLine()!;
        int tentativa = (int)tentativas[indice];
        if ((string)senhas[indice] != senha) {
            Console.WriteLine("Senha incorreta!");
            tentativa++;
            tentativas[indice] = tentativa;
            return;
        }
        Console.WriteLine("Login efetuado com sucesso.");
    }

    static void Main(string[] args)
    {
        string comando = "";
        while (comando.ToLower() != "sair") {
            Console.WriteLine("Insira um dos seguintes comandos:");
            Console.WriteLine("  [1] Cadastrar novo usuário");
            Console.WriteLine("  [2] Login");
            Console.WriteLine("  [SAIR] Encerrar aplicativo");
            comando = Console.ReadLine()!;
            if (comando.ToLower() == "sair") break;
            switch (comando) {
                case "1":
                    CadastarUsuario();
                    break;
                case "2":
                    Login();
                    break;
                default:
                    Console.WriteLine("Comando inválido");
                    break;
            }
        }
    }
}
