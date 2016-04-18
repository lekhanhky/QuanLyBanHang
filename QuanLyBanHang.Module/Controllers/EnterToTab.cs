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
using DevExpress.ExpressApp.Win.Editors;

namespace QuanLyBanHang.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class EnterToTab : ViewController<DetailView>
    {
        public EnterToTab()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            //this.TargetViewType = DetailView;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            foreach (DXPropertyEditor propertyEditor in View.GetItems<DXPropertyEditor>())
            {
                propertyEditor.ControlCreated += new EventHandler<EventArgs>(propertyEditor_ControlCreated);
            }
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
            foreach (DXPropertyEditor propertyEditor in View.GetItems<DXPropertyEditor>())
            {
                propertyEditor.ControlCreated -= new EventHandler<EventArgs>(propertyEditor_ControlCreated);
            }
        }
        void propertyEditor_ControlCreated(object sender, EventArgs e)
        {
            ((DXPropertyEditor)sender).Control.EnterMoveNextControl = true;
        }
    }
}
