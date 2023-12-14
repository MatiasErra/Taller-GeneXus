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
   public class sucursallist : GXProcedure
   {
      public sucursallist( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public sucursallist( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_sucursalId )
      {
         this.AV2sucursalId = aP0_sucursalId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( short aP0_sucursalId )
      {
         sucursallist objsucursallist;
         objsucursallist = new sucursallist();
         objsucursallist.AV2sucursalId = aP0_sucursalId;
         objsucursallist.context.SetSubmitInitialConfig(context);
         objsucursallist.initialize();
         Submit( executePrivateCatch,objsucursallist);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((sucursallist)stateInfo).executePrivate();
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
         args = new Object[] {(short)AV2sucursalId} ;
         ClassLoader.Execute("asucursallist","GeneXus.Programs","asucursallist", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
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
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
