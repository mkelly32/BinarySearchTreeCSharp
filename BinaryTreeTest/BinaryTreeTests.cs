using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTree;

namespace BinaryTreeTest
{
    [TestClass]
    public class BinaryTreeTests
    {
        private int InitialValue = 10;
        private int LesserValue = 5;
        private int GreaterValue = 15;
        private int SmallestValue = 1;
        private int SmallValue = 6;
        private int LargeValue = 12;
        private int LargestValue = 25;

        [TestMethod]
        public void testBinaryTreeConstructor()
        {
            //Test treeSizeOneA is constructed correctly
            BinaryTree.BinaryTree treeSizeOneA = new BinaryTree.BinaryTree(LesserValue, null, null);

            Assert.AreEqual(treeSizeOneA.Data, LesserValue);
            Assert.IsNull(treeSizeOneA.LesserTree);
            Assert.IsNull(treeSizeOneA.GreaterTree);

            //Test treeSizetwo is constructed correctly 
            BinaryTree.BinaryTree treeSizeTwo = new BinaryTree.BinaryTree(GreaterValue, treeSizeOneA, null);
            Assert.AreEqual(treeSizeTwo.Data, GreaterValue);
            Assert.AreEqual(treeSizeTwo.LesserTree, treeSizeOneA);
            Assert.IsNull(treeSizeTwo.GreaterTree);

            //Test treeSizeTwo is constructed correctly
            BinaryTree.BinaryTree treeSizeOneB = new BinaryTree.BinaryTree(LesserValue, null, null);
            BinaryTree.BinaryTree treeSizeOneC = new BinaryTree.BinaryTree(GreaterValue, null, null);
            BinaryTree.BinaryTree treeSizeThree = new BinaryTree.BinaryTree(InitialValue, treeSizeOneB, treeSizeOneC);
            Assert.AreEqual(treeSizeThree.Data, InitialValue);
            Assert.AreEqual(treeSizeThree.LesserTree, treeSizeOneB);
            Assert.AreEqual(treeSizeThree.GreaterTree, treeSizeOneC);
        }

        [TestMethod]
        public void testInsert()
        {
            BinaryTree.BinaryTree root = new BinaryTree.BinaryTree(InitialValue, null, null);

            //Test smaller value is inserted correctly
            root.insert(root, LesserValue);
            Assert.AreEqual(root.LesserTree.Data, LesserValue);

            //Test larger value is inserted correctly
            root.insert(root, GreaterValue);
            Assert.AreEqual(root.GreaterTree.Data, GreaterValue);

            //Test value is inserted correctly to sub trees.
            root.insert(root, SmallestValue);
            Assert.AreEqual(root.LesserTree.LesserTree.Data, SmallestValue);
        }

        [TestMethod]
        public void testContains()
        {
            BinaryTree.BinaryTree root = new BinaryTree.BinaryTree(InitialValue, null, null);

            //Test false for left and right branches repectively
            Assert.IsFalse(root.contains(root, LesserValue));
            Assert.IsFalse(root.contains(root, GreaterValue));

            //Add  more Nodes
            root.insert(root, LesserValue); 
            root.insert(root, GreaterValue);
            root.insert(root, SmallestValue);

            //Test True for left and right braches
            Assert.IsTrue(root.contains(root, LesserValue));
            Assert.IsTrue(root.contains(root, GreaterValue));

            //Test for sub tree
            Assert.IsTrue(root.contains(root, SmallestValue));
        }

        [TestMethod]
        public void testHeight()
        {
            BinaryTree.BinaryTree root = new BinaryTree.BinaryTree(InitialValue, null, null);

            //Test for empty Tree
            BinaryTree.BinaryTree emptyTree = null;
            Assert.AreEqual(root.height(emptyTree), 0);

            //Test for  tree size one
            Assert.AreEqual(root.height(root), 1);

            //Test for treee size two
            root.insert(root, LesserValue);
            Assert.AreEqual(root.height(root), 2);
        }

        [TestMethod]
        public void testLowestCommonAncestor()
        {
            BinaryTree.BinaryTree root = new BinaryTree.BinaryTree(InitialValue, null, null);
            root.insert(root, LesserValue);
            root.insert(root, GreaterValue);
            root.insert(root, SmallestValue);
            root.insert(root, SmallValue);
            root.insert(root, LargestValue);
            root.insert(root, LargeValue);

            //Test for root == LCA
            Assert.AreEqual(root.lowestCommonAncestor(root, LesserValue, GreaterValue), root);

            //Test for LesserTree == LCA
            Assert.AreEqual(root.lowestCommonAncestor(root, SmallestValue, SmallValue), root.LesserTree);

            //Test for GreaterTree == LCA
            Assert.AreEqual(root.lowestCommonAncestor(root, LargeValue, LargestValue), root.GreaterTree);
        }
    }
}
