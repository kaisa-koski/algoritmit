using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using static Binaarihaku;

	[TestFixture]
	public  class TestBinaarihaku
	{
		[Test]
		public  void TestBinHaku42()
		{
			int[] t1 = new int[]{1,2,3,5,6,7,8};
			Assert.AreEqual( 1, BinHaku(t1, 2) , "in method BinHaku, line 44");
			Assert.AreEqual( 0, BinHaku(t1, 1) , "in method BinHaku, line 45");
			Assert.AreEqual( 5, BinHaku(t1, 7) , "in method BinHaku, line 46");
			Assert.AreEqual( -1, BinHaku(t1, 9) , "in method BinHaku, line 47");
			Assert.AreEqual( -1, BinHaku(t1, 4) , "in method BinHaku, line 48");
		}
	}

