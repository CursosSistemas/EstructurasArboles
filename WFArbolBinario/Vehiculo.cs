using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFArbolBinario
{
    public class Vehiculo:Comparador
    {
        String placa { get; set; }
        int modelo { get; set; }
        String marca { get; set; }

        public Vehiculo(String pPlaca, int pModelo, String pMarca)
        {
            placa = pPlaca;
            modelo = pModelo;
            marca = pMarca;
        }

        public Vehiculo(String pPlaca)
        {
            placa = pPlaca;
        }

        public bool igualQue(object q)
        {
            Vehiculo aux = (Vehiculo)q;
            return (placa == aux.placa);
        }

        public bool menorQue(object q)
        {
            Vehiculo aux = (Vehiculo)q;
            return (placa.CompareTo(aux.placa) < 0);
        }

        public bool menorIgualQue(object q)
        {
            throw new NotImplementedException();
        }

        public bool mayorQue(object q)
        {
            Vehiculo aux = (Vehiculo)q;
            return (placa.CompareTo(aux.placa) > 0);
        }

        public bool mayorIgualQue(object q)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return placa + " / " + marca + ", ";
        }
    }
}
