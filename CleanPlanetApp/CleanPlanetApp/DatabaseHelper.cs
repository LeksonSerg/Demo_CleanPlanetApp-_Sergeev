using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using CleanPlanetApp.Models;
using System.Configuration;

namespace CleanPlanetApp
{
    public class DatabaseHelper
    {
        private string connectionString;

        public DatabaseHelper()
        {
            connectionString = @"Data Source=DESKTOP-E2JTTDJ\SQLEXPRESS;Initial Catalog=CleanPlanet;Integrated Security=True";
        }

        public List<Partner> GetPartners()
        {
            var partners = new List<Partner>();

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT * FROM Partners", connection);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            partners.Add(new Partner
                            {
                                PartnerId = (int)reader["PartnerId"],
                                PartnerType = reader["PartnerType"].ToString(),
                                Name = reader["Name"].ToString(),
                                Director = reader["Director"].ToString(),
                                Email = reader["Email"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                LegalAddress = reader["LegalAddress"].ToString(),
                                INN = reader["INN"].ToString(),
                                Rating = (int)reader["Rating"]
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке партнеров: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return partners;
        }

        public List<PartnerService> GetPartnerServices(int partnerId)
        {
            var services = new List<PartnerService>();

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand(@"
                        SELECT ps.PartnerServiceId, ps.PartnerId, ps.ServiceId, ps.Quantity, ps.ExecutionDate, 
                               s.ServiceName, p.Name as PartnerName 
                        FROM PartnerServices ps
                        INNER JOIN Services s ON ps.ServiceId = s.ServiceId
                        INNER JOIN Partners p ON ps.PartnerId = p.PartnerId
                        WHERE ps.PartnerId = @PartnerId", connection);
                    command.Parameters.AddWithValue("@PartnerId", partnerId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            services.Add(new PartnerService
                            {
                                PartnerServiceId = (int)reader["PartnerServiceId"],
                                PartnerId = (int)reader["PartnerId"],
                                ServiceId = (int)reader["ServiceId"],
                                ServiceName = reader["ServiceName"].ToString(),
                                Quantity = (int)reader["Quantity"],
                                ExecutionDate = reader["ExecutionDate"] is DBNull ?
                                    DateTime.MinValue : (DateTime)reader["ExecutionDate"],
                                PartnerName = reader["PartnerName"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке истории услуг: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return services;
        }

        public bool SavePartner(Partner partner)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command;

                    if (partner.PartnerId == 0)
                    {
                        command = new SqlCommand(@"
                            INSERT INTO Partners (PartnerType, Name, Director, Email, Phone, LegalAddress, INN, Rating)
                            VALUES (@PartnerType, @Name, @Director, @Email, @Phone, @LegalAddress, @INN, @Rating)", connection);
                    }
                    else
                    {
                        command = new SqlCommand(@"
                            UPDATE Partners SET 
                            PartnerType = @PartnerType, 
                            Name = @Name, 
                            Director = @Director, 
                            Email = @Email, 
                            Phone = @Phone, 
                            LegalAddress = @LegalAddress, 
                            INN = @INN, 
                            Rating = @Rating
                            WHERE PartnerId = @PartnerId", connection);
                        command.Parameters.AddWithValue("@PartnerId", partner.PartnerId);
                    }

                    command.Parameters.AddWithValue("@PartnerType", partner.PartnerType);
                    command.Parameters.AddWithValue("@Name", partner.Name);
                    command.Parameters.AddWithValue("@Director", partner.Director);
                    command.Parameters.AddWithValue("@Email", partner.Email);
                    command.Parameters.AddWithValue("@Phone", partner.Phone);
                    command.Parameters.AddWithValue("@LegalAddress", partner.LegalAddress);
                    command.Parameters.AddWithValue("@INN", partner.INN);
                    command.Parameters.AddWithValue("@Rating", partner.Rating);

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении партнера: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public List<string> GetPartnerTypes()
        {
            return new List<string> { "ИП", "ООО", "ЗАО", "ОАО" };
        }

        public decimal CalculateServiceCost(int serviceId)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var materialCost = GetMaterialCostForService(serviceId);
                    var laborCost = GetLaborCostForService(serviceId);

                    return materialCost + laborCost;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расчете себестоимости: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private decimal GetMaterialCostForService(int serviceId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(@"
                    SELECT SUM(sm.ConsumptionRate * mp.Price) as TotalMaterialCost
                    FROM ServiceMaterials sm
                    INNER JOIN MaterialPrices mp ON sm.MaterialId = mp.MaterialId
                    INNER JOIN (
                        SELECT MaterialId, MAX(EffectiveDate) as MaxDate
                        FROM MaterialPrices
                        GROUP BY MaterialId
                    ) latest ON mp.MaterialId = latest.MaterialId AND mp.EffectiveDate = latest.MaxDate
                    WHERE sm.ServiceId = @ServiceId", connection);
                command.Parameters.AddWithValue("@ServiceId", serviceId);

                var result = command.ExecuteScalar();
                return result == DBNull.Value ? 0 : Convert.ToDecimal(result);
            }
        }

        private decimal GetLaborCostForService(int serviceId)
        {
            return 1000;
        }

        public List<Service> GetServicesWithCost()
        {
            var services = new List<Service>();

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand(@"
                        SELECT s.*, st.ServiceTypeName, st.ComplexityCoefficient
                        FROM Services s
                        INNER JOIN ServiceTypes st ON s.ServiceTypeId = st.ServiceTypeId",
                        connection);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var service = new Service
                            {
                                ServiceId = (int)reader["ServiceId"],
                                ServiceTypeId = (int)reader["ServiceTypeId"],
                                ServiceName = reader["ServiceName"].ToString(),
                                ServiceCode = reader["ServiceCode"].ToString(),
                                MinimalCost = (decimal)reader["MinimalCost"],
                                ServiceTypeName = reader["ServiceTypeName"].ToString(),
                                ComplexityCoefficient = (double)reader["ComplexityCoefficient"]
                            };

                            service.CalculatedCost = CalculateServiceCost(service.ServiceId);
                            services.Add(service);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке услуг: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return services;
        }

        public int CalculateMaterialQuantity(int serviceTypeId, int materialTypeId, int serviceCount, double serviceParameters)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // 1. Получаем коэффициент сложности услуги
                    var complexityCommand = new SqlCommand(
                        "SELECT ComplexityCoefficient FROM ServiceTypes WHERE ServiceTypeId = @ServiceTypeId",
                        connection);
                    complexityCommand.Parameters.AddWithValue("@ServiceTypeId", serviceTypeId);
                    var complexityResult = complexityCommand.ExecuteScalar();

                    if (complexityResult == null || complexityResult == DBNull.Value)
                    {
                        MessageBox.Show("Тип услуги не найден", "Ошибка");
                        return -1;
                    }
                    double complexityCoefficient = Convert.ToDouble(complexityResult);

                    // 2. Получаем процент перерасхода материала
                    var overheadCommand = new SqlCommand(
                        "SELECT OverheadPercent FROM Materials WHERE MaterialId = @MaterialId",
                        connection);
                    overheadCommand.Parameters.AddWithValue("@MaterialId", materialTypeId);
                    var overheadResult = overheadCommand.ExecuteScalar();

                    if (overheadResult == null || overheadResult == DBNull.Value)
                    {
                        MessageBox.Show("Тип материала не найден", "Ошибка");
                        return -1;
                    }
                    double overheadPercent = Convert.ToDouble(overheadResult);

                    // 3. Проверяем входные параметры
                    if (serviceCount <= 0)
                    {
                        MessageBox.Show("Количество услуг должно быть положительным числом", "Ошибка");
                        return -1;
                    }

                    if (serviceParameters <= 0)
                    {
                        MessageBox.Show("Параметры услуги должны быть положительными", "Ошибка");
                        return -1;
                    }

                    // 4. Расчет базового количества материала на одну услугу
                    // Формула: параметры_услуги × коэффициент_сложности
                    double materialPerService = serviceParameters * complexityCoefficient;

                    // 5. Расчет общего количества для всех услуг
                    double totalMaterial = materialPerService * serviceCount;

                    // 6. Учет перерасхода материала
                    // Формула: общее_количество × (1 + процент_перерасхода)
                    double totalWithOverhead = totalMaterial * (1 + overheadPercent);

                    // 7. Округляем до целого в большую сторону
                    int finalQuantity = (int)Math.Ceiling(totalWithOverhead);

                    MessageBox.Show($"Расчет завершен:\n" +
                                  $"Материал на одну услугу: {materialPerService:F2}\n" +
                                  $"Общее количество: {totalMaterial:F2}\n" +
                                  $"С перерасходом: {totalWithOverhead:F2}\n" +
                                  $"Итоговое количество: {finalQuantity}",
                                  "Результат расчета");

                    return finalQuantity;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расчете количества материала: {ex.Message}", "Ошибка");
                return -1;
            }
        }
        public string GetConnectionString()
        {
            return connectionString;
        }
    }
}