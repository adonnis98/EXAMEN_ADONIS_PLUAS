using EXAMEN.Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN.BaseDatos
{
    public static  class BaseDeDatos
    {
        public static List<Clases.Avion> BaseDeDatosAvion = new List<Clases.Avion>();
        private static string nombreBaseDeDatosAvion = "Avion.dat";
        public static void guardardatosenarchivoavion()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream archivonuevo = new FileStream(nombreBaseDeDatosAvion, FileMode.Create);
            bf.Serialize(archivonuevo, BaseDeDatosAvion);
            archivonuevo.Close();
        }

        public static void CargarDatosAvion()
        {
            if (File.Exists(nombreBaseDeDatosAvion))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream archivoexistente = new FileStream(nombreBaseDeDatosAvion, FileMode.Open);
                BaseDeDatosAvion = (List<Clases.Avion>)bf.Deserialize(archivoexistente);
                archivoexistente.Close();
            }
        }


        public static Avion GetAvionxid(int id)
        {
            foreach (var avion in BaseDeDatosAvion)
            {
                if (avion.getid() == id)
                {
                    return avion;
                }
            }
            return null; 
        }
        public static void ListarAviones()
        {
            foreach (var avion in BaseDeDatosAvion)
            {
                avion.Imprimir();
                Console.WriteLine("-------------------------------");
            }
        }



        ////////////////////////////////////////////////////////////////////////////////

        public static List<Clases.Aereopuerto> BaseDeDatosAereopuerto = new List<Clases.Aereopuerto>();
        private static string nombreBaseDeDatosAereopuerto = "Aereopuerto.dat";
        public static void guardardatosenarchivoaereopuerto()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream archivonuevo = new FileStream(nombreBaseDeDatosAereopuerto, FileMode.Create);
            bf.Serialize(archivonuevo, BaseDeDatosAereopuerto);
            archivonuevo.Close();
        }
        public static void CargarDatosAereopuerto()
        {
            if (File.Exists(nombreBaseDeDatosAereopuerto))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream archivoexistente = new FileStream(nombreBaseDeDatosAereopuerto, FileMode.Open);
                BaseDeDatosAereopuerto = (List<Clases.Aereopuerto>)bf.Deserialize(archivoexistente);
                archivoexistente.Close();
            }
        }
        public static Aereopuerto GetAereopuertoxid(int id)
        {
            foreach (var Aereopuerto in BaseDeDatosAereopuerto)
            {
                if (Aereopuerto.getid() == id)
                {
                    return Aereopuerto;
                }
            }
            return null;
        }
        public static void ListarAereopuertos()
        {
            foreach (var Aereopuerto in BaseDeDatosAereopuerto)
            {
                Aereopuerto.Imprimir();
                Console.WriteLine("-------------------------------");
            }
        }

    }



}
