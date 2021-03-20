using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace EstructurasArboles
{
    class ArbolAVL
    {
        protected NodoAvl raiz;

        public ArbolAVL()
        {
            raiz = null;
        }

        public NodoAvl raizArbol()
        {
            return raiz;
        }



        private NodoAvl rotacionII(NodoAvl n, NodoAvl n1)
        {
            n.ramaIzdo(n1.subarbolDcho());
            n1.ramaDcho(n);
            // actualización de los factores de equilibrio
            if (n1.fe == -1) // se cumple en la inserción
            {
                n.fe = 0;
                n1.fe = 0;
            }
            else
            {
                n.fe = -1;
                n1.fe = 1;
            }
            return n1;
        }


        private NodoAvl rotacionDD(NodoAvl n, NodoAvl n1)
        {
            n.ramaDcho(n1.subarbolIzdo());
            n1.ramaIzdo(n);
            // actualización de los factores de equilibrio
            if (n1.fe == +1) // se cumple en la inserción
            {
                n.fe = 0;
                n1.fe = 0;
            }
            else
            {
                n.fe = +1;
                n1.fe = -1;
            }
            return n1;
        }


        private NodoAvl rotacionID(NodoAvl n, NodoAvl n1)
            {
            NodoAvl n2;
            n2 = (NodoAvl) n1.subarbolDcho();
            n.ramaIzdo(n2.subarbolDcho());
            n2.ramaDcho(n);
            n1.ramaDcho(n2.subarbolIzdo());
            n2.ramaIzdo(n1);
            // actualización de los factores de equilibrio
            if (n2.fe == +1)
                n1.fe = -1;
            else
                n1.fe = 0;
            if (n2.fe == -1)
                n.fe = 1;
            else
                n.fe = 0;
            n2.fe = 0;
            return n2;
            }


        private NodoAvl rotacionDI(NodoAvl n, NodoAvl n1)
        {
            NodoAvl n2;
            n2 = (NodoAvl)n1.subarbolIzdo();
            n.ramaDcho(n2.subarbolIzdo());
            n2.ramaIzdo(n);
            n1.ramaIzdo(n2.subarbolDcho());
            n2.ramaDcho(n1);
            // actualización de los factores de equilibrio
            if (n2.fe == +1)
                n.fe = -1;
            else
                n.fe = 0;
            if (n2.fe == -1)
                n1.fe = 1;
            else
                n1.fe = 0;
            n2.fe = 0;
            return n2;
        }



        public void insertar (Object valor)//throws Exception
            {
            Comparador dato;
            Logical h = new Logical(false); // intercambia un valor booleano
            dato = (Comparador) valor;
            raiz = insertarAvl(raiz, dato, h);
            }



            private NodoAvl insertarAvl(NodoAvl raiz, Comparador dt, Logical h) 
                //throws Exception
            {
                NodoAvl n1;
                if (raiz == null)
                {
                    raiz = new NodoAvl(dt);
                    h.setLogical(true);
                }
                else if (dt.menorQue(raiz.valorNodo()))
                {
                    NodoAvl iz;
                    iz = insertarAvl((NodoAvl) raiz.subarbolIzdo(), dt, h);
                    raiz.ramaIzdo(iz);
                    // regreso por los nodos del camino de búsqueda
                    if (h.booleanValue())
                    {
                        // decrementa el fe por aumentar la altura de rama izquierda
                        switch (raiz.fe)
                        {
                        case 1:
                            raiz.fe = 0;
                            h.setLogical(false);
                            break;
                        case 0:
                            raiz.fe = -1;
                            break;
                        case -1: // aplicar rotación a la izquierda
                            n1 = (NodoAvl)raiz.subarbolIzdo();
                            if (n1.fe == -1)
                                raiz = rotacionII(raiz, n1);
                            else
                                raiz = rotacionID(raiz, n1);
                                h.setLogical(false);
                            break;
                        }
                    }   
                }
                else if (dt.mayorQue(raiz.valorNodo()))
                {
                    NodoAvl dr;
                    dr = insertarAvl((NodoAvl)raiz.subarbolDcho(), dt, h);
                    raiz.ramaDcho(dr);
                    // regreso por los nodos del camino de búsqueda
                    if (h.booleanValue())
                    {
                    // incrementa el fe por aumentar la altura de rama izquierda
                    switch (raiz.fe)
                        {
                        case 1: // aplicar rotación a la derecha
                            n1 = (NodoAvl)raiz.subarbolDcho();
                            if (n1.fe == +1)
                                raiz = rotacionDD(raiz, n1);
                            else
                                raiz = rotacionDI(raiz,n1);
                                h.setLogical(false);
                            break;
                        case 0:
                            raiz.fe = +1;
                            break;
                        case -1:
                            raiz.fe = 0;
                            h.setLogical(false);
                            break;
                        }
                    }
                }
                else
                    throw new Exception("No puede haber claves repetidas " );
                return raiz;
            }

        public void eliminar (Object valor) //throws Exception
        {
        Comparador dato;
        dato = (Comparador) valor;
        Logical flag = new Logical(false);
        raiz = borrarAvl(raiz, dato, flag);
        }


private NodoAvl borrarAvl(NodoAvl r, Comparador clave,
Logical cambiaAltura) //throws Exception
{
if (r == null)
{
throw new Exception (" Nodo no encontrado ");
}
else if (clave.menorQue(r.valorNodo()))
{
NodoAvl iz;
iz = borrarAvl((NodoAvl)r.subarbolIzdo(), clave, cambiaAltura);
r.ramaIzdo(iz);
if (cambiaAltura.booleanValue())
r = equilibrar1(r, cambiaAltura);
}
else if (clave.mayorQue(r.valorNodo()))
{
NodoAvl dr;
dr = borrarAvl((NodoAvl)r.subarbolDcho(), clave, cambiaAltura);
r.ramaDcho(dr);
if (cambiaAltura.booleanValue())
r = equilibrar2(r, cambiaAltura);
}
else // Nodo encontrado
{
NodoAvl q;
q = r; // nodo a quitar del árbol
if (q.subarbolIzdo()== null)
{
r = (NodoAvl) q.subarbolDcho();
cambiaAltura.setLogical(true);
}
else if (q.subarbolDcho() == null)
{
r = (NodoAvl) q.subarbolIzdo();
cambiaAltura.setLogical(true);
}
else
{ // tiene rama izquierda y derecha
NodoAvl iz;
iz = reemplazar(r, (NodoAvl)r.subarbolIzdo(), cambiaAltura);
r.ramaIzdo(iz);
if (cambiaAltura.booleanValue())
r = equilibrar1(r, cambiaAltura);
}
q = null;
}
return r;
}


        private NodoAvl reemplazar(NodoAvl n, NodoAvl act, Logical cambiaAltura)
        {
            if (act.subarbolDcho() != null)
            {
                NodoAvl d;
                d = reemplazar(n, (NodoAvl)act.subarbolDcho(), cambiaAltura);
                act.ramaDcho(d);
                if (cambiaAltura.booleanValue())
                act = equilibrar2(act, cambiaAltura);
            }
           else
           {
                n. nuevoValor(act.valorNodo());
                n = act;
                act = (NodoAvl)act.subarbolIzdo();
                n = null;
                cambiaAltura.setLogical(true);
           }
           return act;
        }

    private NodoAvl equilibrar1(NodoAvl n, Logical cambiaAltura)
    {
        NodoAvl n1;
        switch (n.fe)
        {
        case -1 : n.fe = 0;
        break;
        case 0 : n.fe = 1;
        cambiaAltura.setLogical(false);
        break;
        case +1 : //se aplicar un tipo de rotación derecha
        n1 = (NodoAvl)n.subarbolDcho();
        if (n1.fe >= 0)
        {
            if (n1.fe == 0) //la altura no vuelve a disminuir
            cambiaAltura.setLogical(false);
            n = rotacionDD(n, n1);
        }
        else
            n = rotacionDI(n, n1);
        break;
        }
            return n;
    } 
        
        private NodoAvl equilibrar2(NodoAvl n, Logical cambiaAltura)
        {
        NodoAvl n1;
        switch (n.fe)
        {
        case -1: // Se aplica un tipo de rotación izquierda
        n1 = (NodoAvl)n.subarbolIzdo();
        if (n1.fe <= 0)
        {
        if (n1.fe == 0)
        cambiaAltura.setLogical(false);
        n = rotacionII(n, n1);
        }
        else
        n = rotacionID(n,n1);
        break;
        case 0 : n.fe = -1;
        cambiaAltura.setLogical(false);
        break;
        case +1 : n.fe = 0;
        break;
        }
        return n;
        }
        
        /////////////////////////////////
        /// <summary>
        /// Comprueba el estatus del árbol
        /// </summary>
        /// <returns></returns>
         bool esVacio()
        {
            return raiz == null;
        }

        public static NodoAvl nuevoArbol(NodoAvl ramaIzqda, Object dato, NodoAvl ramaDrcha)
        {
            return new NodoAvl( dato,ramaIzqda, ramaDrcha);
        }


        //binario en preorden
        public static string preorden(Nodo r)
        {
            if (r != null)
            {
                return r.visitar() + preorden (r.subarbolIzdo()) + preorden (r.subarbolDcho());
            }
            return "";
        } 
        
        // Recorrido de un árbol binario en inorden
        public static string inorden(Nodo r)
        {
            if (r != null)
            {
                return inorden (r.subarbolIzdo()) + r.visitar() + inorden (r.subarbolDcho());
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
