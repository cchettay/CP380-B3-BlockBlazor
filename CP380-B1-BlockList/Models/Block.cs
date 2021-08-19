sing System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CP380_B1_BlockList.Models
{
    public class Block
    {
        private DateTime now;


        public int nonce { get; set; } = 0;
        public DateTime timeStamp { get; set; }
        public string previousHash { get; set; }
        public string hash { get; set; }
        public List<Payload> data { get; set; }

        public Block(DateTime timeStamp, string PreviousHash, List<Payload> data)
        {
            nonce = 0;
            timeStamp = timeStamp;
            previousHash = PreviousHash;
            data = data;
            hash = CalculateHash();
        }


        //
        // JSON serialisation:
        //   https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to?pivots=dotnet-5-0
        //
        public string CalculateHash()
        {
            SHA256 sha256 = SHA256.Create();
            var json = JsonSerializer.Serialize(data);

            var input = Encoding.ASCII.GetBytes($"{timeStamp:yyyy-MM-dd hh:mm:ss tt}-{previousHash}-{nonce}-{data}");
            var output = sha256.ComputeHash(input);

            return Convert.ToBase64String(output);
        }

        public void Mine(int difficulty)
        {
            var cvalues = new string('C', difficulty);
            while (this.hash == null || this.hash.Substring(0, difficulty) != cvalues)
            {
                this.nonce++;
                this.hash = this.CalculateHash();
            }
        }

        public static explicit operator Task(Block v)
        {
            throw new NotImplementedException();
        }
    }
}