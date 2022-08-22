using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentHubLab1.AVL
{
    public class Node
    {
        public Node(Applicant element)
        {
            this.element = element;
        }

        public Applicant element;
        public Node left;
        public Node right;
    }
}
