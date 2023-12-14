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
   public class producto_bc : GxSilentTrn, IGxSilentTrn
   {
      public producto_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("xd2", true);
      }

      public producto_bc( IGxContext context )
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
         ReadRow034( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey034( ) ;
         standaloneModal( ) ;
         AddRow034( ) ;
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
            E11032 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z5productoId = A5productoId;
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

      protected void CONFIRM_030( )
      {
         BeforeValidate034( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls034( ) ;
            }
            else
            {
               CheckExtendedTable034( ) ;
               if ( AnyError == 0 )
               {
                  ZM034( 2) ;
                  ZM034( 3) ;
               }
               CloseExtendedTableCursors034( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12032( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11032( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM034( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z25productoName = A25productoName;
            Z27productoSellPrice = A27productoSellPrice;
            Z28productoCostPrice = A28productoCostPrice;
            Z7proveedorId = A7proveedorId;
            Z6tipoDeProductoId = A6tipoDeProductoId;
         }
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z21proveedorName = A21proveedorName;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z29tipoDeProductoName = A29tipoDeProductoName;
         }
         if ( GX_JID == -1 )
         {
            Z5productoId = A5productoId;
            Z25productoName = A25productoName;
            Z26productoImage = A26productoImage;
            Z40000productoImage_GXI = A40000productoImage_GXI;
            Z27productoSellPrice = A27productoSellPrice;
            Z28productoCostPrice = A28productoCostPrice;
            Z7proveedorId = A7proveedorId;
            Z6tipoDeProductoId = A6tipoDeProductoId;
            Z21proveedorName = A21proveedorName;
            Z29tipoDeProductoName = A29tipoDeProductoName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load034( )
      {
         /* Using cursor BC00036 */
         pr_default.execute(4, new Object[] {A5productoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound4 = 1;
            A25productoName = BC00036_A25productoName[0];
            A40000productoImage_GXI = BC00036_A40000productoImage_GXI[0];
            A27productoSellPrice = BC00036_A27productoSellPrice[0];
            A28productoCostPrice = BC00036_A28productoCostPrice[0];
            A21proveedorName = BC00036_A21proveedorName[0];
            A29tipoDeProductoName = BC00036_A29tipoDeProductoName[0];
            A7proveedorId = BC00036_A7proveedorId[0];
            A6tipoDeProductoId = BC00036_A6tipoDeProductoId[0];
            A26productoImage = BC00036_A26productoImage[0];
            ZM034( -1) ;
         }
         pr_default.close(4);
         OnLoadActions034( ) ;
      }

      protected void OnLoadActions034( )
      {
      }

      protected void CheckExtendedTable034( )
      {
         nIsDirty_4 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00034 */
         pr_default.execute(2, new Object[] {A7proveedorId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'proveedor'.", "ForeignKeyNotFound", 1, "PROVEEDORID");
            AnyError = 1;
         }
         A21proveedorName = BC00034_A21proveedorName[0];
         pr_default.close(2);
         /* Using cursor BC00035 */
         pr_default.execute(3, new Object[] {A6tipoDeProductoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'tipo De Producto'.", "ForeignKeyNotFound", 1, "TIPODEPRODUCTOID");
            AnyError = 1;
         }
         A29tipoDeProductoName = BC00035_A29tipoDeProductoName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors034( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey034( )
      {
         /* Using cursor BC00037 */
         pr_default.execute(5, new Object[] {A5productoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00033 */
         pr_default.execute(1, new Object[] {A5productoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM034( 1) ;
            RcdFound4 = 1;
            A5productoId = BC00033_A5productoId[0];
            A25productoName = BC00033_A25productoName[0];
            A40000productoImage_GXI = BC00033_A40000productoImage_GXI[0];
            A27productoSellPrice = BC00033_A27productoSellPrice[0];
            A28productoCostPrice = BC00033_A28productoCostPrice[0];
            A7proveedorId = BC00033_A7proveedorId[0];
            A6tipoDeProductoId = BC00033_A6tipoDeProductoId[0];
            A26productoImage = BC00033_A26productoImage[0];
            Z5productoId = A5productoId;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load034( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey034( ) ;
            }
            Gx_mode = sMode4;
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey034( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode4;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey034( ) ;
         if ( RcdFound4 == 0 )
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
         CONFIRM_030( ) ;
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

      protected void CheckOptimisticConcurrency034( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00032 */
            pr_default.execute(0, new Object[] {A5productoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"producto"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z25productoName, BC00032_A25productoName[0]) != 0 ) || ( Z27productoSellPrice != BC00032_A27productoSellPrice[0] ) || ( Z28productoCostPrice != BC00032_A28productoCostPrice[0] ) || ( Z7proveedorId != BC00032_A7proveedorId[0] ) || ( Z6tipoDeProductoId != BC00032_A6tipoDeProductoId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"producto"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert034( )
      {
         BeforeValidate034( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable034( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM034( 0) ;
            CheckOptimisticConcurrency034( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm034( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert034( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00038 */
                     pr_default.execute(6, new Object[] {A25productoName, A26productoImage, A40000productoImage_GXI, A27productoSellPrice, A28productoCostPrice, A7proveedorId, A6tipoDeProductoId});
                     A5productoId = BC00038_A5productoId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("producto");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
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
               Load034( ) ;
            }
            EndLevel034( ) ;
         }
         CloseExtendedTableCursors034( ) ;
      }

      protected void Update034( )
      {
         BeforeValidate034( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable034( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency034( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm034( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate034( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00039 */
                     pr_default.execute(7, new Object[] {A25productoName, A27productoSellPrice, A28productoCostPrice, A7proveedorId, A6tipoDeProductoId, A5productoId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("producto");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"producto"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate034( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
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
            EndLevel034( ) ;
         }
         CloseExtendedTableCursors034( ) ;
      }

      protected void DeferredUpdate034( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000310 */
            pr_default.execute(8, new Object[] {A26productoImage, A40000productoImage_GXI, A5productoId});
            pr_default.close(8);
            pr_default.SmartCacheProvider.SetUpdated("producto");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate034( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency034( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls034( ) ;
            AfterConfirm034( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete034( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000311 */
                  pr_default.execute(9, new Object[] {A5productoId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("producto");
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
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel034( ) ;
         Gx_mode = sMode4;
      }

      protected void OnDeleteControls034( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000312 */
            pr_default.execute(10, new Object[] {A7proveedorId});
            A21proveedorName = BC000312_A21proveedorName[0];
            pr_default.close(10);
            /* Using cursor BC000313 */
            pr_default.execute(11, new Object[] {A6tipoDeProductoId});
            A29tipoDeProductoName = BC000313_A29tipoDeProductoName[0];
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000314 */
            pr_default.execute(12, new Object[] {A5productoId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"producto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC000315 */
            pr_default.execute(13, new Object[] {A5productoId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"producto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel034( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete034( ) ;
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

      public void ScanKeyStart034( )
      {
         /* Scan By routine */
         /* Using cursor BC000316 */
         pr_default.execute(14, new Object[] {A5productoId});
         RcdFound4 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound4 = 1;
            A5productoId = BC000316_A5productoId[0];
            A25productoName = BC000316_A25productoName[0];
            A40000productoImage_GXI = BC000316_A40000productoImage_GXI[0];
            A27productoSellPrice = BC000316_A27productoSellPrice[0];
            A28productoCostPrice = BC000316_A28productoCostPrice[0];
            A21proveedorName = BC000316_A21proveedorName[0];
            A29tipoDeProductoName = BC000316_A29tipoDeProductoName[0];
            A7proveedorId = BC000316_A7proveedorId[0];
            A6tipoDeProductoId = BC000316_A6tipoDeProductoId[0];
            A26productoImage = BC000316_A26productoImage[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext034( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound4 = 0;
         ScanKeyLoad034( ) ;
      }

      protected void ScanKeyLoad034( )
      {
         sMode4 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound4 = 1;
            A5productoId = BC000316_A5productoId[0];
            A25productoName = BC000316_A25productoName[0];
            A40000productoImage_GXI = BC000316_A40000productoImage_GXI[0];
            A27productoSellPrice = BC000316_A27productoSellPrice[0];
            A28productoCostPrice = BC000316_A28productoCostPrice[0];
            A21proveedorName = BC000316_A21proveedorName[0];
            A29tipoDeProductoName = BC000316_A29tipoDeProductoName[0];
            A7proveedorId = BC000316_A7proveedorId[0];
            A6tipoDeProductoId = BC000316_A6tipoDeProductoId[0];
            A26productoImage = BC000316_A26productoImage[0];
         }
         Gx_mode = sMode4;
      }

      protected void ScanKeyEnd034( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm034( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert034( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate034( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete034( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete034( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate034( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes034( )
      {
      }

      protected void send_integrity_lvl_hashes034( )
      {
      }

      protected void AddRow034( )
      {
         VarsToRow4( bcproducto) ;
      }

      protected void ReadRow034( )
      {
         RowToVars4( bcproducto, 1) ;
      }

      protected void InitializeNonKey034( )
      {
         A25productoName = "";
         A26productoImage = "";
         A40000productoImage_GXI = "";
         A27productoSellPrice = 0;
         A28productoCostPrice = 0;
         A7proveedorId = 0;
         A21proveedorName = "";
         A6tipoDeProductoId = 0;
         A29tipoDeProductoName = "";
         Z25productoName = "";
         Z27productoSellPrice = 0;
         Z28productoCostPrice = 0;
         Z7proveedorId = 0;
         Z6tipoDeProductoId = 0;
      }

      protected void InitAll034( )
      {
         A5productoId = 0;
         InitializeNonKey034( ) ;
      }

      protected void StandaloneModalInsert( )
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

      public void VarsToRow4( Sdtproducto obj4 )
      {
         obj4.gxTpr_Mode = Gx_mode;
         obj4.gxTpr_Productoname = A25productoName;
         obj4.gxTpr_Productoimage = A26productoImage;
         obj4.gxTpr_Productoimage_gxi = A40000productoImage_GXI;
         obj4.gxTpr_Productosellprice = A27productoSellPrice;
         obj4.gxTpr_Productocostprice = A28productoCostPrice;
         obj4.gxTpr_Proveedorid = A7proveedorId;
         obj4.gxTpr_Proveedorname = A21proveedorName;
         obj4.gxTpr_Tipodeproductoid = A6tipoDeProductoId;
         obj4.gxTpr_Tipodeproductoname = A29tipoDeProductoName;
         obj4.gxTpr_Productoid = A5productoId;
         obj4.gxTpr_Productoid_Z = Z5productoId;
         obj4.gxTpr_Productoname_Z = Z25productoName;
         obj4.gxTpr_Productosellprice_Z = Z27productoSellPrice;
         obj4.gxTpr_Productocostprice_Z = Z28productoCostPrice;
         obj4.gxTpr_Proveedorid_Z = Z7proveedorId;
         obj4.gxTpr_Proveedorname_Z = Z21proveedorName;
         obj4.gxTpr_Tipodeproductoid_Z = Z6tipoDeProductoId;
         obj4.gxTpr_Tipodeproductoname_Z = Z29tipoDeProductoName;
         obj4.gxTpr_Productoimage_gxi_Z = Z40000productoImage_GXI;
         obj4.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow4( Sdtproducto obj4 )
      {
         obj4.gxTpr_Productoid = A5productoId;
         return  ;
      }

      public void RowToVars4( Sdtproducto obj4 ,
                              int forceLoad )
      {
         Gx_mode = obj4.gxTpr_Mode;
         A25productoName = obj4.gxTpr_Productoname;
         A26productoImage = obj4.gxTpr_Productoimage;
         A40000productoImage_GXI = obj4.gxTpr_Productoimage_gxi;
         A27productoSellPrice = obj4.gxTpr_Productosellprice;
         A28productoCostPrice = obj4.gxTpr_Productocostprice;
         A7proveedorId = obj4.gxTpr_Proveedorid;
         A21proveedorName = obj4.gxTpr_Proveedorname;
         A6tipoDeProductoId = obj4.gxTpr_Tipodeproductoid;
         A29tipoDeProductoName = obj4.gxTpr_Tipodeproductoname;
         if ( forceLoad == 1 )
         {
            A5productoId = obj4.gxTpr_Productoid;
         }
         Z5productoId = obj4.gxTpr_Productoid_Z;
         Z25productoName = obj4.gxTpr_Productoname_Z;
         Z27productoSellPrice = obj4.gxTpr_Productosellprice_Z;
         Z28productoCostPrice = obj4.gxTpr_Productocostprice_Z;
         Z7proveedorId = obj4.gxTpr_Proveedorid_Z;
         Z21proveedorName = obj4.gxTpr_Proveedorname_Z;
         Z6tipoDeProductoId = obj4.gxTpr_Tipodeproductoid_Z;
         Z29tipoDeProductoName = obj4.gxTpr_Tipodeproductoname_Z;
         Z40000productoImage_GXI = obj4.gxTpr_Productoimage_gxi_Z;
         Gx_mode = obj4.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A5productoId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey034( ) ;
         ScanKeyStart034( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z5productoId = A5productoId;
         }
         ZM034( -1) ;
         OnLoadActions034( ) ;
         AddRow034( ) ;
         ScanKeyEnd034( ) ;
         if ( RcdFound4 == 0 )
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
         RowToVars4( bcproducto, 0) ;
         ScanKeyStart034( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z5productoId = A5productoId;
         }
         ZM034( -1) ;
         OnLoadActions034( ) ;
         AddRow034( ) ;
         ScanKeyEnd034( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey034( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert034( ) ;
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( A5productoId != Z5productoId )
               {
                  A5productoId = Z5productoId;
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
                  Update034( ) ;
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
                  if ( A5productoId != Z5productoId )
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
                        Insert034( ) ;
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
                        Insert034( ) ;
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
         RowToVars4( bcproducto, 1) ;
         SaveImpl( ) ;
         VarsToRow4( bcproducto) ;
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
         RowToVars4( bcproducto, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert034( ) ;
         AfterTrn( ) ;
         VarsToRow4( bcproducto) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow4( bcproducto) ;
         }
         else
         {
            Sdtproducto auxBC = new Sdtproducto(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A5productoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcproducto);
               auxBC.Save();
               bcproducto.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars4( bcproducto, 1) ;
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
         RowToVars4( bcproducto, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert034( ) ;
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
               VarsToRow4( bcproducto) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow4( bcproducto) ;
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
         RowToVars4( bcproducto, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey034( ) ;
         if ( RcdFound4 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A5productoId != Z5productoId )
            {
               A5productoId = Z5productoId;
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
            if ( A5productoId != Z5productoId )
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
         pr_default.close(1);
         pr_default.close(10);
         pr_default.close(11);
         context.RollbackDataStores("producto_bc",pr_default);
         VarsToRow4( bcproducto) ;
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
         Gx_mode = bcproducto.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcproducto.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcproducto )
         {
            bcproducto = (Sdtproducto)(sdt);
            if ( StringUtil.StrCmp(bcproducto.gxTpr_Mode, "") == 0 )
            {
               bcproducto.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow4( bcproducto) ;
            }
            else
            {
               RowToVars4( bcproducto, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcproducto.gxTpr_Mode, "") == 0 )
            {
               bcproducto.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars4( bcproducto, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public Sdtproducto producto_BC
      {
         get {
            return bcproducto ;
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
         pr_default.close(10);
         pr_default.close(11);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z25productoName = "";
         A25productoName = "";
         Z21proveedorName = "";
         A21proveedorName = "";
         Z29tipoDeProductoName = "";
         A29tipoDeProductoName = "";
         Z26productoImage = "";
         A26productoImage = "";
         Z40000productoImage_GXI = "";
         A40000productoImage_GXI = "";
         BC00036_A5productoId = new short[1] ;
         BC00036_A25productoName = new string[] {""} ;
         BC00036_A40000productoImage_GXI = new string[] {""} ;
         BC00036_A27productoSellPrice = new decimal[1] ;
         BC00036_A28productoCostPrice = new decimal[1] ;
         BC00036_A21proveedorName = new string[] {""} ;
         BC00036_A29tipoDeProductoName = new string[] {""} ;
         BC00036_A7proveedorId = new short[1] ;
         BC00036_A6tipoDeProductoId = new short[1] ;
         BC00036_A26productoImage = new string[] {""} ;
         BC00034_A21proveedorName = new string[] {""} ;
         BC00035_A29tipoDeProductoName = new string[] {""} ;
         BC00037_A5productoId = new short[1] ;
         BC00033_A5productoId = new short[1] ;
         BC00033_A25productoName = new string[] {""} ;
         BC00033_A40000productoImage_GXI = new string[] {""} ;
         BC00033_A27productoSellPrice = new decimal[1] ;
         BC00033_A28productoCostPrice = new decimal[1] ;
         BC00033_A7proveedorId = new short[1] ;
         BC00033_A6tipoDeProductoId = new short[1] ;
         BC00033_A26productoImage = new string[] {""} ;
         sMode4 = "";
         BC00032_A5productoId = new short[1] ;
         BC00032_A25productoName = new string[] {""} ;
         BC00032_A40000productoImage_GXI = new string[] {""} ;
         BC00032_A27productoSellPrice = new decimal[1] ;
         BC00032_A28productoCostPrice = new decimal[1] ;
         BC00032_A7proveedorId = new short[1] ;
         BC00032_A6tipoDeProductoId = new short[1] ;
         BC00032_A26productoImage = new string[] {""} ;
         BC00038_A5productoId = new short[1] ;
         BC000312_A21proveedorName = new string[] {""} ;
         BC000313_A29tipoDeProductoName = new string[] {""} ;
         BC000314_A8facturaId = new short[1] ;
         BC000314_A5productoId = new short[1] ;
         BC000315_A2sucursalId = new short[1] ;
         BC000315_A5productoId = new short[1] ;
         BC000316_A5productoId = new short[1] ;
         BC000316_A25productoName = new string[] {""} ;
         BC000316_A40000productoImage_GXI = new string[] {""} ;
         BC000316_A27productoSellPrice = new decimal[1] ;
         BC000316_A28productoCostPrice = new decimal[1] ;
         BC000316_A21proveedorName = new string[] {""} ;
         BC000316_A29tipoDeProductoName = new string[] {""} ;
         BC000316_A7proveedorId = new short[1] ;
         BC000316_A6tipoDeProductoId = new short[1] ;
         BC000316_A26productoImage = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.producto_bc__default(),
            new Object[][] {
                new Object[] {
               BC00032_A5productoId, BC00032_A25productoName, BC00032_A40000productoImage_GXI, BC00032_A27productoSellPrice, BC00032_A28productoCostPrice, BC00032_A7proveedorId, BC00032_A6tipoDeProductoId, BC00032_A26productoImage
               }
               , new Object[] {
               BC00033_A5productoId, BC00033_A25productoName, BC00033_A40000productoImage_GXI, BC00033_A27productoSellPrice, BC00033_A28productoCostPrice, BC00033_A7proveedorId, BC00033_A6tipoDeProductoId, BC00033_A26productoImage
               }
               , new Object[] {
               BC00034_A21proveedorName
               }
               , new Object[] {
               BC00035_A29tipoDeProductoName
               }
               , new Object[] {
               BC00036_A5productoId, BC00036_A25productoName, BC00036_A40000productoImage_GXI, BC00036_A27productoSellPrice, BC00036_A28productoCostPrice, BC00036_A21proveedorName, BC00036_A29tipoDeProductoName, BC00036_A7proveedorId, BC00036_A6tipoDeProductoId, BC00036_A26productoImage
               }
               , new Object[] {
               BC00037_A5productoId
               }
               , new Object[] {
               BC00038_A5productoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000312_A21proveedorName
               }
               , new Object[] {
               BC000313_A29tipoDeProductoName
               }
               , new Object[] {
               BC000314_A8facturaId, BC000314_A5productoId
               }
               , new Object[] {
               BC000315_A2sucursalId, BC000315_A5productoId
               }
               , new Object[] {
               BC000316_A5productoId, BC000316_A25productoName, BC000316_A40000productoImage_GXI, BC000316_A27productoSellPrice, BC000316_A28productoCostPrice, BC000316_A21proveedorName, BC000316_A29tipoDeProductoName, BC000316_A7proveedorId, BC000316_A6tipoDeProductoId, BC000316_A26productoImage
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12032 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z5productoId ;
      private short A5productoId ;
      private short GX_JID ;
      private short Z7proveedorId ;
      private short A7proveedorId ;
      private short Z6tipoDeProductoId ;
      private short A6tipoDeProductoId ;
      private short RcdFound4 ;
      private short nIsDirty_4 ;
      private int trnEnded ;
      private decimal Z27productoSellPrice ;
      private decimal A27productoSellPrice ;
      private decimal Z28productoCostPrice ;
      private decimal A28productoCostPrice ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode4 ;
      private bool returnInSub ;
      private bool mustCommit ;
      private string Z25productoName ;
      private string A25productoName ;
      private string Z21proveedorName ;
      private string A21proveedorName ;
      private string Z29tipoDeProductoName ;
      private string A29tipoDeProductoName ;
      private string Z40000productoImage_GXI ;
      private string A40000productoImage_GXI ;
      private string Z26productoImage ;
      private string A26productoImage ;
      private Sdtproducto bcproducto ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00036_A5productoId ;
      private string[] BC00036_A25productoName ;
      private string[] BC00036_A40000productoImage_GXI ;
      private decimal[] BC00036_A27productoSellPrice ;
      private decimal[] BC00036_A28productoCostPrice ;
      private string[] BC00036_A21proveedorName ;
      private string[] BC00036_A29tipoDeProductoName ;
      private short[] BC00036_A7proveedorId ;
      private short[] BC00036_A6tipoDeProductoId ;
      private string[] BC00036_A26productoImage ;
      private string[] BC00034_A21proveedorName ;
      private string[] BC00035_A29tipoDeProductoName ;
      private short[] BC00037_A5productoId ;
      private short[] BC00033_A5productoId ;
      private string[] BC00033_A25productoName ;
      private string[] BC00033_A40000productoImage_GXI ;
      private decimal[] BC00033_A27productoSellPrice ;
      private decimal[] BC00033_A28productoCostPrice ;
      private short[] BC00033_A7proveedorId ;
      private short[] BC00033_A6tipoDeProductoId ;
      private string[] BC00033_A26productoImage ;
      private short[] BC00032_A5productoId ;
      private string[] BC00032_A25productoName ;
      private string[] BC00032_A40000productoImage_GXI ;
      private decimal[] BC00032_A27productoSellPrice ;
      private decimal[] BC00032_A28productoCostPrice ;
      private short[] BC00032_A7proveedorId ;
      private short[] BC00032_A6tipoDeProductoId ;
      private string[] BC00032_A26productoImage ;
      private short[] BC00038_A5productoId ;
      private string[] BC000312_A21proveedorName ;
      private string[] BC000313_A29tipoDeProductoName ;
      private short[] BC000314_A8facturaId ;
      private short[] BC000314_A5productoId ;
      private short[] BC000315_A2sucursalId ;
      private short[] BC000315_A5productoId ;
      private short[] BC000316_A5productoId ;
      private string[] BC000316_A25productoName ;
      private string[] BC000316_A40000productoImage_GXI ;
      private decimal[] BC000316_A27productoSellPrice ;
      private decimal[] BC000316_A28productoCostPrice ;
      private string[] BC000316_A21proveedorName ;
      private string[] BC000316_A29tipoDeProductoName ;
      private short[] BC000316_A7proveedorId ;
      private short[] BC000316_A6tipoDeProductoId ;
      private string[] BC000316_A26productoImage ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class producto_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00036;
          prmBC00036 = new Object[] {
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmBC00034;
          prmBC00034 = new Object[] {
          new ParDef("@proveedorId",GXType.Int16,4,0)
          };
          Object[] prmBC00035;
          prmBC00035 = new Object[] {
          new ParDef("@tipoDeProductoId",GXType.Int16,4,0)
          };
          Object[] prmBC00037;
          prmBC00037 = new Object[] {
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmBC00033;
          prmBC00033 = new Object[] {
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmBC00032;
          prmBC00032 = new Object[] {
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmBC00038;
          prmBC00038 = new Object[] {
          new ParDef("@productoName",GXType.NVarChar,40,0) ,
          new ParDef("@productoImage",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@productoImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="producto", Fld="productoImage"} ,
          new ParDef("@productoSellPrice",GXType.Decimal,10,2) ,
          new ParDef("@productoCostPrice",GXType.Decimal,10,2) ,
          new ParDef("@proveedorId",GXType.Int16,4,0) ,
          new ParDef("@tipoDeProductoId",GXType.Int16,4,0)
          };
          Object[] prmBC00039;
          prmBC00039 = new Object[] {
          new ParDef("@productoName",GXType.NVarChar,40,0) ,
          new ParDef("@productoSellPrice",GXType.Decimal,10,2) ,
          new ParDef("@productoCostPrice",GXType.Decimal,10,2) ,
          new ParDef("@proveedorId",GXType.Int16,4,0) ,
          new ParDef("@tipoDeProductoId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmBC000310;
          prmBC000310 = new Object[] {
          new ParDef("@productoImage",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@productoImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="producto", Fld="productoImage"} ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmBC000311;
          prmBC000311 = new Object[] {
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmBC000312;
          prmBC000312 = new Object[] {
          new ParDef("@proveedorId",GXType.Int16,4,0)
          };
          Object[] prmBC000313;
          prmBC000313 = new Object[] {
          new ParDef("@tipoDeProductoId",GXType.Int16,4,0)
          };
          Object[] prmBC000314;
          prmBC000314 = new Object[] {
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmBC000315;
          prmBC000315 = new Object[] {
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmBC000316;
          prmBC000316 = new Object[] {
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00032", "SELECT [productoId], [productoName], [productoImage_GXI], [productoSellPrice], [productoCostPrice], [proveedorId], [tipoDeProductoId], [productoImage] FROM [producto] WITH (UPDLOCK) WHERE [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00032,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00033", "SELECT [productoId], [productoName], [productoImage_GXI], [productoSellPrice], [productoCostPrice], [proveedorId], [tipoDeProductoId], [productoImage] FROM [producto] WHERE [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00033,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00034", "SELECT [proveedorName] FROM [proveedor] WHERE [proveedorId] = @proveedorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00034,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00035", "SELECT [tipoDeProductoName] FROM [tipoDeProducto] WHERE [tipoDeProductoId] = @tipoDeProductoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00035,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00036", "SELECT TM1.[productoId], TM1.[productoName], TM1.[productoImage_GXI], TM1.[productoSellPrice], TM1.[productoCostPrice], T2.[proveedorName], T3.[tipoDeProductoName], TM1.[proveedorId], TM1.[tipoDeProductoId], TM1.[productoImage] FROM (([producto] TM1 INNER JOIN [proveedor] T2 ON T2.[proveedorId] = TM1.[proveedorId]) INNER JOIN [tipoDeProducto] T3 ON T3.[tipoDeProductoId] = TM1.[tipoDeProductoId]) WHERE TM1.[productoId] = @productoId ORDER BY TM1.[productoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00036,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00037", "SELECT [productoId] FROM [producto] WHERE [productoId] = @productoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00037,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00038", "INSERT INTO [producto]([productoName], [productoImage], [productoImage_GXI], [productoSellPrice], [productoCostPrice], [proveedorId], [tipoDeProductoId]) VALUES(@productoName, @productoImage, @productoImage_GXI, @productoSellPrice, @productoCostPrice, @proveedorId, @tipoDeProductoId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00038,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC00039", "UPDATE [producto] SET [productoName]=@productoName, [productoSellPrice]=@productoSellPrice, [productoCostPrice]=@productoCostPrice, [proveedorId]=@proveedorId, [tipoDeProductoId]=@tipoDeProductoId  WHERE [productoId] = @productoId", GxErrorMask.GX_NOMASK,prmBC00039)
             ,new CursorDef("BC000310", "UPDATE [producto] SET [productoImage]=@productoImage, [productoImage_GXI]=@productoImage_GXI  WHERE [productoId] = @productoId", GxErrorMask.GX_NOMASK,prmBC000310)
             ,new CursorDef("BC000311", "DELETE FROM [producto]  WHERE [productoId] = @productoId", GxErrorMask.GX_NOMASK,prmBC000311)
             ,new CursorDef("BC000312", "SELECT [proveedorName] FROM [proveedor] WHERE [proveedorId] = @proveedorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000312,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000313", "SELECT [tipoDeProductoName] FROM [tipoDeProducto] WHERE [tipoDeProductoId] = @tipoDeProductoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000313,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000314", "SELECT TOP 1 [facturaId], [productoId] FROM [facturaproducto] WHERE [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000314,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000315", "SELECT TOP 1 [sucursalId], [productoId] FROM [sucursalproducto] WHERE [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000315,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000316", "SELECT TM1.[productoId], TM1.[productoName], TM1.[productoImage_GXI], TM1.[productoSellPrice], TM1.[productoCostPrice], T2.[proveedorName], T3.[tipoDeProductoName], TM1.[proveedorId], TM1.[tipoDeProductoId], TM1.[productoImage] FROM (([producto] TM1 INNER JOIN [proveedor] T2 ON T2.[proveedorId] = TM1.[proveedorId]) INNER JOIN [tipoDeProducto] T3 ON T3.[tipoDeProductoId] = TM1.[tipoDeProductoId]) WHERE TM1.[productoId] = @productoId ORDER BY TM1.[productoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000316,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(3));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(3));
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((string[]) buf[9])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(3));
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((string[]) buf[9])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(3));
                return;
       }
    }

 }

}
