using Microsoft.Win32;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BL
{
    public class Disco
    {

        public static ML.Result Add(ML.Disco disco)
        {
            ML.Result result = new ML.Result();

            try {

                using (DL.NCastilloPruebaTeoricaDos context =  new DL.NCastilloPruebaTeoricaDos())
                {
                    var query = context.DiscoAdd(disco.Titulo, disco.Artista, disco.GeneroMusical, disco.Duracion, disco.Año, disco.Distribuidora, disco.Ventas, disco.Disponibilidad);
                    if (query > 0)
                    {
                        result.Correct = true;

                    }

                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = ":::ERROR DISCO NO AGREGADO:::";
                    }


                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;  


        }


        public static ML.Result Update(ML.Disco disco)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL.NCastilloPruebaTecnicaDos context = new DL.NCastilloPruebaTecnicaDos())
                {

                    var query = context.DiscoUpdate(disco.IdDisco, disco.Titulo, disco.Artista, disco.GeneroMusical, disco.Duracion, disco.Año, disco.Distribuidora, disco.Ventas, disco.Disponibilidad);
                    if (query > 0)
                    {


                        result.Correct = true;
                    }
                    else
                    {

                        result.Correct = false;
                        result.ErrorMessage = ":::ERROR AL ACTUALIZAR LA DISCO";
                    }

                }

            }


            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }


            return result;
        }


        public static ML.Result Delete (int IdDisco)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.NCastilloPruebaTeoricaDos context = new DL.NCastilloPruebaTeoricados())
                {

                    int filasAfectadas = context.DiscoDelete(IdDisco);

                    if(filasAfectadas > 0)
                    {
                        result.Correct = true;  
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = ":::ERROR AL ELIMINAR EL DISCO";
                    }


                }
            }
            catch(Exception ex) 
            { 
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            
            
            
            }

            return result;


        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result ();

            try
            {
                using(DL.NCasstilloPruebaTeoricaDos context = new DL.NCastilloPruebaTeoricaDos())
                {
                    var query = context.DiscoGetAll().ToList();

                    if(query != null)
                    {

                        ML.Disco disco = new ML.Disco();    

                        foreach(var registro in query)
                        {
                            disco.IdDisco = registro.IdDisco;

                            disco.Titulo = registro.Titulo; 

                            disco.Artista = registro.Artista;   

                            disco.GeneroMusical = registro.GeneroMusical;

                            disco.Duracion = registro.Duracion;

                            disco.Año = registro.Año;

                            disco.Distribuidora = registro.Distribuidora;

                            disco.Ventas = registro.Ventas;

                            disco.Disponibilidad = registro.Disponibilidad;


                            result.Object.Add(disco);   


                        }

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = ":::ERROR AL CONSULTAR LOS DISCOS";
                    }

                }
            }
            catch( Exception ex)
            {
                result.Correct = false; 
            }

            return result;  
        }

        public static ML.Result GetById(int IdDisco)
        {
            ML.Result result = new ML.Result(); 
            
            try
            {
                using(DL.NCastilloPruebaTecnicaDos context = new DL.NCastilloPruebaTecnicaDos())
                {
                    var query = context.DiscoGetById(IdDisco).SingleOrderFault();

                    if(query != null)
                    {
                        foreach (var registro in query)
                        {
                            ML.Disco disco = new ML.Disco();

                            disco.IdDisco = registro.IdDisco;

                            disco.Titulo = registro.Titulo;

                            disco.Artista = registro.Artista;

                            disco.GeneroMusical = registro.GeneroMusical;

                            disco.Duracion = registro.Duracion;

                            disco.Año = registro.Año;

                            disco.Distribuidora = registro.Distribuidora;

                            disco.Ventas = registro.Ventas;

                            disco.Disponibilidad = registro.Disponibilidad;

                            result.Objects.Discos;



                        }
                    }


                }

            }
            catch (Exception ex) 
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }

            return result;  


        }

    }

    }
