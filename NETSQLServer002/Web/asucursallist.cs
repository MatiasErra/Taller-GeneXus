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
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class asucursallist : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("xd2", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "sucursalId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV8sucursalId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
            }
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public asucursallist( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("xd2", true);
      }

      public asucursallist( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_sucursalId )
      {
         this.AV8sucursalId = aP0_sucursalId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( short aP0_sucursalId )
      {
         asucursallist objasucursallist;
         objasucursallist = new asucursallist();
         objasucursallist.AV8sucursalId = aP0_sucursalId;
         objasucursallist.context.SetSubmitInitialConfig(context);
         objasucursallist.initialize();
         Submit( executePrivateCatch,objasucursallist);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((asucursallist)stateInfo).executePrivate();
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
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         getPrinter().GxSetDocName("") ;
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            H0G0( false, 80) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 14, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Sucursal", 350, Gx_line+33, 435, Gx_line+58, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+80);
            H0G0( false, 74) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Name", 25, Gx_line+33, 65, Gx_line+51, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("EmpleadoAlternate", 625, Gx_line+33, 747, Gx_line+51, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(17, Gx_line+50, 800, Gx_line+50, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Address", 200, Gx_line+33, 254, Gx_line+51, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("EmpleadoHeadline", 408, Gx_line+33, 532, Gx_line+51, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+74);
            /* Using cursor P000G2 */
            pr_default.execute(0, new Object[] {AV8sucursalId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A3sucursalEmpleadoHeadlineId = P000G2_A3sucursalEmpleadoHeadlineId[0];
               A4sucursalEmpleadoAlternateId = P000G2_A4sucursalEmpleadoAlternateId[0];
               n4sucursalEmpleadoAlternateId = P000G2_n4sucursalEmpleadoAlternateId[0];
               A2sucursalId = P000G2_A2sucursalId[0];
               A20sucursalEmpleadoAlternateName = P000G2_A20sucursalEmpleadoAlternateName[0];
               A19sucursalEmpleadoHeadlineName = P000G2_A19sucursalEmpleadoHeadlineName[0];
               A14sucursalAddress = P000G2_A14sucursalAddress[0];
               A13sucursalName = P000G2_A13sucursalName[0];
               A19sucursalEmpleadoHeadlineName = P000G2_A19sucursalEmpleadoHeadlineName[0];
               A20sucursalEmpleadoAlternateName = P000G2_A20sucursalEmpleadoAlternateName[0];
               H0G0( false, 74) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A13sucursalName, "")), 25, Gx_line+33, 183, Gx_line+51, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A14sucursalAddress, "")), 200, Gx_line+33, 400, Gx_line+51, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A19sucursalEmpleadoHeadlineName, "")), 408, Gx_line+33, 616, Gx_line+51, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A20sucursalEmpleadoAlternateName, "")), 625, Gx_line+33, 808, Gx_line+51, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+74);
               H0G0( false, 58) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 14, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Productos", 350, Gx_line+17, 449, Gx_line+42, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+58);
               H0G0( false, 54) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Name", 250, Gx_line+17, 290, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Stock", 458, Gx_line+17, 494, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(250, Gx_line+33, 517, Gx_line+33, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+54);
               /* Using cursor P000G3 */
               pr_default.execute(1, new Object[] {A2sucursalId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A5productoId = P000G3_A5productoId[0];
                  A30productoStock = P000G3_A30productoStock[0];
                  A25productoName = P000G3_A25productoName[0];
                  A25productoName = P000G3_A25productoName[0];
                  H0G0( false, 100) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A25productoName, "")), 250, Gx_line+33, 417, Gx_line+48, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A30productoStock), "ZZZZZZZZZ9")), 467, Gx_line+33, 531, Gx_line+48, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+100);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0G0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void H0G0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if (IsMain)	waitPrinterEnd();
         base.cleanup();
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
         GXKey = "";
         gxfirstwebparm = "";
         scmdbuf = "";
         P000G2_A3sucursalEmpleadoHeadlineId = new short[1] ;
         P000G2_A4sucursalEmpleadoAlternateId = new short[1] ;
         P000G2_n4sucursalEmpleadoAlternateId = new bool[] {false} ;
         P000G2_A2sucursalId = new short[1] ;
         P000G2_A20sucursalEmpleadoAlternateName = new string[] {""} ;
         P000G2_A19sucursalEmpleadoHeadlineName = new string[] {""} ;
         P000G2_A14sucursalAddress = new string[] {""} ;
         P000G2_A13sucursalName = new string[] {""} ;
         A20sucursalEmpleadoAlternateName = "";
         A19sucursalEmpleadoHeadlineName = "";
         A14sucursalAddress = "";
         A13sucursalName = "";
         P000G3_A5productoId = new short[1] ;
         P000G3_A2sucursalId = new short[1] ;
         P000G3_A30productoStock = new long[1] ;
         P000G3_A25productoName = new string[] {""} ;
         A25productoName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.asucursallist__default(),
            new Object[][] {
                new Object[] {
               P000G2_A3sucursalEmpleadoHeadlineId, P000G2_A4sucursalEmpleadoAlternateId, P000G2_n4sucursalEmpleadoAlternateId, P000G2_A2sucursalId, P000G2_A20sucursalEmpleadoAlternateName, P000G2_A19sucursalEmpleadoHeadlineName, P000G2_A14sucursalAddress, P000G2_A13sucursalName
               }
               , new Object[] {
               P000G3_A5productoId, P000G3_A2sucursalId, P000G3_A30productoStock, P000G3_A25productoName
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV8sucursalId ;
      private short GxWebError ;
      private short A3sucursalEmpleadoHeadlineId ;
      private short A4sucursalEmpleadoAlternateId ;
      private short A2sucursalId ;
      private short A5productoId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long A30productoStock ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n4sucursalEmpleadoAlternateId ;
      private string A20sucursalEmpleadoAlternateName ;
      private string A19sucursalEmpleadoHeadlineName ;
      private string A14sucursalAddress ;
      private string A13sucursalName ;
      private string A25productoName ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000G2_A3sucursalEmpleadoHeadlineId ;
      private short[] P000G2_A4sucursalEmpleadoAlternateId ;
      private bool[] P000G2_n4sucursalEmpleadoAlternateId ;
      private short[] P000G2_A2sucursalId ;
      private string[] P000G2_A20sucursalEmpleadoAlternateName ;
      private string[] P000G2_A19sucursalEmpleadoHeadlineName ;
      private string[] P000G2_A14sucursalAddress ;
      private string[] P000G2_A13sucursalName ;
      private short[] P000G3_A5productoId ;
      private short[] P000G3_A2sucursalId ;
      private long[] P000G3_A30productoStock ;
      private string[] P000G3_A25productoName ;
   }

   public class asucursallist__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000G2;
          prmP000G2 = new Object[] {
          new ParDef("@AV8sucursalId",GXType.Int16,4,0)
          };
          Object[] prmP000G3;
          prmP000G3 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000G2", "SELECT T1.[sucursalEmpleadoHeadlineId] AS sucursalEmpleadoHeadlineId, T1.[sucursalEmpleadoAlternateId] AS sucursalEmpleadoAlternateId, T1.[sucursalId], T3.[empleadoName] AS sucursalEmpleadoAlternateName, T2.[empleadoName] AS sucursalEmpleadoHeadlineName, T1.[sucursalAddress], T1.[sucursalName] FROM (([sucursal] T1 INNER JOIN [empleado] T2 ON T2.[empleadoId] = T1.[sucursalEmpleadoHeadlineId]) LEFT JOIN [empleado] T3 ON T3.[empleadoId] = T1.[sucursalEmpleadoAlternateId]) WHERE T1.[sucursalId] = @AV8sucursalId ORDER BY T1.[sucursalId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000G2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000G3", "SELECT T1.[productoId], T1.[sucursalId], T1.[productoStock], T2.[productoName] FROM ([sucursalproducto] T1 INNER JOIN [producto] T2 ON T2.[productoId] = T1.[productoId]) WHERE T1.[sucursalId] = @sucursalId ORDER BY T2.[productoName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000G3,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
