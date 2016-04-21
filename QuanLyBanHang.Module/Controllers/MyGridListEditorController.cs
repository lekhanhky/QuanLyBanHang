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
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using System.ComponentModel;

namespace QuanLyBanHang.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class MyGridListEditorController : ViewController
    {
        private GridListEditor gridListEditor;
        private void GridView1_KeyDown(Object sender, KeyEventArgs e)
        {
            //// if ((e.KeyCode == Keys.Tab) && (gridListEditor.GridView.ActiveEditor is LookUpEdit))
            //if (e.KeyCode == Keys.Tab)
            //{
            //    try
            //    {
            //        LookupEdit lookupEdit = (LookupEdit)gridListEditor.GridView.ActiveEditor;
            //        //if (lookupEdit.EditValue == null)
            //        //{
            //        lookupEdit.ShowPopup();
            //        e.Handled = true;
            //        //}
            //    }
            //    catch (Exception ex)
            //    {
            //        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        // throw;
            //    }


          //  }
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            gridListEditor = (GridListEditor)((DevExpress.ExpressApp.ListView)View).Editor;
            //gridListEditor.GridView.KeyDown += new KeyEventHandler(GridView_KeyDown);
            //gridListEditor.GridView.ShowingEditor += GridView1_ShowingEditor;
            gridListEditor.GridView.KeyDown += GridView1_KeyDown;
        }

        //private void GridView1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (gridListEditor.GridView.OptionsBehavior.Editable && gridListEditor.GridView.OptionsBehavior.ReadOnly == false && gridListEditor.GridView.FocusedColumn.ReadOnly == false)
        //    {
        //    //    //if (char.IsLetterOrDigit((char)e.KeyCode) && gridListEditor.GridView.ActiveEditor == null)
        //    //    //{
        //    //    if (e.KeyCode == Keys.Tab && gridListEditor.GridView.ActiveEditor == null)
        //    //    {
        //    //        allowShwoingEditor = true;
        //    //    }
                    
        //    //    //}
        //    }
        //}

        private bool allowShwoingEditor = false;
        private void GridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            //if (!allowShwoingEditor)
            //{
            //    e.Cancel = true;
            //}
            //else
            //{
            //    allowShwoingEditor = false;
            //}
        }

        public MyGridListEditorController()
            : base()
        {
            TypeOfView = typeof(DevExpress.ExpressApp.ListView);
        }
    
}
}
