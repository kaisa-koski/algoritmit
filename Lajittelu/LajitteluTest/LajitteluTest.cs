using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using static Lajittelu;

	[TestFixture]
	public  class TestLajittelu
	{
		[Test]
		public  void TestKuplalajittelu48()
		{
			int[] t1 = new int[]{5, 1, 4, 2, 3};
			Kuplalajittelu(t1);
			Assert.AreEqual( "1 2 3 4 5", String.Join(" ", t1) , "in method Kuplalajittelu, line 51");
			int[] t2 = new int[]{4, 3, 2, 5, 1};
			Kuplalajittelu(t2);
			Assert.AreEqual( "1 2 3 4 5", String.Join(" ", t2) , "in method Kuplalajittelu, line 54");
			int[] t3 = new int[]{1, 2, 3, 4, 5};
			Kuplalajittelu(t3);
			Assert.AreEqual( "1 2 3 4 5", String.Join(" ", t3) , "in method Kuplalajittelu, line 57");
			int[] t4 = new int[]{5, 4, 3, 2, 1};
			Kuplalajittelu(t4);
			Assert.AreEqual( "1 2 3 4 5", String.Join(" ", t4) , "in method Kuplalajittelu, line 60");
		}
		[Test]
		public  void TestLisayslajittelu85()
		{
			int[] t1 = new int[]{5, 1, 4, 2, 3};
			Lisayslajittelu(t1);
			Assert.AreEqual( "1 2 3 4 5", String.Join(" ", t1) , "in method Lisayslajittelu, line 88");
			int[] t2 = new int[]{4, 3, 2, 5, 1};
			Lisayslajittelu(t2);
			Assert.AreEqual( "1 2 3 4 5", String.Join(" ", t2) , "in method Lisayslajittelu, line 91");
			int[] t3 = new int[]{1, 2, 3, 4, 5};
			Lisayslajittelu(t3);
			Assert.AreEqual( "1 2 3 4 5", String.Join(" ", t3) , "in method Lisayslajittelu, line 94");
			int[] t4 = new int[]{5, 4, 3, 2, 1};
			Lisayslajittelu(t4);
			Assert.AreEqual( "1 2 3 4 5", String.Join(" ", t4) , "in method Lisayslajittelu, line 97");
			int[] t5 = new int[]{5, 1, 4, 3, 2};
			Lisayslajittelu(t5);
			Assert.AreEqual( "1 2 3 4 5", String.Join(" ", t5) , "in method Lisayslajittelu, line 100");
		}
	}

