using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaParlor.Data.Enums;

namespace PizzaParlor.Data.Drinks
{
    /// <summary>
    /// The Drink class to have inheritance
    /// </summary>
    public class Drink : INotifyPropertyChanged, IMenuItem
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Method to Invoke Property Changed
        /// </summary>
        /// <param name="propertyName">The Property to change</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// The name of the drink
        /// </summary>
        public virtual string Name { get; } = "Drink";

        /// <summary>
        /// The Description of the drink
        /// </summary>
        public virtual string Description { get; } = "A nice cold Drink";

        /// <summary>
        /// The Price of the drink
        /// </summary>
        public virtual decimal Price { get; } = 0;

        /// <summary>
        /// The calories of the drink
        /// </summary>
        public virtual uint CaloriesPerEach { get { return CaloriesTotal; } }

        /// <summary>
        /// The total calories of the drink
        /// </summary>
        public virtual uint CaloriesTotal { get; } = 0;

        /// <summary>
        /// Private Backing for Ice
        /// </summary>
        private bool _ice = true;

        /// <summary>
        /// Decides weather ice is included for this Drink instance
        /// </summary>
        public bool Ice { 
            get 
            {
                return _ice;
            } 
            set 
            {
                _ice = value;
                OnPropertyChanged(nameof(SpecialInstructions));     
            } 
        }

        /// <summary>
        /// Private backing field for DrinkSize
        /// </summary>
        private Size _size = Size.Medium;



        /// <summary>
        /// The size of this Drink instance
        /// </summary>
        public Size DrinkSize
        {
            get
            {
                return _size;
            }

            set
            {
                _size = Size.Medium;
                if (value == Size.Small) _size = Size.Small;
                if (value == Size.Large) _size = Size.Large;
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(DrinkSize));
                OnPropertyChanged(nameof(SpecialInstructions));
                OnPropertyChanged(nameof(CaloriesPerEach));
                OnPropertyChanged(nameof(CaloriesTotal));
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this Iced Tea instance
        /// </summary>
        public virtual IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                instructions.Add(DrinkSize.ToString());
                return instructions;
            }
        }

        /// <summary>
        /// Returns the name of the drink instance
        /// </summary>
        /// <returns>The name</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
