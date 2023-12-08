using System;
using System.Collections.ObjectModel;
using System.Configuration;

namespace JewelSuite
{
    internal class Inputs
    {
        internal static ObservableCollection<string> LoadUnitsFromConfig()
        {
            return new ObservableCollection<string> { "Cubic Meter", "Cubic Feet", "Barrels" };
        }
    }
}