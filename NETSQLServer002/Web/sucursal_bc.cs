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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class sucursal_bc : GxSilentTrn, IGxSilentTrn
   {
      public sucursal_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("xd2", true);
      }

      public sucursal_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow022( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey022( ) ;
         standaloneModal( ) ;
         AddRow022( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E11022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z2sucursalId = A2sucursalId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_020( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls022( ) ;
            }
            else
            {
               CheckExtendedTable022( ) ;
               if ( AnyError == 0 )
               {
                  ZM022( 8) ;
                  ZM022( 9) ;
               }
               CloseExtendedTableCursors022( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode2 = Gx_mode;
            CONFIRM_023( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode2;
               IsConfirmed = 1;
            }
            /* Restore parent mode. */
            Gx_mode = sMode2;
         }
      }

      protected void CONFIRM_023( )
      {
         nGXsfl_3_idx = 0;
         while ( nGXsfl_3_idx < bcsucursal.gxTpr_Producto.Count )
         {
            ReadRow023( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound3 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_3 != 0 ) )
            {
               GetKey023( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound3 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate023( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable023( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM023( 11) ;
                        }
                        CloseExtendedTableCursors023( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound3 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey023( ) ;
                        Load023( ) ;
                        BeforeValidate023( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls023( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_3 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate023( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable023( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM023( 11) ;
                              }
                              CloseExtendedTableCursors023( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow3( ((Sdtsucursal_producto)bcsucursal.gxTpr_Producto.Item(nGXsfl_3_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E12022( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11022( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z13sucursalName = A13sucursalName;
            Z14sucursalAddress = A14sucursalAddress;
            Z17sucursalGeolocation = A17sucursalGeolocation;
            Z18sucursalAddedDate = A18sucursalAddedDate;
            Z3sucursalEmpleadoHeadlineId = A3sucursalEmpleadoHeadlineId;
            Z4sucursalEmpleadoAlternateId = A4sucursalEmpleadoAlternateId;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z19sucursalEmpleadoHeadlineName = A19sucursalEmpleadoHeadlineName;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z20sucursalEmpleadoAlternateName = A20sucursalEmpleadoAlternateName;
         }
         if ( GX_JID == -7 )
         {
            Z2sucursalId = A2sucursalId;
            Z13sucursalName = A13sucursalName;
            Z14sucursalAddress = A14sucursalAddress;
            Z17sucursalGeolocation = A17sucursalGeolocation;
            Z18sucursalAddedDate = A18sucursalAddedDate;
            Z3sucursalEmpleadoHeadlineId = A3sucursalEmpleadoHeadlineId;
            Z4sucursalEmpleadoAlternateId = A4sucursalEmpleadoAlternateId;
            Z19sucursalEmpleadoHeadlineName = A19sucursalEmpleadoHeadlineName;
            Z20sucursalEmpleadoAlternateName = A20sucursalEmpleadoAlternateName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_date = DateTimeUtil.Today( context);
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A18sucursalAddedDate = Gx_date;
         }
      }

      protected void Load022( )
      {
         /* Using cursor BC00029 */
         pr_default.execute(7, new Object[] {A2sucursalId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound2 = 1;
            A13sucursalName = BC00029_A13sucursalName[0];
            A14sucursalAddress = BC00029_A14sucursalAddress[0];
            A17sucursalGeolocation = BC00029_A17sucursalGeolocation[0];
            A18sucursalAddedDate = BC00029_A18sucursalAddedDate[0];
            A19sucursalEmpleadoHeadlineName = BC00029_A19sucursalEmpleadoHeadlineName[0];
            A20sucursalEmpleadoAlternateName = BC00029_A20sucursalEmpleadoAlternateName[0];
            A3sucursalEmpleadoHeadlineId = BC00029_A3sucursalEmpleadoHeadlineId[0];
            A4sucursalEmpleadoAlternateId = BC00029_A4sucursalEmpleadoAlternateId[0];
            n4sucursalEmpleadoAlternateId = BC00029_n4sucursalEmpleadoAlternateId[0];
            ZM022( -7) ;
         }
         pr_default.close(7);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
      }

      protected void CheckExtendedTable022( )
      {
         nIsDirty_2 = 0;
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A13sucursalName)) )
         {
            GX_msglist.addItem("Falta el nombre", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A14sucursalAddress)) )
         {
            GX_msglist.addItem("Falta la direccion", 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A17sucursalGeolocation,"^\\s*(-?([0-8]?[0-9]\\.{1}\\d+|90\\.{1}0+)\\s*,\\s*-?([0-9]{1,2}\\.{1}\\d+|1[0-7][0-9]\\.{1}\\d+|180\\.{1}0+)\\s*)?$") ) )
         {
            GX_msglist.addItem("El valor de sucursal Geolocation no coincide con el patrón especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00027 */
         pr_default.execute(5, new Object[] {A3sucursalEmpleadoHeadlineId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'sucursal Empleado Headline'.", "ForeignKeyNotFound", 1, "SUCURSALEMPLEADOHEADLINEID");
            AnyError = 1;
         }
         A19sucursalEmpleadoHeadlineName = BC00027_A19sucursalEmpleadoHeadlineName[0];
         pr_default.close(5);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A19sucursalEmpleadoHeadlineName)) )
         {
            GX_msglist.addItem("Falta el encargado titular", 1, "");
            AnyError = 1;
         }
         if ( A3sucursalEmpleadoHeadlineId == A4sucursalEmpleadoAlternateId )
         {
            GX_msglist.addItem("Los encargados son los mismos", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00028 */
         pr_default.execute(6, new Object[] {n4sucursalEmpleadoAlternateId, A4sucursalEmpleadoAlternateId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A4sucursalEmpleadoAlternateId) ) )
            {
               GX_msglist.addItem("No existe 'sucursal Empleado Alternate'.", "ForeignKeyNotFound", 1, "SUCURSALEMPLEADOALTERNATEID");
               AnyError = 1;
            }
         }
         A20sucursalEmpleadoAlternateName = BC00028_A20sucursalEmpleadoAlternateName[0];
         pr_default.close(6);
      }

      protected void CloseExtendedTableCursors022( )
      {
         pr_default.close(5);
         pr_default.close(6);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey022( )
      {
         /* Using cursor BC000210 */
         pr_default.execute(8, new Object[] {A2sucursalId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00026 */
         pr_default.execute(4, new Object[] {A2sucursalId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM022( 7) ;
            RcdFound2 = 1;
            A2sucursalId = BC00026_A2sucursalId[0];
            A13sucursalName = BC00026_A13sucursalName[0];
            A14sucursalAddress = BC00026_A14sucursalAddress[0];
            A17sucursalGeolocation = BC00026_A17sucursalGeolocation[0];
            A18sucursalAddedDate = BC00026_A18sucursalAddedDate[0];
            A3sucursalEmpleadoHeadlineId = BC00026_A3sucursalEmpleadoHeadlineId[0];
            A4sucursalEmpleadoAlternateId = BC00026_A4sucursalEmpleadoAlternateId[0];
            n4sucursalEmpleadoAlternateId = BC00026_n4sucursalEmpleadoAlternateId[0];
            Z2sucursalId = A2sucursalId;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode2;
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_020( ) ;
         IsConfirmed = 0;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00025 */
            pr_default.execute(3, new Object[] {A2sucursalId});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"sucursal"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z13sucursalName, BC00025_A13sucursalName[0]) != 0 ) || ( StringUtil.StrCmp(Z14sucursalAddress, BC00025_A14sucursalAddress[0]) != 0 ) || ( StringUtil.StrCmp(Z17sucursalGeolocation, BC00025_A17sucursalGeolocation[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z18sucursalAddedDate ) != DateTimeUtil.ResetTime ( BC00025_A18sucursalAddedDate[0] ) ) || ( Z3sucursalEmpleadoHeadlineId != BC00025_A3sucursalEmpleadoHeadlineId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z4sucursalEmpleadoAlternateId != BC00025_A4sucursalEmpleadoAlternateId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"sucursal"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000211 */
                     pr_default.execute(9, new Object[] {A13sucursalName, A14sucursalAddress, A17sucursalGeolocation, A18sucursalAddedDate, A3sucursalEmpleadoHeadlineId, n4sucursalEmpleadoAlternateId, A4sucursalEmpleadoAlternateId});
                     A2sucursalId = BC000211_A2sucursalId[0];
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("sucursal");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel022( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000212 */
                     pr_default.execute(10, new Object[] {A13sucursalName, A14sucursalAddress, A17sucursalGeolocation, A18sucursalAddedDate, A3sucursalEmpleadoHeadlineId, n4sucursalEmpleadoAlternateId, A4sucursalEmpleadoAlternateId, A2sucursalId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("sucursal");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"sucursal"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel022( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart023( ) ;
                  while ( RcdFound3 != 0 )
                  {
                     getByPrimaryKey023( ) ;
                     Delete023( ) ;
                     ScanKeyNext023( ) ;
                  }
                  ScanKeyEnd023( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000213 */
                     pr_default.execute(11, new Object[] {A2sucursalId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("sucursal");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                           endTrnMsgCod = "SuccessfullyDeleted";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
         }
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel022( ) ;
         Gx_mode = sMode2;
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000214 */
            pr_default.execute(12, new Object[] {A3sucursalEmpleadoHeadlineId});
            A19sucursalEmpleadoHeadlineName = BC000214_A19sucursalEmpleadoHeadlineName[0];
            pr_default.close(12);
            /* Using cursor BC000215 */
            pr_default.execute(13, new Object[] {n4sucursalEmpleadoAlternateId, A4sucursalEmpleadoAlternateId});
            A20sucursalEmpleadoAlternateName = BC000215_A20sucursalEmpleadoAlternateName[0];
            pr_default.close(13);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000216 */
            pr_default.execute(14, new Object[] {A2sucursalId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"factura"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void ProcessNestedLevel023( )
      {
         nGXsfl_3_idx = 0;
         while ( nGXsfl_3_idx < bcsucursal.gxTpr_Producto.Count )
         {
            ReadRow023( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound3 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_3 != 0 ) )
            {
               standaloneNotModal023( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert023( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete023( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update023( ) ;
                  }
               }
            }
            KeyVarsToRow3( ((Sdtsucursal_producto)bcsucursal.gxTpr_Producto.Item(nGXsfl_3_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_3_idx = 0;
            while ( nGXsfl_3_idx < bcsucursal.gxTpr_Producto.Count )
            {
               ReadRow023( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound3 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcsucursal.gxTpr_Producto.RemoveElement(nGXsfl_3_idx);
                  nGXsfl_3_idx = (int)(nGXsfl_3_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey023( ) ;
                  VarsToRow3( ((Sdtsucursal_producto)bcsucursal.gxTpr_Producto.Item(nGXsfl_3_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll023( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_3 = 0;
         nIsMod_3 = 0;
         Gxremove3 = 0;
      }

      protected void ProcessLevel022( )
      {
         /* Save parent mode. */
         sMode2 = Gx_mode;
         ProcessNestedLevel023( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode2;
         /* ' Update level parameters */
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart022( )
      {
         /* Scan By routine */
         /* Using cursor BC000217 */
         pr_default.execute(15, new Object[] {A2sucursalId});
         RcdFound2 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound2 = 1;
            A2sucursalId = BC000217_A2sucursalId[0];
            A13sucursalName = BC000217_A13sucursalName[0];
            A14sucursalAddress = BC000217_A14sucursalAddress[0];
            A17sucursalGeolocation = BC000217_A17sucursalGeolocation[0];
            A18sucursalAddedDate = BC000217_A18sucursalAddedDate[0];
            A19sucursalEmpleadoHeadlineName = BC000217_A19sucursalEmpleadoHeadlineName[0];
            A20sucursalEmpleadoAlternateName = BC000217_A20sucursalEmpleadoAlternateName[0];
            A3sucursalEmpleadoHeadlineId = BC000217_A3sucursalEmpleadoHeadlineId[0];
            A4sucursalEmpleadoAlternateId = BC000217_A4sucursalEmpleadoAlternateId[0];
            n4sucursalEmpleadoAlternateId = BC000217_n4sucursalEmpleadoAlternateId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound2 = 0;
         ScanKeyLoad022( ) ;
      }

      protected void ScanKeyLoad022( )
      {
         sMode2 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound2 = 1;
            A2sucursalId = BC000217_A2sucursalId[0];
            A13sucursalName = BC000217_A13sucursalName[0];
            A14sucursalAddress = BC000217_A14sucursalAddress[0];
            A17sucursalGeolocation = BC000217_A17sucursalGeolocation[0];
            A18sucursalAddedDate = BC000217_A18sucursalAddedDate[0];
            A19sucursalEmpleadoHeadlineName = BC000217_A19sucursalEmpleadoHeadlineName[0];
            A20sucursalEmpleadoAlternateName = BC000217_A20sucursalEmpleadoAlternateName[0];
            A3sucursalEmpleadoHeadlineId = BC000217_A3sucursalEmpleadoHeadlineId[0];
            A4sucursalEmpleadoAlternateId = BC000217_A4sucursalEmpleadoAlternateId[0];
            n4sucursalEmpleadoAlternateId = BC000217_n4sucursalEmpleadoAlternateId[0];
         }
         Gx_mode = sMode2;
      }

      protected void ScanKeyEnd022( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
      }

      protected void ZM023( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z30productoStock = A30productoStock;
         }
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z25productoName = A25productoName;
         }
         if ( GX_JID == -10 )
         {
            Z2sucursalId = A2sucursalId;
            Z30productoStock = A30productoStock;
            Z5productoId = A5productoId;
            Z25productoName = A25productoName;
         }
      }

      protected void standaloneNotModal023( )
      {
      }

      protected void standaloneModal023( )
      {
      }

      protected void Load023( )
      {
         /* Using cursor BC000218 */
         pr_default.execute(16, new Object[] {A2sucursalId, A5productoId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound3 = 1;
            A25productoName = BC000218_A25productoName[0];
            A30productoStock = BC000218_A30productoStock[0];
            ZM023( -10) ;
         }
         pr_default.close(16);
         OnLoadActions023( ) ;
      }

      protected void OnLoadActions023( )
      {
      }

      protected void CheckExtendedTable023( )
      {
         nIsDirty_3 = 0;
         Gx_BScreen = 1;
         standaloneModal023( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC00024 */
         pr_default.execute(2, new Object[] {A5productoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'producto'.", "ForeignKeyNotFound", 1, "PRODUCTOID");
            AnyError = 1;
         }
         A25productoName = BC00024_A25productoName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors023( )
      {
         pr_default.close(2);
      }

      protected void enableDisable023( )
      {
      }

      protected void GetKey023( )
      {
         /* Using cursor BC000219 */
         pr_default.execute(17, new Object[] {A2sucursalId, A5productoId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(17);
      }

      protected void getByPrimaryKey023( )
      {
         /* Using cursor BC00023 */
         pr_default.execute(1, new Object[] {A2sucursalId, A5productoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM023( 10) ;
            RcdFound3 = 1;
            InitializeNonKey023( ) ;
            A30productoStock = BC00023_A30productoStock[0];
            A5productoId = BC00023_A5productoId[0];
            Z2sucursalId = A2sucursalId;
            Z5productoId = A5productoId;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal023( ) ;
            Load023( ) ;
            Gx_mode = sMode3;
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey023( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal023( ) ;
            Gx_mode = sMode3;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes023( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency023( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00022 */
            pr_default.execute(0, new Object[] {A2sucursalId, A5productoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"sucursalproducto"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z30productoStock != BC00022_A30productoStock[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"sucursalproducto"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert023( )
      {
         BeforeValidate023( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable023( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM023( 0) ;
            CheckOptimisticConcurrency023( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm023( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert023( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000220 */
                     pr_default.execute(18, new Object[] {A2sucursalId, A30productoStock, A5productoId});
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("sucursalproducto");
                     if ( (pr_default.getStatus(18) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load023( ) ;
            }
            EndLevel023( ) ;
         }
         CloseExtendedTableCursors023( ) ;
      }

      protected void Update023( )
      {
         BeforeValidate023( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable023( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency023( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm023( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate023( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000221 */
                     pr_default.execute(19, new Object[] {A30productoStock, A2sucursalId, A5productoId});
                     pr_default.close(19);
                     pr_default.SmartCacheProvider.SetUpdated("sucursalproducto");
                     if ( (pr_default.getStatus(19) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"sucursalproducto"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate023( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey023( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel023( ) ;
         }
         CloseExtendedTableCursors023( ) ;
      }

      protected void DeferredUpdate023( )
      {
      }

      protected void Delete023( )
      {
         Gx_mode = "DLT";
         BeforeValidate023( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency023( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls023( ) ;
            AfterConfirm023( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete023( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000222 */
                  pr_default.execute(20, new Object[] {A2sucursalId, A5productoId});
                  pr_default.close(20);
                  pr_default.SmartCacheProvider.SetUpdated("sucursalproducto");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel023( ) ;
         Gx_mode = sMode3;
      }

      protected void OnDeleteControls023( )
      {
         standaloneModal023( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000223 */
            pr_default.execute(21, new Object[] {A5productoId});
            A25productoName = BC000223_A25productoName[0];
            pr_default.close(21);
         }
      }

      protected void EndLevel023( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart023( )
      {
         /* Scan By routine */
         /* Using cursor BC000224 */
         pr_default.execute(22, new Object[] {A2sucursalId});
         RcdFound3 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound3 = 1;
            A25productoName = BC000224_A25productoName[0];
            A30productoStock = BC000224_A30productoStock[0];
            A5productoId = BC000224_A5productoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext023( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound3 = 0;
         ScanKeyLoad023( ) ;
      }

      protected void ScanKeyLoad023( )
      {
         sMode3 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound3 = 1;
            A25productoName = BC000224_A25productoName[0];
            A30productoStock = BC000224_A30productoStock[0];
            A5productoId = BC000224_A5productoId[0];
         }
         Gx_mode = sMode3;
      }

      protected void ScanKeyEnd023( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm023( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert023( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate023( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete023( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete023( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate023( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes023( )
      {
      }

      protected void send_integrity_lvl_hashes023( )
      {
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void AddRow022( )
      {
         VarsToRow2( bcsucursal) ;
      }

      protected void ReadRow022( )
      {
         RowToVars2( bcsucursal, 1) ;
      }

      protected void AddRow023( )
      {
         Sdtsucursal_producto obj3;
         obj3 = new Sdtsucursal_producto(context);
         VarsToRow3( obj3) ;
         bcsucursal.gxTpr_Producto.Add(obj3, 0);
         obj3.gxTpr_Mode = "UPD";
         obj3.gxTpr_Modified = 0;
      }

      protected void ReadRow023( )
      {
         nGXsfl_3_idx = (int)(nGXsfl_3_idx+1);
         RowToVars3( ((Sdtsucursal_producto)bcsucursal.gxTpr_Producto.Item(nGXsfl_3_idx)), 1) ;
      }

      protected void InitializeNonKey022( )
      {
         A13sucursalName = "";
         A14sucursalAddress = "";
         A17sucursalGeolocation = "";
         A18sucursalAddedDate = DateTime.MinValue;
         A3sucursalEmpleadoHeadlineId = 0;
         A19sucursalEmpleadoHeadlineName = "";
         A4sucursalEmpleadoAlternateId = 0;
         n4sucursalEmpleadoAlternateId = false;
         A20sucursalEmpleadoAlternateName = "";
         Z13sucursalName = "";
         Z14sucursalAddress = "";
         Z17sucursalGeolocation = "";
         Z18sucursalAddedDate = DateTime.MinValue;
         Z3sucursalEmpleadoHeadlineId = 0;
         Z4sucursalEmpleadoAlternateId = 0;
      }

      protected void InitAll022( )
      {
         A2sucursalId = 0;
         InitializeNonKey022( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A18sucursalAddedDate = i18sucursalAddedDate;
      }

      protected void InitializeNonKey023( )
      {
         A25productoName = "";
         A30productoStock = 0;
         Z30productoStock = 0;
      }

      protected void InitAll023( )
      {
         A5productoId = 0;
         InitializeNonKey023( ) ;
      }

      protected void StandaloneModalInsert023( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow2( Sdtsucursal obj2 )
      {
         obj2.gxTpr_Mode = Gx_mode;
         obj2.gxTpr_Sucursalname = A13sucursalName;
         obj2.gxTpr_Sucursaladdress = A14sucursalAddress;
         obj2.gxTpr_Sucursalgeolocation = A17sucursalGeolocation;
         obj2.gxTpr_Sucursaladdeddate = A18sucursalAddedDate;
         obj2.gxTpr_Sucursalempleadoheadlineid = A3sucursalEmpleadoHeadlineId;
         obj2.gxTpr_Sucursalempleadoheadlinename = A19sucursalEmpleadoHeadlineName;
         obj2.gxTpr_Sucursalempleadoalternateid = A4sucursalEmpleadoAlternateId;
         obj2.gxTpr_Sucursalempleadoalternatename = A20sucursalEmpleadoAlternateName;
         obj2.gxTpr_Sucursalid = A2sucursalId;
         obj2.gxTpr_Sucursalid_Z = Z2sucursalId;
         obj2.gxTpr_Sucursalname_Z = Z13sucursalName;
         obj2.gxTpr_Sucursaladdress_Z = Z14sucursalAddress;
         obj2.gxTpr_Sucursalgeolocation_Z = Z17sucursalGeolocation;
         obj2.gxTpr_Sucursaladdeddate_Z = Z18sucursalAddedDate;
         obj2.gxTpr_Sucursalempleadoheadlineid_Z = Z3sucursalEmpleadoHeadlineId;
         obj2.gxTpr_Sucursalempleadoheadlinename_Z = Z19sucursalEmpleadoHeadlineName;
         obj2.gxTpr_Sucursalempleadoalternateid_Z = Z4sucursalEmpleadoAlternateId;
         obj2.gxTpr_Sucursalempleadoalternatename_Z = Z20sucursalEmpleadoAlternateName;
         obj2.gxTpr_Sucursalempleadoalternateid_N = (short)(Convert.ToInt16(n4sucursalEmpleadoAlternateId));
         obj2.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow2( Sdtsucursal obj2 )
      {
         obj2.gxTpr_Sucursalid = A2sucursalId;
         return  ;
      }

      public void RowToVars2( Sdtsucursal obj2 ,
                              int forceLoad )
      {
         Gx_mode = obj2.gxTpr_Mode;
         A13sucursalName = obj2.gxTpr_Sucursalname;
         A14sucursalAddress = obj2.gxTpr_Sucursaladdress;
         A17sucursalGeolocation = obj2.gxTpr_Sucursalgeolocation;
         if ( forceLoad == 1 )
         {
            A18sucursalAddedDate = obj2.gxTpr_Sucursaladdeddate;
         }
         A3sucursalEmpleadoHeadlineId = obj2.gxTpr_Sucursalempleadoheadlineid;
         A19sucursalEmpleadoHeadlineName = obj2.gxTpr_Sucursalempleadoheadlinename;
         A4sucursalEmpleadoAlternateId = obj2.gxTpr_Sucursalempleadoalternateid;
         n4sucursalEmpleadoAlternateId = false;
         A20sucursalEmpleadoAlternateName = obj2.gxTpr_Sucursalempleadoalternatename;
         if ( forceLoad == 1 )
         {
            A2sucursalId = obj2.gxTpr_Sucursalid;
         }
         Z2sucursalId = obj2.gxTpr_Sucursalid_Z;
         Z13sucursalName = obj2.gxTpr_Sucursalname_Z;
         Z14sucursalAddress = obj2.gxTpr_Sucursaladdress_Z;
         Z17sucursalGeolocation = obj2.gxTpr_Sucursalgeolocation_Z;
         Z18sucursalAddedDate = obj2.gxTpr_Sucursaladdeddate_Z;
         Z3sucursalEmpleadoHeadlineId = obj2.gxTpr_Sucursalempleadoheadlineid_Z;
         Z19sucursalEmpleadoHeadlineName = obj2.gxTpr_Sucursalempleadoheadlinename_Z;
         Z4sucursalEmpleadoAlternateId = obj2.gxTpr_Sucursalempleadoalternateid_Z;
         Z20sucursalEmpleadoAlternateName = obj2.gxTpr_Sucursalempleadoalternatename_Z;
         n4sucursalEmpleadoAlternateId = (bool)(Convert.ToBoolean(obj2.gxTpr_Sucursalempleadoalternateid_N));
         Gx_mode = obj2.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow3( Sdtsucursal_producto obj3 )
      {
         obj3.gxTpr_Mode = Gx_mode;
         obj3.gxTpr_Productoname = A25productoName;
         obj3.gxTpr_Productostock = A30productoStock;
         obj3.gxTpr_Productoid = A5productoId;
         obj3.gxTpr_Productoid_Z = Z5productoId;
         obj3.gxTpr_Productoname_Z = Z25productoName;
         obj3.gxTpr_Productostock_Z = Z30productoStock;
         obj3.gxTpr_Modified = nIsMod_3;
         return  ;
      }

      public void KeyVarsToRow3( Sdtsucursal_producto obj3 )
      {
         obj3.gxTpr_Productoid = A5productoId;
         return  ;
      }

      public void RowToVars3( Sdtsucursal_producto obj3 ,
                              int forceLoad )
      {
         Gx_mode = obj3.gxTpr_Mode;
         A25productoName = obj3.gxTpr_Productoname;
         A30productoStock = obj3.gxTpr_Productostock;
         A5productoId = obj3.gxTpr_Productoid;
         Z5productoId = obj3.gxTpr_Productoid_Z;
         Z25productoName = obj3.gxTpr_Productoname_Z;
         Z30productoStock = obj3.gxTpr_Productostock_Z;
         nIsMod_3 = obj3.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A2sucursalId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey022( ) ;
         ScanKeyStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z2sucursalId = A2sucursalId;
         }
         ZM022( -7) ;
         OnLoadActions022( ) ;
         AddRow022( ) ;
         bcsucursal.gxTpr_Producto.ClearCollection();
         if ( RcdFound2 == 1 )
         {
            ScanKeyStart023( ) ;
            nGXsfl_3_idx = 1;
            while ( RcdFound3 != 0 )
            {
               Z2sucursalId = A2sucursalId;
               Z5productoId = A5productoId;
               ZM023( -10) ;
               OnLoadActions023( ) ;
               nRcdExists_3 = 1;
               nIsMod_3 = 0;
               AddRow023( ) ;
               nGXsfl_3_idx = (int)(nGXsfl_3_idx+1);
               ScanKeyNext023( ) ;
            }
            ScanKeyEnd023( ) ;
         }
         ScanKeyEnd022( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars2( bcsucursal, 0) ;
         ScanKeyStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z2sucursalId = A2sucursalId;
         }
         ZM022( -7) ;
         OnLoadActions022( ) ;
         AddRow022( ) ;
         bcsucursal.gxTpr_Producto.ClearCollection();
         if ( RcdFound2 == 1 )
         {
            ScanKeyStart023( ) ;
            nGXsfl_3_idx = 1;
            while ( RcdFound3 != 0 )
            {
               Z2sucursalId = A2sucursalId;
               Z5productoId = A5productoId;
               ZM023( -10) ;
               OnLoadActions023( ) ;
               nRcdExists_3 = 1;
               nIsMod_3 = 0;
               AddRow023( ) ;
               nGXsfl_3_idx = (int)(nGXsfl_3_idx+1);
               ScanKeyNext023( ) ;
            }
            ScanKeyEnd023( ) ;
         }
         ScanKeyEnd022( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert022( ) ;
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A2sucursalId != Z2sucursalId )
               {
                  A2sucursalId = Z2sucursalId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update022( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A2sucursalId != Z2sucursalId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert022( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert022( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars2( bcsucursal, 1) ;
         SaveImpl( ) ;
         VarsToRow2( bcsucursal) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars2( bcsucursal, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert022( ) ;
         AfterTrn( ) ;
         VarsToRow2( bcsucursal) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow2( bcsucursal) ;
         }
         else
         {
            Sdtsucursal auxBC = new Sdtsucursal(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A2sucursalId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcsucursal);
               auxBC.Save();
               bcsucursal.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars2( bcsucursal, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars2( bcsucursal, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert022( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow2( bcsucursal) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow2( bcsucursal) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars2( bcsucursal, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey022( ) ;
         if ( RcdFound2 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A2sucursalId != Z2sucursalId )
            {
               A2sucursalId = Z2sucursalId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A2sucursalId != Z2sucursalId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(4);
         pr_default.close(1);
         pr_default.close(12);
         pr_default.close(13);
         pr_default.close(21);
         context.RollbackDataStores("sucursal_bc",pr_default);
         VarsToRow2( bcsucursal) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcsucursal.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcsucursal.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcsucursal )
         {
            bcsucursal = (Sdtsucursal)(sdt);
            if ( StringUtil.StrCmp(bcsucursal.gxTpr_Mode, "") == 0 )
            {
               bcsucursal.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow2( bcsucursal) ;
            }
            else
            {
               RowToVars2( bcsucursal, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcsucursal.gxTpr_Mode, "") == 0 )
            {
               bcsucursal.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars2( bcsucursal, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public Sdtsucursal sucursal_BC
      {
         get {
            return bcsucursal ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
         pr_default.close(21);
         pr_default.close(4);
         pr_default.close(12);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode2 = "";
         Z13sucursalName = "";
         A13sucursalName = "";
         Z14sucursalAddress = "";
         A14sucursalAddress = "";
         Z17sucursalGeolocation = "";
         A17sucursalGeolocation = "";
         Z18sucursalAddedDate = DateTime.MinValue;
         A18sucursalAddedDate = DateTime.MinValue;
         Z19sucursalEmpleadoHeadlineName = "";
         A19sucursalEmpleadoHeadlineName = "";
         Z20sucursalEmpleadoAlternateName = "";
         A20sucursalEmpleadoAlternateName = "";
         Gx_date = DateTime.MinValue;
         BC00029_A2sucursalId = new short[1] ;
         BC00029_A13sucursalName = new string[] {""} ;
         BC00029_A14sucursalAddress = new string[] {""} ;
         BC00029_A17sucursalGeolocation = new string[] {""} ;
         BC00029_A18sucursalAddedDate = new DateTime[] {DateTime.MinValue} ;
         BC00029_A19sucursalEmpleadoHeadlineName = new string[] {""} ;
         BC00029_A20sucursalEmpleadoAlternateName = new string[] {""} ;
         BC00029_A3sucursalEmpleadoHeadlineId = new short[1] ;
         BC00029_A4sucursalEmpleadoAlternateId = new short[1] ;
         BC00029_n4sucursalEmpleadoAlternateId = new bool[] {false} ;
         BC00027_A19sucursalEmpleadoHeadlineName = new string[] {""} ;
         BC00028_A20sucursalEmpleadoAlternateName = new string[] {""} ;
         BC000210_A2sucursalId = new short[1] ;
         BC00026_A2sucursalId = new short[1] ;
         BC00026_A13sucursalName = new string[] {""} ;
         BC00026_A14sucursalAddress = new string[] {""} ;
         BC00026_A17sucursalGeolocation = new string[] {""} ;
         BC00026_A18sucursalAddedDate = new DateTime[] {DateTime.MinValue} ;
         BC00026_A3sucursalEmpleadoHeadlineId = new short[1] ;
         BC00026_A4sucursalEmpleadoAlternateId = new short[1] ;
         BC00026_n4sucursalEmpleadoAlternateId = new bool[] {false} ;
         BC00025_A2sucursalId = new short[1] ;
         BC00025_A13sucursalName = new string[] {""} ;
         BC00025_A14sucursalAddress = new string[] {""} ;
         BC00025_A17sucursalGeolocation = new string[] {""} ;
         BC00025_A18sucursalAddedDate = new DateTime[] {DateTime.MinValue} ;
         BC00025_A3sucursalEmpleadoHeadlineId = new short[1] ;
         BC00025_A4sucursalEmpleadoAlternateId = new short[1] ;
         BC00025_n4sucursalEmpleadoAlternateId = new bool[] {false} ;
         BC000211_A2sucursalId = new short[1] ;
         BC000214_A19sucursalEmpleadoHeadlineName = new string[] {""} ;
         BC000215_A20sucursalEmpleadoAlternateName = new string[] {""} ;
         BC000216_A8facturaId = new short[1] ;
         BC000217_A2sucursalId = new short[1] ;
         BC000217_A13sucursalName = new string[] {""} ;
         BC000217_A14sucursalAddress = new string[] {""} ;
         BC000217_A17sucursalGeolocation = new string[] {""} ;
         BC000217_A18sucursalAddedDate = new DateTime[] {DateTime.MinValue} ;
         BC000217_A19sucursalEmpleadoHeadlineName = new string[] {""} ;
         BC000217_A20sucursalEmpleadoAlternateName = new string[] {""} ;
         BC000217_A3sucursalEmpleadoHeadlineId = new short[1] ;
         BC000217_A4sucursalEmpleadoAlternateId = new short[1] ;
         BC000217_n4sucursalEmpleadoAlternateId = new bool[] {false} ;
         Z25productoName = "";
         A25productoName = "";
         BC000218_A2sucursalId = new short[1] ;
         BC000218_A25productoName = new string[] {""} ;
         BC000218_A30productoStock = new long[1] ;
         BC000218_A5productoId = new short[1] ;
         BC00024_A25productoName = new string[] {""} ;
         BC000219_A2sucursalId = new short[1] ;
         BC000219_A5productoId = new short[1] ;
         BC00023_A2sucursalId = new short[1] ;
         BC00023_A30productoStock = new long[1] ;
         BC00023_A5productoId = new short[1] ;
         sMode3 = "";
         BC00022_A2sucursalId = new short[1] ;
         BC00022_A30productoStock = new long[1] ;
         BC00022_A5productoId = new short[1] ;
         BC000223_A25productoName = new string[] {""} ;
         BC000224_A2sucursalId = new short[1] ;
         BC000224_A25productoName = new string[] {""} ;
         BC000224_A30productoStock = new long[1] ;
         BC000224_A5productoId = new short[1] ;
         i18sucursalAddedDate = DateTime.MinValue;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sucursal_bc__default(),
            new Object[][] {
                new Object[] {
               BC00022_A2sucursalId, BC00022_A30productoStock, BC00022_A5productoId
               }
               , new Object[] {
               BC00023_A2sucursalId, BC00023_A30productoStock, BC00023_A5productoId
               }
               , new Object[] {
               BC00024_A25productoName
               }
               , new Object[] {
               BC00025_A2sucursalId, BC00025_A13sucursalName, BC00025_A14sucursalAddress, BC00025_A17sucursalGeolocation, BC00025_A18sucursalAddedDate, BC00025_A3sucursalEmpleadoHeadlineId, BC00025_A4sucursalEmpleadoAlternateId, BC00025_n4sucursalEmpleadoAlternateId
               }
               , new Object[] {
               BC00026_A2sucursalId, BC00026_A13sucursalName, BC00026_A14sucursalAddress, BC00026_A17sucursalGeolocation, BC00026_A18sucursalAddedDate, BC00026_A3sucursalEmpleadoHeadlineId, BC00026_A4sucursalEmpleadoAlternateId, BC00026_n4sucursalEmpleadoAlternateId
               }
               , new Object[] {
               BC00027_A19sucursalEmpleadoHeadlineName
               }
               , new Object[] {
               BC00028_A20sucursalEmpleadoAlternateName
               }
               , new Object[] {
               BC00029_A2sucursalId, BC00029_A13sucursalName, BC00029_A14sucursalAddress, BC00029_A17sucursalGeolocation, BC00029_A18sucursalAddedDate, BC00029_A19sucursalEmpleadoHeadlineName, BC00029_A20sucursalEmpleadoAlternateName, BC00029_A3sucursalEmpleadoHeadlineId, BC00029_A4sucursalEmpleadoAlternateId, BC00029_n4sucursalEmpleadoAlternateId
               }
               , new Object[] {
               BC000210_A2sucursalId
               }
               , new Object[] {
               BC000211_A2sucursalId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000214_A19sucursalEmpleadoHeadlineName
               }
               , new Object[] {
               BC000215_A20sucursalEmpleadoAlternateName
               }
               , new Object[] {
               BC000216_A8facturaId
               }
               , new Object[] {
               BC000217_A2sucursalId, BC000217_A13sucursalName, BC000217_A14sucursalAddress, BC000217_A17sucursalGeolocation, BC000217_A18sucursalAddedDate, BC000217_A19sucursalEmpleadoHeadlineName, BC000217_A20sucursalEmpleadoAlternateName, BC000217_A3sucursalEmpleadoHeadlineId, BC000217_A4sucursalEmpleadoAlternateId, BC000217_n4sucursalEmpleadoAlternateId
               }
               , new Object[] {
               BC000218_A2sucursalId, BC000218_A25productoName, BC000218_A30productoStock, BC000218_A5productoId
               }
               , new Object[] {
               BC000219_A2sucursalId, BC000219_A5productoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000223_A25productoName
               }
               , new Object[] {
               BC000224_A2sucursalId, BC000224_A25productoName, BC000224_A30productoStock, BC000224_A5productoId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12022 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z2sucursalId ;
      private short A2sucursalId ;
      private short nIsMod_3 ;
      private short RcdFound3 ;
      private short GX_JID ;
      private short Z3sucursalEmpleadoHeadlineId ;
      private short A3sucursalEmpleadoHeadlineId ;
      private short Z4sucursalEmpleadoAlternateId ;
      private short A4sucursalEmpleadoAlternateId ;
      private short RcdFound2 ;
      private short nIsDirty_2 ;
      private short nRcdExists_3 ;
      private short Gxremove3 ;
      private short Z5productoId ;
      private short A5productoId ;
      private short nIsDirty_3 ;
      private short Gx_BScreen ;
      private int trnEnded ;
      private int nGXsfl_3_idx=1 ;
      private long Z30productoStock ;
      private long A30productoStock ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode2 ;
      private string Z17sucursalGeolocation ;
      private string A17sucursalGeolocation ;
      private string sMode3 ;
      private DateTime Z18sucursalAddedDate ;
      private DateTime A18sucursalAddedDate ;
      private DateTime Gx_date ;
      private DateTime i18sucursalAddedDate ;
      private bool returnInSub ;
      private bool n4sucursalEmpleadoAlternateId ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z13sucursalName ;
      private string A13sucursalName ;
      private string Z14sucursalAddress ;
      private string A14sucursalAddress ;
      private string Z19sucursalEmpleadoHeadlineName ;
      private string A19sucursalEmpleadoHeadlineName ;
      private string Z20sucursalEmpleadoAlternateName ;
      private string A20sucursalEmpleadoAlternateName ;
      private string Z25productoName ;
      private string A25productoName ;
      private Sdtsucursal bcsucursal ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00029_A2sucursalId ;
      private string[] BC00029_A13sucursalName ;
      private string[] BC00029_A14sucursalAddress ;
      private string[] BC00029_A17sucursalGeolocation ;
      private DateTime[] BC00029_A18sucursalAddedDate ;
      private string[] BC00029_A19sucursalEmpleadoHeadlineName ;
      private string[] BC00029_A20sucursalEmpleadoAlternateName ;
      private short[] BC00029_A3sucursalEmpleadoHeadlineId ;
      private short[] BC00029_A4sucursalEmpleadoAlternateId ;
      private bool[] BC00029_n4sucursalEmpleadoAlternateId ;
      private string[] BC00027_A19sucursalEmpleadoHeadlineName ;
      private string[] BC00028_A20sucursalEmpleadoAlternateName ;
      private short[] BC000210_A2sucursalId ;
      private short[] BC00026_A2sucursalId ;
      private string[] BC00026_A13sucursalName ;
      private string[] BC00026_A14sucursalAddress ;
      private string[] BC00026_A17sucursalGeolocation ;
      private DateTime[] BC00026_A18sucursalAddedDate ;
      private short[] BC00026_A3sucursalEmpleadoHeadlineId ;
      private short[] BC00026_A4sucursalEmpleadoAlternateId ;
      private bool[] BC00026_n4sucursalEmpleadoAlternateId ;
      private short[] BC00025_A2sucursalId ;
      private string[] BC00025_A13sucursalName ;
      private string[] BC00025_A14sucursalAddress ;
      private string[] BC00025_A17sucursalGeolocation ;
      private DateTime[] BC00025_A18sucursalAddedDate ;
      private short[] BC00025_A3sucursalEmpleadoHeadlineId ;
      private short[] BC00025_A4sucursalEmpleadoAlternateId ;
      private bool[] BC00025_n4sucursalEmpleadoAlternateId ;
      private short[] BC000211_A2sucursalId ;
      private string[] BC000214_A19sucursalEmpleadoHeadlineName ;
      private string[] BC000215_A20sucursalEmpleadoAlternateName ;
      private short[] BC000216_A8facturaId ;
      private short[] BC000217_A2sucursalId ;
      private string[] BC000217_A13sucursalName ;
      private string[] BC000217_A14sucursalAddress ;
      private string[] BC000217_A17sucursalGeolocation ;
      private DateTime[] BC000217_A18sucursalAddedDate ;
      private string[] BC000217_A19sucursalEmpleadoHeadlineName ;
      private string[] BC000217_A20sucursalEmpleadoAlternateName ;
      private short[] BC000217_A3sucursalEmpleadoHeadlineId ;
      private short[] BC000217_A4sucursalEmpleadoAlternateId ;
      private bool[] BC000217_n4sucursalEmpleadoAlternateId ;
      private short[] BC000218_A2sucursalId ;
      private string[] BC000218_A25productoName ;
      private long[] BC000218_A30productoStock ;
      private short[] BC000218_A5productoId ;
      private string[] BC00024_A25productoName ;
      private short[] BC000219_A2sucursalId ;
      private short[] BC000219_A5productoId ;
      private short[] BC00023_A2sucursalId ;
      private long[] BC00023_A30productoStock ;
      private short[] BC00023_A5productoId ;
      private short[] BC00022_A2sucursalId ;
      private long[] BC00022_A30productoStock ;
      private short[] BC00022_A5productoId ;
      private string[] BC000223_A25productoName ;
      private short[] BC000224_A2sucursalId ;
      private string[] BC000224_A25productoName ;
      private long[] BC000224_A30productoStock ;
      private short[] BC000224_A5productoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class sucursal_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new UpdateCursor(def[19])
         ,new UpdateCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00029;
          prmBC00029 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0)
          };
          Object[] prmBC00027;
          prmBC00027 = new Object[] {
          new ParDef("@sucursalEmpleadoHeadlineId",GXType.Int16,4,0)
          };
          Object[] prmBC00028;
          prmBC00028 = new Object[] {
          new ParDef("@sucursalEmpleadoAlternateId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000210;
          prmBC000210 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0)
          };
          Object[] prmBC00026;
          prmBC00026 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0)
          };
          Object[] prmBC00025;
          prmBC00025 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0)
          };
          Object[] prmBC000211;
          prmBC000211 = new Object[] {
          new ParDef("@sucursalName",GXType.NVarChar,40,0) ,
          new ParDef("@sucursalAddress",GXType.NVarChar,1024,0) ,
          new ParDef("@sucursalGeolocation",GXType.NChar,50,0) ,
          new ParDef("@sucursalAddedDate",GXType.Date,8,0) ,
          new ParDef("@sucursalEmpleadoHeadlineId",GXType.Int16,4,0) ,
          new ParDef("@sucursalEmpleadoAlternateId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000212;
          prmBC000212 = new Object[] {
          new ParDef("@sucursalName",GXType.NVarChar,40,0) ,
          new ParDef("@sucursalAddress",GXType.NVarChar,1024,0) ,
          new ParDef("@sucursalGeolocation",GXType.NChar,50,0) ,
          new ParDef("@sucursalAddedDate",GXType.Date,8,0) ,
          new ParDef("@sucursalEmpleadoHeadlineId",GXType.Int16,4,0) ,
          new ParDef("@sucursalEmpleadoAlternateId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@sucursalId",GXType.Int16,4,0)
          };
          Object[] prmBC000213;
          prmBC000213 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0)
          };
          Object[] prmBC000214;
          prmBC000214 = new Object[] {
          new ParDef("@sucursalEmpleadoHeadlineId",GXType.Int16,4,0)
          };
          Object[] prmBC000215;
          prmBC000215 = new Object[] {
          new ParDef("@sucursalEmpleadoAlternateId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000216;
          prmBC000216 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0)
          };
          Object[] prmBC000217;
          prmBC000217 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0)
          };
          Object[] prmBC000218;
          prmBC000218 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmBC00024;
          prmBC00024 = new Object[] {
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmBC000219;
          prmBC000219 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmBC00023;
          prmBC00023 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmBC00022;
          prmBC00022 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmBC000220;
          prmBC000220 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0) ,
          new ParDef("@productoStock",GXType.Decimal,10,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmBC000221;
          prmBC000221 = new Object[] {
          new ParDef("@productoStock",GXType.Decimal,10,0) ,
          new ParDef("@sucursalId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmBC000222;
          prmBC000222 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmBC000223;
          prmBC000223 = new Object[] {
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmBC000224;
          prmBC000224 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00022", "SELECT [sucursalId], [productoStock], [productoId] FROM [sucursalproducto] WITH (UPDLOCK) WHERE [sucursalId] = @sucursalId AND [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00023", "SELECT [sucursalId], [productoStock], [productoId] FROM [sucursalproducto] WHERE [sucursalId] = @sucursalId AND [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00024", "SELECT [productoName] FROM [producto] WHERE [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00024,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00025", "SELECT [sucursalId], [sucursalName], [sucursalAddress], [sucursalGeolocation], [sucursalAddedDate], [sucursalEmpleadoHeadlineId] AS sucursalEmpleadoHeadlineId, [sucursalEmpleadoAlternateId] AS sucursalEmpleadoAlternateId FROM [sucursal] WITH (UPDLOCK) WHERE [sucursalId] = @sucursalId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00025,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00026", "SELECT [sucursalId], [sucursalName], [sucursalAddress], [sucursalGeolocation], [sucursalAddedDate], [sucursalEmpleadoHeadlineId] AS sucursalEmpleadoHeadlineId, [sucursalEmpleadoAlternateId] AS sucursalEmpleadoAlternateId FROM [sucursal] WHERE [sucursalId] = @sucursalId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00026,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00027", "SELECT [empleadoName] AS sucursalEmpleadoHeadlineName FROM [empleado] WHERE [empleadoId] = @sucursalEmpleadoHeadlineId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00027,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00028", "SELECT [empleadoName] AS sucursalEmpleadoAlternateName FROM [empleado] WHERE [empleadoId] = @sucursalEmpleadoAlternateId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00028,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00029", "SELECT TM1.[sucursalId], TM1.[sucursalName], TM1.[sucursalAddress], TM1.[sucursalGeolocation], TM1.[sucursalAddedDate], T2.[empleadoName] AS sucursalEmpleadoHeadlineName, T3.[empleadoName] AS sucursalEmpleadoAlternateName, TM1.[sucursalEmpleadoHeadlineId] AS sucursalEmpleadoHeadlineId, TM1.[sucursalEmpleadoAlternateId] AS sucursalEmpleadoAlternateId FROM (([sucursal] TM1 INNER JOIN [empleado] T2 ON T2.[empleadoId] = TM1.[sucursalEmpleadoHeadlineId]) LEFT JOIN [empleado] T3 ON T3.[empleadoId] = TM1.[sucursalEmpleadoAlternateId]) WHERE TM1.[sucursalId] = @sucursalId ORDER BY TM1.[sucursalId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00029,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000210", "SELECT [sucursalId] FROM [sucursal] WHERE [sucursalId] = @sucursalId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000210,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000211", "INSERT INTO [sucursal]([sucursalName], [sucursalAddress], [sucursalGeolocation], [sucursalAddedDate], [sucursalEmpleadoHeadlineId], [sucursalEmpleadoAlternateId]) VALUES(@sucursalName, @sucursalAddress, @sucursalGeolocation, @sucursalAddedDate, @sucursalEmpleadoHeadlineId, @sucursalEmpleadoAlternateId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000211,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000212", "UPDATE [sucursal] SET [sucursalName]=@sucursalName, [sucursalAddress]=@sucursalAddress, [sucursalGeolocation]=@sucursalGeolocation, [sucursalAddedDate]=@sucursalAddedDate, [sucursalEmpleadoHeadlineId]=@sucursalEmpleadoHeadlineId, [sucursalEmpleadoAlternateId]=@sucursalEmpleadoAlternateId  WHERE [sucursalId] = @sucursalId", GxErrorMask.GX_NOMASK,prmBC000212)
             ,new CursorDef("BC000213", "DELETE FROM [sucursal]  WHERE [sucursalId] = @sucursalId", GxErrorMask.GX_NOMASK,prmBC000213)
             ,new CursorDef("BC000214", "SELECT [empleadoName] AS sucursalEmpleadoHeadlineName FROM [empleado] WHERE [empleadoId] = @sucursalEmpleadoHeadlineId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000214,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000215", "SELECT [empleadoName] AS sucursalEmpleadoAlternateName FROM [empleado] WHERE [empleadoId] = @sucursalEmpleadoAlternateId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000215,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000216", "SELECT TOP 1 [facturaId] FROM [factura] WHERE [sucursalId] = @sucursalId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000216,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000217", "SELECT TM1.[sucursalId], TM1.[sucursalName], TM1.[sucursalAddress], TM1.[sucursalGeolocation], TM1.[sucursalAddedDate], T2.[empleadoName] AS sucursalEmpleadoHeadlineName, T3.[empleadoName] AS sucursalEmpleadoAlternateName, TM1.[sucursalEmpleadoHeadlineId] AS sucursalEmpleadoHeadlineId, TM1.[sucursalEmpleadoAlternateId] AS sucursalEmpleadoAlternateId FROM (([sucursal] TM1 INNER JOIN [empleado] T2 ON T2.[empleadoId] = TM1.[sucursalEmpleadoHeadlineId]) LEFT JOIN [empleado] T3 ON T3.[empleadoId] = TM1.[sucursalEmpleadoAlternateId]) WHERE TM1.[sucursalId] = @sucursalId ORDER BY TM1.[sucursalId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000217,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000218", "SELECT T1.[sucursalId], T2.[productoName], T1.[productoStock], T1.[productoId] FROM ([sucursalproducto] T1 INNER JOIN [producto] T2 ON T2.[productoId] = T1.[productoId]) WHERE T1.[sucursalId] = @sucursalId and T1.[productoId] = @productoId ORDER BY T1.[sucursalId], T1.[productoId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000218,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000219", "SELECT [sucursalId], [productoId] FROM [sucursalproducto] WHERE [sucursalId] = @sucursalId AND [productoId] = @productoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000219,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000220", "INSERT INTO [sucursalproducto]([sucursalId], [productoStock], [productoId]) VALUES(@sucursalId, @productoStock, @productoId)", GxErrorMask.GX_NOMASK,prmBC000220)
             ,new CursorDef("BC000221", "UPDATE [sucursalproducto] SET [productoStock]=@productoStock  WHERE [sucursalId] = @sucursalId AND [productoId] = @productoId", GxErrorMask.GX_NOMASK,prmBC000221)
             ,new CursorDef("BC000222", "DELETE FROM [sucursalproducto]  WHERE [sucursalId] = @sucursalId AND [productoId] = @productoId", GxErrorMask.GX_NOMASK,prmBC000222)
             ,new CursorDef("BC000223", "SELECT [productoName] FROM [producto] WHERE [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000223,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000224", "SELECT T1.[sucursalId], T2.[productoName], T1.[productoStock], T1.[productoId] FROM ([sucursalproducto] T1 INNER JOIN [producto] T2 ON T2.[productoId] = T1.[productoId]) WHERE T1.[sucursalId] = @sucursalId ORDER BY T1.[sucursalId], T1.[productoId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000224,11, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 22 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
       }
    }

 }

}
