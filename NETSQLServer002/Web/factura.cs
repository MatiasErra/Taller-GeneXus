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
   public class factura : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
         {
            A8facturaId = (short)(Math.Round(NumberUtil.Val( GetPar( "facturaId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A8facturaId", StringUtil.LTrimStr( (decimal)(A8facturaId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_18( A8facturaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A2sucursalId = (short)(Math.Round(NumberUtil.Val( GetPar( "sucursalId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A2sucursalId", StringUtil.LTrimStr( (decimal)(A2sucursalId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A2sucursalId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A5productoId = (short)(Math.Round(NumberUtil.Val( GetPar( "productoId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A5productoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A2sucursalId = (short)(Math.Round(NumberUtil.Val( GetPar( "sucursalId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A2sucursalId", StringUtil.LTrimStr( (decimal)(A2sucursalId), 4, 0));
            A5productoId = (short)(Math.Round(NumberUtil.Val( GetPar( "productoId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A2sucursalId, A5productoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridfactura_producto") == 0 )
         {
            gxnrGridfactura_producto_newrow_invoke( ) ;
            return  ;
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7facturaId = (short)(Math.Round(NumberUtil.Val( GetPar( "facturaId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7facturaId", StringUtil.LTrimStr( (decimal)(AV7facturaId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vFACTURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7facturaId), "ZZZ9"), context));
            }
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_1-167910", 0) ;
            }
            Form.Meta.addItem("description", "factura", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtfacturaDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("xd2", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridfactura_producto_newrow_invoke( )
      {
         nRC_GXsfl_63 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_63"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_63_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_63_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_63_idx = GetPar( "sGXsfl_63_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridfactura_producto_newrow( ) ;
         /* End function gxnrGridfactura_producto_newrow_invoke */
      }

      public factura( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("xd2", true);
      }

      public factura( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_facturaId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7facturaId = aP1_facturaId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbfacturaTipoPago = new GXCombobox();
         dynsucursalId = new GXCombobox();
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterunanimosidebar", "GeneXus.Programs.general.ui.masterunanimosidebar", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbfacturaTipoPago.ItemCount > 0 )
         {
            A33facturaTipoPago = cmbfacturaTipoPago.getValidValue(A33facturaTipoPago);
            AssignAttri("", false, "A33facturaTipoPago", A33facturaTipoPago);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbfacturaTipoPago.CurrentValue = StringUtil.RTrim( A33facturaTipoPago);
            AssignProp("", false, cmbfacturaTipoPago_Internalname, "Values", cmbfacturaTipoPago.ToJavascriptSource(), true);
         }
         if ( dynsucursalId.ItemCount > 0 )
         {
            A2sucursalId = (short)(Math.Round(NumberUtil.Val( dynsucursalId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2sucursalId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A2sucursalId", StringUtil.LTrimStr( (decimal)(A2sucursalId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynsucursalId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2sucursalId), 4, 0));
            AssignProp("", false, dynsucursalId_Internalname, "Values", dynsucursalId.ToJavascriptSource(), true);
         }
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Factura", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_factura.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_factura.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_factura.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_factura.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_factura.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_factura.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtfacturaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtfacturaId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtfacturaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A8facturaId), 4, 0, ",", "")), StringUtil.LTrim( ((edtfacturaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A8facturaId), "ZZZ9") : context.localUtil.Format( (decimal)(A8facturaId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtfacturaId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtfacturaId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_factura.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtfacturaDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtfacturaDate_Internalname, "Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtfacturaDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtfacturaDate_Internalname, context.localUtil.Format(A31facturaDate, "99/99/99"), context.localUtil.Format( A31facturaDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtfacturaDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtfacturaDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_factura.htm");
         GxWebStd.gx_bitmap( context, edtfacturaDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtfacturaDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_factura.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtfacturaClientName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtfacturaClientName_Internalname, "Client Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtfacturaClientName_Internalname, A32facturaClientName, StringUtil.RTrim( context.localUtil.Format( A32facturaClientName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtfacturaClientName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtfacturaClientName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_factura.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbfacturaTipoPago_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbfacturaTipoPago_Internalname, "Tipo Pago", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbfacturaTipoPago, cmbfacturaTipoPago_Internalname, StringUtil.RTrim( A33facturaTipoPago), 1, cmbfacturaTipoPago_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbfacturaTipoPago.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_factura.htm");
         cmbfacturaTipoPago.CurrentValue = StringUtil.RTrim( A33facturaTipoPago);
         AssignProp("", false, cmbfacturaTipoPago_Internalname, "Values", (string)(cmbfacturaTipoPago.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynsucursalId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynsucursalId_Internalname, "sucursal Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynsucursalId, dynsucursalId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A2sucursalId), 4, 0)), 1, dynsucursalId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynsucursalId.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, 0, "HLP_factura.htm");
         dynsucursalId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2sucursalId), 4, 0));
         AssignProp("", false, dynsucursalId_Internalname, "Values", (string)(dynsucursalId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divProductotable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitleproducto_Internalname, "producto", "", "", lblTitleproducto_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_factura.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridfactura_producto( ) ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "Right", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_factura.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_factura.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_factura.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Right", "Middle", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridfactura_producto( )
      {
         /*  Grid Control  */
         StartGridControl63( ) ;
         nGXsfl_63_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount6 = 1;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_6 = 1;
               ScanStart046( ) ;
               while ( RcdFound6 != 0 )
               {
                  init_level_properties6( ) ;
                  getByPrimaryKey046( ) ;
                  AddRow046( ) ;
                  ScanNext046( ) ;
               }
               ScanEnd046( ) ;
               nBlankRcdCount6 = 1;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal046( ) ;
            standaloneModal046( ) ;
            sMode6 = Gx_mode;
            while ( nGXsfl_63_idx < nRC_GXsfl_63 )
            {
               bGXsfl_63_Refreshing = true;
               ReadRow046( ) ;
               edtproductoId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTOID_"+sGXsfl_63_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtproductoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               edtproductoName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTONAME_"+sGXsfl_63_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtproductoName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoName_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               edtproductoCount_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTOCOUNT_"+sGXsfl_63_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtproductoCount_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoCount_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               edtproductoStock_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTOSTOCK_"+sGXsfl_63_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtproductoStock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoStock_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               imgprompt_5_Link = cgiGet( "PROMPT_5_"+sGXsfl_63_idx+"Link");
               if ( ( nRcdExists_6 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal046( ) ;
               }
               SendRow046( ) ;
               bGXsfl_63_Refreshing = false;
            }
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount6 = 1;
            nRcdExists_6 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart046( ) ;
               while ( RcdFound6 != 0 )
               {
                  sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_636( ) ;
                  init_level_properties6( ) ;
                  standaloneNotModal046( ) ;
                  getByPrimaryKey046( ) ;
                  standaloneModal046( ) ;
                  AddRow046( ) ;
                  ScanNext046( ) ;
               }
               ScanEnd046( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode6 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx+1), 4, 0), 4, "0");
            SubsflControlProps_636( ) ;
            InitAll046( ) ;
            init_level_properties6( ) ;
            nRcdExists_6 = 0;
            nIsMod_6 = 0;
            nRcdDeleted_6 = 0;
            nBlankRcdCount6 = (short)(nBlankRcdUsr6+nBlankRcdCount6);
            fRowAdded = 0;
            while ( nBlankRcdCount6 > 0 )
            {
               standaloneNotModal046( ) ;
               standaloneModal046( ) ;
               AddRow046( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtproductoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount6 = (short)(nBlankRcdCount6-1);
            }
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridfactura_productoContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridfactura_producto", Gridfactura_productoContainer, subGridfactura_producto_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridfactura_productoContainerData", Gridfactura_productoContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridfactura_productoContainerData"+"V", Gridfactura_productoContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridfactura_productoContainerData"+"V"+"\" value='"+Gridfactura_productoContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11042 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z8facturaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z8facturaId"), ",", "."), 18, MidpointRounding.ToEven));
               Z31facturaDate = context.localUtil.CToD( cgiGet( "Z31facturaDate"), 0);
               Z32facturaClientName = cgiGet( "Z32facturaClientName");
               Z33facturaTipoPago = cgiGet( "Z33facturaTipoPago");
               Z2sucursalId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z2sucursalId"), ",", "."), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_63 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_63"), ",", "."), 18, MidpointRounding.ToEven));
               N2sucursalId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N2sucursalId"), ",", "."), 18, MidpointRounding.ToEven));
               AV7facturaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vFACTURAID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_sucursalId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SUCURSALID"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               A13sucursalName = cgiGet( "SUCURSALNAME");
               A40000GXC1 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXC1"), ",", "."), 18, MidpointRounding.ToEven));
               n40000GXC1 = false;
               AV14Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A8facturaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtfacturaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A8facturaId", StringUtil.LTrimStr( (decimal)(A8facturaId), 4, 0));
               if ( context.localUtil.VCDate( cgiGet( edtfacturaDate_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"factura Date"}), 1, "FACTURADATE");
                  AnyError = 1;
                  GX_FocusControl = edtfacturaDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A31facturaDate = DateTime.MinValue;
                  AssignAttri("", false, "A31facturaDate", context.localUtil.Format(A31facturaDate, "99/99/99"));
               }
               else
               {
                  A31facturaDate = context.localUtil.CToD( cgiGet( edtfacturaDate_Internalname), 2);
                  AssignAttri("", false, "A31facturaDate", context.localUtil.Format(A31facturaDate, "99/99/99"));
               }
               A32facturaClientName = cgiGet( edtfacturaClientName_Internalname);
               AssignAttri("", false, "A32facturaClientName", A32facturaClientName);
               cmbfacturaTipoPago.Name = cmbfacturaTipoPago_Internalname;
               cmbfacturaTipoPago.CurrentValue = cgiGet( cmbfacturaTipoPago_Internalname);
               A33facturaTipoPago = cgiGet( cmbfacturaTipoPago_Internalname);
               AssignAttri("", false, "A33facturaTipoPago", A33facturaTipoPago);
               dynsucursalId.Name = dynsucursalId_Internalname;
               dynsucursalId.CurrentValue = cgiGet( dynsucursalId_Internalname);
               A2sucursalId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynsucursalId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A2sucursalId", StringUtil.LTrimStr( (decimal)(A2sucursalId), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"factura");
               A8facturaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtfacturaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A8facturaId", StringUtil.LTrimStr( (decimal)(A8facturaId), 4, 0));
               forbiddenHiddens.Add("facturaId", context.localUtil.Format( (decimal)(A8facturaId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A8facturaId != Z8facturaId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("factura:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A8facturaId = (short)(Math.Round(NumberUtil.Val( GetPar( "facturaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A8facturaId", StringUtil.LTrimStr( (decimal)(A8facturaId), 4, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode5 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode5;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound5 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_040( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "FACTURAID");
                        AnyError = 1;
                        GX_FocusControl = edtfacturaId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11042 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12042 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
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
            E12042 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll045( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
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

      protected void disable_std_buttons( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtn_delete_Visible = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtn_enter_Visible = 0;
               AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
            }
            DisableAttributes045( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_040( )
      {
         BeforeValidate045( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls045( ) ;
            }
            else
            {
               CheckExtendedTable045( ) ;
               CloseExtendedTableCursors045( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode5 = Gx_mode;
            CONFIRM_046( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode5;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_046( )
      {
         nGXsfl_63_idx = 0;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            ReadRow046( ) ;
            if ( ( nRcdExists_6 != 0 ) || ( nIsMod_6 != 0 ) )
            {
               GetKey046( ) ;
               if ( ( nRcdExists_6 == 0 ) && ( nRcdDeleted_6 == 0 ) )
               {
                  if ( RcdFound6 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate046( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable046( ) ;
                        CloseExtendedTableCursors046( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PRODUCTOID_" + sGXsfl_63_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtproductoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound6 != 0 )
                  {
                     if ( nRcdDeleted_6 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey046( ) ;
                        Load046( ) ;
                        BeforeValidate046( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls046( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_6 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate046( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable046( ) ;
                              CloseExtendedTableCursors046( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_6 == 0 )
                     {
                        GXCCtl = "PRODUCTOID_" + sGXsfl_63_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtproductoId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtproductoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A5productoId), 4, 0, ",", ""))) ;
            ChangePostValue( edtproductoName_Internalname, A25productoName) ;
            ChangePostValue( edtproductoCount_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A34productoCount), 4, 0, ",", ""))) ;
            ChangePostValue( edtproductoStock_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A30productoStock), 10, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z5productoId_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z5productoId), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z34productoCount_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z34productoCount), 4, 0, ",", ""))) ;
            ChangePostValue( "T34productoCount_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(O34productoCount), 4, 0, ",", ""))) ;
            ChangePostValue( "T30productoStock_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(O30productoStock), 10, 0, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_6_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_6), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_6_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_6), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_6_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_6), 4, 0, ",", ""))) ;
            if ( nIsMod_6 != 0 )
            {
               ChangePostValue( "PRODUCTOID_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTONAME_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTOCOUNT_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoCount_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTOSTOCK_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoStock_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* Using cursor T00048 */
         pr_default.execute(5, new Object[] {A8facturaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A40000GXC1 = T00048_A40000GXC1[0];
            n40000GXC1 = T00048_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
            AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         }
         if ( A40000GXC1 < 1 )
         {
            GX_msglist.addItem("Tiene que haber almenos un producto", 1, "");
            AnyError = 1;
         }
         /* End of After( level) rules */
      }

      protected void ResetCaption040( )
      {
      }

      protected void E11042( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV14Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV14Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_sucursalId = 0;
         AssignAttri("", false, "AV11Insert_sucursalId", StringUtil.LTrimStr( (decimal)(AV11Insert_sucursalId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV14Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV15GXV1 = 1;
            AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
            while ( AV15GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV15GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "sucursalId") == 0 )
               {
                  AV11Insert_sucursalId = (short)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_sucursalId", StringUtil.LTrimStr( (decimal)(AV11Insert_sucursalId), 4, 0));
               }
               AV15GXV1 = (int)(AV15GXV1+1);
               AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
            }
         }
      }

      protected void E12042( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwfactura.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM045( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z31facturaDate = T000410_A31facturaDate[0];
               Z32facturaClientName = T000410_A32facturaClientName[0];
               Z33facturaTipoPago = T000410_A33facturaTipoPago[0];
               Z2sucursalId = T000410_A2sucursalId[0];
            }
            else
            {
               Z31facturaDate = A31facturaDate;
               Z32facturaClientName = A32facturaClientName;
               Z33facturaTipoPago = A33facturaTipoPago;
               Z2sucursalId = A2sucursalId;
            }
         }
         if ( GX_JID == -16 )
         {
            Z8facturaId = A8facturaId;
            Z31facturaDate = A31facturaDate;
            Z32facturaClientName = A32facturaClientName;
            Z33facturaTipoPago = A33facturaTipoPago;
            Z2sucursalId = A2sucursalId;
            Z40000GXC1 = A40000GXC1;
            Z13sucursalName = A13sucursalName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtfacturaId_Enabled = 0;
         AssignProp("", false, edtfacturaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtfacturaId_Enabled), 5, 0), true);
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         edtfacturaId_Enabled = 0;
         AssignProp("", false, edtfacturaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtfacturaId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7facturaId) )
         {
            A8facturaId = AV7facturaId;
            AssignAttri("", false, "A8facturaId", StringUtil.LTrimStr( (decimal)(A8facturaId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_sucursalId) )
         {
            dynsucursalId.Enabled = 0;
            AssignProp("", false, dynsucursalId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynsucursalId.Enabled), 5, 0), true);
         }
         else
         {
            dynsucursalId.Enabled = 1;
            AssignProp("", false, dynsucursalId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynsucursalId.Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_sucursalId) )
         {
            A2sucursalId = AV11Insert_sucursalId;
            AssignAttri("", false, "A2sucursalId", StringUtil.LTrimStr( (decimal)(A2sucursalId), 4, 0));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00048 */
            pr_default.execute(5, new Object[] {A8facturaId});
            if ( (pr_default.getStatus(5) != 101) )
            {
               A40000GXC1 = T00048_A40000GXC1[0];
               n40000GXC1 = T00048_n40000GXC1[0];
            }
            else
            {
               A40000GXC1 = 0;
               n40000GXC1 = false;
               AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
            }
            pr_default.close(5);
            AV14Pgmname = "factura";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
            /* Using cursor T000411 */
            pr_default.execute(8, new Object[] {A2sucursalId});
            A13sucursalName = T000411_A13sucursalName[0];
            pr_default.close(8);
         }
      }

      protected void Load045( )
      {
         /* Using cursor T000413 */
         pr_default.execute(9, new Object[] {A8facturaId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound5 = 1;
            A31facturaDate = T000413_A31facturaDate[0];
            AssignAttri("", false, "A31facturaDate", context.localUtil.Format(A31facturaDate, "99/99/99"));
            A32facturaClientName = T000413_A32facturaClientName[0];
            AssignAttri("", false, "A32facturaClientName", A32facturaClientName);
            A33facturaTipoPago = T000413_A33facturaTipoPago[0];
            AssignAttri("", false, "A33facturaTipoPago", A33facturaTipoPago);
            A13sucursalName = T000413_A13sucursalName[0];
            A2sucursalId = T000413_A2sucursalId[0];
            AssignAttri("", false, "A2sucursalId", StringUtil.LTrimStr( (decimal)(A2sucursalId), 4, 0));
            A40000GXC1 = T000413_A40000GXC1[0];
            n40000GXC1 = T000413_n40000GXC1[0];
            ZM045( -16) ;
         }
         pr_default.close(9);
         OnLoadActions045( ) ;
      }

      protected void OnLoadActions045( )
      {
         AV14Pgmname = "factura";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
      }

      protected void CheckExtendedTable045( )
      {
         nIsDirty_5 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV14Pgmname = "factura";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         /* Using cursor T00048 */
         pr_default.execute(5, new Object[] {A8facturaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A40000GXC1 = T00048_A40000GXC1[0];
            n40000GXC1 = T00048_n40000GXC1[0];
         }
         else
         {
            nIsDirty_5 = 1;
            A40000GXC1 = 0;
            n40000GXC1 = false;
            AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         }
         pr_default.close(5);
         if ( ! ( (DateTime.MinValue==A31facturaDate) || ( DateTimeUtil.ResetTime ( A31facturaDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo factura Date fuera de rango", "OutOfRange", 1, "FACTURADATE");
            AnyError = 1;
            GX_FocusControl = edtfacturaDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A33facturaTipoPago, "C") == 0 ) || ( StringUtil.StrCmp(A33facturaTipoPago, "T") == 0 ) ) )
         {
            GX_msglist.addItem("Campo factura Tipo Pago fuera de rango", "OutOfRange", 1, "FACTURATIPOPAGO");
            AnyError = 1;
            GX_FocusControl = cmbfacturaTipoPago_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000411 */
         pr_default.execute(8, new Object[] {A2sucursalId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'sucursal'.", "ForeignKeyNotFound", 1, "SUCURSALID");
            AnyError = 1;
            GX_FocusControl = dynsucursalId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A13sucursalName = T000411_A13sucursalName[0];
         pr_default.close(8);
         if ( DateTimeUtil.ResetTime ( A31facturaDate ) < DateTimeUtil.ResetTime ( Gx_date ) )
         {
            GX_msglist.addItem("La fecha tiene que ser presente o futura", 1, "FACTURADATE");
            AnyError = 1;
            GX_FocusControl = edtfacturaDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors045( )
      {
         pr_default.close(5);
         pr_default.close(8);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_18( short A8facturaId )
      {
         /* Using cursor T000415 */
         pr_default.execute(10, new Object[] {A8facturaId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A40000GXC1 = T000415_A40000GXC1[0];
            n40000GXC1 = T000415_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
            AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A40000GXC1), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_17( short A2sucursalId )
      {
         /* Using cursor T000416 */
         pr_default.execute(11, new Object[] {A2sucursalId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'sucursal'.", "ForeignKeyNotFound", 1, "SUCURSALID");
            AnyError = 1;
            GX_FocusControl = dynsucursalId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A13sucursalName = T000416_A13sucursalName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A13sucursalName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void GetKey045( )
      {
         /* Using cursor T000417 */
         pr_default.execute(12, new Object[] {A8facturaId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(12);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000410 */
         pr_default.execute(7, new Object[] {A8facturaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            ZM045( 16) ;
            RcdFound5 = 1;
            A8facturaId = T000410_A8facturaId[0];
            AssignAttri("", false, "A8facturaId", StringUtil.LTrimStr( (decimal)(A8facturaId), 4, 0));
            A31facturaDate = T000410_A31facturaDate[0];
            AssignAttri("", false, "A31facturaDate", context.localUtil.Format(A31facturaDate, "99/99/99"));
            A32facturaClientName = T000410_A32facturaClientName[0];
            AssignAttri("", false, "A32facturaClientName", A32facturaClientName);
            A33facturaTipoPago = T000410_A33facturaTipoPago[0];
            AssignAttri("", false, "A33facturaTipoPago", A33facturaTipoPago);
            A2sucursalId = T000410_A2sucursalId[0];
            AssignAttri("", false, "A2sucursalId", StringUtil.LTrimStr( (decimal)(A2sucursalId), 4, 0));
            Z8facturaId = A8facturaId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load045( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey045( ) ;
            }
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey045( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(7);
      }

      protected void getEqualNoModal( )
      {
         GetKey045( ) ;
         if ( RcdFound5 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound5 = 0;
         /* Using cursor T000418 */
         pr_default.execute(13, new Object[] {A8facturaId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( T000418_A8facturaId[0] < A8facturaId ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( T000418_A8facturaId[0] > A8facturaId ) ) )
            {
               A8facturaId = T000418_A8facturaId[0];
               AssignAttri("", false, "A8facturaId", StringUtil.LTrimStr( (decimal)(A8facturaId), 4, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void move_previous( )
      {
         RcdFound5 = 0;
         /* Using cursor T000419 */
         pr_default.execute(14, new Object[] {A8facturaId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( T000419_A8facturaId[0] > A8facturaId ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( T000419_A8facturaId[0] < A8facturaId ) ) )
            {
               A8facturaId = T000419_A8facturaId[0];
               AssignAttri("", false, "A8facturaId", StringUtil.LTrimStr( (decimal)(A8facturaId), 4, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey045( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtfacturaDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert045( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( A8facturaId != Z8facturaId )
               {
                  A8facturaId = Z8facturaId;
                  AssignAttri("", false, "A8facturaId", StringUtil.LTrimStr( (decimal)(A8facturaId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "FACTURAID");
                  AnyError = 1;
                  GX_FocusControl = edtfacturaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtfacturaDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update045( ) ;
                  GX_FocusControl = edtfacturaDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A8facturaId != Z8facturaId )
               {
                  /* Insert record */
                  GX_FocusControl = edtfacturaDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert045( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "FACTURAID");
                     AnyError = 1;
                     GX_FocusControl = edtfacturaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtfacturaDate_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert045( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A8facturaId != Z8facturaId )
         {
            A8facturaId = Z8facturaId;
            AssignAttri("", false, "A8facturaId", StringUtil.LTrimStr( (decimal)(A8facturaId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "FACTURAID");
            AnyError = 1;
            GX_FocusControl = edtfacturaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtfacturaDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency045( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00049 */
            pr_default.execute(6, new Object[] {A8facturaId});
            if ( (pr_default.getStatus(6) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"factura"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(6) == 101) || ( DateTimeUtil.ResetTime ( Z31facturaDate ) != DateTimeUtil.ResetTime ( T00049_A31facturaDate[0] ) ) || ( StringUtil.StrCmp(Z32facturaClientName, T00049_A32facturaClientName[0]) != 0 ) || ( StringUtil.StrCmp(Z33facturaTipoPago, T00049_A33facturaTipoPago[0]) != 0 ) || ( Z2sucursalId != T00049_A2sucursalId[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z31facturaDate ) != DateTimeUtil.ResetTime ( T00049_A31facturaDate[0] ) )
               {
                  GXUtil.WriteLog("factura:[seudo value changed for attri]"+"facturaDate");
                  GXUtil.WriteLogRaw("Old: ",Z31facturaDate);
                  GXUtil.WriteLogRaw("Current: ",T00049_A31facturaDate[0]);
               }
               if ( StringUtil.StrCmp(Z32facturaClientName, T00049_A32facturaClientName[0]) != 0 )
               {
                  GXUtil.WriteLog("factura:[seudo value changed for attri]"+"facturaClientName");
                  GXUtil.WriteLogRaw("Old: ",Z32facturaClientName);
                  GXUtil.WriteLogRaw("Current: ",T00049_A32facturaClientName[0]);
               }
               if ( StringUtil.StrCmp(Z33facturaTipoPago, T00049_A33facturaTipoPago[0]) != 0 )
               {
                  GXUtil.WriteLog("factura:[seudo value changed for attri]"+"facturaTipoPago");
                  GXUtil.WriteLogRaw("Old: ",Z33facturaTipoPago);
                  GXUtil.WriteLogRaw("Current: ",T00049_A33facturaTipoPago[0]);
               }
               if ( Z2sucursalId != T00049_A2sucursalId[0] )
               {
                  GXUtil.WriteLog("factura:[seudo value changed for attri]"+"sucursalId");
                  GXUtil.WriteLogRaw("Old: ",Z2sucursalId);
                  GXUtil.WriteLogRaw("Current: ",T00049_A2sucursalId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"factura"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert045( )
      {
         BeforeValidate045( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable045( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM045( 0) ;
            CheckOptimisticConcurrency045( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm045( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert045( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000420 */
                     pr_default.execute(15, new Object[] {A31facturaDate, A32facturaClientName, A33facturaTipoPago, A2sucursalId});
                     A8facturaId = T000420_A8facturaId[0];
                     AssignAttri("", false, "A8facturaId", StringUtil.LTrimStr( (decimal)(A8facturaId), 4, 0));
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("factura");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel045( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption040( ) ;
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
               Load045( ) ;
            }
            EndLevel045( ) ;
         }
         CloseExtendedTableCursors045( ) ;
      }

      protected void Update045( )
      {
         BeforeValidate045( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable045( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency045( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm045( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate045( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000421 */
                     pr_default.execute(16, new Object[] {A31facturaDate, A32facturaClientName, A33facturaTipoPago, A2sucursalId, A8facturaId});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("factura");
                     if ( (pr_default.getStatus(16) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"factura"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate045( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel045( ) ;
                           if ( AnyError == 0 )
                           {
                              if ( IsUpd( ) || IsDlt( ) )
                              {
                                 if ( AnyError == 0 )
                                 {
                                    context.nUserReturn = 1;
                                 }
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
            }
            EndLevel045( ) ;
         }
         CloseExtendedTableCursors045( ) ;
      }

      protected void DeferredUpdate045( )
      {
      }

      protected void delete( )
      {
         BeforeValidate045( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency045( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls045( ) ;
            AfterConfirm045( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete045( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart046( ) ;
                  while ( RcdFound6 != 0 )
                  {
                     getByPrimaryKey046( ) ;
                     Delete046( ) ;
                     ScanNext046( ) ;
                  }
                  ScanEnd046( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000422 */
                     pr_default.execute(17, new Object[] {A8facturaId});
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("factura");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
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
            }
         }
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel045( ) ;
         Gx_mode = sMode5;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls045( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV14Pgmname = "factura";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
            /* Using cursor T000424 */
            pr_default.execute(18, new Object[] {A8facturaId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               A40000GXC1 = T000424_A40000GXC1[0];
               n40000GXC1 = T000424_n40000GXC1[0];
            }
            else
            {
               A40000GXC1 = 0;
               n40000GXC1 = false;
               AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
            }
            pr_default.close(18);
            /* Using cursor T000425 */
            pr_default.execute(19, new Object[] {A2sucursalId});
            A13sucursalName = T000425_A13sucursalName[0];
            pr_default.close(19);
         }
      }

      protected void ProcessNestedLevel046( )
      {
         nGXsfl_63_idx = 0;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            ReadRow046( ) ;
            if ( ( nRcdExists_6 != 0 ) || ( nIsMod_6 != 0 ) )
            {
               standaloneNotModal046( ) ;
               GetKey046( ) ;
               if ( ( nRcdExists_6 == 0 ) && ( nRcdDeleted_6 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert046( ) ;
               }
               else
               {
                  if ( RcdFound6 != 0 )
                  {
                     if ( ( nRcdDeleted_6 != 0 ) && ( nRcdExists_6 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete046( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_6 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update046( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_6 == 0 )
                     {
                        GXCCtl = "PRODUCTOID_" + sGXsfl_63_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtproductoId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtproductoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A5productoId), 4, 0, ",", ""))) ;
            ChangePostValue( edtproductoName_Internalname, A25productoName) ;
            ChangePostValue( edtproductoCount_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A34productoCount), 4, 0, ",", ""))) ;
            ChangePostValue( edtproductoStock_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A30productoStock), 10, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z5productoId_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z5productoId), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z34productoCount_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z34productoCount), 4, 0, ",", ""))) ;
            ChangePostValue( "T34productoCount_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(O34productoCount), 4, 0, ",", ""))) ;
            ChangePostValue( "T30productoStock_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(O30productoStock), 10, 0, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_6_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_6), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_6_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_6), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_6_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_6), 4, 0, ",", ""))) ;
            if ( nIsMod_6 != 0 )
            {
               ChangePostValue( "PRODUCTOID_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTONAME_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTOCOUNT_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoCount_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTOSTOCK_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoStock_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* Using cursor T000424 */
         pr_default.execute(18, new Object[] {A8facturaId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            A40000GXC1 = T000424_A40000GXC1[0];
            n40000GXC1 = T000424_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
            AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         }
         if ( A40000GXC1 < 1 )
         {
            GX_msglist.addItem("Tiene que haber almenos un producto", 1, "");
            AnyError = 1;
         }
         /* End of After( level) rules */
         InitAll046( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_6 = 0;
         nIsMod_6 = 0;
         nRcdDeleted_6 = 0;
      }

      protected void ProcessLevel045( )
      {
         /* Save parent mode. */
         sMode5 = Gx_mode;
         ProcessNestedLevel046( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode5;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel045( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(6);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete045( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(7);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(19);
            pr_default.close(18);
            pr_default.close(2);
            pr_default.close(4);
            pr_default.close(3);
            context.CommitDataStores("factura",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues040( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(7);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(19);
            pr_default.close(18);
            pr_default.close(2);
            pr_default.close(4);
            pr_default.close(3);
            context.RollbackDataStores("factura",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart045( )
      {
         /* Scan By routine */
         /* Using cursor T000426 */
         pr_default.execute(20);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound5 = 1;
            A8facturaId = T000426_A8facturaId[0];
            AssignAttri("", false, "A8facturaId", StringUtil.LTrimStr( (decimal)(A8facturaId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext045( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound5 = 1;
            A8facturaId = T000426_A8facturaId[0];
            AssignAttri("", false, "A8facturaId", StringUtil.LTrimStr( (decimal)(A8facturaId), 4, 0));
         }
      }

      protected void ScanEnd045( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm045( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert045( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate045( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete045( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete045( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate045( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes045( )
      {
         edtfacturaId_Enabled = 0;
         AssignProp("", false, edtfacturaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtfacturaId_Enabled), 5, 0), true);
         edtfacturaDate_Enabled = 0;
         AssignProp("", false, edtfacturaDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtfacturaDate_Enabled), 5, 0), true);
         edtfacturaClientName_Enabled = 0;
         AssignProp("", false, edtfacturaClientName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtfacturaClientName_Enabled), 5, 0), true);
         cmbfacturaTipoPago.Enabled = 0;
         AssignProp("", false, cmbfacturaTipoPago_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbfacturaTipoPago.Enabled), 5, 0), true);
         dynsucursalId.Enabled = 0;
         AssignProp("", false, dynsucursalId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynsucursalId.Enabled), 5, 0), true);
      }

      protected void ZM046( short GX_JID )
      {
         if ( ( GX_JID == 19 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z34productoCount = T00043_A34productoCount[0];
            }
            else
            {
               Z34productoCount = A34productoCount;
            }
         }
         if ( ( GX_JID == 21 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -19 )
         {
            Z8facturaId = A8facturaId;
            Z34productoCount = A34productoCount;
            Z5productoId = A5productoId;
            Z25productoName = A25productoName;
            Z30productoStock = A30productoStock;
         }
      }

      protected void standaloneNotModal046( )
      {
         edtproductoStock_Enabled = 0;
         AssignProp("", false, edtproductoStock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoStock_Enabled), 5, 0), !bGXsfl_63_Refreshing);
      }

      protected void standaloneModal046( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtproductoId_Enabled = 0;
            AssignProp("", false, edtproductoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         }
         else
         {
            edtproductoId_Enabled = 1;
            AssignProp("", false, edtproductoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         }
      }

      protected void Load046( )
      {
         /* Using cursor T000427 */
         pr_default.execute(21, new Object[] {A2sucursalId, A8facturaId, A5productoId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound6 = 1;
            A30productoStock = T000427_A30productoStock[0];
            A25productoName = T000427_A25productoName[0];
            A34productoCount = T000427_A34productoCount[0];
            ZM046( -19) ;
         }
         pr_default.close(21);
         OnLoadActions046( ) ;
      }

      protected void OnLoadActions046( )
      {
      }

      protected void CheckExtendedTable046( )
      {
         nIsDirty_6 = 0;
         Gx_BScreen = 1;
         standaloneModal046( ) ;
         /* Using cursor T00044 */
         pr_default.execute(2, new Object[] {A5productoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PRODUCTOID_" + sGXsfl_63_idx;
            GX_msglist.addItem("No existe 'producto'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtproductoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A25productoName = T00044_A25productoName[0];
         pr_default.close(2);
         /* Using cursor T00046 */
         pr_default.execute(4, new Object[] {A2sucursalId, A5productoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GXCCtl = "PRODUCTOID_" + sGXsfl_63_idx;
            GX_msglist.addItem("No existe 'producto'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtproductoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A30productoStock = T00046_A30productoStock[0];
         nIsDirty_6 = 1;
         O30productoStock = A30productoStock;
         pr_default.close(4);
         if ( A30productoStock < A34productoCount )
         {
            GXCCtl = "PRODUCTOCOUNT_" + sGXsfl_63_idx;
            GX_msglist.addItem("La cantidad de compra es mayor al stock", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtproductoCount_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( A34productoCount == 0 )
         {
            GXCCtl = "PRODUCTOCOUNT_" + sGXsfl_63_idx;
            GX_msglist.addItem("Seleccione una cantidad de producto", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtproductoCount_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors046( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable046( )
      {
      }

      protected void gxLoad_20( short A5productoId )
      {
         /* Using cursor T000428 */
         pr_default.execute(22, new Object[] {A5productoId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GXCCtl = "PRODUCTOID_" + sGXsfl_63_idx;
            GX_msglist.addItem("No existe 'producto'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtproductoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A25productoName = T000428_A25productoName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A25productoName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(22) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(22);
      }

      protected void gxLoad_21( short A2sucursalId ,
                                short A5productoId )
      {
         /* Using cursor T00046 */
         pr_default.execute(4, new Object[] {A2sucursalId, A5productoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GXCCtl = "PRODUCTOID_" + sGXsfl_63_idx;
            GX_msglist.addItem("No existe 'producto'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtproductoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A30productoStock = T00046_A30productoStock[0];
         O30productoStock = A30productoStock;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A30productoStock), 10, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey046( )
      {
         /* Using cursor T000429 */
         pr_default.execute(23, new Object[] {A8facturaId, A5productoId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(23);
      }

      protected void getByPrimaryKey046( )
      {
         /* Using cursor T00043 */
         pr_default.execute(1, new Object[] {A8facturaId, A5productoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM046( 19) ;
            RcdFound6 = 1;
            InitializeNonKey046( ) ;
            A34productoCount = T00043_A34productoCount[0];
            A5productoId = T00043_A5productoId[0];
            O34productoCount = A34productoCount;
            Z8facturaId = A8facturaId;
            Z5productoId = A5productoId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load046( ) ;
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey046( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal046( ) ;
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes046( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency046( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00042 */
            pr_default.execute(0, new Object[] {A8facturaId, A5productoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"facturaproducto"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z34productoCount != T00042_A34productoCount[0] ) )
            {
               if ( Z34productoCount != T00042_A34productoCount[0] )
               {
                  GXUtil.WriteLog("factura:[seudo value changed for attri]"+"productoCount");
                  GXUtil.WriteLogRaw("Old: ",Z34productoCount);
                  GXUtil.WriteLogRaw("Current: ",T00042_A34productoCount[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"facturaproducto"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
         /* Using cursor T000430 */
         pr_default.execute(24, new Object[] {A2sucursalId, A5productoId});
         if ( (pr_default.getStatus(24) == 103) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"sucursalproducto"}), "RecordIsLocked", 1, "");
            AnyError = 1;
            return  ;
         }
         if ( ! IsIns( ) )
         {
            if ( false )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"sucursalproducto"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert046( )
      {
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable046( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM046( 0) ;
            CheckOptimisticConcurrency046( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm046( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert046( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000431 */
                     pr_default.execute(25, new Object[] {A8facturaId, A34productoCount, A5productoId});
                     pr_default.close(25);
                     pr_default.SmartCacheProvider.SetUpdated("facturaproducto");
                     if ( (pr_default.getStatus(25) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        UpdateTablesN1046( ) ;
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
               Load046( ) ;
            }
            EndLevel046( ) ;
         }
         CloseExtendedTableCursors046( ) ;
      }

      protected void Update046( )
      {
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable046( ) ;
         }
         if ( ( nIsMod_6 != 0 ) || ( nIsDirty_6 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency046( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm046( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate046( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000432 */
                        pr_default.execute(26, new Object[] {A34productoCount, A8facturaId, A5productoId});
                        pr_default.close(26);
                        pr_default.SmartCacheProvider.SetUpdated("facturaproducto");
                        if ( (pr_default.getStatus(26) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"facturaproducto"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate046( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              UpdateTablesN1046( ) ;
                              getByPrimaryKey046( ) ;
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
               EndLevel046( ) ;
            }
         }
         CloseExtendedTableCursors046( ) ;
      }

      protected void DeferredUpdate046( )
      {
      }

      protected void Delete046( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency046( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls046( ) ;
            AfterConfirm046( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete046( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000433 */
                  pr_default.execute(27, new Object[] {A8facturaId, A5productoId});
                  pr_default.close(27);
                  pr_default.SmartCacheProvider.SetUpdated("facturaproducto");
                  if ( AnyError == 0 )
                  {
                     UpdateTablesN1046( ) ;
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
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel046( ) ;
         Gx_mode = sMode6;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls046( )
      {
         standaloneModal046( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000434 */
            pr_default.execute(28, new Object[] {A5productoId});
            A25productoName = T000434_A25productoName[0];
            pr_default.close(28);
            /* Using cursor T000435 */
            pr_default.execute(29, new Object[] {A2sucursalId, A5productoId});
            A30productoStock = T000435_A30productoStock[0];
            O30productoStock = A30productoStock;
            pr_default.close(29);
         }
      }

      protected void UpdateTablesN1046( )
      {
         /* Using cursor T000436 */
         pr_default.execute(30, new Object[] {A30productoStock, A2sucursalId, A5productoId});
         pr_default.close(30);
         pr_default.SmartCacheProvider.SetUpdated("sucursalproducto");
      }

      protected void EndLevel046( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         pr_default.close(24);
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart046( )
      {
         /* Scan By routine */
         /* Using cursor T000437 */
         pr_default.execute(31, new Object[] {A8facturaId});
         RcdFound6 = 0;
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound6 = 1;
            A5productoId = T000437_A5productoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext046( )
      {
         /* Scan next routine */
         pr_default.readNext(31);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound6 = 1;
            A5productoId = T000437_A5productoId[0];
         }
      }

      protected void ScanEnd046( )
      {
         pr_default.close(31);
      }

      protected void AfterConfirm046( )
      {
         /* After Confirm Rules */
         if ( IsDlt( )  )
         {
            A30productoStock = (long)(O30productoStock+O34productoCount);
         }
         else
         {
            if ( IsIns( )  || IsUpd( )  || IsDlt( )  )
            {
               A30productoStock = (long)(O30productoStock-A34productoCount+O34productoCount);
            }
         }
      }

      protected void BeforeInsert046( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate046( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete046( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete046( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate046( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes046( )
      {
         edtproductoId_Enabled = 0;
         AssignProp("", false, edtproductoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         edtproductoName_Enabled = 0;
         AssignProp("", false, edtproductoName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoName_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         edtproductoCount_Enabled = 0;
         AssignProp("", false, edtproductoCount_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoCount_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         edtproductoStock_Enabled = 0;
         AssignProp("", false, edtproductoStock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoStock_Enabled), 5, 0), !bGXsfl_63_Refreshing);
      }

      protected void send_integrity_lvl_hashes046( )
      {
      }

      protected void send_integrity_lvl_hashes045( )
      {
      }

      protected void SubsflControlProps_636( )
      {
         edtproductoId_Internalname = "PRODUCTOID_"+sGXsfl_63_idx;
         imgprompt_5_Internalname = "PROMPT_5_"+sGXsfl_63_idx;
         edtproductoName_Internalname = "PRODUCTONAME_"+sGXsfl_63_idx;
         edtproductoCount_Internalname = "PRODUCTOCOUNT_"+sGXsfl_63_idx;
         edtproductoStock_Internalname = "PRODUCTOSTOCK_"+sGXsfl_63_idx;
      }

      protected void SubsflControlProps_fel_636( )
      {
         edtproductoId_Internalname = "PRODUCTOID_"+sGXsfl_63_fel_idx;
         imgprompt_5_Internalname = "PROMPT_5_"+sGXsfl_63_fel_idx;
         edtproductoName_Internalname = "PRODUCTONAME_"+sGXsfl_63_fel_idx;
         edtproductoCount_Internalname = "PRODUCTOCOUNT_"+sGXsfl_63_fel_idx;
         edtproductoStock_Internalname = "PRODUCTOSTOCK_"+sGXsfl_63_fel_idx;
      }

      protected void AddRow046( )
      {
         nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_636( ) ;
         SendRow046( ) ;
      }

      protected void SendRow046( )
      {
         Gridfactura_productoRow = GXWebRow.GetNew(context);
         if ( subGridfactura_producto_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridfactura_producto_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridfactura_producto_Class, "") != 0 )
            {
               subGridfactura_producto_Linesclass = subGridfactura_producto_Class+"Odd";
            }
         }
         else if ( subGridfactura_producto_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridfactura_producto_Backstyle = 0;
            subGridfactura_producto_Backcolor = subGridfactura_producto_Allbackcolor;
            if ( StringUtil.StrCmp(subGridfactura_producto_Class, "") != 0 )
            {
               subGridfactura_producto_Linesclass = subGridfactura_producto_Class+"Uniform";
            }
         }
         else if ( subGridfactura_producto_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridfactura_producto_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridfactura_producto_Class, "") != 0 )
            {
               subGridfactura_producto_Linesclass = subGridfactura_producto_Class+"Odd";
            }
            subGridfactura_producto_Backcolor = (int)(0x0);
         }
         else if ( subGridfactura_producto_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridfactura_producto_Backstyle = 1;
            if ( ((int)((nGXsfl_63_idx) % (2))) == 0 )
            {
               subGridfactura_producto_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridfactura_producto_Class, "") != 0 )
               {
                  subGridfactura_producto_Linesclass = subGridfactura_producto_Class+"Even";
               }
            }
            else
            {
               subGridfactura_producto_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridfactura_producto_Class, "") != 0 )
               {
                  subGridfactura_producto_Linesclass = subGridfactura_producto_Class+"Odd";
               }
            }
         }
         imgprompt_5_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUCTOID_"+sGXsfl_63_idx+"'), id:'"+"PRODUCTOID_"+sGXsfl_63_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_6_"+sGXsfl_63_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_6_" + sGXsfl_63_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_63_idx + "',63)\"";
         ROClassString = "Attribute";
         Gridfactura_productoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtproductoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A5productoId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A5productoId), "ZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,64);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtproductoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtproductoId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)63,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridfactura_productoRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_5_Internalname,(string)sImgUrl,(string)imgprompt_5_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_5_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridfactura_productoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtproductoName_Internalname,(string)A25productoName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtproductoName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtproductoName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)63,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_6_" + sGXsfl_63_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_63_idx + "',63)\"";
         ROClassString = "Attribute";
         Gridfactura_productoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtproductoCount_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A34productoCount), 4, 0, ",", "")),StringUtil.LTrim( ((edtproductoCount_Enabled!=0) ? context.localUtil.Format( (decimal)(A34productoCount), "ZZZ9") : context.localUtil.Format( (decimal)(A34productoCount), "ZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,66);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtproductoCount_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtproductoCount_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)63,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridfactura_productoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtproductoStock_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A30productoStock), 10, 0, ",", "")),StringUtil.LTrim( ((edtproductoStock_Enabled!=0) ? context.localUtil.Format( (decimal)(A30productoStock), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A30productoStock), "ZZZZZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtproductoStock_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtproductoStock_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)63,(short)0,(short)-1,(short)0,(bool)true,(string)"Stock",(string)"right",(bool)false,(string)""});
         ajax_sending_grid_row(Gridfactura_productoRow);
         send_integrity_lvl_hashes046( ) ;
         GXCCtl = "Z5productoId_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z5productoId), 4, 0, ",", "")));
         GXCCtl = "Z34productoCount_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z34productoCount), 4, 0, ",", "")));
         GXCCtl = "O34productoCount_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(O34productoCount), 4, 0, ",", "")));
         GXCCtl = "O30productoStock_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(O30productoStock), 10, 0, ",", "")));
         GXCCtl = "nRcdDeleted_6_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_6), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_6_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_6), 4, 0, ",", "")));
         GXCCtl = "nIsMod_6_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_6), 4, 0, ",", "")));
         GXCCtl = "vMODE_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_63_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vFACTURAID_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7facturaId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTOID_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTONAME_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTOCOUNT_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoCount_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTOSTOCK_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoStock_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_5_"+sGXsfl_63_idx+"Link", StringUtil.RTrim( imgprompt_5_Link));
         ajax_sending_grid_row(null);
         Gridfactura_productoContainer.AddRow(Gridfactura_productoRow);
      }

      protected void ReadRow046( )
      {
         nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_636( ) ;
         edtproductoId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTOID_"+sGXsfl_63_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtproductoName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTONAME_"+sGXsfl_63_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtproductoCount_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTOCOUNT_"+sGXsfl_63_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtproductoStock_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTOSTOCK_"+sGXsfl_63_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         imgprompt_5_Link = cgiGet( "PROMPT_5_"+sGXsfl_63_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtproductoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtproductoId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "PRODUCTOID_" + sGXsfl_63_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtproductoId_Internalname;
            wbErr = true;
            A5productoId = 0;
         }
         else
         {
            A5productoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtproductoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
         }
         A25productoName = cgiGet( edtproductoName_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtproductoCount_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtproductoCount_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "PRODUCTOCOUNT_" + sGXsfl_63_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtproductoCount_Internalname;
            wbErr = true;
            A34productoCount = 0;
         }
         else
         {
            A34productoCount = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtproductoCount_Internalname), ",", "."), 18, MidpointRounding.ToEven));
         }
         A30productoStock = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtproductoStock_Internalname), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "Z5productoId_" + sGXsfl_63_idx;
         Z5productoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "Z34productoCount_" + sGXsfl_63_idx;
         Z34productoCount = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "O34productoCount_" + sGXsfl_63_idx;
         O34productoCount = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "O30productoStock_" + sGXsfl_63_idx;
         O30productoStock = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_6_" + sGXsfl_63_idx;
         nRcdDeleted_6 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_6_" + sGXsfl_63_idx;
         nRcdExists_6 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_6_" + sGXsfl_63_idx;
         nIsMod_6 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtproductoStock_Enabled = edtproductoStock_Enabled;
         defedtproductoId_Enabled = edtproductoId_Enabled;
      }

      protected void ConfirmValues040( )
      {
         nGXsfl_63_idx = 0;
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_636( ) ;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
            sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
            SubsflControlProps_636( ) ;
            ChangePostValue( "Z5productoId_"+sGXsfl_63_idx, cgiGet( "ZT_"+"Z5productoId_"+sGXsfl_63_idx)) ;
            DeletePostValue( "ZT_"+"Z5productoId_"+sGXsfl_63_idx) ;
            ChangePostValue( "Z34productoCount_"+sGXsfl_63_idx, cgiGet( "ZT_"+"Z34productoCount_"+sGXsfl_63_idx)) ;
            DeletePostValue( "ZT_"+"Z34productoCount_"+sGXsfl_63_idx) ;
         }
         ChangePostValue( "O34productoCount", cgiGet( "T34productoCount")) ;
         DeletePostValue( "T34productoCount") ;
         ChangePostValue( "O30productoStock", cgiGet( "T30productoStock")) ;
         DeletePostValue( "T30productoStock") ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 55580), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 55580), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 55580), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 55580), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 55580), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 55580), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("factura.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7facturaId,4,0))}, new string[] {"Gx_mode","facturaId"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"factura");
         forbiddenHiddens.Add("facturaId", context.localUtil.Format( (decimal)(A8facturaId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("factura:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z8facturaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z8facturaId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z31facturaDate", context.localUtil.DToC( Z31facturaDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z32facturaClientName", Z32facturaClientName);
         GxWebStd.gx_hidden_field( context, "Z33facturaTipoPago", Z33facturaTipoPago);
         GxWebStd.gx_hidden_field( context, "Z2sucursalId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2sucursalId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_63", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_63_idx), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N2sucursalId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2sucursalId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vFACTURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7facturaId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vFACTURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7facturaId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_SUCURSALID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_sucursalId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "SUCURSALNAME", A13sucursalName);
         GxWebStd.gx_hidden_field( context, "GXC1", StringUtil.LTrim( StringUtil.NToC( (decimal)(A40000GXC1), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV14Pgmname));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("factura.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7facturaId,4,0))}, new string[] {"Gx_mode","facturaId"})  ;
      }

      public override string GetPgmname( )
      {
         return "factura" ;
      }

      public override string GetPgmdesc( )
      {
         return "factura" ;
      }

      protected void InitializeNonKey045( )
      {
         A2sucursalId = 0;
         AssignAttri("", false, "A2sucursalId", StringUtil.LTrimStr( (decimal)(A2sucursalId), 4, 0));
         A31facturaDate = DateTime.MinValue;
         AssignAttri("", false, "A31facturaDate", context.localUtil.Format(A31facturaDate, "99/99/99"));
         A32facturaClientName = "";
         AssignAttri("", false, "A32facturaClientName", A32facturaClientName);
         A33facturaTipoPago = "";
         AssignAttri("", false, "A33facturaTipoPago", A33facturaTipoPago);
         A13sucursalName = "";
         AssignAttri("", false, "A13sucursalName", A13sucursalName);
         A40000GXC1 = 0;
         n40000GXC1 = false;
         AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         Z31facturaDate = DateTime.MinValue;
         Z32facturaClientName = "";
         Z33facturaTipoPago = "";
         Z2sucursalId = 0;
      }

      protected void InitAll045( )
      {
         A8facturaId = 0;
         AssignAttri("", false, "A8facturaId", StringUtil.LTrimStr( (decimal)(A8facturaId), 4, 0));
         InitializeNonKey045( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey046( )
      {
         A30productoStock = 0;
         A25productoName = "";
         A34productoCount = 0;
         O34productoCount = A34productoCount;
         O30productoStock = A30productoStock;
         Z34productoCount = 0;
      }

      protected void InitAll046( )
      {
         A5productoId = 0;
         InitializeNonKey046( ) ;
      }

      protected void StandaloneModalInsert046( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20233241858836", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("factura.js", "?20233241858836", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties6( )
      {
         edtproductoStock_Enabled = defedtproductoStock_Enabled;
         AssignProp("", false, edtproductoStock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoStock_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         edtproductoId_Enabled = defedtproductoId_Enabled;
         AssignProp("", false, edtproductoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
      }

      protected void StartGridControl63( )
      {
         Gridfactura_productoContainer.AddObjectProperty("GridName", "Gridfactura_producto");
         Gridfactura_productoContainer.AddObjectProperty("Header", subGridfactura_producto_Header);
         Gridfactura_productoContainer.AddObjectProperty("Class", "Grid");
         Gridfactura_productoContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridfactura_productoContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridfactura_productoContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfactura_producto_Backcolorstyle), 1, 0, ".", "")));
         Gridfactura_productoContainer.AddObjectProperty("CmpContext", "");
         Gridfactura_productoContainer.AddObjectProperty("InMasterPage", "false");
         Gridfactura_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridfactura_productoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A5productoId), 4, 0, ".", ""))));
         Gridfactura_productoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoId_Enabled), 5, 0, ".", "")));
         Gridfactura_productoContainer.AddColumnProperties(Gridfactura_productoColumn);
         Gridfactura_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridfactura_productoContainer.AddColumnProperties(Gridfactura_productoColumn);
         Gridfactura_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridfactura_productoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A25productoName));
         Gridfactura_productoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoName_Enabled), 5, 0, ".", "")));
         Gridfactura_productoContainer.AddColumnProperties(Gridfactura_productoColumn);
         Gridfactura_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridfactura_productoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A34productoCount), 4, 0, ".", ""))));
         Gridfactura_productoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoCount_Enabled), 5, 0, ".", "")));
         Gridfactura_productoContainer.AddColumnProperties(Gridfactura_productoColumn);
         Gridfactura_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridfactura_productoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A30productoStock), 10, 0, ".", ""))));
         Gridfactura_productoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoStock_Enabled), 5, 0, ".", "")));
         Gridfactura_productoContainer.AddColumnProperties(Gridfactura_productoColumn);
         Gridfactura_productoContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfactura_producto_Selectedindex), 4, 0, ".", "")));
         Gridfactura_productoContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfactura_producto_Allowselection), 1, 0, ".", "")));
         Gridfactura_productoContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfactura_producto_Selectioncolor), 9, 0, ".", "")));
         Gridfactura_productoContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfactura_producto_Allowhovering), 1, 0, ".", "")));
         Gridfactura_productoContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfactura_producto_Hoveringcolor), 9, 0, ".", "")));
         Gridfactura_productoContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfactura_producto_Allowcollapsing), 1, 0, ".", "")));
         Gridfactura_productoContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfactura_producto_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtfacturaId_Internalname = "FACTURAID";
         edtfacturaDate_Internalname = "FACTURADATE";
         edtfacturaClientName_Internalname = "FACTURACLIENTNAME";
         cmbfacturaTipoPago_Internalname = "FACTURATIPOPAGO";
         dynsucursalId_Internalname = "SUCURSALID";
         lblTitleproducto_Internalname = "TITLEPRODUCTO";
         edtproductoId_Internalname = "PRODUCTOID";
         edtproductoName_Internalname = "PRODUCTONAME";
         edtproductoCount_Internalname = "PRODUCTOCOUNT";
         edtproductoStock_Internalname = "PRODUCTOSTOCK";
         divProductotable_Internalname = "PRODUCTOTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_5_Internalname = "PROMPT_5";
         subGridfactura_producto_Internalname = "GRIDFACTURA_PRODUCTO";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("xd2", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridfactura_producto_Allowcollapsing = 0;
         subGridfactura_producto_Allowselection = 0;
         subGridfactura_producto_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "factura";
         edtproductoStock_Jsonclick = "";
         edtproductoCount_Jsonclick = "";
         edtproductoName_Jsonclick = "";
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         imgprompt_5_Visible = 1;
         edtproductoId_Jsonclick = "";
         subGridfactura_producto_Class = "Grid";
         subGridfactura_producto_Backcolorstyle = 0;
         edtproductoStock_Enabled = 0;
         edtproductoCount_Enabled = 1;
         edtproductoName_Enabled = 0;
         edtproductoId_Enabled = 1;
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         dynsucursalId_Jsonclick = "";
         dynsucursalId.Enabled = 1;
         cmbfacturaTipoPago_Jsonclick = "";
         cmbfacturaTipoPago.Enabled = 1;
         edtfacturaClientName_Jsonclick = "";
         edtfacturaClientName_Enabled = 1;
         edtfacturaDate_Jsonclick = "";
         edtfacturaDate_Enabled = 1;
         edtfacturaId_Jsonclick = "";
         edtfacturaId_Enabled = 0;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLASUCURSALID041( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLASUCURSALID_data041( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXASUCURSALID_html041( )
      {
         short gxdynajaxvalue;
         GXDLASUCURSALID_data041( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynsucursalId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynsucursalId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLASUCURSALID_data041( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000438 */
         pr_default.execute(32);
         while ( (pr_default.getStatus(32) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000438_A2sucursalId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(T000438_A13sucursalName[0]);
            pr_default.readNext(32);
         }
         pr_default.close(32);
      }

      protected void gxnrGridfactura_producto_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_636( ) ;
         while ( nGXsfl_63_idx <= nRC_GXsfl_63 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal046( ) ;
            standaloneModal046( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow046( ) ;
            nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
            sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
            SubsflControlProps_636( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridfactura_productoContainer)) ;
         /* End function gxnrGridfactura_producto_newrow */
      }

      protected void init_web_controls( )
      {
         cmbfacturaTipoPago.Name = "FACTURATIPOPAGO";
         cmbfacturaTipoPago.WebTags = "";
         cmbfacturaTipoPago.addItem("C", "Contado", 0);
         cmbfacturaTipoPago.addItem("T", "Tarjeta", 0);
         if ( cmbfacturaTipoPago.ItemCount > 0 )
         {
            A33facturaTipoPago = cmbfacturaTipoPago.getValidValue(A33facturaTipoPago);
            AssignAttri("", false, "A33facturaTipoPago", A33facturaTipoPago);
         }
         dynsucursalId.Name = "SUCURSALID";
         dynsucursalId.WebTags = "";
         dynsucursalId.removeAllItems();
         /* Using cursor T000439 */
         pr_default.execute(33);
         while ( (pr_default.getStatus(33) != 101) )
         {
            dynsucursalId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000439_A2sucursalId[0]), 4, 0)), T000439_A13sucursalName[0], 0);
            pr_default.readNext(33);
         }
         pr_default.close(33);
         if ( dynsucursalId.ItemCount > 0 )
         {
            A2sucursalId = (short)(Math.Round(NumberUtil.Val( dynsucursalId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2sucursalId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A2sucursalId", StringUtil.LTrimStr( (decimal)(A2sucursalId), 4, 0));
         }
         /* End function init_web_controls */
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

      public void Valid_Facturaid( )
      {
         A2sucursalId = (short)(Math.Round(NumberUtil.Val( dynsucursalId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n40000GXC1 = false;
         /* Using cursor T000424 */
         pr_default.execute(18, new Object[] {A8facturaId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            A40000GXC1 = T000424_A40000GXC1[0];
            n40000GXC1 = T000424_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A40000GXC1", StringUtil.LTrim( StringUtil.NToC( (decimal)(A40000GXC1), 9, 0, ".", "")));
      }

      public void Valid_Sucursalid( )
      {
         A2sucursalId = (short)(Math.Round(NumberUtil.Val( dynsucursalId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000425 */
         pr_default.execute(19, new Object[] {A2sucursalId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'sucursal'.", "ForeignKeyNotFound", 1, "SUCURSALID");
            AnyError = 1;
            GX_FocusControl = dynsucursalId_Internalname;
         }
         A13sucursalName = T000425_A13sucursalName[0];
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A13sucursalName", A13sucursalName);
      }

      public void Valid_Productoid( )
      {
         A2sucursalId = (short)(Math.Round(NumberUtil.Val( dynsucursalId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000434 */
         pr_default.execute(28, new Object[] {A5productoId});
         if ( (pr_default.getStatus(28) == 101) )
         {
            GX_msglist.addItem("No existe 'producto'.", "ForeignKeyNotFound", 1, "PRODUCTOID");
            AnyError = 1;
            GX_FocusControl = edtproductoId_Internalname;
         }
         A25productoName = T000434_A25productoName[0];
         pr_default.close(28);
         /* Using cursor T000435 */
         pr_default.execute(29, new Object[] {A2sucursalId, A5productoId});
         if ( (pr_default.getStatus(29) == 101) )
         {
            GX_msglist.addItem("No existe 'producto'.", "ForeignKeyNotFound", 1, "PRODUCTOID");
            AnyError = 1;
            GX_FocusControl = edtproductoId_Internalname;
         }
         A30productoStock = T000435_A30productoStock[0];
         O30productoStock = A30productoStock;
         pr_default.close(29);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "O30productoStock", StringUtil.LTrim( StringUtil.NToC( (decimal)(O30productoStock), 10, 0, ",", "")));
         AssignAttri("", false, "A25productoName", A25productoName);
         AssignAttri("", false, "A30productoStock", StringUtil.LTrim( StringUtil.NToC( (decimal)(A30productoStock), 10, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7facturaId',fld:'vFACTURAID',pic:'ZZZ9',hsh:true},{av:'dynsucursalId'},{av:'A2sucursalId',fld:'SUCURSALID',pic:'ZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'dynsucursalId'},{av:'A2sucursalId',fld:'SUCURSALID',pic:'ZZZ9'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7facturaId',fld:'vFACTURAID',pic:'ZZZ9',hsh:true},{av:'A8facturaId',fld:'FACTURAID',pic:'ZZZ9'},{av:'dynsucursalId'},{av:'A2sucursalId',fld:'SUCURSALID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynsucursalId'},{av:'A2sucursalId',fld:'SUCURSALID',pic:'ZZZ9'}]}");
         setEventMetadata("AFTER TRN","{handler:'E12042',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'dynsucursalId'},{av:'A2sucursalId',fld:'SUCURSALID',pic:'ZZZ9'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'dynsucursalId'},{av:'A2sucursalId',fld:'SUCURSALID',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_FACTURAID","{handler:'Valid_Facturaid',iparms:[{av:'A8facturaId',fld:'FACTURAID',pic:'ZZZ9'},{av:'A40000GXC1',fld:'GXC1',pic:'999999999'},{av:'dynsucursalId'},{av:'A2sucursalId',fld:'SUCURSALID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_FACTURAID",",oparms:[{av:'A40000GXC1',fld:'GXC1',pic:'999999999'},{av:'dynsucursalId'},{av:'A2sucursalId',fld:'SUCURSALID',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_FACTURADATE","{handler:'Valid_Facturadate',iparms:[{av:'dynsucursalId'},{av:'A2sucursalId',fld:'SUCURSALID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_FACTURADATE",",oparms:[{av:'dynsucursalId'},{av:'A2sucursalId',fld:'SUCURSALID',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_FACTURATIPOPAGO","{handler:'Valid_Facturatipopago',iparms:[{av:'dynsucursalId'},{av:'A2sucursalId',fld:'SUCURSALID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_FACTURATIPOPAGO",",oparms:[{av:'dynsucursalId'},{av:'A2sucursalId',fld:'SUCURSALID',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_SUCURSALID","{handler:'Valid_Sucursalid',iparms:[{av:'A13sucursalName',fld:'SUCURSALNAME',pic:''},{av:'dynsucursalId'},{av:'A2sucursalId',fld:'SUCURSALID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_SUCURSALID",",oparms:[{av:'A13sucursalName',fld:'SUCURSALNAME',pic:''},{av:'dynsucursalId'},{av:'A2sucursalId',fld:'SUCURSALID',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_PRODUCTOID","{handler:'Valid_Productoid',iparms:[{av:'A5productoId',fld:'PRODUCTOID',pic:'ZZZ9'},{av:'A25productoName',fld:'PRODUCTONAME',pic:''},{av:'A30productoStock',fld:'PRODUCTOSTOCK',pic:'ZZZZZZZZZ9'},{av:'dynsucursalId'},{av:'A2sucursalId',fld:'SUCURSALID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_PRODUCTOID",",oparms:[{av:'O30productoStock'},{av:'A25productoName',fld:'PRODUCTONAME',pic:''},{av:'A30productoStock',fld:'PRODUCTOSTOCK',pic:'ZZZZZZZZZ9'},{av:'dynsucursalId'},{av:'A2sucursalId',fld:'SUCURSALID',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_PRODUCTOCOUNT","{handler:'Valid_Productocount',iparms:[{av:'dynsucursalId'},{av:'A2sucursalId',fld:'SUCURSALID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_PRODUCTOCOUNT",",oparms:[{av:'dynsucursalId'},{av:'A2sucursalId',fld:'SUCURSALID',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_PRODUCTOSTOCK","{handler:'Valid_Productostock',iparms:[{av:'dynsucursalId'},{av:'A2sucursalId',fld:'SUCURSALID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_PRODUCTOSTOCK",",oparms:[{av:'dynsucursalId'},{av:'A2sucursalId',fld:'SUCURSALID',pic:'ZZZ9'}]}");
         return  ;
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
         pr_default.close(28);
         pr_default.close(29);
         pr_default.close(7);
         pr_default.close(19);
         pr_default.close(18);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z31facturaDate = DateTime.MinValue;
         Z32facturaClientName = "";
         Z33facturaTipoPago = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A33facturaTipoPago = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A31facturaDate = DateTime.MinValue;
         A32facturaClientName = "";
         lblTitleproducto_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridfactura_productoContainer = new GXWebGrid( context);
         sMode6 = "";
         sStyleString = "";
         Gx_date = DateTime.MinValue;
         A13sucursalName = "";
         AV14Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode5 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A25productoName = "";
         T00048_A40000GXC1 = new int[1] ;
         T00048_n40000GXC1 = new bool[] {false} ;
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z13sucursalName = "";
         T000411_A13sucursalName = new string[] {""} ;
         T000413_A8facturaId = new short[1] ;
         T000413_A31facturaDate = new DateTime[] {DateTime.MinValue} ;
         T000413_A32facturaClientName = new string[] {""} ;
         T000413_A33facturaTipoPago = new string[] {""} ;
         T000413_A13sucursalName = new string[] {""} ;
         T000413_A2sucursalId = new short[1] ;
         T000413_A40000GXC1 = new int[1] ;
         T000413_n40000GXC1 = new bool[] {false} ;
         T000415_A40000GXC1 = new int[1] ;
         T000415_n40000GXC1 = new bool[] {false} ;
         T000416_A13sucursalName = new string[] {""} ;
         T000417_A8facturaId = new short[1] ;
         T000410_A8facturaId = new short[1] ;
         T000410_A31facturaDate = new DateTime[] {DateTime.MinValue} ;
         T000410_A32facturaClientName = new string[] {""} ;
         T000410_A33facturaTipoPago = new string[] {""} ;
         T000410_A2sucursalId = new short[1] ;
         T000418_A8facturaId = new short[1] ;
         T000419_A8facturaId = new short[1] ;
         T00049_A8facturaId = new short[1] ;
         T00049_A31facturaDate = new DateTime[] {DateTime.MinValue} ;
         T00049_A32facturaClientName = new string[] {""} ;
         T00049_A33facturaTipoPago = new string[] {""} ;
         T00049_A2sucursalId = new short[1] ;
         T000420_A8facturaId = new short[1] ;
         T000424_A40000GXC1 = new int[1] ;
         T000424_n40000GXC1 = new bool[] {false} ;
         T000425_A13sucursalName = new string[] {""} ;
         T000426_A8facturaId = new short[1] ;
         Z25productoName = "";
         T000427_A2sucursalId = new short[1] ;
         T000427_A8facturaId = new short[1] ;
         T000427_A30productoStock = new long[1] ;
         T000427_A25productoName = new string[] {""} ;
         T000427_A34productoCount = new short[1] ;
         T000427_A5productoId = new short[1] ;
         T00044_A25productoName = new string[] {""} ;
         T00046_A30productoStock = new long[1] ;
         T000428_A25productoName = new string[] {""} ;
         T000429_A8facturaId = new short[1] ;
         T000429_A5productoId = new short[1] ;
         T00043_A8facturaId = new short[1] ;
         T00043_A34productoCount = new short[1] ;
         T00043_A5productoId = new short[1] ;
         T00042_A8facturaId = new short[1] ;
         T00042_A34productoCount = new short[1] ;
         T00042_A5productoId = new short[1] ;
         T000430_A30productoStock = new long[1] ;
         T000434_A25productoName = new string[] {""} ;
         T000435_A30productoStock = new long[1] ;
         T000437_A8facturaId = new short[1] ;
         T000437_A5productoId = new short[1] ;
         Gridfactura_productoRow = new GXWebRow();
         subGridfactura_producto_Linesclass = "";
         ROClassString = "";
         imgprompt_5_gximage = "";
         sImgUrl = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridfactura_productoColumn = new GXWebColumn();
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000438_A2sucursalId = new short[1] ;
         T000438_A13sucursalName = new string[] {""} ;
         T000439_A2sucursalId = new short[1] ;
         T000439_A13sucursalName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.factura__default(),
            new Object[][] {
                new Object[] {
               T00042_A8facturaId, T00042_A34productoCount, T00042_A5productoId
               }
               , new Object[] {
               T00043_A8facturaId, T00043_A34productoCount, T00043_A5productoId
               }
               , new Object[] {
               T00044_A25productoName
               }
               , new Object[] {
               T00045_A30productoStock
               }
               , new Object[] {
               T00046_A30productoStock
               }
               , new Object[] {
               T00048_A40000GXC1, T00048_n40000GXC1
               }
               , new Object[] {
               T00049_A8facturaId, T00049_A31facturaDate, T00049_A32facturaClientName, T00049_A33facturaTipoPago, T00049_A2sucursalId
               }
               , new Object[] {
               T000410_A8facturaId, T000410_A31facturaDate, T000410_A32facturaClientName, T000410_A33facturaTipoPago, T000410_A2sucursalId
               }
               , new Object[] {
               T000411_A13sucursalName
               }
               , new Object[] {
               T000413_A8facturaId, T000413_A31facturaDate, T000413_A32facturaClientName, T000413_A33facturaTipoPago, T000413_A13sucursalName, T000413_A2sucursalId, T000413_A40000GXC1, T000413_n40000GXC1
               }
               , new Object[] {
               T000415_A40000GXC1, T000415_n40000GXC1
               }
               , new Object[] {
               T000416_A13sucursalName
               }
               , new Object[] {
               T000417_A8facturaId
               }
               , new Object[] {
               T000418_A8facturaId
               }
               , new Object[] {
               T000419_A8facturaId
               }
               , new Object[] {
               T000420_A8facturaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000424_A40000GXC1, T000424_n40000GXC1
               }
               , new Object[] {
               T000425_A13sucursalName
               }
               , new Object[] {
               T000426_A8facturaId
               }
               , new Object[] {
               T000427_A2sucursalId, T000427_A8facturaId, T000427_A30productoStock, T000427_A25productoName, T000427_A34productoCount, T000427_A5productoId
               }
               , new Object[] {
               T000428_A25productoName
               }
               , new Object[] {
               T000429_A8facturaId, T000429_A5productoId
               }
               , new Object[] {
               T000430_A30productoStock
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000434_A25productoName
               }
               , new Object[] {
               T000435_A30productoStock
               }
               , new Object[] {
               }
               , new Object[] {
               T000437_A8facturaId, T000437_A5productoId
               }
               , new Object[] {
               T000438_A2sucursalId, T000438_A13sucursalName
               }
               , new Object[] {
               T000439_A2sucursalId, T000439_A13sucursalName
               }
            }
         );
         AV14Pgmname = "factura";
         Gx_date = DateTimeUtil.Today( context);
      }

      private short nIsMod_6 ;
      private short wcpOAV7facturaId ;
      private short Z8facturaId ;
      private short Z2sucursalId ;
      private short N2sucursalId ;
      private short Z5productoId ;
      private short Z34productoCount ;
      private short O34productoCount ;
      private short nRcdDeleted_6 ;
      private short nRcdExists_6 ;
      private short GxWebError ;
      private short A8facturaId ;
      private short A2sucursalId ;
      private short A5productoId ;
      private short AV7facturaId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nBlankRcdCount6 ;
      private short RcdFound6 ;
      private short nBlankRcdUsr6 ;
      private short AV11Insert_sucursalId ;
      private short RcdFound5 ;
      private short A34productoCount ;
      private short T34productoCount ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_5 ;
      private short nIsDirty_6 ;
      private short subGridfactura_producto_Backcolorstyle ;
      private short subGridfactura_producto_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridfactura_producto_Allowselection ;
      private short subGridfactura_producto_Allowhovering ;
      private short subGridfactura_producto_Allowcollapsing ;
      private short subGridfactura_producto_Collapsed ;
      private int nRC_GXsfl_63 ;
      private int nGXsfl_63_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtfacturaId_Enabled ;
      private int edtfacturaDate_Enabled ;
      private int edtfacturaClientName_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtproductoId_Enabled ;
      private int edtproductoName_Enabled ;
      private int edtproductoCount_Enabled ;
      private int edtproductoStock_Enabled ;
      private int fRowAdded ;
      private int A40000GXC1 ;
      private int AV15GXV1 ;
      private int Z40000GXC1 ;
      private int subGridfactura_producto_Backcolor ;
      private int subGridfactura_producto_Allbackcolor ;
      private int imgprompt_5_Visible ;
      private int defedtproductoStock_Enabled ;
      private int defedtproductoId_Enabled ;
      private int idxLst ;
      private int subGridfactura_producto_Selectedindex ;
      private int subGridfactura_producto_Selectioncolor ;
      private int subGridfactura_producto_Hoveringcolor ;
      private int gxdynajaxindex ;
      private long O30productoStock ;
      private long GRIDFACTURA_PRODUCTO_nFirstRecordOnPage ;
      private long A30productoStock ;
      private long T30productoStock ;
      private long Z30productoStock ;
      private long ZO30productoStock ;
      private string sPrefix ;
      private string sGXsfl_63_idx="0001" ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtfacturaDate_Internalname ;
      private string cmbfacturaTipoPago_Internalname ;
      private string dynsucursalId_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtfacturaId_Internalname ;
      private string edtfacturaId_Jsonclick ;
      private string edtfacturaDate_Jsonclick ;
      private string edtfacturaClientName_Internalname ;
      private string edtfacturaClientName_Jsonclick ;
      private string cmbfacturaTipoPago_Jsonclick ;
      private string dynsucursalId_Jsonclick ;
      private string divProductotable_Internalname ;
      private string lblTitleproducto_Internalname ;
      private string lblTitleproducto_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode6 ;
      private string edtproductoId_Internalname ;
      private string edtproductoName_Internalname ;
      private string edtproductoCount_Internalname ;
      private string edtproductoStock_Internalname ;
      private string imgprompt_5_Link ;
      private string sStyleString ;
      private string subGridfactura_producto_Internalname ;
      private string AV14Pgmname ;
      private string hsh ;
      private string sMode5 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string imgprompt_5_Internalname ;
      private string sGXsfl_63_fel_idx="0001" ;
      private string subGridfactura_producto_Class ;
      private string subGridfactura_producto_Linesclass ;
      private string ROClassString ;
      private string edtproductoId_Jsonclick ;
      private string imgprompt_5_gximage ;
      private string sImgUrl ;
      private string edtproductoName_Jsonclick ;
      private string edtproductoCount_Jsonclick ;
      private string edtproductoStock_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridfactura_producto_Header ;
      private string gxwrpcisep ;
      private DateTime Z31facturaDate ;
      private DateTime A31facturaDate ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_63_Refreshing=false ;
      private bool n40000GXC1 ;
      private bool returnInSub ;
      private bool gxdyncontrolsrefreshing ;
      private string Z32facturaClientName ;
      private string Z33facturaTipoPago ;
      private string A33facturaTipoPago ;
      private string A32facturaClientName ;
      private string A13sucursalName ;
      private string A25productoName ;
      private string Z13sucursalName ;
      private string Z25productoName ;
      private IGxSession AV10WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridfactura_productoContainer ;
      private GXWebRow Gridfactura_productoRow ;
      private GXWebColumn Gridfactura_productoColumn ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbfacturaTipoPago ;
      private GXCombobox dynsucursalId ;
      private IDataStoreProvider pr_default ;
      private int[] T00048_A40000GXC1 ;
      private bool[] T00048_n40000GXC1 ;
      private string[] T000411_A13sucursalName ;
      private short[] T000413_A8facturaId ;
      private DateTime[] T000413_A31facturaDate ;
      private string[] T000413_A32facturaClientName ;
      private string[] T000413_A33facturaTipoPago ;
      private string[] T000413_A13sucursalName ;
      private short[] T000413_A2sucursalId ;
      private int[] T000413_A40000GXC1 ;
      private bool[] T000413_n40000GXC1 ;
      private int[] T000415_A40000GXC1 ;
      private bool[] T000415_n40000GXC1 ;
      private string[] T000416_A13sucursalName ;
      private short[] T000417_A8facturaId ;
      private short[] T000410_A8facturaId ;
      private DateTime[] T000410_A31facturaDate ;
      private string[] T000410_A32facturaClientName ;
      private string[] T000410_A33facturaTipoPago ;
      private short[] T000410_A2sucursalId ;
      private short[] T000418_A8facturaId ;
      private short[] T000419_A8facturaId ;
      private short[] T00049_A8facturaId ;
      private DateTime[] T00049_A31facturaDate ;
      private string[] T00049_A32facturaClientName ;
      private string[] T00049_A33facturaTipoPago ;
      private short[] T00049_A2sucursalId ;
      private short[] T000420_A8facturaId ;
      private int[] T000424_A40000GXC1 ;
      private bool[] T000424_n40000GXC1 ;
      private string[] T000425_A13sucursalName ;
      private short[] T000426_A8facturaId ;
      private short[] T000427_A2sucursalId ;
      private short[] T000427_A8facturaId ;
      private long[] T000427_A30productoStock ;
      private string[] T000427_A25productoName ;
      private short[] T000427_A34productoCount ;
      private short[] T000427_A5productoId ;
      private string[] T00044_A25productoName ;
      private long[] T00046_A30productoStock ;
      private string[] T000428_A25productoName ;
      private short[] T000429_A8facturaId ;
      private short[] T000429_A5productoId ;
      private short[] T00043_A8facturaId ;
      private short[] T00043_A34productoCount ;
      private short[] T00043_A5productoId ;
      private short[] T00042_A8facturaId ;
      private short[] T00042_A34productoCount ;
      private short[] T00042_A5productoId ;
      private long[] T000430_A30productoStock ;
      private string[] T000434_A25productoName ;
      private long[] T000435_A30productoStock ;
      private short[] T000437_A8facturaId ;
      private short[] T000437_A5productoId ;
      private short[] T000438_A2sucursalId ;
      private string[] T000438_A13sucursalName ;
      private short[] T000439_A2sucursalId ;
      private string[] T000439_A13sucursalName ;
      private long[] T00045_A30productoStock ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV12TrnContextAtt ;
   }

   public class factura__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new UpdateCursor(def[25])
         ,new UpdateCursor(def[26])
         ,new UpdateCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new UpdateCursor(def[30])
         ,new ForEachCursor(def[31])
         ,new ForEachCursor(def[32])
         ,new ForEachCursor(def[33])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00045;
          prmT00045 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT000413;
          prmT000413 = new Object[] {
          new ParDef("@facturaId",GXType.Int16,4,0)
          };
          Object[] prmT00048;
          prmT00048 = new Object[] {
          new ParDef("@facturaId",GXType.Int16,4,0)
          };
          Object[] prmT000411;
          prmT000411 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0)
          };
          Object[] prmT000415;
          prmT000415 = new Object[] {
          new ParDef("@facturaId",GXType.Int16,4,0)
          };
          Object[] prmT000416;
          prmT000416 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0)
          };
          Object[] prmT000417;
          prmT000417 = new Object[] {
          new ParDef("@facturaId",GXType.Int16,4,0)
          };
          Object[] prmT000410;
          prmT000410 = new Object[] {
          new ParDef("@facturaId",GXType.Int16,4,0)
          };
          Object[] prmT000418;
          prmT000418 = new Object[] {
          new ParDef("@facturaId",GXType.Int16,4,0)
          };
          Object[] prmT000419;
          prmT000419 = new Object[] {
          new ParDef("@facturaId",GXType.Int16,4,0)
          };
          Object[] prmT00049;
          prmT00049 = new Object[] {
          new ParDef("@facturaId",GXType.Int16,4,0)
          };
          Object[] prmT000420;
          prmT000420 = new Object[] {
          new ParDef("@facturaDate",GXType.Date,8,0) ,
          new ParDef("@facturaClientName",GXType.NVarChar,40,0) ,
          new ParDef("@facturaTipoPago",GXType.NVarChar,40,0) ,
          new ParDef("@sucursalId",GXType.Int16,4,0)
          };
          Object[] prmT000421;
          prmT000421 = new Object[] {
          new ParDef("@facturaDate",GXType.Date,8,0) ,
          new ParDef("@facturaClientName",GXType.NVarChar,40,0) ,
          new ParDef("@facturaTipoPago",GXType.NVarChar,40,0) ,
          new ParDef("@sucursalId",GXType.Int16,4,0) ,
          new ParDef("@facturaId",GXType.Int16,4,0)
          };
          Object[] prmT000422;
          prmT000422 = new Object[] {
          new ParDef("@facturaId",GXType.Int16,4,0)
          };
          Object[] prmT000426;
          prmT000426 = new Object[] {
          };
          Object[] prmT000427;
          prmT000427 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0) ,
          new ParDef("@facturaId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT00044;
          prmT00044 = new Object[] {
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT000428;
          prmT000428 = new Object[] {
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT00046;
          prmT00046 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT000429;
          prmT000429 = new Object[] {
          new ParDef("@facturaId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT00043;
          prmT00043 = new Object[] {
          new ParDef("@facturaId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT00042;
          prmT00042 = new Object[] {
          new ParDef("@facturaId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT000430;
          prmT000430 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT000431;
          prmT000431 = new Object[] {
          new ParDef("@facturaId",GXType.Int16,4,0) ,
          new ParDef("@productoCount",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT000432;
          prmT000432 = new Object[] {
          new ParDef("@productoCount",GXType.Int16,4,0) ,
          new ParDef("@facturaId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT000433;
          prmT000433 = new Object[] {
          new ParDef("@facturaId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT000436;
          prmT000436 = new Object[] {
          new ParDef("@productoStock",GXType.Decimal,10,0) ,
          new ParDef("@sucursalId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT000437;
          prmT000437 = new Object[] {
          new ParDef("@facturaId",GXType.Int16,4,0)
          };
          Object[] prmT000438;
          prmT000438 = new Object[] {
          };
          Object[] prmT000439;
          prmT000439 = new Object[] {
          };
          Object[] prmT000424;
          prmT000424 = new Object[] {
          new ParDef("@facturaId",GXType.Int16,4,0)
          };
          Object[] prmT000425;
          prmT000425 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0)
          };
          Object[] prmT000434;
          prmT000434 = new Object[] {
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT000435;
          prmT000435 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00042", "SELECT [facturaId], [productoCount], [productoId] FROM [facturaproducto] WITH (UPDLOCK) WHERE [facturaId] = @facturaId AND [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00042,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00043", "SELECT [facturaId], [productoCount], [productoId] FROM [facturaproducto] WHERE [facturaId] = @facturaId AND [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00043,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00044", "SELECT [productoName] FROM [producto] WHERE [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00044,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00045", "SELECT [productoStock] FROM [sucursalproducto] WITH (UPDLOCK) WHERE [sucursalId] = @sucursalId AND [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00045,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00046", "SELECT [productoStock] FROM [sucursalproducto] WHERE [sucursalId] = @sucursalId AND [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00046,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00048", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1, [facturaId] FROM [facturaproducto] WITH (UPDLOCK) GROUP BY [facturaId] ) T1 WHERE T1.[facturaId] = @facturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00048,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00049", "SELECT [facturaId], [facturaDate], [facturaClientName], [facturaTipoPago], [sucursalId] FROM [factura] WITH (UPDLOCK) WHERE [facturaId] = @facturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00049,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000410", "SELECT [facturaId], [facturaDate], [facturaClientName], [facturaTipoPago], [sucursalId] FROM [factura] WHERE [facturaId] = @facturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000410,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000411", "SELECT [sucursalName] FROM [sucursal] WHERE [sucursalId] = @sucursalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000411,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000413", "SELECT TM1.[facturaId], TM1.[facturaDate], TM1.[facturaClientName], TM1.[facturaTipoPago], T3.[sucursalName], TM1.[sucursalId], COALESCE( T2.[GXC1], 0) AS GXC1 FROM (([factura] TM1 LEFT JOIN (SELECT COUNT(*) AS GXC1, [facturaId] FROM [facturaproducto] GROUP BY [facturaId] ) T2 ON T2.[facturaId] = TM1.[facturaId]) INNER JOIN [sucursal] T3 ON T3.[sucursalId] = TM1.[sucursalId]) WHERE TM1.[facturaId] = @facturaId ORDER BY TM1.[facturaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000413,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000415", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1, [facturaId] FROM [facturaproducto] WITH (UPDLOCK) GROUP BY [facturaId] ) T1 WHERE T1.[facturaId] = @facturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000415,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000416", "SELECT [sucursalName] FROM [sucursal] WHERE [sucursalId] = @sucursalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000416,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000417", "SELECT [facturaId] FROM [factura] WHERE [facturaId] = @facturaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000417,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000418", "SELECT TOP 1 [facturaId] FROM [factura] WHERE ( [facturaId] > @facturaId) ORDER BY [facturaId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000418,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000419", "SELECT TOP 1 [facturaId] FROM [factura] WHERE ( [facturaId] < @facturaId) ORDER BY [facturaId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000419,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000420", "INSERT INTO [factura]([facturaDate], [facturaClientName], [facturaTipoPago], [sucursalId]) VALUES(@facturaDate, @facturaClientName, @facturaTipoPago, @sucursalId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000420,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000421", "UPDATE [factura] SET [facturaDate]=@facturaDate, [facturaClientName]=@facturaClientName, [facturaTipoPago]=@facturaTipoPago, [sucursalId]=@sucursalId  WHERE [facturaId] = @facturaId", GxErrorMask.GX_NOMASK,prmT000421)
             ,new CursorDef("T000422", "DELETE FROM [factura]  WHERE [facturaId] = @facturaId", GxErrorMask.GX_NOMASK,prmT000422)
             ,new CursorDef("T000424", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1, [facturaId] FROM [facturaproducto] WITH (UPDLOCK) GROUP BY [facturaId] ) T1 WHERE T1.[facturaId] = @facturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000424,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000425", "SELECT [sucursalName] FROM [sucursal] WHERE [sucursalId] = @sucursalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000425,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000426", "SELECT [facturaId] FROM [factura] ORDER BY [facturaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000426,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000427", "SELECT T3.[sucursalId], T1.[facturaId], T3.[productoStock], T2.[productoName], T1.[productoCount], T1.[productoId] FROM (([facturaproducto] T1 INNER JOIN [producto] T2 ON T2.[productoId] = T1.[productoId]) LEFT JOIN [sucursalproducto] T3 ON T3.[sucursalId] = @sucursalId AND T3.[productoId] = T1.[productoId]) WHERE T1.[facturaId] = @facturaId and T1.[productoId] = @productoId ORDER BY T1.[facturaId], T1.[productoId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000427,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000428", "SELECT [productoName] FROM [producto] WHERE [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000428,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000429", "SELECT [facturaId], [productoId] FROM [facturaproducto] WHERE [facturaId] = @facturaId AND [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000429,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000430", "SELECT [productoStock] FROM [sucursalproducto] WITH (UPDLOCK) WHERE [sucursalId] = @sucursalId AND [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000430,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000431", "INSERT INTO [facturaproducto]([facturaId], [productoCount], [productoId]) VALUES(@facturaId, @productoCount, @productoId)", GxErrorMask.GX_NOMASK,prmT000431)
             ,new CursorDef("T000432", "UPDATE [facturaproducto] SET [productoCount]=@productoCount  WHERE [facturaId] = @facturaId AND [productoId] = @productoId", GxErrorMask.GX_NOMASK,prmT000432)
             ,new CursorDef("T000433", "DELETE FROM [facturaproducto]  WHERE [facturaId] = @facturaId AND [productoId] = @productoId", GxErrorMask.GX_NOMASK,prmT000433)
             ,new CursorDef("T000434", "SELECT [productoName] FROM [producto] WHERE [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000434,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000435", "SELECT [productoStock] FROM [sucursalproducto] WHERE [sucursalId] = @sucursalId AND [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000435,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000436", "UPDATE [sucursalproducto] SET [productoStock]=@productoStock  WHERE [sucursalId] = @sucursalId AND [productoId] = @productoId", GxErrorMask.GX_NOMASK,prmT000436)
             ,new CursorDef("T000437", "SELECT [facturaId], [productoId] FROM [facturaproducto] WHERE [facturaId] = @facturaId ORDER BY [facturaId], [productoId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000437,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000438", "SELECT [sucursalId], [sucursalName] FROM [sucursal] ORDER BY [sucursalName] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000438,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000439", "SELECT [sucursalId], [sucursalName] FROM [sucursal] ORDER BY [sucursalName] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000439,0, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 20 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 21 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 22 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 24 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 28 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 29 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 31 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 32 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 33 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
