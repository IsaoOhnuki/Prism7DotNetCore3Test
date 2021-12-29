using System;
using System.Collections.Generic;
using System.Text;

namespace DBMaigration
{
    public class Table1
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Age { get; set; }

#pragma warning disable CS8632 // '#nullable' 注釈コンテキスト内のコードでのみ、Null 許容参照型の注釈を使用する必要があります。
        public string? Sex { get; set; }
#pragma warning restore CS8632 // '#nullable' 注釈コンテキスト内のコードでのみ、Null 許容参照型の注釈を使用する必要があります。
    }
}
