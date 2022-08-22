using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentHubLab1.AVL
{
    public class AVLclass
    {
        public AVLclass()
        {
            Root = null;
            nodeCount = 0;
        }

        public Node Root;
        public int nodeCount;

        public Node Insert(Node root, Applicant element)
        {
            
            if (root == null)
            {
                Node node = new Node(element);
                nodeCount++;
                return node;
            }

            if (string.Compare(root.element.DPI, element.DPI) == 1)
                root.left = Insert(root.left, element);
            if (string.Compare(root.element.DPI, element.DPI) == -1)
                root.right = Insert(root.right, element);

            //balance factor 
            int balance = calculateFactor(root);

            if (balance > 1)
            {
                if (string.Compare(root.left.element.DPI, element.DPI) == 1)
                {
                    //single right rotation
                    return RightRotation(root);
                }
                else if (string.Compare(root.left.element.DPI, element.DPI) == -1)
                {
                    //double roght rotation
                    root.left = LeftRotation(root.left);
                    return RightRotation(root);
                }
            }

            if (balance < -1)
            {
                if (string.Compare(root.right.element.DPI, element.DPI) == -1)
                {
                    //single left rotation
                    return LeftRotation(root);
                }
                else if (string.Compare(root.right.element.DPI, element.DPI) == 1)
                {
                    //double left rotation
                    root.right = RightRotation(root.right);
                    return LeftRotation(root);
                }
            }

            return root;
        }


        public int calculateFactor(Node node)
        {
            if (node == null)
                return -1;
            else
                return getHeight(node.left) - getHeight(node.right);
        }

        public int getHeight(Node node)
        {
            if (node == null)
                return -1;
            return maxHeight(getHeight(node.left), getHeight(node.right));
        }

        public int maxHeight(int heightLeft, int HeightRight)
        {
            return (HeightRight > heightLeft) ? HeightRight + 1 : heightLeft + 1;
        }

        public Node RightRotation(Node node)
        {
            Node newRoot = node.left;
            Node rightAux = newRoot.right;
            newRoot.right = node;
            node.left = rightAux;

            return newRoot;
        }

        public Node LeftRotation(Node node)
        {
            Node newRoot = node.right;
            Node leftAux = newRoot.left;
            newRoot.left = node;
            node.right = leftAux;

            return newRoot;
        }

    }
}
