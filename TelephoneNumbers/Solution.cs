using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        var trie = new List<TeleNode>();
        for (int i = 0; i < N; i++)
        {
            var phoneNumber = Console.ReadLine();
            Console.Error.WriteLine(phoneNumber);
            TeleNode currentNode = null;
            foreach(char c in phoneNumber.ToCharArray())
            {
                int digit = Int32.Parse(c.ToString());
                if (currentNode == null)
                {
                    if (trie.All(tn => tn.Value != digit))
                    {
                        currentNode = new TeleNode() {Value = digit};
                        trie.Add(currentNode);
                    }
                    else
                    {
                        currentNode = trie.First(tn => tn.Value == digit);
                    }
                }
                else if (currentNode.Children.Any(child => child.Value == digit))
                {
                    currentNode = currentNode.Children.First(child => child.Value == digit);
                }
                else
                {
                    var newNode = new TeleNode(){Value = digit};
                    currentNode.Children.Add(newNode);
                    currentNode = newNode;
                }
            }
        }

        Console.WriteLine(trie.Select(tn => tn.Length()).Sum());
    }
}

class TeleNode
{
    public int Value { get; set; }
    public List<TeleNode> Children = new List<TeleNode>();

    public int Length()
    {
        return 1 + Children.Select(tn => tn.Length()).Sum();
    }
}