using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.Entity.Infrastructure;
using System.Xml.Linq;

namespace UserAccount
{
    public partial class Form1 : Form
    {
        string path = "data_table.db";
        string cs = @"URI=file:" + Application.StartupPath + "\\data_table.db"; //database

        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataReader dr;

        public Form1()
        {
            InitializeComponent();
        }

        private void data_Show()
        {
            var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM test";
            var cmd = new SQLiteCommand(stm, con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dataGridView1.Rows.Insert(0, dr.GetString(0), dr.GetString(1));

            }
        }

        private void create_DB()
        {
            if (!System.IO.File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
                using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
                {
                    sqlite.Open();
                    string sql = "create table test(name varchar(20), password varchar(12))";
                    SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                //MessageBox.Show("Database can't create", "Warning");
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            create_DB();
            data_Show();
        }

        //button insert data
        private void button1_Click(object sender, EventArgs e)
        {
            con = new SQLiteConnection(cs);
            con.Open();
            cmd = new SQLiteCommand(con);

            try
            {
                cmd.CommandText = "INSERT INTO  test(name,password) VALUES(@name,@password)";

                string NAME = tbName.Text;
                string PASSWORD = tbPassword.Text;

                cmd.Parameters.AddWithValue("@name", NAME);
                cmd.Parameters.AddWithValue("@password", PASSWORD);

                dataGridView1.ColumnCount = 2;
                dataGridView1.Columns[0].Name = "Name";
                dataGridView1.Columns[1].Name = "Password";

                string[] row = new string[] { NAME, PASSWORD };
                dataGridView1.Rows.Add(row);

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Can't insert data", "Warning");
                return;
            }
            con.Close();
        }

        //update button
        private void button2_Click(object sender, EventArgs e)
        {
            var con = new SQLiteConnection(cs);
            con.Open();

            var cmd = new SQLiteCommand(con);

            try
            {
                cmd.CommandText = "UPDATE test Set password=@Password where name=@Name";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@Name", tbName.Text);
                cmd.Parameters.AddWithValue("@Password", tbPassword.Text);

                cmd.ExecuteNonQuery();
                dataGridView1.Rows.Clear();
                data_Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Can't update data", "Warning");
                return;
            }

            con.Close();

        }


        //delete button
        private void button3_Click(object sender, EventArgs e)
        {
            var con = new SQLiteConnection(cs);
            con.Open();

            var cmd = new SQLiteCommand(con);

            try
            {
                cmd.CommandText = "Delete FROM test where name=@Name";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@Name", tbName.Text);

                cmd.ExecuteNonQuery();
                dataGridView1.Rows.Clear();
                data_Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Can't DELETE data", "Warning");
                return;
            }
            con.Close();
        }


    }
}
