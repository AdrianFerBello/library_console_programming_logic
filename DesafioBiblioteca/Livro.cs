using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DesafioBiblioteca
{
    public class Livro
    {
        public int Id { get; set; }
        public string  Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int AnoDePublicação { get; set; }

        public Livro() { }

        public Livro(int id, string titulo, string autor, string ISBN, int anoDePublicação)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            this.ISBN = ISBN;
            AnoDePublicação = anoDePublicação;
        }

        public override string ToString()
        {
            return $" Id : {Id}, Nome: {Titulo}, Autor: {Autor}, ISBN: {ISBN}, AnoPUB: {AnoDePublicação}";
        }
    }
}