using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab6.App_Views
{
    public partial class Default : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["Lab6Connection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                FillList();
                BtnsActive(false, true, false, false, false, false);
            }
        }

        protected void BtnsActive(bool panel2, bool add, bool insert, bool edit, bool update, bool delete)
        {
            Panel2.Enabled = panel2;
            BtnAdd.Enabled = add;
            BtnInsert.Enabled = insert;
            BtnEdit.Enabled = edit;
            BtnUpdate.Enabled = update;
            BtnDelete.Enabled = delete;
        }

        protected void FillList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = "SELECT * FROM [dbo].[Students] ORDER BY Id;";
            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                DropDownList1.Items.Clear();
                while (reader.Read())
                {
                    ListItem item = new ListItem();
                    item.Text = reader["Id"].ToString() + ": " + reader["Name"];
                    item.Value = reader["Id"].ToString();
                    DropDownList1.Items.Add(item);
                }
            }
            catch (Exception er)
            {
                Response.Write("<script type='text/javascript'>alert('Connection could not open.');</script>");
            }
            finally
            {
                connection.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = "SELECT * FROM [dbo].[Students] WHERE Id = @id;";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", int.Parse(DropDownList1.SelectedItem.Value));

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    txtId.Text = reader["Id"].ToString();
                    txtName.Text = reader["Name"].ToString();
                    chkScholar.Checked = (bool)reader["Scholar"];
                }
                else
                {
                    txtId.Text = "";
                    txtName.Text = "";
                    chkScholar.Checked = false;
                }
            }
            catch (Exception er)
            {
                Response.Write("<script type='text/javascript'>alert('Connection could not open.');</script>");
            }
            finally
            {
                connection.Close();
                BtnsActive(false, true, false, true, false, true);
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            BtnsActive(true, false, true, false, false, false);
            txtId.Text = "";
            txtName.Text = "";
            chkScholar.Checked = false;
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = "INSERT INTO [dbo].[Students] (Id, Name, Scholar) VALUES (@id, @name, @scholar);";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", int.Parse(txtId.Text));
            command.Parameters.AddWithValue("@name", txtName.Text);
            command.Parameters.AddWithValue("@scholar", chkScholar.Checked);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                Response.Write("<script type='text/javascript'>alert('Student added!');</script>");
            }
            catch (Exception er)
            {
                Response.Write("<script type='text/javascript'>alert('Connection could not open.');</script>");
            }
            finally
            {
                connection.Close();
                BtnsActive(false, true, false, false, false, false);
                FillList();
            }
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            BtnsActive(true, false, false, false, true, false);
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = "UPDATE [dbo].[Students] SET Id=@id, Name=@name, Scholar=@scholar WHERE Id=@oldId;";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", int.Parse(txtId.Text));
            command.Parameters.AddWithValue("@name", txtName.Text);
            command.Parameters.AddWithValue("@scholar", chkScholar.Checked);
            command.Parameters.AddWithValue("@oldId", DropDownList1.SelectedValue);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                Response.Write("<script type='text/javascript'>alert('Student updated!');</script>");
            }
            catch (Exception er)
            {
                Response.Write("<script type='text/javascript'>alert('Connection could not open.');</script>");
            }
            finally
            {
                connection.Close();
                BtnsActive(false, true, false, false, false, false);
                FillList();
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = "DELETE FROM [dbo].[Students] WHERE Id=@id;";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", int.Parse(txtId.Text));

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                Response.Write("<script type='text/javascript'>alert('Student deleted!');</script>");
            }
            catch (Exception er)
            {
                Response.Write("<script type='text/javascript'>alert('Connection could not open.');</script>");
            }
            finally
            {
                connection.Close();
                BtnsActive(false, true, false, false, false, false);
                FillList();
            }
        }
    }
}