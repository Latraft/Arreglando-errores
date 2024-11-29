using EDDemo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;


//using GraphVizWrapper;
//using GraphVizWrapper.Queries;
//using GraphVizWrapper.Commands;

//using csdot;
//using csdot.Attributes.DataTypes;

namespace EDDemo.Estructuras_No_Lineales
{
    public partial class frmArboles : Form
    {
        ArbolBusqueda miArbol;
        NodoBinario miRaiz;

        public frmArboles()
        {
            InitializeComponent();
            miArbol = new ArbolBusqueda();
            miRaiz = null;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {

            
            miRaiz = miArbol.RegresaRaiz();

            
            miArbol.strArbol = "";

            
            miArbol.InsertaNodo(int.Parse(txtDato.Text),
                                ref miRaiz);

            
            miArbol.MuestraArbolAcostado(1, miRaiz);
            txtArbol.Text = miArbol.strArbol;
            
            txtDato.Text = "";

 
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            miArbol = null;
            miRaiz = null;
            miArbol = new ArbolBusqueda();
            txtArbol.Text  = "";
            txtDato.Text = "";
            lblRecorridoPreOrden.Text = "";
            lblRecorridoInOrden.Text = "";
            lblRecorridoPostOrden.Text = "";
        }

        private void btnGrafica_Click(object sender, EventArgs e)
        {
            String graphVizString;

            miRaiz = miArbol.RegresaRaiz();
            if (miRaiz == null)
            {
                MessageBox.Show("El arbol esta vacio");
                return;
            }

            StringBuilder b = new StringBuilder();
            b.Append("digraph G { node [shape=\"circle\"]; " + Environment.NewLine);
            b.Append(miArbol.ToDot(miRaiz));
            b.Append("}");
            graphVizString =  b.ToString();

            //graphVizString = @" digraph g{ label=""Graph""; labelloc=top;labeljust=left;}";
            //graphVizString = @"digraph Arbol{Raiz->60; 60->40. 60->90; 40->34; 40->50;}";
            Bitmap bm = FileDotEngine.Run(graphVizString);

            
            frmGrafica graf = new frmGrafica();
            graf.ActualizaGrafica(bm);
            graf.MdiParent = this.MdiParent;
            graf.Show();
        }


        private void btnRecorrer_Click(object sender, EventArgs e)
        {
            //Recorrido en PreOrden
            //Obtenemos el nodo Raiz del arbol
            miRaiz = miArbol.RegresaRaiz();
            miArbol.strRecorrido = "";

            if (miRaiz == null)
            {
                lblRecorridoPreOrden.Text = "El arbol esta vacio";
                return;
            }
            lblRecorridoPreOrden.Text = "";
            miArbol.PreOrden(miRaiz);

            lblRecorridoPreOrden.Text = miArbol.strRecorrido;


            //Recorrido en InOrden
            //Obtenemos el nodo Raiz del arbol
            miRaiz = miArbol.RegresaRaiz();
            miArbol.strRecorrido = "";

            if (miRaiz == null)
            {
                lblRecorridoPostOrden.Text = "El arbol esta vacio";
                return;
            }
            lblRecorridoInOrden.Text = "";
            miArbol.InOrden(miRaiz);
            lblRecorridoInOrden.Text = miArbol.strRecorrido;


            //Recorrido en PostOrden
            //Obtenemos el nodo Raiz del arbol
            miRaiz = miArbol.RegresaRaiz();
            miArbol.strRecorrido = "";

            if (miRaiz == null) {
                lblRecorridoPostOrden.Text = "El arbol esta vacio";
                return;
            }
            lblRecorridoPostOrden.Text = ""; 
            miArbol.PostOrden(miRaiz);
            lblRecorridoPostOrden.Text = miArbol.strRecorrido;
        }

        private void btnCrearArbol_Click(object sender, EventArgs e)
        {
            //Limpiamos los objetos y clases del anterior arbol
            miArbol = null;
            miRaiz = null;
            miArbol = new ArbolBusqueda();
            txtArbol.Text = "";
            txtDato.Text = "";
             
            miArbol.strArbol = "";

            Random rnd = new Random();

            for (int nNodos =1; nNodos <= txtNodos.Value; nNodos++)
            {
                int Dato = rnd.Next(1, 100);
                //Obtenemos el nodo Raiz del arbol
                miRaiz = miArbol.RegresaRaiz();

                //Se inserta el nodo con el dato capturado
                miArbol.InsertaNodo(Dato, ref miRaiz);
            }

          
            miArbol.MuestraArbolAcostado(1, miRaiz);
            txtArbol.Text = miArbol.strArbol;

            txtDato.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            miRaiz = miArbol.RegresaRaiz();

            if (miRaiz == null)
            {
                MessageBox.Show("El árbol está vacío.");
                return;
            }

           
            int valor = int.Parse(txtBuscar.Text);

           
            bool encontrado = miArbol.BuscarNodo(valor, miRaiz);

            if (encontrado)
            {
                MessageBox.Show($"El nodo con valor {valor} fue encontrado.");
            }
            else
            {
                MessageBox.Show($"El nodo con valor {valor} no existe en el árbol.");
            }

            
            txtBuscar.Text = "";
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtDatoEliminar.Text, out int valor))
            {
                
                miArbol.EliminarNodoConPredecesor(valor);
                miArbol.strArbol = "";
                miArbol.MuestraArbolAcostado(1, miArbol.RegresaRaiz());
                txtArbol.Text = miArbol.strArbol;

            }
            else
            {
                MessageBox.Show("Por favor, ingresa un valor numérico válido en el campo 'txtPredecesor'.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            miRaiz = miArbol.RegresaRaiz();
            int altura = miArbol.ObtenerAltura();
            texAltura.Text = altura.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            miRaiz = miArbol.RegresaRaiz();
            int cantidadNodos = miArbol.ContarNodos();
            txtCantidadNodos.Text = cantidadNodos.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            miRaiz = miArbol.RegresaRaiz();
            int cantidadHojas = miArbol.ContarHojas();
            txtCantidadHojas.Text = cantidadHojas.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            miRaiz = miArbol.RegresaRaiz();
            bool esCompleto = miArbol.EsBinarioCompleto();
            boton9.Text = esCompleto ? "Sí" : "No";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            miRaiz = miArbol.RegresaRaiz();
            bool esLleno = miArbol.EsBinarioLleno();
            boton10.Text = esLleno ? "Sí" : "No";
        }

        private void txtCantidadNodos_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
                miArbol.Podar();
                txtArbol.Text = "El árbol ha sido podado.";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(btsucesor.Text, out int valor))
            {
                
                miArbol.EliminarNodoConSucesor(valor);
                miArbol.strArbol = "";
                miArbol.MuestraArbolAcostado(1, miArbol.RegresaRaiz());
                txtArbol.Text = miArbol.strArbol;
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un valor numérico válido en el campo 'txtSucesor'.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string recorridoAmplitud = miArbol.RecorridoAmplitud();
            btrecorrer.Text = recorridoAmplitud;
        }

        private void sucesor_TextChanged(object sender, EventArgs e)
        {

        }

        private void btrecorrer_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtArbol_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblRecorridoInOrden_Click(object sender, EventArgs e)
        {

        }

        private void lblRecorridoPreOrden_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
