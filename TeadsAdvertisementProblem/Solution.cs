using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()); // the number of adjacency relations

        var nodes = new Dictionary<int, Node>();

        for (int i = 0; i < n; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int xi = int.Parse(inputs[0]); // the ID of a person which is adjacent to yi
            int yi = int.Parse(inputs[1]); // the ID of a person which is adjacent to xi

            var firstNode = new Node(xi);
            if (nodes.ContainsKey(xi))
            {
                firstNode = nodes[xi];
            }
            else
            {
                nodes.Add(xi, firstNode);
            }

            var secondNode = new Node(yi);
            if (nodes.ContainsKey(yi))
            {
                secondNode = nodes[yi];
            }
            else
            {
                nodes.Add(yi, secondNode);
            }
            firstNode.Neighbors.Add(secondNode);
            secondNode.Neighbors.Add(firstNode);
        }

        var minSteps = 0;
        while (nodes.Count > 1)
        {
            minSteps++;
            var leafNodes = nodes.Values.Where(node => node.Neighbors.Count == 1).ToList();
            foreach (var node in leafNodes)
            {
                nodes.Remove(node.Value);
                node.Neighbors.ToList().ForEach(neighbor => neighbor.Neighbors.Remove(node));
            }
        }
        
        Console.WriteLine(minSteps);
    }
}

public class Node
{
    public int Value { get; }
    public HashSet<Node> Neighbors = new HashSet<Node>();

    public Node(int value)
    {
        Value = value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        return ((Node)obj).Value == Value;
    }
}