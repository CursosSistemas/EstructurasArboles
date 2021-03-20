using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasArboles
{
    class ArbolBinario
    {
        protected Nodo raiz;

        public ArbolBinario()
        {
            raiz = null;
        }

        public ArbolBinario(Nodo raiz)
        {
            this.raiz = raiz;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Nodo raizArbol()
        {
            return raiz;
        }

        /// <summary>
        /// Comprueba el estatus del árbol
        /// </summary>
        /// <returns></returns>
         bool esVacio()
        {
            return raiz == null;
        }

        public static Nodo nuevoArbol(Nodo ramaIzqda, Object dato, Nodo ramaDrcha)
        {
            return new Nodo(ramaIzqda, dato, ramaDrcha);
        }


        //binario en preorden
        public static string preorden(Nodo r)
        {
            if (r != null)
            {
                return r.visitar() + preorden (r.subarbolIzdo()) + 
                    preorden (r.subarbolDcho());
            }
            return "";
        } 
        
        // Recorrido de un árbol binario en inorden
        public static string inorden(Nodo r)
        {
            if (r != null)
            {
                return inorden (r.subarbolIzdo()) 
                    + r.visitar() + inorden (r.subarbolDcho());
            }
            return "";
        } 
        
        // Recorrido de un árbol binario en postorden
        public static string postorden(Nodo r)
        {
            if (r != null)
            {
                return postorden (r.subarbolIzdo()) + postorden (r.subarbolDcho()) + r.visitar();
            }
            return "";
        }

        //Devuelve el número de nodos que tiene el árbol
        public static int numNodos(Nodo raiz)
        {
            if (raiz == null)
                return 0;
            else
                return 1 + numNodos(raiz.subarbolIzdo()) +
                numNodos(raiz.subarbolDcho());
        }
    }
}
