using System;
using System.Windows.Forms;
using System.Windows;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows.Media;

namespace NLP_Create
{
    /// <summary>
    /// Логика взаимодействия для EU_CMK_RUP_Form.xaml
    /// </summary>
    public partial class EU_CMK_RUP_Form : System.Windows.Window
    {
        private string QR = ""; // переменная, хранящая запрос на вывод данных
        public EU_CMK_RUP_Form()
        {
            InitializeComponent();
        }
        public string Form_Of_Control_ID = ""; // Хранит Код записи таблицы формы контроля из БД
        public string numberSpeciality = "";  // Хранит номер специальности из РУПа
        public string nameSpecialty = ""; // Хранит название специальности из РУПа

        public string Year_Of_Flow = ""; // Хранит год потока из РУПа
        public string Period_Of_Study = ""; // Хранит срок обучения из РУПа
        public string ID_Specialty = ""; // Хранит код записи таблицы специальность

        public string Name_CMK = "1"; // Хранит название ЦМК из РУпа
        public string Name_Of_The_Form = ""; // Хранит название Формы контроля из РУПа

        public string Name_Form_Control = ""; // Переменная, для перебора названий форм контроля из РУПа
        public string Number_Of_Semester = ""; // Хранит номер семестра из РУПа

        public string CMK_ID = ""; // Хранит код записи таблицы ЦМК
        public string RUP_ID = ""; // Хранит код записи таблицы РУП


        public string Educational_Unit_ID = ""; // Хранит название учебной единицы РУПа
        public string Type_Of_Educational_Unit_ID = ""; // Хранит название вида учебной единицы РУПа
        public string CMK_RUP_ID = ""; // Хранит название ЦМК РУПа
        string EU_CMK_RUP_ID = ""; // Хранит вид учебной единицы из РУПа
        string ID_EU_CMK_RUP = "";



        string First_Cell = ""; // Хранение значения номера столбца для поулчения типа учебной единицы
        string Two_Cell = ""; // Хранит в себе название первого столбца РУПа
        string Number_CMK_Exel = ""; // Хранение номера кода названия ЦМК в Документе EXEL
        int Row_First_Cell = 20; // Хранение строки первого столбца
        int Row = 19; // Хранение строки для перебора учебной единицы
        int Cell_First_Cell = 1; // Хранение столбца первого столбца из РУПа

        // Хранение записываемых полей в таблицу УЕ_РУП_ЦМК
        string Prefix = ""; // Значение, полученное из РУПа для записи в таблицу EU_CMK_RUP
        string Total_Number_Of_Hours = ""; // Значение, полученное из РУПа для записи в таблицу EU_CMK_RUP
        string Theoretical_Hours = ""; // Значение, полученное из РУПа для записи в таблицу EU_CMK_RUP
        string Lab_Prac_Hours = ""; // Значение, полученное из РУПа для записи в таблицу EU_CMK_RUP
        string Individual_Work = ""; // Значение, полученное из РУПа для записи в таблицу EU_CMK_RUP
        string Consultations = ""; // Значение, полученное из РУПа для записи в таблицу EU_CMK_RUP
        string Coursework_Project = ""; // Значение, полученное из РУПа для записи в таблицу EU_CMK_RUP
        string Interim_Certification = ""; // Значение, полученное из РУПа для записи в таблицу EU_CMK_RUP

        string ID_Educational_Unit = ""; // Код записи, полученный из БД для записи в таблицу EU_CMK_RUP
        string ID_Type_Of_Educational_Unit = ""; // Код записи, полученный из БД для записи в таблицу EU_CMK_RUP
        string ID_CMK_RUP = ""; // Код записи, полученный из БД для записи в таблицу EU_CMK_RUP
        string ID_Form_Of_Control_EU = ""; // Код записи, полученный из БД для записи в таблицу EU_CMK_RUP
        string ID_EU_CMK_RUP_Zapic = ""; // Код записи, полученный из БД для записи в таблицу EU_CMK_RUP


        private void dgEU_CMK_RUP_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrEU_CMK_RUP; // ЛОжим в переменную значение строки запроса вывода данных из БД
            dgFill(QR); // ЛОжим эту переменную в функцию заполнения datagrid
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //QR = DBConnection.qrEU_CMK_RUP;
            //dgFill(QR);
        }

        private void dgFill(string qr)
        {
            DBConnection connection = new DBConnection(); // подключаемся к классу DBConnection
            DBConnection.qrEU_CMK_RUP = qr; // ЛОжим запрос вывода данных из БД в переменную
            connection.EU_CMK_RUPFill(); // вызываем функцию с запросом и виртуальной таблицей
            dgEU_CMK_RUP.ItemsSource = connection.dtEU_CMK_RUP.DefaultView; // заполняем компонент datagrid 
            // Скрываем ненужные столбцы
            dgEU_CMK_RUP.Columns[0].Visibility = Visibility.Collapsed;
            dgEU_CMK_RUP.Columns[9].Visibility = Visibility.Collapsed;
            dgEU_CMK_RUP.Columns[10].Visibility = Visibility.Collapsed;
            dgEU_CMK_RUP.Columns[11].Visibility = Visibility.Collapsed;
            dgEU_CMK_RUP.Columns[12].Visibility = Visibility.Collapsed;
            //dgEU_CMK_RUP.Columns[13].Visibility = Visibility.Collapsed;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // если поле пустое, или документ не формата .xls, то выводим сообщение ошибки, иначе, начинаем импорт
            if (tbPyt.Text != "" && tbPyt.Text.EndsWith(".xls")) 
            {
                string testingExcel = @tbPyt.Text;
                //string testingExcel = @"C:\Users\чОрт\Desktop\ПП 03.01\Uchebny_plan_09_02_07-Admin_BD_OFO_3g10m_2019KVALY_osf.xls";
                Application xlApp = new Application();
                Workbook xlWorkbook = xlApp.Workbooks.Open(testingExcel, Type.Missing, true); // Подключаемся к документу

                //Заполнение таблички Специальность

                //читаем данные из Excel
                _Worksheet list_1 = (_Worksheet)xlWorkbook.Sheets[1];//Получаем первый лист
                Range xlRange_1 = list_1.UsedRange;//Получаем используемый сектор ячеек в листе
                                                   // ----------------------------------------------------
                numberSpeciality = xlRange_1.Cells[14, 1].Text;// Таблица специальность
                nameSpecialty = xlRange_1.Cells[14, 7].Text;

                queryOfTables("INSERT INTO Specialty values('" + numberSpeciality + "', '" + nameSpecialty + "')"); // Заполнение таблицы специальности

                rc_Specialty.Fill = Brushes.LightSlateGray;
                // ----------------------------------------------------
                //Заполнение таблички РУП
                Year_Of_Flow = xlRange_1.Cells[27, 45].Text; // Таблица РУП
                Period_Of_Study = xlRange_1.Cells[27, 29].Text;
                // Получение айдишника записи из таблицы специальность
                queryOfTables_RUP("select [ID_Specialty] from [dbo].[Specialty] where [Number_Specialty] = '" + numberSpeciality + "' AND [Name_Specialty] = '" + nameSpecialty + "'"); // Получение нужного кода записи из таблицы специальность

                queryOfTables("INSERT INTO RUP values('" + Year_Of_Flow + "', '" + Period_Of_Study + "', " + Convert.ToInt32(ID_Specialty) + ")"); // заполнение таблицы РУП

                rc_RUP.Fill = Brushes.LightSlateGray;
                // ------------------------------------------------------
                //Заполнение таблички ЦМК

                _Worksheet list_11 = (_Worksheet)xlWorkbook.Sheets[11];//Получаем последний лист
                Range xlRange_11 = list_11.UsedRange;//Получаем используемый сектор ячеек в листе
                                                     
                int Row_CMK = 2; // Хранит номер строки
                int Cell_CMK = 3; // Хранит номер столбца
                // Пока название ЦМК не будет равно пустоте, заполняй таблицу Названиями ЦМК
                while (Name_CMK != "")
                {
                    Name_CMK = xlRange_11.Cells[Row_CMK, Cell_CMK].Text; // Таблица ЦМК
                    queryOfTables("INSERT INTO CMK values('" + Name_CMK + "')"); 
                    Row_CMK++;
                    Name_CMK = xlRange_11.Cells[Row_CMK, Cell_CMK].Text;
                }

                rc_CMK.Fill = Brushes.LightSlateGray;
                // ------------------------------------------------------
                //Заполнение таблички Учебные единици и вид учебной единицы
                // ------------------------------------------------------
                _Worksheet list_3 = (_Worksheet)xlWorkbook.Sheets[3];//Получаем 3 лист
                Range xlRange_3 = list_3.UsedRange;//Получаем используемый сектор ячеек в листе
                                                   // ------------------------------------------------------
                Int32 Row_Education = 18; // хранит номер строки
                Int32 Cell_Education = 3; // хранит номер столбца
                string XXX = "";
                // ЗАполнение таблицы Учебные единицы и ВИд учебной единицы
                while (Row_Education <= 149)
                {
                    XXX = xlRange_3.Cells[Row_Education, Cell_Education].Text;
                    if (XXX != "" && XXX != "Всего часов по МДК")
                    {
                        if (XXX == "Базовые дисциплины" || XXX == "Профильные дисциплины" || XXX == "Предлагаемые ОО" || XXX == "Среднее общее образование" || XXX == "ПРОФЕССИОНАЛЬНАЯ ПОДГОТОВКА" ||
                            XXX == "Общий гуманитарный и социально-экономический учебный цикл" || XXX == "Математический и общий естественнонаучный учебный цикл" ||
                            XXX == "Общепрофессиональный цикл" || XXX == "Профессиональный цикл" || XXX == "Разработка модулей программного обеспечения для компьютерных систем" ||
                            XXX == "Осуществление интеграции программных модулей" || XXX == "Сопровождение и обслуживание программного обеспечения компьютерных систем" ||
                            XXX == "Соадминистрирование баз данных и серверов" || XXX == "Разработка, администрирование и защита баз данных")
                        {
                            queryOfTables("INSERT INTO Type_Of_Educational_Unit values('" + XXX + "')"); // Заполнение типа учебной единицы
                        }
                        else
                        {
                            queryOfTables("INSERT INTO Educational_Unit values('" + XXX + "')"); // Заполнение учебной единицы
                        }

                        if (XXX == "Разработка модулей программного обеспечения для компьютерных систем" ||
                            XXX == "Осуществление интеграции программных модулей" || XXX == "Сопровождение и обслуживание программного обеспечения компьютерных систем" ||
                            XXX == "Соадминистрирование баз данных и серверов" || XXX == "Разработка, администрирование и защита баз данных")
                        {
                            queryOfTables("INSERT INTO Educational_Unit values('" + XXX + "')"); // Заполнение учебной единицы
                        }
                    }

                    Row_Education++;
                }
                rc_Education_Unit.Fill = Brushes.LightSlateGray;
                rc_Type_Education_Unit.Fill = Brushes.LightSlateGray;
                // ------------------------------------------------------



                // ------------------------------------------------------                            Заполнение таблицы "форма контроля"

                int Row_F_C = 3; // хранит номер строки
                int Cell_F_C = 4; // хранит номер столбца
                // Пока форма контроля не будет равна Другие, то заполняй таблицу 
                while (Name_Of_The_Form != "Другие")
                {
                    Name_Of_The_Form = xlRange_3.Cells[Row_F_C, Cell_F_C].Text;
                    queryOfTables("INSERT INTO Form_Of_Control values('" + Name_Of_The_Form + "')"); // заполнение таблицы форма контроля
                    Cell_F_C++;
                }
                rc_Form_of_Control.Fill = Brushes.LightSlateGray;

                // ------------------------------------------------------                      Заполнение таблицы "СМК РУП"



                Row_CMK = 2;  // хранит номер строки
                Cell_CMK = 3; // хранит номер столбца

                queryOfTables_RUP_CMK("select [ID_RUP] from [dbo].[RUP] where [Year_Of_Flow] = '" + Year_Of_Flow + "' AND [Period_Of_Study] = '" + Period_Of_Study + "'");// Получить айдишник РУп

                Name_CMK = xlRange_11.Cells[Row_CMK, Cell_CMK].Text;
                while (Row_CMK <= 4)
                {
                    Name_CMK = xlRange_11.Cells[Row_CMK, Cell_CMK].Text;

                    queryOfTables_CMK("select [ID_CMK] from [dbo].[CMK] where [Name_CMK] = '" + Name_CMK + "'");// Получать айдишник цмк



                    queryOfTables("INSERT INTO CMK_RUP values(" + RUP_ID + ", " + CMK_ID + ")"); // Заполнение РУП_ЦМК

                    Row_CMK++;
                }
                rc_CMK_RUP.Fill = Brushes.LightSlateGray;


                // ------------------------------------------------------                       Заполнение таблицы "форма контроля учебных единиц"
                int Row_F_C_UE = 21; // хранит номер строки
                int CellF_C_UE = 4;  // хранит номер столбца
                int Row_Form_Control_EU = 3; // хранит номер строки
                int Cell_Form_Control_EU = 4; // хранит номер столбца
                int Cell_Xranenie_EU = 3; // хранит номер столбца
                string Xranenie_EU = ""; // Хранит значения третьего столбца РУПа

                while (Row_F_C_UE <= 149)
                {
                    // Тут добавляем переменную, которая будет хранить учебную единицу 
                    // Если Переменная  не равна пустоте или виду учебных (Кроме ПМ-ов), то переходим к циклу ниже
                    Xranenie_EU = xlRange_3.Cells[Row_F_C_UE, Cell_Xranenie_EU].Text;

                    if (Xranenie_EU != "" && Xranenie_EU != "Профильные дисциплины" && Xranenie_EU != "Предлагаемые ОО" &&
                        Xranenie_EU != "ПРОФЕССИОНАЛЬНАЯ ПОДГОТОВКА" && Xranenie_EU != "Общий гуманитарный и социально-экономический учебный цикл" &&
                        Xranenie_EU != "Математический и общий естественнонаучный учебный цикл" &&
                        Xranenie_EU != "Общепрофессиональный цикл" && Xranenie_EU != "Профессиональный цикл" && Xranenie_EU != "Всего часов по МДК")
                    {
                        while (Cell_Form_Control_EU <= 9 || CellF_C_UE <= 9)
                        {
                            Name_Form_Control = xlRange_3.Cells[Row_Form_Control_EU, Cell_Form_Control_EU].Text;

                            Number_Of_Semester = xlRange_3.Cells[Row_F_C_UE, CellF_C_UE].Text;

                            queryOfTables_Form_Of_Control_EU("select [ID_Form_Of_Control] from [dbo].[Form_Of_Control] where [Name_Of_The_Form] = '" + Name_Form_Control + "'");

                            if (Number_Of_Semester != "")
                            {
                                queryOfTables("INSERT INTO Form_Of_Control_EU values('" + Number_Of_Semester + "', " + Convert.ToInt32(Form_Of_Control_ID) + ")");

                                // Получаю айдишник только что записавшейся записи в таблицу Form_Of_Control_EU
                                queryOfTables_ID_Form_Of_Control_EU("select [ID_Form_Of_Control_EU] from [dbo].[Form_Of_Control_EU] where [Number_Of_Semester] = '" + Number_Of_Semester + "' AND [Form_Of_Control_ID] = '" + Form_Of_Control_ID + "'");


                                // ЗДЕСЬ СДЕЛАТЬ ТАК, ЧТО БЫ В ЭТОМ ТЕЛЕ УСЛОВИЯ СРАБАТОВАЛО ДОБАВЛЕНИЯ САМЫХ ПЕРВЫХ ЗАПИСЕЙ, ДАБЫ СРАЗУ ЗАПИСЫВАТЬ АЙДИШНИК ФОРМЫ КОНТРОЛЯ УЧЕБНЫХ ЕДИНИЦ
                                // ДАЛЕЕ МАГИЧЕСКИМ ОБРАЗОМ СТРОКА БУДЕТ СДВИГАТЬСЯ ВНИЗ, И ВСЕ ПО НОВОЙ

                                // ПОЛУЧИТЬ ПОЛЕ ПРЕФИКС
                                int Cell_Prefix = 2;
                                Prefix = xlRange_3.Cells[Row_F_C_UE, Cell_Prefix].Text; // ПОЛЕ ПРЕФИКС ЗАПИСАНО 

                                //ПОЛУЧИТЬ АЙДИШНИК РУССКОГО ЯЗЫКА (УЧЕБНЫЕ ДИСЦИПЛИНЫ) И ЗАПИСАТЬ ЕГО В ПЕРЕМЕННУЮ            
                                int Cell_Educational_Unit_ID = 3;
                                Educational_Unit_ID = xlRange_3.Cells[Row_F_C_UE, Cell_Educational_Unit_ID].Text;
                                queryOfTables_Educational_Unit_ID("select [ID_Educational_Unit] from [dbo].[Educational_Unit] where [Name_Of_The_EU] = '" + Educational_Unit_ID + "'");

                                // ПОЛУЧИТЬ АЙДИШНИК ТИПА УЧЕБНОЙ ЕДИНИЦЫ И ЗАПИСАТЬ ЕГО В ПЕРЕМЕННУЮ
                                First_Cell = xlRange_3.Cells[Row_First_Cell, Cell_First_Cell].Text;
                                if (Row_F_C_UE == 75 || Row_F_C_UE == 92 || Row_F_C_UE == 108 || Row_F_C_UE == 123 || Row_F_C_UE == 138)
                                {
                                    First_Cell = xlRange_3.Cells[Row_F_C_UE, Cell_First_Cell].Text;
                                }

                                int Cell_Type_Of_Educational_Unit_ID = 3;

                                switch (First_Cell)
                                {
                                    case "13":
                                        Type_Of_Educational_Unit_ID = xlRange_3.Cells[Row_First_Cell, Cell_Type_Of_Educational_Unit_ID].Text;
                                        queryOfTables_Type_Of_Educational_Unit_ID("select [ID_Type_Of_Educational_Unit] from [dbo].[Type_Of_Educational_Unit] where [Number_Of_Type] = '" + Type_Of_Educational_Unit_ID + "'");
                                        break;
                                    case "24":
                                        Type_Of_Educational_Unit_ID = xlRange_3.Cells[Row_First_Cell, Cell_Type_Of_Educational_Unit_ID].Text;
                                        queryOfTables_Type_Of_Educational_Unit_ID("select [ID_Type_Of_Educational_Unit] from [dbo].[Type_Of_Educational_Unit] where [Number_Of_Type] = '" + Type_Of_Educational_Unit_ID + "'");
                                        break;
                                    case "30":
                                        Type_Of_Educational_Unit_ID = xlRange_3.Cells[Row_First_Cell, Cell_Type_Of_Educational_Unit_ID].Text;
                                        queryOfTables_Type_Of_Educational_Unit_ID("select [ID_Type_Of_Educational_Unit] from [dbo].[Type_Of_Educational_Unit] where [Number_Of_Type] = '" + Type_Of_Educational_Unit_ID + "'");
                                        break;
                                    case "37":
                                        Type_Of_Educational_Unit_ID = xlRange_3.Cells[Row_First_Cell, Cell_Type_Of_Educational_Unit_ID].Text;
                                        queryOfTables_Type_Of_Educational_Unit_ID("select [ID_Type_Of_Educational_Unit] from [dbo].[Type_Of_Educational_Unit] where [Number_Of_Type] = '" + Type_Of_Educational_Unit_ID + "'");
                                        break;
                                    case "45":
                                        Type_Of_Educational_Unit_ID = xlRange_3.Cells[Row_First_Cell, Cell_Type_Of_Educational_Unit_ID].Text;
                                        queryOfTables_Type_Of_Educational_Unit_ID("select [ID_Type_Of_Educational_Unit] from [dbo].[Type_Of_Educational_Unit] where [Number_Of_Type] = '" + Type_Of_Educational_Unit_ID + "'");
                                        break;
                                    case "51":
                                        Type_Of_Educational_Unit_ID = xlRange_3.Cells[Row_First_Cell, Cell_Type_Of_Educational_Unit_ID].Text;
                                        queryOfTables_Type_Of_Educational_Unit_ID("select [ID_Type_Of_Educational_Unit] from [dbo].[Type_Of_Educational_Unit] where [Number_Of_Type] = '" + Type_Of_Educational_Unit_ID + "'");
                                        break;
                                    case "68":
                                        Type_Of_Educational_Unit_ID = xlRange_3.Cells[Row_F_C_UE, Cell_Type_Of_Educational_Unit_ID].Text;
                                        queryOfTables_Type_Of_Educational_Unit_ID("select [ID_Type_Of_Educational_Unit] from [dbo].[Type_Of_Educational_Unit] where [Number_Of_Type] = '" + Type_Of_Educational_Unit_ID + "'");
                                        break;
                                    case "85":
                                        Type_Of_Educational_Unit_ID = xlRange_3.Cells[Row_F_C_UE, Cell_Type_Of_Educational_Unit_ID].Text;
                                        queryOfTables_Type_Of_Educational_Unit_ID("select [ID_Type_Of_Educational_Unit] from [dbo].[Type_Of_Educational_Unit] where [Number_Of_Type] = '" + Type_Of_Educational_Unit_ID + "'");
                                        break;
                                    case "101":
                                        Type_Of_Educational_Unit_ID = xlRange_3.Cells[Row_F_C_UE, Cell_Type_Of_Educational_Unit_ID].Text;
                                        queryOfTables_Type_Of_Educational_Unit_ID("select [ID_Type_Of_Educational_Unit] from [dbo].[Type_Of_Educational_Unit] where [Number_Of_Type] = '" + Type_Of_Educational_Unit_ID + "'");
                                        break;
                                    case "116":
                                        Type_Of_Educational_Unit_ID = xlRange_3.Cells[Row_F_C_UE, Cell_Type_Of_Educational_Unit_ID].Text;
                                        queryOfTables_Type_Of_Educational_Unit_ID("select [ID_Type_Of_Educational_Unit] from [dbo].[Type_Of_Educational_Unit] where [Number_Of_Type] = '" + Type_Of_Educational_Unit_ID + "'");
                                        break;
                                    case "131":
                                        Type_Of_Educational_Unit_ID = xlRange_3.Cells[Row_F_C_UE, Cell_Type_Of_Educational_Unit_ID].Text;
                                        queryOfTables_Type_Of_Educational_Unit_ID("select [ID_Type_Of_Educational_Unit] from [dbo].[Type_Of_Educational_Unit] where [Number_Of_Type] = '" + Type_Of_Educational_Unit_ID + "'");
                                        break;

                                }

                                // ПОЛУЧИТЬ АЙДИШНИК НУЖНОЙ ЗАПИСИ ИЗ ТАБЛИЦЫ CMK_RUP И ЗАПИСАТЬ ЕГО В ПЕРЕМЕННУЮ (В ЗАВИСИМОСТИ ОТ 82 СТОЛБЦА)
                                // Запись значения кода ЦМК с 3 листа эксель
                                int Cell_CMK_RUP_ID = 82;
                                Number_CMK_Exel = xlRange_3.Cells[Row_F_C_UE, Cell_CMK_RUP_ID].Text;
                                // Получение нужного названия ЦМК, относящегося к нужной записи 
                                int Row_LIST_11 = 2;
                                int Cell_LIST_11 = 2;
                                CMK_RUP_ID = xlRange_11.Cells[Row_LIST_11, Cell_LIST_11].Text;
                                while (CMK_RUP_ID.Length < 4)
                                {

                                    if (Number_CMK_Exel == CMK_RUP_ID)
                                    {
                                        Cell_LIST_11++;
                                        CMK_RUP_ID = xlRange_11.Cells[Row_LIST_11, Cell_LIST_11].Text;
                                    }
                                    else
                                    {
                                        Row_LIST_11++;
                                        CMK_RUP_ID = xlRange_11.Cells[Row_LIST_11, Cell_LIST_11].Text;
                                    }
                                }
                                // Получение нужного айдишника из таблица CMK
                                queryOfTables_CMK("select [ID_CMK] from [dbo].[CMK] where [Name_CMK] = '" + CMK_RUP_ID + "'");// Получать айдишник цмк

                                // Получение нужного айдишника из таблицы CMK_RUP          
                                queryOfTables_ID_CMK_RUP("select [ID_CMK_RUP] from [dbo].[CMK_RUP] where [CMK_ID] = '" + CMK_ID + "'");// Получать айдишник цмк_руп

                                // ПОЛУЧИТЬ ОБЩЕЕ КОЛИЧЕСТВО ЧАСОВ (13 СТОЛБЕЦ)
                                int Cell_Total_Number_Of_Hours = 13;
                                Total_Number_Of_Hours = xlRange_3.Cells[Row_F_C_UE, Cell_Total_Number_Of_Hours].Text;

                                // ПОЛУЧИТЬ ТЕОРИТИЧЕСКИЕ ЧАСЫ (14 СТОЛБЕЦ)
                                int Cell_Theoretical_Hours = 14;
                                Theoretical_Hours = xlRange_3.Cells[Row_F_C_UE, Cell_Theoretical_Hours].Text;
                                if (Theoretical_Hours == "")
                                {
                                    Theoretical_Hours = "0";
                                }

                                // ПОЛУЧИТЬ СУММУ ЛАБОРАТОРНЫХ И ТЕОРЕТИЧЕСКИХ ЧАСОВ (15 и 16 СТОЛБЦЫ)
                                int Cell_Prac_Hours = 15;
                                int Cell_Lab_Hours = 16;

                                string Prac_Hours = "";
                                string Lab_Hours = "";

                                Prac_Hours = xlRange_3.Cells[Row_F_C_UE, Cell_Prac_Hours].Text;
                                Lab_Hours = xlRange_3.Cells[Row_F_C_UE, Cell_Lab_Hours].Text;

                                if (Prac_Hours == "")
                                {
                                    Prac_Hours = "0";
                                }
                                if (Lab_Hours == "")
                                {
                                    Lab_Hours = "0";
                                }
                                if (Xranenie_EU == "Учебная практика" || Xranenie_EU == "Производственная практика")
                                {
                                    Lab_Hours = "0";
                                    Prac_Hours = "0";
                                }


                                int qwerty = 0;

                                qwerty = Convert.ToInt32(Prac_Hours) + Convert.ToInt32(Lab_Hours);
                                Lab_Prac_Hours = Convert.ToString(qwerty);

                                // ПОЛУЧИТЬ САМОСТОЯТЕЛЬНУЮ РАБОТУ (11 СТОЛБЕЦ)
                                int Cell_Individual_Work = 11;
                                Individual_Work = xlRange_3.Cells[Row_F_C_UE, Cell_Individual_Work].Text;
                                if (Individual_Work == "")
                                {
                                    Individual_Work = "0";
                                }

                                // ПОЛУЧИТЬ КОНСУЛЬТАЦИЮ (12 СТОЛБЕЦ)
                                int Cell_Consultations = 12;
                                Consultations = xlRange_3.Cells[Row_F_C_UE, Cell_Consultations].Text;
                                if (Consultations == "")
                                {
                                    Consultations = "0";
                                }

                                // ПОЛЕ КУРСОВАЯ РАБОТА/ПРОЕКТ ВСЕГДА БУДЕТ "0", т.к. такого поля в РУПе нету
                                Coursework_Project = "0";

                                // ПОЛУЧИТЬ ПРОМЕЖУТОЧНУЮ АТТЕСТАЦИЮ (17 СТОЛБЕЦ)
                                int Cell_Interim_Certification = 17;
                                Interim_Certification = xlRange_3.Cells[Row_F_C_UE, Cell_Interim_Certification].Text;
                                if (Interim_Certification == "")
                                {
                                    Interim_Certification = "0";
                                }
                                if (Xranenie_EU == "Учебная практика" || Xranenie_EU == "Производственная практика")
                                {
                                    Interim_Certification = "0";
                                }
                                // Пишем запрос на заполнение данных последней таблички
                                if (Xranenie_EU == "Разработка программных модулей" || Xranenie_EU == "Поддержка и тестирование программных модулей" ||
                                    Xranenie_EU == "Разработка мобильных приложений" || Xranenie_EU == "Системное программирование" ||
                                    Xranenie_EU == "Учебная практика" || Xranenie_EU == "Производственная практика" || Xranenie_EU == "Экзамен по профессиональному модулю" ||
                                    Xranenie_EU == "Технология разработки программного обеспечения" || Xranenie_EU == "Инструментальные средства разработки программного обеспечения" ||
                                    Xranenie_EU == "Математическое моделирование" || Xranenie_EU == "Внедрение и поддержка компьютерных систем" ||
                                    Xranenie_EU == "Обеспечение качества функционирования компьютерных систем" || Xranenie_EU == "Управление и автоматизация баз данных" ||
                                    Xranenie_EU == "Сертификация информационных систем" || Xranenie_EU == "Технология разработки и защиты баз данных")
                                {
                                    // Получить айдишник той записи из центральной таблицы, где есть запись с видом учебной единицы "ПМ" (По идее это будет последняя запись)

                                    int Cell = 1;
                                    Two_Cell = xlRange_3.Cells[Row, Cell].Text;

                                    // Получение актуального айдишника записи из таблицы учебные единицы
                                    switch (Two_Cell)
                                    {
                                        case "68":
                                            EU_CMK_RUP_ID = xlRange_3.Cells[Row, Cell_Type_Of_Educational_Unit_ID].Text;
                                            // Получение актуального айдишника записи из таблицы учебные единицы
                                            queryOfTables_EU_CMK_RUP_ID("select [ID_Educational_Unit] from [dbo].[Educational_Unit] where [Name_Of_The_EU] = '" + EU_CMK_RUP_ID + "'");
                                            break;
                                        case "85":
                                            EU_CMK_RUP_ID = xlRange_3.Cells[Row, Cell_Type_Of_Educational_Unit_ID].Text;
                                            queryOfTables_EU_CMK_RUP_ID("select [ID_Educational_Unit] from [dbo].[Educational_Unit] where [Name_Of_The_EU] = '" + EU_CMK_RUP_ID + "'");
                                            break;
                                        case "101":
                                            EU_CMK_RUP_ID = xlRange_3.Cells[Row, Cell_Type_Of_Educational_Unit_ID].Text;
                                            queryOfTables_EU_CMK_RUP_ID("select [ID_Educational_Unit] from [dbo].[Educational_Unit] where [Name_Of_The_EU] = '" + EU_CMK_RUP_ID + "'");
                                            break;
                                        case "116":
                                            EU_CMK_RUP_ID = xlRange_3.Cells[Row, Cell_Type_Of_Educational_Unit_ID].Text;
                                            queryOfTables_EU_CMK_RUP_ID("select [ID_Educational_Unit] from [dbo].[Educational_Unit] where [Name_Of_The_EU] = '" + EU_CMK_RUP_ID + "'");
                                            break;
                                        case "131":
                                            EU_CMK_RUP_ID = xlRange_3.Cells[Row, Cell_Type_Of_Educational_Unit_ID].Text;
                                            queryOfTables_EU_CMK_RUP_ID("select [ID_Educational_Unit] from [dbo].[Educational_Unit] where [Name_Of_The_EU] = '" + EU_CMK_RUP_ID + "'");
                                            break;
                                    }


                                    queryOfTables_EU_CMK_RUP_ID_Zapic("select [ID_EU_CMK_RUP] from [dbo].[EU_CMK_RUP] where [Educational_Unit_ID] = '" + ID_EU_CMK_RUP + "'"); // получение айдишника записи из таблицы EU_CMK_RUP
                                    // Дальше писать в последний столбец за место null тот айдишник
                                    // Заполнение таблицы EU_CMK_RUP
                                    queryOfTables("INSERT INTO EU_CMK_RUP values('" + Prefix + "', '" + Total_Number_Of_Hours + "', '" + Theoretical_Hours + "', '" + Lab_Prac_Hours + "', '" + Individual_Work + "', '" + Consultations + "', '" + Coursework_Project + "', '" + Interim_Certification + "', " + Convert.ToInt32(ID_Educational_Unit) + ", " + Convert.ToInt32(ID_Type_Of_Educational_Unit) + ", " + Convert.ToInt32(ID_Form_Of_Control_EU) + ", " + Convert.ToInt32(ID_CMK_RUP) + ", " + Convert.ToInt32(ID_EU_CMK_RUP_Zapic) + ")");
                                }
                                else
                                {
                                    // Заполнение таблицы EU_CMK_RUP без последнего столбца
                                    queryOfTables("INSERT INTO EU_CMK_RUP values('" + Prefix + "', '" + Total_Number_Of_Hours + "', '" + Theoretical_Hours + "', '" + Lab_Prac_Hours + "', '" + Individual_Work + "', '" + Consultations + "', '" + Coursework_Project + "', '" + Interim_Certification + "', " + Convert.ToInt32(ID_Educational_Unit) + ", " + Convert.ToInt32(ID_Type_Of_Educational_Unit) + ", " + Convert.ToInt32(ID_Form_Of_Control_EU) + ", " + Convert.ToInt32(ID_CMK_RUP) + ", null)");

                                }


                            }
                            Cell_Form_Control_EU++;
                            CellF_C_UE++;
                        }
                        Cell_Form_Control_EU = 4;
                        CellF_C_UE = 4;
                    }

                    Row_F_C_UE++;
                    Row_First_Cell++;
                    Row++;
                }




                rc_Form_of_Control_UE.Fill = Brushes.LightSlateGray;
                rc_EU_CMK_RUP.Fill = Brushes.LightSlateGray;

                dgFill(QR); // выводим записанные данные в БД в таблицу datagrid

                // ------------------------------------------------------

                xlWorkbook.Close(); // закрываем подключение exel
            }
            else
            {
                System.Windows.MessageBox.Show("Вы ввели неправильный путь к документу, документ должен быть формата .xls");
            }
            

        }
        // Функция заполнения таблицы БД полученными данными
        private void queryOfTables(string query)
        {
            SqlConnection connection = new SqlConnection(
            "Data Source = 89.179.240.226,63388;" +
            "Initial Catalog = Educational_institution; Persist Security Info=True; User ID = VolkovVA; Password = @Lp0t%");
            connection.Open();
            SqlCommand command = new SqlCommand(query,connection); 
            command.ExecuteScalar(); // Запись значений в таблицу
            connection.Close();

        }
        // Получение кода записи из таблицы EU_CMK_RUP 
        private void queryOfTables_EU_CMK_RUP_ID_Zapic(string query)
        {
            SqlConnection connection = new SqlConnection(
            "Data Source = 89.179.240.226,63388;" +
            "Initial Catalog = Educational_institution; Persist Security Info=True; User ID = VolkovVA; Password = @Lp0t%");
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            ID_EU_CMK_RUP_Zapic = command.ExecuteScalar().ToString(); // ЗАпись полученного кода записи в переменную
            connection.Close();

        }

        // Получение кода записи из таблицы Учебные единицы РУПа и ЦМК 
        private void queryOfTables_EU_CMK_RUP_ID(string query)
        {
            SqlConnection connection = new SqlConnection(
            "Data Source = 89.179.240.226,63388;" +
            "Initial Catalog = Educational_institution; Persist Security Info=True; User ID = VolkovVA; Password = @Lp0t%");
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            ID_EU_CMK_RUP = command.ExecuteScalar().ToString(); // ЗАпись полученного кода записи в переменную
            connection.Close();

        }

        // Получение кода записи из таблицы ФОрма контроля учебной единицы 
        private void queryOfTables_Form_Of_Control_EU(string query)
        {
            SqlConnection connection = new SqlConnection(
            "Data Source = 89.179.240.226,63388;" +
            "Initial Catalog = Educational_institution; Persist Security Info=True; User ID = VolkovVA; Password = @Lp0t%");
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            Form_Of_Control_ID = command.ExecuteScalar().ToString(); // ЗАпись полученного кода записи в переменную
            connection.Close();

        }

        // Получение кода записи из таблицы специальности СМК_РУП
        private void queryOfTables_ID_CMK_RUP(string query)
        {
            SqlConnection connection = new SqlConnection(
            "Data Source = 89.179.240.226,63388;" +
            "Initial Catalog = Educational_institution; Persist Security Info=True; User ID = VolkovVA; Password = @Lp0t%");
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            ID_CMK_RUP = command.ExecuteScalar().ToString(); // ЗАпись полученного кода записи в переменную
            connection.Close();

        }
        // Получение кода записи из таблицы форма контроля учебной единицы 
        private void queryOfTables_ID_Form_Of_Control_EU(string query)
        {
            SqlConnection connection = new SqlConnection(
            "Data Source = 89.179.240.226,63388;" +
            "Initial Catalog = Educational_institution; Persist Security Info=True; User ID = VolkovVA; Password = @Lp0t%");
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            ID_Form_Of_Control_EU = command.ExecuteScalar().ToString(); // ЗАпись полученного кода записи в переменную
            connection.Close();

        }
        // Получение кода записи из таблицы Тип учебной единицы 
        private void queryOfTables_Type_Of_Educational_Unit_ID(string query)
        {
            SqlConnection connection = new SqlConnection(
            "Data Source = 89.179.240.226,63388;" +
            "Initial Catalog = Educational_institution; Persist Security Info=True; User ID = VolkovVA; Password = @Lp0t%");
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            ID_Type_Of_Educational_Unit = command.ExecuteScalar().ToString(); // ЗАпись полученного кода записи в переменную
            connection.Close();

        }
        // Получение кода записи из таблицы ЦМК 
        private void queryOfTables_CMK(string query)
        {
            SqlConnection connection = new SqlConnection(
            "Data Source = 89.179.240.226,63388;" +
            "Initial Catalog = Educational_institution; Persist Security Info=True; User ID = VolkovVA; Password = @Lp0t%");
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            CMK_ID = command.ExecuteScalar().ToString(); // ЗАпись полученного кода записи в переменную
            connection.Close();

        }
        // Получение кода записи из таблицы учебной единицы
        private void queryOfTables_Educational_Unit_ID(string query)
        {
            SqlConnection connection = new SqlConnection(
            "Data Source = 89.179.240.226,63388;" +
            "Initial Catalog = Educational_institution; Persist Security Info=True; User ID = VolkovVA; Password = @Lp0t%");
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            ID_Educational_Unit = command.ExecuteScalar().ToString(); // ЗАпись полученного кода записи в переменную
            connection.Close();

        }
        // Получение кода записи из таблицы РУП_ЦМК 
        private void queryOfTables_RUP_CMK(string query)
        {
            SqlConnection connection = new SqlConnection(
            "Data Source = 89.179.240.226,63388;" +
            "Initial Catalog = Educational_institution; Persist Security Info=True; User ID = VolkovVA; Password = @Lp0t%");
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            RUP_ID = command.ExecuteScalar().ToString(); // ЗАпись полученного кода записи в переменную
            connection.Close();

        }
        // Получение кода записи из таблицы специальности или РУП
        private void queryOfTables_RUP(string query)
        {
            // Строка подключения
            SqlConnection connection = new SqlConnection(
            "Data Source = 89.179.240.226,63388;" +
            "Initial Catalog = Educational_institution; Persist Security Info=True; User ID = VolkovVA; Password = @Lp0t%");
            connection.Open(); 
            SqlCommand command = new SqlCommand(query, connection);
            ID_Specialty = command.ExecuteScalar().ToString(); // ЗАпись полученного кода записи в переменную
            connection.Close();
        }

        private void dgEU_CMK_RUP_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            // Локализация названий столбцов таблицы
            switch (e.Column.Header)
            {
                case ("Prefix"):
                    e.Column.Header = "Префикс";
                    break;
                case ("Total_Number_Of_Hours"):
                    e.Column.Header = "Общее количество часов";
                    break;
                case ("Theoretical_Hours"):
                    e.Column.Header = "Теоретические часы";
                    break;
                case ("Lab_Prac_Hours"):
                    e.Column.Header = "Лабораторные и практические часы";
                    break;
                case ("Individual_Work"):
                    e.Column.Header = "Индивидуальная работа";
                    break;
                case ("Consultations"):
                    e.Column.Header = "Консультация";
                    break;
                case ("Coursework_Project"):
                    e.Column.Header = "Курсовой проект";
                    break;
                case ("Interim_Certification"):
                    e.Column.Header = "Промежуточная аттекстация";
                    break;
                case ("EU_CMK_RUP_ID"):
                    e.Column.Header = "Код ПМ";
                    break;

            }
        }
    }
    
}
