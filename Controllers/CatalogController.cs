using Microsoft.AspNetCore.Mvc;
using VideoCatalog.Core;
using VideoCatalog.Data;
using VideoCatalog.Helpers;
using VideoCatalog.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace VideoCatalog.Controllers
{
    public class CatalogController : Controller
    {

        UnitOfWork unitOfWork;
        OperationResult operationResult = new OperationResult();

        public CatalogController(VideoCatalogContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }
        public JsonResult getAll()
        {
            var rep = unitOfWork.CatalogRepository.GetAll();
             var eventList = from e in rep
                            select new
                            {
                                CatalogID = e.CatalogID,
                                CatalogName = e.CatalogName,
                                ModifiedDate = e.ModifiedDate            
                            };
            // phải trả về eventList.FirstOrDefault(); vì eventList.ToArray(); trả về một list
            var rows = eventList.ToList();
            return Json(rep);
        }
        public JsonResult addEntity(Catalog entity)
        {
            entity.ModifiedDate = DateTime.Now;
            operationResult = unitOfWork.CatalogRepository.Add(entity);
            unitOfWork.Complete();
            if (operationResult.Success)
            {
                return Json(new
                {
                    statusCode = 200,
                    status = operationResult.Message,

                });

            }
            else
            {
                return Json(new
                {
                    statusCode = 400,
                    status = operationResult.Message,

                });

            }
        }
        public JsonResult updateEntity(Catalog entity)
        {
             entity.ModifiedDate = DateTime.Now;
            operationResult = unitOfWork.CatalogRepository.Update(entity, x => x.CatalogID == entity.CatalogID);
            unitOfWork.Complete();
            if (operationResult.Success)
            {
                return Json(new
                {
                    statusCode = 200,
                    status = operationResult.Message,

                });

            }
            else
            {
                return Json(new
                {
                    statusCode = 400,
                    status = operationResult.Message,

                });

            }
        }
        public JsonResult getById(int id)
        {
            var currentEntity = unitOfWork.CatalogRepository.FindBy(x=>x.CatalogID == id);
            var eventList = from e in currentEntity
                            select new
                            {
                                catalogID = e.CatalogID,
                                catalogName = e.CatalogName
                                
                            };
            // phải trả về eventList.FirstOrDefault(); vì eventList.ToArray(); trả về một list
            var rows = eventList.FirstOrDefault();
            return Json(rows);
        }
        public JsonResult removeEntity(int id)
        {
            
            var currentEntity = unitOfWork.CatalogRepository.FindBy(x=>x.CatalogID == id).FirstOrDefault();
            operationResult =unitOfWork.CatalogRepository.Remove(currentEntity);
            unitOfWork.Complete();
            if (operationResult.Success)
            {
                return Json(new
                {
                    statusCode = 200,
                    status = operationResult.Message,

                });

            }
            else
            {
                return Json(new
                {
                    statusCode = 400,
                    status = operationResult.Message,

                });

            }
        }
        
    }
}