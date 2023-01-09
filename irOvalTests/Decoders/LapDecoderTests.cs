using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace irOval.Decoders.Tests
{
    [TestClass]
    public class LapDecoderTests
    {
        [TestMethod]
        public void LapDecoderTest()
        {
            LapDecoder dec = new(3);

            dec.Decode(1, 5f);
            Assert.AreEqual("5", dec.ToOverlay());

            dec.Decode(2, 7f);
            Assert.AreEqual("6", dec.ToOverlay());

            dec.Decode(3, 9f);
            Assert.AreEqual("7", dec.ToOverlay());

            dec.Decode(4, 11f);
            Assert.AreEqual("9", dec.ToOverlay());
        }
    }
}