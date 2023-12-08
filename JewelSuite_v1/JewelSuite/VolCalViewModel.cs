using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JewelSuite
{
    public class VolCalViewModel : INotifyPropertyChanged
    {
        private readonly VolCalModel _model;

        public VolCalViewModel(VolCalModel model)
        {
            _model = model;
        }

        private double _fluidContactDepth;
        public double FluidContactDepth
        {
            get { return _fluidContactDepth; }
            set
            {
                if (_fluidContactDepth != value)
                {
                    _fluidContactDepth = value;
                    OnPropertyChanged(nameof(FluidContactDepth));
                }
            }
        }

        private string _selectedUnit;
        public string SelectedUnit
        {
            get { return _selectedUnit; }
            set
            {
                if (_selectedUnit != value)
                {
                    _selectedUnit = value;
                    OnPropertyChanged(nameof(SelectedUnit));
                }
            }
        }

        private double _calculatedVolume;
        public double CalculatedVolume
        {
            get { return _calculatedVolume; }
            set
            {
                if (_calculatedVolume != value)
                {
                    _calculatedVolume = value;
                    OnPropertyChanged(nameof(CalculatedVolume));
                }
            }
        }

        public ObservableCollection<string> Units { get; } = Inputs.LoadUnitsFromConfig();
       
        public ICommand CalculateVolumeCommand => new RelayCommand(CalculateVolume);

        private void CalculateVolume()
        {
            try
            {
                _model.FluidContactDepth = FluidContactDepth * 3.28084;//fluidcontact depth converted into feet
                _model.CalculateVolume();
                ConvertAndCalculate();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }         
        }

        public void ConvertAndCalculate()
        {
            // Convert the volume to the selected unit
            double conversionFactor = GetConversionFactor(SelectedUnit);
            CalculatedVolume = _model.CalculatedVolume * conversionFactor;
        }

        private double GetConversionFactor(string unit)
        {
            switch (unit)
            {
                case "Cubic Meter":
                    return 0.028;
                case "Cubic Feet":
                    return 1;
                case "Barrels":
                    return 0.178;
                default:
                    return 1; 
            }
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
