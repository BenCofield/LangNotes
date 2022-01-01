using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace LangNotes
{
	public class MainPageViewModel : INotifyPropertyChanged
	{
		public MainPageViewModel()
		{
			EraseCommand = new Command(() =>
			{
				Note = string.Empty;
			});

			SaveCommand = new Command(() =>
			{
				AllNotes.Add(Note);

				Note = string.Empty;
			});
		}

		public ObservableCollection<string> AllNotes = new ObservableCollection<string>();

        public event PropertyChangedEventHandler PropertyChanged;

		string note;

		public string Note
		{
			get => note;
			set
			{
				note = value;

				var args = new PropertyChangedEventArgs(nameof(Note));

				PropertyChanged?.Invoke(this, args);
			}
		}

		public Command SaveCommand { get; }

		public Command EraseCommand { get; }
    }
}

