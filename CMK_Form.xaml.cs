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
    /// Логика взаимодействия для CMK_Form.xaml
    /// </summary>
    public partial class CMK_Form : Window
    {
        private string QR = "";
        public CMK_Form()
        {
            InitializeComponent();
        }

        DBProcedures procedure = new DBProcedures();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrCMK;
            dgFill(QR);
        }

        private void dgFill(string qr)
        {
            Action action = () =>
            {
                DBConnection connection = new DBConnection();
                DBConnection.qrCMK = qr;
                connection.CMKFill();
                connection.Dependency.OnChange += Dependency_OnChange;
                dgCMK.ItemsSource = connection.dtCMK.DefaultView;
                dgCMK.Columns[0].Visibility = Visibility.Collapsed;
            };
            Dispatcher.Invoke(action);

        }


        private void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                dgFill(QR);
        }

        private void DgCMK_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Name_CMK"):
                    e.Column.Header = "Название ЦМК";
                    break;
            }

        }

        private void btInsert_Click(object sender, RoutedEventArgs e)
        {
            bool err = false;
            List<TextBox> textBoxes = new List<TextBox>();
            textBoxes.Add(tbName_CMK);
            foreach (TextBox textBox in textBoxes)
            {
                if (textBox.Text.Length > 50 || textBox.Text == "")
                {
                    textBox.Background = Brushes.Red;
                    MessageBox.Show("Поле не может быть пустым, а так же там не должно быть более 50 символов");
                    err = true;
                }
            }

            if (!err)
            {
                procedure.spCMK_insert(
                tbName_CMK.Text.ToString());
                dgFill(QR);
                tbName_CMK.Text = "";
                tbName_CMK.Background = Brushes.White;
            }
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            bool err = false;
            List<TextBox> textBoxes = new List<TextBox>();
            textBoxes.Add(tbName_CMK);
            if (tbName_CMK.Text == "")
            {
                MessageBox.Show("Не выбрана запись или вы не ввели новое значение");

            }
            else
            {
                foreach (TextBox textBox in textBoxes)
                {
                    textBox.Background = Brushes.White;
                    if (textBox.Text.Length > 50 || textBox.Text == "")
                    {
                        MessageBox.Show("Поле не может быть пустым, а так же там не должно быть более 50 символов");
                        textBox.Background = Brushes.Red;
                        err = true;
                    }
                }

               
                if (!err)
                {
                    DataRowView ID = (DataRowView)dgCMK.SelectedItems[0];
                    procedure.spCMK_update(Convert.ToInt32(
                        ID["ID_CMK"]), tbName_CMK.Text.ToString());
                    dgFill(QR);
                    tbName_CMK.Text = "";
                    tbName_CMK.Background = Brushes.White;
                }
            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            if (tbName_CMK.Text == "")
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
                            (DataRowView)dgCMK.SelectedItems[0];
                        procedure.spCMK_delete(
                            Convert.ToInt32(ID["ID_CMK"]));
                        dgFill(QR);
                        tbName_CMK.Background = Brushes.White;
                        break;
                }
            }
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgCMK.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tbFindValue.Text)

                {
                    dgCMK.SelectedItem = dataRow;
                }
            }
        }

        private void btFilter_Click(object sender, RoutedEventArgs e)
        {
            string newQr = QR + " where [Name_CMK] like '%" + tbFindValue.Text + "%'";
            dgFill(newQr);
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            tbFindValue.Text = "";
            dgFill(QR);
            tbName_CMK.Text = "";
            tbName_CMK.Background = Brushes.White;
        }
    }
}
