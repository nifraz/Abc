using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.CarTraders.Core.Domain
{
    public class Log
    {
        //nav props
        public User User { get; set; } //opt

        //domain props
        public long Id { get; set; } //pk
        public DateTime Time { get; set; } //req
        public string Title { get; set; } //req
        public LogAction Action { get; set; } //req
        public string Text { get; set; } //req

        //fk props
        public string Username { get; set; } //fk user

        public Log() : base()
        {
            
        }
    }

    public enum LogAction : byte
    {
        Auth = 0,
        Select = 1,
        Insert = 2,
        Update = 3,
        Delete = 4,
        Save = 5
    }
}
