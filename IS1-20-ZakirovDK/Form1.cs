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
    public partial class Auth1 : MetroForm
    {
        public Auth1()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }
        public void ManagerRole(int role)
        {
            switch (role)
            {
                //И в зависимости от того, какая роль (цифра) хранится в поле класса и передана в метод, показываются те или иные кнопки.
                //Вы можете скрыть их и не отображать вообще, здесь они просто выключены
                case 1:
                    metroLabel1.Text = "Максимальный";
                    metroLabel1.ForeColor = Color.Green;
                    metroButton1.Enabled = true;
                    metroButton2.Enabled = true;
                    metroButton3.Enabled = true;
                    break;
                case 2:
                    metroLabel1.Text = "Умеренный";
                    metroLabel1.ForeColor = Color.YellowGreen;
                    metroButton1.Enabled = false;
                    metroButton2.Enabled = true;
                    metroButton3.Enabled = true;
                    break;
                case 3:
                    metroLabel1.Text = "Минимальный";
                    metroLabel1.ForeColor = Color.Yellow;
                    metroButton1.Enabled = false;
                    metroButton2.Enabled = false;
                    metroButton3.Enabled = true;
                    break;
                //Если по какой то причине в классе ничего не содержится, то всё отключается вообще
                default:
                    metroLabel1.Text = "Неопределённый";
                    metroLabel1.ForeColor = Color.Red;
                    metroButton1.Enabled = false;
                    metroButton2.Enabled = false;
                    metroButton3.Enabled = false;
                    break;
            }
        }
        private void Form1_auth1_Load(object sender, EventArgs e)
        {
            //Сокрытие текущей формы
            this.Hide();
            //Инициализируем и вызываем форму диалога авторизации
            Auth2 auth2 = new Auth2();
            //Вызов формы в режиме диалога
            auth2.ShowDialog();
            //Если авторизации была успешна и в поле класса хранится истина, то делаем движуху:
            if (Auth.auth)
            {
                //Отображаем рабочую форму
                this.Show();
                //Вытаскиваем из класса поля в label'ы
                metroLabel2.Text = Auth.auth_id;
                metroLabel3.Text = Auth.auth_fio;
                metroLabel4.Text = "Успешна!";
                //Красим текст в Label в зелёный цвет
                metroLabel4.ForeColor = Color.Green;
                //Вызываем метод управления ролями
                ManagerRole(Auth.auth_role);
            }
            //иначе
            else
            {
                this.Show();
                metroLabel2.Text = "неизвестный пользователь";
                metroLabel3.Text = "Отсутствует информация о пользователе";
                metroLabel4.Text = "Тебе сдесь не рады!";
                metroLabel4.ForeColor = Color.Red;
                ManagerRole(Auth.auth_role);
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
