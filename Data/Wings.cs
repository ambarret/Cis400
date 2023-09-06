using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// The Wings class
    /// </summary>
    public class Wings
    {
        /// <summary>
        /// The name of the Wings instance
        /// </summary>
        public string Name { get; } = "Wings";

        /// <summary>
        /// The description of the Wings instance
        /// </summary>
        public string Description { get; } = "Chicken wings tossed in sauce";

        /// <summary>
        /// private backing field for the wingsauce property
        /// </summary>
        private WingSauce _sauce = WingSauce.Medium;

        /// <summary>
        /// The sauce for this Wings instance
        /// </summary>
        public WingSauce Sauce
        {
            get
            {
                return _sauce;
            }
            set
            {
                _sauce = WingSauce.Medium;
                if (value == WingSauce.Mild) _sauce = WingSauce.Mild;
                if (value == WingSauce.Hot) _sauce = WingSauce.Hot;
                if (value == WingSauce.HoneyBBQ) _sauce = WingSauce.HoneyBBQ;
            }
        }

        /// <summary>
        /// Checks if this Wings instance requires bone in
        /// </summary>
        public bool BoneIn { get; set; } = true;

        /// <summary>
        /// private backing field for the Count Property
        /// </summary>
        private uint _count = 5;

        /// <summary>
        /// The ammount of sticks in this Wings instance
        /// </summary>
        public uint Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value >= 4)
                {
                    if (value <= 12)
                    {
                        _count = value;
                    }
                    else
                    {
                        _count = 12;
                    }
                }
                else
                {
                    _count = 4;
                }
            }
        }

        /// <summary>
        /// The price for this instance of the Wings class
        /// </summary>
        public decimal Price
        {
            get
            {
                if (BoneIn) return 1.50m * Count;
                return 1.75m * Count;
            }
        }

        /// <summary>
        /// The calories for each Wing in this instance
        /// </summary>
        public uint CaloriesPerEach
        {
            get
            {
                uint cal = 125;
                if (!BoneIn) cal += 50;
                if (Sauce == WingSauce.HoneyBBQ) cal += 20;
                return cal;
            }
        }

        /// <summary>
        /// the total ammount of calories for this wings instance
        /// </summary>
        public uint CaloriesTotal
        {
            get
            {
                return Count * CaloriesPerEach;
            }
        }

        /// <summary>
        /// Special instructions for the preperation for the Wings instance
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (BoneIn) instructions.Add($"{Count} Bone-In Wings");
                else instructions.Add($"{Count} Boneless Wings");
                instructions.Add(Sauce.ToString());
                return instructions;
            }
        }
    }
}
