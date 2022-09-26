using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TalentHubLab1.AVL;
using TalentHubLab1;
using TalentHubLab1.Huffman;
using TalentHubLab1.RecommendationLetters;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        //arrange
        AVLclass testAVL = new AVLclass();

        Applicant test = new Applicant()
        {
            Name = "Mario",
            DPI = "1",
            DateBirth = "21-12-1990",
            Address = "Guatemala"
        };

        Applicant test2 = new Applicant()
        {
            Name = "Juan",
            DPI = "5",
            DateBirth = "23-04-2001",
            Address = "Guatemala"
        };

        Applicant test3 = new Applicant()
        {
            Name = "Roberto",
            DPI = "2",
            DateBirth = "11-04-2000",
            Address = "Guatemala"
        };

        Applicant test4 = new Applicant()
        {
            Name = "Pedro",
            DPI = "7",
            DateBirth = "11-04-2002",
            Address = "Guatemala"
        };

        [TestMethod]
        
        public void AVLinsertion_test()
        {

            //Act
            testAVL.Root = testAVL.Insert(testAVL.Root, test);
            string result = testAVL.Root.element.Address;

            //Assert
            Assert.IsTrue(testAVL.nodeCount != 0 && testAVL.Root != null);
            Assert.AreEqual("Guatemala", result);
        }


        [TestMethod]

        public void AVLrightRotation_test()
        {

            //Act
            //insertion case that forces an imbalance to the left side of the tree
            testAVL.Root = testAVL.Insert(testAVL.Root, test2);
            testAVL.Root = testAVL.Insert(testAVL.Root, test3);
            testAVL.Root = testAVL.Insert(testAVL.Root, test);

            //Assert
            //validates that all the nodes in the tree have a balance factor equals to 0 after the right rotation
            Assert.IsTrue(testAVL.calculateFactor(testAVL.Root) == 0 && testAVL.calculateFactor(testAVL.Root.left) == 0 && testAVL.calculateFactor(testAVL.Root.right) == 0 && testAVL.nodeCount == 3);
            
        }

        [TestMethod]

        public void AVLleftRotation_test()
        {

            //Act
            //insertion case that forces an imbalance to the right side of the tree
            testAVL.Root = testAVL.Insert(testAVL.Root, test);
            testAVL.Root = testAVL.Insert(testAVL.Root, test3);
            testAVL.Root = testAVL.Insert(testAVL.Root, test2);

            //Assert
            //validates that all the nodes in the tree have a balance factor equals to 0 after the right rotation
            Assert.IsTrue(testAVL.calculateFactor(testAVL.Root) == 0 && testAVL.calculateFactor(testAVL.Root.left) == 0 && testAVL.calculateFactor(testAVL.Root.right) == 0 && testAVL.nodeCount == 3);

        }

        [TestMethod]

        public void AVLedit_test()
        {
            //Act
            testAVL.Root = testAVL.Insert(testAVL.Root, test);  //Root
            testAVL.Root = testAVL.Insert(testAVL.Root, test3); //Right child of Root 


            //changes in Right child of Root
            test3.Address = "Japan";
            test3.DateBirth = "24-12-2002";

            testAVL.Edit(testAVL.Root, test3);


            //Assert
            //Changes made in test3 are expected to be notice

            Assert.AreEqual("Japan", testAVL.Root.right.element.Address);
            Assert.AreEqual("24-12-2002", testAVL.Root.right.element.DateBirth);
        }

        [TestMethod]
        public void AVLdelete_test()
        {
            //Act
            testAVL.Root = testAVL.Insert(testAVL.Root, test);
            testAVL.Root = testAVL.Insert(testAVL.Root, test2);
            testAVL.Root = testAVL.Insert(testAVL.Root, test3);
            testAVL.Root = testAVL.Insert(testAVL.Root, test4);

            

            testAVL.Delete(testAVL.Root, test3);

            //Assert
            Assert.IsTrue(testAVL.Root.element.DPI == "5" && testAVL.Root.right.element.DPI == "7" && testAVL.Root.left.element.DPI == "1");
        }

        [TestMethod]
        public void AVLsearchByDPI_test()
        {
            //act
            testAVL.Root = testAVL.Insert(testAVL.Root, test);
            testAVL.Root = testAVL.Insert(testAVL.Root, test2);
            testAVL.Root = testAVL.Insert(testAVL.Root, test3);
            testAVL.Root = testAVL.Insert(testAVL.Root, test4);


            Applicant search = testAVL.SearchByDPI(testAVL.Root, "7");
            Applicant search2 = testAVL.SearchByDPI(testAVL.Root, "5");

            //assert
            Assert.IsTrue(search.Name == "Pedro" && search.DPI == "7");
            Assert.IsTrue(search2.Name == "Juan" && search2.DPI == "5");
            Assert.IsTrue(testAVL.SearchByDPI(testAVL.Root, "13") == null);
        }


        [TestMethod]
        public void HuffmanTreeCreation_test()
        {
            //arrange
            string text = "hello world";
            HuffmanTree tree = new HuffmanTree();


            //act
            tree.CreateTree(text.Replace(" ", "").ToLower());


            //assert

            Assert.IsTrue(tree.Root.Frequency == 10);
            Assert.IsTrue(tree.DPIcodificated == "000001101011101011101110110");

            Assert.IsTrue(tree.DecodeText(tree.DPIcodificated) == "helloworld");
        }

        [TestMethod]

        public void LZ78Encoding_test()
        {
            //arrange
            RecommendationLetter letter = new RecommendationLetter("ABRACADRABRARAAAA");
            
            //act
            letter.Encoding();

            //assert
            Assert.IsTrue(letter.EntryDictionary.Keys.Count == 10);
            Assert.IsTrue(letter.EncodingDictionary[10].character == '~');
            Assert.IsTrue(letter.EntryDictionary["ad"] == 5);
        }


        [TestMethod]

        public void LZ78Decode_test()
        {
            //arrange
            string text = "ABRACADRABRARAAAA";
            string text2 = "Quia maxime magni molestiae inventore magni vitae necessitatibus. Est vitae harum ratione. Sint inventore quo. Natus pariatur quia voluptatem earum accusantium nihil ducimus fugit. Eos dolorem sapiente quia quod accusantium ab.Ut libero ipsa.Quas temporibus sit fugit. Quia et omnis enim accusamus aliquid aspernatur cumque illum id. Quo quia mollitia repudiandae. Maxime expedita illo.At eius aut magni aut sit voluptates quidem.Illum dolorem molestias quia omnis tempore incidunt et repudiandae rerum. Recusandae sit aut tempore voluptatem sequi enim et veritatis eligendi. Qui enim quis impedit. Quo modi nihil nihil nemo sapiente deleniti fuga laborum.Quia ut debitis voluptatem ad id exercitationem non. Facilis quo voluptate.Enim rerum ut excepturi ex eos. Mollitia reprehenderit sapiente eveniet. Odit non nisi laborum. Velit repudiandae nostrum est et aut architecto incidunt. Ut non omnis illo dignissimos.Optio est enim in.";

            RecommendationLetter letter = new RecommendationLetter(text);
            RecommendationLetter letter2 = new RecommendationLetter(text2);
            letter.Encoding();
            letter2.Encoding();

            //act
            string decodeText = letter.Decode(1);
            string decodeText2 = letter2.Decode(1);

            //assert
            Assert.IsTrue(decodeText.ToUpper() == text);
            Assert.IsTrue(decodeText2 == text2.ToLower());
        }

    }
}
