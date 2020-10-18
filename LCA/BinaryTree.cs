using System;
using System.Xml;

namespace LCA
{
    public class BinaryTree
    {
        private int data;
        private BinaryTree lesserTree;
        private BinaryTree greaterTree;

        private BinaryTree(int data, BinaryTree lesserTree, BinaryTree greaterTree)
        {
            this.data = data;
            this.lesserTree = lesserTree;
            this.greaterTree = greaterTree;
        }

        public int getData() { return this.data; }

        public static BinaryTree insert(BinaryTree node, int data)
        {
            if (node == null)
                return new BinaryTree(data, null, null);
            if (data < node.data)
                return insert(node.lesserTree, data);
            else
                return insert(node.greaterTree, data);
        }
        public Boolean contains(BinaryTree node, int data)
        {
            if (node == null)
                return false;
            if (node.data == data)
                return true;
            if (data < node.data)
                return contains(node.lesserTree, data);
            else
                return contains(node.greaterTree, data);
        }

        public int height(BinaryTree node)
        {
            if (node == null)
                return 0;
            return Math.Max(1 + height(node.lesserTree), 1 + height(node.greaterTree));
        }

        public static BinaryTree makeTree(int[] data)
        {
            BinaryTree root = insert(null, data[0]);
            for (int index = 1; index < data.Length; index++)
                insert(root, data[index]);
            return root;
        }
    }
}
