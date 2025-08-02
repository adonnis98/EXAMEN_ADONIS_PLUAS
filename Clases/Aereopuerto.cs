using EXAMEN.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN.Clases
{
    [Serializable]
    public class Aereopuerto
    {
        private int id;
        private string empresa;
        private string ciudad;
        private int cantidad_puerta;
        private int capacidad_teminales;
        private string pais;
        private DateTime UltimaRevision;

        public Aereopuerto(string empresa, string ciudad, int cantidad_puerta, string pais)
        {
            this.id = BaseDatos.BaseDeDatos.BaseDeDatosAereopuerto.Count + 1;
            this.empresa = empresa;
            this.ciudad = ciudad;
            this.cantidad_puerta = cantidad_puerta;
            this.pais = pais;
            this.capacidad_teminales = 1;
            this.UltimaRevision = DateTime.Now;
            BaseDeDatos.BaseDeDatosAereopuerto.Add(this);
        }

        public void Imprimir()
        {
            Console.WriteLine($"ID: " + this.id.ToString());
            Console.WriteLine($"Empresa: " + this.empresa);
            Console.WriteLine($"Ciudad: " + this.ciudad);
            Console.WriteLine($"Cantidad de Puertas: " + this.cantidad_puerta);
            Console.WriteLine($"Capacidad de Terminales: " + this.capacidad_teminales);
            Console.WriteLine($"Pais: " + this.pais);
            Console.WriteLine($"Ultima Revision: " + this.UltimaRevision);
        }

        public int getid()
        {
           return this.id;
        }
        public string SetEmpresa(string par_empresa) => this.empresa = par_empresa;
        public string SetCiudad(string par_ciudad) => this.ciudad = par_ciudad;
        public int SetCantidadPuerta(int par_cantidad_puerta) => this.cantidad_puerta = par_cantidad_puerta;
        public int getCapacidadTerminales(int par_capacidad_terminales) => this.capacidad_teminales = par_capacidad_terminales;
        public string SetPais(string par_pais) => this.pais = par_pais;
        public DateTime getUltimaRevision(DateTime par_ultima_revision) => this.UltimaRevision = par_ultima_revision;


    }
}
