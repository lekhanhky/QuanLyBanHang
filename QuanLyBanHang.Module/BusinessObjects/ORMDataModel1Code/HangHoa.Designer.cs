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

    public partial class HangHoa : XPLiteObject
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
        [Indexed(Name = @"IX_HangHoa", Unique = true)]
        [Size(50)]
        [DevExpress.Xpo.DisplayName(@"Mã")]
        public string Ma
        {
            get { return fMa; }
            set { SetPropertyValue<string>("Ma", ref fMa, value); }
        }
        string fMa1;
        [Indexed(Name = @"IX_HangHoa_2", Unique = true)]
        [Size(50)]
        [DevExpress.Xpo.DisplayName(@"Mã 1")]
        public string Ma1
        {
            get { return fMa1; }
            set { SetPropertyValue<string>("Ma1", ref fMa1, value); }
        }
        string fMa2;
        [Indexed(Name = @"IX_HangHoa_3", Unique = true)]
        [Size(50)]
        [DevExpress.Xpo.DisplayName(@"Mã 2")]
        public string Ma2
        {
            get { return fMa2; }
            set { SetPropertyValue<string>("Ma2", ref fMa2, value); }
        }
        string fMaVach;
        [Size(50)]
        [DevExpress.Xpo.DisplayName(@"Mã vạch")]
        public string MaVach
        {
            get { return fMaVach; }
            set { SetPropertyValue<string>("MaVach", ref fMaVach, value); }
        }
        string fTen;
        [Indexed(Name = @"IX_HangHoa_1", Unique = true)]
        [Size(200)]
        [DevExpress.Xpo.DisplayName(@"Tên")]
        public string Ten
        {
            get { return fTen; }
            set { SetPropertyValue<string>("Ten", ref fTen, value); }
        }
        DonViTinh fDonViTinh_Id;
        [Association(@"HangHoaReferencesDonViTinh")]
        [DevExpress.Xpo.DisplayName(@"Đơn vị tính")]
        public DonViTinh DonViTinh_Id
        {
            get { return fDonViTinh_Id; }
            set { SetPropertyValue<DonViTinh>("DonViTinh_Id", ref fDonViTinh_Id, value); }
        }
        decimal fGia;
        [DevExpress.Xpo.DisplayName(@"Giá")]
        public decimal Gia
        {
            get { return fGia; }
            set { SetPropertyValue<decimal>("Gia", ref fGia, value); }
        }
        string fGhiChu;
        [Size(200)]
        [DevExpress.Xpo.DisplayName(@"Ghi chú")]
        public string GhiChu
        {
            get { return fGhiChu; }
            set { SetPropertyValue<string>("GhiChu", ref fGhiChu, value); }
        }
        bool fSuDung;
        [DevExpress.Xpo.DisplayName(@"Sử dụng")]
        public bool SuDung
        {
            get { return fSuDung; }
            set { SetPropertyValue<bool>("SuDung", ref fSuDung, value); }
        }
        LoaiHang fLoaiHang_Id;
        [Association(@"HangHoaReferencesLoaiHang")]
        [DevExpress.Xpo.DisplayName(@"Loại hàng")]
        public LoaiHang LoaiHang_Id
        {
            get { return fLoaiHang_Id; }
            set { SetPropertyValue<LoaiHang>("LoaiHang_Id", ref fLoaiHang_Id, value); }
        }
        [Association(@"Nhap_HangHoaReferencesHangHoa")]
        public XPCollection<Nhap_HangHoa> Nhap_HangHoas { get { return GetCollection<Nhap_HangHoa>("Nhap_HangHoas"); } }
        [Association(@"NhapDauKy_HangHoaReferencesHangHoa")]
        public XPCollection<NhapDauKy_HangHoa> NhapDauKy_HangHoas { get { return GetCollection<NhapDauKy_HangHoa>("NhapDauKy_HangHoas"); } }
        [Association(@"Xuat_HangHoaReferencesHangHoa")]
        public XPCollection<Xuat_HangHoa> Xuat_HangHoas { get { return GetCollection<Xuat_HangHoa>("Xuat_HangHoas"); } }
    }

}
