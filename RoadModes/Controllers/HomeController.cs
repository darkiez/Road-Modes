using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoadModes.Models;
using System.Configuration;
using System.Data.SqlClient;
using RoadModes.DB;

namespace RoadModes.Controllers
{

    public class HomeController : Controller
    {
        Roadez _db;

        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(ROAD_LAYERZ insertmodel)
        {
            
            RoadsEntities2 entity = new RoadsEntities2();
            
            try
            {
                entity.ROAD_LAYERZ.Add(insertmodel);

                entity.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            Roadez cow = new Roadez();
            cow.SEG_ID = insertmodel.SEG_ID;
            cow.BEGIN_DIST = insertmodel.BEGIN_DIST;
            cow.END_DIST = insertmodel.END_DIS;
            cow.BUILD_DATE = insertmodel.BUILD_DATE;
            cow.LAYER_THICK = insertmodel.LAYER_THICK;
            cow.LAYER_MAT = insertmodel.LAYER__MAT;
            
            return View(cow);
        }




        [HttpGet]
        public ActionResult Edit(int id)
        {
            RoadsEntities2 entity = new RoadsEntities2();
            
            Roadez horse = new Roadez();

            try
            {
                var model = entity.ROAD_LAYERZ.Select(x => new Roadez
                {
                    SEG_ID = x.SEG_ID,
                    BEGIN_DIST = x.BEGIN_DIST,
                    END_DIST = x.END_DIS,
                    BUILD_DATE = x.BUILD_DATE,
                    LAYER_MAT = x.LAYER__MAT,
                    LAYER_THICK = x.LAYER_THICK
                }).Where(y => y.SEG_ID == id);
                
                horse.SEG_ID = model.FirstOrDefault().SEG_ID;
                horse.BEGIN_DIST = model.FirstOrDefault().BEGIN_DIST;
                horse.END_DIST = model.FirstOrDefault().END_DIST;
                horse.BUILD_DATE = model.FirstOrDefault().BUILD_DATE;
                horse.LAYER_MAT = model.FirstOrDefault().LAYER_MAT;
                horse.LAYER_THICK = model.FirstOrDefault().LAYER_THICK;

            }
            catch (Exception)
            {
                throw;
            }
            
            return View(horse);
        }

        [HttpPost]
        public ActionResult Edit(ROAD_LAYERZ updatemodel, int id)
        {
            
            RoadsEntities2 entity = new RoadsEntities2();
 
            try
            {
                var model = entity.ROAD_LAYERZ.Select(x => new Roadez
                {
                    //SEG_ID = updatemodel.SEG_ID,
                    BEGIN_DIST = updatemodel.BEGIN_DIST,
                    END_DIST = updatemodel.END_DIS,
                    BUILD_DATE = updatemodel.BUILD_DATE,
                    LAYER_MAT = updatemodel.LAYER__MAT,
                    LAYER_THICK = updatemodel.LAYER_THICK
                }).Where(y => y.SEG_ID == id);

                //horse.SEG_ID = model.FirstOrDefault().SEG_ID;
                //horse.BEGIN_DIST = model.FirstOrDefault().BEGIN_DIST;
                //horse.END_DIST = model.FirstOrDefault().END_DIST;
                //horse.BUILD_DATE = model.FirstOrDefault().BUILD_DATE;
                //horse.LAYER_MAT = model.FirstOrDefault().LAYER_MAT;
                //horse.LAYER_THICK = model.FirstOrDefault().LAYER_THICK;
                
                entity.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            
            return RedirectToAction("Home","List");
        }
        
        [HttpPost]
        public ActionResult Delete(int id)
        {
            
            RoadsEntities2 entity = new RoadsEntities2();

            try
            {
                var model = new ROAD_LAYERZ { SEG_ID = id };

                entity.ROAD_LAYERZ.Attach(model);
                entity.ROAD_LAYERZ.Remove(model);
                
                entity.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("Home", "List");
        }
        
        [HttpGet]
        public ActionResult List()
        {
            
            RoadsEntities2 entity = new RoadsEntities2();

            List<Roadez> pig = new List<Roadez>();
            try
            {
                var model = entity.ROAD_LAYERZ.Select(x => new Roadez
                {
                    SEG_ID = x.SEG_ID,
                    BEGIN_DIST = x.BEGIN_DIST,
                    END_DIST = x.END_DIS,
                    BUILD_DATE = x.BUILD_DATE,
                    LAYER_MAT = x.LAYER__MAT,
                    LAYER_THICK = x.LAYER_THICK
                 });

                foreach (var item in model)
                {
                    pig.Add(item);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return View(pig);
        }
    }
}