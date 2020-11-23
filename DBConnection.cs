using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace NLP_Create
{
    class DBConnection
    {
        public static SqlConnection connection = new SqlConnection(
            "Data Source = 89.179.240.226,63388;" +
            "Initial Catalog = Educational_institution; Persist Security Info=True; User ID = VolkovVA; Password = @Lp0t%"); // Строка подключения к источнику данных
        public SqlDependency Dependency = new SqlDependency(); // создание компонента для определения отличия результатов запроса БД от изначально полученных
        public DataTable dtRole_In_CMK = new DataTable("Role_In_CMK");
        public DataTable dtCMK = new DataTable("CMK");
        public DataTable dtSpecialty = new DataTable("Specialty");
        public DataTable dtGroup = new DataTable("Group");
        public DataTable dtRUP = new DataTable("RUP");
        public DataTable dtCMK_RUP = new DataTable("CMK_RUP");
        public DataTable dtDistribution_CMK = new DataTable("Distribution_CMK");
        public DataTable dtNLP = new DataTable("NLP");
        public DataTable dtRequest = new DataTable("Request");
        public DataTable dtEducational_Unit = new DataTable("Educational_Unit");
        public DataTable dtType_Of_Educational_Unit = new DataTable("Type_Of_Educational_Unit");
        public DataTable dtForm_Of_Control = new DataTable("Form_Of_Control");
        public DataTable dtForm_Of_Control_EU = new DataTable("Form_Of_Control_EU");
        public DataTable dtEU_CMK_RUP = new DataTable("EU_CMK_RUP"); // Создание виртуальной таблицы



        public static string
            qrRole_In_CMK = "select [ID_Role_In_CMK], [Name_Role] from [dbo].[Role_In_CMK] ",
            qrCMK = "select [ID_CMK], [Name_CMK] from [dbo].[CMK] ",
            qrSpecialty = "select [ID_Specialty], [Number_Specialty], [Name_Specialty] from [dbo].[Specialty] ",
            qrGroup = "select [ID_Group], [Name_Group], [Specialty_ID], " +
            "Convert(varchar, [Name_Specialty]) as \"Специальность\" from [dbo].[Group] " +
            "inner join [dbo].[Specialty] on [dbo].[Specialty].[ID_Specialty] = [dbo].[Group].[Specialty_ID] ",
            qrRUP = "select [ID_RUP], [Year_Of_Flow], [Period_Of_Study], [Specialty_RUP_ID], " +
            "Convert(varchar, [Name_Specialty]) as \"Специальность\" from [dbo].[RUP] " +
            "inner join [dbo].[Specialty] on [dbo].[Specialty].[ID_Specialty] = [dbo].[RUP].[Specialty_RUP_ID] ",
            qrCMK_RUP = "select [ID_CMK_RUP], [RUP_ID], [CMK_ID], " +
            "Convert(varchar, [Name_CMK]) as \"Название ЦМК\", " +
            "Convert(varchar, [Year_Of_Flow]) as \"Год потока\" from [dbo].[CMK_RUP] " +
            "inner join [dbo].[CMK] on [dbo].[CMK].[ID_CMK] = [dbo].[CMK_RUP].[CMK_ID] " +
            "inner join [dbo].[RUP] on [dbo].[RUP].[ID_RUP] = [dbo].[CMK_RUP].[RUP_ID] ",
            qrDistribution_CMK = "select [ID_Distribution], [Role_In_CMK_ID], [CMK_Distribution_ID], [Plurality_Distribution_ID], " +
            "Convert(varchar, [Name_Role]) as \"Название роли\", " +
            "Convert(varchar, [Name_CMK]) as \"Название ЦМК\", " +
            "Convert(varchar, [Surname]+' '+[Name]+' '+[Second_Name]+' '+[Position_name]) as \"ФИО+должность\" from [dbo].[Distribution_CMK] " +
            "inner join [dbo].[Role_In_CMK] on [dbo].[Role_In_CMK].[ID_Role_In_CMK] = [dbo].[Distribution_CMK].[Role_In_CMK_ID] " +
            "inner join [dbo].[CMK] on [dbo].[CMK].[ID_CMK] = [dbo].[Distribution_CMK].[CMK_Distribution_ID] " +
            "inner join [dbo].[Plurality] on [dbo].[Plurality].[ID_Plurality] = [dbo].[Distribution_CMK].[Plurality_Distribution_ID] " +
            "inner join [dbo].[Positions] on [dbo].[Positions].[Id_Position] = [dbo].[Plurality].[PositionId_Position] " +
            "inner join [dbo].[Employees] on [dbo].[Employees].[Id_Employee] = [dbo].[Plurality].[EmployeeId_Employee] ",
            qrEducational_Unit = "select [ID_Educational_Unit], [Name_Of_The_EU] from [dbo].[Educational_Unit] ",
            qrType_Of_Educational_Unit = "select [ID_Type_Of_Educational_Unit], [Number_Of_Type] from [dbo].[Type_Of_Educational_Unit] ",
            qrForm_Of_Control = "select [ID_Form_Of_Control], [Name_Of_The_Form] from [dbo].[Form_Of_Control] ",
            qrForm_Of_Control_EU = "select [ID_Form_Of_Control_EU], [Number_Of_Semester], Form_Of_Control_ID, " +
            "Convert(varchar, [Name_Of_The_Form]) as \"Название формы\" from [dbo].[Form_Of_Control_EU] " +
            "inner join [dbo].[Form_Of_Control] on [dbo].[Form_Of_Control].[ID_Form_Of_Control] = [dbo].[Form_Of_Control_EU].[Form_Of_Control_ID] ",
            // Строка подключения к таблице [dbo].[EU_CMK_RUP] на вывод всех данных из таблицы
            qrEU_CMK_RUP = "select [ID_EU_CMK_RUP], [Prefix], [Total_Number_Of_Hours], [Theoretical_Hours], [Lab_Prac_Hours], [Individual_Work], " +
            "[Consultations], [Coursework_Project], [Interim_Certification], " +
            "Educational_Unit_ID, Type_Of_Educational_Unit_ID, Form_Of_Control_EU_ID, CMK_RUP_ID, EU_CMK_RUP_ID, " +
            "Convert(varchar, [Name_Of_The_EU]) as \"Название учебной единицы\", " +
            "Convert(varchar, [Number_Of_Type]) as \"Тип учебной единицы\", " +
            "Convert(varchar, [Number_Of_Semester]+ ' - ' +[Name_Of_The_Form]) as \"Номер семестра+Форма контроля\", " +
            "Convert(varchar, [Year_Of_Flow]+ ' ' +[Name_CMK]) as \"ЦМК РУП\", " +
            "Convert(varchar, [Prefix]) as \"Учебные единицы РУП ЦМК прификс\" from [dbo].[EU_CMK_RUP] " +
            "inner join [dbo].[Educational_Unit] on [dbo].[Educational_Unit].[ID_Educational_Unit] = [dbo].[EU_CMK_RUP].Educational_Unit_ID " +
            "inner join [dbo].[Type_Of_Educational_Unit] on [dbo].[Type_Of_Educational_Unit].[ID_Type_Of_Educational_Unit] = [dbo].[EU_CMK_RUP].Type_Of_Educational_Unit_ID " +
            "inner join [dbo].[Form_Of_Control_EU] on [dbo].[Form_Of_Control_EU].[ID_Form_Of_Control_EU] = [dbo].[EU_CMK_RUP].Form_Of_Control_EU_ID " +
            "inner join [dbo].[Form_Of_Control] on [dbo].[Form_Of_Control].[ID_Form_Of_Control] = [dbo].[Form_Of_Control_EU].Form_Of_Control_ID " +
            "inner join [dbo].[CMK_RUP] on [dbo].[CMK_RUP].[ID_CMK_RUP] = [dbo].[EU_CMK_RUP].CMK_RUP_ID " +
            "inner join [dbo].[RUP] on [dbo].[RUP].[ID_RUP] = [dbo].[CMK_RUP].[RUP_ID] " +
            "inner join [dbo].[CMK] on [dbo].[CMK].[ID_CMK] = [dbo].[CMK_RUP].[CMK_ID] ",
            qrNLP = "select [ID_NLP], [Date_Forming], [Number_Of_Weeks], [Hours_Per_Week], " +
            "[EU_CMK_RUP_NLP_ID], [Group_ID], [Distribution_ID], " +
            "Convert(varchar, [Prefix]) as \"УЕ ЦМК РУП Префикс\", " +
            "Convert(varchar, [Name_Group]) as \"Название группы\", " +
            "Convert(varchar, [Surname]+' '+[Name]+' '+[Second_Name]) as \"Распределение сотрудника\" from [dbo].[NLP] " +
            "inner join [dbo].[EU_CMK_RUP] on [dbo].[EU_CMK_RUP].[ID_EU_CMK_RUP] = [dbo].[NLP].[EU_CMK_RUP_NLP_ID] " +
            "inner join [dbo].[Group] on [dbo].[Group].[ID_Group] = [dbo].[NLP].[Group_ID] " +
            "inner join [dbo].[Distribution_CMK] on [dbo].[Distribution_CMK].[ID_Distribution] = [dbo].[NLP].[Distribution_ID] " +
            "inner join [dbo].[Plurality] on [dbo].[Plurality].[ID_Plurality] = [dbo].[Distribution_CMK].[Plurality_Distribution_ID] " +
            "inner join [dbo].[Employees] on [dbo].[Employees].[Id_Employee] = [dbo].[Plurality].[EmployeeId_Employee] ",
            qrRequest = "select [ID_Request], [Status], [Text_Request], [NLP_Request_ID] , " +
            "Convert(varchar, [Date_Forming]+ ' ' +[Surname]+' '+[Name]+' '+[Second_Name]) as \"НЛП\" from [dbo].[Request] " +
            "inner join [dbo].[NLP] on [dbo].[NLP].[ID_NLP] = [dbo].[Request].[NLP_Request_ID] " +
            "inner join [dbo].[Distribution_CMK] on [dbo].[Distribution_CMK].[ID_Distribution] = [dbo].[NLP].[Distribution_ID] " +
            "inner join [dbo].[Plurality] on [dbo].[Plurality].[ID_Plurality] = [dbo].[Distribution_CMK].[Plurality_Distribution_ID] " +
            "inner join [dbo].[Employees] on [dbo].[Employees].[Id_Employee] = [dbo].[Plurality].[EmployeeId_Employee] ";








        private SqlCommand command = new SqlCommand("", connection); // создание объекта "command" для подключения к БД
        public static Int32 IDrecord, IDuser;
        //public void dbEnter(string login, string password)
        //{
        //    command.CommandText = "SELECT count(*) FROM [dbo].[Employee] " +
        //        "where [Employee_Login] = '" + login + "' and [Employee_Password] = '" +
        //            password + "'";
        //    connection.Open();
        //    IDuser = Convert.ToInt32(command.ExecuteScalar().ToString());
        //    connection.Close();
        //}

        // Функция на вывод данных из таблицы БД
        private void dtFill(DataTable table, string query)
        {
            command.Notification = null;
            Dependency.AddCommandDependency(command);
            SqlDependency.Start(connection.ConnectionString);
            command.CommandText = query; // Кладем запрос в переменную 
            connection.Open(); // Открываем подключение
            table.Load(command.ExecuteReader()); // Считывание таблицы баз данных
            connection.Close(); // ЗАкрываем подключение
        }

        public void Role_In_CMKFill()
        {
            dtFill(dtRole_In_CMK, qrRole_In_CMK);
        }

        public void CMKFill()
        {
            dtFill(dtCMK, qrCMK);
        }

        public void SpecialtyFill()
        {
            dtFill(dtSpecialty, qrSpecialty);
        }

        public void GroupFill()
        {
            dtFill(dtGroup, qrGroup);
        }

        public void RUPFill()
        {
            dtFill(dtRUP, qrRUP);
        }

        public void CMK_RUPFill()
        {
            dtFill(dtCMK_RUP, qrCMK_RUP);
        }

        public void Distribution_CMKFill()
        {
            dtFill(dtDistribution_CMK, qrDistribution_CMK);
        }

        public void NLPFill()
        {
            dtFill(dtNLP, qrNLP);
        }

        public void RequestFill()
        {
            dtFill(dtRequest, qrRequest);
        }

        public void Educational_UnitFill()
        {
            dtFill(dtEducational_Unit, qrEducational_Unit);
        }

        public void Type_Of_Educational_UnitFill()
        {
            dtFill(dtType_Of_Educational_Unit, qrType_Of_Educational_Unit);
        }

        public void Form_Of_ControlFill()
        {
            dtFill(dtForm_Of_Control, qrForm_Of_Control);
        }

        public void Form_Of_Control_EUFill()
        {
            dtFill(dtForm_Of_Control_EU, qrForm_Of_Control_EU);
        }
        // Функция хранит в себе текст запроса БД и название виртуальной таблицы datatable
        public void EU_CMK_RUPFill()
        {
            dtFill(dtEU_CMK_RUP, qrEU_CMK_RUP);
        }


    }
}
