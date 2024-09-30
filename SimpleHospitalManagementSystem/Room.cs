using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHospitalManagementSystem
{
    public class Room
    {
        //enum for room type
        public enum RoomType { General, ICU, OperationTheater}

        //attributes
        public int RoomNumber {  get; set; }
        public RoomType TypeOfRoom { get; set; }
        public bool IsOccupied {  get; private set; }// tracks whether the room is occupied

        //constructor to initialize the room attributes
        public Room(int RoomNumber, RoomType TypeOfRoom) 
        {
            this.RoomNumber = RoomNumber;
            this.TypeOfRoom = TypeOfRoom;
            IsOccupied=false; 
        }
        //OccupyRoom() method to marks the room as occupied
        public void OccupyRoom() 
        {
            if (IsOccupied) { Console.WriteLine($"Room {RoomNumber} is already occupied."); }
            else 
            {
                IsOccupied = true;
                Console.WriteLine($"Room {RoomNumber} is now occupied.");
            }
        }
        public void VacateRoom()
        {
            if (!IsOccupied) { Console.WriteLine($"Room {RoomNumber} is already vacant."); }
            else { IsOccupied = false; Console.WriteLine($"Room {RoomNumber} is now vacanted."); }
        }



    }
}
