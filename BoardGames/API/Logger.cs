using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BoardGames.API
{
    public class Logger
    {
        public Logger()
        {

        }

        public static void Log(Exception exception)
        {
            using (var fileStream = new FileStream ( @"Exceptions.log", FileMode.Append ))
            using (var streamWriter = new StreamWriter(fileStream))
            {
                streamWriter.WriteLine(DateTime.Now);
                streamWriter.WriteLine("Message: " + exception.Message);
                streamWriter.WriteLine("Source: " + exception.Source);
                streamWriter.WriteLine("StackTrace: " + exception.StackTrace);
                streamWriter.WriteLine();
                streamWriter.Flush();
            }
        }
    }
}
