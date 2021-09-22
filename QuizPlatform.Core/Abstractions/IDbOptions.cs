using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPlatform.Core.Abstractions
{
    public interface IDbOptions
    {
        string ConnectionString { get; set; }
        string Database { get; set; }
    }
}
