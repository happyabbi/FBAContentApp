﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing.Printing;
using FBAContentApp.Entities;
using FBAContentApp.ViewModels;
using FBAContentApp.Models;
using Microsoft.Win32;
using System.Windows.Interop;
using FBAContentApp.Views.AppWindows;

namespace FBAContentApp.Views
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        Properties.Settings settings = new Properties.Settings();

        SettingsViewModel settingsVM = new SettingsViewModel();
        
        public SettingsView()
        {
            InitializeComponent();
            PopulateGUI();
        }

        #region Methods

        /// <summary>
        /// Populates the GUI with values from database & computer. Sets selected items to the settings saved from the application.
        /// </summary>
        void PopulateGUI()
        {
            settingsVM = new SettingsViewModel();
            settings = new Properties.Settings();

            //set item sources
            comboCompanyAddress.ItemsSource = settingsVM.CompanyAddresses;
            comboPrinters.ItemsSource = settingsVM.InstalledPrinters;

            comboPrinters.Items.Refresh();
            comboCompanyAddress.Items.Refresh();

            //disable edit and delete shipFromBtn
            editShipFrBtn.IsEnabled = false;
            deleteShipFrBtn.IsEnabled = false;

            //load settings.printer as selected item
            if (settings.LabelPrinter != null)
            {
                //get index of the saved printer from ViewModel.Installedprinters
                int index = settingsVM.InstalledPrinters.IndexOf(settings.LabelPrinter);
                //set the above to the selected item in the comboBox for printers
                comboPrinters.SelectedIndex = index;

            }

            //load settings.companyAddress Id as the selected item
            if(settings.CompanyAddressId > 0)
            {
                //get the companyAddressModel from settingsViewModel where it's the same ID as the settings.CompAddressID
                int compId = settings.CompanyAddressId;

                int index = settingsVM.CompanyAddresses.FindIndex(c => c.Id == compId);

                //set the combo box to the result
                comboCompanyAddress.SelectedIndex = index;

                //call selected event to change it's value
                comboCompanyAddress_Selected(this.comboCompanyAddress, null);
            }

            if(settings.SaveFileDir != null)
            {
                string saveDir = settings.SaveFileDir;
                txtSaveLocation.Text = saveDir;
            }

        }

        #endregion

        #region Events

        /// <summary>
        /// Opens a new window that allows the user to add a new ShipFrom Company Address to the databse.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newShipFrbtn_Click(object sender, RoutedEventArgs e)
        {
            //open a new window for adding a new Company Ship From.
            CompanyAddressModel comp = new CompanyAddressModel();
            CompanyAddressWin compWindow = new CompanyAddressWin(comp, Utilities.DbQuery.Add);
            compWindow.titleLabel.Content = "Add New Company Ship From";
            compWindow.ShowDialog();

            if (compWindow.DialogResult == true)
            {
                //save updated warehouse to database.
                MessageBox.Show("Company Address successfully saved.");
                PopulateGUI();
            }
            else
            {
                //inform user nothing was done.
                MessageBox.Show("Unable to save the Company Address.");
            }

        }

        /// <summary>
        /// Edits the currently selected company address.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editShipFrBtn_Click(object sender, RoutedEventArgs e)
        {
            if (comboCompanyAddress.SelectedItem is CompanyAddressModel)
            {
                //grab selected item.
                CompanyAddressModel companyAddress = (CompanyAddressModel)comboCompanyAddress.SelectedItem;
                //instantiate new CompanyAddressWin.xaml and pass in selected comp address
                CompanyAddressWin compWindow = new CompanyAddressWin(companyAddress, Utilities.DbQuery.Edit);
                compWindow.titleLabel.Content = "Edit Company Ship From";
                //show the window.
                compWindow.ShowDialog();

                if (compWindow.DialogResult == true) //warehouse edit is successful
                {
                    //save updated warehouse to database.
                    MessageBox.Show("Company Address successfully saved.");
                    PopulateGUI();
                }
                else   //warehouse edit is unsuccessful
                {
                    //inform user nothing was done.
                    MessageBox.Show("Unable to save the Company Address.");
                }

            }
        }

        /// <summary>
        /// Deletes the currently selected company address.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteShipFrBtn_Click(object sender, RoutedEventArgs e)
        {
            //grab selected item.
            CompanyAddressModel companyAddress = (CompanyAddressModel)comboCompanyAddress.SelectedItem;

            //companyviewModel to Delete item.
            CompanyViewModel compVm = new CompanyViewModel(companyAddress);
            if(compVm.CompanyAddressToDb(companyAddress, Utilities.DbQuery.Delete))
            {
                MessageBox.Show(companyAddress.CompanyName + " ship from address successfully deleted.");
            }
            else
            {
                MessageBox.Show("Unable to delete" + companyAddress.CompanyName + " ship from address.");
            }

        }

        /// <summary>
        /// Opens a FolderBrowserDialog box for the user to select where they would like shipment contents files to be saved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void browseBtn_Click(object sender, RoutedEventArgs e)
        {
            string selectedPath = "";
            //open a OpenFileDialog/Browser window so that user can set the output directoy of where to save the contents files
           using(var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                if(dialog.SelectedPath != null)
                {
                    selectedPath = dialog.SelectedPath;
                }
            }

            txtSaveLocation.Text = selectedPath;
        }


        /// <summary>
        /// Saves the settings the user has selected/input.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            //grab all values from window
            string saveDir = txtSaveLocation.Text;
            string labelPrinter = comboPrinters.SelectedItem as string;

            //first check that a company has been selected
            if(comboCompanyAddress.SelectedItem != null)
            {
                CompanyAddressModel comp = (CompanyAddressModel)comboCompanyAddress.SelectedItem;
                int compId = comp.Id;

                //save to settings for persistence
                if (saveDir != null & labelPrinter != null)
                {
                    settings.CompanyAddressId = compId;
                    settings.SaveFileDir = saveDir;
                    settings.LabelPrinter = labelPrinter;
                    settings.Save();
                    //return to main menu
                    Switcher.Switch(new MainMenu());
                }
                else
                {
                    MessageBox.Show("A label printer and save file directory must be selected.");
                }

            }
            else
            {
                MessageBox.Show("A company address must be selected.");
            }
            


            
        }

        /// <summary>
        /// Returns the user to the MainMenu.xaml view and does not save any settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            //do nothing and return to MainMenu page
            Switcher.Switch(new MainMenu());
        }


        /// <summary>
        /// When a CompanyAddress is selected, it displays the full address for the user to view it all, and enables the deletion and editing of the selected address.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboCompanyAddress_Selected(object sender, RoutedEventArgs e)
        {
            if(comboCompanyAddress.SelectedItem is CompanyAddressModel)
            {
                CompanyAddressModel companyAddress = settingsVM.CompanyAddresses[comboCompanyAddress.SelectedIndex];
                txtBlockFullCompanyAddress.Text = companyAddress.LegalEntityName+ "\n"+ companyAddress.CompanyName + "\n" + companyAddress.AddressLine1 + "\n" + companyAddress.AddressLine2 + "\n" + companyAddress.AddressLine3 + "\n" + companyAddress.City + ", " + companyAddress.StateAbrv + " " + companyAddress.ZipCode; ;

                editShipFrBtn.IsEnabled = true;
                deleteShipFrBtn.IsEnabled = true;
            }
        }






        #endregion

    }
}
