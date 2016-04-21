using System;
using System.Collections.Generic;
using DevExpress.ExpressApp;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.ExpressApp.Win.Editors;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils;

namespace QuanLyBanhang.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CauHinhChungListView : ViewController
    {
        public CauHinhChungListView()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            //Application.Security.UserId;
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
        //void SetGridFont(GridView view, Font font)
        //{

        //    foreach (AppearanceObject ap in view.Appearance)

        //        ap.Font = font;
        //}
        GridListEditor listEditor;
        private void SetBestFitForColumns(GridView gridView)
        {
            if (gridView != null)
            {
                //Calculate the estimated best width
                int estimatedBestWidth = 0;

                //To avoid a full grid scan, only use the 20 first rows to set the best fit
                gridView.BestFitMaxRowCount = 20;

                foreach (GridColumn column in gridView.Columns)
                {
                    estimatedBestWidth += column.GetBestWidth();
                }

                //If the calculated best width is greater than the grid width
                if (estimatedBestWidth > gridView.GridControl.Width || true)
                {
                    //Disable the column autowidth (which is true by default) to allow the scrollbar to appear
                    gridView.OptionsView.ColumnAutoWidth = false;

                    //And force the columns to resize to its best width
                    gridView.BestFitColumns();
                }
            }
        }

        private void GridView_DataSourceChanged(object sender, EventArgs e)
        {
            ((GridView)sender).BestFitColumns();
        }
        void gridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT" && e.ListSourceRowIndex >= 0)
            { e.DisplayText = (e.ListSourceRowIndex + 1).ToString(); }
        }

        private void GridControl_ProcessGridKey(Object sender, KeyEventArgs e)
        {
            DevExpress.XtraGrid.GridControl grid = sender as DevExpress.XtraGrid.GridControl;
            GridView gridView = grid.FocusedView as GridView;

            //if (gridView.FocusedColumn.VisibleIndex == gridView.VisibleColumns.Count - 1)
            //    gridView.FocusedRowHandle++;
            //    gridView.FocusedColumn = gridView.GetNearestCanFocusedColumn(gridView.FocusedColumn);
            //for (int j = gridView.VisibleColumns.Count - 1; j >= 0; j--)
            //{
            //    if (gridView.VisibleColumns[j].VisibleIndex > 0)
            //    {
            //        //gridView.VisibleColumns[j].VisibleIndex = gridView.VisibleColumns[j].VisibleIndex + 1;
            //        if (gridView.VisibleColumns[0].FieldName == "DX$CheckboxSelectorColumn")
            //        {
            //            gridView.VisibleColumns[0].OptionsColumn.TabStop = false;
            //        }
            //    }
            //}
            if (!gridView.IsEditing && e.KeyCode == Keys.Enter)
            // if (e.KeyCode == Keys.Enter)
            {
                SendKeys.SendWait("{TAB}");
                gridView.ShowEditor();
                gridView.CloseEditor();
                gridView.UpdateCurrentRow();
                gridView.PostEditor();
                e.Handled = true;
            }
        }

        private void CauHinhChungListView_ViewControlsCreated(object sender, EventArgs e)
        {
            listEditor = ((DevExpress.ExpressApp.ListView)View).Editor as GridListEditor;
            GridView gridView = listEditor.GridView;
            gridView.OptionsView.EnableAppearanceOddRow = true;
            //gridView.Appearance.OddRow.BackColor = Color.PaleTurquoise;
            gridView.Appearance.OddRow.BackColor = Color.LightBlue;
            //gridView.Appearance.FocusedCell.BackColor = Color.Plum;
            gridView.Appearance.FocusedCell.BackColor = Color.BlueViolet;
            gridView.OptionsView.ColumnAutoWidth = false;
            gridView.BestFitColumns();
            gridView.OptionsView.ShowAutoFilterRow = false;
            gridView.OptionsFind.AlwaysVisible = true;
            gridView.OptionsView.ShowFooter = true;
            //gridView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
            gridView.OptionsView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
            gridView.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.Formatted;
            //SetGridFont(gridView, new Font("VNI-Times", 10));
            //selected multi
            gridView.OptionsSelection.MultiSelect = true;
            //gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            //gridView.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;

            gridView.OptionsView.ShowAutoFilterRow = true;
            //gridView.GridControl.AllowRestoreSelectionAndFocusedRow = DevExpress.Utils.DefaultBoolean.True;
            gridView.OptionsBehavior.EditorShowMode = EditorShowMode.MouseDownFocused;
            //gridView.OptionsBehavior.EditorShowMode = EditorShowMode.MouseUp;
            gridView.SelectionChanged += listEditor_SelectionChanged;

            ////////////////////////
            if (listEditor != null && !View.Id.Contains("Lookup"))
            // if (listEditor != null)
            {
                Console.WriteLine("View đã duyệt " + View.Id);
                //thêm sự kiện

                gridView.GridControl.ProcessGridKey += new KeyEventHandler(GridControl_ProcessGridKey);
                listEditor.GridView.DataSourceChanged += new EventHandler(GridView_DataSourceChanged);
                //listEditor.Grid.HandleCreated += new EventHandler(Grid_HandleCreated);
                SetBestFitForColumns(gridView);
            }
            else
            {
                // gridView.GridControl.ProcessGridKey += new KeyEventHandler(GridControl_ProcessGridKey);
                listEditor.GridView.DataSourceChanged += new EventHandler(GridView_DataSourceChanged);
                //listEditor.Grid.HandleCreated += new EventHandler(Grid_HandleCreated);
                //SetBestFitForColumns(gridView);
                //listEditor.GridView.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
                //listEditor.GridView.OptionsSelection.EnableAppearanceFocusedCell = false;
                //listEditor.GridView.OptionsSelection.EnableAppearanceFocusedRow = false;
                //listEditor.GridView.OptionsSelection.EnableAppearanceHideSelection = false;
                //listEditor.GridView.OptionsSelection.MultiSelect = true;
                //listEditor.GridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                //listEditor.GridView.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
                //listEditor.GridView.MouseDown += new System.Windows.Forms.MouseEventHandler(GridView_MouseDown);
                //listEditor.GridView.MouseUp += new System.Windows.Forms.MouseEventHandler(GridView_MouseUp);
                //listEditor.GridView.ColumnFilterChanged += GridView_ColumnFilterChanged;
            }

            if (gridView.Columns["itemNo"] == null)
            {
                GridColumn itemNo = new GridColumn();
                itemNo.Caption = "STT";
                itemNo.OptionsColumn.AllowEdit = false;
                itemNo.OptionsColumn.TabStop = false;
                itemNo.UnboundType = UnboundColumnType.String;
                itemNo.Width = 28;
                gridView.Columns.Add(itemNo);
                itemNo.VisibleIndex = 0;
                itemNo.Fixed = FixedStyle.Left;

            }

            gridView.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView_CustomColumnDisplayText);

        }

        private void GridView_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            GridHitInfo hi = view.CalcHitInfo(e.Location);
            if (hi.Column.FieldName == "DX$CheckboxSelectorColumn")
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
        private void GridView_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            RestoreSelection(view);
        }
        private void GridView_ColumnFilterChanged(object sender, EventArgs e)
        {
            RestoreSelection(sender as GridView);
        }
        private List<int> selectedRows = new List<int>();
        void RestoreSelection(GridView view)
        {
            BeginInvoke(new Action(() =>
            {
                for (int i = 0; i < selectedRows.Count; i++)
                    view.SelectRow(view.GetRowHandle(selectedRows[i]));
            }));
        }

        private void BeginInvoke(Action action)
        {
            throw new NotImplementedException();
        }

        private void CauHinhChungListView_ViewControlsCreated_1(object sender, EventArgs e)
        {
            
        }
        Boolean ClearSelection = true;
        void listEditor_SelectionChanged(object sender, EventArgs e)
        {
            if (ClearSelection)
            {
                ClearSelection = false;
                View.CurrentObject = null;
                listEditor.GridView.UnselectRow(0);
            }
        }
    }
}
