using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MetroFramework.Forms;

namespace IS1_20_ZakirovDK
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn;

            // строка подключения к БД
            string connStr = "server=chuc.caseum.ru/phpmyadmin;port=44444;user=st_1_20_14;" +
                "database=is_1_20_st14_KURS;password=45850148;";
            // создаём объект для подключения к БД

            conn = new MySqlConnection(connStr);

            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = $"SELECT fio FROM employees WHERE id_employee=2";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // выполняем запрос и получаем ответ
            string name = command.ExecuteScalar().ToString();
            // выводим ответ в TextBox
            metroLabel1.Text = name;
            // закрываем соединение с БД
            conn.Close();
        }
        private void Form1_auth1_Load(object sender, EventArgs e)
        {
            //Сокрытие текущей формы
            this.Hide();
            //Инициализируем и вызываем форму диалога авторизации
            Form2 form17_Auth2 = new Form2();
            //Вызов формы в режиме диалога
            form17_Auth2.ShowDialog();
            //Если авторизации была успешна и в поле класса хранится истина, то делаем движуху:
            if (Auth.auth)
            {
                //Отображаем рабочую форму
                this.Show();
            }
            //иначе
            else
            {
                //Закрываем форму
                this.Close();
            }
        }
    }
}
