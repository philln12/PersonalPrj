using PersonalProject.Models;
using PersonalProject.Request;
using PersonalProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PersonalProject.Controllers.Api
{
    [AllowAnonymous]
    [RoutePrefix("api/Locations")]
    public class LocationController : ApiController
    {
        ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        //[AuthorizationRequired]
        [Route(), HttpGet]
        public HttpResponseMessage GetAllLocations()
        {
            try
            {
                //ItemsResponse<ProductModel> response = new ItemsResponse<ProductModel>();
                //response.Items = _productService.GetAllProducts();
                IEnumerable<LocationModel> locations = _locationService.GetAllLocations();
                return Request.CreateResponse(HttpStatusCode.OK, locations);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            };
        }

        [Route(), HttpPost]
        public HttpResponseMessage PostLocation(LocationAddRequest model)
        {
            try
            {         
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                //ItemResponse<int> response = new ItemResponse<int>();
                //response.Item = _organicLocation.Insert(model);
                int locations = _locationService.Insert(model);


                return Request.CreateResponse(HttpStatusCode.OK, locations);
            }
            catch (Exception ex)
            {
                //logError(MethodBase.GetCurrentMethod().Name, ex);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
               
                _locationService.Delete(id);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
         
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage PutOrganicLocation(LocationUpdateRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                _locationService.Update(model);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {               
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }
        [Route("YelpUrl"), HttpPost]
        public HttpResponseMessage Scrape(ScrapRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
           
                string locationresult = _locationService.Scrape(model);


                return Request.CreateResponse(HttpStatusCode.OK, locationresult);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }
}

