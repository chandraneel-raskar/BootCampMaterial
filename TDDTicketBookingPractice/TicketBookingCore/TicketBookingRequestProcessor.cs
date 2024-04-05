using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingCore

{
    public class TicketBookingRequestProcessor : TicketBookingBase
    {

        public TicketBookingRequestProcessor(ITicketBookingRepository ticketBookingRepository)
        {

        }
        public TicketBookingResponse Book(TicketBookingRequest request) 
        {
            if(request == null) throw new ArgumentNullException(nameof(request));


            return new TicketBookingResponse
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };
            
        }
    }

}
