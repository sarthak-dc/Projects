// Author: Sarthak Thukran
// Created: April 20 2023
// Updated: April 21 2023
// Description: a model representing instances of a zoo speccies.
using System.ComponentModel.DataAnnotations;

namespace ZooDatabase.Models
{
    public class SpeciesModel

    {
        /// <summary>
        /// Unique Species Id
        /// </summary>
        [Key]
        public int SpeciesId { get; set; }
        /// <summary>
        /// The Species Name.
        /// </summary>

        public string? SpeciesName { get; set; }

        /// <summary>
        /// The animal's species.
        /// </summary>

        [Required(AllowEmptyStrings = true, ErrorMessage = "You must enter the animal's species")]

        [MinLength(3, ErrorMessage = "The species name must be at least (3) letters. ")]
        public string Species { get; set; } = String.Empty;

        /// <summary>
        /// Notes about the Species dietary habits.
        /// </summary>

        [Required(AllowEmptyStrings = false)]
        public string? Diet { get; set; }

        /// <summary>
        /// Is the species considered an endangered species or not?
        /// </summary>

        [Display(Name = "Endangered?")]
        public bool IsEndangered { get; set; }



    }
}