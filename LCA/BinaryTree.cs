using System;

namespace LCA
{
    public class BinaryTree
    {
        public class Node
        {
            private int data;
            private Node lesserTree;
            private Node greaterTree;
            public void DisplayNode()
            {
                Console.Write(data);
            }
        }
        public Node root;
    }
}
