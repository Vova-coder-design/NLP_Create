using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace NLP_Create
{
    class DBProcedures
    {
        private SqlCommand command
            = new SqlCommand("", DBConnection.connection);
        private void commandconfig(string config)
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "[dbo].[" + config + "]";
            command.Parameters.Clear();
        }

        // ПРОЦЕДУРЫ ДОБАВЛЕНИЯ ИЗМЕНЕНИЯ УДАЛЕНИЯ ДЛЯ ТАБЛИЦЫ "РОЛЬ В ЦМК"
        public void spRole_In_CMK_insert(string Name_Role)
        {
            commandconfig("Role_In_CMK_insert");
            command.Parameters.AddWithValue("@Name_Role", Name_Role);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void spRole_In_CMK_update(Int32 ID_Role_In_CMK, string Name_Role)
        {
            commandconfig("Role_In_CMK_update");
            command.Parameters.AddWithValue("@ID_Role_In_CMK", ID_Role_In_CMK);
            command.Parameters.AddWithValue("@Name_Role", Name_Role);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        public void spRole_In_CMK_delete(Int32 ID_Role_In_CMK)
        {
            commandconfig("Role_In_CMK_delete");
            command.Parameters.AddWithValue("@ID_Role_In_CMK", ID_Role_In_CMK);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        // ПРОЦЕДУРЫ ДОБАВЛЕНИЯ ИЗМЕНЕНИЯ УДАЛЕНИЯ ДЛЯ ТАБЛИЦЫ "ЦМК"
        public void spCMK_insert(string Name_CMK)
        {
            commandconfig("CMK_insert");
            command.Parameters.AddWithValue("@Name_CMK", Name_CMK);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void spCMK_update(Int32 ID_CMK, string Name_CMK)
        {
            commandconfig("CMK_update");
            command.Parameters.AddWithValue("@ID_CMK", ID_CMK);
            command.Parameters.AddWithValue("@Name_CMK", Name_CMK);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        public void spCMK_delete(Int32 ID_CMK)
        {
            commandconfig("CMK_delete");
            command.Parameters.AddWithValue("@ID_CMK", ID_CMK);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        // ПРОЦЕДУРЫ ДОБАВЛЕНИЯ ИЗМЕНЕНИЯ УДАЛЕНИЯ ДЛЯ ТАБЛИЦЫ "СПЕЦИАЛЬНОСТЬ"

        public void spSpecialty_insert(string Number_Specialty, string Name_Specialty)
        {
            commandconfig("Specialty_insert");
            command.Parameters.AddWithValue("@Number_Specialty", Number_Specialty);
            command.Parameters.AddWithValue("@Name_Specialty", Name_Specialty);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void spSpecialty_update(Int32 ID_Specialty, string Number_Specialty, string Name_Specialty)
        {
            commandconfig("Specialty_update");
            command.Parameters.AddWithValue("@ID_Specialty", ID_Specialty);
            command.Parameters.AddWithValue("@Number_Specialty", Number_Specialty);
            command.Parameters.AddWithValue("@Name_Specialty", Name_Specialty);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        public void spSpecialty_delete(Int32 ID_Specialty)
        {
            commandconfig("Specialty_delete");
            command.Parameters.AddWithValue("@ID_Specialty", ID_Specialty);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        // ПРОЦЕДУРЫ ДОБАВЛЕНИЯ ИЗМЕНЕНИЯ УДАЛЕНИЯ ДЛЯ ТАБЛИЦЫ "ГРУППА"

        public void spGroup_insert(string Name_Group, Int32 Specialty_ID)
        {
            commandconfig("Group_insert");
            command.Parameters.AddWithValue("@Name_Group", Name_Group);
            command.Parameters.AddWithValue("@Specialty_ID", Specialty_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void spGroup_update(Int32 ID_Group, string Name_Group, Int32 Specialty_ID)
        {
            commandconfig("Group_update");
            command.Parameters.AddWithValue("@ID_Group", ID_Group);
            command.Parameters.AddWithValue("@Name_Group", Name_Group);
            command.Parameters.AddWithValue("@Specialty_ID", Specialty_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        public void spGroup_delete(Int32 ID_Group)
        {
            commandconfig("Group_delete");
            command.Parameters.AddWithValue("@ID_Group", ID_Group);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }


        // ПРОЦЕДУРЫ ДОБАВЛЕНИЯ ИЗМЕНЕНИЯ УДАЛЕНИЯ ДЛЯ ТАБЛИЦЫ "РУП"

        public void spRUP_insert(string Year_Of_Flow, string Period_Of_Study, Int32 Specialty_RUP_ID)
        {
            commandconfig("RUP_insert");
            command.Parameters.AddWithValue("@Year_Of_Flow", Year_Of_Flow);
            command.Parameters.AddWithValue("@Period_Of_Study", Period_Of_Study);
            command.Parameters.AddWithValue("@Specialty_RUP_ID", Specialty_RUP_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void spRUP_update(Int32 ID_RUP, string Year_Of_Flow, string Period_Of_Study, Int32 Specialty_RUP_ID)
        {
            commandconfig("RUP_update");
            command.Parameters.AddWithValue("@ID_RUP", ID_RUP);
            command.Parameters.AddWithValue("@Year_Of_Flow", Year_Of_Flow);
            command.Parameters.AddWithValue("@Period_Of_Study", Period_Of_Study);
            command.Parameters.AddWithValue("@Specialty_RUP_ID", Specialty_RUP_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        public void spRUP_delete(Int32 ID_RUP)
        {
            commandconfig("RUP_delete");
            command.Parameters.AddWithValue("@ID_RUP", ID_RUP);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }


        // ПРОЦЕДУРЫ ДОБАВЛЕНИЯ ИЗМЕНЕНИЯ УДАЛЕНИЯ ДЛЯ ТАБЛИЦЫ "ЦМК РУП"

        public void spCMK_RUP_insert(Int32 RUP_ID, Int32 CMK_ID)
        {
            commandconfig("CMK_RUP_insert");
            command.Parameters.AddWithValue("@RUP_ID", RUP_ID);
            command.Parameters.AddWithValue("@CMK_ID", CMK_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void spCMK_RUP_update(Int32 ID_CMK_RUP, Int32 RUP_ID, Int32 CMK_ID)
        {
            commandconfig("CMK_RUP_update");
            command.Parameters.AddWithValue("@ID_CMK_RUP", ID_CMK_RUP);
            command.Parameters.AddWithValue("@RUP_ID", RUP_ID);
            command.Parameters.AddWithValue("@CMK_ID", CMK_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        public void spCMK_RUP_delete(Int32 ID_CMK_RUP)
        {
            commandconfig("CMK_RUP_delete");
            command.Parameters.AddWithValue("@ID_CMK_RUP", ID_CMK_RUP);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }


        // ПРОЦЕДУРЫ ДОБАВЛЕНИЯ ИЗМЕНЕНИЯ УДАЛЕНИЯ ДЛЯ ТАБЛИЦЫ "Распределение ЦМК"

        public void spDistribution_CMK_insert(Int32 Role_In_CMK_ID, Int32 CMK_Distribution_ID, Int32 Plurality_Distribution_ID)
        {
            commandconfig("Distribution_CMK_insert");
            command.Parameters.AddWithValue("@Role_In_CMK_ID", Role_In_CMK_ID);
            command.Parameters.AddWithValue("@CMK_Distribution_ID", CMK_Distribution_ID);
            command.Parameters.AddWithValue("@Plurality_Distribution_ID", Plurality_Distribution_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void spDistribution_CMK_update(Int32 ID_Distribution, Int32 Role_In_CMK_ID, Int32 CMK_Distribution_ID, Int32 Plurality_Distribution_ID)
        {
            commandconfig("Distribution_CMK_update");
            command.Parameters.AddWithValue("@ID_Distribution", ID_Distribution);
            command.Parameters.AddWithValue("@Role_In_CMK_ID", Role_In_CMK_ID);
            command.Parameters.AddWithValue("@CMK_Distribution_ID", CMK_Distribution_ID);
            command.Parameters.AddWithValue("@Plurality_Distribution_ID", Plurality_Distribution_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        public void spDistribution_CMK_delete(Int32 ID_Distribution)
        {
            commandconfig("Distribution_CMK_delete");
            command.Parameters.AddWithValue("@ID_Distribution", ID_Distribution);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }


        // ПРОЦЕДУРЫ ДОБАВЛЕНИЯ ИЗМЕНЕНИЯ УДАЛЕНИЯ ДЛЯ ТАБЛИЦЫ "НЛП"
        public void spNLP_insert(string Date_Forming, string Number_Of_Weeks, string Hours_Per_Week, 
           Int32 EU_CMK_RUP_NLP_ID, Int32 Group_ID, Int32 Distribution_ID)
        {
            commandconfig("NLP_insert");
            command.Parameters.AddWithValue("@Date_Forming", Date_Forming);
            command.Parameters.AddWithValue("@Number_Of_Weeks", Number_Of_Weeks);
            command.Parameters.AddWithValue("@Hours_Per_Week", Hours_Per_Week);
            command.Parameters.AddWithValue("@EU_CMK_RUP_NLP_ID", EU_CMK_RUP_NLP_ID);
            command.Parameters.AddWithValue("@Group_ID", Group_ID);
            command.Parameters.AddWithValue("@Distribution_ID", Distribution_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void spNLP_update(Int32 ID_NLP, string Date_Forming, string Number_Of_Weeks, string Hours_Per_Week,
           Int32 EU_CMK_RUP_NLP_ID, Int32 Group_ID, Int32 Distribution_ID)
        {
            commandconfig("NLP_update");
            command.Parameters.AddWithValue("@ID_NLP ", ID_NLP);
            command.Parameters.AddWithValue("@Date_Forming", Date_Forming);
            command.Parameters.AddWithValue("@Number_Of_Weeks", Number_Of_Weeks);
            command.Parameters.AddWithValue("@Hours_Per_Week", Hours_Per_Week);
            command.Parameters.AddWithValue("@EU_CMK_RUP_NLP_ID", EU_CMK_RUP_NLP_ID);
            command.Parameters.AddWithValue("@Group_ID", Group_ID);
            command.Parameters.AddWithValue("@Distribution_ID", Distribution_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        public void spNLP_delete(Int32 ID_NLP)
        {
            commandconfig("NLP_delete");
            command.Parameters.AddWithValue("@ID_NLP ", ID_NLP);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }


        // ПРОЦЕДУРЫ ДОБАВЛЕНИЯ ИЗМЕНЕНИЯ УДАЛЕНИЯ ДЛЯ ТАБЛИЦЫ "Запрос"

        public void spRequest_insert(bool Status, string Text_Request, Int32 NLP_Request_ID)
        {
            commandconfig("Request_insert");
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@Text_Request", Text_Request);
            command.Parameters.AddWithValue("@NLP_Request_ID", NLP_Request_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void spRequest_update(Int32 ID_Request, bool Status, string Text_Request, Int32 NLP_Request_ID)
        {
            commandconfig("Request_update");
            command.Parameters.AddWithValue("@ID_Request", ID_Request);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@Text_Request", Text_Request);
            command.Parameters.AddWithValue("@NLP_Request_ID", NLP_Request_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        public void spRequest_delete(Int32 ID_Request)
        {
            commandconfig("Request_delete");
            command.Parameters.AddWithValue("@ID_Request", ID_Request);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }


        // ПРОЦЕДУРЫ ДОБАВЛЕНИЯ ИЗМЕНЕНИЯ УДАЛЕНИЯ ДЛЯ ТАБЛИЦЫ "Учебная единица"
        public void spEducational_Unit_insert(string Name_Of_The_EU)
        {
            commandconfig("Educational_Unit_insert");
            command.Parameters.AddWithValue("@Name_Of_The_EU", Name_Of_The_EU);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void spEducational_Unit_updated(Int32 ID_Educational_Unit, string Name_Of_The_EU)
        {
            commandconfig("Educational_Unit_updated");
            command.Parameters.AddWithValue("@ID_Educational_Unit", ID_Educational_Unit);
            command.Parameters.AddWithValue("@Name_Of_The_EU", Name_Of_The_EU);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        public void spEducational_Unit_delete(Int32 ID_Educational_Unit)
        {
            commandconfig("Educational_Unit_delete");
            command.Parameters.AddWithValue("@ID_Educational_Unit", ID_Educational_Unit);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        // ПРОЦЕДУРЫ ДОБАВЛЕНИЯ ИЗМЕНЕНИЯ УДАЛЕНИЯ ДЛЯ ТАБЛИЦЫ "Вид учебной единицы"
        public void spType_Of_Educational_Unit_insert(string Number_Of_Type)
        {
            commandconfig("Type_Of_Educational_Unit_insert");
            command.Parameters.AddWithValue("@Number_Of_Type", Number_Of_Type);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void spType_Of_Educational_Unit_updated(Int32 ID_Type_Of_Educational_Unit, string Number_Of_Type)
        {
            commandconfig("Type_Of_Educational_Unit_updated");
            command.Parameters.AddWithValue("@ID_Type_Of_Educational_Unit", ID_Type_Of_Educational_Unit);
            command.Parameters.AddWithValue("@Number_Of_Type", Number_Of_Type);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        public void spType_Of_Educational_Unit_delete(Int32 ID_Type_Of_Educational_Unit)
        {
            commandconfig("Type_Of_Educational_Unit_delete");
            command.Parameters.AddWithValue("@ID_Type_Of_Educational_Unit", ID_Type_Of_Educational_Unit);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }


        // ПРОЦЕДУРЫ ДОБАВЛЕНИЯ ИЗМЕНЕНИЯ УДАЛЕНИЯ ДЛЯ ТАБЛИЦЫ "Форма контроля"
        public void spForm_Of_Control_insert(string Name_Of_The_Form)
        {
            commandconfig("Form_Of_Control_insert");
            command.Parameters.AddWithValue("@Name_Of_The_Form", Name_Of_The_Form);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void spForm_Of_Control_updated(Int32 ID_Form_Of_Control, string Name_Of_The_Form)
        {
            commandconfig("Form_Of_Control_updated");
            command.Parameters.AddWithValue("@ID_Form_Of_Control", ID_Form_Of_Control);
            command.Parameters.AddWithValue("@Name_Of_The_Form", Name_Of_The_Form);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        public void spForm_Of_Control_delete(Int32 ID_Form_Of_Control)
        {
            commandconfig("Form_Of_Control_delete");
            command.Parameters.AddWithValue("@ID_Form_Of_Control", ID_Form_Of_Control);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }


        // ПРОЦЕДУРЫ ДОБАВЛЕНИЯ ИЗМЕНЕНИЯ УДАЛЕНИЯ ДЛЯ ТАБЛИЦЫ "Форма контроля учебной единицы"

        public void spForm_Of_Control_EU_insert(string Number_Of_Semester, Int32 Form_Of_Control_ID)
        {
            commandconfig("Form_Of_Control_EU_insert");
            command.Parameters.AddWithValue("@Number_Of_Semester", Number_Of_Semester);
            command.Parameters.AddWithValue("@Form_Of_Control_ID", Form_Of_Control_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void spForm_Of_Control_EU_updated(Int32 ID_Form_Of_Control_EU, string Number_Of_Semester, Int32 Form_Of_Control_ID)
        {
            commandconfig("Form_Of_Control_EU_updated");
            command.Parameters.AddWithValue("@ID_Form_Of_Control_EU", ID_Form_Of_Control_EU);
            command.Parameters.AddWithValue("@Number_Of_Semester", Number_Of_Semester);
            command.Parameters.AddWithValue("@Form_Of_Control_ID", Form_Of_Control_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        public void spForm_Of_Control_EU_delete(Int32 ID_Form_Of_Control_EU)
        {
            commandconfig("Form_Of_Control_EU_delete");
            command.Parameters.AddWithValue("@ID_Form_Of_Control_EU", ID_Form_Of_Control_EU);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }



        // ПРОЦЕДУРЫ ДОБАВЛЕНИЯ ИЗМЕНЕНИЯ УДАЛЕНИЯ ДЛЯ ТАБЛИЦЫ "Учебные единицы РУП"
        public void spEU_CMK_RUP_insert(string Prefix, string Total_Number_Of_Hours, string Theoretical_Hours,
           string Lab_Prac_Hours, string Individual_Work, string Consultations, string Coursework_Project, string Interim_Certification, Int32 Educational_Unit_ID,
           Int32 Type_Of_Educational_Unit_ID, Int32 Form_Of_Control_EU_ID, Int32 CMK_RUP_ID, Int32 EU_CMK_RUP_ID)
        {
            commandconfig("EU_CMK_RUP_insert");
            command.Parameters.AddWithValue("@Prefix", Prefix);
            command.Parameters.AddWithValue("@Total_Number_Of_Hours", Total_Number_Of_Hours);
            command.Parameters.AddWithValue("@Theoretical_Hours", Theoretical_Hours);
            command.Parameters.AddWithValue("@Lab_Prac_Hours", Lab_Prac_Hours);
            command.Parameters.AddWithValue("@Individual_Work", Individual_Work);
            command.Parameters.AddWithValue("@Consultations", Consultations);
            command.Parameters.AddWithValue("@Coursework_Project", Coursework_Project);
            command.Parameters.AddWithValue("@Interim_Certification", Interim_Certification);
            command.Parameters.AddWithValue("@Educational_Unit_ID", Educational_Unit_ID);
            command.Parameters.AddWithValue("@Type_Of_Educational_Unit_ID", Type_Of_Educational_Unit_ID);
            command.Parameters.AddWithValue("@Form_Of_Control_EU_ID", Form_Of_Control_EU_ID);
            command.Parameters.AddWithValue("@CMK_RUP_ID", CMK_RUP_ID);
            command.Parameters.AddWithValue("@EU_CMK_RUP_ID", EU_CMK_RUP_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void spEU_CMK_RUP_updated(Int32 ID_EU_CMK_RUP, string Prefix, string Total_Number_Of_Hours, string Theoretical_Hours,
           string Lab_Prac_Hours, string Individual_Work, string Consultations, string Coursework_Project, string Interim_Certification, Int32 Educational_Unit_ID,
           Int32 Type_Of_Educational_Unit_ID, Int32 Form_Of_Control_EU_ID, Int32 CMK_RUP_ID, Int32 EU_CMK_RUP_ID)
        {
            commandconfig("EU_CMK_RUP_updated");
            command.Parameters.AddWithValue("@ID_EU_CMK_RUP ", ID_EU_CMK_RUP);
            command.Parameters.AddWithValue("@Prefix", Prefix);
            command.Parameters.AddWithValue("@Total_Number_Of_Hours", Total_Number_Of_Hours);
            command.Parameters.AddWithValue("@Theoretical_Hours", Theoretical_Hours);
            command.Parameters.AddWithValue("@Lab_Prac_Hours", Lab_Prac_Hours);
            command.Parameters.AddWithValue("@Individual_Work", Individual_Work);
            command.Parameters.AddWithValue("@Consultations", Consultations);
            command.Parameters.AddWithValue("@Coursework_Project", Coursework_Project);
            command.Parameters.AddWithValue("@Interim_Certification", Interim_Certification);
            command.Parameters.AddWithValue("@Educational_Unit_ID", Educational_Unit_ID);
            command.Parameters.AddWithValue("@Type_Of_Educational_Unit_ID", Type_Of_Educational_Unit_ID);
            command.Parameters.AddWithValue("@Form_Of_Control_EU_ID", Form_Of_Control_EU_ID);
            command.Parameters.AddWithValue("@CMK_RUP_ID", CMK_RUP_ID);
            command.Parameters.AddWithValue("@EU_CMK_RUP_ID", EU_CMK_RUP_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        public void spEU_CMK_RUP_delete(Int32 ID_EU_CMK_RUP)
        {
            commandconfig("EU_CMK_RUP_delete");
            command.Parameters.AddWithValue("@ID_EU_CMK_RUP ", ID_EU_CMK_RUP);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }



    }
}
