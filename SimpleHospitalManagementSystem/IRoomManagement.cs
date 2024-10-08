using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHospitalManagementSystem
{
    public interface IRoomManagement
    {
        public bool isOccupied { get; set; }// tracks whether the room is occupied
        // Marks a room as occupied
        void OccupyRoom();

        // Marks a room as available
        void VacateRoom();

        // Checks the occupancy status of the room
        bool IsRoomOccupied();

    }
}
