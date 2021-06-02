using System;

namespace DPRN2_U3_EA_HICL
{
    class ModulosDeAyuda
    {

        public static void MandarMensaje(int X, int Y, string mensaje)
        {//Método que permite mostrar un pequeño mensaje

            //Se agrega el mensaje
            Console.SetCursorPosition(X + 2, Y + 2);
            Console.WriteLine(mensaje);
        }

        public static void MandarMensaje(int X, int Y, string mensaje, bool borrar)
        {//Método que permite mostrar un pequeño mensaje

            MandarMensaje(X, Y, mensaje);

            if (borrar == true)//Si se desea borrar el mensaje
            {
                Console.SetCursorPosition(X + 4, Y + 4);
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
                
                //Se limpiea el mensaje
                Console.SetCursorPosition(X + 2, Y + 2);
                Console.WriteLine("                                                   ");
                Console.SetCursorPosition(X + 4, Y + 4);
                Console.WriteLine("                                                   ");
            }
        }

        public static string PreguntarSiONo(int X, int Y)
        {
            string opcion = null;
            Capturar();

            void Capturar()
            {
                try
                {
                    Console.SetCursorPosition(X - 1, Y);
                    Console.WriteLine("[ ] ");

                    Console.SetCursorPosition(X, Y);
                    opcion = Console.ReadLine();

                    if (opcion.ToLower().Equals("s"))//Eligieron SI
                    {
                    }
                    else
                    {
                        if (opcion.ToLower().Equals("n"))//Eligieron NO
                        {
                        }
                        else//Cualquier otra tecla lanza una excepción
                        {
                            //se lanza una excepción propia
                            throw new GestionDeErroresPropiosException("          Ingrese [S] ó [N]");
                        }
                    }
                }
                catch (Exception e)
                {   //Se invoca método para controlar los errores
                    Principal.ControlarExcepciones(e);//Se envía por parámetro el error
                    Capturar();//Se pide nuevamente el dato
                }
            }

            return opcion;
        }

        public static byte? ElegirOpcion(int X, int Y, int opcIni, int opcFin)
        {//Método para elegir opción del menú principal
            byte? opcion = null;//Variable que guarda la opción elegida

            Console.SetCursorPosition(X, Y);//Se captura la opcion deseada
            opcion = Convert.ToByte(Console.ReadLine());

            if (opcion < opcIni || opcion > opcFin)//Si opción no válida

            {   //Se lanza excepción propia
                throw new GestionDeErroresPropiosException("            ¡OPCIÓN NO VÁLIDA!");
            }
            else//Si todo está correcto, se procede
            {
                return opcion;//Se retorna la opción elegida
            }
        }


    }
}