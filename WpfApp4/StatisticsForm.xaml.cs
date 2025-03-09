using System.Collections.Generic;
using System.Windows;

namespace ServiceCenterApp
{
    public partial class StatisticsForm : Window
    {
        public StatisticsForm(List<Request> requests)
        {
            InitializeComponent();

            // Пример статистики, здесь можно добавить вашу логику для вывода статистики
            List<string> statistics = new List<string>
            {
                "Количество выполненных заявок: " + requests.Count,
                "Среднее время выполнения заявки: " + CalculateAverageTime(requests),
                "Статистика по типам неисправностей: " + GetFaultStatistics(requests)
            };

            lbStatistics.ItemsSource = statistics;
        }

        private string CalculateAverageTime(List<Request> requests)
        {
            // Ваши расчеты для времени выполнения заявок
            return "1.5 дня"; // Пример
        }

        private string GetFaultStatistics(List<Request> requests)
        {
            // Логика для подсчета статистики по типам неисправностей
            return "Холодильники: 10, Стиральные машины: 5"; // Пример
        }
    }
}
