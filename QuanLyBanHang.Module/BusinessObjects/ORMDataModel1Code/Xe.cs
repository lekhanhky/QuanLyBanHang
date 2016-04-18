using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace QuanLyBanHang.Module.BusinessObjects.QuanLyBanHang
{

    public partial class Xe
    {
        public Xe(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
