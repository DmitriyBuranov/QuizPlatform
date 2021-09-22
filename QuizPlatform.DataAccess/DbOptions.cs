using QuizPlatform.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPlatform.DataAccess
{
    public class DbOptions : IDbOptions
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}
