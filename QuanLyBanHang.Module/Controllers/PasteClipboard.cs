using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Windows.Forms;

namespace QuanLyBanHang.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class PasteClipboard : ViewController
    {
        public PasteClipboard()
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

               private void AddRow(string data, int rowHandle, GridView gridView)
        {
            if (data == string.Empty) return;
            //string[] rowData = data.Split('\t');
            string[] rowData = data.Split(new char[] { '\r', '\x09' });
            int column = gridView.FocusedColumn.VisibleIndex;
            for (int i = 0; i < rowData.Length; i++)
            {
                if (i >= gridView.VisibleColumns.Count) break;
                try
                {
                    rowData[i] = rowData[i].Replace(",00", "");
                    rowData[i] = rowData[i].Replace(".", "");
                    rowData[i] = rowData[i].Replace("₫", "");
                    //
                    //

                    gridView.SetRowCellValue(rowHandle, gridView.VisibleColumns[column + i], rowData[i]);
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);
                }
            }
        }

        private string ClipboardData
        {
            get
            {
                IDataObject iData = Clipboard.GetDataObject();
                if (iData == null) return "";

                if (iData.GetDataPresent(DataFormats.UnicodeText))
                    return (string)iData.GetData(DataFormats.UnicodeText).ToString().Replace(".", "").ToString().Replace(",", "");
                return "";
            }
            set
            {
                //Clipboard.SetDataObject(value);
                Clipboard.SetDataObject("UnicodeText", true);
            }
        }

        private void GridControl_ProcessGridKey(object sender, KeyEventArgs e)
        {
            DevExpress.XtraGrid.GridControl grid = sender as DevExpress.XtraGrid.GridControl;
            GridView gridView = grid.FocusedView as GridView;
            //if (!gridView.IsEditing && e.KeyCode == Keys.Enter)
            //// if (e.KeyCode == Keys.Enter)
            //{
            //    SendKeys.SendWait("{TAB}");
            //    gridView.ShowEditor();
            //    gridView.CloseEditor();
            //    gridView.UpdateCurrentRow();
            //    gridView.PostEditor();
            //    e.Handled = true;
            //}
            if (e.Control && e.KeyCode == System.Windows.Forms.Keys.V)
            {
                string[] data = ClipboardData.Split(new char[] { '\r', '\n', }, StringSplitOptions.RemoveEmptyEntries);
                if (data.Length == 1)
                {
                    foreach (GridCell cell in gridView.GetSelectedCells())
                    {
                        //            if (Object.ReferenceEquals(cell.GetType(), ClipboardData.GetType()))

                        gridView.SetRowCellValue(cell.RowHandle, cell.Column, ClipboardData);

                        //  else if (Object.ReferenceEquals(cell.GetType(), ClipboardData.GetType()) == false)
                    }
                }
                else if (data.Length > 1)
                {
                    int startRow = gridView.FocusedRowHandle;
                    foreach (string row in data)
                    {
                        AddRow(row, startRow++, gridView);
                        if (!gridView.IsValidRowHandle(startRow)) break;
                    }
                }
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
            //================================
            ////paste
            //if (e.Control && e.KeyCode == Keys.V)
            //{
            //    foreach (GridCell cell in gridView.GetSelectedCells())
            //    {
            //        gridView.SetRowCellValue(cell.RowHandle, cell.Column, ClipboardData);
            //    }
            //    e.SuppressKeyPress = true;
            //    e.Handled = true;
            //}
            //=====================================
            //if (e.Control && e.KeyCode == Keys.V)
            //{
            //    string[] data = ClipboardData.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            //    if (data.Length < 1) return;
            //    int startRow = gridView.FocusedRowHandle;
            //    foreach (string row in data)
            //    {
            //        AddRow(row, startRow++, gridView);
            //        if (!gridView.IsValidRowHandle(startRow)) break;
            //    }
            //    e.SuppressKeyPress = true;
            //    e.Handled = true;
            //}
            //===============================
            //if (e.Control && e.KeyCode == System.Windows.Forms.Keys.V)
            //{
            //    try
            //    {
            //        string[] data = ClipboardData.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            //        if (data.Length == 1)
            //        {
            //            foreach (GridCell cell in gridView.GetSelectedCells())
            //            {
            //                //            if (Object.ReferenceEquals(cell.GetType(), ClipboardData.GetType()))

            //                gridView.SetRowCellValue(cell.RowHandle, cell.Column, ClipboardData);

            //                //  else if (Object.ReferenceEquals(cell.GetType(), ClipboardData.GetType()) == false)

            //            }
            //        }
            //        else if (data.Length > 1)
            //        {
            //            int startRow = gridView.FocusedRowHandle;
            //            foreach (string row in data)
            //            {
            //                AddRow(row, startRow++, gridView);
            //                if (!gridView.IsValidRowHandle(startRow)) break;
            //            }
            //        }
            //        e.SuppressKeyPress = true;
            //        e.Handled = true;
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine("Lỗi paste clipboard " + ex.ToString());
            //    }

            //}
        }

        private void PasteClipboard_ViewControlsCreated(object sender, EventArgs e)
        {
            GridListEditor listEditor = ((DevExpress.ExpressApp.ListView)View).Editor as GridListEditor;
            GridView gridView = listEditor.GridView;
            if (listEditor != null && !View.Id.Contains("Lookup"))
            // if (listEditor != null)
            {
                Console.WriteLine("View đã duyệt " + View.Id);

                gridView.GridControl.ProcessGridKey += new KeyEventHandler(GridControl_ProcessGridKey);
            }
        }
    }
}