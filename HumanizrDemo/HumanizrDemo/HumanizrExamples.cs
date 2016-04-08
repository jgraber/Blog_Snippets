using System;
using Humanizer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HumanizrDemo
{
    [TestClass]
    public class HumanizrExamples
    {
        [TestMethod]
        public void Text_KuerzenAufBestimmteLaenge_RestMitPunktenAngedeutet()
        {
            var meinText = "Dies ist ein sehr langer Text";

            var result = meinText.Truncate(5);

            Assert.AreEqual("Dies…", result);
        }
    }
}
