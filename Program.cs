namespace Tree_Practice;
class Program {
    static void Main(string[] args) {
        BinaryTree tree = new BinaryTree(10);
        tree.Insert(5);
        tree.Insert(15);
        tree.Insert(3);
        tree.Insert(7);
        tree.Insert(12);
        tree.Insert(18);

        Console.WriteLine("Inorder Traversal\n--------------");
        tree.InorderTraversal(tree.Root);
    }
}

/*
Creates individual TreeNodes
@param Value is the specific value of the node
@param Left is the TreeNode to the left of a given value
@param Right is the TreeNode to the right of a given value
*/
public class TreeNode {
    public int Value { get; set; } //The 'get;' and 'set;' are auto-implemented properties; Shorthand for default getters and setters
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }

    public TreeNode(int value) {
        Value = value; //Set the value of the node
        Left = null; //Set the left node to null
        Right = null; //Set the right node to null
    }
}

public class BinaryTree {
    public TreeNode Root { get; set; } //Initialize the root of the tree

    //Create a new tree with a root
    public BinaryTree(int rootVal) {
        Root = new TreeNode(rootVal); //Create a new TreeNode to be the root of the tree
    }

    //Insert value into tree
    public void Insert(int value) {
        InsertRecursive(Root, value);
    }

    //Responsible for creating the overall tree structure during insertion
    private void InsertRecursive(TreeNode current, int value) {
        if(value < current.Value) { //If the value is less than the current node; smaller values go to the left of the parent
            if(current.Left == null) { //If there isn't already a node on the left
                current.Left = new TreeNode(value); //Create new node on left using the given value
            } else {
                InsertRecursive(current.Left, value); //Move down the tree to the left to find an open left node
            }
        } else { //If the given value is bigger than the current node; larger values go to the right of the parent
            if(current.Right == null) { //If the current node does not have a node to its right
                current.Right = new TreeNode(value); //Create a new node on the right using the given value
            } else {
                InsertRecursive(current.Right, value); //Move down the tree to the right to find an open Right node
            }
        }
    }

    public void InorderTraversal(TreeNode node) {
        if(node != null) { //If the given node is not null
            InorderTraversal(node.Left); //Move DOWN to the node left of the current one and repeat
            Console.WriteLine(node.Value + " "); //Print the value of the current node
            InorderTraversal(node.Right); //Move DOWN to the node right of the current one and repeat
        }//***IMPORTANT!*** this method can only 
    }
}
