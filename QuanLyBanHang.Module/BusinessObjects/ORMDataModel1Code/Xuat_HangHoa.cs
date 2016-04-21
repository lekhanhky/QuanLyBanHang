using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace QuanLyBanHang.Module.BusinessObjects.QuanLyBanHang
{

    public partial class Xuat_HangHoa
    {
        public Xuat_HangHoa(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            if (!IsLoading && propertyName == "HangHoa_Id" && newValue != oldValue && newValue != null)
            {
                // this.HangHoa_Id.DonViTinh_Id = ((HangHoa)newValue).DonViTinh_Id;
                this.DonViTinh_Id = this.HangHoa_Id.DonViTinh_Id;
            }
        }
    }

}
