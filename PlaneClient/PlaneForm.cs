using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlaneShare;

namespace PlaneClient
{
    public partial class PlaneForm : Form
    {
        const String uri = "tcp://127.0.0.1:0505/pktq"; // địa chỉ Localhost
        IPlaneBus planeBus = (IPlaneBus)Activator.GetObject(typeof(IPlaneBus), uri);
        public PlaneForm()
        {
            InitializeComponent();
        }

        private void gridPlane_Click(object sender, EventArgs e)
        {

        }

        private void PlaneForm_Load(object sender, EventArgs e)
        {
            List<Plane> planes = planeBus.GetAll();
            gridPlane.DataSource = planes;

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
