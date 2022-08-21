using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentHubLab1.AVL
{
    class AVLclass<T>
    {
        public AVLclass()
        {
            Root = null;
            nodeCount = 0;
        }

        Node Root;
        int nodeCount;

        public Node Insert(Node root, Applicant element)
        {
            
            if (Root == null)
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

        

    }
}
