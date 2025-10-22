using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Lab18.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content(@"
                <html>
                    <head>
                        <title>Мониторинг ASP.NET Core</title>
                    </head>
                    <body>
                        <h1>Пример мониторинга веб-приложения</h1>
                        <p>Перейдите по <a href='/metrics'>/metrics</a> для просмотра метрик Prometheus</p>
                        <p>Перейдите по <a href='/Home/Dashboard'>/Home/Dashboard</a> для просмотра дашборда</p>
                    </body>
                </html>", "text/html; charset=utf-8");
        }

        public IActionResult TriggerError()
        {
            throw new Exception("Тестовая ошибка для мониторинга");
        }

        public IActionResult Dashboard()
        {
            return Content(@"
                <html>
                    <head>
                        <title>Дашборд мониторинга</title>
                    </head>
                    <body>
                        <h1>Дашборд мониторинга</h1>
                        <canvas id='requestsChart'></canvas>
                        <script src='https://cdn.jsdelivr.net/npm/chart.js'></script>
                        <script>
                        async function updateChart(chart) {
                            const response = await fetch('/metrics');
                            const text = await response.text();
                            
                            // Найдём строку с нужной метрикой
                            const match = text.match(/http_requests_received_total\{code=\""200\"",method=\""GET\"",controller=\""Home\"",action=\""Index\"",endpoint=\""\{controller=Home\}\/\{action=Index\}\/\{id\?\}\""\}\s+(\d+)/);
                            const value = match ? parseInt(match[1]) : 0;   

                            // Добавим новое значение
                            const now = new Date().toLocaleTimeString();
                            chart.data.labels.push(now);
                            chart.data.datasets[0].data.push(value);

                            // Оставим последние 20 точек
                            if (chart.data.labels.length > 20) {
                                chart.data.labels.shift();
                                chart.data.datasets[0].data.shift();
                            }

                            chart.update();
                        }

                        // Создаём график
                        const ctx = document.getElementById('requestsChart').getContext('2d');
                        const requestsChart = new Chart(ctx, {
                            type: 'line',
                            data: {
                                labels: [],
                                datasets: [{
                                    label: 'GET 200 requests',
                                    data: [],
                                    borderColor: 'blue',
                                    fill: false
                                }]
                            },
                            options: {
                                responsive: true,
                                scales: {
                                    x: { display: true },
                                    y: { beginAtZero: true }
                                }
                            }
                        });

                        // Обновляем график каждые 5 секунд
                        setInterval(() => updateChart(requestsChart), 5000);
                        </script>
                    </body>
                </html>
            ", "text/html; charset=utf-8");
        }
    }
}
