using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFArbolBinario
{
    class Estudiante2 : Comparador
    {
        int Carne { get; set; }
        String Nombre { get; set; }

        public Estudiante2(int carne, String nombre)
        {
            Carne = carne;
            Nombre = nombre;
        }

        bool Comparador.igualQue(Object op2)
        {
            Estudiante2 p2 = (Estudiante2)op2;
            return Carne == p2.Carne;
        }

        bool Comparador.menorQue(Object op2)
        {
            Estudiante2 p2 = (Estudiante2)op2;
            return Carne < p2.Carne;
        }

        bool Comparador.menorIgualQue(Object op2)
        {
            Estudiante2 p2 = (Estudiante2)op2;
            return Carne <= p2.Carne;
        }

        bool Comparador.mayorQue(Object op2)
        {
            Estudiante2 p2 = (Estudiante2)op2;
            return Carne > p2.Carne;
        }

        bool Comparador.mayorIgualQue(Object op2)
        {
            Estudiante2 p2 = (Estudiante2)op2;
            return Carne > p2.Carne;
        }

        public override string ToString()
        {
            return "(" + Carne + " - " + Nombre + ")";
        }
    }

}
