using Microsoft.AspNetCore.Mvc;
using VideoCatalog.Core;
using VideoCatalog.Data;
using VideoCatalog.Helpers;
using VideoCatalog.Models;
using System.Collections.Generic;
using System.Linq;

namespace VideoCatalog.Controllers
{
    public class ItemController :  Controller
    {
        UnitOfWork unitOfWork;
        OperationResult operationResult = new OperationResult();

        public ItemController(VideoCatalogContext context)
        {
            unitOfWork = new UnitOfWork(context);

        }
        public JsonResult getAll()
        {
            return Json(unitOfWork.ItemRepository.GetAll());
        }
        public JsonResult addEntity(Item entity)
        {
            operationResult = unitOfWork.ItemRepository.Add(entity);
            unitOfWork.Complete();
            if (operationResult.Success)
            {
                return Json(new
                {
                    statusCode = 200,
                    status = operationResult.Message

                });

            }
            else
            {
                return Json(new
                {
                    statusCode = 400,
                    status = operationResult.Message

                });

            }
        }
        public JsonResult updateEntity(Item entity)
        {
            operationResult = unitOfWork.ItemRepository.Update(entity, x => x.ItemID == entity.ItemID);
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
            var currentEntity = unitOfWork.ItemRepository.FindBy(x=>x.ItemID == id);

            return Json(currentEntity);
        }
        public JsonResult removeEntity(int id)
        {
            var currentEntity = unitOfWork.ItemRepository.FindBy(x=>x.ItemID == id).FirstOrDefault();
            operationResult =unitOfWork.ItemRepository.Remove(currentEntity);
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
                    status = operationResult.Message

                });

            }
        }

<<<<<<< HEAD
        public IActionResult gitDemo()
=======
        public IActionResult demo()
>>>>>>> parent of 517148b... Update Item Controller 2
        {
            return View();
        }
    }
}