using GestaoDeEquipamentos.Entities;
using System;
using System.Collections.Generic;

namespace GestaoDeEquipamentos.Telas
{
    class TelaFabricantes
    {
        private List<Fabricantes> fabricantes = new List<Fabricantes>();
        private List<Equipamento> equipamentos;

        public TelaFabricantes(List<Equipamento> equipamentos)
        {
            this.equipamentos = equipamentos;
        }

        public void MenuFabricantes()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("---- MENU DE FABRICANTES ----");
                Console.WriteLine("(1) Cadastrar Fabricante");
                Console.WriteLine("(2) Visualizar Fabricantes");
                Console.WriteLine("(3) Editar Fabricante");
                Console.WriteLine("(4) Excluir Fabricante");
                Console.WriteLine("(5) Voltar");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarFabricante();
                        break;
                    case "2":
                        VisualizarFabricantes();
                        break;
                    case "3":
                        EditarFabricante();
                        break;
                    case "4":
                        ExcluirFabricante();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void CadastrarFabricante()
        {
            Fabricantes fabricante = new Fabricantes();
            fabricante.ID = fabricantes.Count + 1;

            Console.Write("Nome: ");
            fabricante.Nome = Console.ReadLine();

            Console.Write("Email: ");
            fabricante.Email = Console.ReadLine();

            Console.Write("Telefone: ");
            fabricante.Telefone = Console.ReadLine();

            fabricantes.Add(fabricante);
            Console.WriteLine("Fabricante cadastrado com sucesso!");
        }

        private void VisualizarFabricantes()
        {
            if (fabricantes.Count == 0)
            {
                Console.WriteLine("Nenhum fabricante cadastrado.");
                return;
            }

            foreach (var fab in fabricantes)
            {
                int qtdEquipamentos = equipamentos.FindAll(e => e.Fabricante == fab.Nome).Count;
                Console.WriteLine($"ID: {fab.ID} | Nome: {fab.Nome} | Email: {fab.Email} | Telefone: {fab.Telefone} | Equipamentos Registrados: {qtdEquipamentos}");
            }
        }

        private void EditarFabricante()
        {
            Console.Write("Digite o ID do fabricante que deseja editar: ");
            int id = int.Parse(Console.ReadLine());

            Fabricantes fabricante = fabricantes.Find(f => f.ID == id);
            if (fabricante == null)
            {
                Console.WriteLine("Fabricante não encontrado.");
                return;
            }

            Console.Write("Novo Nome: ");
            fabricante.Nome = Console.ReadLine();

            Console.Write("Novo Email: ");
            fabricante.Email = Console.ReadLine();

            Console.Write("Novo Telefone: ");
            fabricante.Telefone = Console.ReadLine();

            Console.WriteLine("Fabricante atualizado com sucesso!");
        }

        private void ExcluirFabricante()
        {
            Console.Write("Digite o ID do fabricante que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            Fabricantes fabricante = fabricantes.Find(f => f.ID == id);
            if (fabricante == null)
            {
                Console.WriteLine("Fabricante não encontrado.");
                return;
            }

            fabricantes.Remove(fabricante);
            Console.WriteLine("Fabricante removido com sucesso!");
        }

        public List<Fabricantes> ObterFabricantes()
        {
            return fabricantes;
        }
    }
}
