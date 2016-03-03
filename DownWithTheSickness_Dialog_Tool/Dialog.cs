using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownWithTheSickness_Dialog_Tool
{
    public class Dialog
    {
        public Dialog()
        {
            speaker = new Character();
            addressed_to = new List<Character>();
            constraints = new List<String>();
        }
        public Character speaker { get; set; }
        public String dialog_text { get; set; }
        public List<Character> addressed_to { get; set; }
        public List<String> constraints { get; set; }
        public int dialog_number { get; set; }
    }
}
