using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentHubLab1.Huffman
{
    class HuffmanTree
    {
        Dictionary<char, string> HuffmanCodesDictionary; //for encoding process
        HuffmanNode Root;
        List<HuffmanNode> NodeList;

        public Func<HuffmanNode, HuffmanNode, int> CompareNodes = (node1, node2) =>
        {
            return node1.Frequency > node2.Frequency ? 1 : 0;
        };

 
    }
}
