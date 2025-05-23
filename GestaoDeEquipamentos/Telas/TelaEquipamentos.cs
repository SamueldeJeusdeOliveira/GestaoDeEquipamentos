using GestaoDeEquipamentos.Entities;
using GestaoDeEquipamentos.Repositorio;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GestaoDeEquipamentos.Telas
{
    class TelaEquipamentos : Registro<Equipamento>
    {
        private List<Fabricantes> fabricantes;

        public TelaEquipamentos(List<Fabricantes> listaFabricantes, List<Equipamento> equipamentosList) : base("Equipamentos")
        {
            fabricantes = listaFabricantes;
            this.list = equipamentosList; 
        }

        public void MenuEquipamento()
        {
            while (true)
            {
                switch (ApresentarMenu())
                {
                    case '1':
                        Cadastrar();
                        break;
                    case '2':
                        Visualizar();
                        break;
                    case '3':
                        Editar();
                        break;
                    case '4':
                        Excluir();
                        break;
                    case '5':
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void Cadastrar()
        {
            Console.Clear();

            Console.Write("Nome (mínimo 6 caracteres): ");
            string nome = Console.ReadLine();
            if (nome.Length < 6)
            {
                Console.WriteLine("Nome inválido.");
                return;
            }

            Console.Write("Preço de aquisição: ");
            if (!double.TryParse(Console.ReadLine(), out double preco))
            {
                Console.WriteLine("Preço inválido.");
                return;
            }

            Console.Write("Número de série: ");
            string numSerie = Console.ReadLine();

            Console.Write("Data de fabricação (dd/mm/aaaa): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataFab))
            {
                Console.WriteLine("Data inválida.");
                return;
            }

            if (fabricantes.Count == 0)
            {
                Console.WriteLine("Nenhum fabricante cadastrado. Cadastre um fabricante antes.");
                return;
            }

            Console.WriteLine("Escolha o fabricante:");
            for (int i = 0; i < fabricantes.Count; i++)
            {
                Console.WriteLine($"({i + 1}) {fabricantes[i].Nome}");
            }

            if (!int.TryParse(Console.ReadLine(), out int escolha) || escolha < 1 || escolha > fabricantes.Count)
            {
                Console.WriteLine("Opção inválida.");
                return;
            }

            Equipamento equipamento = new Equipamento(
                iD: list.Count + 1,
                nome: nome,
                precoAquisicao: preco,
                numSerie: numSerie,
                dataFabricacao: dataFab,
                fabricante: fabricantes[escolha - 1]
            );

            Adicionar(equipamento);
            Console.WriteLine("Equipamento registrado com sucesso!");
        }

        private void Visualizar()
        {
            Console.Clear();

            if (list.Count == 0)
            {
                Console.WriteLine("Nenhum equipamento cadastrado.");
                return;
            }

            foreach (Equipamento item in list)
            {
                Console.WriteLine($"ID: {item.ID} || NOME: {item.Nome} || PREÇO: {item.PrecoAquisicao:C} || Nº DE SÉRIE: {item.NumSerie} || FABRICADO EM: {item.DataFabricacao:dd/MM/yyyy} || FABRICANTE: {item.Fabricante?.Nome}");
            }
        }

        private void Editar()
        {
            Console.Clear();
            Visualizar();

            Console.Write("\nDigite o ID do equipamento a editar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Equipamento equipamento = list.Find(e => e.ID == id);
            if (equipamento == null)
            {
                Console.WriteLine("Equipamento não encontrado.");
                return;
            }

            Console.Write("Novo nome: ");
            string nome = Console.ReadLine();
            if (nome.Length < 6)
            {
                Console.WriteLine("Nome deve ter no mínimo 6 caracteres.");
                return;
            }

            Console.Write("Novo preço: ");
            if (!double.TryParse(Console.ReadLine(), out double preco))
            {
                Console.WriteLine("Preço inválido.");
                return;
            }

            Console.Write("Novo número de série: ");
            string numSerie = Console.ReadLine();

            Console.Write("Nova data de fabricação (dd/mm/aaaa): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime data))
            {
                Console.WriteLine("Data inválida.");
                return;
            }

            Console.WriteLine("Escolha o novo fabricante:");
            for (int i = 0; i < fabricantes.Count; i++)
            {
                Console.WriteLine($"({i + 1}) {fabricantes[i].Nome}");
            }

            if (!int.TryParse(Console.ReadLine(), out int escolha) || escolha < 1 || escolha > fabricantes.Count)
            {
                Console.WriteLine("Fabricante inválido.");
                return;
            }

            equipamento.AtualiazaDados(nome, preco, numSerie, data, fabricantes[escolha - 1]);
            Console.WriteLine("Equipamento atualizado com sucesso!");
        }

        private void Excluir()
        {
            Console.Clear();
            Visualizar();

            Console.Write("\nDigite o ID do equipamento a excluir: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Equipamento equipamento = list.Find(e => e.ID == id);
            if (equipamento == null)
            {
                Console.WriteLine("Equipamento não encontrado.");
                return;
            }

            Remover(equipamento); 
            Console.WriteLine("Equipamento excluído com sucesso.");
        }

        public List<Equipamento> ObterEquipamentos()
        {
            return list;
        }
    }
}
