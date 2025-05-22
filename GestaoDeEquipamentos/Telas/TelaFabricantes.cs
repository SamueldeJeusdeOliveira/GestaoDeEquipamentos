using GestaoDeEquipamentos.Entities;
using GestaoDeEquipamentos.Repositorio;

namespace GestaoDeEquipamentos.Telas
{
    class TelaFabricantes : Registro<Fabricantes>
    {
        private List<Equipamento> equipamentos;
        private List<Fabricantes> fabricantes;
        public TelaFabricantes(List<Equipamento> equipamentos, List<Fabricantes> fabricantesList)
        {
            fabricantes = fabricantesList;
            this.equipamentos = equipamentos;
            this.list = fabricantesList;
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
                        Cadastrar();
                        break;
                    case "2":
                        Visualizar();
                        break;
                    case "3":
                        Editar();
                        break;
                    case "4":
                        Excluir();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void Cadastrar()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            var fabricante = new Fabricantes(list.Count+1, nome, email, telefone);
            Adicionar(fabricante);
            Console.WriteLine("Fabricante cadastrado com sucesso!");
        }

        private void Visualizar()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Nenhum fabricante cadastrado.");
                return;
            }

            foreach (var fab in list)
            {
                int qtdEquipamentos = equipamentos.FindAll(e => e.Fabricante == fab).Count;
                Console.WriteLine($"\nID: {fab.ID} | Nome: {fab.Nome} | Email: {fab.Email} | Telefone: {fab.Telefone} | Equipamentos Registrados: {qtdEquipamentos}");
            }
        }

        private void Editar()
        {
            Console.Write("Digite o ID do fabricante que deseja editar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido!");
                return;
            }

            var fabricante = list.Find(f => f.ID == id);
            if (fabricante == null)
            {
                Console.WriteLine("Fabricante não encontrado.");
                return;
            }

            Console.Write("Novo Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Novo Email: ");
            string email = Console.ReadLine();

            Console.Write("Novo Telefone: ");
            string telefone = Console.ReadLine();

            fabricante.AtualiazaDados(nome, email, telefone);
            Console.WriteLine("Fabricante atualizado com sucesso!");
        }

        private void Excluir()
        {
            Console.Write("Digite o ID do fabricante que deseja excluir: ");
            if (!int.TryParse(Console.ReadLine(), out int id)){Console.WriteLine("ID inválido!");return;}

            var fabricante = list.Find(f => f.ID == id);
            if (fabricante == null)
            {
                Console.WriteLine("Fabricante não encontrado.");
                return;
            }

            // Verifica se há equipamentos vinculados a este fabricante
            bool temEquipamentos = equipamentos.Exists(e => e.Fabricante == fabricante);
            if (temEquipamentos)
            {
                Console.WriteLine("Não é possível excluir. Existem equipamentos vinculados a este fabricante.");
                return;
            }

            Remover(fabricante);
            Console.WriteLine("Fabricante removido com sucesso!");
        }

        public List<Fabricantes> ObterFabricantes()
        {
            return list;
        }
    }
}
