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
   [XmlRoot(ElementName = "sucursal.producto" )]
   [XmlType(TypeName =  "sucursal.producto" , Namespace = "xd2" )]
   [Serializable]
   public class Sdtsucursal_producto : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public Sdtsucursal_producto( )
      {
      }

      public Sdtsucursal_producto( IGxContext context )
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

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"productoId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "producto");
         metadata.Set("BT", "sucursalproducto");
         metadata.Set("PK", "[ \"productoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"productoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"sucursalId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Productoid_Z");
         state.Add("gxTpr_Productoname_Z");
         state.Add("gxTpr_Productostock_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         Sdtsucursal_producto sdt;
         sdt = (Sdtsucursal_producto)(source);
         gxTv_Sdtsucursal_producto_Productoid = sdt.gxTv_Sdtsucursal_producto_Productoid ;
         gxTv_Sdtsucursal_producto_Productoname = sdt.gxTv_Sdtsucursal_producto_Productoname ;
         gxTv_Sdtsucursal_producto_Productostock = sdt.gxTv_Sdtsucursal_producto_Productostock ;
         gxTv_Sdtsucursal_producto_Mode = sdt.gxTv_Sdtsucursal_producto_Mode ;
         gxTv_Sdtsucursal_producto_Modified = sdt.gxTv_Sdtsucursal_producto_Modified ;
         gxTv_Sdtsucursal_producto_Initialized = sdt.gxTv_Sdtsucursal_producto_Initialized ;
         gxTv_Sdtsucursal_producto_Productoid_Z = sdt.gxTv_Sdtsucursal_producto_Productoid_Z ;
         gxTv_Sdtsucursal_producto_Productoname_Z = sdt.gxTv_Sdtsucursal_producto_Productoname_Z ;
         gxTv_Sdtsucursal_producto_Productostock_Z = sdt.gxTv_Sdtsucursal_producto_Productostock_Z ;
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
         AddObjectProperty("productoId", gxTv_Sdtsucursal_producto_Productoid, false, includeNonInitialized);
         AddObjectProperty("productoName", gxTv_Sdtsucursal_producto_Productoname, false, includeNonInitialized);
         AddObjectProperty("productoStock", gxTv_Sdtsucursal_producto_Productostock, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_Sdtsucursal_producto_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_Sdtsucursal_producto_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_Sdtsucursal_producto_Initialized, false, includeNonInitialized);
            AddObjectProperty("productoId_Z", gxTv_Sdtsucursal_producto_Productoid_Z, false, includeNonInitialized);
            AddObjectProperty("productoName_Z", gxTv_Sdtsucursal_producto_Productoname_Z, false, includeNonInitialized);
            AddObjectProperty("productoStock_Z", gxTv_Sdtsucursal_producto_Productostock_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( Sdtsucursal_producto sdt )
      {
         if ( sdt.IsDirty("productoId") )
         {
            gxTv_Sdtsucursal_producto_N = 0;
            gxTv_Sdtsucursal_producto_Productoid = sdt.gxTv_Sdtsucursal_producto_Productoid ;
         }
         if ( sdt.IsDirty("productoName") )
         {
            gxTv_Sdtsucursal_producto_N = 0;
            gxTv_Sdtsucursal_producto_Productoname = sdt.gxTv_Sdtsucursal_producto_Productoname ;
         }
         if ( sdt.IsDirty("productoStock") )
         {
            gxTv_Sdtsucursal_producto_N = 0;
            gxTv_Sdtsucursal_producto_Productostock = sdt.gxTv_Sdtsucursal_producto_Productostock ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "productoId" )]
      [  XmlElement( ElementName = "productoId"   )]
      public short gxTpr_Productoid
      {
         get {
            return gxTv_Sdtsucursal_producto_Productoid ;
         }

         set {
            gxTv_Sdtsucursal_producto_N = 0;
            gxTv_Sdtsucursal_producto_Productoid = value;
            gxTv_Sdtsucursal_producto_Modified = 1;
            SetDirty("Productoid");
         }

      }

      [  SoapElement( ElementName = "productoName" )]
      [  XmlElement( ElementName = "productoName"   )]
      public string gxTpr_Productoname
      {
         get {
            return gxTv_Sdtsucursal_producto_Productoname ;
         }

         set {
            gxTv_Sdtsucursal_producto_N = 0;
            gxTv_Sdtsucursal_producto_Productoname = value;
            gxTv_Sdtsucursal_producto_Modified = 1;
            SetDirty("Productoname");
         }

      }

      [  SoapElement( ElementName = "productoStock" )]
      [  XmlElement( ElementName = "productoStock"   )]
      public long gxTpr_Productostock
      {
         get {
            return gxTv_Sdtsucursal_producto_Productostock ;
         }

         set {
            gxTv_Sdtsucursal_producto_N = 0;
            gxTv_Sdtsucursal_producto_Productostock = value;
            gxTv_Sdtsucursal_producto_Modified = 1;
            SetDirty("Productostock");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_Sdtsucursal_producto_Mode ;
         }

         set {
            gxTv_Sdtsucursal_producto_N = 0;
            gxTv_Sdtsucursal_producto_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_Sdtsucursal_producto_Mode_SetNull( )
      {
         gxTv_Sdtsucursal_producto_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_Sdtsucursal_producto_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_Sdtsucursal_producto_Modified ;
         }

         set {
            gxTv_Sdtsucursal_producto_N = 0;
            gxTv_Sdtsucursal_producto_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_Sdtsucursal_producto_Modified_SetNull( )
      {
         gxTv_Sdtsucursal_producto_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_Sdtsucursal_producto_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_Sdtsucursal_producto_Initialized ;
         }

         set {
            gxTv_Sdtsucursal_producto_N = 0;
            gxTv_Sdtsucursal_producto_Initialized = value;
            gxTv_Sdtsucursal_producto_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_Sdtsucursal_producto_Initialized_SetNull( )
      {
         gxTv_Sdtsucursal_producto_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_Sdtsucursal_producto_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "productoId_Z" )]
      [  XmlElement( ElementName = "productoId_Z"   )]
      public short gxTpr_Productoid_Z
      {
         get {
            return gxTv_Sdtsucursal_producto_Productoid_Z ;
         }

         set {
            gxTv_Sdtsucursal_producto_N = 0;
            gxTv_Sdtsucursal_producto_Productoid_Z = value;
            gxTv_Sdtsucursal_producto_Modified = 1;
            SetDirty("Productoid_Z");
         }

      }

      public void gxTv_Sdtsucursal_producto_Productoid_Z_SetNull( )
      {
         gxTv_Sdtsucursal_producto_Productoid_Z = 0;
         SetDirty("Productoid_Z");
         return  ;
      }

      public bool gxTv_Sdtsucursal_producto_Productoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "productoName_Z" )]
      [  XmlElement( ElementName = "productoName_Z"   )]
      public string gxTpr_Productoname_Z
      {
         get {
            return gxTv_Sdtsucursal_producto_Productoname_Z ;
         }

         set {
            gxTv_Sdtsucursal_producto_N = 0;
            gxTv_Sdtsucursal_producto_Productoname_Z = value;
            gxTv_Sdtsucursal_producto_Modified = 1;
            SetDirty("Productoname_Z");
         }

      }

      public void gxTv_Sdtsucursal_producto_Productoname_Z_SetNull( )
      {
         gxTv_Sdtsucursal_producto_Productoname_Z = "";
         SetDirty("Productoname_Z");
         return  ;
      }

      public bool gxTv_Sdtsucursal_producto_Productoname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "productoStock_Z" )]
      [  XmlElement( ElementName = "productoStock_Z"   )]
      public long gxTpr_Productostock_Z
      {
         get {
            return gxTv_Sdtsucursal_producto_Productostock_Z ;
         }

         set {
            gxTv_Sdtsucursal_producto_N = 0;
            gxTv_Sdtsucursal_producto_Productostock_Z = value;
            gxTv_Sdtsucursal_producto_Modified = 1;
            SetDirty("Productostock_Z");
         }

      }

      public void gxTv_Sdtsucursal_producto_Productostock_Z_SetNull( )
      {
         gxTv_Sdtsucursal_producto_Productostock_Z = 0;
         SetDirty("Productostock_Z");
         return  ;
      }

      public bool gxTv_Sdtsucursal_producto_Productostock_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_Sdtsucursal_producto_N = 1;
         gxTv_Sdtsucursal_producto_Productoname = "";
         gxTv_Sdtsucursal_producto_Mode = "";
         gxTv_Sdtsucursal_producto_Productoname_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return gxTv_Sdtsucursal_producto_N ;
      }

      private short gxTv_Sdtsucursal_producto_Productoid ;
      private short gxTv_Sdtsucursal_producto_N ;
      private short gxTv_Sdtsucursal_producto_Modified ;
      private short gxTv_Sdtsucursal_producto_Initialized ;
      private short gxTv_Sdtsucursal_producto_Productoid_Z ;
      private long gxTv_Sdtsucursal_producto_Productostock ;
      private long gxTv_Sdtsucursal_producto_Productostock_Z ;
      private string gxTv_Sdtsucursal_producto_Mode ;
      private string gxTv_Sdtsucursal_producto_Productoname ;
      private string gxTv_Sdtsucursal_producto_Productoname_Z ;
   }

   [DataContract(Name = @"sucursal.producto", Namespace = "xd2")]
   public class Sdtsucursal_producto_RESTInterface : GxGenericCollectionItem<Sdtsucursal_producto>
   {
      public Sdtsucursal_producto_RESTInterface( ) : base()
      {
      }

      public Sdtsucursal_producto_RESTInterface( Sdtsucursal_producto psdt ) : base(psdt)
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

      [DataMember( Name = "productoStock" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Productostock
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Productostock), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Productostock = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      public Sdtsucursal_producto sdt
      {
         get {
            return (Sdtsucursal_producto)Sdt ;
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
            sdt = new Sdtsucursal_producto() ;
         }
      }

   }

   [DataContract(Name = @"sucursal.producto", Namespace = "xd2")]
   public class Sdtsucursal_producto_RESTLInterface : GxGenericCollectionItem<Sdtsucursal_producto>
   {
      public Sdtsucursal_producto_RESTLInterface( ) : base()
      {
      }

      public Sdtsucursal_producto_RESTLInterface( Sdtsucursal_producto psdt ) : base(psdt)
      {
      }

      public Sdtsucursal_producto sdt
      {
         get {
            return (Sdtsucursal_producto)Sdt ;
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
            sdt = new Sdtsucursal_producto() ;
         }
      }

   }

}
