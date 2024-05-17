using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWpf.CloseableTest.Services
{
    /// <summary>
    /// Provides abstraction for closing functionality to keep viewmodel from directly referencing view
    /// </summary>
    internal interface ICloseable
    {
        void Close();
    }
}
