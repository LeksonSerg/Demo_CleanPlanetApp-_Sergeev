using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CleanPlanetApp
{
    public static class TestConnection
    {
        public static void Test()
        {
            string connectionString = @"Data Source=DESKTOP-E2JTTDJ\SQLEXPRESS;Initial Catalog=CleanPlanet;Integrated Security=True";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Подключение к БД успешно!", "Тест БД");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}", "Ошибка БД");
            }
        }
    }
}