using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingCore
{
    internal interface ITicketBookingRepository
    {
        void Save(TicketBooking ticket);
    }

    public class TicketBooking : TicketBookingBase
    {
    }
}
