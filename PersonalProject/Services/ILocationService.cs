using PersonalProject.Models;
using PersonalProject.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.Services
{
    public interface ILocationService
    {

        IEnumerable<LocationModel> GetAllLocations();
        LocationModel GetById(int id);
        int Insert(LocationAddRequest model);
        void Delete(int id);
        void Update(LocationUpdateRequest model);
        string Scrape(ScrapRequest model);

    }
}
