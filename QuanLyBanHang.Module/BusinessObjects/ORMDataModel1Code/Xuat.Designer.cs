﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace QuanLyBanHang.Module.BusinessObjects.QuanLyBanHang
{

    public partial class Xuat : XPLiteObject
    {
        int fId;
        [Key(true)]
        [MemberDesignTimeVisibility(false)]
        public int Id
        {
            get { return fId; }
            set { SetPropertyValue<int>("Id", ref fId, value); }
        }
        string fMa;
        [Size(50)]
        [DevExpress.Xpo.DisplayName(@"Mã")]
        public string Ma
        {
            get { return fMa; }
            set { SetPropertyValue<string>("Ma", ref fMa, value); }
        }
        DateTime fNgayTao;
        [DevExpress.Xpo.DisplayName(@"Ngày tạo")]
        public DateTime NgayTao
        {
            get { return fNgayTao; }
            set { SetPropertyValue<DateTime>("NgayTao", ref fNgayTao, value); }
        }
        DateTime fNgayHoaDon;
        [DevExpress.Xpo.DisplayName(@"Ngày hóa đơn")]
        public DateTime NgayHoaDon
        {
            get { return fNgayHoaDon; }
            set { SetPropertyValue<DateTime>("NgayHoaDon", ref fNgayHoaDon, value); }
        }
        string fSoHoaDon;
        [Size(50)]
        [DevExpress.Xpo.DisplayName(@"Số hóa đơn")]
        public string SoHoaDon
        {
            get { return fSoHoaDon; }
            set { SetPropertyValue<string>("SoHoaDon", ref fSoHoaDon, value); }
        }
        DoiTuong fDoiTuong_Id;
        [Association(@"XuatReferencesDoiTuong")]
        [DevExpress.Xpo.DisplayName(@"Khách hàng")]
        public DoiTuong DoiTuong_Id
        {
            get { return fDoiTuong_Id; }
            set { SetPropertyValue<DoiTuong>("DoiTuong_Id", ref fDoiTuong_Id, value); }
        }
        string fGhiChu;
        [Size(200)]
        [DevExpress.Xpo.DisplayName(@"Ghi chú")]
        public string GhiChu
        {
            get { return fGhiChu; }
            set { SetPropertyValue<string>("GhiChu", ref fGhiChu, value); }
        }
        [Association(@"Xuat_HangHoaReferencesXuat")]
        public XPCollection<Xuat_HangHoa> Xuat_HangHoas { get { return GetCollection<Xuat_HangHoa>("Xuat_HangHoas"); } }
    }

}
