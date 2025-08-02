using EXAMEN.BaseDatos;
using EXAMEN.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BaseDeDatos.CargarDatosAereopuerto();
            BaseDeDatos.CargarDatosAvion();
            Console.Title = "Sistema de Gestion de Aeropuertos y Aviones";
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine("Bienvenido al sistema de gestion de Aeropuertos y Aviones");
                Console.WriteLine("1. Agregar Avion");
                Console.WriteLine("2. Eliminar Avion");
                Console.WriteLine("3. Listar Aviones");
                Console.WriteLine("4. Modificar Avion");
                Console.WriteLine("5. Consultar Avion por ID");
                Console.WriteLine("6. Agregar Aereopuerto");
                Console.WriteLine("7. Eliminar Aereopuerto");
                Console.WriteLine("8. Listar Aereopuertos");
                Console.WriteLine("9. Modificar Aereopuerto");
                Console.WriteLine("10. Consultar Aereopuerto por ID");
                Console.WriteLine("0. Salir");
                Console.WriteLine("------------------------------------------------------------------");
                Console.ResetColor();
                Console.Write("Seleccione una opcion: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarAvion();
                        BaseDeDatos.guardardatosenarchivoavion();
                        break;
                    case "2":
                        EliminarAvion();
                        BaseDeDatos.guardardatosenarchivoavion();
                        break;
                    case "3":
                        ListarAviones();
                        break;
                    case "4":
                        modificaravion();
                        BaseDeDatos.guardardatosenarchivoavion();
                        break;
                    case "5":
                        consultaravionporid();
                        break;
                    case "6":
                        AgregarAereopuerto();
                        BaseDeDatos.guardardatosenarchivoaereopuerto();
                        break;
                    case "7":
                        EliminarAereopuerto();
                        BaseDeDatos.guardardatosenarchivoaereopuerto();
                        break;
                    case "8":
                        ListarAereopuertos();
                        break;
                    case "9":
                        modificaraereopuerto();
                        BaseDeDatos.guardardatosenarchivoaereopuerto();
                        break;
                    case "10":
                        consultaraereopuertoporid();
                        break;
                    case "0":
                        Console.WriteLine("Saliendo del sistema...");
                        return;
                    default:
                        Console.WriteLine("Opcion no valida, intente de nuevo.");
                        break;
                }


            }
        }

        private static void consultaraereopuertoporid()
        {
            Console.Clear();
            Console.WriteLine("Consulta de Aereopuerto por ID");
            Console.WriteLine("Ingrese el ID del aereopuerto a consultar:");
            int id = Convert.ToInt32(Console.ReadLine());
            Aereopuerto objAereopuertoConsultado = BaseDeDatos.GetAereopuertoxid(id);
            if (objAereopuertoConsultado == null)
            {
                Console.WriteLine("No se encontro un aereopuerto con ese ID.");
            }
            else
            {
                objAereopuertoConsultado.Imprimir();
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        private static void consultaravionporid()
        {
            Console.Clear();
            Console.WriteLine("Consulta de Avion por ID");
            Console.WriteLine("Ingrese el ID del avion a consultar:");
            int id = Convert.ToInt32(Console.ReadLine());
            Avion objAvionConsultado = BaseDeDatos.GetAvionxid(id);
            if (objAvionConsultado == null)
            {
                Console.WriteLine("No se encontro un avion con ese ID.");
            }
            else
            {
                objAvionConsultado.Imprimir();
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        private static void modificaraereopuerto()
        {
            Console.Clear();
            Console.WriteLine("Actualización de datos de Aereopuerto");
            Console.WriteLine("Ingrese el id del aereopuerto a modificar:");
            int id = Convert.ToInt32(Console.ReadLine());
            Aereopuerto objAereopuertoConsultado = BaseDeDatos.GetAereopuertoxid(id);
            if (objAereopuertoConsultado == null)
            {
                Console.WriteLine("Aereopuerto no encontrado");
            }
            else
            {
                objAereopuertoConsultado.Imprimir();
                Console.WriteLine("Ingrese el nuevo nombre de la empresa:");
                string nuevaEmpresa = Console.ReadLine();
                objAereopuertoConsultado.SetEmpresa(nuevaEmpresa);
                Console.WriteLine("Ingrese la nueva ciudad del aereopuerto:");
                string nuevaCiudad = Console.ReadLine();
                objAereopuertoConsultado.SetCiudad(nuevaCiudad);
                Console.WriteLine("Ingrese la nueva cantidad de puertas:");
                int nuevaCantidadPuerta;
                while (!int.TryParse(Console.ReadLine(), out nuevaCantidadPuerta) || nuevaCantidadPuerta <= 0)
                {
                    Console.WriteLine("Cantidad invalida, por favor ingrese un numero positivo.");
                }
                objAereopuertoConsultado.SetCantidadPuerta(nuevaCantidadPuerta);
                Console.WriteLine("Ingrese el nuevo pais del aereopuerto:");
                string nuevoPais = Console.ReadLine();
                objAereopuertoConsultado.SetPais(nuevoPais);
                Console.WriteLine("Datos del aereopuerto actualizados exitosamente.");
            }
        }

        private static void ListarAereopuertos()
        {
            BaseDeDatos.ListarAereopuertos();
            Console.ReadLine();
        }


        private static void EliminarAereopuerto()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el id del aereopuerto a eliminar:");
            int id = Convert.ToInt32(Console.ReadLine());

            Aereopuerto objAereopuertoConsultado = BaseDeDatos.GetAereopuertoxid(id);
            if (objAereopuertoConsultado == null)
            {
                Console.WriteLine("No se encontro un aereopuerto con ese codigo.");

            }
            else
            {
                Console.Write("¿Esta seguro que desea eliminar los datos de este aereopuerto? (S/N): ");
                string confirmacion = Console.ReadLine().ToUpper();
                if (confirmacion == "S")
                {
                    BaseDatos.BaseDeDatos.BaseDeDatosAereopuerto.Remove(objAereopuertoConsultado);
                    Console.WriteLine("Avion eliminado exitosamente.");
                }
            }
            Console.ReadLine();
        }

        //CREATE
        private static void AgregarAereopuerto()
        {
            Console.Clear();
            string empresa;
            string ciudad;
            int cantidad_puerta;
            string pais;
            Console.WriteLine("Ingrese el nombre de la empresa:");
            empresa = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Ingrese la ciudad del aereopuerto:");
            ciudad = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Ingrese la cantidad de puertas:");
            while (!int.TryParse(Console.ReadLine(), out cantidad_puerta) || cantidad_puerta <= 0)
            {
                Console.WriteLine("Cantidad invalida, por favor ingrese un numero positivo.");
            }
            Console.WriteLine();
            Console.WriteLine("Ingrese el pais del aereopuerto:");
            pais = Console.ReadLine();
            Console.WriteLine();
            Aereopuerto objAereopuerto = new Aereopuerto(empresa, ciudad, cantidad_puerta, pais);
            Console.WriteLine("Aereopuerto agregado exitosamente.");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        /// <summary>
        /// ///////////////////////////////////////////////////
        /// </summary>


        //DELETE
        private static void EliminarAvion()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el id del avion a eliminar:");
            int id = Convert.ToInt32(Console.ReadLine());
            Avion objAvionconsultado = BaseDeDatos.GetAvionxid(id);

            if (objAvionconsultado == null)
            {
                Console.WriteLine("No se encontro un avion con ese id.");

            }
            else
            {
                Console.Write("¿Esta seguro que desea eliminar los datos de este avion? (S/N): ");
                string confirmacion = Console.ReadLine().ToUpper();
                if (confirmacion == "S")
                {
                    BaseDatos.BaseDeDatos.BaseDeDatosAvion.Remove(objAvionconsultado);
                    Console.WriteLine("Avion eliminado exitosamente.");
                }
            }
            Console.ReadLine();
        }
        //UPDATE
        private static void modificaravion()
        {
            Console.Clear();
            Console.WriteLine("Actualización de datos de Avion");
            Console.WriteLine("Ingrese el id del avion a modificar:");
            int id = Convert.ToInt32(Console.ReadLine());

            Avion objAvionConsultado = BaseDeDatos.GetAvionxid(id);
            if (objAvionConsultado == null)
            {
                Console.WriteLine("No se encontro un avion con ese id.");
            }
            else
            {
                objAvionConsultado.Imprimir();
                Console.WriteLine("Ingrese el nuevo numero de vuelo:");
                string nuevoNumeroVuelo = Console.ReadLine();
                objAvionConsultado.SetNumeroVuelo(nuevoNumeroVuelo);
                Console.WriteLine("Ingrese el nuevo origen del vuelo:");
                string nuevoOrigen = Console.ReadLine();
                objAvionConsultado.SetOrigen(nuevoOrigen);
                Console.WriteLine("Ingrese el nuevo destino del vuelo:");
                string nuevoDestino = Console.ReadLine();
                objAvionConsultado.SetDestino(nuevoDestino);
                Console.WriteLine("Ingrese la nueva capacidad de pasajeros:");
                int nuevacapacidad;
                while (!int.TryParse(Console.ReadLine(), out nuevacapacidad) || nuevacapacidad <= 0)
                {
                    Console.WriteLine("Capacidad invalida, por favor ingrese un numero positivo.");
                }
                objAvionConsultado.SetCapacidadPasajero(nuevacapacidad);
                Console.WriteLine("Ingrese el nuevo modelo del avion:");
                string nuevoModelo = Console.ReadLine();
                objAvionConsultado.SetModelo(nuevoModelo);
                Console.WriteLine("Datos del avion actualizados exitosamente.");
            }
        }
        //READ
        private static void ListarAviones()
        {

            BaseDeDatos.ListarAviones();
            Console.ReadLine();
        }
        //CREATE
        private static void AgregarAvion()
        {
            Console.Clear();
            string numerovuelo;
            string origen;
            string destino;
            string modelo;
            int capacidad_pasajero;

            Console.WriteLine("Ingrese el numero de vuelo:");
            numerovuelo = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Ingrese el origen del vuelo:");
            origen = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Ingrese el destino del vuelo:");
            destino = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Ingrese la capacidad de pasajeros:");
            capacidad_pasajero = 0;
            Console.WriteLine();

            Console.WriteLine("Ingrese el modelo del avion:");
            modelo = Console.ReadLine();
            Console.WriteLine();

            Avion OBJAvion = new Avion(numerovuelo, origen, destino, capacidad_pasajero, modelo);
            Console.WriteLine("Avion agregado exitosamente.");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
        }
    }

}
