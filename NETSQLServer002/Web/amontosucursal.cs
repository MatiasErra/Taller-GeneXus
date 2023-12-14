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
   public class amontosucursal : GXWebProcedure
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
            gxfirstwebparm = GetFirstPar( "fechaInicio");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV9fechaInicio = context.localUtil.ParseDateParm( gxfirstwebparm);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV8fechaFin = context.localUtil.ParseDateParm( GetPar( "fechaFin"));
               }
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

      public amontosucursal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("xd2", true);
      }

      public amontosucursal( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_fechaInicio ,
                           DateTime aP1_fechaFin )
      {
         this.AV9fechaInicio = aP0_fechaInicio;
         this.AV8fechaFin = aP1_fechaFin;
         initialize();
         executePrivate();
      }

      public void executeSubmit( DateTime aP0_fechaInicio ,
                                 DateTime aP1_fechaFin )
      {
         amontosucursal objamontosucursal;
         objamontosucursal = new amontosucursal();
         objamontosucursal.AV9fechaInicio = aP0_fechaInicio;
         objamontosucursal.AV8fechaFin = aP1_fechaFin;
         objamontosucursal.context.SetSubmitInitialConfig(context);
         objamontosucursal.initialize();
         Submit( executePrivateCatch,objamontosucursal);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((amontosucursal)stateInfo).executePrivate();
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
            H0F0( false, 100) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 16, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Sucursales", 350, Gx_line+33, 475, Gx_line+66, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+100);
            H0F0( false, 100) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Nombre:", 158, Gx_line+33, 213, Gx_line+51, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Total:", 492, Gx_line+33, 528, Gx_line+51, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(150, Gx_line+50, 600, Gx_line+50, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+100);
            /* Using cursor P000F2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A2sucursalId = P000F2_A2sucursalId[0];
               A13sucursalName = P000F2_A13sucursalName[0];
               AV10TotalMonto = 0;
               /* Using cursor P000F3 */
               pr_default.execute(1, new Object[] {A2sucursalId, AV9fechaInicio, AV8fechaFin});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A8facturaId = P000F3_A8facturaId[0];
                  A31facturaDate = P000F3_A31facturaDate[0];
                  /* Using cursor P000F4 */
                  pr_default.execute(2, new Object[] {A8facturaId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A5productoId = P000F4_A5productoId[0];
                     A27productoSellPrice = P000F4_A27productoSellPrice[0];
                     A34productoCount = P000F4_A34productoCount[0];
                     A27productoSellPrice = P000F4_A27productoSellPrice[0];
                     /* Using cursor P000F5 */
                     pr_default.execute(3, new Object[] {A5productoId});
                     while ( (pr_default.getStatus(3) != 101) )
                     {
                        AV10TotalMonto = (short)(AV10TotalMonto+((A34productoCount*A27productoSellPrice)));
                        /* Exiting from a For First loop. */
                        if (true) break;
                     }
                     pr_default.close(3);
                     pr_default.readNext(2);
                  }
                  pr_default.close(2);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               H0F0( false, 100) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A13sucursalName, "")), 150, Gx_line+33, 401, Gx_line+51, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV10TotalMonto), "ZZZ9")), 492, Gx_line+33, 667, Gx_line+50, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+100);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0F0( true, 0) ;
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

      protected void H0F0( bool bFoot ,
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
         P000F2_A2sucursalId = new short[1] ;
         P000F2_A13sucursalName = new string[] {""} ;
         A13sucursalName = "";
         P000F3_A2sucursalId = new short[1] ;
         P000F3_A8facturaId = new short[1] ;
         P000F3_A31facturaDate = new DateTime[] {DateTime.MinValue} ;
         A31facturaDate = DateTime.MinValue;
         P000F4_A8facturaId = new short[1] ;
         P000F4_A5productoId = new short[1] ;
         P000F4_A27productoSellPrice = new decimal[1] ;
         P000F4_A34productoCount = new short[1] ;
         P000F5_A5productoId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.amontosucursal__default(),
            new Object[][] {
                new Object[] {
               P000F2_A2sucursalId, P000F2_A13sucursalName
               }
               , new Object[] {
               P000F3_A2sucursalId, P000F3_A8facturaId, P000F3_A31facturaDate
               }
               , new Object[] {
               P000F4_A8facturaId, P000F4_A5productoId, P000F4_A27productoSellPrice, P000F4_A34productoCount
               }
               , new Object[] {
               P000F5_A5productoId
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short A2sucursalId ;
      private short AV10TotalMonto ;
      private short A8facturaId ;
      private short A5productoId ;
      private short A34productoCount ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private decimal A27productoSellPrice ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime AV9fechaInicio ;
      private DateTime AV8fechaFin ;
      private DateTime A31facturaDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string A13sucursalName ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000F2_A2sucursalId ;
      private string[] P000F2_A13sucursalName ;
      private short[] P000F3_A2sucursalId ;
      private short[] P000F3_A8facturaId ;
      private DateTime[] P000F3_A31facturaDate ;
      private short[] P000F4_A8facturaId ;
      private short[] P000F4_A5productoId ;
      private decimal[] P000F4_A27productoSellPrice ;
      private short[] P000F4_A34productoCount ;
      private short[] P000F5_A5productoId ;
   }

   public class amontosucursal__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000F2;
          prmP000F2 = new Object[] {
          };
          Object[] prmP000F3;
          prmP000F3 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0) ,
          new ParDef("@AV9fechaInicio",GXType.Date,8,0) ,
          new ParDef("@AV8fechaFin",GXType.Date,8,0)
          };
          Object[] prmP000F4;
          prmP000F4 = new Object[] {
          new ParDef("@facturaId",GXType.Int16,4,0)
          };
          Object[] prmP000F5;
          prmP000F5 = new Object[] {
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000F2", "SELECT [sucursalId], [sucursalName] FROM [sucursal] ORDER BY [sucursalId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000F2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000F3", "SELECT [sucursalId], [facturaId], [facturaDate] FROM [factura] WHERE ([sucursalId] = @sucursalId) AND ([facturaDate] >= @AV9fechaInicio and [facturaDate] <= @AV8fechaFin) ORDER BY [sucursalId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000F3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000F4", "SELECT T1.[facturaId], T1.[productoId], T2.[productoSellPrice], T1.[productoCount] FROM ([facturaproducto] T1 INNER JOIN [producto] T2 ON T2.[productoId] = T1.[productoId]) WHERE T1.[facturaId] = @facturaId ORDER BY T1.[facturaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000F4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000F5", "SELECT [productoId] FROM [producto] WHERE [productoId] = @productoId ORDER BY [productoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000F5,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
