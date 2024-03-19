using Data.Models.Data;
using Data.Models.Services.Repositories.Manager;
using Microsoft.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace Cafeteria.App
{
    /// <summary>
    /// Interaction logic for AuthForm.xaml
    /// </summary>
    public partial class AuthForm : Window
    {
        private string _connectionString = "Server=VLADLENPC\\SQLEXPRESS;Database=testdatabase;Integrated Security=True;TrustServerCertificate=True;";
        public AuthForm()
        {
            InitializeComponent();
            
            DatabaseContext dbContext = new DatabaseContext(_connectionString);

            UserRepository userRepository = new UserRepository(dbContext);
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                if (e.GetPosition(this).Y <= 100) 
                {
                    DragMove();
                    if (Top < 0) 
                    {
                        Top = 0;
                    }
                }
            }
        }
        // Добавляем обработчик нажатия на кнопку "Свернуть"
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        // Добавляем обработчик нажатия на кнопку "Развернуть/Свернуть"
        private void MaximizeRestoreButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }
        }

        // Добавляем обработчик нажатия на кнопку "Закрыть"
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;

            // Проверка введенных данных в базе данных
            if (ValidateUser(username, password))
            {
                // Получение роли пользователя из базы данных
                string role = GetUserRole(username);

                if (role == "user")
                {
                    MessageBox.Show("Авторизация успешна! Добро пожаловать, пользователь!");
                    Hide();
                    UserInterface userInterface = new UserInterface();
                    userInterface.Show();
                    // Добавьте здесь код для перехода к основному окну приложения для пользователя
                }
                else if (role == "admin")
                {
                    MessageBox.Show("Авторизация успешна! Добро пожаловать, администратор!");
                    Hide();
                    AdminInterface adminInterface = new AdminInterface();
                    adminInterface.Show();
                    // Добавьте здесь код для перехода к основному окну приложения для администратора
                }
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль. Попробуйте снова.");
            }
        }

        private bool ValidateUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());

                return count > 0;
            }

        }
        private string GetUserRole(string username)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Role FROM Users WHERE Username = @Username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                connection.Open();
                string role = Convert.ToString(command.ExecuteScalar());

                return role;
            }
        }

    }
}