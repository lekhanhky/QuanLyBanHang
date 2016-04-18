using System;
using DevExpress.ExpressApp;
using DevExpress.XtraLayout;


namespace QuanLyBanHang.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ShowExpandLayout : ViewController
    {
        public ShowExpandLayout()
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
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void ShowExpandLayout_ViewControlsCreated(object sender, EventArgs e)
        {
            foreach (BaseLayoutItem item in ((LayoutControl)View.Control).Items)
            {
                if (item is LayoutControlGroup)
                {
                    ((LayoutControlGroup)item).ExpandButtonVisible = true;
                }
            }
        }
    }
}
