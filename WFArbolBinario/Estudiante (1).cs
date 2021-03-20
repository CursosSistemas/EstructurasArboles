using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFArbolBinario
{
    class Estudiante : Comparador
    {
        int Carne { get; set; }
        String Nombre { get; set; }

        public Estudiante(int carne, String nombre)
        {
            Carne = carne;
            Nombre = nombre;
        }

        bool Comparador.igualQue(Object op2)
        {
            Estudiante p2 = (Estudiante)op2;
            return Carne == p2.Carne;
        }

        bool Comparador.menorQue(Object op2)
        {
            Estudiante p2 = (Estudiante)op2;
            //if (Nombre.CompareTo(p2.Nombre) < 0)
            //    return true;
            //else
            //    return false;
            return Carne < p2.Carne;
        }

        bool Comparador.menorIgualQue(Object op2)
        {
            Estudiante p2 = (Estudiante)op2;
            return Carne <= p2.Carne;
        }

        bool Comparador.mayorQue(Object op2)
        {
            Estudiante p2 = (Estudiante)op2;
            return Carne > p2.Carne;
        }

        bool Comparador.mayorIgualQue(Object op2)
        {
            Estudiante p2 = (Estudiante)op2;
            return Carne > p2.Carne;
        }

        public override string ToString()
        {
            return "(" + Carne + " - " + Nombre + ")";
        }
    }

}
