using NUnit.Framework;
using static O1;

	[TestFixture]
	public  class TestO1
	{
		[Test]
		public  void TestOnkoJaollinen24()
		{
			int[] t = { 1, 2, 3, 4, 5, 6 };
			Assert.AreEqual( 3, JaollistenMaara(t, 2) , "in method JaollistenMaara, line 26");
			Assert.AreEqual( 2, JaollistenMaara(t, 3) , "in method JaollistenMaara, line 27");
			Assert.AreEqual( 1, JaollistenMaara(t, 5) , "in method JaollistenMaara, line 28");
			Assert.AreEqual( 0, JaollistenMaara(t, 7) , "in method JaollistenMaara, line 29");
		}
	}

