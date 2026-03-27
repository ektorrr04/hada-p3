using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENCategory
    {

        private int id;
        private string name;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public ENCategory()
        {
            id = 0;
            name = "";
        }

        public ENCategory(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public bool Read()
        {
            CADCategory cad = new CADCategory();
            return cad.read(this);
        }

        public List<ENCategory> ReadAll()
        {
            CADCategory cad = new CADCategory();
            return cad.readAll();
        }
    }
}
