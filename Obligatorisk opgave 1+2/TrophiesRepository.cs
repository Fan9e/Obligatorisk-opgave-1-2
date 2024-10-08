namespace Obligatorisk_opgave_1_2
{
	public class TrophiesRepository
	{
		//Listen over trophys
		private  List<Trophy> _trophyList;
		public int nextId = 1;

		//Konstruktør hvor vi initialiserer listen med mindst 5 Trophy-objekter
		public TrophiesRepository()
		{
			_trophyList = new List<Trophy>()
			{
			new Trophy { Id = nextId++, Competition = "World Cup", Year = 2022 },
			new Trophy { Id = nextId++, Competition = "Champions League", Year = 2021 },
			new Trophy { Id = nextId++, Competition = "Premier League", Year = 2020 },
			new Trophy { Id = nextId++, Competition = "Copa America", Year = 2019 },
			new Trophy { Id = nextId++, Competition = "Euro Cup", Year = 2018 }
			};
		}


		// Get() metode uden filtrering eller sortering: Returnerer en kopi af listen
		public List<Trophy> Get()
		{
			// Returnerer en ny liste, der er en kopi af den originale
			return new List<Trophy>(_trophyList);
		}

		// Get() med filtrering på år
		public IEnumerable<Trophy> Get(int year)

		{
			IEnumerable<Trophy> kopiList = new List<Trophy>(_trophyList);
			
			kopiList = kopiList.Where(t => t.Year == year);
			
			// Filtrerer listen baseret på year
			return kopiList;
		}

		// Get() med sortering: sortBy kan være "Competition" eller "Year"
		public IEnumerable<Trophy> Get(string sortBy)
		{
			IEnumerable<Trophy> kopiList = new List<Trophy>(_trophyList);
			if (sortBy.ToLower() == "competition")
			{
				// Sorterer listen baseret på Competition i alfabetisk rækkefølge
				kopiList = kopiList.OrderBy(t => t.Competition);
			}
			else if (sortBy.ToLower() == "year")
			{
				// Sorterer listen baseret på Year i stigende rækkefølge
				 kopiList = kopiList.OrderBy(t => t.Year);
			}
				// Hvis ingen gyldig sortering er angivet, returneres listen uden sortering
				return kopiList;
		}

		// Add() metode: Tilføjer et nyt Trophy til listen
		public Trophy Add(Trophy trophy)
		{
			trophy.validate();
			trophy.Id = nextId++;

			_trophyList.Add(trophy); // Tilføjer det nye Trophy til listen
			return trophy;
		}

		public Trophy? GetById(int id) 
		{
			return _trophyList.Find(t => t.Id == id);
			
		}


		// Remove() metode: Fjerner et Trophy baseret på Id
		public Trophy? Remove(int id)
		{
			Trophy? trophyToRemove = GetById(id);
			if (trophyToRemove == null)
			{
				return null;
			}

			_trophyList.Remove(trophyToRemove); // Fjern trofæet
			return trophyToRemove;
		}

		// Update() metode: Opdaterer et eksisterende Trophy baseret på Id
		public Trophy? Update(int id, Trophy values)
		{
			Trophy? existingTrophy = GetById(id);
			if (existingTrophy == null)
			{
				return null;
			}

			// Opdater trofæets data
			existingTrophy.Competition = values.Competition;
			existingTrophy.Year = values.Year;

			return existingTrophy;
		}


	}
}
