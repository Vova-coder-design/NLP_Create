using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace NLP_Create
{
    /// <summary>
    /// Логика взаимодействия для Educational_Unit_Form.xaml
    /// </summary>
    public partial class Educational_Unit_Form : Window
    {
        private string QR = "";
        public Educational_Unit_Form()
        {
            InitializeComponent();
        }

        DBProcedures procedure = new DBProcedures();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrEducational_Unit;
            dgFill(QR);
        }

        private void dgFill(string qr)
        {
            Action action = () =>
            {
                DBConnection connection = new DBConnection();
                DBConnection.qrEducational_Unit = qr;
                connection.Educational_UnitFill();
                connection.Dependency.OnChange += Dependency_OnChange;
                dgEducational_Unit.ItemsSource = connection.dtEducational_Unit.DefaultView;
                dgEducational_Unit.Columns[0].Visibility = Visibility.Collapsed;
            };
            Dispatcher.Invoke(action);

        }

        private void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                dgFill(QR);
        }

        private void DgEducational_Unit_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Name_Of_The_EU"):
                    e.Column.Header = "Название учебной единицы";
                    break;
            }

        }

        private void btInsert_Click(object sender, RoutedEventArgs e)
        {
            bool err = false;
            List<TextBox> textBoxes = new List<TextBox>();
            textBoxes.Add(tbName_Of_The_EU);
            foreach (TextBox textBox in textBoxes)
            {
                if (textBox.Text.Length > 30 || textBox.Text == "")
                {
                    textBox.Background = Brushes.Red;
                    MessageBox.Show("Поле не может быть пустым, а так же там не должно быть более 30 символов");
                    err = true;
                }
            }

            if (!err)
            {
                procedure.spEducational_Unit_insert(
                tbName_Of_The_EU.Text.ToString());
                dgFill(QR);
                tbName_Of_The_EU.Text = "";
                tbName_Of_The_EU.Background = Brushes.White;
            }
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            bool err = false;
            List<TextBox> textBoxes = new List<TextBox>();
            textBoxes.Add(tbName_Of_The_EU);
            if (tbName_Of_The_EU.Text == "")
            {
                MessageBox.Show("Не выбрана запись или вы не ввели новое значение");

            }
            else
            {
                foreach (TextBox textBox in textBoxes)
                {
                    textBox.Background = Brushes.White;
                    if (textBox.Text.Length > 30 || textBox.Text == "")
                    {
                        MessageBox.Show("Поле не может быть пустым, а так же там не должно быть более 30 символов");
                        textBox.Background = Brushes.Red;
                        err = true;
                    }
                }


                if (!err)
                {
                    DataRowView ID = (DataRowView)dgEducational_Unit.SelectedItems[0];
                    procedure.spEducational_Unit_updated(Convert.ToInt32(
                        ID["ID_Educational_Unit"]), tbName_Of_The_EU.Text.ToString());
                    dgFill(QR);
                    tbName_Of_The_EU.Text = "";
                    tbName_Of_The_EU.Background = Brushes.White;
                }
            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            if (tbName_Of_The_EU.Text == "")
            {
                MessageBox.Show("Не выбрана запись");

            }
            else
            {
                switch (MessageBox.Show("Удалить выбранную запись?",
              "Удаление записи", MessageBoxButton.YesNo,
              MessageBoxImage.Warning))
                {
                    case MessageBoxResult.Yes:
                        DataRowView ID =
                            (DataRowView)dgEducational_Unit.SelectedItems[0];
                        procedure.spEducational_Unit_delete(
                            Convert.ToInt32(ID["ID_Educational_Unit"]));
                        dgFill(QR);
                        tbName_Of_The_EU.Background = Brushes.White;
                        break;
                }
            }
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgEducational_Unit.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tbFindValue.Text)

                {
                    dgEducational_Unit.SelectedItem = dataRow;
                }
            }
        }

        private void btFilter_Click(object sender, RoutedEventArgs e)
        {
            string newQr = QR + " where [Name_Of_The_EU] like '%" + tbFindValue.Text + "%'";
            dgFill(newQr);
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            tbFindValue.Text = "";
            dgFill(QR);
            tbName_Of_The_EU.Text = "";
            tbName_Of_The_EU.Background = Brushes.White;
        }


    }
}
