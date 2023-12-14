using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
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
namespace GeneXus.Programs {
   public class montosucursal : GXProcedure
   {
      public montosucursal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public montosucursal( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_fechaInicio ,
                           DateTime aP1_fechaFin )
      {
         this.AV2fechaInicio = aP0_fechaInicio;
         this.AV3fechaFin = aP1_fechaFin;
         initialize();
         executePrivate();
      }

      public void executeSubmit( DateTime aP0_fechaInicio ,
                                 DateTime aP1_fechaFin )
      {
         montosucursal objmontosucursal;
         objmontosucursal = new montosucursal();
         objmontosucursal.AV2fechaInicio = aP0_fechaInicio;
         objmontosucursal.AV3fechaFin = aP1_fechaFin;
         objmontosucursal.context.SetSubmitInitialConfig(context);
         objmontosucursal.initialize();
         Submit( executePrivateCatch,objmontosucursal);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((montosucursal)stateInfo).executePrivate();
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
         args = new Object[] {(DateTime)AV2fechaInicio,(DateTime)AV3fechaFin} ;
         ClassLoader.Execute("amontosucursal","GeneXus.Programs","amontosucursal", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
         {
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private DateTime AV2fechaInicio ;
      private DateTime AV3fechaFin ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}