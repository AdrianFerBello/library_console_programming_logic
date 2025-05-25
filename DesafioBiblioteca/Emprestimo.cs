using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBiblioteca
{
    public class Emprestimo
    {
        public int Id  { get; set; }
        public int IdUsuario { get; set; }
        public int IdLivro { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataDevoluçao { get; set; }
        public decimal MultaPorDia { get; set; }

        public Emprestimo() { }

        public Emprestimo(int id, int idUsuario, int idLivro, DateTime dataEmissao, DateTime dataDevoluçao, decimal multaPorDia)
        {
            Id = id;
            IdUsuario = idUsuario;
            IdLivro = idLivro;
            DataEmissao = dataEmissao;
            DataDevoluçao = dataDevoluçao;
            MultaPorDia = multaPorDia;
        }
    }
}
