using System;
using System.Collections.Generic;

namespace GestaoDeEquipamentos.Repositorio
{
    class Registro<T>
    {
        protected string nomeEntidade;
        protected List<T> list = new List<T>();
        public Registro(string entidade)
        {
            this.nomeEntidade = entidade;
            this.list = new List<T>();
        }
        public virtual void Adicionar(T t)
        {
            list.Add(t);
            Console.WriteLine($"{typeof(T).Name} adicionado com sucesso!");
        }

        public virtual void Remover(T t)
        {
            list.Remove(t);
            Console.WriteLine($"{typeof(T).Name} removido com sucesso!");
        }

        public virtual void Visualizar()
        {
            if (list.Count == 0)
            {
                Console.WriteLine($"Nenhum {typeof(T).Name.ToLower()} encontrado.");
                return;
            }

            list.ForEach(item => Console.WriteLine(item));
        }

        public virtual List<T> ObterTodos()
        {
            return list;
        }

        public virtual char ApresentarMenu()
        {
            string nomeEntidade = typeof(T).Name;
            Console.Clear();
            Console.WriteLine($"---- MENU DE {nomeEntidade.ToUpper()} ----");
            Console.WriteLine($"(1) Cadastrar {nomeEntidade}");
            Console.WriteLine($"(2) Visualizar {nomeEntidade}");
            Console.WriteLine($"(3) Editar {nomeEntidade}");
            Console.WriteLine($"(4) Excluir {nomeEntidade}");
            Console.WriteLine($"(5) Voltar");
            Console.Write("Escolha uma opção: ");

            return Console.ReadKey().KeyChar;
        }

    }
}
