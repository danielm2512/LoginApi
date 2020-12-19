using System;
using System.Collections.Generic;
using System.Text;

namespace TesteLogin.Application.Dto
{
    public class Result<T>
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public string Code { get; set; }
        public int Total { get; set; }
        public int TotalInPage { get; set; }
        public T Data { get; set; }
        public Dictionary<string, string> Subtitles { get; set; }
        public int Id { get; set; }
        public string Uid { get; set; }
    }

    public class Result
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
    }
}
