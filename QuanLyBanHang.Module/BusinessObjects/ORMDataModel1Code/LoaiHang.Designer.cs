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

    public partial class LoaiHang : XPLiteObject
    {
        int fId;
        [Key(true)]
        public int Id
        {
            get { return fId; }
            set { SetPropertyValue<int>("Id", ref fId, value); }
        }
        string fMa;
        [Indexed(Name = @"IX_LoaiHang", Unique = true)]
        [Size(50)]
        public string Ma
        {
            get { return fMa; }
            set { SetPropertyValue<string>("Ma", ref fMa, value); }
        }
        string fTen;
        [Indexed(Name = @"IX_LoaiHang_1", Unique = true)]
        [Size(200)]
        public string Ten
        {
            get { return fTen; }
            set { SetPropertyValue<string>("Ten", ref fTen, value); }
        }
        string fGhiChu;
        [Size(200)]
        public string GhiChu
        {
            get { return fGhiChu; }
            set { SetPropertyValue<string>("GhiChu", ref fGhiChu, value); }
        }
    }

}
