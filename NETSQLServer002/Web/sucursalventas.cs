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
   public class sucursalventas : GXProcedure
   {
      public sucursalventas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public sucursalventas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_sucursalId ,
                           DateTime aP1_fechaInicio ,
                           DateTime aP2_fechaFin )
      {
         this.AV2sucursalId = aP0_sucursalId;
         this.AV3fechaInicio = aP1_fechaInicio;
         this.AV4fechaFin = aP2_fechaFin;
         initialize();
         executePrivate();
      }

      public void executeSubmit( short aP0_sucursalId ,
                                 DateTime aP1_fechaInicio ,
                                 DateTime aP2_fechaFin )
      {
         sucursalventas objsucursalventas;
         objsucursalventas = new sucursalventas();
         objsucursalventas.AV2sucursalId = aP0_sucursalId;
         objsucursalventas.AV3fechaInicio = aP1_fechaInicio;
         objsucursalventas.AV4fechaFin = aP2_fechaFin;
         objsucursalventas.context.SetSubmitInitialConfig(context);
         objsucursalventas.initialize();
         Submit( executePrivateCatch,objsucursalventas);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((sucursalventas)stateInfo).executePrivate();
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
         args = new Object[] {(short)AV2sucursalId,(DateTime)AV3fechaInicio,(DateTime)AV4fechaFin} ;
         ClassLoader.Execute("asucursalventas","GeneXus.Programs","asucursalventas", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 3 ) )
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

      private short AV2sucursalId ;
      private DateTime AV3fechaInicio ;
      private DateTime AV4fechaFin ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
