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
    /// Логика взаимодействия для Form_Of_Control_Form.xaml
    /// </summary>
    public partial class Form_Of_Control_Form : Window
    {
        private string QR = "";
        public Form_Of_Control_Form()
        {
            InitializeComponent();
        }

        DBProcedures procedure = new DBProcedures();
            
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrForm_Of_Control;
            dgFill(QR);
        }

        private void dgFill(string qr)
        {
            Action action = () =>
            {
                DBConnection connection = new DBConnection();
                DBConnection.qrForm_Of_Control = qr;
                connection.Form_Of_ControlFill();
                connection.Dependency.OnChange += Dependency_OnChange;
                dgForm_Of_Control.ItemsSource = connection.dtForm_Of_Control.DefaultView;
                dgForm_Of_Control.Columns[0].Visibility = Visibility.Collapsed;
            };
            Dispatcher.Invoke(action);

        }

        private void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                dgFill(QR);
        }

        private void DgForm_Of_Control_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Name_Of_The_Form"):
                    e.Column.Header = "Название формы контроля";
                    break;
            }

        }

        private void btInsert_Click(object sender, RoutedEventArgs e)
        {
            bool err = false;
            List<TextBox> textBoxes = new List<TextBox>();
            textBoxes.Add(tbName_Of_The_Form);
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
                procedure.spForm_Of_Control_insert(
                tbName_Of_The_Form.Text.ToString());
                dgFill(QR);
                tbName_Of_The_Form.Text = "";
                tbName_Of_The_Form.Background = Brushes.White;
            }
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            bool err = false;
            List<TextBox> textBoxes = new List<TextBox>();
            textBoxes.Add(tbName_Of_The_Form);
            if (tbName_Of_The_Form.Text == "")
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
                    DataRowView ID = (DataRowView)dgForm_Of_Control.SelectedItems[0];
                    procedure.spForm_Of_Control_updated(Convert.ToInt32(
                        ID["ID_Form_Of_Control"]), tbName_Of_The_Form.Text.ToString());
                    dgFill(QR);
                    tbName_Of_The_Form.Text = "";
                    tbName_Of_The_Form.Background = Brushes.White;
                }
            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            if (tbName_Of_The_Form.Text == "")
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
                            (DataRowView)dgForm_Of_Control.SelectedItems[0];
                        procedure.spForm_Of_Control_delete(
                            Convert.ToInt32(ID["ID_Form_Of_Control"]));
                        dgFill(QR);
                        tbName_Of_The_Form.Background = Brushes.White;
                        break;
                }
            }
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgForm_Of_Control.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tbFindValue.Text)

                {
                    dgForm_Of_Control.SelectedItem = dataRow;
                }
            }
        }

        private void btFilter_Click(object sender, RoutedEventArgs e)
        {
            string newQr = QR + " where [Name_Of_The_Form] like '%" + tbFindValue.Text + "%'";
            dgFill(newQr);
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            tbFindValue.Text = "";
            dgFill(QR);
            tbName_Of_The_Form.Text = "";
            tbName_Of_The_Form.Background = Brushes.White;
        }
    }
}
