using DbConnect.Adapter;
using DbConnect.Tools;
using HtmlAgilityPack;
using PersonalProject.Models;
using PersonalProject.Request;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PersonalProject.Services
{
    public class LocationService : BaseService, ILocationService
    {
        //getall
        public IEnumerable<LocationModel> GetAllLocations()
        {
            DbCmdDef cmdDef = new DbCmdDef
            {
                DbCommandText = "dbo.Location_SelectAll",
                DbCommandType = System.Data.CommandType.StoredProcedure,

            };
            return Adapter.LoadObject<LocationModel>(cmdDef);
        }
        //getbyid
        public LocationModel GetById(int id)
        {
            try
            {
                return Adapter.LoadObject<LocationModel>(new DbCmdDef
                {
                    DbCommandText = "dbo.Location_SelectById",
                    DbCommandType = System.Data.CommandType.StoredProcedure,
                    DbParameters = new[]
                    {
                        SqlDbParameter.Instance.BuildParameter("@Id", id, System.Data.SqlDbType.Int)

                    }

                }).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        //post
        public int Insert(LocationAddRequest model)
        {
            int id = 0;

            Adapter.ExecuteQuery(new DbCmdDef
            {
                DbCommandText = "dbo.Location_Insert",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = new[]
                    {
                        SqlDbParameter.Instance.BuildParameter("@LocationName", model.LocationName, System.Data.SqlDbType.NVarChar,50),
                        SqlDbParameter.Instance.BuildParameter("@LocationDescription", model.LocationDescription, System.Data.SqlDbType.NVarChar,300),
                        SqlDbParameter.Instance.BuildParameter("@StreetAddress", model.StreetAddress, System.Data.SqlDbType.NVarChar,50),
                        SqlDbParameter.Instance.BuildParameter("@City", model.City, System.Data.SqlDbType.NVarChar,50),
                        SqlDbParameter.Instance.BuildParameter("@State", model.State, System.Data.SqlDbType.NVarChar,50),
                        SqlDbParameter.Instance.BuildParameter("@PostalCode", model.PostalCode, System.Data.SqlDbType.NVarChar,50),
                        SqlDbParameter.Instance.BuildParameter("@LocationUrl", model.LocationUrl, System.Data.SqlDbType.NVarChar,200),


                        SqlDbParameter.Instance.BuildParameter("@Id", id, System.Data.SqlDbType.Int,paramDirection: ParameterDirection.Output),

                    }

            },
                 delegate (IDataParameterCollection param)
                {
                    Int32.TryParse(param["@Id"].ToString(), out id);
                });
            return id;
        }

        //delete
        public void Delete(int id)
        {
            Adapter.ExecuteQuery(new DbCmdDef
            {
                DbCommandText = "dbo.Location_Delete",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = new[]
                     {
                        SqlDbParameter.Instance.BuildParameter("@Id", id, System.Data.SqlDbType.Int),

                     }

            });
        }

        //update
        public void Update(LocationUpdateRequest model)
        {

            Adapter.ExecuteQuery(new DbCmdDef
            {
                DbCommandText = "dbo.Location_Update",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = new[]
                    {
                        SqlDbParameter.Instance.BuildParameter("@Id", model.Id, System.Data.SqlDbType.Int),
                        SqlDbParameter.Instance.BuildParameter("@LocationName", model.LocationName, System.Data.SqlDbType.NVarChar,50),
                        SqlDbParameter.Instance.BuildParameter("@LocationDescription", model.LocationDescription, System.Data.SqlDbType.NVarChar,300),
                        SqlDbParameter.Instance.BuildParameter("@StreetAddress", model.StreetAddress, System.Data.SqlDbType.NVarChar,50),
                        SqlDbParameter.Instance.BuildParameter("@City", model.City, System.Data.SqlDbType.NVarChar,50),
                        SqlDbParameter.Instance.BuildParameter("@State", model.State, System.Data.SqlDbType.NVarChar,50),
                        SqlDbParameter.Instance.BuildParameter("@PostalCode", model.PostalCode, System.Data.SqlDbType.NVarChar,50),
                        SqlDbParameter.Instance.BuildParameter("@LocationUrl", model.LocationUrl, System.Data.SqlDbType.NVarChar,200),

                    }

            
                 });
          
        }
        //scraper
        public string Scrape(ScrapRequest model)
        {

            //var html = @"https://www.yelp.com/biz/mo-ran-gak-restaurant-garden-grove";

            var html = @model.Url;

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            var node = htmlDoc.DocumentNode.SelectSingleNode("//head/title");

            return node.InnerHtml;
            //Console.WriteLine(node.InnerHtml);
            //    Console.ReadLine();
        }

    }
}
