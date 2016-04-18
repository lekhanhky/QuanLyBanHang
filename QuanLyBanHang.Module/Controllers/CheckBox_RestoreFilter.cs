using System;
using System.Collections.Generic;
using DevExpress.ExpressApp;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraGrid.Selection;

namespace QuanLyBanHang.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CheckBox_RestoreFilter : ViewController
    {
        public CheckBox_RestoreFilter()
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

        private void CheckBox_RestoreFilter_ViewControlsCreated(object sender, EventArgs e)
        {
            GridListEditor listEditor = ((DevExpress.ExpressApp.ListView)View).Editor as GridListEditor;
            GridControl grid = (GridControl)listEditor.Control;
            GridView gridView1 = (GridView)grid.FocusedView;
            //test CheckMarkSelection
            new GridCheckMarksSelection(gridView1);
            gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            gridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(gridview1_MouseDown);
            gridView1.MouseUp += new MouseEventHandler(gridView1_MouseUp);
            gridView1.ColumnFilterChanged += gridView1_ColumnFilterChanged;
            //gridview1.ShownEditor += new EventHandler(gridview1_ShownEditor);
            //gridview1.HiddenEditor += new EventHandler(gridview1_HiddenEditor);
        }
        private void gridView1_ColumnFilterChanged(object sender, EventArgs e)
        {
            RestoreSelection(sender as GridView);
        }

        private void gridView1_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            RestoreSelection(view);
        }

        private void gridview1_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            GridHitInfo hi = view.CalcHitInfo(e.Location);
            // if (hi.Column.FieldName == "DX$CheckboxSelectorColumn")
            try
            {
                if (hi.Column.FieldName == "Check")
                {
                    if (!hi.InRow)
                    {
                        bool allSelected = view.DataController.Selection.Count == view.DataRowCount;
                        if (!allSelected)
                        {
                            for (int i = 0; i < view.RowCount; i++)
                            {
                                int sourceHandle = view.GetDataSourceRowIndex(i);
                                if (!selectedRows.Contains(sourceHandle))
                                    selectedRows.Add(sourceHandle);
                            }
                        }
                        else selectedRows.Clear();
                    }
                    else
                    {
                        int sourceHandle = view.GetDataSourceRowIndex(hi.RowHandle);
                        if (!selectedRows.Contains(sourceHandle))
                            selectedRows.Add(sourceHandle);
                        else
                            selectedRows.Remove(sourceHandle);
                    }
                }
                RestoreSelection(view);
            }
            catch (Exception)
            {

               // throw;
            }
            
        }

        private void RestoreSelection(GridView view)
        {
            //this.BeginInvoke(new MethodInvoker(delegate {
            //    AddMessage(this);
            //}));
            //Form formTemplate = Frame.Template as Form;
            //if (formTemplate != null)
            //    formTemplate.BeginInvoke(new MethodInvoker(formTemplate.Close));
            //=====================================
            Form formTemplate = Frame.Template as Form;
            if (formTemplate != null)
                formTemplate.BeginInvoke((new Action(() =>
                {
                    for (int i = 0; i < selectedRows.Count; i++)
                        view.SelectRow(view.GetRowHandle(selectedRows[i]));
                })));
            //BeginInvoke(new Action(() =>
            //{
            //    for (int i = 0; i < selectedRows.Count; i++)
            //        view.SelectRow(view.GetRowHandle(selectedRows[i]));
            //}));
        }
        List<int> selectedRows = new List<int>();
    }
}
