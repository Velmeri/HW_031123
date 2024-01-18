using HW_031123.FileManagers;
using HW_031123.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HW_031123.MVVM.MVs
{
	public class MainViewModel : INotifyPropertyChanged
	{
		private Contact _selectedContact;
		private List<Contact> _contacts;
		private readonly string _filePath = "contacts.xml";
		private readonly XmlManager _xmlManager = new XmlManager();

		public Contact SelectedContact
		{
			get => _selectedContact;
			set
			{
				_selectedContact = value;
				OnPropertyChanged(nameof(SelectedContact));
			}
		}

		public ICommand CreateNewContactCommand { get; }
		public ICommand SaveContactCommand { get; }
		public ICommand DeleteContactCommand { get; }

		public MainViewModel()
		{
			CreateNewContactCommand = new ActionCommand(CreateNewContact);
			SaveContactCommand = new ActionCommand(SaveContact);
			DeleteContactCommand = new ActionCommand(DeleteContact);
		}

		public void CreateNewContact()
		{
			SelectedContact = new Contact();

		}

		public void SaveContact()
		{
			if (SelectedContact != null) {
				XmlManager manager = new XmlManager();
				string filePath = "path/to/your/contact/file.xml";
				manager.SaveContact(SelectedContact, filePath);
			}
		}

		public void DeleteContact()
		{
			if (SelectedContact != null && _contacts.Contains(SelectedContact)) {
				_contacts.Remove(SelectedContact);

				foreach (var contact in _contacts) {
					_xmlManager.SaveContact(contact, _filePath);
				}

				SelectedContact = null;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private class ActionCommand : ICommand
		{
			private readonly Action _action;

			public ActionCommand(Action action)
			{
				_action = action;
			}

			public event EventHandler CanExecuteChanged;

			public bool CanExecute(object parameter) => true;

			public void Execute(object parameter)
			{
				_action();
			}
		}
	}
}
