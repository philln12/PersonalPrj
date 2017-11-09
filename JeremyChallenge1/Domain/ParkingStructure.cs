using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeremyChallenge1.Domain
{
    public class ParkingStructure
    {
        public List<Level> ParkingLevels;
    }

    public class Level
    {
        public List<ParkingSpot> ParkingSpots;
    }

    public enum ParkingType
    {
        General,
        Valet,
        FrequentFlyer
    }

    public class ParkingSpot
    {
 

        public double TimeParked(DateTime TimeOut, DateTime TimeIn)
        {
            return (TimeOut - TimeIn).TotalHours;
        }

        public double Cost(ParkingType parkingType, double timeParked)
        {
            if (parkingType == ParkingType.General)
                return 1 * timeParked;
            if (parkingType == ParkingType.Valet)
                return 2 * timeParked;

            return 3 * timeParked;
            //return parkingType * timeParked;
        }



        //public list AddCar(Car model)
        //{
        //    //someway to input and store level, spot and info

        //}
        //// Dict<LevelName string, List<spot>>
        //// if (spot.where(S=75.Existing num == incoming parkingspot.num){error or increment to next spot}



     
    }

    public class Car
    {
        public string OwnerName { get; set; }
        public string LicensePlate { get; set; }
    }


    public class StructureService
    {
        //AddCar


        //RemoveCar
        //ParkingCost
        //GetOwner
        //GetParkingSpace
    }

}
