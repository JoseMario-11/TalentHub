using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TalentHubLab1.Huffman;

namespace TalentHubLab1
{
    public class Applicant
    {
        
        public string Name { get; set; }
        public string DPI { get; set; }
        public string DateBirth { get; set; }
        public string Address { get; set; }
        public string[] Companies { get; set; }

        [NonSerialized]

        public Dictionary<string, HuffmanTree> CompanyApplicantInfo = new Dictionary<string, HuffmanTree>();
    }
}
