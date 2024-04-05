using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternWkshp
{
    //interface IKitchen
    //{
    //    public void CookFood();
    //}
     class PaymentFacade
    {
        private Starter upi;
        private MainCourse netBanking;
        private Dessert cardPayment;

        public PaymentFacade(Starter upi, MainCourse netBanking, Dessert cardPayment)
        {
            this.upi = upi;
            this.netBanking = netBanking;
            this.cardPayment = cardPayment;
        }

        public void Pay(/*Payment type Selector parameter*/)
        {
            // Payment method selector
        }
    }

    //class Starter : IKitchen
    //{
    //    //Upi Payment methods
    //}

    //class MainCourse : IKitchen
    //{
    //    //NetBanking Payment methods

    //}

    //class Dessert : IKitchen
    //{
    //    //CardPayment Payment methods

    }
}
