using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;

namespace DPRN2_U3_EA_HICL
{
    class Principal
    {
        //Transformar  planetas en un arreglo de Planetas (transforma JSON a objeto c#)
        public static List<Universo> planetasStarWars = JsonConvert.DeserializeObject<List<Universo>>(Constantes.MisPlanetas);

        static void Main()
        {
            byte? opcionMenuPrincipal = null;

            try//Esta sentencia Try-Catch gestionará las excepciones
            {  //al más alto nivel, que se produzcan en el programa

                do
                {//Mostraremos el menú mientras no se elija SALIR
                    Etiquetas.MenuPrincipal();//Se llama al menu principal
                    opcionMenuPrincipal = ModulosDeAyuda.ElegirOpcion(58, 18, 1, 5);//Se elige opción del menú principal
                    RealizarAccion(opcionMenuPrincipal);//Se lleva a cabo la tarea  elegida
                }
                while (opcionMenuPrincipal != 5);//si se elije SALIR finaliza el ciclo

            }
            catch (Exception e)
            {   //Se invoca método para controlar los errores
                ControlarExcepciones(e);//Se envía por parámetro el error
                Main();//Después de indicar el error, se vuelve al menú principal
            }
        }

        static void RealizarAccion(byte? opcionMenuPrincipal)
        {
            switch (opcionMenuPrincipal)
            {
                case 1://VER UNIVERSOS
                    //UniversoPredeterminado();
                    Etiquetas.EtiquetasCatálogoUniverso(38,9);//Imprimimos etiquetas
                    Universo.VerUniversos(38, 9, false, -1);//Mostramos los universos que hay
                    Console.ReadKey();//Espera de una tecla
                    break;

                case 2://CREAR UNIVERSO
                    Etiquetas.EtiquetasCrearUniverso();//Imprimimos etiquetas
                    Universo.CrearUniverso();
                    Console.ReadKey();//Espera de una tecla
                    break;

                case 3://MODIFICAR UNIVERSO
                    Etiquetas.EtiquetasCatálogoUniverso(38, 9);//Imprimimos etiquetas
                    Universo.VerUniversos(38, 9, false, -1);//Mostramos los universos que hay
                    Universo.ModificarUniverso();//Modificar un universo

                    Console.ReadKey();//Espera de una tecla
                    break;

                case 4://ELIMINAR UNIVERSO
                    Etiquetas.EtiquetasCatálogoUniverso(38,9);//Imprimimos etiquetas
                    Universo.VerUniversos(38, 9, false, -1);//Mostramos los universos que hay
                    Universo.EliminarUniverso();//Seleccionar y eliminar universo

                    Console.ReadKey();//Espera de una tecla
                    break;

                case 5: //Salir del programa
                    break;

                default:
                    Console.WriteLine("No existe esa opción");
                    break;
            }
        }

        public static void ControlarExcepciones(Exception e)//Método para controlar las                                                      
        {//excepciones. Según la excepción muestra un mensaje

            //Variable para almacenar tipo de error
            string error = null;
            error = Convert.ToString(e.GetType());

            //Si es un error por que se ingresó letras
            if (error.Equals("System.FormatException"))
            {
                Console.SetCursorPosition(40, 28);//Mensaje para el usuario
                Console.WriteLine("¡INGRESE NÚMEROS SIN LETRAS!");

            }//Si es un error por que se ingresó un número muy grande o muy pequeño
            else
            {
                if (error.Equals("System.OverflowException"))
                {
                    Console.SetCursorPosition(40, 28);//Mensaje para el usuario
                    Console.WriteLine("** ¡NÚMERO MUY GRANDE! **");
                }//Si es un error por fuera de rango de un array
                else
                {
                    if (error.Equals("System.IndexOutOfRangeException"))
                    {
                        Console.SetCursorPosition(40, 28);//Mensaje para el usuario
                        Console.WriteLine("SUPERÓ EL RANGO DE LA MATRIZ");
                    }
                    else
                    {
                        Console.SetCursorPosition(40, 28);//Cualquier otro tipo de error
                        Console.WriteLine(e.Message);//Mensaje para el usuario
                    }
                }
            }

            //Console.SetCursorPosition(40, 25);//Mensaje para el usuario
            //Console.WriteLine(e.GetType());

            Console.ReadKey();//Espera de una tecla
            Console.SetCursorPosition(40, 28);
            Console.WriteLine("                                                       ");//Se limpia el mensaje
        }
    }
}
