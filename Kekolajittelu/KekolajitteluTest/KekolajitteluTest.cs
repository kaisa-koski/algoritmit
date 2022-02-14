using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using static Kekolajittelu;

	[TestFixture]
	public  class TestKekolajittelu
	{
		[Test]
		public  void TestLajittele40()
		{
			int[] t1 = new int[]{2,1,4,3,5};
			Lajittele(t1);
			Assert.AreEqual( "1 2 3 4 5", String.Join(" ", t1) , "in method Lajittele, line 43");
			int[] t2 = new int[]{3,2,1};
			Lajittele(t2);
			Assert.AreEqual( "1 2 3", String.Join(" ", t2) , "in method Lajittele, line 46");
			int[] t3 = new int[]{-1,5,-3,4,0};
			Lajittele(t3);
			Assert.AreEqual( "-3 -1 0 4 5", String.Join(" ", t3) , "in method Lajittele, line 49");
			int[] t4 = new int[]{};
			Lajittele(t4);
			Assert.AreEqual( "", String.Join(" ", t4) , "in method Lajittele, line 52");
		}
		[Test]
		public  void TestLisaaKekoon76()
		{
			int[] t5 = new int[]{2,1,5,0,0};
			LisaaKekoon(t5, 6);
			Assert.AreEqual( "3 1 5 6 0", String.Join(" ", t5) , "in method LisaaKekoon, line 79");
			LisaaKekoon(t5, 3);
			Assert.AreEqual( "4 1 3 6 5", String.Join(" ", t5) , "in method LisaaKekoon, line 81");
			LisaaKekoon(t5, 4);
			Assert.AreEqual( "4 1 3 6 5", String.Join(" ", t5) , "in method LisaaKekoon, line 83");
			int[] t6 = new int[]{};
			LisaaKekoon(t6, 5);
			Assert.AreEqual( "", String.Join(" ", t6) , "in method LisaaKekoon, line 86");
		}
		[Test]
		public  void TestKorjaaKeko108()
		{
			int[] t7 = new int[]{3,3,1,2};
			KorjaaKeko(t7, 1);
			Assert.AreEqual( "3 1 3 2", String.Join(" ", t7) , "in method KorjaaKeko, line 111");
			int[] t8 = new int[]{3,1,3,2,0,0};
			KorjaaKeko(t8, 2);
			Assert.AreEqual( "3 1 3 2 0 0", String.Join(" ", t8) , "in method KorjaaKeko, line 114");
			int[] t9 = new int[]{6,1,2,5,3,4,3,0,0};
			KorjaaKeko(t9, 3);
			Assert.AreEqual( "6 1 2 3 3 4 5 0 0", String.Join(" ", t9) , "in method KorjaaKeko, line 117");
		}
		[Test]
		public  void TestLajitteleKeko144()
		{
			int[] t10 = new int[]{4,1,3,2,4};
			LajitteleKeko(t10);
			Assert.AreEqual( "0 4 3 2 1", String.Join(" ", t10) , "in method LajitteleKeko, line 147");
			int[] t11 = new int[]{5,1,3,2,4,5,0,0};
			LajitteleKeko(t11);
			Assert.AreEqual( "0 5 4 3 2 1 0 0", String.Join(" ", t11) , "in method LajitteleKeko, line 150");
		}
		[Test]
		public  void TestPoistaPienin166()
		{
			int[] t11 = new int[]{4,1,3,2,4};
			Assert.AreEqual( 1, PoistaPienin(t11) , "in method PoistaPienin, line 168");
			Assert.AreEqual( "3 2 3 4 1", String.Join(" ", t11) , "in method PoistaPienin, line 169");
			Assert.AreEqual( 2, PoistaPienin(t11) , "in method PoistaPienin, line 170");
			Assert.AreEqual( "2 3 4 2 1", String.Join(" ", t11) , "in method PoistaPienin, line 171");
			Assert.AreEqual( 3, PoistaPienin(t11) , "in method PoistaPienin, line 172");
			Assert.AreEqual( "1 4 3 2 1", String.Join(" ", t11) , "in method PoistaPienin, line 173");
			Assert.AreEqual( 4, PoistaPienin(t11) , "in method PoistaPienin, line 174");
			Assert.AreEqual( "0 4 3 2 1", String.Join(" ", t11) , "in method PoistaPienin, line 175");
		}
	}

