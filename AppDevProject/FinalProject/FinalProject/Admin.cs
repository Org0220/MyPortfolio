using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Admin : User
    {
        private static int newId = 1;
        public Admin(String name) : base(name)
        {
            generateId();
        }
        public Admin(String password, String name ) : base(password, name)
        {
            generateId();
        }
        public override void generateId()
        {

            this.Id = String.Format("A{0:000}", newId);
            newId++;
        }

        public override bool Equals(Object obj)
        {
            return this.Id == ((Admin)obj).Id;
        }
        public override int GetHashCode() { return 0; }

    }
}
