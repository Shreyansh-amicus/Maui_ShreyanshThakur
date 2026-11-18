using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Maui_ShreyanshThakur.Models
{
    public class Inspection : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Site { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime ScheduledDate { get; set; }

        private bool _isSelected;

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected == value)
                    return;

                _isSelected = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(
            [CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}