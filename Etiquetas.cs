using System;

namespace DPRN2_U3_EA_HICL
{
    class Etiquetas
    {
        public static void EtiquetasModificarPlanetas(int X, int Y, string _nombre, long _rotacion, long _orbita)
        {//Etiquetas para mostrar datos del planeta y modificarlos
            DibujaTitulo();//Limpiamos pantalla

            Console.SetCursorPosition(X, Y);//38, 9
            Console.WriteLine("|------------------------------------------|");
            Console.SetCursorPosition(X, Y + 1);
            Console.WriteLine("|              DATOS ANTERIORES            |");
            Console.SetCursorPosition(X, Y + 2);
            Console.WriteLine("|------------------------------------------|");
            Console.SetCursorPosition(X, Y + 3);
            Console.WriteLine("|   NOMBRE:                                |");
            Console.SetCursorPosition(X, Y + 4);
            Console.WriteLine("| ROTACIÓN:                                |");
            Console.SetCursorPosition(X, Y + 5);
            Console.WriteLine("|   ÓRBITA:                                |");
            Console.SetCursorPosition(X, Y + 6);
            Console.WriteLine("|------------------------------------------|");

            Console.SetCursorPosition(X + 12, Y + 3);
            Console.WriteLine(_nombre.ToUpper());//Agregamos nombre del planeta
            Console.SetCursorPosition(X + 12, Y + 4);
            Console.WriteLine(_rotacion);//Agregamos rotación del planeta
            Console.SetCursorPosition(X + 12, Y + 5);
            Console.WriteLine(_orbita);//Agregamos órbiyta del planeta
        }

        public static void EtiquetasAccionEnPlanetas(int X, int Y)
        {//Etiquetas para mostrar botones tipo CRUD

            Console.SetCursorPosition(X, Y);//57, 9
            Console.WriteLine("|-----------------------|");
            Console.SetCursorPosition(X, Y + 1);
            Console.WriteLine("| 1. Crear Planeta      |");
            Console.SetCursorPosition(X, Y + 2);
            Console.WriteLine("|-----------------------|");

            Console.SetCursorPosition(X, Y + 4);
            Console.WriteLine("|-----------------------|");
            Console.SetCursorPosition(X, Y + 5);
            Console.WriteLine("| 2. Modificar Planeta  |");
            Console.SetCursorPosition(X, Y + 6);
            Console.WriteLine("|-----------------------|");

            Console.SetCursorPosition(X + 26, Y);
            Console.WriteLine("|-----------------------|");
            Console.SetCursorPosition(X + 26, Y + 1);
            Console.WriteLine("| 3. Destruir Planeta   |");
            Console.SetCursorPosition(X + 26, Y + 2);
            Console.WriteLine("|-----------------------|");

            Console.SetCursorPosition(X + 26, Y + 4);
            Console.WriteLine("|-----------------------|");
            Console.SetCursorPosition(X + 26, Y + 5);
            Console.WriteLine("| 4. Transferir Planeta |");
            Console.SetCursorPosition(X + 26, Y + 6);
            Console.WriteLine("|-----------------------|");

            Console.SetCursorPosition(X, Y + 8);
            Console.WriteLine("|-----------------------|");
            Console.SetCursorPosition(X, Y + 9);
            Console.WriteLine("| 5. Salir              |");
            Console.SetCursorPosition(X, Y + 10);
            Console.WriteLine("|-----------------------|");
        }
        public static void EtiquetasCatálogoPlanetas(int X, int Y, string universo)
        {//Etiquetas para mostrar datos de los planetas
            DibujaTitulo();//Limpiamos pantalla

            Console.SetCursorPosition(X, Y);//28, 9
            Console.WriteLine("|------------------------------------------|");
            Console.SetCursorPosition(X, Y + 1);
            Console.WriteLine("|    PLANETAS DEL UNIVERSO                 |");
            Console.SetCursorPosition(X, Y + 2);
            Console.WriteLine("|------------------------------------------|");
            Console.SetCursorPosition(X, Y + 3);
            Console.WriteLine("|     NOMBRE        ROTACIÓN     ÓRBITA    |");
            Console.SetCursorPosition(X, Y + 4);
            Console.WriteLine("|------------------------------------------|");
            Console.SetCursorPosition(X, Y + 5);
            Console.WriteLine("|                                          |");
            Console.SetCursorPosition(X, Y + 6);
            Console.WriteLine("|                                          |");
            Console.SetCursorPosition(X, Y + 7);
            Console.WriteLine("|                                          |");
            Console.SetCursorPosition(X, Y + 8);
            Console.WriteLine("|                                          |");
            Console.SetCursorPosition(X, Y + 9);
            Console.WriteLine("|                                          |");
            Console.SetCursorPosition(X, Y + 10);
            Console.WriteLine("|                                          |");
            Console.SetCursorPosition(X, Y + 11);
            Console.WriteLine("|                                          |");
            Console.SetCursorPosition(X, Y + 12);
            Console.WriteLine("|                                          |");
            Console.SetCursorPosition(X, Y + 13);
            Console.WriteLine("|                                          |");
            Console.SetCursorPosition(X, Y + 14);
            Console.WriteLine("|                                          |");
            Console.SetCursorPosition(X, Y + 15);
            Console.WriteLine("|                                          |");
            Console.SetCursorPosition(X, Y + 16);
            Console.WriteLine("|                                          |");
            Console.SetCursorPosition(X, Y + 17);
            Console.WriteLine("|------------------------------------------|");
            Console.SetCursorPosition(X + 27, Y + 1);
            Console.WriteLine(universo.ToUpper());//Agregamos nombre del universo
        }

        public static void EtiquetasIngresarPlanetas(int X, int Y, string universo, string msg)
        {//Etiquetas para preguntar si desean ingresar planetas
         //X=61,Y=20
            Console.SetCursorPosition(X, Y);
            Console.WriteLine("|------------------------------------------|                               ");
            Console.SetCursorPosition(X, Y + 1);
            Console.WriteLine("|                                          |                               ");
            Console.SetCursorPosition(X, Y + 2);
            Console.WriteLine("|------------------------------------------|                               ");
            Console.SetCursorPosition(X, Y + 3);
            Console.WriteLine("|              Nombre:                     |                               ");
            Console.SetCursorPosition(X, Y + 4);
            Console.WriteLine("|     Periodo Orbital:                     |                               ");
            Console.SetCursorPosition(X, Y + 5);
            Console.WriteLine("| Periodo de Rotación:                     |                               ");
            Console.SetCursorPosition(X, Y + 6);
            Console.WriteLine("|------------------------------------------|                               ");
            Console.SetCursorPosition(X + 1, Y + 1);
            Console.WriteLine(msg + " " + universo.ToUpper());//Agregamos nombre del universo

        }

        public static void EtiquetasCrearPlanetasUniversoPreguntar(int X, int Y)
        {//Etiquetas para preguntar si desean ingresar planetas

            Console.SetCursorPosition(X, Y);
            Console.WriteLine("|------------------------------------------|");
            Console.SetCursorPosition(X, Y + 1);
            Console.WriteLine("| ¿DESEA INGRESAR LOS PLANETAS?: [ ]       |");
            Console.SetCursorPosition(X, Y + 2);
            Console.WriteLine("|            [S]i      [N]o                |");
            Console.SetCursorPosition(X, Y + 3);
            Console.WriteLine("|------------------------------------------|");
        }

        public static void EtiquetasCrearUniverso()
        {//Etiquetas para pedir datos de un nuevo universo
            DibujaTitulo();//Limpiamos pantalla

            Console.SetCursorPosition(38, 9);
            Console.WriteLine("|------------------------------------------|");
            Console.SetCursorPosition(38, 10);
            Console.WriteLine("|   INGRESE LOS DATOS DEL NUEVO UNIVERSO   |");
            Console.SetCursorPosition(38, 11);
            Console.WriteLine("|------------------------------------------|");
            Console.SetCursorPosition(38, 12);
            Console.WriteLine("| NOMBRE:                                  |");
            Console.SetCursorPosition(38, 13);
            Console.WriteLine("|------------------------------------------|");
        }

        public static void EtiquetasCatálogoUniverso(int X, int Y)
        {//Etiquetas para mostrar datos de los universos
            DibujaTitulo();//Limpiamos pantalla

            Console.SetCursorPosition(X, Y);
            Console.WriteLine("|------------------------------------------|");
            Console.SetCursorPosition(X, Y + 1);
            Console.WriteLine("|      CATÁLOGO DE UNIVERSOS CREADOS       |");
            Console.SetCursorPosition(X, Y + 2);
            Console.WriteLine("|------------------------------------------|");
            Console.SetCursorPosition(X, Y + 3);
            Console.WriteLine("|     NOMBRE               # PLANETAS      |");
            Console.SetCursorPosition(X, Y + 4);
            Console.WriteLine("|------------------------------------------|");
            Console.SetCursorPosition(X, Y + 5);
            Console.WriteLine("|                                          |");
            Console.SetCursorPosition(X, Y + 6);
            Console.WriteLine("|                                          |");
            Console.SetCursorPosition(X, Y + 7);
            Console.WriteLine("|                                          |");
            Console.SetCursorPosition(X, Y + 8);
            Console.WriteLine("|                                          |");
            Console.SetCursorPosition(X, Y + 9);
            Console.WriteLine("|                                          |");
            Console.SetCursorPosition(X, Y + 10);
            Console.WriteLine("|                                          |");
            Console.SetCursorPosition(X, Y + 11);
            Console.WriteLine("|------------------------------------------|");
        }

        public static void MenuPrincipal()//Método que implementa al menú principal
        {

            DibujaTitulo();
            //Menú de opciones
            Console.SetCursorPosition(38, 9);
            Console.WriteLine("|------------------------------------------|");
            Console.SetCursorPosition(38, 10);
            Console.WriteLine("|        MENÚ PRINCIPAL DEL CREADOR        |");
            Console.SetCursorPosition(38, 11);
            Console.WriteLine("|------------------------------------------|");
            Console.SetCursorPosition(38, 12);
            Console.WriteLine("| 1. Ver universos.                        |");
            Console.SetCursorPosition(38, 13);
            Console.WriteLine("| 2. Crear nuevo universo.                 |");
            Console.SetCursorPosition(38, 14);
            Console.WriteLine("| 3. Modificar universos.                  |");
            Console.SetCursorPosition(38, 15);
            Console.WriteLine("| 4. Eliminar universos.                   |");
            Console.SetCursorPosition(38, 16);
            Console.WriteLine("| 5. Salir.                                |");
            Console.SetCursorPosition(38, 17);
            Console.WriteLine("|------------------------------------------|");
            Console.SetCursorPosition(38, 18);
            Console.WriteLine("| ELIJA UNA OPCIÓN [ ]                     |");
            Console.SetCursorPosition(38, 19);
            Console.WriteLine("|------------------------------------------|");
        }

        public static void DibujaTitulo()//Método que permite agregar título a la ventana principal
        {
            //Mensajes de bienvenida al programa
            Console.Clear();
            Console.SetCursorPosition(40, 1);
            Console.WriteLine("****************************************");
            Console.SetCursorPosition(40, 2);
            Console.WriteLine("*        Programación .NET II          *");
            Console.SetCursorPosition(40, 3);
            Console.WriteLine("*   Evidencia de Aprendizaje - UNADM   *");
            Console.SetCursorPosition(40, 4);
            Console.WriteLine("*        Control de errores en         *");
            Console.SetCursorPosition(40, 5);
            Console.WriteLine("*     conjuntos de objetos en C#       *");
            Console.SetCursorPosition(40, 6);
            Console.WriteLine("*      Alumno: Hiram Chávez López      *");
            Console.SetCursorPosition(40, 7);
            Console.WriteLine("****************************************");
        }
    }

}
