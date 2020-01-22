using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Pilot
    {
        public Pilot() { }
        public Pilot(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            PilotId = Guid.NewGuid();
        }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Nickname { get; set; }
        public Guid PilotId { get; set; }

        public int VacationDays { get; set; }

        public Pilot NewPilotSetUp(Pilot pilot)
        {
            //New pilots start with 10 vacation days.
            pilot.VacationDays = 10;

            return pilot;
        }

        public Pilot PilotPromoted(Pilot pilot)
        {
            var rnd = new Random();
            pilot.VacationDays += rnd.Next(1, 5);
            return pilot;
        }

        public Pilot PilotPenalized(Pilot pilot, int penaltyDays)
        {
            pilot.VacationDays -= penaltyDays;
            return pilot;
        }


    }

}
