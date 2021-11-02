using NUnit.Framework;
using System;
using AssignmentDemo.WrapText;
using AssignmentDemo.WrapTextTest;

namespace TestProject1
{
    [TestFixture]
    public class WrapTextTest: Base
    {

        [Test]
        public void MultipleLinesInputText()
        {
                var input = FileUtils.readFileDataAndReplaceSpecialChars("WrapTextTest\\TestData\\Input\\MultipleLinesText.txt");
                var actual = WrapText.Wrap(input, 35);
                Console.WriteLine(actual);
                string expected = FileUtils.readFileData("WrapTextTest\\TestData\\Output\\MultipleLinesText.txt");
                Assert.AreEqual(expected, actual);
        }


        [Test]
        public void SingleLineInputText()
        {
                var input = FileUtils.readFileDataAndReplaceSpecialChars("WrapTextTest\\TestData\\Input\\SingleLineText.txt");
                var actual = WrapText.Wrap(input, 35);
                string expected = FileUtils.readFileData("WrapTextTest\\TestData\\Output\\SingleLineText.txt");
                Assert.AreEqual(expected, actual);
}

        [Test]
        public void PerformanceTest()
        {
                var input = FileUtils.readFileDataAndReplaceSpecialChars("WrapTextTest\\TestData\\Input\\PerfText.txt");
                var actual = WrapText.Wrap(input, 35);
                string expected = FileUtils.readFileData("WrapTextTest\\TestData\\Output\\PerfText.txt");
                Assert.AreEqual(expected, actual);
        }


        [Test]
        public void SpecialCharsInputText()
        {
                var input = FileUtils.readFileDataAndReplaceSpecialChars("WrapTextTest\\TestData\\Input\\SpecialCharsText.txt");
                var actual = WrapText.Wrap(input, 35);
                string expected = FileUtils.readFileData("WrapTextTest\\TestData\\Output\\SpecialCharsText.txt");
                Assert.AreEqual(expected, actual);
        }


        [Test]
        public void BoundaryConditionsTest()
        {
                var input = FileUtils.readFileDataAndReplaceSpecialChars("WrapTextTest\\TestData\\Input\\BoundaryText.txt");
                var actual = WrapText.Wrap(input, 16);
                string expected = FileUtils.readFileData("WrapTextTest\\TestData\\Output\\BoundaryText.txt");
                Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BlankTextCheck()
        {
                var input = FileUtils.readFileDataAndReplaceSpecialChars("WrapTextTest\\TestData\\Input\\BlankFile.txt");
                var actual = WrapText.Wrap(input, 16);
                string expected = FileUtils.readFileData("WrapTextTest\\TestData\\Output\\BlankFile.txt");
                Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ZeroWidthCheck()
        {
            try
            {
                var input = FileUtils.readFileDataAndReplaceSpecialChars("WrapTextTest\\TestData\\Input\\BlankFile.txt");
                var actual = WrapText.Wrap(input, 0);
                string expected = FileUtils.readFileData("WrapTextTest\\TestData\\Output\\BlankFile.txt");
                Assert.True(false,"Invalid Exception Thrownn");
            }
            catch (InvalidOperationException e)
            {
                Assert.True(true);
            }
        }
    }
}