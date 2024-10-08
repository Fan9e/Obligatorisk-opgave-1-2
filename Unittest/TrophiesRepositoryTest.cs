using Obligatorisk_opgave_1_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unittest
{
	[TestClass]
    public class TrophiesRepositoryTest
    {
		private TrophiesRepository repository;

		// Dette kaldes før hver test, så vi starter med en ny instans af TrophiesRepository hver gang
		[TestInitialize]
		public void Setup()
		{
			repository = new TrophiesRepository();
		}
		// Test for Add() metoden
		[TestMethod]
		public void TestAdd()
		{
			// Arrange
			Trophy newTrophy = new Trophy { Competition = "FA Cup", Year = 2023 };
			Trophy nullTrophy = new Trophy { Competition = null, Year = 2023 }; 

			// Act
			repository.Add(newTrophy);
			var allTrophies = repository.Get();  // Hent alle trofæer efter tilføjelsen

			// Assert
			Assert.AreEqual(6, allTrophies.Count()); // Sørg for, at listen nu indeholder 6 trofæer
			
			Assert.IsTrue(allTrophies.Exists(t => t.Id == 6 && t.Competition == "FA Cup" && t.Year == 2023)); 

			Assert.ThrowsException<ArgumentNullException>(() => repository.Add(nullTrophy));


		}
		//prøv at forklare det her til Frederikke
		[TestMethod]
		public void TestRemove()
		{
			// Act
			Trophy result = repository.Remove(1);  // Fjern trofæet med Id = 1
			var allTrophies = repository.Get();

			// Assert
			
			Assert.AreEqual(4, allTrophies.Count()); // Sørg for, at der nu er 4 trofæer tilbage
			Assert.IsFalse(allTrophies.Exists(t => t.Id == 1));  // Sørg for, at trofæet med Id = 1 er fjernet

			Assert.IsNull(repository.Remove(0));
		}


		// Test for Update() metoden
		[TestMethod]
		public void TestUpdate()
		{
			// Arrange
			Trophy GoodTrophy = new Trophy { Competition = "Updated World Cup", Year = 2023 };
			Trophy BadTrophy = new Trophy { Competition = "Non-existent Trophy", Year = 2023 };

			// Act
			Trophy? result = repository.Update(1, GoodTrophy);
			var allTrophies = repository.Get();
			Trophy? result2 = repository.Update(999, BadTrophy);

			// Assert
		
			var updated = allTrophies.Find(t => t.Id == 1);
			Assert.AreEqual("Updated World Cup", updated.Competition); // Sørg for, at Competition er opdateret
			Assert.AreEqual(2023, updated.Year);  // Sørg for, at Year er opdateret

			Assert.IsNull(result2);
		}
	}
}
