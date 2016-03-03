using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownWithTheSickness_Dialog_Tool
{
    public class Scene
    {
        public Scene()
        {
            name = "";
            dialogs = new List<Dialog>();
        }
        public Scene(String name)
        {
            this.name = name;
            dialogs = new List<Dialog>();
        }
        public string name { get; set; }
        public List<Dialog> dialogs { get; set; }
    }

}
