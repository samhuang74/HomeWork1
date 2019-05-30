using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeWork1.Exceptions
{
    public class CustomerException : Exception
    {
        private String CMessage = "";

        public CustomerException(string message) : base()
        {
            CMessage = "錯誤訊息加工 : " + message ;
        }

        //
        // 摘要:
        //     Gets a message that describes the current exception.
        //
        // 傳回:
        //     The error message that explains the reason for the exception, or an empty string
        //     ("").
        public override string Message {
            get => CMessage;            
        }

    }
}