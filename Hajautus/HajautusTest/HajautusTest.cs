using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using static Hajautus;

	[TestFixture]
	public  class TestHajautus
	{
		[Test]
		public  void TestHajauta55()
		{
			int[] t = new int[10];
			Assert.AreEqual( 0, Hajauta(t, 10) , "in method Hajauta, line 57");
			Assert.AreEqual( 6, Hajauta(t, 36) , "in method Hajauta, line 58");
			Assert.AreEqual( 5, Hajauta(t, 55) , "in method Hajauta, line 59");
			Assert.AreEqual( 9, Hajauta(t, 99) , "in method Hajauta, line 60");
		}
		[Test]
		public  void TestLisaa78()
		{
			int[] t2 = new int[10];
			Assert.AreEqual( "Alkio 5 lisätty", Lisaa(t2, 5) , "in method Lisaa, line 80");
			Assert.AreEqual( "Alkio 26 lisätty", Lisaa(t2, 26) , "in method Lisaa, line 81");
			Assert.AreEqual( "Alkio 36 lisätty", Lisaa(t2, 36) , "in method Lisaa, line 82");
			Assert.AreEqual( "Alkio 44 lisätty", Lisaa(t2, 44) , "in method Lisaa, line 83");
			Assert.AreEqual( "Alkio 88 lisätty", Lisaa(t2, 88) , "in method Lisaa, line 84");
			Assert.AreEqual( "Alkio 10 lisätty", Lisaa(t2, 10) , "in method Lisaa, line 85");
			Assert.AreEqual( "10 0 0 0 44 5 26 36 88 0", String.Join(" ", t2) , "in method Lisaa, line 86");
		}
		[Test]
		public  void TestPoista126()
		{
			int[] t3 = new int[10];
			Assert.AreEqual( "Alkio 5 lisätty", Lisaa(t3, 5) , "in method Poista, line 128");
			Assert.AreEqual( "Alkio 26 lisätty", Lisaa(t3, 26) , "in method Poista, line 129");
			Assert.AreEqual( "Alkio 36 lisätty", Lisaa(t3, 36) , "in method Poista, line 130");
			Assert.AreEqual( "Alkio 44 lisätty", Lisaa(t3, 44) , "in method Poista, line 131");
			Assert.AreEqual( "Alkio 88 lisätty", Lisaa(t3, 88) , "in method Poista, line 132");
			Assert.AreEqual( "Alkio 10 lisätty", Lisaa(t3, 10) , "in method Poista, line 133");
			Assert.AreEqual( "Alkio 10 lisätty", Lisaa(t3, 10) , "in method Poista, line 134");
			Assert.AreEqual( "10 10 0 0 44 5 26 36 88 0", String.Join(" ", t3) , "in method Poista, line 135");
			Assert.AreEqual( "Alkio 5 poistettu", Poista(t3, 5) , "in method Poista, line 136");
			Assert.AreEqual( "Alkiota 5 ei löydy", Poista(t3, 5) , "in method Poista, line 137");
			Assert.AreEqual( "Alkio 44 poistettu", Poista(t3, 44) , "in method Poista, line 138");
			Assert.AreEqual( "Alkio 88 poistettu", Poista(t3, 88) , "in method Poista, line 139");
			Assert.AreEqual( "Alkio 10 poistettu", Poista(t3, 10) , "in method Poista, line 140");
			Assert.AreEqual( "-1 10 0 0 -1 -1 26 36 -1 0", String.Join(" ", t3) , "in method Poista, line 141");
		}
	}

