using GestaoDeEquipamentos.Entities;

namespace GestaoDeEquipamentos.Telas
{
    class TelaMenu
    {
        public void Menu()
        {
            List<Equipamento> equipamentosCompartilhados = new List<Equipamento>();
            List<Fabricantes> fabricantesCompartilhados = new List<Fabricantes>();

            TelaEquipamentos telaEquipamentos = new TelaEquipamentos(fabricantesCompartilhados, equipamentosCompartilhados);
            TelaFabricantes telaFabricantes = new TelaFabricantes(equipamentosCompartilhados, fabricantesCompartilhados);
            TelaChamados telaChamados = new TelaChamados(equipamentosCompartilhados);


            while (true)
            {
                Console.Clear();
                Console.WriteLine("---- GESTÃO DE EQUIPAMENTOS ----");
                Console.WriteLine("(1) Gerir Equipamentos");
                Console.WriteLine("(2) Gerir Chamados");
                Console.WriteLine("(3) Gerir Fabricantes");
                Console.WriteLine("(4) Sair");
                Console.Write("Escolha uma opção: ");

                string entrada = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(entrada)) continue;

                char opcao = entrada[0];

                switch (opcao)
                {
                    case '1':
                        telaEquipamentos.MenuEquipamento();
                        break;
                    case '2':
                        telaChamados.MenuChamados();
                        break;
                    case '3':
                        telaFabricantes.MenuFabricantes();
                        break;
                    case '4':
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}