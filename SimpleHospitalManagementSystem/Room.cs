using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHospitalManagementSystem
{
    //enum for room type
    public enum RoomType { IPR, OPR }
    public class Room : IRoomManagement, IDisplayInfo
    {
        

        //attributes
        public int RoomNumber {  get; set; }
        public RoomType TypeOfRoom { get; set; }
        public bool isOccupied {  get; set; }// tracks whether the room is occupied

        //constructor to initialize the room attributes
        public Room(int RoomNumber, RoomType TypeOfRoom) 
        {
            this.RoomNumber = RoomNumber;
            this.TypeOfRoom = TypeOfRoom;
            isOccupied=false; 
        }

        //methods
        //OccupyRoom() method to marks the room as occupied
        public void OccupyRoom() 
        {
            if (isOccupied) { Console.WriteLine($"Room {RoomNumber} is already occupied."); }
            else 
            {
                isOccupied = true;
                Console.WriteLine($"Room {RoomNumber} is now occupied.");
            }
        }
        // Method to mark the room as vacant
        public void VacateRoom()    
        {
            if (!isOccupied) { Console.WriteLine($"Room {RoomNumber} is already vacant."); }
            else { isOccupied = false; Console.WriteLine($"Room {RoomNumber} is now vacant."); }
        }
        // Implementing the IsRoomOccupied method
        public bool IsRoomOccupied()
        {
            return isOccupied;
        }
        // Method to display room information
        public void DisplayInfo()       
        {
            Console.WriteLine($"Room Number: {RoomNumber} \t " +
                $"Room Type: {TypeOfRoom} \t " +
                $"Is Occupied: {(isOccupied ? "Yes" : "No")}");
        }



    }
}
