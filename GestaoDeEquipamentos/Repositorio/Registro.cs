using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoDeEquipamentos.Entities;

namespace GestaoDeEquipamentos.Repositorio
{
    class Registro<T>
    {
        protected List<T> list = new List<T>();
        
        public virtual void Adicionar(T t) { list.Add(t); Console.WriteLine("Item adicionado com sucesso!"); }
        public virtual void Remover(T t) { list.Remove(t); Console.WriteLine("Item Removido com sucesso!"); }
        public virtual void Visualizar()
        {
            if (list.Count == 0) { Console.WriteLine("Nenhum item encontrado"); return; }
            list.ForEach(t => Console.WriteLine(t));
        }
        public virtual List<T> ObterTodos()
        {
            return list;
        }

    }
}
