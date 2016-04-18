using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using System;
using System.ComponentModel;
using System.Windows.Forms;


namespace QuanLyBanHang.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class LookupPropertyEditorController : ViewController<DetailView>
    {
        private bool isChanged = false;
        public LookupPropertyEditorController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            foreach (LookupPropertyEditor lookupPropertyEditor in View.GetItems<LookupPropertyEditor>())
            {
                lookupPropertyEditor.ControlCreated += lookupPropertyEditor_ControlCreated;
            }
        }
        private void lookupPropertyEditor_ControlCreated(object sender, EventArgs e)
        {
            LookupEdit lookup = ((LookupPropertyEditor)sender).Control;
            // lookup.MouseDown += lookup_MouseDown;
            // lookup.MouseUp += lookup_MouseUp;
            lookup.QueryCloseUp += lookup_QueryCloseUp;
            //kiểm tra trường hợp popup xem sao
            //lookup.PreviewKeyDown += lookup_PreviewKeyDown;
            //lookup.KeyDown += lookup_KeyDown;
            //lookup.KeyPress += lookup_Keypress;
            //lookup.MouseClick += lookup_MouseClick;
            lookup.Closed += lookup_Closed;
        }
        private void lookup_Closed(object sender, ClosedEventArgs e)
        {
            this.isChanged = true;
        }

        private void lookup_QueryCloseUp(object sender, CancelEventArgs e)
        {
            this.isChanged = true;
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
            SubscribeToEvents();
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            UnsubscribeFromEvents();
            base.OnDeactivated();
        }

        private void UnsubscribeFromEvents()
        {
            foreach (LookupPropertyEditor lookup in View.GetItems<LookupPropertyEditor>())
            {
                try
                {
                    //if (this.isChanged == true && acc > 1)
                    //{
                    lookup.Control.QueryPopUp -= new System.ComponentModel.CancelEventHandler(Control_QueryPopUp);

                    //}
                }
                catch (Exception)
                {
                }
            }
        }

        private void SubscribeToEvents()
        {
            foreach (LookupPropertyEditor lookup in View.GetItems<LookupPropertyEditor>())
            {
                // acc = acc + 1;
                // lookup.Control.KeyPress += new System.Windows.Forms.KeyPressEventArgs(Control_KeyPress);
                try
                {
                    //if (this.isChanged == true && acc > 1)
                    //{
                    lookup.Control.QueryPopUp += new System.ComponentModel.CancelEventHandler(Control_QueryPopUp);
                    // }
                }
                catch (Exception)
                {
                }
            }
        }
        private void Control_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LookupEdit l = (LookupEdit)sender;
            //CollectionSourceBase collectionSource = l.GetPopupFormCollectionSource();
            //if ( collectionSource.List.Count > 0 )
            {
                //if (lookupEdit.EditValue == null && collectionSource.List.Count == 1 && flagEnter == false)
                //{
                //    lookupEdit.EditValue = collectionSource.List[0];
                //    return;
                //}
                //if (lookupEdit.EditValue != null && collectionSource.List.Count > 0 && flagEnter == false)
                //{
                //Console.WriteLine("lookupedit " + lookupEdit.EditValue.ToString());

                if (this.isChanged == true)
                {
                    //l.ClosePopup();
                    ((LayoutControl)View.Control).SelectNextControl(l, true, true, true, true);
                    //flagEnter = true;
                    //collectionSource.Reload();
                    e.Cancel = true;
                    this.isChanged = false;
                }
                //else
                //{
                //    //collectionSource.Reload();
                //}

                // }
            }
        }

    }
}
