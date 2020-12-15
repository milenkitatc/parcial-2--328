using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Alumno_Datos
{
    public partial class Form_con : Form
    {
        bool sw=false;
        public Form_con()
        {
            InitializeComponent();
        }
        DataSet c;

        private void Form_con_Load(object sender, EventArgs e)
        {
            ServiceReference6.WebService2SoapClient ws = new ServiceReference6.WebService2SoapClient();
            c = ws.cargar_ci();

            cb_ci.DataSource = c.Tables[0];
            cb_ci.DisplayMember = "ci";
            cb_ci.ValueMember = "ci";
            cb_ci.SelectedIndex =-1;
            sw = true;
        }
        
        private void cb_ci_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sw == true)
            {
                if (this.cb_ci.SelectedIndex >= 0)
                {
                    ServiceReference6.WebService2SoapClient ws = new ServiceReference6.WebService2SoapClient();
                    c = ws.consultar_ci(cb_ci.SelectedValue.ToString());
                    txtci.Text = c.Tables[0].Rows[0]["ci"].ToString();
                    txtcarrera.Text = c.Tables[0].Rows[0]["carrera"].ToString();
                    txtcel.Text = c.Tables[0].Rows[0]["telefono"].ToString();
                    txtcorreo.Text = c.Tables[0].Rows[0]["correo"].ToString();
                    txtdireccion.Text = c.Tables[0].Rows[0]["direccion"].ToString();
                    txtfnac.Text = c.Tables[0].Rows[0]["fecha_nac"].ToString();
                    txtgenero.Text = c.Tables[0].Rows[0]["genero"].ToString();
                    txtmaterno.Text = c.Tables[0].Rows[0]["materno"].ToString();
                    txtnacionalidad.Text = c.Tables[0].Rows[0]["nacionalidad"].ToString();
                    txtnombre.Text = c.Tables[0].Rows[0]["nombre"].ToString();
                    txtpaterno.Text = c.Tables[0].Rows[0]["paterno"].ToString();
                    txt_reguniv.Text = c.Tables[0].Rows[0]["registro"].ToString();

                    ServiceReference6.WebService2SoapClient ws1 = new ServiceReference6.WebService2SoapClient();
                    c = ws1.consultar_materias(txtci.Text.ToString());

                    dgvmateria.DataSource = c;
                    dgvmateria.DataMember= "materias";
                }
            }
            
        }
    }
}
