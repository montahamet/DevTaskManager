using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.API
{
    /// <summary>
    /// Response for Web call
    /// </summary>
    public class ApiResponse
    {

        public ApiResponse()
        {

        }

        /// <summary>
        /// Success
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Error
        /// </summary>
        public int Error { get; set; } = -1;

        /// <summary>
        /// Message : Success / Error
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Data
        /// </summary>
        public object Data { get; set; }
    }
}
