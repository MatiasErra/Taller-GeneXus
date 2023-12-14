using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "producto" )]
   [XmlType(TypeName =  "producto" , Namespace = "xd2" )]
   [Serializable]
   public class Sdtproducto : GxSilentTrnSdt
   {
      public Sdtproducto( )
      {
      }

      public Sdtproducto( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( short AV5productoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV5productoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"productoId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "producto");
         metadata.Set("BT", "producto");
         metadata.Set("PK", "[ \"productoId\" ]");
         metadata.Set("PKAssigned", "[ \"productoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"proveedorId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"tipoDeProductoId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Productoimage_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Productoid_Z");
         state.Add("gxTpr_Productoname_Z");
         state.Add("gxTpr_Productosellprice_Z");
         state.Add("gxTpr_Productocostprice_Z");
         state.Add("gxTpr_Proveedorid_Z");
         state.Add("gxTpr_Proveedorname_Z");
         state.Add("gxTpr_Tipodeproductoid_Z");
         state.Add("gxTpr_Tipodeproductoname_Z");
         state.Add("gxTpr_Productoimage_gxi_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         Sdtproducto sdt;
         sdt = (Sdtproducto)(source);
         gxTv_Sdtproducto_Productoid = sdt.gxTv_Sdtproducto_Productoid ;
         gxTv_Sdtproducto_Productoname = sdt.gxTv_Sdtproducto_Productoname ;
         gxTv_Sdtproducto_Productoimage = sdt.gxTv_Sdtproducto_Productoimage ;
         gxTv_Sdtproducto_Productoimage_gxi = sdt.gxTv_Sdtproducto_Productoimage_gxi ;
         gxTv_Sdtproducto_Productosellprice = sdt.gxTv_Sdtproducto_Productosellprice ;
         gxTv_Sdtproducto_Productocostprice = sdt.gxTv_Sdtproducto_Productocostprice ;
         gxTv_Sdtproducto_Proveedorid = sdt.gxTv_Sdtproducto_Proveedorid ;
         gxTv_Sdtproducto_Proveedorname = sdt.gxTv_Sdtproducto_Proveedorname ;
         gxTv_Sdtproducto_Tipodeproductoid = sdt.gxTv_Sdtproducto_Tipodeproductoid ;
         gxTv_Sdtproducto_Tipodeproductoname = sdt.gxTv_Sdtproducto_Tipodeproductoname ;
         gxTv_Sdtproducto_Mode = sdt.gxTv_Sdtproducto_Mode ;
         gxTv_Sdtproducto_Initialized = sdt.gxTv_Sdtproducto_Initialized ;
         gxTv_Sdtproducto_Productoid_Z = sdt.gxTv_Sdtproducto_Productoid_Z ;
         gxTv_Sdtproducto_Productoname_Z = sdt.gxTv_Sdtproducto_Productoname_Z ;
         gxTv_Sdtproducto_Productosellprice_Z = sdt.gxTv_Sdtproducto_Productosellprice_Z ;
         gxTv_Sdtproducto_Productocostprice_Z = sdt.gxTv_Sdtproducto_Productocostprice_Z ;
         gxTv_Sdtproducto_Proveedorid_Z = sdt.gxTv_Sdtproducto_Proveedorid_Z ;
         gxTv_Sdtproducto_Proveedorname_Z = sdt.gxTv_Sdtproducto_Proveedorname_Z ;
         gxTv_Sdtproducto_Tipodeproductoid_Z = sdt.gxTv_Sdtproducto_Tipodeproductoid_Z ;
         gxTv_Sdtproducto_Tipodeproductoname_Z = sdt.gxTv_Sdtproducto_Tipodeproductoname_Z ;
         gxTv_Sdtproducto_Productoimage_gxi_Z = sdt.gxTv_Sdtproducto_Productoimage_gxi_Z ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("productoId", gxTv_Sdtproducto_Productoid, false, includeNonInitialized);
         AddObjectProperty("productoName", gxTv_Sdtproducto_Productoname, false, includeNonInitialized);
         AddObjectProperty("productoImage", gxTv_Sdtproducto_Productoimage, false, includeNonInitialized);
         AddObjectProperty("productoSellPrice", gxTv_Sdtproducto_Productosellprice, false, includeNonInitialized);
         AddObjectProperty("productoCostPrice", gxTv_Sdtproducto_Productocostprice, false, includeNonInitialized);
         AddObjectProperty("proveedorId", gxTv_Sdtproducto_Proveedorid, false, includeNonInitialized);
         AddObjectProperty("proveedorName", gxTv_Sdtproducto_Proveedorname, false, includeNonInitialized);
         AddObjectProperty("tipoDeProductoId", gxTv_Sdtproducto_Tipodeproductoid, false, includeNonInitialized);
         AddObjectProperty("tipoDeProductoName", gxTv_Sdtproducto_Tipodeproductoname, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("productoImage_GXI", gxTv_Sdtproducto_Productoimage_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_Sdtproducto_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_Sdtproducto_Initialized, false, includeNonInitialized);
            AddObjectProperty("productoId_Z", gxTv_Sdtproducto_Productoid_Z, false, includeNonInitialized);
            AddObjectProperty("productoName_Z", gxTv_Sdtproducto_Productoname_Z, false, includeNonInitialized);
            AddObjectProperty("productoSellPrice_Z", gxTv_Sdtproducto_Productosellprice_Z, false, includeNonInitialized);
            AddObjectProperty("productoCostPrice_Z", gxTv_Sdtproducto_Productocostprice_Z, false, includeNonInitialized);
            AddObjectProperty("proveedorId_Z", gxTv_Sdtproducto_Proveedorid_Z, false, includeNonInitialized);
            AddObjectProperty("proveedorName_Z", gxTv_Sdtproducto_Proveedorname_Z, false, includeNonInitialized);
            AddObjectProperty("tipoDeProductoId_Z", gxTv_Sdtproducto_Tipodeproductoid_Z, false, includeNonInitialized);
            AddObjectProperty("tipoDeProductoName_Z", gxTv_Sdtproducto_Tipodeproductoname_Z, false, includeNonInitialized);
            AddObjectProperty("productoImage_GXI_Z", gxTv_Sdtproducto_Productoimage_gxi_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( Sdtproducto sdt )
      {
         if ( sdt.IsDirty("productoId") )
         {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Productoid = sdt.gxTv_Sdtproducto_Productoid ;
         }
         if ( sdt.IsDirty("productoName") )
         {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Productoname = sdt.gxTv_Sdtproducto_Productoname ;
         }
         if ( sdt.IsDirty("productoImage") )
         {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Productoimage = sdt.gxTv_Sdtproducto_Productoimage ;
         }
         if ( sdt.IsDirty("productoImage") )
         {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Productoimage_gxi = sdt.gxTv_Sdtproducto_Productoimage_gxi ;
         }
         if ( sdt.IsDirty("productoSellPrice") )
         {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Productosellprice = sdt.gxTv_Sdtproducto_Productosellprice ;
         }
         if ( sdt.IsDirty("productoCostPrice") )
         {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Productocostprice = sdt.gxTv_Sdtproducto_Productocostprice ;
         }
         if ( sdt.IsDirty("proveedorId") )
         {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Proveedorid = sdt.gxTv_Sdtproducto_Proveedorid ;
         }
         if ( sdt.IsDirty("proveedorName") )
         {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Proveedorname = sdt.gxTv_Sdtproducto_Proveedorname ;
         }
         if ( sdt.IsDirty("tipoDeProductoId") )
         {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Tipodeproductoid = sdt.gxTv_Sdtproducto_Tipodeproductoid ;
         }
         if ( sdt.IsDirty("tipoDeProductoName") )
         {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Tipodeproductoname = sdt.gxTv_Sdtproducto_Tipodeproductoname ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "productoId" )]
      [  XmlElement( ElementName = "productoId"   )]
      public short gxTpr_Productoid
      {
         get {
            return gxTv_Sdtproducto_Productoid ;
         }

         set {
            gxTv_Sdtproducto_N = 0;
            if ( gxTv_Sdtproducto_Productoid != value )
            {
               gxTv_Sdtproducto_Mode = "INS";
               this.gxTv_Sdtproducto_Productoid_Z_SetNull( );
               this.gxTv_Sdtproducto_Productoname_Z_SetNull( );
               this.gxTv_Sdtproducto_Productosellprice_Z_SetNull( );
               this.gxTv_Sdtproducto_Productocostprice_Z_SetNull( );
               this.gxTv_Sdtproducto_Proveedorid_Z_SetNull( );
               this.gxTv_Sdtproducto_Proveedorname_Z_SetNull( );
               this.gxTv_Sdtproducto_Tipodeproductoid_Z_SetNull( );
               this.gxTv_Sdtproducto_Tipodeproductoname_Z_SetNull( );
               this.gxTv_Sdtproducto_Productoimage_gxi_Z_SetNull( );
            }
            gxTv_Sdtproducto_Productoid = value;
            SetDirty("Productoid");
         }

      }

      [  SoapElement( ElementName = "productoName" )]
      [  XmlElement( ElementName = "productoName"   )]
      public string gxTpr_Productoname
      {
         get {
            return gxTv_Sdtproducto_Productoname ;
         }

         set {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Productoname = value;
            SetDirty("Productoname");
         }

      }

      [  SoapElement( ElementName = "productoImage" )]
      [  XmlElement( ElementName = "productoImage"   )]
      [GxUpload()]
      public string gxTpr_Productoimage
      {
         get {
            return gxTv_Sdtproducto_Productoimage ;
         }

         set {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Productoimage = value;
            SetDirty("Productoimage");
         }

      }

      [  SoapElement( ElementName = "productoImage_GXI" )]
      [  XmlElement( ElementName = "productoImage_GXI"   )]
      public string gxTpr_Productoimage_gxi
      {
         get {
            return gxTv_Sdtproducto_Productoimage_gxi ;
         }

         set {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Productoimage_gxi = value;
            SetDirty("Productoimage_gxi");
         }

      }

      [  SoapElement( ElementName = "productoSellPrice" )]
      [  XmlElement( ElementName = "productoSellPrice"   )]
      public decimal gxTpr_Productosellprice
      {
         get {
            return gxTv_Sdtproducto_Productosellprice ;
         }

         set {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Productosellprice = value;
            SetDirty("Productosellprice");
         }

      }

      [  SoapElement( ElementName = "productoCostPrice" )]
      [  XmlElement( ElementName = "productoCostPrice"   )]
      public decimal gxTpr_Productocostprice
      {
         get {
            return gxTv_Sdtproducto_Productocostprice ;
         }

         set {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Productocostprice = value;
            SetDirty("Productocostprice");
         }

      }

      [  SoapElement( ElementName = "proveedorId" )]
      [  XmlElement( ElementName = "proveedorId"   )]
      public short gxTpr_Proveedorid
      {
         get {
            return gxTv_Sdtproducto_Proveedorid ;
         }

         set {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Proveedorid = value;
            SetDirty("Proveedorid");
         }

      }

      [  SoapElement( ElementName = "proveedorName" )]
      [  XmlElement( ElementName = "proveedorName"   )]
      public string gxTpr_Proveedorname
      {
         get {
            return gxTv_Sdtproducto_Proveedorname ;
         }

         set {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Proveedorname = value;
            SetDirty("Proveedorname");
         }

      }

      [  SoapElement( ElementName = "tipoDeProductoId" )]
      [  XmlElement( ElementName = "tipoDeProductoId"   )]
      public short gxTpr_Tipodeproductoid
      {
         get {
            return gxTv_Sdtproducto_Tipodeproductoid ;
         }

         set {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Tipodeproductoid = value;
            SetDirty("Tipodeproductoid");
         }

      }

      [  SoapElement( ElementName = "tipoDeProductoName" )]
      [  XmlElement( ElementName = "tipoDeProductoName"   )]
      public string gxTpr_Tipodeproductoname
      {
         get {
            return gxTv_Sdtproducto_Tipodeproductoname ;
         }

         set {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Tipodeproductoname = value;
            SetDirty("Tipodeproductoname");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_Sdtproducto_Mode ;
         }

         set {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_Sdtproducto_Mode_SetNull( )
      {
         gxTv_Sdtproducto_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_Sdtproducto_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_Sdtproducto_Initialized ;
         }

         set {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_Sdtproducto_Initialized_SetNull( )
      {
         gxTv_Sdtproducto_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_Sdtproducto_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "productoId_Z" )]
      [  XmlElement( ElementName = "productoId_Z"   )]
      public short gxTpr_Productoid_Z
      {
         get {
            return gxTv_Sdtproducto_Productoid_Z ;
         }

         set {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Productoid_Z = value;
            SetDirty("Productoid_Z");
         }

      }

      public void gxTv_Sdtproducto_Productoid_Z_SetNull( )
      {
         gxTv_Sdtproducto_Productoid_Z = 0;
         SetDirty("Productoid_Z");
         return  ;
      }

      public bool gxTv_Sdtproducto_Productoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "productoName_Z" )]
      [  XmlElement( ElementName = "productoName_Z"   )]
      public string gxTpr_Productoname_Z
      {
         get {
            return gxTv_Sdtproducto_Productoname_Z ;
         }

         set {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Productoname_Z = value;
            SetDirty("Productoname_Z");
         }

      }

      public void gxTv_Sdtproducto_Productoname_Z_SetNull( )
      {
         gxTv_Sdtproducto_Productoname_Z = "";
         SetDirty("Productoname_Z");
         return  ;
      }

      public bool gxTv_Sdtproducto_Productoname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "productoSellPrice_Z" )]
      [  XmlElement( ElementName = "productoSellPrice_Z"   )]
      public decimal gxTpr_Productosellprice_Z
      {
         get {
            return gxTv_Sdtproducto_Productosellprice_Z ;
         }

         set {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Productosellprice_Z = value;
            SetDirty("Productosellprice_Z");
         }

      }

      public void gxTv_Sdtproducto_Productosellprice_Z_SetNull( )
      {
         gxTv_Sdtproducto_Productosellprice_Z = 0;
         SetDirty("Productosellprice_Z");
         return  ;
      }

      public bool gxTv_Sdtproducto_Productosellprice_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "productoCostPrice_Z" )]
      [  XmlElement( ElementName = "productoCostPrice_Z"   )]
      public decimal gxTpr_Productocostprice_Z
      {
         get {
            return gxTv_Sdtproducto_Productocostprice_Z ;
         }

         set {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Productocostprice_Z = value;
            SetDirty("Productocostprice_Z");
         }

      }

      public void gxTv_Sdtproducto_Productocostprice_Z_SetNull( )
      {
         gxTv_Sdtproducto_Productocostprice_Z = 0;
         SetDirty("Productocostprice_Z");
         return  ;
      }

      public bool gxTv_Sdtproducto_Productocostprice_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "proveedorId_Z" )]
      [  XmlElement( ElementName = "proveedorId_Z"   )]
      public short gxTpr_Proveedorid_Z
      {
         get {
            return gxTv_Sdtproducto_Proveedorid_Z ;
         }

         set {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Proveedorid_Z = value;
            SetDirty("Proveedorid_Z");
         }

      }

      public void gxTv_Sdtproducto_Proveedorid_Z_SetNull( )
      {
         gxTv_Sdtproducto_Proveedorid_Z = 0;
         SetDirty("Proveedorid_Z");
         return  ;
      }

      public bool gxTv_Sdtproducto_Proveedorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "proveedorName_Z" )]
      [  XmlElement( ElementName = "proveedorName_Z"   )]
      public string gxTpr_Proveedorname_Z
      {
         get {
            return gxTv_Sdtproducto_Proveedorname_Z ;
         }

         set {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Proveedorname_Z = value;
            SetDirty("Proveedorname_Z");
         }

      }

      public void gxTv_Sdtproducto_Proveedorname_Z_SetNull( )
      {
         gxTv_Sdtproducto_Proveedorname_Z = "";
         SetDirty("Proveedorname_Z");
         return  ;
      }

      public bool gxTv_Sdtproducto_Proveedorname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "tipoDeProductoId_Z" )]
      [  XmlElement( ElementName = "tipoDeProductoId_Z"   )]
      public short gxTpr_Tipodeproductoid_Z
      {
         get {
            return gxTv_Sdtproducto_Tipodeproductoid_Z ;
         }

         set {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Tipodeproductoid_Z = value;
            SetDirty("Tipodeproductoid_Z");
         }

      }

      public void gxTv_Sdtproducto_Tipodeproductoid_Z_SetNull( )
      {
         gxTv_Sdtproducto_Tipodeproductoid_Z = 0;
         SetDirty("Tipodeproductoid_Z");
         return  ;
      }

      public bool gxTv_Sdtproducto_Tipodeproductoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "tipoDeProductoName_Z" )]
      [  XmlElement( ElementName = "tipoDeProductoName_Z"   )]
      public string gxTpr_Tipodeproductoname_Z
      {
         get {
            return gxTv_Sdtproducto_Tipodeproductoname_Z ;
         }

         set {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Tipodeproductoname_Z = value;
            SetDirty("Tipodeproductoname_Z");
         }

      }

      public void gxTv_Sdtproducto_Tipodeproductoname_Z_SetNull( )
      {
         gxTv_Sdtproducto_Tipodeproductoname_Z = "";
         SetDirty("Tipodeproductoname_Z");
         return  ;
      }

      public bool gxTv_Sdtproducto_Tipodeproductoname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "productoImage_GXI_Z" )]
      [  XmlElement( ElementName = "productoImage_GXI_Z"   )]
      public string gxTpr_Productoimage_gxi_Z
      {
         get {
            return gxTv_Sdtproducto_Productoimage_gxi_Z ;
         }

         set {
            gxTv_Sdtproducto_N = 0;
            gxTv_Sdtproducto_Productoimage_gxi_Z = value;
            SetDirty("Productoimage_gxi_Z");
         }

      }

      public void gxTv_Sdtproducto_Productoimage_gxi_Z_SetNull( )
      {
         gxTv_Sdtproducto_Productoimage_gxi_Z = "";
         SetDirty("Productoimage_gxi_Z");
         return  ;
      }

      public bool gxTv_Sdtproducto_Productoimage_gxi_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_Sdtproducto_N = 1;
         gxTv_Sdtproducto_Productoname = "";
         gxTv_Sdtproducto_Productoimage = "";
         gxTv_Sdtproducto_Productoimage_gxi = "";
         gxTv_Sdtproducto_Proveedorname = "";
         gxTv_Sdtproducto_Tipodeproductoname = "";
         gxTv_Sdtproducto_Mode = "";
         gxTv_Sdtproducto_Productoname_Z = "";
         gxTv_Sdtproducto_Proveedorname_Z = "";
         gxTv_Sdtproducto_Tipodeproductoname_Z = "";
         gxTv_Sdtproducto_Productoimage_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "producto", "GeneXus.Programs.producto_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_Sdtproducto_N ;
      }

      private short gxTv_Sdtproducto_Productoid ;
      private short gxTv_Sdtproducto_N ;
      private short gxTv_Sdtproducto_Proveedorid ;
      private short gxTv_Sdtproducto_Tipodeproductoid ;
      private short gxTv_Sdtproducto_Initialized ;
      private short gxTv_Sdtproducto_Productoid_Z ;
      private short gxTv_Sdtproducto_Proveedorid_Z ;
      private short gxTv_Sdtproducto_Tipodeproductoid_Z ;
      private decimal gxTv_Sdtproducto_Productosellprice ;
      private decimal gxTv_Sdtproducto_Productocostprice ;
      private decimal gxTv_Sdtproducto_Productosellprice_Z ;
      private decimal gxTv_Sdtproducto_Productocostprice_Z ;
      private string gxTv_Sdtproducto_Mode ;
      private string gxTv_Sdtproducto_Productoname ;
      private string gxTv_Sdtproducto_Productoimage_gxi ;
      private string gxTv_Sdtproducto_Proveedorname ;
      private string gxTv_Sdtproducto_Tipodeproductoname ;
      private string gxTv_Sdtproducto_Productoname_Z ;
      private string gxTv_Sdtproducto_Proveedorname_Z ;
      private string gxTv_Sdtproducto_Tipodeproductoname_Z ;
      private string gxTv_Sdtproducto_Productoimage_gxi_Z ;
      private string gxTv_Sdtproducto_Productoimage ;
   }

   [DataContract(Name = @"producto", Namespace = "xd2")]
   public class Sdtproducto_RESTInterface : GxGenericCollectionItem<Sdtproducto>
   {
      public Sdtproducto_RESTInterface( ) : base()
      {
      }

      public Sdtproducto_RESTInterface( Sdtproducto psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "productoId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Productoid
      {
         get {
            return sdt.gxTpr_Productoid ;
         }

         set {
            sdt.gxTpr_Productoid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "productoName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Productoname
      {
         get {
            return sdt.gxTpr_Productoname ;
         }

         set {
            sdt.gxTpr_Productoname = value;
         }

      }

      [DataMember( Name = "productoImage" , Order = 2 )]
      [GxUpload()]
      public string gxTpr_Productoimage
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Productoimage)) ? PathUtil.RelativeURL( sdt.gxTpr_Productoimage) : StringUtil.RTrim( sdt.gxTpr_Productoimage_gxi)) ;
         }

         set {
            sdt.gxTpr_Productoimage = value;
         }

      }

      [DataMember( Name = "productoSellPrice" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Productosellprice
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Productosellprice, 10, 2)) ;
         }

         set {
            sdt.gxTpr_Productosellprice = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "productoCostPrice" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Productocostprice
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Productocostprice, 10, 2)) ;
         }

         set {
            sdt.gxTpr_Productocostprice = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "proveedorId" , Order = 5 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Proveedorid
      {
         get {
            return sdt.gxTpr_Proveedorid ;
         }

         set {
            sdt.gxTpr_Proveedorid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "proveedorName" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Proveedorname
      {
         get {
            return sdt.gxTpr_Proveedorname ;
         }

         set {
            sdt.gxTpr_Proveedorname = value;
         }

      }

      [DataMember( Name = "tipoDeProductoId" , Order = 7 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Tipodeproductoid
      {
         get {
            return sdt.gxTpr_Tipodeproductoid ;
         }

         set {
            sdt.gxTpr_Tipodeproductoid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "tipoDeProductoName" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Tipodeproductoname
      {
         get {
            return sdt.gxTpr_Tipodeproductoname ;
         }

         set {
            sdt.gxTpr_Tipodeproductoname = value;
         }

      }

      public Sdtproducto sdt
      {
         get {
            return (Sdtproducto)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new Sdtproducto() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 9 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"producto", Namespace = "xd2")]
   public class Sdtproducto_RESTLInterface : GxGenericCollectionItem<Sdtproducto>
   {
      public Sdtproducto_RESTLInterface( ) : base()
      {
      }

      public Sdtproducto_RESTLInterface( Sdtproducto psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "productoName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Productoname
      {
         get {
            return sdt.gxTpr_Productoname ;
         }

         set {
            sdt.gxTpr_Productoname = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public Sdtproducto sdt
      {
         get {
            return (Sdtproducto)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new Sdtproducto() ;
         }
      }

   }

}
