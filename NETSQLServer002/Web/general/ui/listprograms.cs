using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.general.ui {
   public class listprograms : GXProcedure
   {
      public listprograms( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("xd2", true);
      }

      public listprograms( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName> aP0_ProgramNames )
      {
         this.AV9ProgramNames = new GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName>( context, "ProgramName", "xd2") ;
         initialize();
         executePrivate();
         aP0_ProgramNames=this.AV9ProgramNames;
      }

      public GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName> executeUdp( )
      {
         execute(out aP0_ProgramNames);
         return AV9ProgramNames ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName> aP0_ProgramNames )
      {
         listprograms objlistprograms;
         objlistprograms = new listprograms();
         objlistprograms.AV9ProgramNames = new GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName>( context, "ProgramName", "xd2") ;
         objlistprograms.context.SetSubmitInitialConfig(context);
         objlistprograms.initialize();
         Submit( executePrivateCatch,objlistprograms);
         aP0_ProgramNames=this.AV9ProgramNames;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((listprograms)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9ProgramNames = new GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName>( context, "ProgramName", "xd2");
         AV11name = "Home";
         AV12description = "Inicio";
         AV13link = formatLink("home.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV11name = "WWempleado";
         AV12description = "Gestion de empleados";
         AV13link = formatLink("wwempleado.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV11name = "WWfactura";
         AV12description = "Gestion de facturas";
         AV13link = formatLink("wwfactura.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV11name = "WWproducto";
         AV12description = "Gestion de productos";
         AV13link = formatLink("wwproducto.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV11name = "WWproveedor";
         AV12description = "Gestion de proveedores";
         AV13link = formatLink("wwproveedor.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV11name = "WWsucursal";
         AV12description = "Gestion de sucursales";
         AV13link = formatLink("wwsucursal.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV11name = "WWtipoDeProducto";
         AV12description = "Gestion de tipo de productos";
         AV13link = formatLink("wwtipodeproducto.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV11name = "MontoSucursalPorFecha";
         AV12description = "Monto total de sucursal por fechas";
         AV13link = formatLink("montosucursalporfecha.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV11name = "sucursalSelect";
         AV12description = "Ver una sucursal";
         AV13link = formatLink("sucursalselect.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV11name = "ventasSucursalPorFecha";
         AV12description = "Ventas de sucursal por fechas";
         AV13link = formatLink("ventassucursalporfecha.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV11name = "productoStock";
         AV12description = "Cambiar stock de sucursal";
         AV13link = formatLink("productostock.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'ADDPROGRAM' Routine */
         returnInSub = false;
         AV8IsAuthorized = true;
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.general.security.isauthorized(context ).execute(  AV11name, out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV10ProgramName = new GeneXus.Programs.general.ui.SdtProgramNames_ProgramName(context);
            AV10ProgramName.gxTpr_Name = AV11name;
            AV10ProgramName.gxTpr_Description = AV12description;
            AV10ProgramName.gxTpr_Link = AV13link;
            AV9ProgramNames.Add(AV10ProgramName, 0);
         }
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV9ProgramNames = new GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName>( context, "ProgramName", "xd2");
         AV11name = "";
         AV12description = "";
         AV13link = "";
         AV10ProgramName = new GeneXus.Programs.general.ui.SdtProgramNames_ProgramName(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private bool returnInSub ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private string AV11name ;
      private string AV12description ;
      private string AV13link ;
      private GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName> aP0_ProgramNames ;
      private GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName> AV9ProgramNames ;
      private GeneXus.Programs.general.ui.SdtProgramNames_ProgramName AV10ProgramName ;
   }

}
