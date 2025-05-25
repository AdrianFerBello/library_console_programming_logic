using DesafioBiblioteca;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace DesafioBiblioteca
{
    public class Program
    {
        //lista global de livros
        static List<Livro> listLivro = new List<Livro>
        {
            new Livro(1, "A Revolução dos Bichos", "George Orwell", "9780451526342", 1945),
            new Livro(2, "O Alquimista", "Paulo Coelho", "9780061122415", 1988),
            new Livro(3, "Harry Potter e a Pedra Filosofal", "J.K. Rowling", "9780439708180", 1997),
            new Livro(4, "O Código Da Vinci", "Dan Brown", "9780307474278", 2003)
        };


        //lista global de Usuarios
        static List<Usuario> listUsuario = new List<Usuario>
        {
            new Usuario(1, "Alice Santos", "alice.santos@email.com"),
            new Usuario(2, "Bruno Lima", "bruno.lima@email.com"),
            new Usuario(3, "Carla Oliveira", "carla.oliveira@email.com"),
            new Usuario(4, "Diego Pereira", "diego.pereira@email.com")
        };

        //lista global de Emprestimos
        static List<Emprestimo> listEmprestimos = new List<Emprestimo>();

        static void Main(string[] args)
        {
            MenuPrincipal();
        }

        static void MenuPrincipal()
        {
            var continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("---------------BEM VINDO A BIBLIOTECA ---------------");
                Console.WriteLine("---------------------- MENU ----------------");
                Console.WriteLine();
                Console.WriteLine(" ========== Cadastros =============");
                Console.WriteLine("1. Cadastrar um Livro");
                Console.WriteLine("2. Cadastrar um Usuario");
                Console.WriteLine("3. Cadastrar um Emprestimo");
                Console.WriteLine();
                Console.WriteLine("=========== Consultas ============= ");
                Console.WriteLine("4. Consultar Livros");
                Console.WriteLine("5. Consultar Usuarios");
                Console.WriteLine("6. Consultar Emprestimos");
                Console.WriteLine();
                Console.WriteLine("======== DEVOLUÇÕES E REMOÇAO ======");
                Console.WriteLine("7. Devolver um Livro");
                Console.WriteLine("8. Remover Livros ");
                Console.WriteLine("9. SAIR");


                Console.WriteLine();
                Console.Write("Digite uma opção: ");

                int opção = int.Parse(Console.ReadLine());


                switch (opção)
                {
                    case 1:
                        CadastrarLivro();
                        break;

                    case 2:
                        CadastrarUsuario();
                        break;

                    case 3:
                        CadastrarEmprestimo();
                        break;

                    case 4:
                        ConsultarLivros();
                        break;

                    case 5:
                        ConsultarUSuarios();
                        break;

                    case 6:
                        ListaEmprestimos();
                        break;

                    case 7:
                        DevolverLivro();
                        break;
                    case 8:
                        RemoverLivro();
                        break;

                    case 9:
                        continuar = false;
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção invalida!! Voltar ao menu");
                        Console.ReadKey();
                        break;

                }
            }
        }

        static void CadastrarLivro()
        {
            Console.Clear();
            Console.WriteLine("------ Cadastrando um Livro ------");
            Console.Write("Digite o Id do livro: ");
            int id = int.Parse(Console.ReadLine());

            if (listLivro.Exists(livro => livro.Id == id))
            {
                Console.WriteLine("Livro com Id ja existente, Digite o Id novamente: ");
                id = int.Parse(Console.ReadLine());

                while (listLivro.Exists(livro => livro.Id == id))
                {
                    Console.WriteLine("Id existente, digite novamente: ");
                    id = int.Parse(Console.ReadLine());
                }
            }

            Console.Write("Digite o Titulo do livro: ");
            string titulo = Console.ReadLine();
            Console.Write("Digite o nome do autor: ");
            string autor = Console.ReadLine();
            Console.Write("Digite o ISBN do livro: ");
            string isbn = Console.ReadLine();
            Console.Write("Digite o Ano de Publicação: ");
            int anoDePublicação = int.Parse(Console.ReadLine());
            Console.WriteLine();


            listLivro.Add(new Livro
            {
                Id = id,
                Titulo = titulo,
                Autor = autor,
                ISBN = isbn,
                AnoDePublicação = anoDePublicação,
            });

            Console.Write("Livro criado com sucesso !!!!");
            Console.ReadKey();
        }
        static void ConsultarLivros()
        {
            Console.Clear();

            Console.WriteLine("----- Livros Cadastrados -------");

            {
                if (listLivro.Count == 0)
                {
                    Console.WriteLine("Nao há Livros Cadastrados");
                }

                else
                {
                    var orderById = listLivro.OrderBy(x => x.Id);

                    foreach (var livros in orderById)
                    {
                        Console.WriteLine(livros);
                    }
                }

                Console.ReadKey();
            }
        }
        /*static void ConsultarEmprestimos()
        {
            //arrumar função essa consulta deve ser de emprestimos
            Console.Clear();

            Console.WriteLine("------- Consultar Um Emprestimo --------");
            Console.Write("Digite o id do Emprestimo: ");
            int id = int.Parse(Console.ReadLine());

            Emprestimo emprestimo = listEmprestimos.FirstOrDefault(emp => emp.Id == id);

            if (emprestimo != null)
            {
                Console.WriteLine($"ID do Emprestimo: {emprestimo.Id}, ID do usuario: {emprestimo.IdUsuario}, Data Emissao: {emprestimo.DataEmissao}, Data Devoluçao Prevista: {emprestimo.DataDevoluçao}");
            }

            else
            {
                Console.WriteLine("Emprestimo não existente!!!");
            }

            Console.ReadKey();

        }*/
        static void RemoverLivro()
        {
            Console.Clear();

            Console.WriteLine("------- Remover Livro --------");

            Console.Write("Digite o Id do livro p/ remover: ");
            int id = int.Parse(Console.ReadLine());

            if (listLivro.Exists(livro => livro.Id == id))
            {
                listLivro.RemoveAll(livro => livro.Id == id);
                Console.WriteLine("Livro Removido com Sucesso!!!");
            }

            else
            {
                Console.WriteLine("Livro inexistente !!");
            }

            Console.ReadKey();
        }
        static void CadastrarUsuario()
        {
            Console.Clear();
            Console.WriteLine("------ Cadastro de Usuario ------");
            Console.Write("Digite o Id do Usuario: ");
            int id = int.Parse(Console.ReadLine());

            if (listUsuario.Exists(usuario => usuario.Id == id))
            {
                Console.WriteLine("Usuario com Id ja existente, Digite o Id novamente: ");
                id = int.Parse(Console.ReadLine());

                while (listUsuario.Exists(usuario => usuario.Id == id))
                {
                    Console.WriteLine("Id existente, digite novamente: ");
                    id = int.Parse(Console.ReadLine());
                }
            }

            Console.Write("Digite o Nome do Usuario: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o Email do Usuario: ");
            string email = Console.ReadLine();
            Console.WriteLine();


            listUsuario.Add(new Usuario
            {
                Id = id,
                Nome = nome,
                Email = email,
            });

            Console.Write("Usuario criado com sucesso !!!!");
            Console.ReadKey();
        }
        static void CadastrarEmprestimo()
        {
            Console.Clear();

            Console.WriteLine("--------- Cadastrar um Emprestimo ---------");
            Console.Write("Digite o Id do Emprestimo: ");
            int idEmprestimo = int.Parse(Console.ReadLine());

            if (listEmprestimos.Exists(Emprestimo => Emprestimo.Id == idEmprestimo))
            {
                Console.WriteLine("Emprestimo com Id ja existente, Digite o Id novamente: ");
                idEmprestimo = int.Parse(Console.ReadLine());

                while (listEmprestimos.Exists(Emprestimo => Emprestimo.Id == idEmprestimo))
                {
                    Console.WriteLine("IdEmprestimo existente, digite novamente: ");
                    idEmprestimo = int.Parse(Console.ReadLine());
                }
            }

            Console.Write("Digite o Id do Livro a ser emprestado: ");
            int idLivroEmprestado = int.Parse(Console.ReadLine());

            Console.Write("Digite o Id do Usuario: ");
            int idUsuario = int.Parse(Console.ReadLine());

            double multaPorDia = 0;

            DateTime dataEmissao = new DateTime();
            dataEmissao = DateTime.Today;

            var dataDevolução = dataEmissao.AddDays(30);

            listEmprestimos.Add(new Emprestimo
            {
                Id = idEmprestimo,
                IdLivro = idLivroEmprestado,
                IdUsuario = idUsuario,
                DataEmissao = dataEmissao,
                DataDevoluçao = dataDevolução,
                MultaPorDia = (decimal)multaPorDia,
            });


            //verificando se Usuario existe
            if (listUsuario.Exists(usuario => usuario.Id == idUsuario))
            {
                //Verifica se o livro existe na lista de livros
                if (listLivro.Exists(x => x.Id == idLivroEmprestado))
                {
                    Console.WriteLine("Emprestimo cadastrado com Sucesso !!!!");
                }
                else
                {
                    Console.WriteLine("O Livro nao pode ser emprestado, pois ele nao existe !!!");

                }
            }
            else
            {
                Console.WriteLine("Usuario nao existe !!!");
            }


            Console.ReadKey();

        }
        static void DevolverLivro()
        {
            Console.Clear();
            Console.Clear();
            Console.WriteLine("--------- Devolver um Livro ---------");
            Console.Write("Digite o Id do Livro para Devolução: ");
            if (!int.TryParse(Console.ReadLine(), out int idLivro))
            {
                Console.WriteLine("ID do Livro inválido!");
                return;
            }

            Console.Write("Digite o Id do Usuário que vai devolver: ");
            if (!int.TryParse(Console.ReadLine(), out int idUsuario))
            {
                Console.WriteLine("ID do Usuário inválido!");
                return;
            }

            // Verifica se o usuário existe
            if (!listUsuario.Exists(usuario => usuario.Id == idUsuario))
            {
                Console.WriteLine("Usuário não existe!");
                return;
            }

            // Verifica se o livro está na lista de empréstimos
            var emprestimo = listEmprestimos.FirstOrDefault(e => e.IdLivro == idLivro && e.IdUsuario == idUsuario);
            if (emprestimo == null)
            {
                Console.WriteLine("O livro não está emprestado ou não pertence a esse usuário.");
                return;
            }

            // Verifica atrasos e calcula multas
            if (DateTime.Now < emprestimo.DataDevoluçao || DateTime.Now > emprestimo.DataDevoluçao)
            {
                TimeSpan atraso = DateTime.Now - emprestimo.DataDevoluçao;
                decimal multa = (decimal)atraso.Days * emprestimo.MultaPorDia;

                Console.WriteLine($"Livro: {listLivro.FirstOrDefault(l => l.Id == idLivro)?.Titulo}");
                Console.WriteLine($"Usuário: {listUsuario.FirstOrDefault(u => u.Id == idUsuario)?.Nome}");
                Console.WriteLine($"Atrasado por {atraso.Days} dias. Multa: R$ {multa:F2}");

                Console.Write("Multa paga? [S / N]: ");
                char resposta = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (resposta != 'S')
                {
                    Console.WriteLine("Infelizmente não podemos dar baixa no empréstimo sem o pagamento da multa.");
                    return;
                }

                Console.WriteLine("Pagamento efetuado! Multa quitada.");
            }
            else
            {
                Console.WriteLine("Devolução dentro do prazo.");
            }

            // Remove o empréstimo
            listEmprestimos.Remove(emprestimo);
            Console.WriteLine("Livro devolvido com sucesso!");
            Console.ReadKey();

        }
        static void ConsultarUSuarios()
        {
            Console.Clear();

            var orderByIdUsers = listUsuario.OrderBy(x => x.Id);

            Console.WriteLine("----------| Lista de Usuarios | -------- ");
            Console.WriteLine();

            foreach (var usuarios in orderByIdUsers)
            {
                Console.WriteLine(usuarios);
                Console.WriteLine("-------------------------------------------------------------------------");
            }
            Console.ReadKey();
        }
        static void ListaEmprestimos()
        {
            Console.Clear();

            Console.WriteLine("-------------- Consultar Emprestimos ----------");
            Console.WriteLine();

            var orderByIdEmprestimos = listEmprestimos.OrderBy(x => x.Id);

            if (orderByIdEmprestimos != null)
            {
                foreach (var emprestimo in orderByIdEmprestimos)
                {
                    Console.WriteLine($"ID Emprestimo: {emprestimo.Id} ,ID do usuario: {emprestimo.IdUsuario}, ID do livro: {emprestimo.IdLivro}, Data Emissao: {emprestimo.DataEmissao}, Data Devoluçao Prevista: {emprestimo.DataDevoluçao}");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Nao Existe emprestimos !!!");
            }

            Console.ReadKey();
        }
    }
}