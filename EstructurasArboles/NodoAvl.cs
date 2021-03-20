using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasArboles
{

    class NodoAvl : Nodo
    {

        public int fe;
        public NodoAvl(Object valor):base(valor)
        {
            fe = 0;
        }

        public NodoAvl(Object valor, NodoAvl ramaIzdo, NodoAvl ramaDcho):base(ramaIzdo, valor, ramaDcho)
        {
            fe = 0;
        }
    }
}
