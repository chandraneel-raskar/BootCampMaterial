using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternWkshp
{
    interface IKitchen
    {
        public void CookFood();
    }
    class OrderFacade
    {
        private Starter starter;
        private MainCourse maincourse;
        private Dessert dessert;

        public OrderFacade(Starter upi, MainCourse netBanking, Dessert cardPayment)
        {
            this.starter = upi;
            this.maincourse = netBanking;
            this.dessert = cardPayment;
        }

        public void Pay(/*Payment type Selector parameter*/)
        {
            // Payment method selector
        }
    }

    class Starter : IKitchen
    {
        //Upi Payment methods
        public void CookFood() { }

    }

    class MainCourse : IKitchen
    {
        //NetBanking Payment methods
        public void CookFood() { }

    }

    class Dessert : IKitchen
    {
        //CardPayment Payment methods
        public void CookFood() { }

    }
}
