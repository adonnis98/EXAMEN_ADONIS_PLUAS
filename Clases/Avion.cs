using EXAMEN.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN.Clases
{
    [Serializable]
    public class Avion
    {
        private int id;
        private string codigo;
        private string numerovuelo;
        private string origen;
        private string destino;
        private int capacidad_pasajero;
        private string tipo_avion;
        private string modelo;
        private DateTime HoraSalida;
        private bool envuelo;


        public Avion(string numerovuelo, string origen, string destino, int capacidad_pasajero, string modelo)
        {
            this.id = BaseDeDatos.BaseDeDatosAvion.Count + 1;
            this.numerovuelo = numerovuelo;
            this.origen = origen;
            this.destino = destino;
            this.capacidad_pasajero = capacidad_pasajero;
            this.modelo = modelo;
            this.HoraSalida = DateTime.Now;
            this.envuelo = false;
            BaseDeDatos.BaseDeDatosAvion.Add(this);
        }

        public void Imprimir()
        {
            Console.WriteLine($"ID: " + this.id.ToString());
            Console.WriteLine($"Numero de Vuelo: " + this.numerovuelo);
            Console.WriteLine($"Origen: " + this.origen);
            Console.WriteLine($"Destino: " + this.destino);
            Console.WriteLine($"Capacidad de Pasajeros: " + this.capacidad_pasajero);
            Console.WriteLine($"Modelo: " + this.modelo);
            Console.WriteLine($"Hora de Salida: " + this.HoraSalida);
            Console.WriteLine($"En Vuelo: " + (this.envuelo ? "Si" : "No"));
        }

        public int getid()
        {
            return this.id;
        }

        public string SetNumeroVuelo(string par_numerovuelo) => this.numerovuelo = par_numerovuelo;
        public string SetOrigen(string par_origen) => this.origen = par_origen;
        public string SetDestino(string par_destino) => this.destino = par_destino;
        public int SetCapacidadPasajero(int par_capacidad_pasajero) => this.capacidad_pasajero = par_capacidad_pasajero;
        public string SetModelo(string par_modelo) => this.modelo = par_modelo;
        public DateTime getHoraSalida(DateTime par_hora_salida) => this.HoraSalida = par_hora_salida;
        public DateTime SetHoraSalida(DateTime par_hora_salida)
        {
            this.HoraSalida = par_hora_salida;
            return this.HoraSalida;
        }
        public bool SetEnVuelo(bool par_envuelo)
        {
            this.envuelo = par_envuelo;
            return this.envuelo;
        }
    }
}
