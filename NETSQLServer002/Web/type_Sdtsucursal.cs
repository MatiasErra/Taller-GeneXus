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
   [XmlRoot(ElementName = "sucursal" )]
   [XmlType(TypeName =  "sucursal" , Namespace = "xd2" )]
   [Serializable]
   public class Sdtsucursal : GxSilentTrnSdt
   {
      public Sdtsucursal( )
      {
      }

      public Sdtsucursal( IGxContext context )
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

      public void Load( short AV2sucursalId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV2sucursalId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"sucursalId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "sucursal");
         metadata.Set("BT", "sucursal");
         metadata.Set("PK", "[ \"sucursalId\" ]");
         metadata.Set("PKAssigned", "[ \"sucursalId\" ]");
         metadata.Set("Levels", "[ \"producto\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"empleadoId\" ],\"FKMap\":[ \"sucursalEmpleadoAlternateId-empleadoId\" ] },{ \"FK\":[ \"empleadoId\" ],\"FKMap\":[ \"sucursalEmpleadoHeadlineId-empleadoId\" ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Sucursalid_Z");
         state.Add("gxTpr_Sucursalname_Z");
         state.Add("gxTpr_Sucursaladdress_Z");
         state.Add("gxTpr_Sucursalgeolocation_Z");
         state.Add("gxTpr_Sucursaladdeddate_Z_Nullable");
         state.Add("gxTpr_Sucursalempleadoheadlineid_Z");
         state.Add("gxTpr_Sucursalempleadoheadlinename_Z");
         state.Add("gxTpr_Sucursalempleadoalternateid_Z");
         state.Add("gxTpr_Sucursalempleadoalternatename_Z");
         state.Add("gxTpr_Sucursalempleadoalternateid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         Sdtsucursal sdt;
         sdt = (Sdtsucursal)(source);
         gxTv_Sdtsucursal_Sucursalid = sdt.gxTv_Sdtsucursal_Sucursalid ;
         gxTv_Sdtsucursal_Sucursalname = sdt.gxTv_Sdtsucursal_Sucursalname ;
         gxTv_Sdtsucursal_Sucursaladdress = sdt.gxTv_Sdtsucursal_Sucursaladdress ;
         gxTv_Sdtsucursal_Sucursalgeolocation = sdt.gxTv_Sdtsucursal_Sucursalgeolocation ;
         gxTv_Sdtsucursal_Sucursaladdeddate = sdt.gxTv_Sdtsucursal_Sucursaladdeddate ;
         gxTv_Sdtsucursal_Sucursalempleadoheadlineid = sdt.gxTv_Sdtsucursal_Sucursalempleadoheadlineid ;
         gxTv_Sdtsucursal_Sucursalempleadoheadlinename = sdt.gxTv_Sdtsucursal_Sucursalempleadoheadlinename ;
         gxTv_Sdtsucursal_Sucursalempleadoalternateid = sdt.gxTv_Sdtsucursal_Sucursalempleadoalternateid ;
         gxTv_Sdtsucursal_Sucursalempleadoalternatename = sdt.gxTv_Sdtsucursal_Sucursalempleadoalternatename ;
         gxTv_Sdtsucursal_Producto = sdt.gxTv_Sdtsucursal_Producto ;
         gxTv_Sdtsucursal_Mode = sdt.gxTv_Sdtsucursal_Mode ;
         gxTv_Sdtsucursal_Initialized = sdt.gxTv_Sdtsucursal_Initialized ;
         gxTv_Sdtsucursal_Sucursalid_Z = sdt.gxTv_Sdtsucursal_Sucursalid_Z ;
         gxTv_Sdtsucursal_Sucursalname_Z = sdt.gxTv_Sdtsucursal_Sucursalname_Z ;
         gxTv_Sdtsucursal_Sucursaladdress_Z = sdt.gxTv_Sdtsucursal_Sucursaladdress_Z ;
         gxTv_Sdtsucursal_Sucursalgeolocation_Z = sdt.gxTv_Sdtsucursal_Sucursalgeolocation_Z ;
         gxTv_Sdtsucursal_Sucursaladdeddate_Z = sdt.gxTv_Sdtsucursal_Sucursaladdeddate_Z ;
         gxTv_Sdtsucursal_Sucursalempleadoheadlineid_Z = sdt.gxTv_Sdtsucursal_Sucursalempleadoheadlineid_Z ;
         gxTv_Sdtsucursal_Sucursalempleadoheadlinename_Z = sdt.gxTv_Sdtsucursal_Sucursalempleadoheadlinename_Z ;
         gxTv_Sdtsucursal_Sucursalempleadoalternateid_Z = sdt.gxTv_Sdtsucursal_Sucursalempleadoalternateid_Z ;
         gxTv_Sdtsucursal_Sucursalempleadoalternatename_Z = sdt.gxTv_Sdtsucursal_Sucursalempleadoalternatename_Z ;
         gxTv_Sdtsucursal_Sucursalempleadoalternateid_N = sdt.gxTv_Sdtsucursal_Sucursalempleadoalternateid_N ;
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
         AddObjectProperty("sucursalId", gxTv_Sdtsucursal_Sucursalid, false, includeNonInitialized);
         AddObjectProperty("sucursalName", gxTv_Sdtsucursal_Sucursalname, false, includeNonInitialized);
         AddObjectProperty("sucursalAddress", gxTv_Sdtsucursal_Sucursaladdress, false, includeNonInitialized);
         AddObjectProperty("sucursalGeolocation", gxTv_Sdtsucursal_Sucursalgeolocation, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_Sdtsucursal_Sucursaladdeddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_Sdtsucursal_Sucursaladdeddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_Sdtsucursal_Sucursaladdeddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("sucursalAddedDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("sucursalEmpleadoHeadlineId", gxTv_Sdtsucursal_Sucursalempleadoheadlineid, false, includeNonInitialized);
         AddObjectProperty("sucursalEmpleadoHeadlineName", gxTv_Sdtsucursal_Sucursalempleadoheadlinename, false, includeNonInitialized);
         AddObjectProperty("sucursalEmpleadoAlternateId", gxTv_Sdtsucursal_Sucursalempleadoalternateid, false, includeNonInitialized);
         AddObjectProperty("sucursalEmpleadoAlternateId_N", gxTv_Sdtsucursal_Sucursalempleadoalternateid_N, false, includeNonInitialized);
         AddObjectProperty("sucursalEmpleadoAlternateName", gxTv_Sdtsucursal_Sucursalempleadoalternatename, false, includeNonInitialized);
         if ( gxTv_Sdtsucursal_Producto != null )
         {
            AddObjectProperty("producto", gxTv_Sdtsucursal_Producto, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_Sdtsucursal_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_Sdtsucursal_Initialized, false, includeNonInitialized);
            AddObjectProperty("sucursalId_Z", gxTv_Sdtsucursal_Sucursalid_Z, false, includeNonInitialized);
            AddObjectProperty("sucursalName_Z", gxTv_Sdtsucursal_Sucursalname_Z, false, includeNonInitialized);
            AddObjectProperty("sucursalAddress_Z", gxTv_Sdtsucursal_Sucursaladdress_Z, false, includeNonInitialized);
            AddObjectProperty("sucursalGeolocation_Z", gxTv_Sdtsucursal_Sucursalgeolocation_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_Sdtsucursal_Sucursaladdeddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_Sdtsucursal_Sucursaladdeddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_Sdtsucursal_Sucursaladdeddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("sucursalAddedDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("sucursalEmpleadoHeadlineId_Z", gxTv_Sdtsucursal_Sucursalempleadoheadlineid_Z, false, includeNonInitialized);
            AddObjectProperty("sucursalEmpleadoHeadlineName_Z", gxTv_Sdtsucursal_Sucursalempleadoheadlinename_Z, false, includeNonInitialized);
            AddObjectProperty("sucursalEmpleadoAlternateId_Z", gxTv_Sdtsucursal_Sucursalempleadoalternateid_Z, false, includeNonInitialized);
            AddObjectProperty("sucursalEmpleadoAlternateName_Z", gxTv_Sdtsucursal_Sucursalempleadoalternatename_Z, false, includeNonInitialized);
            AddObjectProperty("sucursalEmpleadoAlternateId_N", gxTv_Sdtsucursal_Sucursalempleadoalternateid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( Sdtsucursal sdt )
      {
         if ( sdt.IsDirty("sucursalId") )
         {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursalid = sdt.gxTv_Sdtsucursal_Sucursalid ;
         }
         if ( sdt.IsDirty("sucursalName") )
         {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursalname = sdt.gxTv_Sdtsucursal_Sucursalname ;
         }
         if ( sdt.IsDirty("sucursalAddress") )
         {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursaladdress = sdt.gxTv_Sdtsucursal_Sucursaladdress ;
         }
         if ( sdt.IsDirty("sucursalGeolocation") )
         {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursalgeolocation = sdt.gxTv_Sdtsucursal_Sucursalgeolocation ;
         }
         if ( sdt.IsDirty("sucursalAddedDate") )
         {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursaladdeddate = sdt.gxTv_Sdtsucursal_Sucursaladdeddate ;
         }
         if ( sdt.IsDirty("sucursalEmpleadoHeadlineId") )
         {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursalempleadoheadlineid = sdt.gxTv_Sdtsucursal_Sucursalempleadoheadlineid ;
         }
         if ( sdt.IsDirty("sucursalEmpleadoHeadlineName") )
         {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursalempleadoheadlinename = sdt.gxTv_Sdtsucursal_Sucursalempleadoheadlinename ;
         }
         if ( sdt.IsDirty("sucursalEmpleadoAlternateId") )
         {
            gxTv_Sdtsucursal_Sucursalempleadoalternateid_N = (short)(sdt.gxTv_Sdtsucursal_Sucursalempleadoalternateid_N);
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursalempleadoalternateid = sdt.gxTv_Sdtsucursal_Sucursalempleadoalternateid ;
         }
         if ( sdt.IsDirty("sucursalEmpleadoAlternateName") )
         {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursalempleadoalternatename = sdt.gxTv_Sdtsucursal_Sucursalempleadoalternatename ;
         }
         if ( gxTv_Sdtsucursal_Producto != null )
         {
            GXBCLevelCollection<Sdtsucursal_producto> newCollectionProducto = sdt.gxTpr_Producto;
            Sdtsucursal_producto currItemProducto;
            Sdtsucursal_producto newItemProducto;
            short idx = 1;
            while ( idx <= newCollectionProducto.Count )
            {
               newItemProducto = ((Sdtsucursal_producto)newCollectionProducto.Item(idx));
               currItemProducto = gxTv_Sdtsucursal_Producto.GetByKey(newItemProducto.gxTpr_Productoid);
               if ( StringUtil.StrCmp(currItemProducto.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemProducto.UpdateDirties(newItemProducto);
                  if ( StringUtil.StrCmp(newItemProducto.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemProducto.gxTpr_Mode = "DLT";
                  }
                  currItemProducto.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_Sdtsucursal_Producto.Add(newItemProducto, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "sucursalId" )]
      [  XmlElement( ElementName = "sucursalId"   )]
      public short gxTpr_Sucursalid
      {
         get {
            return gxTv_Sdtsucursal_Sucursalid ;
         }

         set {
            gxTv_Sdtsucursal_N = 0;
            if ( gxTv_Sdtsucursal_Sucursalid != value )
            {
               gxTv_Sdtsucursal_Mode = "INS";
               this.gxTv_Sdtsucursal_Sucursalid_Z_SetNull( );
               this.gxTv_Sdtsucursal_Sucursalname_Z_SetNull( );
               this.gxTv_Sdtsucursal_Sucursaladdress_Z_SetNull( );
               this.gxTv_Sdtsucursal_Sucursalgeolocation_Z_SetNull( );
               this.gxTv_Sdtsucursal_Sucursaladdeddate_Z_SetNull( );
               this.gxTv_Sdtsucursal_Sucursalempleadoheadlineid_Z_SetNull( );
               this.gxTv_Sdtsucursal_Sucursalempleadoheadlinename_Z_SetNull( );
               this.gxTv_Sdtsucursal_Sucursalempleadoalternateid_Z_SetNull( );
               this.gxTv_Sdtsucursal_Sucursalempleadoalternatename_Z_SetNull( );
               if ( gxTv_Sdtsucursal_Producto != null )
               {
                  GXBCLevelCollection<Sdtsucursal_producto> collectionProducto = gxTv_Sdtsucursal_Producto;
                  Sdtsucursal_producto currItemProducto;
                  short idx = 1;
                  while ( idx <= collectionProducto.Count )
                  {
                     currItemProducto = ((Sdtsucursal_producto)collectionProducto.Item(idx));
                     currItemProducto.gxTpr_Mode = "INS";
                     currItemProducto.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_Sdtsucursal_Sucursalid = value;
            SetDirty("Sucursalid");
         }

      }

      [  SoapElement( ElementName = "sucursalName" )]
      [  XmlElement( ElementName = "sucursalName"   )]
      public string gxTpr_Sucursalname
      {
         get {
            return gxTv_Sdtsucursal_Sucursalname ;
         }

         set {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursalname = value;
            SetDirty("Sucursalname");
         }

      }

      [  SoapElement( ElementName = "sucursalAddress" )]
      [  XmlElement( ElementName = "sucursalAddress"   )]
      public string gxTpr_Sucursaladdress
      {
         get {
            return gxTv_Sdtsucursal_Sucursaladdress ;
         }

         set {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursaladdress = value;
            SetDirty("Sucursaladdress");
         }

      }

      [  SoapElement( ElementName = "sucursalGeolocation" )]
      [  XmlElement( ElementName = "sucursalGeolocation"   )]
      public string gxTpr_Sucursalgeolocation
      {
         get {
            return gxTv_Sdtsucursal_Sucursalgeolocation ;
         }

         set {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursalgeolocation = value;
            SetDirty("Sucursalgeolocation");
         }

      }

      [  SoapElement( ElementName = "sucursalAddedDate" )]
      [  XmlElement( ElementName = "sucursalAddedDate"  , IsNullable=true )]
      public string gxTpr_Sucursaladdeddate_Nullable
      {
         get {
            if ( gxTv_Sdtsucursal_Sucursaladdeddate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_Sdtsucursal_Sucursaladdeddate).value ;
         }

         set {
            gxTv_Sdtsucursal_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_Sdtsucursal_Sucursaladdeddate = DateTime.MinValue;
            else
               gxTv_Sdtsucursal_Sucursaladdeddate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Sucursaladdeddate
      {
         get {
            return gxTv_Sdtsucursal_Sucursaladdeddate ;
         }

         set {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursaladdeddate = value;
            SetDirty("Sucursaladdeddate");
         }

      }

      [  SoapElement( ElementName = "sucursalEmpleadoHeadlineId" )]
      [  XmlElement( ElementName = "sucursalEmpleadoHeadlineId"   )]
      public short gxTpr_Sucursalempleadoheadlineid
      {
         get {
            return gxTv_Sdtsucursal_Sucursalempleadoheadlineid ;
         }

         set {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursalempleadoheadlineid = value;
            SetDirty("Sucursalempleadoheadlineid");
         }

      }

      [  SoapElement( ElementName = "sucursalEmpleadoHeadlineName" )]
      [  XmlElement( ElementName = "sucursalEmpleadoHeadlineName"   )]
      public string gxTpr_Sucursalempleadoheadlinename
      {
         get {
            return gxTv_Sdtsucursal_Sucursalempleadoheadlinename ;
         }

         set {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursalempleadoheadlinename = value;
            SetDirty("Sucursalempleadoheadlinename");
         }

      }

      [  SoapElement( ElementName = "sucursalEmpleadoAlternateId" )]
      [  XmlElement( ElementName = "sucursalEmpleadoAlternateId"   )]
      public short gxTpr_Sucursalempleadoalternateid
      {
         get {
            return gxTv_Sdtsucursal_Sucursalempleadoalternateid ;
         }

         set {
            gxTv_Sdtsucursal_Sucursalempleadoalternateid_N = 0;
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursalempleadoalternateid = value;
            SetDirty("Sucursalempleadoalternateid");
         }

      }

      public void gxTv_Sdtsucursal_Sucursalempleadoalternateid_SetNull( )
      {
         gxTv_Sdtsucursal_Sucursalempleadoalternateid_N = 1;
         gxTv_Sdtsucursal_Sucursalempleadoalternateid = 0;
         SetDirty("Sucursalempleadoalternateid");
         return  ;
      }

      public bool gxTv_Sdtsucursal_Sucursalempleadoalternateid_IsNull( )
      {
         return (gxTv_Sdtsucursal_Sucursalempleadoalternateid_N==1) ;
      }

      [  SoapElement( ElementName = "sucursalEmpleadoAlternateName" )]
      [  XmlElement( ElementName = "sucursalEmpleadoAlternateName"   )]
      public string gxTpr_Sucursalempleadoalternatename
      {
         get {
            return gxTv_Sdtsucursal_Sucursalempleadoalternatename ;
         }

         set {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursalempleadoalternatename = value;
            SetDirty("Sucursalempleadoalternatename");
         }

      }

      [  SoapElement( ElementName = "producto" )]
      [  XmlArray( ElementName = "producto"  )]
      [  XmlArrayItemAttribute( ElementName= "sucursal.producto"  , IsNullable=false)]
      public GXBCLevelCollection<Sdtsucursal_producto> gxTpr_Producto_GXBCLevelCollection
      {
         get {
            if ( gxTv_Sdtsucursal_Producto == null )
            {
               gxTv_Sdtsucursal_Producto = new GXBCLevelCollection<Sdtsucursal_producto>( context, "sucursal.producto", "xd2");
            }
            return gxTv_Sdtsucursal_Producto ;
         }

         set {
            if ( gxTv_Sdtsucursal_Producto == null )
            {
               gxTv_Sdtsucursal_Producto = new GXBCLevelCollection<Sdtsucursal_producto>( context, "sucursal.producto", "xd2");
            }
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Producto = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<Sdtsucursal_producto> gxTpr_Producto
      {
         get {
            if ( gxTv_Sdtsucursal_Producto == null )
            {
               gxTv_Sdtsucursal_Producto = new GXBCLevelCollection<Sdtsucursal_producto>( context, "sucursal.producto", "xd2");
            }
            gxTv_Sdtsucursal_N = 0;
            return gxTv_Sdtsucursal_Producto ;
         }

         set {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Producto = value;
            SetDirty("Producto");
         }

      }

      public void gxTv_Sdtsucursal_Producto_SetNull( )
      {
         gxTv_Sdtsucursal_Producto = null;
         SetDirty("Producto");
         return  ;
      }

      public bool gxTv_Sdtsucursal_Producto_IsNull( )
      {
         if ( gxTv_Sdtsucursal_Producto == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_Sdtsucursal_Mode ;
         }

         set {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_Sdtsucursal_Mode_SetNull( )
      {
         gxTv_Sdtsucursal_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_Sdtsucursal_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_Sdtsucursal_Initialized ;
         }

         set {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_Sdtsucursal_Initialized_SetNull( )
      {
         gxTv_Sdtsucursal_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_Sdtsucursal_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "sucursalId_Z" )]
      [  XmlElement( ElementName = "sucursalId_Z"   )]
      public short gxTpr_Sucursalid_Z
      {
         get {
            return gxTv_Sdtsucursal_Sucursalid_Z ;
         }

         set {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursalid_Z = value;
            SetDirty("Sucursalid_Z");
         }

      }

      public void gxTv_Sdtsucursal_Sucursalid_Z_SetNull( )
      {
         gxTv_Sdtsucursal_Sucursalid_Z = 0;
         SetDirty("Sucursalid_Z");
         return  ;
      }

      public bool gxTv_Sdtsucursal_Sucursalid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "sucursalName_Z" )]
      [  XmlElement( ElementName = "sucursalName_Z"   )]
      public string gxTpr_Sucursalname_Z
      {
         get {
            return gxTv_Sdtsucursal_Sucursalname_Z ;
         }

         set {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursalname_Z = value;
            SetDirty("Sucursalname_Z");
         }

      }

      public void gxTv_Sdtsucursal_Sucursalname_Z_SetNull( )
      {
         gxTv_Sdtsucursal_Sucursalname_Z = "";
         SetDirty("Sucursalname_Z");
         return  ;
      }

      public bool gxTv_Sdtsucursal_Sucursalname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "sucursalAddress_Z" )]
      [  XmlElement( ElementName = "sucursalAddress_Z"   )]
      public string gxTpr_Sucursaladdress_Z
      {
         get {
            return gxTv_Sdtsucursal_Sucursaladdress_Z ;
         }

         set {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursaladdress_Z = value;
            SetDirty("Sucursaladdress_Z");
         }

      }

      public void gxTv_Sdtsucursal_Sucursaladdress_Z_SetNull( )
      {
         gxTv_Sdtsucursal_Sucursaladdress_Z = "";
         SetDirty("Sucursaladdress_Z");
         return  ;
      }

      public bool gxTv_Sdtsucursal_Sucursaladdress_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "sucursalGeolocation_Z" )]
      [  XmlElement( ElementName = "sucursalGeolocation_Z"   )]
      public string gxTpr_Sucursalgeolocation_Z
      {
         get {
            return gxTv_Sdtsucursal_Sucursalgeolocation_Z ;
         }

         set {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursalgeolocation_Z = value;
            SetDirty("Sucursalgeolocation_Z");
         }

      }

      public void gxTv_Sdtsucursal_Sucursalgeolocation_Z_SetNull( )
      {
         gxTv_Sdtsucursal_Sucursalgeolocation_Z = "";
         SetDirty("Sucursalgeolocation_Z");
         return  ;
      }

      public bool gxTv_Sdtsucursal_Sucursalgeolocation_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "sucursalAddedDate_Z" )]
      [  XmlElement( ElementName = "sucursalAddedDate_Z"  , IsNullable=true )]
      public string gxTpr_Sucursaladdeddate_Z_Nullable
      {
         get {
            if ( gxTv_Sdtsucursal_Sucursaladdeddate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_Sdtsucursal_Sucursaladdeddate_Z).value ;
         }

         set {
            gxTv_Sdtsucursal_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_Sdtsucursal_Sucursaladdeddate_Z = DateTime.MinValue;
            else
               gxTv_Sdtsucursal_Sucursaladdeddate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Sucursaladdeddate_Z
      {
         get {
            return gxTv_Sdtsucursal_Sucursaladdeddate_Z ;
         }

         set {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursaladdeddate_Z = value;
            SetDirty("Sucursaladdeddate_Z");
         }

      }

      public void gxTv_Sdtsucursal_Sucursaladdeddate_Z_SetNull( )
      {
         gxTv_Sdtsucursal_Sucursaladdeddate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Sucursaladdeddate_Z");
         return  ;
      }

      public bool gxTv_Sdtsucursal_Sucursaladdeddate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "sucursalEmpleadoHeadlineId_Z" )]
      [  XmlElement( ElementName = "sucursalEmpleadoHeadlineId_Z"   )]
      public short gxTpr_Sucursalempleadoheadlineid_Z
      {
         get {
            return gxTv_Sdtsucursal_Sucursalempleadoheadlineid_Z ;
         }

         set {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursalempleadoheadlineid_Z = value;
            SetDirty("Sucursalempleadoheadlineid_Z");
         }

      }

      public void gxTv_Sdtsucursal_Sucursalempleadoheadlineid_Z_SetNull( )
      {
         gxTv_Sdtsucursal_Sucursalempleadoheadlineid_Z = 0;
         SetDirty("Sucursalempleadoheadlineid_Z");
         return  ;
      }

      public bool gxTv_Sdtsucursal_Sucursalempleadoheadlineid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "sucursalEmpleadoHeadlineName_Z" )]
      [  XmlElement( ElementName = "sucursalEmpleadoHeadlineName_Z"   )]
      public string gxTpr_Sucursalempleadoheadlinename_Z
      {
         get {
            return gxTv_Sdtsucursal_Sucursalempleadoheadlinename_Z ;
         }

         set {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursalempleadoheadlinename_Z = value;
            SetDirty("Sucursalempleadoheadlinename_Z");
         }

      }

      public void gxTv_Sdtsucursal_Sucursalempleadoheadlinename_Z_SetNull( )
      {
         gxTv_Sdtsucursal_Sucursalempleadoheadlinename_Z = "";
         SetDirty("Sucursalempleadoheadlinename_Z");
         return  ;
      }

      public bool gxTv_Sdtsucursal_Sucursalempleadoheadlinename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "sucursalEmpleadoAlternateId_Z" )]
      [  XmlElement( ElementName = "sucursalEmpleadoAlternateId_Z"   )]
      public short gxTpr_Sucursalempleadoalternateid_Z
      {
         get {
            return gxTv_Sdtsucursal_Sucursalempleadoalternateid_Z ;
         }

         set {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursalempleadoalternateid_Z = value;
            SetDirty("Sucursalempleadoalternateid_Z");
         }

      }

      public void gxTv_Sdtsucursal_Sucursalempleadoalternateid_Z_SetNull( )
      {
         gxTv_Sdtsucursal_Sucursalempleadoalternateid_Z = 0;
         SetDirty("Sucursalempleadoalternateid_Z");
         return  ;
      }

      public bool gxTv_Sdtsucursal_Sucursalempleadoalternateid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "sucursalEmpleadoAlternateName_Z" )]
      [  XmlElement( ElementName = "sucursalEmpleadoAlternateName_Z"   )]
      public string gxTpr_Sucursalempleadoalternatename_Z
      {
         get {
            return gxTv_Sdtsucursal_Sucursalempleadoalternatename_Z ;
         }

         set {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursalempleadoalternatename_Z = value;
            SetDirty("Sucursalempleadoalternatename_Z");
         }

      }

      public void gxTv_Sdtsucursal_Sucursalempleadoalternatename_Z_SetNull( )
      {
         gxTv_Sdtsucursal_Sucursalempleadoalternatename_Z = "";
         SetDirty("Sucursalempleadoalternatename_Z");
         return  ;
      }

      public bool gxTv_Sdtsucursal_Sucursalempleadoalternatename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "sucursalEmpleadoAlternateId_N" )]
      [  XmlElement( ElementName = "sucursalEmpleadoAlternateId_N"   )]
      public short gxTpr_Sucursalempleadoalternateid_N
      {
         get {
            return gxTv_Sdtsucursal_Sucursalempleadoalternateid_N ;
         }

         set {
            gxTv_Sdtsucursal_N = 0;
            gxTv_Sdtsucursal_Sucursalempleadoalternateid_N = value;
            SetDirty("Sucursalempleadoalternateid_N");
         }

      }

      public void gxTv_Sdtsucursal_Sucursalempleadoalternateid_N_SetNull( )
      {
         gxTv_Sdtsucursal_Sucursalempleadoalternateid_N = 0;
         SetDirty("Sucursalempleadoalternateid_N");
         return  ;
      }

      public bool gxTv_Sdtsucursal_Sucursalempleadoalternateid_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_Sdtsucursal_N = 1;
         gxTv_Sdtsucursal_Sucursalname = "";
         gxTv_Sdtsucursal_Sucursaladdress = "";
         gxTv_Sdtsucursal_Sucursalgeolocation = "";
         gxTv_Sdtsucursal_Sucursaladdeddate = DateTime.MinValue;
         gxTv_Sdtsucursal_Sucursalempleadoheadlinename = "";
         gxTv_Sdtsucursal_Sucursalempleadoalternatename = "";
         gxTv_Sdtsucursal_Mode = "";
         gxTv_Sdtsucursal_Sucursalname_Z = "";
         gxTv_Sdtsucursal_Sucursaladdress_Z = "";
         gxTv_Sdtsucursal_Sucursalgeolocation_Z = "";
         gxTv_Sdtsucursal_Sucursaladdeddate_Z = DateTime.MinValue;
         gxTv_Sdtsucursal_Sucursalempleadoheadlinename_Z = "";
         gxTv_Sdtsucursal_Sucursalempleadoalternatename_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "sucursal", "GeneXus.Programs.sucursal_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_Sdtsucursal_N ;
      }

      private short gxTv_Sdtsucursal_Sucursalid ;
      private short gxTv_Sdtsucursal_N ;
      private short gxTv_Sdtsucursal_Sucursalempleadoheadlineid ;
      private short gxTv_Sdtsucursal_Sucursalempleadoalternateid ;
      private short gxTv_Sdtsucursal_Initialized ;
      private short gxTv_Sdtsucursal_Sucursalid_Z ;
      private short gxTv_Sdtsucursal_Sucursalempleadoheadlineid_Z ;
      private short gxTv_Sdtsucursal_Sucursalempleadoalternateid_Z ;
      private short gxTv_Sdtsucursal_Sucursalempleadoalternateid_N ;
      private string gxTv_Sdtsucursal_Sucursalgeolocation ;
      private string gxTv_Sdtsucursal_Mode ;
      private string gxTv_Sdtsucursal_Sucursalgeolocation_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_Sdtsucursal_Sucursaladdeddate ;
      private DateTime gxTv_Sdtsucursal_Sucursaladdeddate_Z ;
      private string gxTv_Sdtsucursal_Sucursalname ;
      private string gxTv_Sdtsucursal_Sucursaladdress ;
      private string gxTv_Sdtsucursal_Sucursalempleadoheadlinename ;
      private string gxTv_Sdtsucursal_Sucursalempleadoalternatename ;
      private string gxTv_Sdtsucursal_Sucursalname_Z ;
      private string gxTv_Sdtsucursal_Sucursaladdress_Z ;
      private string gxTv_Sdtsucursal_Sucursalempleadoheadlinename_Z ;
      private string gxTv_Sdtsucursal_Sucursalempleadoalternatename_Z ;
      private GXBCLevelCollection<Sdtsucursal_producto> gxTv_Sdtsucursal_Producto=null ;
   }

   [DataContract(Name = @"sucursal", Namespace = "xd2")]
   public class Sdtsucursal_RESTInterface : GxGenericCollectionItem<Sdtsucursal>
   {
      public Sdtsucursal_RESTInterface( ) : base()
      {
      }

      public Sdtsucursal_RESTInterface( Sdtsucursal psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "sucursalId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Sucursalid
      {
         get {
            return sdt.gxTpr_Sucursalid ;
         }

         set {
            sdt.gxTpr_Sucursalid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "sucursalName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Sucursalname
      {
         get {
            return sdt.gxTpr_Sucursalname ;
         }

         set {
            sdt.gxTpr_Sucursalname = value;
         }

      }

      [DataMember( Name = "sucursalAddress" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Sucursaladdress
      {
         get {
            return sdt.gxTpr_Sucursaladdress ;
         }

         set {
            sdt.gxTpr_Sucursaladdress = value;
         }

      }

      [DataMember( Name = "sucursalGeolocation" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Sucursalgeolocation
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Sucursalgeolocation) ;
         }

         set {
            sdt.gxTpr_Sucursalgeolocation = value;
         }

      }

      [DataMember( Name = "sucursalAddedDate" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Sucursaladdeddate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Sucursaladdeddate) ;
         }

         set {
            sdt.gxTpr_Sucursaladdeddate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "sucursalEmpleadoHeadlineId" , Order = 5 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Sucursalempleadoheadlineid
      {
         get {
            return sdt.gxTpr_Sucursalempleadoheadlineid ;
         }

         set {
            sdt.gxTpr_Sucursalempleadoheadlineid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "sucursalEmpleadoHeadlineName" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Sucursalempleadoheadlinename
      {
         get {
            return sdt.gxTpr_Sucursalempleadoheadlinename ;
         }

         set {
            sdt.gxTpr_Sucursalempleadoheadlinename = value;
         }

      }

      [DataMember( Name = "sucursalEmpleadoAlternateId" , Order = 7 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Sucursalempleadoalternateid
      {
         get {
            return sdt.gxTpr_Sucursalempleadoalternateid ;
         }

         set {
            sdt.gxTpr_Sucursalempleadoalternateid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "sucursalEmpleadoAlternateName" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Sucursalempleadoalternatename
      {
         get {
            return sdt.gxTpr_Sucursalempleadoalternatename ;
         }

         set {
            sdt.gxTpr_Sucursalempleadoalternatename = value;
         }

      }

      [DataMember( Name = "producto" , Order = 9 )]
      public GxGenericCollection<Sdtsucursal_producto_RESTInterface> gxTpr_Producto
      {
         get {
            return new GxGenericCollection<Sdtsucursal_producto_RESTInterface>(sdt.gxTpr_Producto) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Producto);
         }

      }

      public Sdtsucursal sdt
      {
         get {
            return (Sdtsucursal)Sdt ;
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
            sdt = new Sdtsucursal() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 10 )]
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

   [DataContract(Name = @"sucursal", Namespace = "xd2")]
   public class Sdtsucursal_RESTLInterface : GxGenericCollectionItem<Sdtsucursal>
   {
      public Sdtsucursal_RESTLInterface( ) : base()
      {
      }

      public Sdtsucursal_RESTLInterface( Sdtsucursal psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "sucursalName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Sucursalname
      {
         get {
            return sdt.gxTpr_Sucursalname ;
         }

         set {
            sdt.gxTpr_Sucursalname = value;
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

      public Sdtsucursal sdt
      {
         get {
            return (Sdtsucursal)Sdt ;
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
            sdt = new Sdtsucursal() ;
         }
      }

   }

}
