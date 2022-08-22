using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TalentHubLab1.AVL;
using TalentHubLab1;

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
            DPI = "13245653476121",
            DateBirth = "21-12-1990",
            Address = "Guatemala"
        };

        Applicant test2 = new Applicant()
        {
            Name = "Juan",
            DPI = "52452345234524",
            DateBirth = "23-04-2001",
            Address = "Guatemala"
        };

        Applicant test3 = new Applicant()
        {
            Name = "Roberto",
            DPI = "2345322543222455",
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
    }
}
