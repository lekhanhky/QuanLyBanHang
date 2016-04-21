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
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace QuanLyBanHang.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class SkipReadOnlyPropertiesController : ViewController<ListView>
    {
        public SkipReadOnlyPropertiesController()
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
            try
            {
                GridListEditor editor = View.Editor as GridListEditor;
                if (editor != null)
                {
                    editor.GridView.FocusedColumnChanged += this.GridView_FocusedColumnChanged;
                }
            }
            catch (Exception)
            {

               // throw;
            }
            
        }

        private void GridView_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            GridView gridView = ((GridView)sender);
            bool canShowEditor = gridView.CanShowEditor;
            if (!canShowEditor)
            {
                //// determine whats the action TAB or SHIFT-TAB
                bool forward = e.FocusedColumn.VisibleIndex > e.PrevFocusedColumn.VisibleIndex;

                if (forward && gridView.FocusedColumn.VisibleIndex + 1 < gridView.VisibleColumns.Count)
                {
                    gridView.FocusedColumn = gridView.VisibleColumns[gridView.FocusedColumn.VisibleIndex + 1];
                }
                else if (!forward && gridView.FocusedColumn.VisibleIndex - 1 >= 0)
                {
                    gridView.FocusedColumn = gridView.VisibleColumns[gridView.FocusedColumn.VisibleIndex - 1];
                }
            }
        }

        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
