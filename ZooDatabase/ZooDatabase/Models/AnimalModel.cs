// Author: Sarthak Thukran
// Created: April 20 2023
// Updated: April 21 2023
// Description: a model representing instances of a zoo animal.
using System.ComponentModel.DataAnnotations;

namespace ZooDatabase.Models
{
    public class AnimalModel
    {
        /// <summary>
        /// Unique Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The animal's Name.
        /// </summary>

        public string? Name { get; set; }

        /// <summary>
        /// The animal's species.
        /// </summary>

        [Required(AllowEmptyStrings = true, ErrorMessage = "You must enter the animal's species")]

        [MinLength(3, ErrorMessage = "The species name must be at least (3) letters. ")]
        public string SpeciesId { get; set; } = String.Empty;

        /// <summary>
        /// Birth date of the animal (where known).
        /// </summary>

        [Display(Name = "BirthDate")]
        public DateTime? BirthDate { get; set; }


        /// <summary>
        /// This should return the animal's age in years.
        /// </summary>
        public string Age
        {
            get
            {
                // Check if the birthdate is known.
                if (BirthDate != DateTime.MinValue)
                {
                    // Calculate the animal's age based on the current date and the birthdate.
                    TimeSpan Age = (TimeSpan)(DateTime.Now - BirthDate);
                    int years = (int)(Age.TotalDays / 365.25);
                    int months = (int)(((Age.TotalDays / 365.25) - years) * 12);
                    int days = (int)(Age.TotalDays - ((years * 365.25) + (months * 30.44)));

                    // Return the animal's age in years, months, and days.
                    return $"{years} years, {months} months, {days} days";
                }
                else
                {
                    // Return "unknown" if the birthdate is not known.
                    return "unknown";
                }
            }
        }


        /// <summary>
        /// Allows you to print the animal instance as a string.
        /// </summary>
        /// <returns>A description of the animal.</returns>

        public override string ToString()
        {
            if (Name != null)
            {
                return Name + "(" + SpeciesId + ")";
            }
            else
            {
                return SpeciesId.ToString() + "(" + SpeciesId + ")";
            }
        }
    }
}
