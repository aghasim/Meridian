using MeridianTest.Intefaces;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;



namespace MeridianTest.Service
{
    public class Client : IClient
    {
        private readonly Encoding encoder;
        private TcpClient client;

        public Client()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            this.encoder = Encoding.GetEncoding("KOI8-R");
        }



        public async Task<String> Send(String command)
        {
            try
            {
                using (this.client = new TcpClient("job.latypoff.com", this.GetPortNumber(1337012345)))
                {
                    var stream = this.client.GetStream();
                    var bytes = this.encoder.GetBytes(command);
                    await stream.WriteAsync(bytes, 0, bytes.Length);

                    await Task.Delay(TimeSpan.FromSeconds(1));

                    var count = 0;
                    var buffer = new Byte[1024];
                    Int32 readByte;
                    while ((readByte = stream.ReadByte()) != 0xA && readByte != -1)
                    {
                        buffer[count] = Convert.ToByte(readByte);
                        count++;
                    }

                    var result = encoder.GetString(buffer, 0, count);
                    return result;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



        private Int32 GetPortNumber(Double second)
        {
            var date = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            date = date.AddSeconds(second);
            return date.Year;
        }
    }
}

