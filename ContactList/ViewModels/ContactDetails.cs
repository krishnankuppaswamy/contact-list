﻿using ContactList.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace ContactList.ViewModels {
    public class ContactDetails : ViewModelBase, INotifyPropertyChanged {

        public ContactDetails(IContactRepository repository) {
            Repository = repository;
        }

        public ICommand DeleteContactCommand => new RelayCommand(DeleteContact);

        private Contact contact;
        public Contact Contact {
            get { return contact; }
            private set {
                contact = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Contact"));
            }
        }

        public IContactRepository Repository { get; private set; }

        public new event PropertyChangedEventHandler PropertyChanged;

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState) {
            Contact = parameter as Contact;
            await Task.CompletedTask;
        }

        private void DeleteContact() {

            Repository.DeleteContact(contact);

            NavigationService.GoBack();
        }

    }
}
