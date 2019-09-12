using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DbCodeFisrtDemo.Models
{
    [Table("User")]
    public class UserModel
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "最大长度为50")]
        public string UserName { get; set; }
        [MaxLength(50, ErrorMessage = "最大长度为50")]
        public string Password { get; set; }
        [DefaultValue(18)]
        public int Age { get; set; }
        //sqlserver中nvarchar(50)，对应EF中：
        //[MaxLength(50, ErrorMessage = "最大长度为{1}")]

        //sqlserver中char(10)，对应EF中：
        //[MaxLength(10)]
        //[Column(TypeName = "CHAR")]

        //sqlserver中text，对应EF中：
        //[Column(TypeName = "text")]

        //sqlserver中Date（sqlserver2008版本以上才有），对应EF中：
        //[Column(TypeName = "Date")]
    }
}
