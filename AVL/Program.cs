using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace Zadanie
{

    class Program
    {
        class Node // Wezel
        {
            public int key, height;

            public Node left;
            public Node right;

            public Node(int d)
            {
                key = d;
                height = 1;
            }
        }
        public class AVL
        {
            Node root;

            int wysokosc(Node N)
            {
                if (N == null)
                {
                    return 0;
                }
                else
                {
                    return N.height;
                }
            }

            int maks(int a, int b)
            {
                if (a > b)
                {
                    return a;
                }
                else
                {
                    return b;
                }
            }
            int balans(Node N)
            {
                if (N == null)
                {
                    return 0;
                }
                else
                {
                    return wysokosc(N.left) - wysokosc(N.right);
                }

            }

            Node lewaRotacja(Node x)
            {
                Node y = x.right;
                Node help = y.left;

                y.left = x;
                x.right = help;

                x.height = maks(wysokosc(x.left), wysokosc(x.right)) + 1;
                y.height = maks(wysokosc(y.left), wysokosc(y.right)) + 1;

                return y;
            }
            Node prawaRotacja(Node y)
            {
                Node x = y.left;
                Node help = x.right;

                x.right = y;
                y.left = help;

                y.height = maks(wysokosc(y.left), wysokosc(y.right)) + 1;
                x.height = maks(wysokosc(x.left), wysokosc(x.right)) + 1;

                return x;
            }

            Node insert(Node node, int key)
            {
                if (node == null)
                {
                    return (new Node(key));
                }

                if (key < node.key)
                {
                    node.left = insert(node.left, key);
                }
                else if (key > node.key)
                {
                    node.right = insert(node.right, key);
                }
                else
                {
                    return node;
                }

                node.height = 1 + maks(wysokosc(node.left), wysokosc(node.right));

                int balance = balans(node);

                if (balance > 1 && key < node.left.key) // RR
                {
                    return prawaRotacja(node);
                }

                if (balance < -1 && key > node.right.key) // LL
                {
                    return lewaRotacja(node);
                }

                if (balance > 1 && key > node.left.key) // LR
                {
                    node.left = lewaRotacja(node.left);
                    return prawaRotacja(node);
                }

                if (balance < -1 && key < node.right.key) // RL
                {
                    node.right = prawaRotacja(node.right);
                    return lewaRotacja(node);
                }

                return node;
            }

            void KLP (Node node, StreamWriter writer)
            {
                if (node != null)
                {
                    writer.Write(node.key + " ");
                    KLP(node.left, writer);
                    KLP(node.right, writer);
                }
            }

            public static void Main(string[] args)
            {

                AVL tree = new AVL();

                FileStream inFile = new FileStream("InTest.txt", FileMode.Open, FileAccess.Read);
                FileStream outFile = new FileStream("OutTest.txt", FileMode.Truncate, FileAccess.Write);
                using var reader = new StreamReader(inFile);
                using var writer = new StreamWriter(outFile);

                Random rand = new Random();
                int liczba;

                string line;
                string[] splitLine;
                int n;

                line = reader.ReadLine();
                int[] numbers = line.Split(' ').Select(int.Parse).ToArray();
                n = numbers.Length;

                int tryb = 2;
                if (tryb == 1)
                {
                    for (int i = 0; i < n; i++)
                    {
                        //Console.WriteLine(numbers[i]);
                        tree.root = tree.insert(tree.root, numbers[i]);
                    }
                }
                else if (tryb == 2)
                {
                    for (int i = 0; i < 60; i++)
                    {
                        liczba = rand.Next(100, 200);
                        tree.root = tree.insert(tree.root, liczba);
                    }
                }

                writer.Write("KLP: ");
                tree.KLP(tree.root, writer);
                writer.WriteLine();

                int help = 0, insert;
                while (help != 9)
                {
                    Console.WriteLine("Co chcesz zrobić");
                    Console.WriteLine("1. insert i wypisanie do pliku");
                    Console.WriteLine("9. wyjdz");
                    help = Int32.Parse(Console.ReadLine());

                    if (help == 1)
                    {
                        Console.WriteLine("Co chcesz dodać: ");
                        insert = Int32.Parse(Console.ReadLine());

                        tree.root = tree.insert(tree.root, insert);

                        writer.Write("nowe KLP: ");
                        tree.KLP(tree.root, writer);
                    }

                }  

            }

        }
    }
}

