using System;
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
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace NLP_Create
{
    /// <summary>
    /// Логика взаимодействия для Form_Of_Control_EU_Form.xaml
    /// </summary>
    public partial class Form_Of_Control_EU_Form : Window
    {
        private string QR = "";
        public Form_Of_Control_EU_Form()
        {
            InitializeComponent();
        }
        DBProcedures procedures = new DBProcedures();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrForm_Of_Control_EU;
            dgFill(QR);
            cbFill();
        }

        private void dgFill(string qr)
        {
            Action action = () =>
            {
                DBConnection connection = new DBConnection();
                DBConnection.qrForm_Of_Control_EU = qr;
                connection.Form_Of_Control_EUFill();
                connection.Dependency.OnChange += Dependency_OnChange;
                dgForm_Of_Control_EU.ItemsSource = connection.dtForm_Of_Control_EU.DefaultView;
                dgForm_Of_Control_EU.Columns[0].Visibility = Visibility.Collapsed;
                dgForm_Of_Control_EU.Columns[2].Visibility = Visibility.Collapsed;
            };
            Dispatcher.Invoke(action);

        }

        private void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                dgFill(QR);
        }

        private void cbFill()
        {
            DBConnection connection = new DBConnection();
            connection.Form_Of_ControlFill();
            cbForm_Of_Control_ID.ItemsSource = connection.dtForm_Of_Control.DefaultView;
            cbForm_Of_Control_ID.SelectedValuePath = "ID_Form_Of_Control";
            cbForm_Of_Control_ID.DisplayMemberPath = "Name_Of_The_Form";
        }

        private void DgForm_Of_Control_EU_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Number_Of_Semester"):
                    e.Column.Header = "Номер семестра";
                    break;

            }
        }


    }
}
