using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeWork1.Models.VModels
{
    public class Question
    {
        [Display(Name = "ID")]
        public String QId { get; set; }

        [Display(Name = "類型")]
        public String Kind { get; set; }

        [Display(Name = "題目")]
        public String Topic { get; set; }

        [Display(Name = "選擇")]
        public List<Option> Options { get; set; }
    }

    public class Option
    {
        public String Title { get; set; }
        public String Value { get; set; }
        public Boolean IsChecked { get; set; }
    }
}