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
    /// Логика взаимодействия для Role_In_CMK_Form.xaml
    /// </summary>
    public partial class Role_In_CMK_Form : Window
    {
        private string QR = "";
        public Role_In_CMK_Form()
        {
            InitializeComponent();
        }

        DBProcedures procedure = new DBProcedures();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrRole_In_CMK;
            dgFill(QR);
        }

        private void dgFill(string qr)
        {
            Action action = () =>
            {
                DBConnection connection = new DBConnection();
                DBConnection.qrRole_In_CMK = qr;
                connection.Role_In_CMKFill();
                connection.Dependency.OnChange += Dependency_OnChange;
                dgRole_In_CMK.ItemsSource = connection.dtRole_In_CMK.DefaultView;
                dgRole_In_CMK.Columns[0].Visibility = Visibility.Collapsed;
            };
            Dispatcher.Invoke(action);

        }


        private void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                dgFill(QR);
        }

        private void DgRole_In_CMK_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Name_Role"):
                    e.Column.Header = "Название роли";
                    break;
            }

        }

        private void btInsert_Click(object sender, RoutedEventArgs e)
        {
            bool err = false;
            List<TextBox> textBoxes = new List<TextBox>();
            textBoxes.Add(tbName_Role);
            foreach (TextBox textBox in textBoxes)
            {
                if (textBox.Text.Length > 50 || textBox.Text == "")
                {
                    textBox.Background = Brushes.Red;
                    MessageBox.Show("Поле не может быть пустым, а так же там не должно быть более 50 символов");
                    err = true;
                }
            }

            //foreach (DataRowView dataRow in (DataView)dgRole_In_CMK.ItemsSource)
            //{
            //    if (dataRow.Row.ItemArray[1].ToString() == tbName_Role.Text)

            //    {
            //        tbName_Role.Background = Brushes.Red;
            //        MessageBox.Show("Такая роль уже есть в системе");
            //        err = true;
            //    }
            //}
            if (!err)
            {
                procedure.spRole_In_CMK_insert(
                tbName_Role.Text.ToString());
                dgFill(QR);
                tbName_Role.Text = "";
                tbName_Role.Background = Brushes.White;
            }
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            bool err = false;
            List<TextBox> textBoxes = new List<TextBox>();
            textBoxes.Add(tbName_Role);
            if (tbName_Role.Text == "")
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

                //foreach (DataRowView dataRow in (DataView)dgRole_In_CMK.ItemsSource)
                //{
                //    if (dataRow.Row.ItemArray[1].ToString() == tbName_Role.Text)

                //    {
                //        tbName_Role.Background = Brushes.Red;
                //        MessageBox.Show("Такая роль уже есть в системе");
                //        err = true;
                //    }
                //}
                if (!err)
                {
                    DataRowView ID = (DataRowView)dgRole_In_CMK.SelectedItems[0];
                    procedure.spRole_In_CMK_update(Convert.ToInt32(
                        ID["ID_Role_In_CMK"]), tbName_Role.Text.ToString());
                    dgFill(QR);
                    tbName_Role.Text = "";
                    tbName_Role.Background = Brushes.White;
                }
            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            if (tbName_Role.Text == "")
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
                            (DataRowView)dgRole_In_CMK.SelectedItems[0];
                        procedure.spRole_In_CMK_delete(
                            Convert.ToInt32(ID["ID_Role_In_CMK"]));
                        dgFill(QR);
                        tbName_Role.Background = Brushes.White;
                        break;
                }
            }
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgRole_In_CMK.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tbFindValue.Text)

                {
                    dgRole_In_CMK.SelectedItem = dataRow;
                }
            }
        }

        private void btFilter_Click(object sender, RoutedEventArgs e)
        {
            string newQr = QR + " where [Name_Role] like '%" + tbFindValue.Text + "%'";
            dgFill(newQr);
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            tbFindValue.Text = "";
            dgFill(QR);
            tbName_Role.Text = "";
            tbName_Role.Background = Brushes.White;
        }

        private void tbName_Role_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Char i = e.Text[0];
            if (i < 'А' || i > 'я')
                e.Handled = true;
        }
    }
}
