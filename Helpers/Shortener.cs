using System.Text;
using UrlShortener.Helpers.Interfaces;

namespace UrlShortener.Helpers
{
    public class Shortener : IShortener
    {
        private const string Alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public Uri GetShortUrl(Uri url)
        {
            string input = url.AbsoluteUri;

            using var sha = System.Security.Cryptography.SHA256.Create();
            var hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));

            string shortCode = EncodeBase62(hashBytes.Take(6).ToArray());

            var shortUrl = new Uri($"https://short.ly/{shortCode}");
            return shortUrl;
        }

        private string EncodeBase62(byte[] bytes)
        {
            var value = BitConverter.ToUInt64(bytes.Concat(new byte[8 - bytes.Length]).ToArray(), 0);
            var sb = new StringBuilder();

            while (value > 0)
            {
                sb.Insert(0, Alphabet[(int)(value % 62)]);
                value /= 62;
            }

            return sb.ToString();
        }
    }
}