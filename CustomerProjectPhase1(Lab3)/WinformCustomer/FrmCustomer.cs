using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InterfaceCustomer;
using FactoryCustomer;
using InterfaceDal;
using FactoryDal;
namespace WinformCustomer
{
    public partial class FrmCustomer : Form
    {
        private ICustomer cust = null;
        
        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            DalLayer.Items.Add("ADODal");
            DalLayer.Items.Add("EFDal");
            LoadGrid();
        }
        private void LoadGrid()
        {
            IDal<ICustomer> Idal = FactoryDalLayer<IDal<ICustomer>>.Create("ADODal");
            List<ICustomer> custs = Idal.Search();
            dtgGridCustomer.DataSource = custs;

        }
        private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cust = Factory<ICustomer>.Create(cmbCustomerType.Text);
        }
        private void SetCustomer()
        {
            cust.CustomerName = txtCustomerName.Text;
            cust.PhoneNumber = txtPhoneNumber.Text;
            cust.BillDate = Convert.ToDateTime(txtBillingDate.Text);
            cust.BillAmount = Convert.ToDecimal(txtBillingAmount.Text);
            cust.Address = txtAddress.Text;
        }
        private void btnValidate_Click(object sender, EventArgs e)
        {
            try
            {
                SetCustomer();
                cust.Validate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetCustomer();
            IDal<ICustomer> dal = FactoryDalLayer<IDal<ICustomer>>
                                 .Create("ADODal");
            dal.Add(cust); // In memory
            dal.Save(); // Physical committ
        }
    }
}
