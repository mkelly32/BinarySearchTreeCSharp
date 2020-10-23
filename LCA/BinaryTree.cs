using System;

namespace BinaryTree
{
    public class BinaryTree
    {
        public int Data;
        public BinaryTree LesserTree;
        public BinaryTree GreaterTree;

        public BinaryTree(int data, BinaryTree lesserTree, BinaryTree greaterTree)
        {
            this.Data = data;
            this.LesserTree = lesserTree;
            this.GreaterTree = greaterTree;
        }
        
        public BinaryTree insert(BinaryTree node, int data)
        {
            if (node == null)
                return new BinaryTree(data, null, null);
            if (data < node.Data)
                node.LesserTree = insert(node.LesserTree, data);
            else
                node.GreaterTree = insert(node.GreaterTree, data);
            return node;
        }
        public Boolean contains(BinaryTree node, int data)
        {
            if (node == null)
                return false;
            if (node.Data == data)
                return true;
            if (data < node.Data)
                return contains(node.LesserTree, data);
            else
                return contains(node.GreaterTree, data);
        }

        public int height(BinaryTree node)
        {
            if (node == null)
                return 0;
            return Math.Max(1 + height(node.LesserTree), 1 + height(node.GreaterTree));
        }

        public static void Main()
        {

        }
    }
}
