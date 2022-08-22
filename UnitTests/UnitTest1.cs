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
        AVLclass testAVL = new AVLclass();

        [TestMethod]
        
        

        public void AVLinsertion_test()
        {
            //Arrage
            Applicant test = new Applicant() 
            {
                Name = "Mario",
                DPI = "13245653476121",
                DateBirth = "11-04-2002",
                Address = "Guatemala"
            };


            //Act
            testAVL.Root = testAVL.Insert(testAVL.Root, test);
            string result = testAVL.Root.element.Address;

            //Assert
            Assert.IsTrue(testAVL.nodeCount != 0 && testAVL.Root != null);
            Assert.AreEqual("Guatemala", result);
        }
    }
}
