using System;
using System.Globalization;
using System.Collections.Generic;

namespace DPRN2_U3_EA_HICL
{
    //SEGUNDA PARTE DE LA CLASE PARCIAL Universo (antes ViaLacteaStarWars)  
    //MÁS GENÉRICO, PARA AGREGAR: CONSTRUCTOR DE LA CLASE Y SUS MÉTODOS .
    //AL INICIAR EL PROGRAMA, AUTOMÁTICAMENTE CREARÁ EL PRIMER UNIVERSO,
    //EL CUAL SERÁ EL DE STAR WARS Y SUS PLANETAS (o galaxia)
    public partial class Universo
    {

        //Constructor sin parámetros
        public Universo()
        { }

        //MÉTODOS DE LA CLASE UNIVERSO
        public static void VerUniversos(int X, int Y, bool transferir, int _univActual)
        {
            string universo = null;//almacena el nombre del universo
            int? totalUniversos = null;
            totalUniversos = Principal.planetasStarWars.Count;

            if (totalUniversos == 0)//Si no hay universos
            {
                ModulosDeAyuda.MandarMensaje(X + 1, Y + 4, "¡NO HAY UNIVERSOS PARA MOSTRAR!");
                ModulosDeAyuda.MandarMensaje(X + 1, Y + 5, "      ¡CAPTÚRELOS PRIMERO!     ");
            }
            else//Si hay por lo menos un universo
            {
                for (int j = 0; j <= totalUniversos - 1; j++)//Recorremos todos los universos de la lista
                {
                    if (transferir && _univActual == j)//Si un planeta se transferirá, no se pone su universo
                    {

                    }
                    else//Si no es de transferencia, se ponen los universos
                    {
                        universo = Principal.planetasStarWars[j].NombreUniverso;//Agregamos el nombre
                        universo = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(universo));//Mayusculas primeras letras

                        Console.SetCursorPosition(X + 2, Y + 5 + j);//Nombre del universo
                        Console.WriteLine(j + 1 + ". " + universo);

                        Console.SetCursorPosition(X + 31, Y + 5 + j);//# de planetas del universo
                        Console.WriteLine(Principal.planetasStarWars[j].planetas.Count);
                    }
                }
            }
        }

        public static void CrearUniverso()
        {

            CapturarNombreDeUniverso();

            void CapturarNombreDeUniverso()
            {
                try
                {

                    string captura = null;//Variable temporal para almacenar el nombre

                    Console.SetCursorPosition(48, 12);
                    Console.WriteLine("                         ");//Se limpia el espacio

                    Console.SetCursorPosition(48, 12);
                    captura = Console.ReadLine().ToLower();//Se captura el  nombre

                    //Checamos si ya existe ese universo
                    bool existe = Principal.planetasStarWars.Exists(elemento => elemento.NombreUniverso.Equals(captura));

                    if (existe)//Si ya existe ese universo
                    {
                        //se lanza una excepción propia
                        throw new GestionDeErroresPropiosException("¡ESE UNIVERSO YA EXISTE, INGRESE OTRO NOMBRE!");
                    }
                    else
                    {
                        if (captura.Equals(""))//Si va vacío el nombre del universo
                        {
                            throw new GestionDeErroresPropiosException("       ¡EL NOMBRE NO PUEDE IR VACÍO!        ");
                        }
                        else//Si no existe ese universo entonces se crea pero con la
                        {//lista (vacía) para los planetas, éstos se agregan después                     
                            Principal.planetasStarWars.Add(new Universo//A la lista de universos agregamos uno nuevo
                            {   //Nombre del universo
                                NombreUniverso = captura, //(CultureInfo.InvariantCulture.TextInfo.ToTitleCase(captura)),
                                planetas = new List<Planeta>//Lista vacía de planetas para el nuevo universo
                                {//Más adelante se pueden agregar los planetas
                                 //new Planeta{//Instancia de la clase Planeta
                                    /*Name = _planeta,
                                    OrbitalPeriod = _orbital,
                                    RotationPeriod = _rotacion,*/
                                    //},
                                }
                            });

                            int _numUniversos = 0;//Variable para total de universos
                            int _universoActual = 0;//Variable para universo actual

                            _numUniversos = Principal.planetasStarWars.Count;//Total de registros en lista Universos
                            _universoActual = _numUniversos - 1;


                            string respuesta = null;

                            Etiquetas.EtiquetasCrearPlanetasUniversoPreguntar(38, 15);//Imprimir etiquetas
                            respuesta = ModulosDeAyuda.PreguntarSiONo(72, 16);//Método que valida Si o No. Pos. X, Y

                            if (respuesta.ToLower().Equals("s"))
                            {//Si desean agregar los planetas
                                CrearPlanetas(captura, _numUniversos, 61, 23, false, _universoActual, "INGRESE LOS PLANETAS DE", false, -1);
                            }
                            else
                            {
                                ModulosDeAyuda.MandarMensaje(50, 20, "¡UNIVERSO GUARDADO!");
                            }
                        }
                    }
                }
                catch (Exception e)
                {   //Se invoca método para controlar los errores
                    Principal.ControlarExcepciones(e);//Se envía por parámetro el error
                    CrearUniverso();//Se vuelve a solicitar el nombre
                }
            }
        }

        public static void ModificarUniverso()
        {
            int? opcionUniverso = null; //Variable para elegir universo a eliminar
            int totalUniversos = Principal.planetasStarWars.Count;//Total de universos
            string _nomUniverso = null;

            if (totalUniversos > 0)
            { //Si hay por lo menos un universo
                ModulosDeAyuda.MandarMensaje(36, 20, "      ELIJA UN UNIVERSO A MODIFICAR [ ]      ");
                try
                {//Si hay un error se maneja a este nivel para recapturar
                    opcionUniverso = ModulosDeAyuda.ElegirOpcion(75, 22, 1, totalUniversos);//Se elige universo
                    _nomUniverso = Principal.planetasStarWars[(Int32)opcionUniverso - 1].NombreUniverso;//Obtenemos su nombre
                    Etiquetas.EtiquetasCatálogoPlanetas(10, 9, _nomUniverso);//Etiquetas para los datos de los planetas
                    Etiquetas.EtiquetasAccionEnPlanetas(57, 9);//Botones para la acción
                    VerPlanetas(opcionUniverso);//Muestra los planetas del universo elegido
                }
                catch (Exception e)
                {   //Se invoca método para controlar los errores
                    Principal.ControlarExcepciones(e);//Se envía por parámetro el error
                    ModificarUniverso();//Después de indicar el error, se vuelve al menú principal
                }
            }
            else
            {//Si no hay universos
                throw new GestionDeErroresPropiosException("¡  NO HAY UNIVERSOS PARA MODIFICAR  !");
            }
        }

        public static void EliminarUniverso()
        {
            int? opcionUniverso = null; //Variable para elegir universo a eliminar
            int totalUniversos = Principal.planetasStarWars.Count;//Total de universos
            string confirmacionEliminar = null;//Confirmación de eliminación

            if (totalUniversos > 0)
            { //Si hay por lo menos un universo
                ModulosDeAyuda.MandarMensaje(36, 20, "      ELIJA EL UNIVERSO A ELIMINAR [ ]      ");
                try
                {//Si hay un error se maneja a este nivel para recapturar
                    opcionUniverso = ModulosDeAyuda.ElegirOpcion(74, 22, 1, totalUniversos);//Se elige universo
                    ProcederSioNo();

                    void ProcederSioNo()
                    {
                        try
                        {  //Aseguramos que en verdad quieren eliminar el universo
                            ModulosDeAyuda.MandarMensaje(38, 22, "        ¿ESTÁ SEGURO DE PROCEDER [ ]        ");
                            ModulosDeAyuda.MandarMensaje(38, 23, "               [S]i    [N]o                 ");
                            confirmacionEliminar = ModulosDeAyuda.PreguntarSiONo(74, 24);//Solicitamos Si o No

                            if (confirmacionEliminar.ToLower().Equals("s"))//Si a eliminar
                            {
                                Principal.planetasStarWars.RemoveAt((Int32)opcionUniverso - 1);
                                ModulosDeAyuda.MandarMensaje(38, 25, "          ¡UNIVERSO ELIMINADO!              ");
                            }
                        }
                        catch (Exception e)
                        {   //Se invoca método para controlar los errores
                            Principal.ControlarExcepciones(e);//Se envía por parámetro el error
                            ProcederSioNo();//Después de indicar el error, se vuelve al menú principal
                        }
                    }
                }
                catch (Exception e)
                {   //Se invoca método para controlar los errores
                    Principal.ControlarExcepciones(e);//Se envía por parámetro el error
                    EliminarUniverso();//Después de indicar el error, se vuelve al menú principal
                }
            }
            else
            {//Si no hay universos
                throw new GestionDeErroresPropiosException("¡  NO HAY UNIVERSOS PARA ELIMINAR  !");
            }
        }

        public static void VerPlanetas(int? opcionUniverso)
        {
            string _planeta = null;//almacena el nombre del planeta
            long _rotacion = 0;//almacena periodo de rotación del planeta
            long _orbita = 0;//almacena periodo de órbita del planeta

            int? totalPlanetas = null;
            totalPlanetas = Principal.planetasStarWars[(Int32)opcionUniverso - 1].planetas.Count;

            if (totalPlanetas == 0)//Si no hay planeta
            {
                ModulosDeAyuda.MandarMensaje(15, 13, "¡NO HAY PLANETAS PARA MOSTRAR!");
                ModulosDeAyuda.MandarMensaje(15, 14, "    ¡EMPIECE CREANDO UNO!    ");
            }
            else//Si hay por lo menos un planeta
            {
                for (int j = 0; j <= totalPlanetas - 1; j++)//Recorremos todos los universos de la lista
                {
                    //Guardamos el nombre y ponemos en mayusculas primeras letras
                    _planeta = Principal.planetasStarWars[(Int32)opcionUniverso - 1].planetas[j].Name;
                    _planeta = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(_planeta));
                    //Guardamos periodo de rotación y ponemos en mayusculas primeras letras
                    _rotacion = Principal.planetasStarWars[(Int32)opcionUniverso - 1].planetas[j].RotationPeriod;
                    //Guardamos periodo de órbita y ponemos en mayusculas primeras letras
                    _orbita = Principal.planetasStarWars[(Int32)opcionUniverso - 1].planetas[j].OrbitalPeriod;

                    //Imprimimos en pantalla
                    Console.SetCursorPosition(13, 14 + j);//Nombre
                    Console.WriteLine(j + 1 + ". " + _planeta);

                    Console.SetCursorPosition(33, 14 + j);//Rotación
                    Console.WriteLine(_rotacion);

                    Console.SetCursorPosition(44, 14 + j);//Órbita
                    Console.WriteLine(_orbita);
                }
            }
            SeleccionarAccion();//Llamamos las acciones

            void SeleccionarAccion()//Método para pedir la acción a realizar sobre los planetas
            {
                Byte? opcionAccion = null;
                bool salir = false;

                try//Capturar error al nivel más próximo
                {
                    ModulosDeAyuda.MandarMensaje(56, 20, "SELECCIONE UNA ACCIÓN  [ ]");//Etiqueta
                    opcionAccion = ModulosDeAyuda.ElegirOpcion(82, 22, 1, 5);//Ingresa número de la acción

                    string _nomUniverso = null;//Se guarda el nombre del universo actual
                    _nomUniverso = Principal.planetasStarWars[(Int32)opcionUniverso - 1].NombreUniverso;

                    int totalUniversos = 0;//Total de universos
                    int _universoActual = 0;//Universo actual

                    totalUniversos = Principal.planetasStarWars.Count;
                    _universoActual = (Int32)opcionUniverso - 1;

                    //MENÚ CRUD PLANETAS
                    //Hay o no planetas y se seleccionó Crear 
                    if (totalPlanetas >= 0 && opcionAccion == 1)
                    {
                        CrearPlanetas(_nomUniverso, totalUniversos, 51, 13, true, _universoActual, "INGRESE LOS PLANETAS DE", false, -1);//Método para crear los planetas
                    }
                    else
                    {   //Hay planetas y se seleccionó Modificar
                        if (totalPlanetas > 0 && opcionAccion == 2)
                        {
                            ModificarPlanetas(_universoActual);//Método para modificar los planetas
                        }
                        else
                        {   //Hay planetas y se seleccionó Destruir
                            if (totalPlanetas > 0 && opcionAccion == 3)
                            {
                                DestruirPlanetas(_universoActual);//Método para destruir los planetas
                            }
                            else
                            {   //Hay planetas y se seleccionó Transferir
                                if (totalPlanetas > 0 && opcionAccion == 4)
                                {
                                    if (totalUniversos > 1)
                                    {//Si hay más de un universo
                                        TransferirPlanetas(_universoActual);
                                    }
                                    else//Si solo hay un universo no se puede hacer la transferencia
                                    {
                                        ModulosDeAyuda.MandarMensaje(56, 22, "SÓLO HAY UN UNIVERSO, TRANSFERENCIA IMPOSIBLE");
                                        Console.ReadKey();
                                    }
                                }
                                else
                                {   //Se optó por salir
                                    if (opcionAccion == 5)
                                    {
                                        salir = true;
                                    }
                                    else//No hay planetas y se optó por modificar, destruir o transferir
                                    {
                                        ModulosDeAyuda.MandarMensaje(56, 18, "ACCIÓN IMPOSIBLE, CAPTURE PRIMERO PLANETAS", true);
                                        SeleccionarAccion();
                                    }
                                }

                            }
                        }
                    }

                    if (!salir)//Vuelve a mostrar los planetas y sus acciones
                    {
                        Etiquetas.EtiquetasCatálogoPlanetas(10, 9, _nomUniverso);//Etiquetas para los datos de los planetas
                        Etiquetas.EtiquetasAccionEnPlanetas(57, 9);//Botones para la acción
                        VerPlanetas(opcionUniverso);//Muestra los planetas del universo elegido
                    }

                }
                catch (Exception e)
                {   //Se invoca método para controlar los errores
                    Principal.ControlarExcepciones(e);//Se envía por parámetro el error
                    SeleccionarAccion();//Después de indicar el error, se retoma la acción última
                }
            }
        }

        public static void CrearPlanetas(string _universo, int _numUniversos, int X, int Y, bool limpiar, int _univActual, string mensaje, bool modificar, int planAct)
        {//Método para crear planetas
            if (limpiar == true)
            {//Si deseamos limpiar la pantalla y dejar solo la captura
                Etiquetas.DibujaTitulo();
            }

            Etiquetas.EtiquetasIngresarPlanetas(X - 23, Y - 3, _universo, mensaje);//Etiquetas

            SolicitarPlanetas();

            void SolicitarPlanetas()//Método que solicita, captura y valida planetas
            {
                string agregarOtroPlaneta = null;//Continuidad de captura de planetas
                string _planeta = null;//Variable para el nombre del planeta
                long _orbital = 0;//Su periodo de orbita
                long _rotacion = 0;//Su periodo de rotación

                do//Capturar planetas mientras se elija SI
                {
                    CapturarNombreDePlaneta();//Capturar nombre del planeta
                    CapturarPeriodoOrbitalDePlaneta();//Periodo de órbita
                    CapturarPeriodoDeRotacionDePlaneta();//Periodo de rotación
                    AgregarDatosAlPlaneta();//Se agregan los datos a la lista 82,19

                    if (!modificar)//Si es una modificación al planeta, se omite
                    {
                        ModulosDeAyuda.MandarMensaje(X + 21, Y - 4, "      ¡PLANETA GUARDADO!     ");//Mensaje todo OK
                        ModulosDeAyuda.MandarMensaje(X + 21, Y - 2, "  ¿Agregar otro Planeta? [ ] ");//82,21
                        ModulosDeAyuda.MandarMensaje(X + 21, Y - 1, "          [S]i  [N]o         ");//82,22
                        agregarOtroPlaneta = ModulosDeAyuda.PreguntarSiONo(X + 49, Y);//Solicitamos Si o No 110,23
                    }
                    else
                    {
                        agregarOtroPlaneta = "n";
                    }

                    if (agregarOtroPlaneta.ToLower().Equals("s"))//Evaluamos: Si-Repetir la captura
                    {
                        Etiquetas.EtiquetasIngresarPlanetas(X - 23, Y - 3, _universo, mensaje);//Etiquetas
                    }
                } while (agregarOtroPlaneta.ToLower().Equals("s"));//Condicional mientras sea [S]i

                void CapturarNombreDePlaneta()
                {
                    try
                    {
                        Console.SetCursorPosition(X, Y);
                        Console.WriteLine("                ");//Se limpia el espacio

                        Console.SetCursorPosition(X, Y);
                        _planeta = Console.ReadLine().ToLower();//Se captura el  nombre

                        //Checamos si ya existe ese planeta
                        bool existe = Principal.planetasStarWars[_univActual].planetas.Exists(elemento => elemento.Name.Equals(_planeta));

                        if (existe)
                        {//Si existe uno se pide otro nombre
                            throw new GestionDeErroresPropiosException("¡ESE PLANETA YA EXISTE, INGRESE OTRO NOMBRE!");
                        }
                        else
                        {
                            if (_planeta.Equals(""))
                            {
                                throw new GestionDeErroresPropiosException("       ¡EL NOMBRE NO PUEDE IR VACÍO!        ");
                            }

                        }

                    }
                    catch (Exception e)
                    {   //Se invoca método para controlar los errores
                        Principal.ControlarExcepciones(e);//Se envía por parámetro el error
                        CapturarNombreDePlaneta();//Se vuelve a solicitar el nombre
                    }
                }

                void CapturarPeriodoOrbitalDePlaneta()
                {
                    try
                    {
                        Console.SetCursorPosition(X, Y + 1);
                        Console.WriteLine("                ");//Se limpia el espacio

                        Console.SetCursorPosition(X, Y + 1);
                        _orbital = Convert.ToInt64(Console.ReadLine());//Se captura periodo orbital
                    }
                    catch (Exception e)
                    {   //Se invoca método para controlar los errores
                        Principal.ControlarExcepciones(e);//Se envía por parámetro el error
                        CapturarPeriodoOrbitalDePlaneta();//Se vuelve a solicitar el nombre
                    }
                }

                void CapturarPeriodoDeRotacionDePlaneta()
                {
                    try
                    {                           //61,25
                        Console.SetCursorPosition(X, Y + 2);
                        Console.WriteLine("                ");//Se limpia el espacio

                        Console.SetCursorPosition(X, Y + 2);
                        _rotacion = Convert.ToInt64(Console.ReadLine());//Se captura periodo rotación

                        if (_rotacion > _orbital && _rotacion < 1)
                        {
                            //se lanza una excepción propia
                            throw new GestionDeErroresPropiosException("EL PERIODO DE ROTACIÓN DEBE SER MENOR AL ORBITAL Y MAYOR A 1");
                        }
                        else
                        {
                            if (_rotacion > _orbital)
                            {
                                //se lanza una excepción propia
                                throw new GestionDeErroresPropiosException("EL PERIODO DE ROTACIÓN DEBE SER MENOR AL ORBITAL");
                            }
                            else
                            {
                                if (_rotacion < 1)
                                {
                                    //se lanza una excepción propia
                                    throw new GestionDeErroresPropiosException("EL PERIODO DE ROTACIÓN DEBE SER MAYOR A 1");
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {   //Se invoca método para controlar los errores
                        Principal.ControlarExcepciones(e);//Se envía por parámetro el error
                        CapturarPeriodoDeRotacionDePlaneta();//Se vuelve a solicitar el nombre
                    }
                }

                void AgregarDatosAlPlaneta()//Método para agregar los datos del planeta en la
                {//lista de planetas
                    if (!modificar)//Si es nuevo planeta y no una modificación, entonces se crea
                    {
                        Principal.planetasStarWars[_univActual].planetas.Add(//Al último universo
                            new Planeta //se agrega el planeta
                            {
                                Name = _planeta,//Datos del planeta
                                OrbitalPeriod = _orbital,
                                RotationPeriod = _rotacion,
                            });
                    }
                    else//Si es modificación a un planeta existente
                    {
                        Principal.planetasStarWars[_univActual].planetas[planAct].Name = _planeta;
                        Principal.planetasStarWars[_univActual].planetas[planAct].OrbitalPeriod = _orbital;
                        Principal.planetasStarWars[_univActual].planetas[planAct].RotationPeriod = _rotacion;
                    }
                }
            }
        }

        public static void ModificarPlanetas(int? _universoActual)//Método para modificar los datos de un planeta
        {
            Byte? opcionPlaneta = null;//Planeta elegido

            int? totalPlanetas = null;//Total de planetas del universo
            totalPlanetas = Principal.planetasStarWars[(Int32)_universoActual].planetas.Count;

            int? totalUniversos = null;//Total de planetas del universo
            totalUniversos = Principal.planetasStarWars.Count;

            string _nomPlaneta = null;//Nombre del planeta
            long _rotacion = 0;
            long _orbita = 0;

            string _nomUniverso = null;//Nombre del universo
            _nomUniverso = Principal.planetasStarWars[(Int32)_universoActual].NombreUniverso;

            try//Capturar error al nivel más próximo
            {
                ModulosDeAyuda.MandarMensaje(56, 22, "SELECCIONE UN PLANETA  [ ]");//Etiqueta
                opcionPlaneta = ModulosDeAyuda.ElegirOpcion(82, 24, 1, (Int32)totalPlanetas);//Ingresa número de la acción

                _nomPlaneta = Principal.planetasStarWars[(Int32)_universoActual].planetas[(Int32)opcionPlaneta - 1].Name;
                _rotacion = Principal.planetasStarWars[(Int32)_universoActual].planetas[(Int32)opcionPlaneta - 1].RotationPeriod;
                _orbita = Principal.planetasStarWars[(Int32)_universoActual].planetas[(Int32)opcionPlaneta - 1].OrbitalPeriod;

                Etiquetas.EtiquetasModificarPlanetas(38, 9, _nomPlaneta, _rotacion, _orbita);
                //Método para crear/modificar los planetas
                CrearPlanetas(_nomUniverso, (Int32)totalUniversos, 61, 20, false, (Int32)_universoActual, "NUEVOS DATOS DEL PLANETA EN", true, (Int32)opcionPlaneta - 1);
                ModulosDeAyuda.MandarMensaje(43, 24, "      ¡PLANETA GUARDADO!     ");//Mensaje todo OK
                Console.ReadKey();
            }
            catch (Exception e)
            {   //Se invoca método para controlar los errores
                Principal.ControlarExcepciones(e);//Se envía por parámetro el error
                ModificarPlanetas(_universoActual);//Después de indicar el error, se retoma la acción última
            }
        }

        public static void DestruirPlanetas(int? _universoActual)
        {
            Byte? opcionPlaneta = null;//Planeta elegido
            int? totalPlanetas = null;

            totalPlanetas = Principal.planetasStarWars[(Int32)_universoActual].planetas.Count;

            string confirmacionEliminar = null;//Confirmación de eliminación

            try
            {
                ModulosDeAyuda.MandarMensaje(56, 22, "SELECCIONE UN PLANETA  [ ]");//Etiqueta
                opcionPlaneta = ModulosDeAyuda.ElegirOpcion(82, 24, 1, (Int32)totalPlanetas);//Ingresa número de la acción

                ProcederSioNo();//Proceder a la eliminación

                void ProcederSioNo()
                {
                    try
                    {  //Aseguramos que en verdad quieren eliminar el planeta
                        ModulosDeAyuda.MandarMensaje(47, 24, "        ¿ESTÁ SEGURO DE PROCEDER [ ]        ");
                        ModulosDeAyuda.MandarMensaje(47, 25, "               [S]i    [N]o                 ");
                        confirmacionEliminar = ModulosDeAyuda.PreguntarSiONo(83, 26);//Solicitamos Si o No

                        if (confirmacionEliminar.ToLower().Equals("s"))//Si a eliminar
                        {
                            Principal.planetasStarWars[(Int32)_universoActual].planetas.RemoveAt((Int32)opcionPlaneta - 1);
                            ModulosDeAyuda.MandarMensaje(20, 26, "¡PLANETA ELIMINADO!");
                            Console.ReadKey();
                        }
                    }
                    catch (Exception e)
                    {   //Se invoca método para controlar los errores
                        Principal.ControlarExcepciones(e);//Se envía por parámetro el error
                        ProcederSioNo();//Después de indicar el error, se vuelve al menú principal
                    }
                }

            }
            catch (Exception e)
            {   //Se invoca método para controlar los errores
                Principal.ControlarExcepciones(e);//Se envía por parámetro el error
                DestruirPlanetas(_universoActual);//Después de indicar el error, se retoma la acción última
            }
        }

        public static void TransferirPlanetas(int? _universoActual)
        {
            Byte? opcionPlaneta = null;//Planeta elegido
            Byte? universoDestino = null;//Destino del planeta

            int? totalPlanetas = null;
            int? totalUniversos = null;

            string nomPlaneta = null;

            totalPlanetas = Principal.planetasStarWars[(Int32)_universoActual].planetas.Count;
            totalUniversos = Principal.planetasStarWars.Count;

            string confirmacionTransferir = null;//Confirmación de eliminación

            try
            {
                ModulosDeAyuda.MandarMensaje(56, 22, "SELECCIONE UN PLANETA: [ ]");//Etiqueta
                opcionPlaneta = ModulosDeAyuda.ElegirOpcion(82, 24, 1, (Int32)totalPlanetas);

                nomPlaneta = Principal.planetasStarWars[(Int32)_universoActual].planetas[(Int32)opcionPlaneta - 1].Name;

                SeleccionarUniverso();

                void SeleccionarUniverso()
                {
                    Etiquetas.EtiquetasCatálogoUniverso(20, 9);//Imprimimos etiquetas
                    Universo.VerUniversos(20, 9, true, (Int32)_universoActual);//Mostramos los universos que hay

                    try
                    {
                        ModulosDeAyuda.MandarMensaje(65, 11, "EL UNIVERSO DESTINO ES [ ]");//Etiqueta
                        universoDestino = ModulosDeAyuda.ElegirOpcion(91, 13, 1, (Int32)totalUniversos);

                        if (universoDestino == _universoActual + 1)
                        {//No se puede enviar al mismo destino
                            throw new GestionDeErroresPropiosException("            ¡OPCIÓN NO VÁLIDA!");
                        }
                    }
                    catch (Exception e)
                    {   //Se invoca método para controlar los errores
                        Principal.ControlarExcepciones(e);//Se envía por parámetro el error
                        SeleccionarUniverso();//indica el error
                    }
                }

                ProcederSioNo();//Proceder a la eliminación

                void ProcederSioNo()
                {
                    try
                    {  //Aseguramos que en verdad quieren transferir el planeta
                        ModulosDeAyuda.MandarMensaje(65, 13, "¿ESTÁ SEGURO DE PROCEDER [ ]        ");
                        ModulosDeAyuda.MandarMensaje(65, 14, "       [S]i    [N]o                 ");
                        confirmacionTransferir = ModulosDeAyuda.PreguntarSiONo(65 + 27, 15);//Solicitamos Si o No

                        if (confirmacionTransferir.ToLower().Equals("s"))//Si a transferir
                        {
                            //Checamos si ya existe ese planeta
                            bool existe = Principal.planetasStarWars[(Int32)universoDestino - 1].planetas.Exists(elemento => elemento.Name.Equals(nomPlaneta.ToLower()));

                            if (existe)//si ya existe un planeta con ese nombre
                            {
                                ModulosDeAyuda.MandarMensaje(65, 16, "YA EXISTE UN PLANETA CON ESE NOMBRE.");
                                ModulosDeAyuda.MandarMensaje(65, 17, " ELIJA OTRO DESTINO U OTRO PLANETA.");
                            }
                            else//Si no existe, entonces se transfiere
                            {
                                //Primero transferimos el planeta a su universo destino
                                Principal.planetasStarWars[(Int32)universoDestino - 1].planetas.Add(
                                    new Planeta //se agrega el planeta
                                    {
                                        Name = Principal.planetasStarWars[(Int32)_universoActual].planetas[(Int32)opcionPlaneta-1].Name,
                                        OrbitalPeriod = Principal.planetasStarWars[(Int32)_universoActual].planetas[(Int32)opcionPlaneta-1].OrbitalPeriod,
                                        RotationPeriod = Principal.planetasStarWars[(Int32)_universoActual].planetas[(Int32)opcionPlaneta-1].RotationPeriod,
                                    });

                                //Después eliminamos el planeta de su universo origen
                                Principal.planetasStarWars[(Int32)_universoActual].planetas.RemoveAt((Int32)opcionPlaneta - 1);
                                ModulosDeAyuda.MandarMensaje(20, 24, "¡PLANETA TRANSFERIDO Y ELIMINADO!");

                                Console.ReadKey();
                            }
                        }
                        Console.ReadKey();

                    }
                    catch (Exception e)
                    {   //Se invoca método para controlar los errores
                        Principal.ControlarExcepciones(e);//Se envía por parámetro el error
                        ProcederSioNo();
                    }
                }

            }
            catch (Exception e)
            {   //Se invoca método para controlar los errores
                Principal.ControlarExcepciones(e);//Se envía por parámetro el error
                TransferirPlanetas(_universoActual);
            }
        }
    }

    //SEGUNDA PARTE DE LA CLASE PARCIAL Planeta PARA 
    //AGREGAR: CONSTRUCTOR DE LA CLASE Y SUS MÉTODOS 
    public partial class Planeta
    {

        //Constructor sin parámetros
        public Planeta()
        { }
    }
}