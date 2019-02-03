using MeridianTest.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace MeridianTest.Service
{
    public class Meridian: IMeridian
    {
        private readonly IClient client;

        public Meridian(IClient client)
        {
            this.client = client;
        }
        public async Task<Double> Get()
        {
            var request = new List<Task<String>>();
            for (int i = 1; i <= 2018; i++)
            {
                var command = i.ToString() + "\n";
                request.Add(client.Send(command));
            }
            var result = await Task.WhenAll(request.ToArray());

            var list = result.Select(x => Double.Parse(Regex.Replace(x, "[^0-9]", ""))).ToList();

            var sortedList = list.OrderBy(x => x).ToList();

            if (sortedList.Count % 2 == 0)
            {
                return  (sortedList[sortedList.Count / 2 - 1] + sortedList[sortedList.Count / 2]) / 2;
            }
            else
            {
                return  sortedList[sortedList.Count / 2];
            }
        }
    }
}
