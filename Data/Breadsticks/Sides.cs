using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaParlor.Data.Enums;

namespace PizzaParlor.Data.Breadsticks
{ 
    /// <summary>
    /// The sides class
    /// </summary>
    public class Sides : INotifyPropertyChanged, IMenuItem
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
        /// The name for this Side
        /// </summary>
        public virtual string Name { get; } = "Side";

        /// <summary>
        /// The description for this Side
        /// </summary>
        public virtual string Description { get; } = "Side description";

        /// <summary>
        /// The price for this Side
        /// </summary>
        public virtual decimal Price { get; }

        /// <summary>
        /// The calories for each item in the Side
        /// </summary>
        public virtual uint CaloriesPerEach { get; }

        /// <summary>
        /// The total calories for all of that Side
        /// </summary>
        public uint CaloriesTotal
        {
            get
            {
                return SideCount * CaloriesPerEach;
            }
        }

        /// <summary>
        /// The instructions for that Side
        /// </summary>
        public virtual IEnumerable<string> SpecialInstructions { get; } = new List<string>();

        /// <summary>
        /// private backing field for the Count Property
        /// </summary>
        protected uint _count = 8;

        /// <summary>
        /// The ammount of sticks in this Wings instance
        /// </summary>
        public virtual uint SideCount
        {
            get
            {
                return _count;
            }
            set
            {
                if (value >= 4 && value <= 12)
                {
                    _count = value;
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(SpecialInstructions));
                    OnPropertyChanged(nameof(CaloriesPerEach));
                    OnPropertyChanged(nameof(CaloriesTotal));
                }
            }
        }

        /// <summary>
        /// Returns the name of the side instance
        /// </summary>
        /// <returns>The name</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
