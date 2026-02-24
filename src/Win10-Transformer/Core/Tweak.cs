using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Win10_Transformer.Core
{
    public class Tweak : INotifyPropertyChanged
    {
        private bool _isApplied;

        public string Name { get; set; }
        public string Description { get; set; }
        public Action Apply { get; set; }
        public Action Revert { get; set; }
        public Func<bool>? CheckStatus { get; set; }

        public bool IsApplied
        {
            get => _isApplied;
            set
            {
                if (_isApplied != value)
                {
                    _isApplied = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Category
        {
            get
            {
                if (Name.Contains(':'))
                {
                    return Name.Split(':')[0];
                }
                return "General";
            }
        }

        public string DisplayName
        {
            get
            {
                if (Name.Contains(':'))
                {
                    return Name.Split(':')[1].Trim();
                }
                return Name;
            }
        }

        public Tweak(string name, string description, Action apply, Action revert, Func<bool>? checkStatus = null)
        {
            Name = name;
            Description = description;
            Apply = apply;
            Revert = revert;
            CheckStatus = checkStatus;
            _isApplied = false;
        }

        public void RefreshStatus()
        {
            if (CheckStatus != null)
            {
                IsApplied = CheckStatus();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
