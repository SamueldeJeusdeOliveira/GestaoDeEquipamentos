using GestaoDeEquipamentos.Entities;
using System;
using System.Collections.Generic;

namespace GestaoDeEquipamentos.Telas
{
    class TelaMenu
    {
        public void Menu()
        {
            List<Equipamento> equipamentosCompartilhados = new List<Equipamento>();
            TelaEquipamentos telaEquipamentos = new TelaEquipamentos(equipamentosCompartilhados);
            TelaChamados telaChamados = new TelaChamados(equipamentosCompartilhados);
            TelaFabricantes telaFabricantes = new TelaFabricantes(equipamentosCompartilhados);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("GESTÃO DE EQUIPAMENTOS");
                Console.WriteLine("(1) Gerir Equipamentos");
                Console.WriteLine("(2) Gerir Chamados");
                Console.WriteLine("(3) Gerir Fabricantes");
                Console.WriteLine("(4) Sair");
                char opcao = char.Parse(Console.ReadLine());

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
                    default:
                        return;
                }
            }
        }
    }
}
