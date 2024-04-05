using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDExamples
{
    //interface IVolleyballActions
    //{
    //    void Attack();
    //    void Set();
    //    void Recieve();     ***Volleyball Actions Interface***
    //    void Serve();
    //}
    interface IAttack
    {
        void Attack();
    }    
    interface ISet
    {
        void Set();
    }    
    interface IRecieve         /***Segregated Interfaces for each player***/
    {
        void Recieve();
    }    
    interface IServe
    {
        void Serve();
    }
}
