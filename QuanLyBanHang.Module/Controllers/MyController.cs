using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace QuanLyBanHang.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class MyController : ViewController<DetailView>
    {
        public MyController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
            //System.Windows.Forms.Control lastControl = null; foreach (PropertyEditor pe in View.GetItems<PropertyEditor>())
            //{
            //    System.Windows.Forms.Control c = (System.Windows.Forms.Control)pe.Control;
            //    if (c != null && c.TabStop)
            //    {
            //        if (lastControl == null || c.TabIndex > lastControl.TabIndex)
            //        {
            //            lastControl = c;
            //        }
            //    }
            //}
            //if (lastControl != null)
            //{
            //    lastControl.Leave += new EventHandler(lastControl_Leave);
            //}
        }
        //void lastControl_Leave(object sender, EventArgs e)
        //{
        //    ((System.Windows.Forms.Control)sender).BeginInvoke(new Action(delegate
        //    {
        //        if (View == null) return; View.Close();
        //    }));
        //}
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
