using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Disco
    {

       public static ML.Result GetAll()
        {

            ML.Result result = new ML.Result();

            try
            {

                using(DL.NCastilloPruebaTecnicaDosEntities context = new DL.NCastilloPruebaTecnicaDosEntities())
                {
                    var query = context.DiscoGetAll().ToList();

                    result.Objects = new List<object>();

                    if (query != null)
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

                            disco.Disponibilidad = Convert.ToBoolean(registro.Disponibilidad);

                            result.Objects.Add(disco);
                        }

                        result.Correct = true;

                    }

                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al mostrar los discos";
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

        public static ML.Result Add( ML.Disco disco)



        {
            ML.Result result = new ML.Result();

            try 
            {
                using(DL.NCastilloPruebaTecnicaDosEntities context = new DL.NCastilloPruebaTecnicaDosEntities())
                {

                    var query = context.DiscoAdd(disco.Titulo, disco.Artista, disco.GeneroMusical, disco.Duracion, disco.Año, disco.Distribuidora, disco.Ventas, disco.Disponibilidad);

                    if(query > 0)
                    {

                        result.Correct = true;
                    }

                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al agregar Disco";
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


        public static ML.Result Update( ML.Disco disco) 
        {
            ML.Result result = new ML.Result();

            try
            {

                using (DL.NCastilloPruebaTecnicaDosEntities context = new DL.NCastilloPruebaTecnicaDosEntities())
                {

                    int filasAfectadas = context.DiscoUpdate(disco.IdDisco, disco.Titulo, disco.Artista, disco.GeneroMusical, disco.Duracion, disco.Año, disco.Distribuidora, disco.Ventas, disco.Disponibilidad);

                    if(filasAfectadas > 0)
                    {

                        result.Correct = true;  
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al actualizar la disco";
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


        public static ML.Result GetById( int IdDisco) 
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.NCastilloPruebaTecnicaDosEntities context = new DL.NCastilloPruebaTecnicaDosEntities())
                {
                    var query = context.DiscoGetById(IdDisco).SingleOrDefault();

                    result.Objects = new List<object>();


                    if (query != null)
                    {
                        ML.Disco disco = new ML.Disco();

                        

                            disco.IdDisco = query.IdDisco;

                            disco.Titulo = query.Titulo;

                            disco.Artista = query.Artista;

                            disco.GeneroMusical = query.GeneroMusical;

                            disco.Duracion = query.Duracion;

                            disco.Año = query.Año;

                            disco.Distribuidora = query.Distribuidora;

                            disco.Ventas = query.Ventas;

                            disco.Disponibilidad = Convert.ToBoolean(query.Disponibilidad);

                            result.Object = disco;


                            result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al consultar Disco";
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


        public static ML.Result Delete(int IdDisco)
        {

            ML.Result result = new ML.Result();

            try 
            {
                using (DL.NCastilloPruebaTecnicaDosEntities context = new DL.NCastilloPruebaTecnicaDosEntities())
                {
                    int filasAfectadas = context.DiscoDelete(IdDisco);  

                    if(filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct= false;

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
