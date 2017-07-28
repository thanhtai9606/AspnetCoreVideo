using Microsoft.AspNetCore.Mvc;
using VideoCatalog.Core;
using VideoCatalog.Data;
using VideoCatalog.Helpers;
using VideoCatalog.Models;
using System.Collections.Generic;
using System.Linq;
namespace VideoCatalog.Controllers
{
    public class CategoryController : Controller
    {
        UnitOfWork unitOfWork;
        OperationResult operationResult = new OperationResult();

        public CategoryController(VideoCatalogContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }
        public JsonResult getAll()
        {
             var rep = unitOfWork.CategoryRepository.GetAll();
             var eventList = from e in rep
                            select new
                            {
                               CategoryID = e.CategoryID,
                               CategoryName = e.CategoryName,
                                ModifiedDate = e.ModifiedDate                              
                               

                            };
            // phải trả về eventList.FirstOrDefault(); vì eventList.ToArray(); trả về một list
            var rows = eventList.ToList();
            return Json(rep);
            //return Json(unitOfWork.CategoryRepository.GetAll());
        }
        public JsonResult addEntity(Category entity)
        {
            operationResult = unitOfWork.CategoryRepository.Add(entity);
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
        public JsonResult updateEntity(Category entity)
        {
            operationResult = unitOfWork.CategoryRepository.Update(entity, x => x.CategoryID == entity.CategoryID);
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
            var currentEntity = unitOfWork.CategoryRepository.FindBy(x=>x.CategoryID == id);

            return Json(currentEntity);
        }
        public JsonResult removeEntity(int id)
        {
            var currentEntity = unitOfWork.CategoryRepository.FindBy(x=>x.CategoryID == id).FirstOrDefault();
            operationResult =unitOfWork.CategoryRepository.Remove(currentEntity);
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