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

    public partial class Kho : XPLiteObject
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
        [Indexed(Name = @"IX_Kho", Unique = true)]
        [Size(50)]
        [DevExpress.Xpo.DisplayName(@"Mã")]
        public string Ma
        {
            get { return fMa; }
            set { SetPropertyValue<string>("Ma", ref fMa, value); }
        }
        string fTen;
        [Indexed(Name = @"IX_Kho_1", Unique = true)]
        [Size(200)]
        [DevExpress.Xpo.DisplayName(@"Tên")]
        public string Ten
        {
            get { return fTen; }
            set { SetPropertyValue<string>("Ten", ref fTen, value); }
        }
        string fGhiChu;
        [Size(200)]
        [DevExpress.Xpo.DisplayName(@"Ghi chú")]
        public string GhiChu
        {
            get { return fGhiChu; }
            set { SetPropertyValue<string>("GhiChu", ref fGhiChu, value); }
        }
        string fDienThoai;
        [Size(50)]
        [DevExpress.Xpo.DisplayName(@"Điện thoại")]
        public string DienThoai
        {
            get { return fDienThoai; }
            set { SetPropertyValue<string>("DienThoai", ref fDienThoai, value); }
        }
        string fDiaChi;
        [Size(200)]
        [DevExpress.Xpo.DisplayName(@"Địa chỉ")]
        public string DiaChi
        {
            get { return fDiaChi; }
            set { SetPropertyValue<string>("DiaChi", ref fDiaChi, value); }
        }
    }

}
