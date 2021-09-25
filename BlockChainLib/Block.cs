using System;
using System.Security.Cryptography;
using System.Text;

namespace BlockChainLib
{
    public class Block
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Данные
        /// </summary>
        public string Data { get; private set; }
        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Created { get; private set; }
        /// <summary>
        /// Хеш блока
        /// </summary>
        public string Hash { get; private set; }
        /// <summary>
        /// Хеш предыдущего блока
        /// </summary>
        public string PreviousHash { get; private set; }

        /// <summary>
        /// Конструктор генезис блока
        /// </summary>
        public Block()
        {
            Id = 1;
            Data = "hello world";
            Created = DateTime.UtcNow;
            PreviousHash = null;

            Hash = CalculateHash();
            /*var data = GetData();
            Hash = GetHash(data);*/
        }

        /// <summary>
        /// Конструктор блока
        /// </summary>
        /// <param name="data"></param>
        /// <param name="block"></param>
        /// <param name="user"></param>
        public Block(string data, Block block)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentNullException("Пустой аргумент data", nameof(data));
            }

            if(block == null)
            {
                throw new ArgumentNullException("Пустой аргумент block", nameof(block));
            }

            Id = block.Id + 1;
            Data = data;
            PreviousHash = block.Hash;
            Created = DateTime.UtcNow;
            Hash = CalculateHash();
            /*var blockData = GetData();
            Hash = GetHash(blockData);*/
        }
        /// <summary>
        /// Получение значимых данных
        /// </summary>
        /// <returns></returns>
        private string GetData()
        {
            string result = string.Empty;

            result += Id.ToString();
            result += Data;
            result += Created.ToString("dd.MM.yyyy HH:mm:ss:fff");
            return result;
        }
        /// <summary>
        /// Хеширование данных
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string GetHash(string data)
        {
            var message = Encoding.ASCII.GetBytes(data);
            var hashString = new SHA256Managed();
            string hex = string.Empty;

            var hashValue = hashString.ComputeHash(message);
            foreach(byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }

        private string CalculateHash()
        {
            SHA256 sha256 = SHA256.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes($"{Id}-{Data}-{Created.ToString("dd.MM.yyyy HH:mm:ss:fff")}");
            byte[] outputBytes = sha256.ComputeHash(inputBytes);

            return Convert.ToBase64String(outputBytes);
        }
        public override string ToString()
        {
            return Hash;
        }
    }
}
