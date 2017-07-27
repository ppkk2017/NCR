using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCR_Test;
using System.IO;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        // check the total counts in input.txt == (valid count of duplicate + invalid count) , result is 507, correct
        [TestMethod]
        public void TestInput()
        {
            using (StreamReader sreader = new StreamReader(@"..\..\..\TestProject1\Resource\input.txt"))
            {//sreader
                string line;
                int totallines = 0;
                int actualline = 0;
                Duplicate du = new Duplicate();
                while ((line = sreader.ReadLine()) != null)
                {
                    du.CheckIfDuplicate1(line);
                    ++totallines;
                }
                List<SetInfo> validsetlist = Duplicate.formalSetDic.Values.ToList<SetInfo>();
                foreach (var l in validsetlist)
                {
                    actualline += l.counts;
                }
                List<SetInfo> invalidsetlist = Duplicate.invalidSetDic.Values.ToList<SetInfo>();
                foreach (var il in invalidsetlist)
                {
                    actualline += il.counts;
                }
                Assert.AreEqual(totallines, actualline);
            }
        }

        //check a)
        [TestMethod]
        public void TestMethod1()
        {
            Duplicate du = new Duplicate();

            //add some number as inputed before
            Duplicate.formalSetDic.Add("1,2,3",
                new SetInfo
                {
                    counts = 1
                });
            Duplicate.formalSetDic.Add("1,1,2,3",
                new SetInfo
                {
                    counts = 1
                });


            Assert.AreEqual(false, du.CheckIfDuplicate1("1"));
            Assert.AreEqual(true, du.CheckIfDuplicate1("1,2,3"));
            Assert.AreEqual(true, du.CheckIfDuplicate1("3,2,1"));
            Assert.AreEqual(false, du.CheckIfDuplicate1("1,2,3,"));
            Assert.AreEqual(true, du.CheckIfDuplicate1("1,2,3,1"));
            Assert.AreEqual(false, du.CheckIfDuplicate1(",1,2,3,1"));
            Assert.AreEqual(false, du.CheckIfDuplicate1("a,b,c"));
            Assert.AreEqual(false, du.CheckIfDuplicate1(""));
            Assert.AreEqual(false, du.CheckIfDuplicate1(" "));
        }

        //check b)
        [TestMethod]
        public void TestMethod2()
        {
            Duplicate d = new Duplicate();
            Duplicate.formalSetDic.Add("1,2,3",
                new SetInfo
                {
                    counts = 1
                });

            Duplicate.formalSetDic.Add("1,1,2,3",
                new SetInfo
                {
                    counts = 1 //no duplicate
                    //counts = 2 // 1 duplicate
                });
            Assert.AreEqual(2, d.GetDuplicatedorNotDuplicateCounts(false));
            //Assert.AreEqual(1, d.GetDuplicatedorNotDuplicateCounts(true));
        }

        //check c)
        [TestMethod]
        public void Method3()
        {
            Duplicate d = new Duplicate();
            Duplicate.formalSetDic.Add("1,2,3",
                           new SetInfo
                           {
                               counts = 0
                           });
            Duplicate.formalSetDic.Add("1,2,3,4",
            new SetInfo
            {
                //counts = 0
                counts = 1
            });
            Duplicate.formalSetDic.Add("1,2,3,4,5",
                new SetInfo
                {
                    //counts = 0
                    counts = 1
                });

            List<string> mostDuplist = d.GetMostFrequetofDuplicateSet().ToList<string>();
            List<string> expectedlist = new List<string>(){ 
                "1,2,3,4",
                   "1,2,3,4,5"
               };

            //expectedlist = new List<string>() { }; all set cout is 0

            CollectionAssert.AreEqual(expectedlist, mostDuplist);
        }

        //check d)
        [TestMethod]
        public void Method4()
        {
            Duplicate d = new Duplicate();
            d.CheckIfDuplicate1("~,1");
            d.CheckIfDuplicate1("~,");
            d.CheckIfDuplicate1("abc1");
            d.CheckIfDuplicate1("1,2,3");
            d.CheckIfDuplicate1("");
            d.CheckIfDuplicate1("1,");
            d.CheckIfDuplicate1("1,a");
            List<string> actualInvalidInput = d.GetInvalidInputs().ToList<string>();
            List<string> expectedResult = new List<string>
            {
                "~,1",
                "~,",
                "abc1",
                "",
                "1,",
                "1,a"
            };
            CollectionAssert.AreEqual(expectedResult, actualInvalidInput);
        }
    }
}
