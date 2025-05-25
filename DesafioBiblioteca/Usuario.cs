using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBiblioteca
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public Usuario() { }

        public Usuario(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public override string ToString() {
            return $" Id usuario: {Id}, Nome: {Nome}, Email: {Email}";
        }

    }
}
