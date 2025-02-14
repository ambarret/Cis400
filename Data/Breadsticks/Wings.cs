﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaParlor.Data.Enums;

namespace PizzaParlor.Data.Breadsticks
{
    /// <summary>
    /// The Wings class
    /// </summary>
    public class Wings : Sides
    {
        /// <summary>
        /// The name of the Wings instance
        /// </summary>
        public override string Name { get; } = "Wings";

        /// <summary>
        /// The description of the Wings instance
        /// </summary>
        public override string Description { get; } = "Chicken wings tossed in sauce";

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
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(SpecialInstructions));
                OnPropertyChanged(nameof(CaloriesPerEach));
                OnPropertyChanged(nameof(CaloriesTotal));
            }
        }

        /// <summary>
        /// Backing Field for Wings
        /// </summary>
        private bool _boneIn = true;

        /// <summary>
        /// Checks if this Wings instance requires bone in
        /// </summary>
        public bool BoneIn 
        {
            get { return _boneIn; }
            set {
                _boneIn = value;               
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(SpecialInstructions));
                OnPropertyChanged(nameof(CaloriesPerEach));
                OnPropertyChanged(nameof(CaloriesTotal));
            } 
        }

        /// <summary>
        /// private backing field for the Count Property
        /// </summary>
        protected new uint _count = 5;

        /// <summary>
        /// The ammount of sticks in this Wings instance
        /// </summary>
        public override uint SideCount
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
        /// The price for this instance of the Wings class
        /// </summary>
        public override decimal Price
        {
            get
            {
                if (BoneIn) return 1.50m * SideCount;
                return 1.75m * SideCount;
            }
        }

        /// <summary>
        /// The calories for each Wing in this instance
        /// </summary>
        public override uint CaloriesPerEach
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
        /// Special instructions for the preperation for the Wings instance
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (BoneIn) instructions.Add($"{SideCount} Bone-In Wings");
                else instructions.Add($"{SideCount} Boneless Wings");
                instructions.Add(Sauce.ToString());
                return instructions;
            }
        }
    }
}
