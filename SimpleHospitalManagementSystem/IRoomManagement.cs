using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHospitalManagementSystem
{
    public interface IRoomManagement
    {
        // Marks a room as occupied
    void OccupyRoom();

        // Marks a room as available
        void VacateRoom();

        // Checks the occupancy status of the room
        bool IsOccupied();

        // Optional: Display room information (could be useful for UI purposes)
        void DisplayRoomInfo();
    }
}
