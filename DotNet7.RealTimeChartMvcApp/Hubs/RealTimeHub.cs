using DotNet7.RealTimeChartMvcApp.Models;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DotNet7.RealTimeChartMvcApp.Hubs
{
    public class RealTimeHub : Hub
    {

        public async Task SeverReceiveMessage()
        {
            Random random = new Random();
            PieChartResponseModel modle = new PieChartResponseModel()
            {
                Data = new PieChartModel
                {
                    Labels = new List<string>{"A","B","C","D","E"},
                    Series = new List<int> { random.Next(1,50), random.Next(1, 50), random.Next(1, 50), random.Next(1, 50), random.Next(1, 50) }
                }
            };
            var count = 0;
            await Clients.All.SendAsync("ClientReceiveMessage",JsonConvert.SerializeObject(modle));
        }

    }
}
