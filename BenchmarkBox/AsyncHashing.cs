namespace BenchmarkBox
{
    using System.IO;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using BenchmarkDotNet.Attributes;

    internal static class Async
    {
        public static async Task<byte[]> ComputeHashAsync(this HashAlgorithm hash, Stream inputStream)
        {
            var buffer = new byte[4096];
            while(true)
            {
                var readCount = await inputStream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
                if (readCount == 0)
                    break;
                hash.TransformBlock(buffer, 0, readCount, buffer, 0);
            }
            hash.TransformFinalBlock(buffer, 0, 0);
            return hash.Hash;
        }
    }

    public class AsyncHashing
    {
        private MemoryStream[] streams = Enumerable.Range(0, 4)
            .Select(_ => new MemoryStream(Encoding.ASCII.GetBytes(new string('e', 40000000))))
            .ToArray();
        private SHA512Managed sha512 = new SHA512Managed();

        [Benchmark]
        public async Task<object> AsyncHashMultipleStreams()
        {
            var hashes = new List<byte[]>();
            foreach(var stream in streams)
            {
                hashes.Add(await sha512.ComputeHashAsync(stream));
            }
            return hashes;
        }

        [Benchmark]
        public object SyncHashMultpleStreams()
        {
            var hashes = new List<byte[]>();
            foreach (var stream in streams)
            {
                hashes.Add(sha512.ComputeHash(stream));
            }
            return hashes;
        }
    }
}