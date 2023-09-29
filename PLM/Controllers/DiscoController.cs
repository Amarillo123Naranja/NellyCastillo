using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLM.Controllers
{
    public class DiscoController : Controller
    {
        // GET: Disco
       
            [HttpGet]
            public ActionResult GetAll()
            {
                ML.Result result = BL.Disco.GetAll();
                ML.Disco disco = new ML.Disco();
                disco.Discos = result.Objects;

                if (result.Correct)
                {

                    return View(disco);

                }
                else
                {
                    return View();
                }
            }


            [HttpGet]
            public ActionResult Form(int? IdDisco)
            {
                ML.Disco disco = new ML.Disco();

                if (IdDisco != null)//Actualiza
                {

                    ML.Result result = BL.Disco.GetById(IdDisco.Value);

                    if (result.Correct)
                    {
                        disco = (ML.Disco)result.Object;


                    }
                }

                else//Muestra la vista
                {
                    return View();


                }

                return View(disco);

            }

            [HttpPost]
            public ActionResult Form(ML.Disco disco)
            {


                if (disco.IdDisco == 0)//Agregar
                {
                    ML.Result result = BL.Disco.Add(disco);

                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "Registro Compleatdo con exito";

                    }
                    else
                    {
                        ViewBag.Mensaje = "Error al agregar el registro" + result.ErrorMessage;
                    }


                }
                else//Actualiza
                {
                    ML.Result result = BL.Disco.Update(disco);

                    if (result.Correct)
                    {

                        ViewBag.Mensaje = "Se ha compleatdo la actualizacion";
                    }

                    else
                    {
                        ViewBag.Mensaje = "Ocurrio un error al actualizar" + result.ErrorMessage;
                    }
                }

                return PartialView("Modal");


            }

            public ActionResult Delete(int IdDisco)
            {
                ML.Result result = BL.Disco.Delete(IdDisco);

                if (result.Correct)
                {
                    ViewBag.Mensaje = "Registro eliminado con Exito";



                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un error al eliminar el registro" + result.ErrorMessage;
                }

                return PartialView("Modal");


            }
        }

    }
    
