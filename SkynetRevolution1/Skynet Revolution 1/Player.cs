using System;
using System.Collections.Generic;
using System.Linq;

namespace SkynetRevolution1.Skynet_Revolution_1
{
    /**
     * Auto-generated code below aims at helping you parse
     * the standard input according to the problem statement.
     **/
    class Player
    {
        public static void Main(string[] args)
        {
            string[] inputs;
            inputs = Console.ReadLine().Split(' ');
            int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
            int L = int.Parse(inputs[1]); // the number of links
            int E = int.Parse(inputs[2]); // the number of exit gateways

            var Links = new List<Link>();
            var Gateways = new List<int>();

            for (int i = 0; i < L; i++)
            {
                inputs = Console.ReadLine()?.Split(' ');
                Links.Add(new Link(){FirstNode = int.Parse(inputs[0]), SecondNode = int.Parse(inputs[1])});
            }
            for (int i = 0; i < E; i++)
            {
                Gateways.Add(int.Parse(Console.ReadLine()));
            }

            // game loop
            while (true)
            {
                int virusNode = int.Parse(Console.ReadLine()); // The index of the node on which the Skynet agent is positioned this turn

                BreakLink(Links, Gateways, virusNode);
            }
        }

        public static void BreakLink(List<Link> links, List<int> gateways, int virusNode)
        {
            foreach(var gatewayNode in gateways)
            {

                if (links.Any(link => link.ContainsNode(virusNode) && link.ContainsNode(gatewayNode)))
                {
                    var possiblyGatewayNodeToBreak = links.First(link => link.ContainsNode(virusNode) && link.ContainsNode(gatewayNode));
                    Console.WriteLine($"{possiblyGatewayNodeToBreak.FirstNode} {possiblyGatewayNodeToBreak.SecondNode}");
                    links.Remove(possiblyGatewayNodeToBreak);
                    return;
                }
            }

            var possibleLinkToBreak =
                links.DefaultIfEmpty(null).FirstOrDefault(link => link.FirstNode == virusNode || link.SecondNode == virusNode);

            if (possibleLinkToBreak != null)
            {
                Console.WriteLine($"{possibleLinkToBreak.FirstNode} {possibleLinkToBreak.SecondNode}");
                links.Remove(possibleLinkToBreak);
            }
        }
    }

    public class Link
    {
        public int FirstNode { get; set; }
        public int SecondNode { get; set; }

        public bool ContainsNode(int node)
        {
            return FirstNode == node || SecondNode == node;
        }
    }
}
