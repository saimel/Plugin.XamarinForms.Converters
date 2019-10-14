// MainPageViewModel.cs
//
// Author: Saimel Saez <saimelsaez@gmail.com>
//
// 8/12/2019
//
// --------------------------------------------------

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Demo.Enums;
using Xamarin.Forms;

namespace Demo
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string _text;
        private double _number;
        private EventType _eventType;
        private bool _isToggled;
        private int? _nullInteger;

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                NotifyPropertyChanged();
            }
        }

        public double Number
        {
            get => _number;
            set
            {
                _number = value;
                NotifyPropertyChanged();
            }
        }

        public EventType EventType
        {
            get => _eventType;
            set {
                _eventType = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsToggled
        {
            get => _isToggled;
            set
            {
                _isToggled = value;
                NotifyPropertyChanged();
            }
        }

        public int? NullInteger
        {
            get => _nullInteger;
            set
            {
                _nullInteger = value;
                if (_nullInteger.Equals(0d))
                {
                    _nullInteger = null;
                }

                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(NullIntegerSwitched));
            }
        }

        public int? NullIntegerSwitched
        {
            get
            {
                if (NullInteger.HasValue)
                    return null;

                return 1;
            }
        }

        public ICommand SwitchNullCommand { get; set; }

        public MainPageViewModel()
        {
            _text = "HELLO WORLD";
            _eventType = EventType.None;

            SwitchNullCommand = new Command(
                execute: () =>
                {
                    if (NullInteger.HasValue)
                    {
                        NullInteger = null;
                    }
                    else
                    {
                        NullInteger = 1;
                    }
                }
            );
        }

        #region Interface implementations

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
