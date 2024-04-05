using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDExamples
{
    internal class Blocker : Attacker, IAttack
    {
        public void Attack()
        {
            //some functionality
        }
        public void Block() 
        { 
            //functionality where in a blocker is a special position that should
            //have ability to block and attack the ball as well
        }
    }
}
//This particular code inherits the attributes of the Attacker class form the Main code and showcases inheritance