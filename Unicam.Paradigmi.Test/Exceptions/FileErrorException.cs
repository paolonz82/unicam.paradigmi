using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Test.Exceptions
{
    public class FileErrorException : Exception
    {
        public FileErrorException(string message, string path) : this(message,path,null)
        {
            
        }
        public FileErrorException(string message, string path, Exception innerException) : base(message,innerException)
        {
            Path = path;
        }
        public string Path { get; set; }
    }
}
