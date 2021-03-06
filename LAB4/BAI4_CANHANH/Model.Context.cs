﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BAI4_CANHANH
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class QLSV_CANHANEntities : DbContext
    {
        public QLSV_CANHANEntities()
            : base("name=QLSV_CANHANEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<LOP> LOPs { get; set; }
        public DbSet<NHANVIEN> NHANVIENs { get; set; }
        public DbSet<SINHVIEN> SINHVIENs { get; set; }
    
        public virtual int SP_INS_ENCRYPT_NHANVIEN(string mANV, string hOTEN, string eMAIL, string lUONG, string tENDN, string mATKHAU)
        {
            var mANVParameter = mANV != null ?
                new ObjectParameter("MANV", mANV) :
                new ObjectParameter("MANV", typeof(string));
    
            var hOTENParameter = hOTEN != null ?
                new ObjectParameter("HOTEN", hOTEN) :
                new ObjectParameter("HOTEN", typeof(string));
    
            var eMAILParameter = eMAIL != null ?
                new ObjectParameter("EMAIL", eMAIL) :
                new ObjectParameter("EMAIL", typeof(string));
    
            var lUONGParameter = lUONG != null ?
                new ObjectParameter("LUONG", lUONG) :
                new ObjectParameter("LUONG", typeof(string));
    
            var tENDNParameter = tENDN != null ?
                new ObjectParameter("TENDN", tENDN) :
                new ObjectParameter("TENDN", typeof(string));
    
            var mATKHAUParameter = mATKHAU != null ?
                new ObjectParameter("MATKHAU", mATKHAU) :
                new ObjectParameter("MATKHAU", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_INS_ENCRYPT_NHANVIEN", mANVParameter, hOTENParameter, eMAILParameter, lUONGParameter, tENDNParameter, mATKHAUParameter);
        }
    
        public virtual int SP_INS_ENCRYPT_SINHVIEN(string mASV, string hOTEN, Nullable<System.DateTime> nGAYSINH, string dIACHI, string mALOP, string tENDN, string mATKHAU)
        {
            var mASVParameter = mASV != null ?
                new ObjectParameter("MASV", mASV) :
                new ObjectParameter("MASV", typeof(string));
    
            var hOTENParameter = hOTEN != null ?
                new ObjectParameter("HOTEN", hOTEN) :
                new ObjectParameter("HOTEN", typeof(string));
    
            var nGAYSINHParameter = nGAYSINH.HasValue ?
                new ObjectParameter("NGAYSINH", nGAYSINH) :
                new ObjectParameter("NGAYSINH", typeof(System.DateTime));
    
            var dIACHIParameter = dIACHI != null ?
                new ObjectParameter("DIACHI", dIACHI) :
                new ObjectParameter("DIACHI", typeof(string));
    
            var mALOPParameter = mALOP != null ?
                new ObjectParameter("MALOP", mALOP) :
                new ObjectParameter("MALOP", typeof(string));
    
            var tENDNParameter = tENDN != null ?
                new ObjectParameter("TENDN", tENDN) :
                new ObjectParameter("TENDN", typeof(string));
    
            var mATKHAUParameter = mATKHAU != null ?
                new ObjectParameter("MATKHAU", mATKHAU) :
                new ObjectParameter("MATKHAU", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_INS_ENCRYPT_SINHVIEN", mASVParameter, hOTENParameter, nGAYSINHParameter, dIACHIParameter, mALOPParameter, tENDNParameter, mATKHAUParameter);
        }
    
        public virtual ObjectResult<SP_SEL_ENCRYPT_NHANVIEN_Result> SP_SEL_ENCRYPT_NHANVIEN()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_SEL_ENCRYPT_NHANVIEN_Result>("SP_SEL_ENCRYPT_NHANVIEN");
        }
    
        public virtual ObjectResult<FIND_NV_Result> FIND_NV(string mANV)
        {
            var mANVParameter = mANV != null ?
                new ObjectParameter("MANV", mANV) :
                new ObjectParameter("MANV", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FIND_NV_Result>("FIND_NV", mANVParameter);
        }
    
        public virtual int UPDATE_NV(string mANV, string hOTEN, string eMAIL, string lUONG, string tENDN, string mATKHAU)
        {
            var mANVParameter = mANV != null ?
                new ObjectParameter("MANV", mANV) :
                new ObjectParameter("MANV", typeof(string));
    
            var hOTENParameter = hOTEN != null ?
                new ObjectParameter("HOTEN", hOTEN) :
                new ObjectParameter("HOTEN", typeof(string));
    
            var eMAILParameter = eMAIL != null ?
                new ObjectParameter("EMAIL", eMAIL) :
                new ObjectParameter("EMAIL", typeof(string));
    
            var lUONGParameter = lUONG != null ?
                new ObjectParameter("LUONG", lUONG) :
                new ObjectParameter("LUONG", typeof(string));
    
            var tENDNParameter = tENDN != null ?
                new ObjectParameter("TENDN", tENDN) :
                new ObjectParameter("TENDN", typeof(string));
    
            var mATKHAUParameter = mATKHAU != null ?
                new ObjectParameter("MATKHAU", mATKHAU) :
                new ObjectParameter("MATKHAU", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UPDATE_NV", mANVParameter, hOTENParameter, eMAILParameter, lUONGParameter, tENDNParameter, mATKHAUParameter);
        }
    
        public virtual ObjectResult<LOGIN_NV_Result> LOGIN_NV(string mANV, string pASSWORD)
        {
            var mANVParameter = mANV != null ?
                new ObjectParameter("MANV", mANV) :
                new ObjectParameter("MANV", typeof(string));
    
            var pASSWORDParameter = pASSWORD != null ?
                new ObjectParameter("PASSWORD", pASSWORD) :
                new ObjectParameter("PASSWORD", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LOGIN_NV_Result>("LOGIN_NV", mANVParameter, pASSWORDParameter);
        }
    
        public virtual ObjectResult<LOGIN_SV_Result> LOGIN_SV(string mANV, string pASSWORD)
        {
            var mANVParameter = mANV != null ?
                new ObjectParameter("MANV", mANV) :
                new ObjectParameter("MANV", typeof(string));
    
            var pASSWORDParameter = pASSWORD != null ?
                new ObjectParameter("PASSWORD", pASSWORD) :
                new ObjectParameter("PASSWORD", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LOGIN_SV_Result>("LOGIN_SV", mANVParameter, pASSWORDParameter);
        }
    }
}
