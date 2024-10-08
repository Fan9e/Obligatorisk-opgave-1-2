using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_opgave_1_2
{
	public class Trophy
	{
        public int Id { get; set; }
		public string Competition { get; set; }
		public int Year { get; set; }

		public override string ToString() 
		{
			return $"{Id}, {Competition}, {Year}";
		}

		public void ValidateCompetition()
		{
			if (Competition == null)
			{
				throw new ArgumentNullException(nameof(Competition), "Title cannot be null");
			}
			if (Competition.Length < 3)
			{
				throw new ArgumentException("Title must be at least 3 characters", nameof(Competition));
			}
		}

		public void ValidateYear()
		{
			if (Year < 1970)
			{
				throw new ArgumentOutOfRangeException(nameof(Year), "Year must be at least 1970");
			}
			if (Year > 2024)
			{
				throw new ArgumentOutOfRangeException(nameof(Year), "Year must be at under 2024");
			}
		}

		public void validate()
		{
			ValidateCompetition();
			ValidateYear();
		}




	}


}
