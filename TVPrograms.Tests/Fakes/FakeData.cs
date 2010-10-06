using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVPrograms.Core.Domain.Model;

namespace TVPrograms.Tests.Fakes
{
    public class FakeData
    {
        public static Network CreateNetwork()
        {
            Network network = new Network();
            network.NetworkInitials = "Fox";
            network.NetworkName = "Fox";
            network.Programs = CreatePrograms();
            return network;
        }

        public static List<Network> CreateNetworks()
        {
            List<Network> networks = new List<Network>();

            for (int i = 1; i <= 10; i++)
            {
                Network network = CreateNetwork();
                network.id = i;
                networks.Add(network);
            }

            return networks;
        }

        public static Program CreateProgram()
        {
            Program program = new Program();
            program.ProgramName = "House";
            program.Network_id = 1;
            program.Daypart_id = 1;

            return program;
        }

        public static List<Program> CreatePrograms()
        {
            List<Program> programs = new List<Program>();

            for (int i = 1; i <= 10; i++)
            {
                Program program = CreateProgram();
                program.id = i;
                programs.Add(program);
            }

            return programs;
            
        }


    }
}
