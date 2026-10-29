using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week1
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            bool adminExists = false;
            foreach (User u in UserStorage.users)
            {
                if (u.username == "admin")
                {
                    adminExists = true;
                    break;
                }
            }
            if (!adminExists)
            {
                UserStorage.AddUser("admin", "Administrator", "123", "ADMIN");
                UserStorage.AddUser("user1", "User One", "pass1", "userr");

            }
        }

        private void buttonGoToRegister_Click(object sender, EventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            formRegister.Show();
            this.Hide();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            //cek lek textbox e username mbe pass kosongg
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username dan Password harus diisi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ngecek ada ga usn mbe pass e nde userStorage
            if (username == "admin" && password == "123")
            {
                // Find and set admin as current user
                foreach (User u in UserStorage.users)
                {
                    if (u.username == "admin")
                    {
                        UserStorage.currentUser = u;
                        break;
                    }
                }
                
                MessageBox.Show("Login berhasil!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (UserStorage.users.Count == 0)
                {
                    MessageBox.Show("No accounts found.");
                }
                else
                {
                    string allUsers = "";
                    foreach (User u in UserStorage.users)
                    {
                        allUsers += $"Username: {u.username}, Name: {u.nama}, Referral: {u.referralCode}, Money: {u.money}\n";
                    }

                    MessageBox.Show(allUsers, "Registered Users");
                }
                FormVendingMachine formVendingMachine = new FormVendingMachine();
                formVendingMachine.Show();
                this.Hide();
            }
            else
            {
                bool foundUser = false;
                foreach (User u in UserStorage.users)
                {
                    if (u.username == username && u.password == password)
                    {
                        UserStorage.currentUser = u;
                        foundUser = true;
                        MessageBox.Show("Login berhasil!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        if (UserStorage.users.Count == 0)
                        {
                            MessageBox.Show("No accounts found.");
                        }
                        else
                        {
                            string allUsers = "";
                            foreach (User u2 in UserStorage.users)
                            {
                                allUsers += $"Username: {u2.username}, Name: {u2.nama}, Referral: {u2.referralCode}, Money: {u2.money}\n";
                            }

                            MessageBox.Show(allUsers, "Registered Users");
                        }
                        
                        FormVendingMachine formVendingMachine = new FormVendingMachine();
                        formVendingMachine.Show();
                        this.Hide();
                        break;
                    }
                }
                
                if (!foundUser)
                {
                    MessageBox.Show("Username atau Password salah!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
