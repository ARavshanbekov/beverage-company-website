using Microsoft.AspNetCore.ResponseCompression;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace kelechekBurulsunFiveWebsite.CustomCompressionProvider
{
    public class CustomBrotliCompressionProvider : ICompressionProvider
    {
        public string EncodingName => "br";
        public bool SupportsFlush => true;

        public Stream CreateStream(Stream outputStream)
        {
            return new BrotliStream(
                outputStream,               
                CompressionLevel.Fastest); // very costly if optimal value selected, may not be appropriate for a web server
        }
    }    
}
