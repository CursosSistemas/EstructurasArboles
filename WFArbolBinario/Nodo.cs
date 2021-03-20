using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFArbolBinario
{
    
    class Nodo
    {
        protected Object dato;
        protected Nodo izdo;
        protected Nodo dcho;

        /// <summary>
        /// Método Constructor del nodo el cual recibe un valor y asign
        /// asigna nulos a los hijos
        /// </summary>
        /// <param name="valor">hhhhhhhhhhhhh</param>
        public Nodo(Object valor)
        {
            dato = valor;
            izdo = dcho = null;
        }

        public Nodo(Nodo ramaIzdo, Object valor, Nodo ramaDcho)
        {
            this.dato=valor;
            izdo = ramaIzdo;
            dcho = ramaDcho;
        }

        // operaciones de acceso
        public Object valorNodo()
        { 
            return dato;
        }

        public Nodo subarbolIzdo() { return izdo; }
        public Nodo subarbolDcho() { return dcho; }


        public void nuevoValor(Object d) 
        {
            dato = d; 
        }


        public void ramaIzdo(Nodo n) { izdo = n; }
        public void ramaDcho(Nodo n) { dcho = n; }
        public string visitar()
        {
            return dato.ToString();
        }

    }
}
