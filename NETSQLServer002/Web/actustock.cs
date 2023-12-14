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
   public class actustock : GXProcedure
   {
      public actustock( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("xd2", true);
      }

      public actustock( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_sucursalId ,
                           short aP1_proveedorId ,
                           short aP2_productoId ,
                           long aP3_countStock ,
                           out string aP4_Mensaje )
      {
         this.AV12sucursalId = aP0_sucursalId;
         this.AV11proveedorId = aP1_proveedorId;
         this.AV10productoId = aP2_productoId;
         this.AV8countStock = aP3_countStock;
         this.AV9Mensaje = "" ;
         initialize();
         executePrivate();
         aP4_Mensaje=this.AV9Mensaje;
      }

      public string executeUdp( short aP0_sucursalId ,
                                short aP1_proveedorId ,
                                short aP2_productoId ,
                                long aP3_countStock )
      {
         execute(aP0_sucursalId, aP1_proveedorId, aP2_productoId, aP3_countStock, out aP4_Mensaje);
         return AV9Mensaje ;
      }

      public void executeSubmit( short aP0_sucursalId ,
                                 short aP1_proveedorId ,
                                 short aP2_productoId ,
                                 long aP3_countStock ,
                                 out string aP4_Mensaje )
      {
         actustock objactustock;
         objactustock = new actustock();
         objactustock.AV12sucursalId = aP0_sucursalId;
         objactustock.AV11proveedorId = aP1_proveedorId;
         objactustock.AV10productoId = aP2_productoId;
         objactustock.AV8countStock = aP3_countStock;
         objactustock.AV9Mensaje = "" ;
         objactustock.context.SetSubmitInitialConfig(context);
         objactustock.initialize();
         Submit( executePrivateCatch,objactustock);
         aP4_Mensaje=this.AV9Mensaje;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((actustock)stateInfo).executePrivate();
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
         /* Using cursor P000I2 */
         pr_default.execute(0, new Object[] {AV12sucursalId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2sucursalId = P000I2_A2sucursalId[0];
            /* Using cursor P000I3 */
            pr_default.execute(1, new Object[] {AV11proveedorId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A7proveedorId = P000I3_A7proveedorId[0];
               W7proveedorId = A7proveedorId;
               /* Using cursor P000I4 */
               pr_default.execute(2, new Object[] {AV12sucursalId, AV10productoId, A7proveedorId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A2sucursalId = P000I4_A2sucursalId[0];
                  A5productoId = P000I4_A5productoId[0];
                  A30productoStock = P000I4_A30productoStock[0];
                  A30productoStock = (long)(A30productoStock+AV8countStock);
                  AV9Mensaje = "Stock actualizado";
                  /* Using cursor P000I5 */
                  pr_default.execute(3, new Object[] {A30productoStock, A2sucursalId, A5productoId});
                  pr_default.close(3);
                  pr_default.SmartCacheProvider.SetUpdated("sucursalproducto");
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(2);
               A7proveedorId = W7proveedorId;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9Mensaje)) )
         {
            A2sucursalId = AV12sucursalId;
            /*
               INSERT RECORD ON TABLE sucursalproducto

            */
            A5productoId = AV10productoId;
            A30productoStock = AV8countStock;
            AV9Mensaje = "Producto agregado";
            /* Using cursor P000I6 */
            pr_default.execute(4, new Object[] {A2sucursalId, A5productoId, A30productoStock});
            pr_default.close(4);
            pr_default.SmartCacheProvider.SetUpdated("sucursalproducto");
            if ( (pr_default.getStatus(4) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
         }
         this.cleanup();
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         context.CommitDataStores("actustock",pr_default);
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
         AV9Mensaje = "";
         scmdbuf = "";
         P000I2_A2sucursalId = new short[1] ;
         P000I3_A7proveedorId = new short[1] ;
         P000I4_A7proveedorId = new short[1] ;
         P000I4_A2sucursalId = new short[1] ;
         P000I4_A5productoId = new short[1] ;
         P000I4_A30productoStock = new long[1] ;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actustock__default(),
            new Object[][] {
                new Object[] {
               P000I2_A2sucursalId
               }
               , new Object[] {
               P000I3_A7proveedorId
               }
               , new Object[] {
               P000I4_A7proveedorId, P000I4_A2sucursalId, P000I4_A5productoId, P000I4_A30productoStock
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV12sucursalId ;
      private short AV11proveedorId ;
      private short AV10productoId ;
      private short A2sucursalId ;
      private short A7proveedorId ;
      private short W7proveedorId ;
      private short A5productoId ;
      private int GX_INS3 ;
      private long AV8countStock ;
      private long A30productoStock ;
      private string scmdbuf ;
      private string Gx_emsg ;
      private string AV9Mensaje ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000I2_A2sucursalId ;
      private short[] P000I3_A7proveedorId ;
      private short[] P000I4_A7proveedorId ;
      private short[] P000I4_A2sucursalId ;
      private short[] P000I4_A5productoId ;
      private long[] P000I4_A30productoStock ;
      private string aP4_Mensaje ;
   }

   public class actustock__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new UpdateCursor(def[3])
         ,new UpdateCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000I2;
          prmP000I2 = new Object[] {
          new ParDef("@AV12sucursalId",GXType.Int16,4,0)
          };
          Object[] prmP000I3;
          prmP000I3 = new Object[] {
          new ParDef("@AV11proveedorId",GXType.Int16,4,0)
          };
          Object[] prmP000I4;
          prmP000I4 = new Object[] {
          new ParDef("@AV12sucursalId",GXType.Int16,4,0) ,
          new ParDef("@AV10productoId",GXType.Int16,4,0) ,
          new ParDef("@proveedorId",GXType.Int16,4,0)
          };
          Object[] prmP000I5;
          prmP000I5 = new Object[] {
          new ParDef("@productoStock",GXType.Decimal,10,0) ,
          new ParDef("@sucursalId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmP000I6;
          prmP000I6 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0) ,
          new ParDef("@productoStock",GXType.Decimal,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000I2", "SELECT [sucursalId] FROM [sucursal] WHERE [sucursalId] = @AV12sucursalId ORDER BY [sucursalId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000I2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000I3", "SELECT [proveedorId] FROM [proveedor] WHERE [proveedorId] = @AV11proveedorId ORDER BY [proveedorId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000I3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000I4", "SELECT T2.[proveedorId], T1.[sucursalId], T1.[productoId], T1.[productoStock] FROM ([sucursalproducto] T1 WITH (UPDLOCK) INNER JOIN [producto] T2 ON T2.[productoId] = T1.[productoId]) WHERE (T1.[sucursalId] = @AV12sucursalId and T1.[productoId] = @AV10productoId) AND (T2.[proveedorId] = @proveedorId) ORDER BY T1.[sucursalId], T1.[productoId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000I4,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000I5", "UPDATE [sucursalproducto] SET [productoStock]=@productoStock  WHERE [sucursalId] = @sucursalId AND [productoId] = @productoId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000I5)
             ,new CursorDef("P000I6", "INSERT INTO [sucursalproducto]([sucursalId], [productoId], [productoStock]) VALUES(@sucursalId, @productoId, @productoStock)", GxErrorMask.GX_NOMASK,prmP000I6)
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
       }
    }

 }

}
