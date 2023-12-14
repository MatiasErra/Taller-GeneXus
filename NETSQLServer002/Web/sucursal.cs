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
   public class sucursal : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"SUCURSALEMPLEADOHEADLINEID") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLASUCURSALEMPLEADOHEADLINEID022( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"SUCURSALEMPLEADOALTERNATEID") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLASUCURSALEMPLEADOALTERNATEID022( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A3sucursalEmpleadoHeadlineId = (short)(Math.Round(NumberUtil.Val( GetPar( "sucursalEmpleadoHeadlineId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A3sucursalEmpleadoHeadlineId", StringUtil.LTrimStr( (decimal)(A3sucursalEmpleadoHeadlineId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A3sucursalEmpleadoHeadlineId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_22") == 0 )
         {
            A4sucursalEmpleadoAlternateId = (short)(Math.Round(NumberUtil.Val( GetPar( "sucursalEmpleadoAlternateId"), "."), 18, MidpointRounding.ToEven));
            n4sucursalEmpleadoAlternateId = false;
            AssignAttri("", false, "A4sucursalEmpleadoAlternateId", StringUtil.LTrimStr( (decimal)(A4sucursalEmpleadoAlternateId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_22( A4sucursalEmpleadoAlternateId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_24") == 0 )
         {
            A5productoId = (short)(Math.Round(NumberUtil.Val( GetPar( "productoId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_24( A5productoId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridsucursal_producto") == 0 )
         {
            gxnrGridsucursal_producto_newrow_invoke( ) ;
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
               AV7sucursalId = (short)(Math.Round(NumberUtil.Val( GetPar( "sucursalId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7sucursalId", StringUtil.LTrimStr( (decimal)(AV7sucursalId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vSUCURSALID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7sucursalId), "ZZZ9"), context));
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
            Form.Meta.addItem("description", "sucursal", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtsucursalName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("xd2", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridsucursal_producto_newrow_invoke( )
      {
         nRC_GXsfl_73 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_73"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_73_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_73_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_73_idx = GetPar( "sGXsfl_73_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridsucursal_producto_newrow( ) ;
         /* End function gxnrGridsucursal_producto_newrow_invoke */
      }

      public sucursal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("xd2", true);
      }

      public sucursal( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_sucursalId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7sucursalId = aP1_sucursalId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynsucursalEmpleadoHeadlineId = new GXCombobox();
         dynsucursalEmpleadoAlternateId = new GXCombobox();
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
         if ( dynsucursalEmpleadoHeadlineId.ItemCount > 0 )
         {
            A3sucursalEmpleadoHeadlineId = (short)(Math.Round(NumberUtil.Val( dynsucursalEmpleadoHeadlineId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A3sucursalEmpleadoHeadlineId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A3sucursalEmpleadoHeadlineId", StringUtil.LTrimStr( (decimal)(A3sucursalEmpleadoHeadlineId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynsucursalEmpleadoHeadlineId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A3sucursalEmpleadoHeadlineId), 4, 0));
            AssignProp("", false, dynsucursalEmpleadoHeadlineId_Internalname, "Values", dynsucursalEmpleadoHeadlineId.ToJavascriptSource(), true);
         }
         if ( dynsucursalEmpleadoAlternateId.ItemCount > 0 )
         {
            A4sucursalEmpleadoAlternateId = (short)(Math.Round(NumberUtil.Val( dynsucursalEmpleadoAlternateId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A4sucursalEmpleadoAlternateId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            n4sucursalEmpleadoAlternateId = false;
            AssignAttri("", false, "A4sucursalEmpleadoAlternateId", StringUtil.LTrimStr( (decimal)(A4sucursalEmpleadoAlternateId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynsucursalEmpleadoAlternateId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A4sucursalEmpleadoAlternateId), 4, 0));
            AssignProp("", false, dynsucursalEmpleadoAlternateId_Internalname, "Values", dynsucursalEmpleadoAlternateId.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Sucursal", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_sucursal.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_sucursal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_sucursal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_sucursal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_sucursal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_sucursal.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtsucursalId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsucursalId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtsucursalId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2sucursalId), 4, 0, ",", "")), StringUtil.LTrim( ((edtsucursalId_Enabled!=0) ? context.localUtil.Format( (decimal)(A2sucursalId), "ZZZ9") : context.localUtil.Format( (decimal)(A2sucursalId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsucursalId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsucursalId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_sucursal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtsucursalName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsucursalName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsucursalName_Internalname, A13sucursalName, StringUtil.RTrim( context.localUtil.Format( A13sucursalName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsucursalName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsucursalName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_sucursal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtsucursalAddress_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsucursalAddress_Internalname, "Address", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtsucursalAddress_Internalname, A14sucursalAddress, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A14sucursalAddress), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtsucursalAddress_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_sucursal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+Sucursalgeolocation_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, Sucursalgeolocation_Internalname, "Geolocation", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* User Defined Control */
         ucSucursalgeolocation.SetProperty("Attribute", sucursalGeolocation);
         ucSucursalgeolocation.SetProperty("CaptionClass", Sucursalgeolocation_Captionclass);
         ucSucursalgeolocation.SetProperty("CaptionStyle", Sucursalgeolocation_Captionstyle);
         ucSucursalgeolocation.SetProperty("CaptionPosition", Sucursalgeolocation_Captionposition);
         ucSucursalgeolocation.Render(context, "sdgeolocation", Sucursalgeolocation_Internalname, "SUCURSALGEOLOCATIONContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtsucursalAddedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsucursalAddedDate_Internalname, "Added Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtsucursalAddedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtsucursalAddedDate_Internalname, context.localUtil.Format(A18sucursalAddedDate, "99/99/99"), context.localUtil.Format( A18sucursalAddedDate, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsucursalAddedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsucursalAddedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_sucursal.htm");
         GxWebStd.gx_bitmap( context, edtsucursalAddedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtsucursalAddedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_sucursal.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynsucursalEmpleadoHeadlineId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynsucursalEmpleadoHeadlineId_Internalname, "Headline Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynsucursalEmpleadoHeadlineId, dynsucursalEmpleadoHeadlineId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A3sucursalEmpleadoHeadlineId), 4, 0)), 1, dynsucursalEmpleadoHeadlineId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynsucursalEmpleadoHeadlineId.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "", true, 0, "HLP_sucursal.htm");
         dynsucursalEmpleadoHeadlineId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A3sucursalEmpleadoHeadlineId), 4, 0));
         AssignProp("", false, dynsucursalEmpleadoHeadlineId_Internalname, "Values", (string)(dynsucursalEmpleadoHeadlineId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynsucursalEmpleadoAlternateId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynsucursalEmpleadoAlternateId_Internalname, "Alternate Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynsucursalEmpleadoAlternateId, dynsucursalEmpleadoAlternateId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A4sucursalEmpleadoAlternateId), 4, 0)), 1, dynsucursalEmpleadoAlternateId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynsucursalEmpleadoAlternateId.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "", true, 0, "HLP_sucursal.htm");
         dynsucursalEmpleadoAlternateId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A4sucursalEmpleadoAlternateId), 4, 0));
         AssignProp("", false, dynsucursalEmpleadoAlternateId_Internalname, "Values", (string)(dynsucursalEmpleadoAlternateId.ToJavascriptSource()), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitleproducto_Internalname, "Productos", "", "", lblTitleproducto_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_sucursal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridsucursal_producto( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_sucursal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_sucursal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_sucursal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Right", "Middle", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridsucursal_producto( )
      {
         /*  Grid Control  */
         StartGridControl73( ) ;
         nGXsfl_73_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount3 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_3 = 1;
               ScanStart023( ) ;
               while ( RcdFound3 != 0 )
               {
                  init_level_properties3( ) ;
                  getByPrimaryKey023( ) ;
                  AddRow023( ) ;
                  ScanNext023( ) ;
               }
               ScanEnd023( ) ;
               nBlankRcdCount3 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal023( ) ;
            standaloneModal023( ) ;
            sMode3 = Gx_mode;
            while ( nGXsfl_73_idx < nRC_GXsfl_73 )
            {
               bGXsfl_73_Refreshing = true;
               ReadRow023( ) ;
               edtproductoId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTOID_"+sGXsfl_73_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtproductoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoId_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtproductoName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTONAME_"+sGXsfl_73_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtproductoName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoName_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtproductoStock_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTOSTOCK_"+sGXsfl_73_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtproductoStock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoStock_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               imgprompt_5_Link = cgiGet( "PROMPT_5_"+sGXsfl_73_idx+"Link");
               if ( ( nRcdExists_3 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal023( ) ;
               }
               SendRow023( ) ;
               bGXsfl_73_Refreshing = false;
            }
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount3 = 5;
            nRcdExists_3 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart023( ) ;
               while ( RcdFound3 != 0 )
               {
                  sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_733( ) ;
                  init_level_properties3( ) ;
                  standaloneNotModal023( ) ;
                  getByPrimaryKey023( ) ;
                  standaloneModal023( ) ;
                  AddRow023( ) ;
                  ScanNext023( ) ;
               }
               ScanEnd023( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode3 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx+1), 4, 0), 4, "0");
            SubsflControlProps_733( ) ;
            InitAll023( ) ;
            init_level_properties3( ) ;
            nRcdExists_3 = 0;
            nIsMod_3 = 0;
            nRcdDeleted_3 = 0;
            nBlankRcdCount3 = (short)(nBlankRcdUsr3+nBlankRcdCount3);
            fRowAdded = 0;
            while ( nBlankRcdCount3 > 0 )
            {
               standaloneNotModal023( ) ;
               standaloneModal023( ) ;
               AddRow023( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtproductoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount3 = (short)(nBlankRcdCount3-1);
            }
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridsucursal_productoContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridsucursal_producto", Gridsucursal_productoContainer, subGridsucursal_producto_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridsucursal_productoContainerData", Gridsucursal_productoContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridsucursal_productoContainerData"+"V", Gridsucursal_productoContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridsucursal_productoContainerData"+"V"+"\" value='"+Gridsucursal_productoContainer.GridValuesHidden()+"'/>") ;
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
         E11022 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z2sucursalId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z2sucursalId"), ",", "."), 18, MidpointRounding.ToEven));
               Z13sucursalName = cgiGet( "Z13sucursalName");
               Z14sucursalAddress = cgiGet( "Z14sucursalAddress");
               Z17sucursalGeolocation = cgiGet( "Z17sucursalGeolocation");
               Z18sucursalAddedDate = context.localUtil.CToD( cgiGet( "Z18sucursalAddedDate"), 0);
               Z3sucursalEmpleadoHeadlineId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z3sucursalEmpleadoHeadlineId"), ",", "."), 18, MidpointRounding.ToEven));
               Z4sucursalEmpleadoAlternateId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z4sucursalEmpleadoAlternateId"), ",", "."), 18, MidpointRounding.ToEven));
               n4sucursalEmpleadoAlternateId = ((0==A4sucursalEmpleadoAlternateId) ? true : false);
               A17sucursalGeolocation = cgiGet( "Z17sucursalGeolocation");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_73 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_73"), ",", "."), 18, MidpointRounding.ToEven));
               N3sucursalEmpleadoHeadlineId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N3sucursalEmpleadoHeadlineId"), ",", "."), 18, MidpointRounding.ToEven));
               N4sucursalEmpleadoAlternateId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N4sucursalEmpleadoAlternateId"), ",", "."), 18, MidpointRounding.ToEven));
               n4sucursalEmpleadoAlternateId = ((0==A4sucursalEmpleadoAlternateId) ? true : false);
               A17sucursalGeolocation = cgiGet( "SUCURSALGEOLOCATION");
               AV7sucursalId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vSUCURSALID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_sucursalEmpleadoHeadlineId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SUCURSALEMPLEADOHEADLINEID"), ",", "."), 18, MidpointRounding.ToEven));
               AV12Insert_sucursalEmpleadoAlternateId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SUCURSALEMPLEADOALTERNATEID"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               A19sucursalEmpleadoHeadlineName = cgiGet( "SUCURSALEMPLEADOHEADLINENAME");
               A20sucursalEmpleadoAlternateName = cgiGet( "SUCURSALEMPLEADOALTERNATENAME");
               AV15Pgmname = cgiGet( "vPGMNAME");
               Sucursalgeolocation_Objectcall = cgiGet( "SUCURSALGEOLOCATION_Objectcall");
               Sucursalgeolocation_Class = cgiGet( "SUCURSALGEOLOCATION_Class");
               Sucursalgeolocation_Enabled = StringUtil.StrToBool( cgiGet( "SUCURSALGEOLOCATION_Enabled"));
               Sucursalgeolocation_Maptype = cgiGet( "SUCURSALGEOLOCATION_Maptype");
               Sucursalgeolocation_Mapzoom = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUCURSALGEOLOCATION_Mapzoom"), ",", "."), 18, MidpointRounding.ToEven));
               Sucursalgeolocation_Maxzoom = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUCURSALGEOLOCATION_Maxzoom"), ",", "."), 18, MidpointRounding.ToEven));
               Sucursalgeolocation_Minzoom = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUCURSALGEOLOCATION_Minzoom"), ",", "."), 18, MidpointRounding.ToEven));
               Sucursalgeolocation_Googleapikey = cgiGet( "SUCURSALGEOLOCATION_Googleapikey");
               Sucursalgeolocation_Captionvalue = cgiGet( "SUCURSALGEOLOCATION_Captionvalue");
               Sucursalgeolocation_Captionclass = cgiGet( "SUCURSALGEOLOCATION_Captionclass");
               Sucursalgeolocation_Captionstyle = cgiGet( "SUCURSALGEOLOCATION_Captionstyle");
               Sucursalgeolocation_Captionposition = cgiGet( "SUCURSALGEOLOCATION_Captionposition");
               Sucursalgeolocation_Isabstractlayoutcontrol = StringUtil.StrToBool( cgiGet( "SUCURSALGEOLOCATION_Isabstractlayoutcontrol"));
               Sucursalgeolocation_Coltitle = cgiGet( "SUCURSALGEOLOCATION_Coltitle");
               Sucursalgeolocation_Coltitlefont = cgiGet( "SUCURSALGEOLOCATION_Coltitlefont");
               Sucursalgeolocation_Coltitlecolor = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUCURSALGEOLOCATION_Coltitlecolor"), ",", "."), 18, MidpointRounding.ToEven));
               Sucursalgeolocation_Usercontroliscolumn = StringUtil.StrToBool( cgiGet( "SUCURSALGEOLOCATION_Usercontroliscolumn"));
               Sucursalgeolocation_Visible = StringUtil.StrToBool( cgiGet( "SUCURSALGEOLOCATION_Visible"));
               /* Read variables values. */
               A2sucursalId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtsucursalId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A2sucursalId", StringUtil.LTrimStr( (decimal)(A2sucursalId), 4, 0));
               A13sucursalName = cgiGet( edtsucursalName_Internalname);
               AssignAttri("", false, "A13sucursalName", A13sucursalName);
               A14sucursalAddress = cgiGet( edtsucursalAddress_Internalname);
               AssignAttri("", false, "A14sucursalAddress", A14sucursalAddress);
               A18sucursalAddedDate = context.localUtil.CToD( cgiGet( edtsucursalAddedDate_Internalname), 2);
               AssignAttri("", false, "A18sucursalAddedDate", context.localUtil.Format(A18sucursalAddedDate, "99/99/99"));
               dynsucursalEmpleadoHeadlineId.Name = dynsucursalEmpleadoHeadlineId_Internalname;
               dynsucursalEmpleadoHeadlineId.CurrentValue = cgiGet( dynsucursalEmpleadoHeadlineId_Internalname);
               A3sucursalEmpleadoHeadlineId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynsucursalEmpleadoHeadlineId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A3sucursalEmpleadoHeadlineId", StringUtil.LTrimStr( (decimal)(A3sucursalEmpleadoHeadlineId), 4, 0));
               dynsucursalEmpleadoAlternateId.Name = dynsucursalEmpleadoAlternateId_Internalname;
               dynsucursalEmpleadoAlternateId.CurrentValue = cgiGet( dynsucursalEmpleadoAlternateId_Internalname);
               A4sucursalEmpleadoAlternateId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynsucursalEmpleadoAlternateId_Internalname), "."), 18, MidpointRounding.ToEven));
               n4sucursalEmpleadoAlternateId = false;
               AssignAttri("", false, "A4sucursalEmpleadoAlternateId", StringUtil.LTrimStr( (decimal)(A4sucursalEmpleadoAlternateId), 4, 0));
               n4sucursalEmpleadoAlternateId = ((0==A4sucursalEmpleadoAlternateId) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"sucursal");
               A2sucursalId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtsucursalId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A2sucursalId", StringUtil.LTrimStr( (decimal)(A2sucursalId), 4, 0));
               forbiddenHiddens.Add("sucursalId", context.localUtil.Format( (decimal)(A2sucursalId), "ZZZ9"));
               A18sucursalAddedDate = context.localUtil.CToD( cgiGet( edtsucursalAddedDate_Internalname), 2);
               AssignAttri("", false, "A18sucursalAddedDate", context.localUtil.Format(A18sucursalAddedDate, "99/99/99"));
               forbiddenHiddens.Add("sucursalAddedDate", context.localUtil.Format(A18sucursalAddedDate, "99/99/99"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A2sucursalId != Z2sucursalId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("sucursal:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A2sucursalId = (short)(Math.Round(NumberUtil.Val( GetPar( "sucursalId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A2sucursalId", StringUtil.LTrimStr( (decimal)(A2sucursalId), 4, 0));
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
                     sMode2 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode2;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound2 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_020( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SUCURSALID");
                        AnyError = 1;
                        GX_FocusControl = edtsucursalId_Internalname;
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
                           E11022 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12022 ();
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
            E12022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll022( ) ;
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
            DisableAttributes022( ) ;
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
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_023( )
      {
         nGXsfl_73_idx = 0;
         while ( nGXsfl_73_idx < nRC_GXsfl_73 )
         {
            ReadRow023( ) ;
            if ( ( nRcdExists_3 != 0 ) || ( nIsMod_3 != 0 ) )
            {
               GetKey023( ) ;
               if ( ( nRcdExists_3 == 0 ) && ( nRcdDeleted_3 == 0 ) )
               {
                  if ( RcdFound3 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate023( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable023( ) ;
                        CloseExtendedTableCursors023( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PRODUCTOID_" + sGXsfl_73_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtproductoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound3 != 0 )
                  {
                     if ( nRcdDeleted_3 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
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
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate023( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable023( ) ;
                              CloseExtendedTableCursors023( ) ;
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
                     if ( nRcdDeleted_3 == 0 )
                     {
                        GXCCtl = "PRODUCTOID_" + sGXsfl_73_idx;
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
            ChangePostValue( edtproductoStock_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A30productoStock), 10, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z5productoId_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z5productoId), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z30productoStock_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z30productoStock), 10, 0, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_3_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_3), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_3_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_3), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_3_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_3), 4, 0, ",", ""))) ;
            if ( nIsMod_3 != 0 )
            {
               ChangePostValue( "PRODUCTOID_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTONAME_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTOSTOCK_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoStock_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption020( )
      {
      }

      protected void E11022( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV15Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV15Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_sucursalEmpleadoHeadlineId = 0;
         AssignAttri("", false, "AV11Insert_sucursalEmpleadoHeadlineId", StringUtil.LTrimStr( (decimal)(AV11Insert_sucursalEmpleadoHeadlineId), 4, 0));
         AV12Insert_sucursalEmpleadoAlternateId = 0;
         AssignAttri("", false, "AV12Insert_sucursalEmpleadoAlternateId", StringUtil.LTrimStr( (decimal)(AV12Insert_sucursalEmpleadoAlternateId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV15Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV16GXV1 = 1;
            AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
            while ( AV16GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV16GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "sucursalEmpleadoHeadlineId") == 0 )
               {
                  AV11Insert_sucursalEmpleadoHeadlineId = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_sucursalEmpleadoHeadlineId", StringUtil.LTrimStr( (decimal)(AV11Insert_sucursalEmpleadoHeadlineId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "sucursalEmpleadoAlternateId") == 0 )
               {
                  AV12Insert_sucursalEmpleadoAlternateId = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_sucursalEmpleadoAlternateId", StringUtil.LTrimStr( (decimal)(AV12Insert_sucursalEmpleadoAlternateId), 4, 0));
               }
               AV16GXV1 = (int)(AV16GXV1+1);
               AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
            }
         }
      }

      protected void E12022( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwsucursal.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
         returnInSub = true;
         if (true) return;
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z13sucursalName = T00026_A13sucursalName[0];
               Z14sucursalAddress = T00026_A14sucursalAddress[0];
               Z17sucursalGeolocation = T00026_A17sucursalGeolocation[0];
               Z18sucursalAddedDate = T00026_A18sucursalAddedDate[0];
               Z3sucursalEmpleadoHeadlineId = T00026_A3sucursalEmpleadoHeadlineId[0];
               Z4sucursalEmpleadoAlternateId = T00026_A4sucursalEmpleadoAlternateId[0];
            }
            else
            {
               Z13sucursalName = A13sucursalName;
               Z14sucursalAddress = A14sucursalAddress;
               Z17sucursalGeolocation = A17sucursalGeolocation;
               Z18sucursalAddedDate = A18sucursalAddedDate;
               Z3sucursalEmpleadoHeadlineId = A3sucursalEmpleadoHeadlineId;
               Z4sucursalEmpleadoAlternateId = A4sucursalEmpleadoAlternateId;
            }
         }
         if ( GX_JID == -20 )
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
         GXASUCURSALEMPLEADOHEADLINEID_html022( ) ;
         GXASUCURSALEMPLEADOALTERNATEID_html022( ) ;
         edtsucursalId_Enabled = 0;
         AssignProp("", false, edtsucursalId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsucursalId_Enabled), 5, 0), true);
         edtsucursalAddedDate_Enabled = 0;
         AssignProp("", false, edtsucursalAddedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsucursalAddedDate_Enabled), 5, 0), true);
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         edtsucursalId_Enabled = 0;
         AssignProp("", false, edtsucursalId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsucursalId_Enabled), 5, 0), true);
         edtsucursalAddedDate_Enabled = 0;
         AssignProp("", false, edtsucursalAddedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsucursalAddedDate_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7sucursalId) )
         {
            A2sucursalId = AV7sucursalId;
            AssignAttri("", false, "A2sucursalId", StringUtil.LTrimStr( (decimal)(A2sucursalId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_sucursalEmpleadoHeadlineId) )
         {
            dynsucursalEmpleadoHeadlineId.Enabled = 0;
            AssignProp("", false, dynsucursalEmpleadoHeadlineId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynsucursalEmpleadoHeadlineId.Enabled), 5, 0), true);
         }
         else
         {
            dynsucursalEmpleadoHeadlineId.Enabled = 1;
            AssignProp("", false, dynsucursalEmpleadoHeadlineId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynsucursalEmpleadoHeadlineId.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_sucursalEmpleadoAlternateId) )
         {
            dynsucursalEmpleadoAlternateId.Enabled = 0;
            AssignProp("", false, dynsucursalEmpleadoAlternateId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynsucursalEmpleadoAlternateId.Enabled), 5, 0), true);
         }
         else
         {
            dynsucursalEmpleadoAlternateId.Enabled = 1;
            AssignProp("", false, dynsucursalEmpleadoAlternateId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynsucursalEmpleadoAlternateId.Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_sucursalEmpleadoAlternateId) )
         {
            A4sucursalEmpleadoAlternateId = AV12Insert_sucursalEmpleadoAlternateId;
            n4sucursalEmpleadoAlternateId = false;
            AssignAttri("", false, "A4sucursalEmpleadoAlternateId", StringUtil.LTrimStr( (decimal)(A4sucursalEmpleadoAlternateId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_sucursalEmpleadoHeadlineId) )
         {
            A3sucursalEmpleadoHeadlineId = AV11Insert_sucursalEmpleadoHeadlineId;
            AssignAttri("", false, "A3sucursalEmpleadoHeadlineId", StringUtil.LTrimStr( (decimal)(A3sucursalEmpleadoHeadlineId), 4, 0));
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
         if ( IsIns( )  )
         {
            A18sucursalAddedDate = Gx_date;
            AssignAttri("", false, "A18sucursalAddedDate", context.localUtil.Format(A18sucursalAddedDate, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00027 */
            pr_default.execute(5, new Object[] {A3sucursalEmpleadoHeadlineId});
            A19sucursalEmpleadoHeadlineName = T00027_A19sucursalEmpleadoHeadlineName[0];
            pr_default.close(5);
            /* Using cursor T00028 */
            pr_default.execute(6, new Object[] {n4sucursalEmpleadoAlternateId, A4sucursalEmpleadoAlternateId});
            A20sucursalEmpleadoAlternateName = T00028_A20sucursalEmpleadoAlternateName[0];
            pr_default.close(6);
            AV15Pgmname = "sucursal";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         }
      }

      protected void Load022( )
      {
         /* Using cursor T00029 */
         pr_default.execute(7, new Object[] {A2sucursalId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound2 = 1;
            A13sucursalName = T00029_A13sucursalName[0];
            AssignAttri("", false, "A13sucursalName", A13sucursalName);
            A14sucursalAddress = T00029_A14sucursalAddress[0];
            AssignAttri("", false, "A14sucursalAddress", A14sucursalAddress);
            A17sucursalGeolocation = T00029_A17sucursalGeolocation[0];
            A18sucursalAddedDate = T00029_A18sucursalAddedDate[0];
            AssignAttri("", false, "A18sucursalAddedDate", context.localUtil.Format(A18sucursalAddedDate, "99/99/99"));
            A19sucursalEmpleadoHeadlineName = T00029_A19sucursalEmpleadoHeadlineName[0];
            A20sucursalEmpleadoAlternateName = T00029_A20sucursalEmpleadoAlternateName[0];
            A3sucursalEmpleadoHeadlineId = T00029_A3sucursalEmpleadoHeadlineId[0];
            AssignAttri("", false, "A3sucursalEmpleadoHeadlineId", StringUtil.LTrimStr( (decimal)(A3sucursalEmpleadoHeadlineId), 4, 0));
            A4sucursalEmpleadoAlternateId = T00029_A4sucursalEmpleadoAlternateId[0];
            n4sucursalEmpleadoAlternateId = T00029_n4sucursalEmpleadoAlternateId[0];
            AssignAttri("", false, "A4sucursalEmpleadoAlternateId", StringUtil.LTrimStr( (decimal)(A4sucursalEmpleadoAlternateId), 4, 0));
            ZM022( -20) ;
         }
         pr_default.close(7);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
         AV15Pgmname = "sucursal";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
      }

      protected void CheckExtendedTable022( )
      {
         nIsDirty_2 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV15Pgmname = "sucursal";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A13sucursalName)) )
         {
            GX_msglist.addItem("Falta el nombre", 1, "SUCURSALNAME");
            AnyError = 1;
            GX_FocusControl = edtsucursalName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A14sucursalAddress)) )
         {
            GX_msglist.addItem("Falta la direccion", 1, "SUCURSALADDRESS");
            AnyError = 1;
            GX_FocusControl = edtsucursalAddress_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A17sucursalGeolocation,"^\\s*(-?([0-8]?[0-9]\\.{1}\\d+|90\\.{1}0+)\\s*,\\s*-?([0-9]{1,2}\\.{1}\\d+|1[0-7][0-9]\\.{1}\\d+|180\\.{1}0+)\\s*)?$") ) )
         {
            GX_msglist.addItem("El valor de sucursal Geolocation no coincide con el patrón especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor T00027 */
         pr_default.execute(5, new Object[] {A3sucursalEmpleadoHeadlineId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'sucursal Empleado Headline'.", "ForeignKeyNotFound", 1, "SUCURSALEMPLEADOHEADLINEID");
            AnyError = 1;
            GX_FocusControl = dynsucursalEmpleadoHeadlineId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A19sucursalEmpleadoHeadlineName = T00027_A19sucursalEmpleadoHeadlineName[0];
         pr_default.close(5);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A19sucursalEmpleadoHeadlineName)) )
         {
            GX_msglist.addItem("Falta el encargado titular", 1, "");
            AnyError = 1;
         }
         if ( A3sucursalEmpleadoHeadlineId == A4sucursalEmpleadoAlternateId )
         {
            GX_msglist.addItem("Los encargados son los mismos", 1, "SUCURSALEMPLEADOHEADLINEID");
            AnyError = 1;
            GX_FocusControl = dynsucursalEmpleadoHeadlineId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00028 */
         pr_default.execute(6, new Object[] {n4sucursalEmpleadoAlternateId, A4sucursalEmpleadoAlternateId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A4sucursalEmpleadoAlternateId) ) )
            {
               GX_msglist.addItem("No existe 'sucursal Empleado Alternate'.", "ForeignKeyNotFound", 1, "SUCURSALEMPLEADOALTERNATEID");
               AnyError = 1;
               GX_FocusControl = dynsucursalEmpleadoAlternateId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A20sucursalEmpleadoAlternateName = T00028_A20sucursalEmpleadoAlternateName[0];
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

      protected void gxLoad_21( short A3sucursalEmpleadoHeadlineId )
      {
         /* Using cursor T000210 */
         pr_default.execute(8, new Object[] {A3sucursalEmpleadoHeadlineId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'sucursal Empleado Headline'.", "ForeignKeyNotFound", 1, "SUCURSALEMPLEADOHEADLINEID");
            AnyError = 1;
            GX_FocusControl = dynsucursalEmpleadoHeadlineId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A19sucursalEmpleadoHeadlineName = T000210_A19sucursalEmpleadoHeadlineName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A19sucursalEmpleadoHeadlineName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_22( short A4sucursalEmpleadoAlternateId )
      {
         /* Using cursor T000211 */
         pr_default.execute(9, new Object[] {n4sucursalEmpleadoAlternateId, A4sucursalEmpleadoAlternateId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A4sucursalEmpleadoAlternateId) ) )
            {
               GX_msglist.addItem("No existe 'sucursal Empleado Alternate'.", "ForeignKeyNotFound", 1, "SUCURSALEMPLEADOALTERNATEID");
               AnyError = 1;
               GX_FocusControl = dynsucursalEmpleadoAlternateId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A20sucursalEmpleadoAlternateName = T000211_A20sucursalEmpleadoAlternateName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A20sucursalEmpleadoAlternateName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void GetKey022( )
      {
         /* Using cursor T000212 */
         pr_default.execute(10, new Object[] {A2sucursalId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(10);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00026 */
         pr_default.execute(4, new Object[] {A2sucursalId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM022( 20) ;
            RcdFound2 = 1;
            A2sucursalId = T00026_A2sucursalId[0];
            AssignAttri("", false, "A2sucursalId", StringUtil.LTrimStr( (decimal)(A2sucursalId), 4, 0));
            A13sucursalName = T00026_A13sucursalName[0];
            AssignAttri("", false, "A13sucursalName", A13sucursalName);
            A14sucursalAddress = T00026_A14sucursalAddress[0];
            AssignAttri("", false, "A14sucursalAddress", A14sucursalAddress);
            A17sucursalGeolocation = T00026_A17sucursalGeolocation[0];
            A18sucursalAddedDate = T00026_A18sucursalAddedDate[0];
            AssignAttri("", false, "A18sucursalAddedDate", context.localUtil.Format(A18sucursalAddedDate, "99/99/99"));
            A3sucursalEmpleadoHeadlineId = T00026_A3sucursalEmpleadoHeadlineId[0];
            AssignAttri("", false, "A3sucursalEmpleadoHeadlineId", StringUtil.LTrimStr( (decimal)(A3sucursalEmpleadoHeadlineId), 4, 0));
            A4sucursalEmpleadoAlternateId = T00026_A4sucursalEmpleadoAlternateId[0];
            n4sucursalEmpleadoAlternateId = T00026_n4sucursalEmpleadoAlternateId[0];
            AssignAttri("", false, "A4sucursalEmpleadoAlternateId", StringUtil.LTrimStr( (decimal)(A4sucursalEmpleadoAlternateId), 4, 0));
            Z2sucursalId = A2sucursalId;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound2 = 0;
         /* Using cursor T000213 */
         pr_default.execute(11, new Object[] {A2sucursalId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000213_A2sucursalId[0] < A2sucursalId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000213_A2sucursalId[0] > A2sucursalId ) ) )
            {
               A2sucursalId = T000213_A2sucursalId[0];
               AssignAttri("", false, "A2sucursalId", StringUtil.LTrimStr( (decimal)(A2sucursalId), 4, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void move_previous( )
      {
         RcdFound2 = 0;
         /* Using cursor T000214 */
         pr_default.execute(12, new Object[] {A2sucursalId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( T000214_A2sucursalId[0] > A2sucursalId ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( T000214_A2sucursalId[0] < A2sucursalId ) ) )
            {
               A2sucursalId = T000214_A2sucursalId[0];
               AssignAttri("", false, "A2sucursalId", StringUtil.LTrimStr( (decimal)(A2sucursalId), 4, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtsucursalName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert022( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A2sucursalId != Z2sucursalId )
               {
                  A2sucursalId = Z2sucursalId;
                  AssignAttri("", false, "A2sucursalId", StringUtil.LTrimStr( (decimal)(A2sucursalId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SUCURSALID");
                  AnyError = 1;
                  GX_FocusControl = edtsucursalId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtsucursalName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update022( ) ;
                  GX_FocusControl = edtsucursalName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A2sucursalId != Z2sucursalId )
               {
                  /* Insert record */
                  GX_FocusControl = edtsucursalName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert022( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SUCURSALID");
                     AnyError = 1;
                     GX_FocusControl = edtsucursalId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtsucursalName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert022( ) ;
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
         if ( A2sucursalId != Z2sucursalId )
         {
            A2sucursalId = Z2sucursalId;
            AssignAttri("", false, "A2sucursalId", StringUtil.LTrimStr( (decimal)(A2sucursalId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SUCURSALID");
            AnyError = 1;
            GX_FocusControl = edtsucursalId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtsucursalName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00025 */
            pr_default.execute(3, new Object[] {A2sucursalId});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"sucursal"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z13sucursalName, T00025_A13sucursalName[0]) != 0 ) || ( StringUtil.StrCmp(Z14sucursalAddress, T00025_A14sucursalAddress[0]) != 0 ) || ( StringUtil.StrCmp(Z17sucursalGeolocation, T00025_A17sucursalGeolocation[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z18sucursalAddedDate ) != DateTimeUtil.ResetTime ( T00025_A18sucursalAddedDate[0] ) ) || ( Z3sucursalEmpleadoHeadlineId != T00025_A3sucursalEmpleadoHeadlineId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z4sucursalEmpleadoAlternateId != T00025_A4sucursalEmpleadoAlternateId[0] ) )
            {
               if ( StringUtil.StrCmp(Z13sucursalName, T00025_A13sucursalName[0]) != 0 )
               {
                  GXUtil.WriteLog("sucursal:[seudo value changed for attri]"+"sucursalName");
                  GXUtil.WriteLogRaw("Old: ",Z13sucursalName);
                  GXUtil.WriteLogRaw("Current: ",T00025_A13sucursalName[0]);
               }
               if ( StringUtil.StrCmp(Z14sucursalAddress, T00025_A14sucursalAddress[0]) != 0 )
               {
                  GXUtil.WriteLog("sucursal:[seudo value changed for attri]"+"sucursalAddress");
                  GXUtil.WriteLogRaw("Old: ",Z14sucursalAddress);
                  GXUtil.WriteLogRaw("Current: ",T00025_A14sucursalAddress[0]);
               }
               if ( StringUtil.StrCmp(Z17sucursalGeolocation, T00025_A17sucursalGeolocation[0]) != 0 )
               {
                  GXUtil.WriteLog("sucursal:[seudo value changed for attri]"+"sucursalGeolocation");
                  GXUtil.WriteLogRaw("Old: ",Z17sucursalGeolocation);
                  GXUtil.WriteLogRaw("Current: ",T00025_A17sucursalGeolocation[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z18sucursalAddedDate ) != DateTimeUtil.ResetTime ( T00025_A18sucursalAddedDate[0] ) )
               {
                  GXUtil.WriteLog("sucursal:[seudo value changed for attri]"+"sucursalAddedDate");
                  GXUtil.WriteLogRaw("Old: ",Z18sucursalAddedDate);
                  GXUtil.WriteLogRaw("Current: ",T00025_A18sucursalAddedDate[0]);
               }
               if ( Z3sucursalEmpleadoHeadlineId != T00025_A3sucursalEmpleadoHeadlineId[0] )
               {
                  GXUtil.WriteLog("sucursal:[seudo value changed for attri]"+"sucursalEmpleadoHeadlineId");
                  GXUtil.WriteLogRaw("Old: ",Z3sucursalEmpleadoHeadlineId);
                  GXUtil.WriteLogRaw("Current: ",T00025_A3sucursalEmpleadoHeadlineId[0]);
               }
               if ( Z4sucursalEmpleadoAlternateId != T00025_A4sucursalEmpleadoAlternateId[0] )
               {
                  GXUtil.WriteLog("sucursal:[seudo value changed for attri]"+"sucursalEmpleadoAlternateId");
                  GXUtil.WriteLogRaw("Old: ",Z4sucursalEmpleadoAlternateId);
                  GXUtil.WriteLogRaw("Current: ",T00025_A4sucursalEmpleadoAlternateId[0]);
               }
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
                     /* Using cursor T000215 */
                     pr_default.execute(13, new Object[] {A13sucursalName, A14sucursalAddress, A17sucursalGeolocation, A18sucursalAddedDate, A3sucursalEmpleadoHeadlineId, n4sucursalEmpleadoAlternateId, A4sucursalEmpleadoAlternateId});
                     A2sucursalId = T000215_A2sucursalId[0];
                     AssignAttri("", false, "A2sucursalId", StringUtil.LTrimStr( (decimal)(A2sucursalId), 4, 0));
                     pr_default.close(13);
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
                              ResetCaption020( ) ;
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
                     /* Using cursor T000216 */
                     pr_default.execute(14, new Object[] {A13sucursalName, A14sucursalAddress, A17sucursalGeolocation, A18sucursalAddedDate, A3sucursalEmpleadoHeadlineId, n4sucursalEmpleadoAlternateId, A4sucursalEmpleadoAlternateId, A2sucursalId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("sucursal");
                     if ( (pr_default.getStatus(14) == 103) )
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
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
      }

      protected void delete( )
      {
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
                  ScanStart023( ) ;
                  while ( RcdFound3 != 0 )
                  {
                     getByPrimaryKey023( ) ;
                     Delete023( ) ;
                     ScanNext023( ) ;
                  }
                  ScanEnd023( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000217 */
                     pr_default.execute(15, new Object[] {A2sucursalId});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("sucursal");
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
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel022( ) ;
         Gx_mode = sMode2;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV15Pgmname = "sucursal";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T000218 */
            pr_default.execute(16, new Object[] {A3sucursalEmpleadoHeadlineId});
            A19sucursalEmpleadoHeadlineName = T000218_A19sucursalEmpleadoHeadlineName[0];
            pr_default.close(16);
            /* Using cursor T000219 */
            pr_default.execute(17, new Object[] {n4sucursalEmpleadoAlternateId, A4sucursalEmpleadoAlternateId});
            A20sucursalEmpleadoAlternateName = T000219_A20sucursalEmpleadoAlternateName[0];
            pr_default.close(17);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000220 */
            pr_default.execute(18, new Object[] {A2sucursalId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"factura"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
         }
      }

      protected void ProcessNestedLevel023( )
      {
         nGXsfl_73_idx = 0;
         while ( nGXsfl_73_idx < nRC_GXsfl_73 )
         {
            ReadRow023( ) ;
            if ( ( nRcdExists_3 != 0 ) || ( nIsMod_3 != 0 ) )
            {
               standaloneNotModal023( ) ;
               GetKey023( ) ;
               if ( ( nRcdExists_3 == 0 ) && ( nRcdDeleted_3 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert023( ) ;
               }
               else
               {
                  if ( RcdFound3 != 0 )
                  {
                     if ( ( nRcdDeleted_3 != 0 ) && ( nRcdExists_3 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete023( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_3 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update023( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_3 == 0 )
                     {
                        GXCCtl = "PRODUCTOID_" + sGXsfl_73_idx;
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
            ChangePostValue( edtproductoStock_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A30productoStock), 10, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z5productoId_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z5productoId), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z30productoStock_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z30productoStock), 10, 0, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_3_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_3), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_3_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_3), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_3_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_3), 4, 0, ",", ""))) ;
            if ( nIsMod_3 != 0 )
            {
               ChangePostValue( "PRODUCTOID_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTONAME_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTOSTOCK_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoStock_Enabled), 5, 0, ".", ""))) ;
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
         nRcdDeleted_3 = 0;
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
         AssignAttri("", false, "Gx_mode", Gx_mode);
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
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(16);
            pr_default.close(17);
            pr_default.close(2);
            context.CommitDataStores("sucursal",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues020( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(16);
            pr_default.close(17);
            pr_default.close(2);
            context.RollbackDataStores("sucursal",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart022( )
      {
         /* Scan By routine */
         /* Using cursor T000221 */
         pr_default.execute(19);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound2 = 1;
            A2sucursalId = T000221_A2sucursalId[0];
            AssignAttri("", false, "A2sucursalId", StringUtil.LTrimStr( (decimal)(A2sucursalId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound2 = 1;
            A2sucursalId = T000221_A2sucursalId[0];
            AssignAttri("", false, "A2sucursalId", StringUtil.LTrimStr( (decimal)(A2sucursalId), 4, 0));
         }
      }

      protected void ScanEnd022( )
      {
         pr_default.close(19);
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
         edtsucursalId_Enabled = 0;
         AssignProp("", false, edtsucursalId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsucursalId_Enabled), 5, 0), true);
         edtsucursalName_Enabled = 0;
         AssignProp("", false, edtsucursalName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsucursalName_Enabled), 5, 0), true);
         edtsucursalAddress_Enabled = 0;
         AssignProp("", false, edtsucursalAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsucursalAddress_Enabled), 5, 0), true);
         edtsucursalAddedDate_Enabled = 0;
         AssignProp("", false, edtsucursalAddedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsucursalAddedDate_Enabled), 5, 0), true);
         dynsucursalEmpleadoHeadlineId.Enabled = 0;
         AssignProp("", false, dynsucursalEmpleadoHeadlineId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynsucursalEmpleadoHeadlineId.Enabled), 5, 0), true);
         dynsucursalEmpleadoAlternateId.Enabled = 0;
         AssignProp("", false, dynsucursalEmpleadoAlternateId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynsucursalEmpleadoAlternateId.Enabled), 5, 0), true);
         Sucursalgeolocation_Enabled = Convert.ToBoolean( 0);
         AssignProp("", false, Sucursalgeolocation_Internalname, "Enabled", StringUtil.BoolToStr( Sucursalgeolocation_Enabled), true);
      }

      protected void ZM023( short GX_JID )
      {
         if ( ( GX_JID == 23 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z30productoStock = T00023_A30productoStock[0];
            }
            else
            {
               Z30productoStock = A30productoStock;
            }
         }
         if ( GX_JID == -23 )
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
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtproductoId_Enabled = 0;
            AssignProp("", false, edtproductoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoId_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         }
         else
         {
            edtproductoId_Enabled = 1;
            AssignProp("", false, edtproductoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoId_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         }
      }

      protected void Load023( )
      {
         /* Using cursor T000222 */
         pr_default.execute(20, new Object[] {A2sucursalId, A5productoId});
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound3 = 1;
            A25productoName = T000222_A25productoName[0];
            A30productoStock = T000222_A30productoStock[0];
            ZM023( -23) ;
         }
         pr_default.close(20);
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
         /* Using cursor T00024 */
         pr_default.execute(2, new Object[] {A5productoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PRODUCTOID_" + sGXsfl_73_idx;
            GX_msglist.addItem("No existe 'producto'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtproductoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A25productoName = T00024_A25productoName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors023( )
      {
         pr_default.close(2);
      }

      protected void enableDisable023( )
      {
      }

      protected void gxLoad_24( short A5productoId )
      {
         /* Using cursor T000223 */
         pr_default.execute(21, new Object[] {A5productoId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GXCCtl = "PRODUCTOID_" + sGXsfl_73_idx;
            GX_msglist.addItem("No existe 'producto'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtproductoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A25productoName = T000223_A25productoName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A25productoName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(21) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(21);
      }

      protected void GetKey023( )
      {
         /* Using cursor T000224 */
         pr_default.execute(22, new Object[] {A2sucursalId, A5productoId});
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(22);
      }

      protected void getByPrimaryKey023( )
      {
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {A2sucursalId, A5productoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM023( 23) ;
            RcdFound3 = 1;
            InitializeNonKey023( ) ;
            A30productoStock = T00023_A30productoStock[0];
            A5productoId = T00023_A5productoId[0];
            Z2sucursalId = A2sucursalId;
            Z5productoId = A5productoId;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load023( ) ;
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey023( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal023( ) ;
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
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
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {A2sucursalId, A5productoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"sucursalproducto"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z30productoStock != T00022_A30productoStock[0] ) )
            {
               if ( Z30productoStock != T00022_A30productoStock[0] )
               {
                  GXUtil.WriteLog("sucursal:[seudo value changed for attri]"+"productoStock");
                  GXUtil.WriteLogRaw("Old: ",Z30productoStock);
                  GXUtil.WriteLogRaw("Current: ",T00022_A30productoStock[0]);
               }
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
                     /* Using cursor T000225 */
                     pr_default.execute(23, new Object[] {A2sucursalId, A30productoStock, A5productoId});
                     pr_default.close(23);
                     pr_default.SmartCacheProvider.SetUpdated("sucursalproducto");
                     if ( (pr_default.getStatus(23) == 1) )
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
         if ( ( nIsMod_3 != 0 ) || ( nIsDirty_3 != 0 ) )
         {
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
                        /* Using cursor T000226 */
                        pr_default.execute(24, new Object[] {A30productoStock, A2sucursalId, A5productoId});
                        pr_default.close(24);
                        pr_default.SmartCacheProvider.SetUpdated("sucursalproducto");
                        if ( (pr_default.getStatus(24) == 103) )
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
         }
         CloseExtendedTableCursors023( ) ;
      }

      protected void DeferredUpdate023( )
      {
      }

      protected void Delete023( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
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
                  /* Using cursor T000227 */
                  pr_default.execute(25, new Object[] {A2sucursalId, A5productoId});
                  pr_default.close(25);
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
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel023( ) ;
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls023( )
      {
         standaloneModal023( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000228 */
            pr_default.execute(26, new Object[] {A5productoId});
            A25productoName = T000228_A25productoName[0];
            pr_default.close(26);
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

      public void ScanStart023( )
      {
         /* Scan By routine */
         /* Using cursor T000229 */
         pr_default.execute(27, new Object[] {A2sucursalId});
         RcdFound3 = 0;
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound3 = 1;
            A5productoId = T000229_A5productoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext023( )
      {
         /* Scan next routine */
         pr_default.readNext(27);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound3 = 1;
            A5productoId = T000229_A5productoId[0];
         }
      }

      protected void ScanEnd023( )
      {
         pr_default.close(27);
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
         edtproductoId_Enabled = 0;
         AssignProp("", false, edtproductoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoId_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtproductoName_Enabled = 0;
         AssignProp("", false, edtproductoName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoName_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtproductoStock_Enabled = 0;
         AssignProp("", false, edtproductoStock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoStock_Enabled), 5, 0), !bGXsfl_73_Refreshing);
      }

      protected void send_integrity_lvl_hashes023( )
      {
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void SubsflControlProps_733( )
      {
         edtproductoId_Internalname = "PRODUCTOID_"+sGXsfl_73_idx;
         imgprompt_5_Internalname = "PROMPT_5_"+sGXsfl_73_idx;
         edtproductoName_Internalname = "PRODUCTONAME_"+sGXsfl_73_idx;
         edtproductoStock_Internalname = "PRODUCTOSTOCK_"+sGXsfl_73_idx;
      }

      protected void SubsflControlProps_fel_733( )
      {
         edtproductoId_Internalname = "PRODUCTOID_"+sGXsfl_73_fel_idx;
         imgprompt_5_Internalname = "PROMPT_5_"+sGXsfl_73_fel_idx;
         edtproductoName_Internalname = "PRODUCTONAME_"+sGXsfl_73_fel_idx;
         edtproductoStock_Internalname = "PRODUCTOSTOCK_"+sGXsfl_73_fel_idx;
      }

      protected void AddRow023( )
      {
         nGXsfl_73_idx = (int)(nGXsfl_73_idx+1);
         sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
         SubsflControlProps_733( ) ;
         SendRow023( ) ;
      }

      protected void SendRow023( )
      {
         Gridsucursal_productoRow = GXWebRow.GetNew(context);
         if ( subGridsucursal_producto_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridsucursal_producto_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridsucursal_producto_Class, "") != 0 )
            {
               subGridsucursal_producto_Linesclass = subGridsucursal_producto_Class+"Odd";
            }
         }
         else if ( subGridsucursal_producto_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridsucursal_producto_Backstyle = 0;
            subGridsucursal_producto_Backcolor = subGridsucursal_producto_Allbackcolor;
            if ( StringUtil.StrCmp(subGridsucursal_producto_Class, "") != 0 )
            {
               subGridsucursal_producto_Linesclass = subGridsucursal_producto_Class+"Uniform";
            }
         }
         else if ( subGridsucursal_producto_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridsucursal_producto_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridsucursal_producto_Class, "") != 0 )
            {
               subGridsucursal_producto_Linesclass = subGridsucursal_producto_Class+"Odd";
            }
            subGridsucursal_producto_Backcolor = (int)(0x0);
         }
         else if ( subGridsucursal_producto_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridsucursal_producto_Backstyle = 1;
            if ( ((int)((nGXsfl_73_idx) % (2))) == 0 )
            {
               subGridsucursal_producto_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridsucursal_producto_Class, "") != 0 )
               {
                  subGridsucursal_producto_Linesclass = subGridsucursal_producto_Class+"Even";
               }
            }
            else
            {
               subGridsucursal_producto_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridsucursal_producto_Class, "") != 0 )
               {
                  subGridsucursal_producto_Linesclass = subGridsucursal_producto_Class+"Odd";
               }
            }
         }
         imgprompt_5_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUCTOID_"+sGXsfl_73_idx+"'), id:'"+"PRODUCTOID_"+sGXsfl_73_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_3_"+sGXsfl_73_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_3_" + sGXsfl_73_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_73_idx + "',73)\"";
         ROClassString = "Attribute";
         Gridsucursal_productoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtproductoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A5productoId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A5productoId), "ZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,74);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtproductoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtproductoId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)73,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridsucursal_productoRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_5_Internalname,(string)sImgUrl,(string)imgprompt_5_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_5_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridsucursal_productoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtproductoName_Internalname,(string)A25productoName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtproductoName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtproductoName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)73,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_3_" + sGXsfl_73_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_73_idx + "',73)\"";
         ROClassString = "Attribute";
         Gridsucursal_productoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtproductoStock_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A30productoStock), 10, 0, ",", "")),StringUtil.LTrim( ((edtproductoStock_Enabled!=0) ? context.localUtil.Format( (decimal)(A30productoStock), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A30productoStock), "ZZZZZZZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,76);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtproductoStock_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtproductoStock_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)73,(short)0,(short)-1,(short)0,(bool)true,(string)"Stock",(string)"right",(bool)false,(string)""});
         ajax_sending_grid_row(Gridsucursal_productoRow);
         send_integrity_lvl_hashes023( ) ;
         GXCCtl = "Z5productoId_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z5productoId), 4, 0, ",", "")));
         GXCCtl = "Z30productoStock_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z30productoStock), 10, 0, ",", "")));
         GXCCtl = "nRcdDeleted_3_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_3), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_3_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_3), 4, 0, ",", "")));
         GXCCtl = "nIsMod_3_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_3), 4, 0, ",", "")));
         GXCCtl = "vMODE_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_73_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vSUCURSALID_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7sucursalId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTOID_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTONAME_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTOSTOCK_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoStock_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_5_"+sGXsfl_73_idx+"Link", StringUtil.RTrim( imgprompt_5_Link));
         ajax_sending_grid_row(null);
         Gridsucursal_productoContainer.AddRow(Gridsucursal_productoRow);
      }

      protected void ReadRow023( )
      {
         nGXsfl_73_idx = (int)(nGXsfl_73_idx+1);
         sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
         SubsflControlProps_733( ) ;
         edtproductoId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTOID_"+sGXsfl_73_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtproductoName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTONAME_"+sGXsfl_73_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtproductoStock_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTOSTOCK_"+sGXsfl_73_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         imgprompt_5_Link = cgiGet( "PROMPT_5_"+sGXsfl_73_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtproductoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtproductoId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "PRODUCTOID_" + sGXsfl_73_idx;
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
         if ( ( ( context.localUtil.CToN( cgiGet( edtproductoStock_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtproductoStock_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
         {
            GXCCtl = "PRODUCTOSTOCK_" + sGXsfl_73_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtproductoStock_Internalname;
            wbErr = true;
            A30productoStock = 0;
         }
         else
         {
            A30productoStock = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtproductoStock_Internalname), ",", "."), 18, MidpointRounding.ToEven));
         }
         GXCCtl = "Z5productoId_" + sGXsfl_73_idx;
         Z5productoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "Z30productoStock_" + sGXsfl_73_idx;
         Z30productoStock = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_3_" + sGXsfl_73_idx;
         nRcdDeleted_3 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_3_" + sGXsfl_73_idx;
         nRcdExists_3 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_3_" + sGXsfl_73_idx;
         nIsMod_3 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtproductoId_Enabled = edtproductoId_Enabled;
      }

      protected void ConfirmValues020( )
      {
         nGXsfl_73_idx = 0;
         sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
         SubsflControlProps_733( ) ;
         while ( nGXsfl_73_idx < nRC_GXsfl_73 )
         {
            nGXsfl_73_idx = (int)(nGXsfl_73_idx+1);
            sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
            SubsflControlProps_733( ) ;
            ChangePostValue( "Z5productoId_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z5productoId_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z5productoId_"+sGXsfl_73_idx) ;
            ChangePostValue( "Z30productoStock_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z30productoStock_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z30productoStock_"+sGXsfl_73_idx) ;
         }
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
         context.AddJavascriptSource("SDGeoLocation/mapsproviders.js", "", false, true);
         context.AddJavascriptSource("SDGeoLocation/wellknown.js", "", false, true);
         context.AddJavascriptSource("SDGeoLocation/Gxmap.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("sucursal.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7sucursalId,4,0))}, new string[] {"Gx_mode","sucursalId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"sucursal");
         forbiddenHiddens.Add("sucursalId", context.localUtil.Format( (decimal)(A2sucursalId), "ZZZ9"));
         forbiddenHiddens.Add("sucursalAddedDate", context.localUtil.Format(A18sucursalAddedDate, "99/99/99"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("sucursal:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z2sucursalId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2sucursalId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z13sucursalName", Z13sucursalName);
         GxWebStd.gx_hidden_field( context, "Z14sucursalAddress", Z14sucursalAddress);
         GxWebStd.gx_hidden_field( context, "Z17sucursalGeolocation", StringUtil.RTrim( Z17sucursalGeolocation));
         GxWebStd.gx_hidden_field( context, "Z18sucursalAddedDate", context.localUtil.DToC( Z18sucursalAddedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z3sucursalEmpleadoHeadlineId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z3sucursalEmpleadoHeadlineId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z4sucursalEmpleadoAlternateId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4sucursalEmpleadoAlternateId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_73", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_73_idx), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N3sucursalEmpleadoHeadlineId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A3sucursalEmpleadoHeadlineId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N4sucursalEmpleadoAlternateId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4sucursalEmpleadoAlternateId), 4, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "SUCURSALGEOLOCATION", StringUtil.RTrim( A17sucursalGeolocation));
         GxWebStd.gx_hidden_field( context, "vSUCURSALID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7sucursalId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSUCURSALID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7sucursalId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_SUCURSALEMPLEADOHEADLINEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_sucursalEmpleadoHeadlineId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_SUCURSALEMPLEADOALTERNATEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_sucursalEmpleadoAlternateId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "SUCURSALEMPLEADOHEADLINENAME", A19sucursalEmpleadoHeadlineName);
         GxWebStd.gx_hidden_field( context, "SUCURSALEMPLEADOALTERNATENAME", A20sucursalEmpleadoAlternateName);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV15Pgmname));
         GxWebStd.gx_hidden_field( context, "SUCURSALGEOLOCATION_Objectcall", StringUtil.RTrim( Sucursalgeolocation_Objectcall));
         GxWebStd.gx_hidden_field( context, "SUCURSALGEOLOCATION_Enabled", StringUtil.BoolToStr( Sucursalgeolocation_Enabled));
         GxWebStd.gx_hidden_field( context, "SUCURSALGEOLOCATION_Captionclass", StringUtil.RTrim( Sucursalgeolocation_Captionclass));
         GxWebStd.gx_hidden_field( context, "SUCURSALGEOLOCATION_Captionstyle", StringUtil.RTrim( Sucursalgeolocation_Captionstyle));
         GxWebStd.gx_hidden_field( context, "SUCURSALGEOLOCATION_Captionposition", StringUtil.RTrim( Sucursalgeolocation_Captionposition));
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
         return formatLink("sucursal.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7sucursalId,4,0))}, new string[] {"Gx_mode","sucursalId"})  ;
      }

      public override string GetPgmname( )
      {
         return "sucursal" ;
      }

      public override string GetPgmdesc( )
      {
         return "sucursal" ;
      }

      protected void InitializeNonKey022( )
      {
         A3sucursalEmpleadoHeadlineId = 0;
         AssignAttri("", false, "A3sucursalEmpleadoHeadlineId", StringUtil.LTrimStr( (decimal)(A3sucursalEmpleadoHeadlineId), 4, 0));
         A4sucursalEmpleadoAlternateId = 0;
         n4sucursalEmpleadoAlternateId = false;
         AssignAttri("", false, "A4sucursalEmpleadoAlternateId", StringUtil.LTrimStr( (decimal)(A4sucursalEmpleadoAlternateId), 4, 0));
         n4sucursalEmpleadoAlternateId = ((0==A4sucursalEmpleadoAlternateId) ? true : false);
         A13sucursalName = "";
         AssignAttri("", false, "A13sucursalName", A13sucursalName);
         A14sucursalAddress = "";
         AssignAttri("", false, "A14sucursalAddress", A14sucursalAddress);
         A17sucursalGeolocation = "";
         AssignAttri("", false, "A17sucursalGeolocation", A17sucursalGeolocation);
         A18sucursalAddedDate = DateTime.MinValue;
         AssignAttri("", false, "A18sucursalAddedDate", context.localUtil.Format(A18sucursalAddedDate, "99/99/99"));
         A19sucursalEmpleadoHeadlineName = "";
         AssignAttri("", false, "A19sucursalEmpleadoHeadlineName", A19sucursalEmpleadoHeadlineName);
         A20sucursalEmpleadoAlternateName = "";
         AssignAttri("", false, "A20sucursalEmpleadoAlternateName", A20sucursalEmpleadoAlternateName);
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
         AssignAttri("", false, "A2sucursalId", StringUtil.LTrimStr( (decimal)(A2sucursalId), 4, 0));
         InitializeNonKey022( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A18sucursalAddedDate = i18sucursalAddedDate;
         AssignAttri("", false, "A18sucursalAddedDate", context.localUtil.Format(A18sucursalAddedDate, "99/99/99"));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20233241858743", true, true);
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
         context.AddJavascriptSource("sucursal.js", "?20233241858744", false, true);
         context.AddJavascriptSource("SDGeoLocation/mapsproviders.js", "", false, true);
         context.AddJavascriptSource("SDGeoLocation/wellknown.js", "", false, true);
         context.AddJavascriptSource("SDGeoLocation/Gxmap.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties3( )
      {
         edtproductoId_Enabled = defedtproductoId_Enabled;
         AssignProp("", false, edtproductoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoId_Enabled), 5, 0), !bGXsfl_73_Refreshing);
      }

      protected void StartGridControl73( )
      {
         Gridsucursal_productoContainer.AddObjectProperty("GridName", "Gridsucursal_producto");
         Gridsucursal_productoContainer.AddObjectProperty("Header", subGridsucursal_producto_Header);
         Gridsucursal_productoContainer.AddObjectProperty("Class", "Grid");
         Gridsucursal_productoContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridsucursal_productoContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridsucursal_productoContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsucursal_producto_Backcolorstyle), 1, 0, ".", "")));
         Gridsucursal_productoContainer.AddObjectProperty("CmpContext", "");
         Gridsucursal_productoContainer.AddObjectProperty("InMasterPage", "false");
         Gridsucursal_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridsucursal_productoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A5productoId), 4, 0, ".", ""))));
         Gridsucursal_productoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoId_Enabled), 5, 0, ".", "")));
         Gridsucursal_productoContainer.AddColumnProperties(Gridsucursal_productoColumn);
         Gridsucursal_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridsucursal_productoContainer.AddColumnProperties(Gridsucursal_productoColumn);
         Gridsucursal_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridsucursal_productoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A25productoName));
         Gridsucursal_productoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoName_Enabled), 5, 0, ".", "")));
         Gridsucursal_productoContainer.AddColumnProperties(Gridsucursal_productoColumn);
         Gridsucursal_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridsucursal_productoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A30productoStock), 10, 0, ".", ""))));
         Gridsucursal_productoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtproductoStock_Enabled), 5, 0, ".", "")));
         Gridsucursal_productoContainer.AddColumnProperties(Gridsucursal_productoColumn);
         Gridsucursal_productoContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsucursal_producto_Selectedindex), 4, 0, ".", "")));
         Gridsucursal_productoContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsucursal_producto_Allowselection), 1, 0, ".", "")));
         Gridsucursal_productoContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsucursal_producto_Selectioncolor), 9, 0, ".", "")));
         Gridsucursal_productoContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsucursal_producto_Allowhovering), 1, 0, ".", "")));
         Gridsucursal_productoContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsucursal_producto_Hoveringcolor), 9, 0, ".", "")));
         Gridsucursal_productoContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsucursal_producto_Allowcollapsing), 1, 0, ".", "")));
         Gridsucursal_productoContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsucursal_producto_Collapsed), 1, 0, ".", "")));
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
         edtsucursalId_Internalname = "SUCURSALID";
         edtsucursalName_Internalname = "SUCURSALNAME";
         edtsucursalAddress_Internalname = "SUCURSALADDRESS";
         Sucursalgeolocation_Internalname = "SUCURSALGEOLOCATION";
         edtsucursalAddedDate_Internalname = "SUCURSALADDEDDATE";
         dynsucursalEmpleadoHeadlineId_Internalname = "SUCURSALEMPLEADOHEADLINEID";
         dynsucursalEmpleadoAlternateId_Internalname = "SUCURSALEMPLEADOALTERNATEID";
         lblTitleproducto_Internalname = "TITLEPRODUCTO";
         edtproductoId_Internalname = "PRODUCTOID";
         edtproductoName_Internalname = "PRODUCTONAME";
         edtproductoStock_Internalname = "PRODUCTOSTOCK";
         divProductotable_Internalname = "PRODUCTOTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_5_Internalname = "PROMPT_5";
         subGridsucursal_producto_Internalname = "GRIDSUCURSAL_PRODUCTO";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("xd2", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridsucursal_producto_Allowcollapsing = 0;
         subGridsucursal_producto_Allowselection = 0;
         subGridsucursal_producto_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "sucursal";
         edtproductoStock_Jsonclick = "";
         edtproductoName_Jsonclick = "";
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         imgprompt_5_Visible = 1;
         edtproductoId_Jsonclick = "";
         subGridsucursal_producto_Class = "Grid";
         subGridsucursal_producto_Backcolorstyle = 0;
         edtproductoStock_Enabled = 1;
         edtproductoName_Enabled = 0;
         edtproductoId_Enabled = 1;
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         dynsucursalEmpleadoAlternateId_Jsonclick = "";
         dynsucursalEmpleadoAlternateId.Enabled = 1;
         dynsucursalEmpleadoHeadlineId_Jsonclick = "";
         dynsucursalEmpleadoHeadlineId.Enabled = 1;
         edtsucursalAddedDate_Jsonclick = "";
         edtsucursalAddedDate_Enabled = 0;
         Sucursalgeolocation_Captionposition = "Left";
         Sucursalgeolocation_Captionstyle = "";
         Sucursalgeolocation_Captionclass = "col-sm-3 AttributeLabel";
         Sucursalgeolocation_Enabled = Convert.ToBoolean( 1);
         edtsucursalAddress_Enabled = 1;
         edtsucursalName_Jsonclick = "";
         edtsucursalName_Enabled = 1;
         edtsucursalId_Jsonclick = "";
         edtsucursalId_Enabled = 0;
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

      protected void GXDLASUCURSALEMPLEADOHEADLINEID022( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLASUCURSALEMPLEADOHEADLINEID_data022( ) ;
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

      protected void GXASUCURSALEMPLEADOHEADLINEID_html022( )
      {
         short gxdynajaxvalue;
         GXDLASUCURSALEMPLEADOHEADLINEID_data022( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynsucursalEmpleadoHeadlineId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynsucursalEmpleadoHeadlineId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLASUCURSALEMPLEADOHEADLINEID_data022( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("Seleccione un encargado titular");
         /* Using cursor T000230 */
         pr_default.execute(28);
         while ( (pr_default.getStatus(28) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000230_A3sucursalEmpleadoHeadlineId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(T000230_A19sucursalEmpleadoHeadlineName[0]);
            pr_default.readNext(28);
         }
         pr_default.close(28);
      }

      protected void GXDLASUCURSALEMPLEADOALTERNATEID022( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLASUCURSALEMPLEADOALTERNATEID_data022( ) ;
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

      protected void GXASUCURSALEMPLEADOALTERNATEID_html022( )
      {
         short gxdynajaxvalue;
         GXDLASUCURSALEMPLEADOALTERNATEID_data022( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynsucursalEmpleadoAlternateId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynsucursalEmpleadoAlternateId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLASUCURSALEMPLEADOALTERNATEID_data022( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("Seleccione un encargado alternativo");
         /* Using cursor T000231 */
         pr_default.execute(29);
         while ( (pr_default.getStatus(29) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000231_A4sucursalEmpleadoAlternateId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(T000231_A20sucursalEmpleadoAlternateName[0]);
            pr_default.readNext(29);
         }
         pr_default.close(29);
      }

      protected void gxnrGridsucursal_producto_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_733( ) ;
         while ( nGXsfl_73_idx <= nRC_GXsfl_73 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal023( ) ;
            standaloneModal023( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow023( ) ;
            nGXsfl_73_idx = (int)(nGXsfl_73_idx+1);
            sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
            SubsflControlProps_733( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridsucursal_productoContainer)) ;
         /* End function gxnrGridsucursal_producto_newrow */
      }

      protected void init_web_controls( )
      {
         dynsucursalEmpleadoHeadlineId.Name = "SUCURSALEMPLEADOHEADLINEID";
         dynsucursalEmpleadoHeadlineId.WebTags = "";
         dynsucursalEmpleadoAlternateId.Name = "SUCURSALEMPLEADOALTERNATEID";
         dynsucursalEmpleadoAlternateId.WebTags = "";
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

      public void Valid_Sucursalempleadoheadlineid( )
      {
         A3sucursalEmpleadoHeadlineId = (short)(Math.Round(NumberUtil.Val( dynsucursalEmpleadoHeadlineId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n4sucursalEmpleadoAlternateId = false;
         A4sucursalEmpleadoAlternateId = (short)(Math.Round(NumberUtil.Val( dynsucursalEmpleadoAlternateId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n4sucursalEmpleadoAlternateId = false;
         /* Using cursor T000232 */
         pr_default.execute(30, new Object[] {A3sucursalEmpleadoHeadlineId});
         if ( (pr_default.getStatus(30) == 101) )
         {
            GX_msglist.addItem("No existe 'sucursal Empleado Headline'.", "ForeignKeyNotFound", 1, "SUCURSALEMPLEADOHEADLINEID");
            AnyError = 1;
            GX_FocusControl = dynsucursalEmpleadoHeadlineId_Internalname;
         }
         A19sucursalEmpleadoHeadlineName = T000232_A19sucursalEmpleadoHeadlineName[0];
         pr_default.close(30);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A19sucursalEmpleadoHeadlineName)) )
         {
            GX_msglist.addItem("Falta el encargado titular", 1, "SUCURSALEMPLEADOHEADLINEID");
            AnyError = 1;
            GX_FocusControl = dynsucursalEmpleadoHeadlineId_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A19sucursalEmpleadoHeadlineName", A19sucursalEmpleadoHeadlineName);
      }

      public void Valid_Sucursalempleadoalternateid( )
      {
         A3sucursalEmpleadoHeadlineId = (short)(Math.Round(NumberUtil.Val( dynsucursalEmpleadoHeadlineId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n4sucursalEmpleadoAlternateId = false;
         A4sucursalEmpleadoAlternateId = (short)(Math.Round(NumberUtil.Val( dynsucursalEmpleadoAlternateId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n4sucursalEmpleadoAlternateId = false;
         /* Using cursor T000233 */
         pr_default.execute(31, new Object[] {n4sucursalEmpleadoAlternateId, A4sucursalEmpleadoAlternateId});
         if ( (pr_default.getStatus(31) == 101) )
         {
            if ( ! ( (0==A4sucursalEmpleadoAlternateId) ) )
            {
               GX_msglist.addItem("No existe 'sucursal Empleado Alternate'.", "ForeignKeyNotFound", 1, "SUCURSALEMPLEADOALTERNATEID");
               AnyError = 1;
               GX_FocusControl = dynsucursalEmpleadoAlternateId_Internalname;
            }
         }
         A20sucursalEmpleadoAlternateName = T000233_A20sucursalEmpleadoAlternateName[0];
         pr_default.close(31);
         if ( A3sucursalEmpleadoHeadlineId == A4sucursalEmpleadoAlternateId )
         {
            GX_msglist.addItem("Los encargados son los mismos", 1, "SUCURSALEMPLEADOALTERNATEID");
            AnyError = 1;
            GX_FocusControl = dynsucursalEmpleadoAlternateId_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A20sucursalEmpleadoAlternateName", A20sucursalEmpleadoAlternateName);
      }

      public void Valid_Productoid( )
      {
         A3sucursalEmpleadoHeadlineId = (short)(Math.Round(NumberUtil.Val( dynsucursalEmpleadoHeadlineId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n4sucursalEmpleadoAlternateId = false;
         A4sucursalEmpleadoAlternateId = (short)(Math.Round(NumberUtil.Val( dynsucursalEmpleadoAlternateId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n4sucursalEmpleadoAlternateId = false;
         /* Using cursor T000228 */
         pr_default.execute(26, new Object[] {A5productoId});
         if ( (pr_default.getStatus(26) == 101) )
         {
            GX_msglist.addItem("No existe 'producto'.", "ForeignKeyNotFound", 1, "PRODUCTOID");
            AnyError = 1;
            GX_FocusControl = edtproductoId_Internalname;
         }
         A25productoName = T000228_A25productoName[0];
         pr_default.close(26);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A25productoName", A25productoName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7sucursalId',fld:'vSUCURSALID',pic:'ZZZ9',hsh:true},{av:'dynsucursalEmpleadoHeadlineId'},{av:'A3sucursalEmpleadoHeadlineId',fld:'SUCURSALEMPLEADOHEADLINEID',pic:'ZZZ9'},{av:'dynsucursalEmpleadoAlternateId'},{av:'A4sucursalEmpleadoAlternateId',fld:'SUCURSALEMPLEADOALTERNATEID',pic:'ZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'dynsucursalEmpleadoHeadlineId'},{av:'A3sucursalEmpleadoHeadlineId',fld:'SUCURSALEMPLEADOHEADLINEID',pic:'ZZZ9'},{av:'dynsucursalEmpleadoAlternateId'},{av:'A4sucursalEmpleadoAlternateId',fld:'SUCURSALEMPLEADOALTERNATEID',pic:'ZZZ9'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7sucursalId',fld:'vSUCURSALID',pic:'ZZZ9',hsh:true},{av:'A2sucursalId',fld:'SUCURSALID',pic:'ZZZ9'},{av:'A18sucursalAddedDate',fld:'SUCURSALADDEDDATE',pic:''},{av:'dynsucursalEmpleadoHeadlineId'},{av:'A3sucursalEmpleadoHeadlineId',fld:'SUCURSALEMPLEADOHEADLINEID',pic:'ZZZ9'},{av:'dynsucursalEmpleadoAlternateId'},{av:'A4sucursalEmpleadoAlternateId',fld:'SUCURSALEMPLEADOALTERNATEID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynsucursalEmpleadoHeadlineId'},{av:'A3sucursalEmpleadoHeadlineId',fld:'SUCURSALEMPLEADOHEADLINEID',pic:'ZZZ9'},{av:'dynsucursalEmpleadoAlternateId'},{av:'A4sucursalEmpleadoAlternateId',fld:'SUCURSALEMPLEADOALTERNATEID',pic:'ZZZ9'}]}");
         setEventMetadata("AFTER TRN","{handler:'E12022',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'dynsucursalEmpleadoHeadlineId'},{av:'A3sucursalEmpleadoHeadlineId',fld:'SUCURSALEMPLEADOHEADLINEID',pic:'ZZZ9'},{av:'dynsucursalEmpleadoAlternateId'},{av:'A4sucursalEmpleadoAlternateId',fld:'SUCURSALEMPLEADOALTERNATEID',pic:'ZZZ9'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'dynsucursalEmpleadoHeadlineId'},{av:'A3sucursalEmpleadoHeadlineId',fld:'SUCURSALEMPLEADOHEADLINEID',pic:'ZZZ9'},{av:'dynsucursalEmpleadoAlternateId'},{av:'A4sucursalEmpleadoAlternateId',fld:'SUCURSALEMPLEADOALTERNATEID',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_SUCURSALID","{handler:'Valid_Sucursalid',iparms:[{av:'dynsucursalEmpleadoHeadlineId'},{av:'A3sucursalEmpleadoHeadlineId',fld:'SUCURSALEMPLEADOHEADLINEID',pic:'ZZZ9'},{av:'dynsucursalEmpleadoAlternateId'},{av:'A4sucursalEmpleadoAlternateId',fld:'SUCURSALEMPLEADOALTERNATEID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_SUCURSALID",",oparms:[{av:'dynsucursalEmpleadoHeadlineId'},{av:'A3sucursalEmpleadoHeadlineId',fld:'SUCURSALEMPLEADOHEADLINEID',pic:'ZZZ9'},{av:'dynsucursalEmpleadoAlternateId'},{av:'A4sucursalEmpleadoAlternateId',fld:'SUCURSALEMPLEADOALTERNATEID',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_SUCURSALNAME","{handler:'Valid_Sucursalname',iparms:[{av:'dynsucursalEmpleadoHeadlineId'},{av:'A3sucursalEmpleadoHeadlineId',fld:'SUCURSALEMPLEADOHEADLINEID',pic:'ZZZ9'},{av:'dynsucursalEmpleadoAlternateId'},{av:'A4sucursalEmpleadoAlternateId',fld:'SUCURSALEMPLEADOALTERNATEID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_SUCURSALNAME",",oparms:[{av:'dynsucursalEmpleadoHeadlineId'},{av:'A3sucursalEmpleadoHeadlineId',fld:'SUCURSALEMPLEADOHEADLINEID',pic:'ZZZ9'},{av:'dynsucursalEmpleadoAlternateId'},{av:'A4sucursalEmpleadoAlternateId',fld:'SUCURSALEMPLEADOALTERNATEID',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_SUCURSALADDRESS","{handler:'Valid_Sucursaladdress',iparms:[{av:'dynsucursalEmpleadoHeadlineId'},{av:'A3sucursalEmpleadoHeadlineId',fld:'SUCURSALEMPLEADOHEADLINEID',pic:'ZZZ9'},{av:'dynsucursalEmpleadoAlternateId'},{av:'A4sucursalEmpleadoAlternateId',fld:'SUCURSALEMPLEADOALTERNATEID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_SUCURSALADDRESS",",oparms:[{av:'dynsucursalEmpleadoHeadlineId'},{av:'A3sucursalEmpleadoHeadlineId',fld:'SUCURSALEMPLEADOHEADLINEID',pic:'ZZZ9'},{av:'dynsucursalEmpleadoAlternateId'},{av:'A4sucursalEmpleadoAlternateId',fld:'SUCURSALEMPLEADOALTERNATEID',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_SUCURSALEMPLEADOHEADLINEID","{handler:'Valid_Sucursalempleadoheadlineid',iparms:[{av:'A19sucursalEmpleadoHeadlineName',fld:'SUCURSALEMPLEADOHEADLINENAME',pic:''},{av:'dynsucursalEmpleadoHeadlineId'},{av:'A3sucursalEmpleadoHeadlineId',fld:'SUCURSALEMPLEADOHEADLINEID',pic:'ZZZ9'},{av:'dynsucursalEmpleadoAlternateId'},{av:'A4sucursalEmpleadoAlternateId',fld:'SUCURSALEMPLEADOALTERNATEID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_SUCURSALEMPLEADOHEADLINEID",",oparms:[{av:'A19sucursalEmpleadoHeadlineName',fld:'SUCURSALEMPLEADOHEADLINENAME',pic:''},{av:'dynsucursalEmpleadoHeadlineId'},{av:'A3sucursalEmpleadoHeadlineId',fld:'SUCURSALEMPLEADOHEADLINEID',pic:'ZZZ9'},{av:'dynsucursalEmpleadoAlternateId'},{av:'A4sucursalEmpleadoAlternateId',fld:'SUCURSALEMPLEADOALTERNATEID',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_SUCURSALEMPLEADOALTERNATEID","{handler:'Valid_Sucursalempleadoalternateid',iparms:[{av:'A20sucursalEmpleadoAlternateName',fld:'SUCURSALEMPLEADOALTERNATENAME',pic:''},{av:'dynsucursalEmpleadoHeadlineId'},{av:'A3sucursalEmpleadoHeadlineId',fld:'SUCURSALEMPLEADOHEADLINEID',pic:'ZZZ9'},{av:'dynsucursalEmpleadoAlternateId'},{av:'A4sucursalEmpleadoAlternateId',fld:'SUCURSALEMPLEADOALTERNATEID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_SUCURSALEMPLEADOALTERNATEID",",oparms:[{av:'A20sucursalEmpleadoAlternateName',fld:'SUCURSALEMPLEADOALTERNATENAME',pic:''},{av:'dynsucursalEmpleadoHeadlineId'},{av:'A3sucursalEmpleadoHeadlineId',fld:'SUCURSALEMPLEADOHEADLINEID',pic:'ZZZ9'},{av:'dynsucursalEmpleadoAlternateId'},{av:'A4sucursalEmpleadoAlternateId',fld:'SUCURSALEMPLEADOALTERNATEID',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_PRODUCTOID","{handler:'Valid_Productoid',iparms:[{av:'A5productoId',fld:'PRODUCTOID',pic:'ZZZ9'},{av:'A25productoName',fld:'PRODUCTONAME',pic:''},{av:'dynsucursalEmpleadoHeadlineId'},{av:'A3sucursalEmpleadoHeadlineId',fld:'SUCURSALEMPLEADOHEADLINEID',pic:'ZZZ9'},{av:'dynsucursalEmpleadoAlternateId'},{av:'A4sucursalEmpleadoAlternateId',fld:'SUCURSALEMPLEADOALTERNATEID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_PRODUCTOID",",oparms:[{av:'A25productoName',fld:'PRODUCTONAME',pic:''},{av:'dynsucursalEmpleadoHeadlineId'},{av:'A3sucursalEmpleadoHeadlineId',fld:'SUCURSALEMPLEADOHEADLINEID',pic:'ZZZ9'},{av:'dynsucursalEmpleadoAlternateId'},{av:'A4sucursalEmpleadoAlternateId',fld:'SUCURSALEMPLEADOALTERNATEID',pic:'ZZZ9'}]}");
         setEventMetadata("NULL","{handler:'Valid_Productostock',iparms:[{av:'dynsucursalEmpleadoHeadlineId'},{av:'A3sucursalEmpleadoHeadlineId',fld:'SUCURSALEMPLEADOHEADLINEID',pic:'ZZZ9'},{av:'dynsucursalEmpleadoAlternateId'},{av:'A4sucursalEmpleadoAlternateId',fld:'SUCURSALEMPLEADOALTERNATEID',pic:'ZZZ9'}]");
         setEventMetadata("NULL",",oparms:[{av:'dynsucursalEmpleadoHeadlineId'},{av:'A3sucursalEmpleadoHeadlineId',fld:'SUCURSALEMPLEADOHEADLINEID',pic:'ZZZ9'},{av:'dynsucursalEmpleadoAlternateId'},{av:'A4sucursalEmpleadoAlternateId',fld:'SUCURSALEMPLEADOALTERNATEID',pic:'ZZZ9'}]}");
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
         pr_default.close(26);
         pr_default.close(4);
         pr_default.close(30);
         pr_default.close(16);
         pr_default.close(31);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z13sucursalName = "";
         Z14sucursalAddress = "";
         Z17sucursalGeolocation = "";
         Z18sucursalAddedDate = DateTime.MinValue;
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A13sucursalName = "";
         A14sucursalAddress = "";
         ucSucursalgeolocation = new GXUserControl();
         sucursalGeolocation = "";
         A18sucursalAddedDate = DateTime.MinValue;
         lblTitleproducto_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridsucursal_productoContainer = new GXWebGrid( context);
         sMode3 = "";
         sStyleString = "";
         A17sucursalGeolocation = "";
         Gx_date = DateTime.MinValue;
         A19sucursalEmpleadoHeadlineName = "";
         A20sucursalEmpleadoAlternateName = "";
         AV15Pgmname = "";
         Sucursalgeolocation_Objectcall = "";
         Sucursalgeolocation_Class = "";
         Sucursalgeolocation_Maptype = "";
         Sucursalgeolocation_Googleapikey = "";
         Sucursalgeolocation_Captionvalue = "";
         Sucursalgeolocation_Coltitle = "";
         Sucursalgeolocation_Coltitlefont = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode2 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A25productoName = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z19sucursalEmpleadoHeadlineName = "";
         Z20sucursalEmpleadoAlternateName = "";
         T00027_A19sucursalEmpleadoHeadlineName = new string[] {""} ;
         T00028_A20sucursalEmpleadoAlternateName = new string[] {""} ;
         T00029_A2sucursalId = new short[1] ;
         T00029_A13sucursalName = new string[] {""} ;
         T00029_A14sucursalAddress = new string[] {""} ;
         T00029_A17sucursalGeolocation = new string[] {""} ;
         T00029_A18sucursalAddedDate = new DateTime[] {DateTime.MinValue} ;
         T00029_A19sucursalEmpleadoHeadlineName = new string[] {""} ;
         T00029_A20sucursalEmpleadoAlternateName = new string[] {""} ;
         T00029_A3sucursalEmpleadoHeadlineId = new short[1] ;
         T00029_A4sucursalEmpleadoAlternateId = new short[1] ;
         T00029_n4sucursalEmpleadoAlternateId = new bool[] {false} ;
         T000210_A19sucursalEmpleadoHeadlineName = new string[] {""} ;
         T000211_A20sucursalEmpleadoAlternateName = new string[] {""} ;
         T000212_A2sucursalId = new short[1] ;
         T00026_A2sucursalId = new short[1] ;
         T00026_A13sucursalName = new string[] {""} ;
         T00026_A14sucursalAddress = new string[] {""} ;
         T00026_A17sucursalGeolocation = new string[] {""} ;
         T00026_A18sucursalAddedDate = new DateTime[] {DateTime.MinValue} ;
         T00026_A3sucursalEmpleadoHeadlineId = new short[1] ;
         T00026_A4sucursalEmpleadoAlternateId = new short[1] ;
         T00026_n4sucursalEmpleadoAlternateId = new bool[] {false} ;
         T000213_A2sucursalId = new short[1] ;
         T000214_A2sucursalId = new short[1] ;
         T00025_A2sucursalId = new short[1] ;
         T00025_A13sucursalName = new string[] {""} ;
         T00025_A14sucursalAddress = new string[] {""} ;
         T00025_A17sucursalGeolocation = new string[] {""} ;
         T00025_A18sucursalAddedDate = new DateTime[] {DateTime.MinValue} ;
         T00025_A3sucursalEmpleadoHeadlineId = new short[1] ;
         T00025_A4sucursalEmpleadoAlternateId = new short[1] ;
         T00025_n4sucursalEmpleadoAlternateId = new bool[] {false} ;
         T000215_A2sucursalId = new short[1] ;
         T000218_A19sucursalEmpleadoHeadlineName = new string[] {""} ;
         T000219_A20sucursalEmpleadoAlternateName = new string[] {""} ;
         T000220_A8facturaId = new short[1] ;
         T000221_A2sucursalId = new short[1] ;
         Z25productoName = "";
         T000222_A2sucursalId = new short[1] ;
         T000222_A25productoName = new string[] {""} ;
         T000222_A30productoStock = new long[1] ;
         T000222_A5productoId = new short[1] ;
         T00024_A25productoName = new string[] {""} ;
         T000223_A25productoName = new string[] {""} ;
         T000224_A2sucursalId = new short[1] ;
         T000224_A5productoId = new short[1] ;
         T00023_A2sucursalId = new short[1] ;
         T00023_A30productoStock = new long[1] ;
         T00023_A5productoId = new short[1] ;
         T00022_A2sucursalId = new short[1] ;
         T00022_A30productoStock = new long[1] ;
         T00022_A5productoId = new short[1] ;
         T000228_A25productoName = new string[] {""} ;
         T000229_A2sucursalId = new short[1] ;
         T000229_A5productoId = new short[1] ;
         Gridsucursal_productoRow = new GXWebRow();
         subGridsucursal_producto_Linesclass = "";
         ROClassString = "";
         imgprompt_5_gximage = "";
         sImgUrl = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i18sucursalAddedDate = DateTime.MinValue;
         Gridsucursal_productoColumn = new GXWebColumn();
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000230_A3sucursalEmpleadoHeadlineId = new short[1] ;
         T000230_A19sucursalEmpleadoHeadlineName = new string[] {""} ;
         T000231_A4sucursalEmpleadoAlternateId = new short[1] ;
         T000231_n4sucursalEmpleadoAlternateId = new bool[] {false} ;
         T000231_A20sucursalEmpleadoAlternateName = new string[] {""} ;
         T000232_A19sucursalEmpleadoHeadlineName = new string[] {""} ;
         T000233_A20sucursalEmpleadoAlternateName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sucursal__default(),
            new Object[][] {
                new Object[] {
               T00022_A2sucursalId, T00022_A30productoStock, T00022_A5productoId
               }
               , new Object[] {
               T00023_A2sucursalId, T00023_A30productoStock, T00023_A5productoId
               }
               , new Object[] {
               T00024_A25productoName
               }
               , new Object[] {
               T00025_A2sucursalId, T00025_A13sucursalName, T00025_A14sucursalAddress, T00025_A17sucursalGeolocation, T00025_A18sucursalAddedDate, T00025_A3sucursalEmpleadoHeadlineId, T00025_A4sucursalEmpleadoAlternateId, T00025_n4sucursalEmpleadoAlternateId
               }
               , new Object[] {
               T00026_A2sucursalId, T00026_A13sucursalName, T00026_A14sucursalAddress, T00026_A17sucursalGeolocation, T00026_A18sucursalAddedDate, T00026_A3sucursalEmpleadoHeadlineId, T00026_A4sucursalEmpleadoAlternateId, T00026_n4sucursalEmpleadoAlternateId
               }
               , new Object[] {
               T00027_A19sucursalEmpleadoHeadlineName
               }
               , new Object[] {
               T00028_A20sucursalEmpleadoAlternateName
               }
               , new Object[] {
               T00029_A2sucursalId, T00029_A13sucursalName, T00029_A14sucursalAddress, T00029_A17sucursalGeolocation, T00029_A18sucursalAddedDate, T00029_A19sucursalEmpleadoHeadlineName, T00029_A20sucursalEmpleadoAlternateName, T00029_A3sucursalEmpleadoHeadlineId, T00029_A4sucursalEmpleadoAlternateId, T00029_n4sucursalEmpleadoAlternateId
               }
               , new Object[] {
               T000210_A19sucursalEmpleadoHeadlineName
               }
               , new Object[] {
               T000211_A20sucursalEmpleadoAlternateName
               }
               , new Object[] {
               T000212_A2sucursalId
               }
               , new Object[] {
               T000213_A2sucursalId
               }
               , new Object[] {
               T000214_A2sucursalId
               }
               , new Object[] {
               T000215_A2sucursalId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000218_A19sucursalEmpleadoHeadlineName
               }
               , new Object[] {
               T000219_A20sucursalEmpleadoAlternateName
               }
               , new Object[] {
               T000220_A8facturaId
               }
               , new Object[] {
               T000221_A2sucursalId
               }
               , new Object[] {
               T000222_A2sucursalId, T000222_A25productoName, T000222_A30productoStock, T000222_A5productoId
               }
               , new Object[] {
               T000223_A25productoName
               }
               , new Object[] {
               T000224_A2sucursalId, T000224_A5productoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000228_A25productoName
               }
               , new Object[] {
               T000229_A2sucursalId, T000229_A5productoId
               }
               , new Object[] {
               T000230_A3sucursalEmpleadoHeadlineId, T000230_A19sucursalEmpleadoHeadlineName
               }
               , new Object[] {
               T000231_A4sucursalEmpleadoAlternateId, T000231_A20sucursalEmpleadoAlternateName
               }
               , new Object[] {
               T000232_A19sucursalEmpleadoHeadlineName
               }
               , new Object[] {
               T000233_A20sucursalEmpleadoAlternateName
               }
            }
         );
         AV15Pgmname = "sucursal";
         Gx_date = DateTimeUtil.Today( context);
      }

      private short nIsMod_3 ;
      private short wcpOAV7sucursalId ;
      private short Z2sucursalId ;
      private short Z3sucursalEmpleadoHeadlineId ;
      private short Z4sucursalEmpleadoAlternateId ;
      private short N3sucursalEmpleadoHeadlineId ;
      private short N4sucursalEmpleadoAlternateId ;
      private short Z5productoId ;
      private short nRcdDeleted_3 ;
      private short nRcdExists_3 ;
      private short GxWebError ;
      private short A3sucursalEmpleadoHeadlineId ;
      private short A4sucursalEmpleadoAlternateId ;
      private short A5productoId ;
      private short AV7sucursalId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2sucursalId ;
      private short nBlankRcdCount3 ;
      private short RcdFound3 ;
      private short nBlankRcdUsr3 ;
      private short AV11Insert_sucursalEmpleadoHeadlineId ;
      private short AV12Insert_sucursalEmpleadoAlternateId ;
      private short RcdFound2 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_2 ;
      private short nIsDirty_3 ;
      private short subGridsucursal_producto_Backcolorstyle ;
      private short subGridsucursal_producto_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridsucursal_producto_Allowselection ;
      private short subGridsucursal_producto_Allowhovering ;
      private short subGridsucursal_producto_Allowcollapsing ;
      private short subGridsucursal_producto_Collapsed ;
      private int nRC_GXsfl_73 ;
      private int nGXsfl_73_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtsucursalId_Enabled ;
      private int edtsucursalName_Enabled ;
      private int edtsucursalAddress_Enabled ;
      private int edtsucursalAddedDate_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtproductoId_Enabled ;
      private int edtproductoName_Enabled ;
      private int edtproductoStock_Enabled ;
      private int fRowAdded ;
      private int Sucursalgeolocation_Mapzoom ;
      private int Sucursalgeolocation_Maxzoom ;
      private int Sucursalgeolocation_Minzoom ;
      private int Sucursalgeolocation_Coltitlecolor ;
      private int AV16GXV1 ;
      private int subGridsucursal_producto_Backcolor ;
      private int subGridsucursal_producto_Allbackcolor ;
      private int imgprompt_5_Visible ;
      private int defedtproductoId_Enabled ;
      private int idxLst ;
      private int subGridsucursal_producto_Selectedindex ;
      private int subGridsucursal_producto_Selectioncolor ;
      private int subGridsucursal_producto_Hoveringcolor ;
      private int gxdynajaxindex ;
      private long Z30productoStock ;
      private long GRIDSUCURSAL_PRODUCTO_nFirstRecordOnPage ;
      private long A30productoStock ;
      private string sPrefix ;
      private string sGXsfl_73_idx="0001" ;
      private string wcpOGx_mode ;
      private string Z17sucursalGeolocation ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtsucursalName_Internalname ;
      private string dynsucursalEmpleadoHeadlineId_Internalname ;
      private string dynsucursalEmpleadoAlternateId_Internalname ;
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
      private string edtsucursalId_Internalname ;
      private string edtsucursalId_Jsonclick ;
      private string edtsucursalName_Jsonclick ;
      private string edtsucursalAddress_Internalname ;
      private string Sucursalgeolocation_Internalname ;
      private string sucursalGeolocation ;
      private string Sucursalgeolocation_Captionclass ;
      private string Sucursalgeolocation_Captionstyle ;
      private string Sucursalgeolocation_Captionposition ;
      private string edtsucursalAddedDate_Internalname ;
      private string edtsucursalAddedDate_Jsonclick ;
      private string dynsucursalEmpleadoHeadlineId_Jsonclick ;
      private string dynsucursalEmpleadoAlternateId_Jsonclick ;
      private string divProductotable_Internalname ;
      private string lblTitleproducto_Internalname ;
      private string lblTitleproducto_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode3 ;
      private string edtproductoId_Internalname ;
      private string edtproductoName_Internalname ;
      private string edtproductoStock_Internalname ;
      private string imgprompt_5_Link ;
      private string sStyleString ;
      private string subGridsucursal_producto_Internalname ;
      private string A17sucursalGeolocation ;
      private string AV15Pgmname ;
      private string Sucursalgeolocation_Objectcall ;
      private string Sucursalgeolocation_Class ;
      private string Sucursalgeolocation_Maptype ;
      private string Sucursalgeolocation_Googleapikey ;
      private string Sucursalgeolocation_Captionvalue ;
      private string Sucursalgeolocation_Coltitle ;
      private string Sucursalgeolocation_Coltitlefont ;
      private string hsh ;
      private string sMode2 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string imgprompt_5_Internalname ;
      private string sGXsfl_73_fel_idx="0001" ;
      private string subGridsucursal_producto_Class ;
      private string subGridsucursal_producto_Linesclass ;
      private string ROClassString ;
      private string edtproductoId_Jsonclick ;
      private string imgprompt_5_gximage ;
      private string sImgUrl ;
      private string edtproductoName_Jsonclick ;
      private string edtproductoStock_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridsucursal_producto_Header ;
      private string gxwrpcisep ;
      private DateTime Z18sucursalAddedDate ;
      private DateTime A18sucursalAddedDate ;
      private DateTime Gx_date ;
      private DateTime i18sucursalAddedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n4sucursalEmpleadoAlternateId ;
      private bool wbErr ;
      private bool bGXsfl_73_Refreshing=false ;
      private bool Sucursalgeolocation_Enabled ;
      private bool Sucursalgeolocation_Isabstractlayoutcontrol ;
      private bool Sucursalgeolocation_Usercontroliscolumn ;
      private bool Sucursalgeolocation_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool gxdyncontrolsrefreshing ;
      private string Z13sucursalName ;
      private string Z14sucursalAddress ;
      private string A13sucursalName ;
      private string A14sucursalAddress ;
      private string A19sucursalEmpleadoHeadlineName ;
      private string A20sucursalEmpleadoAlternateName ;
      private string A25productoName ;
      private string Z19sucursalEmpleadoHeadlineName ;
      private string Z20sucursalEmpleadoAlternateName ;
      private string Z25productoName ;
      private IGxSession AV10WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridsucursal_productoContainer ;
      private GXWebRow Gridsucursal_productoRow ;
      private GXWebColumn Gridsucursal_productoColumn ;
      private GXUserControl ucSucursalgeolocation ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynsucursalEmpleadoHeadlineId ;
      private GXCombobox dynsucursalEmpleadoAlternateId ;
      private IDataStoreProvider pr_default ;
      private string[] T00027_A19sucursalEmpleadoHeadlineName ;
      private string[] T00028_A20sucursalEmpleadoAlternateName ;
      private short[] T00029_A2sucursalId ;
      private string[] T00029_A13sucursalName ;
      private string[] T00029_A14sucursalAddress ;
      private string[] T00029_A17sucursalGeolocation ;
      private DateTime[] T00029_A18sucursalAddedDate ;
      private string[] T00029_A19sucursalEmpleadoHeadlineName ;
      private string[] T00029_A20sucursalEmpleadoAlternateName ;
      private short[] T00029_A3sucursalEmpleadoHeadlineId ;
      private short[] T00029_A4sucursalEmpleadoAlternateId ;
      private bool[] T00029_n4sucursalEmpleadoAlternateId ;
      private string[] T000210_A19sucursalEmpleadoHeadlineName ;
      private string[] T000211_A20sucursalEmpleadoAlternateName ;
      private short[] T000212_A2sucursalId ;
      private short[] T00026_A2sucursalId ;
      private string[] T00026_A13sucursalName ;
      private string[] T00026_A14sucursalAddress ;
      private string[] T00026_A17sucursalGeolocation ;
      private DateTime[] T00026_A18sucursalAddedDate ;
      private short[] T00026_A3sucursalEmpleadoHeadlineId ;
      private short[] T00026_A4sucursalEmpleadoAlternateId ;
      private bool[] T00026_n4sucursalEmpleadoAlternateId ;
      private short[] T000213_A2sucursalId ;
      private short[] T000214_A2sucursalId ;
      private short[] T00025_A2sucursalId ;
      private string[] T00025_A13sucursalName ;
      private string[] T00025_A14sucursalAddress ;
      private string[] T00025_A17sucursalGeolocation ;
      private DateTime[] T00025_A18sucursalAddedDate ;
      private short[] T00025_A3sucursalEmpleadoHeadlineId ;
      private short[] T00025_A4sucursalEmpleadoAlternateId ;
      private bool[] T00025_n4sucursalEmpleadoAlternateId ;
      private short[] T000215_A2sucursalId ;
      private string[] T000218_A19sucursalEmpleadoHeadlineName ;
      private string[] T000219_A20sucursalEmpleadoAlternateName ;
      private short[] T000220_A8facturaId ;
      private short[] T000221_A2sucursalId ;
      private short[] T000222_A2sucursalId ;
      private string[] T000222_A25productoName ;
      private long[] T000222_A30productoStock ;
      private short[] T000222_A5productoId ;
      private string[] T00024_A25productoName ;
      private string[] T000223_A25productoName ;
      private short[] T000224_A2sucursalId ;
      private short[] T000224_A5productoId ;
      private short[] T00023_A2sucursalId ;
      private long[] T00023_A30productoStock ;
      private short[] T00023_A5productoId ;
      private short[] T00022_A2sucursalId ;
      private long[] T00022_A30productoStock ;
      private short[] T00022_A5productoId ;
      private string[] T000228_A25productoName ;
      private short[] T000229_A2sucursalId ;
      private short[] T000229_A5productoId ;
      private short[] T000230_A3sucursalEmpleadoHeadlineId ;
      private string[] T000230_A19sucursalEmpleadoHeadlineName ;
      private short[] T000231_A4sucursalEmpleadoAlternateId ;
      private bool[] T000231_n4sucursalEmpleadoAlternateId ;
      private string[] T000231_A20sucursalEmpleadoAlternateName ;
      private string[] T000232_A19sucursalEmpleadoHeadlineName ;
      private string[] T000233_A20sucursalEmpleadoAlternateName ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV13TrnContextAtt ;
   }

   public class sucursal__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new UpdateCursor(def[23])
         ,new UpdateCursor(def[24])
         ,new UpdateCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00029;
          prmT00029 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0)
          };
          Object[] prmT00027;
          prmT00027 = new Object[] {
          new ParDef("@sucursalEmpleadoHeadlineId",GXType.Int16,4,0)
          };
          Object[] prmT00028;
          prmT00028 = new Object[] {
          new ParDef("@sucursalEmpleadoAlternateId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000210;
          prmT000210 = new Object[] {
          new ParDef("@sucursalEmpleadoHeadlineId",GXType.Int16,4,0)
          };
          Object[] prmT000211;
          prmT000211 = new Object[] {
          new ParDef("@sucursalEmpleadoAlternateId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000212;
          prmT000212 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0)
          };
          Object[] prmT00026;
          prmT00026 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0)
          };
          Object[] prmT000213;
          prmT000213 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0)
          };
          Object[] prmT000214;
          prmT000214 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0)
          };
          Object[] prmT00025;
          prmT00025 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0)
          };
          Object[] prmT000215;
          prmT000215 = new Object[] {
          new ParDef("@sucursalName",GXType.NVarChar,40,0) ,
          new ParDef("@sucursalAddress",GXType.NVarChar,1024,0) ,
          new ParDef("@sucursalGeolocation",GXType.NChar,50,0) ,
          new ParDef("@sucursalAddedDate",GXType.Date,8,0) ,
          new ParDef("@sucursalEmpleadoHeadlineId",GXType.Int16,4,0) ,
          new ParDef("@sucursalEmpleadoAlternateId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000216;
          prmT000216 = new Object[] {
          new ParDef("@sucursalName",GXType.NVarChar,40,0) ,
          new ParDef("@sucursalAddress",GXType.NVarChar,1024,0) ,
          new ParDef("@sucursalGeolocation",GXType.NChar,50,0) ,
          new ParDef("@sucursalAddedDate",GXType.Date,8,0) ,
          new ParDef("@sucursalEmpleadoHeadlineId",GXType.Int16,4,0) ,
          new ParDef("@sucursalEmpleadoAlternateId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@sucursalId",GXType.Int16,4,0)
          };
          Object[] prmT000217;
          prmT000217 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0)
          };
          Object[] prmT000218;
          prmT000218 = new Object[] {
          new ParDef("@sucursalEmpleadoHeadlineId",GXType.Int16,4,0)
          };
          Object[] prmT000219;
          prmT000219 = new Object[] {
          new ParDef("@sucursalEmpleadoAlternateId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000220;
          prmT000220 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0)
          };
          Object[] prmT000221;
          prmT000221 = new Object[] {
          };
          Object[] prmT000222;
          prmT000222 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT00024;
          prmT00024 = new Object[] {
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT000223;
          prmT000223 = new Object[] {
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT000224;
          prmT000224 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT00023;
          prmT00023 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT00022;
          prmT00022 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT000225;
          prmT000225 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0) ,
          new ParDef("@productoStock",GXType.Decimal,10,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT000226;
          prmT000226 = new Object[] {
          new ParDef("@productoStock",GXType.Decimal,10,0) ,
          new ParDef("@sucursalId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT000227;
          prmT000227 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT000229;
          prmT000229 = new Object[] {
          new ParDef("@sucursalId",GXType.Int16,4,0)
          };
          Object[] prmT000230;
          prmT000230 = new Object[] {
          };
          Object[] prmT000231;
          prmT000231 = new Object[] {
          };
          Object[] prmT000232;
          prmT000232 = new Object[] {
          new ParDef("@sucursalEmpleadoHeadlineId",GXType.Int16,4,0)
          };
          Object[] prmT000233;
          prmT000233 = new Object[] {
          new ParDef("@sucursalEmpleadoAlternateId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000228;
          prmT000228 = new Object[] {
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00022", "SELECT [sucursalId], [productoStock], [productoId] FROM [sucursalproducto] WITH (UPDLOCK) WHERE [sucursalId] = @sucursalId AND [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00023", "SELECT [sucursalId], [productoStock], [productoId] FROM [sucursalproducto] WHERE [sucursalId] = @sucursalId AND [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00024", "SELECT [productoName] FROM [producto] WHERE [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00024,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00025", "SELECT [sucursalId], [sucursalName], [sucursalAddress], [sucursalGeolocation], [sucursalAddedDate], [sucursalEmpleadoHeadlineId] AS sucursalEmpleadoHeadlineId, [sucursalEmpleadoAlternateId] AS sucursalEmpleadoAlternateId FROM [sucursal] WITH (UPDLOCK) WHERE [sucursalId] = @sucursalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00025,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00026", "SELECT [sucursalId], [sucursalName], [sucursalAddress], [sucursalGeolocation], [sucursalAddedDate], [sucursalEmpleadoHeadlineId] AS sucursalEmpleadoHeadlineId, [sucursalEmpleadoAlternateId] AS sucursalEmpleadoAlternateId FROM [sucursal] WHERE [sucursalId] = @sucursalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00026,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00027", "SELECT [empleadoName] AS sucursalEmpleadoHeadlineName FROM [empleado] WHERE [empleadoId] = @sucursalEmpleadoHeadlineId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00027,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00028", "SELECT [empleadoName] AS sucursalEmpleadoAlternateName FROM [empleado] WHERE [empleadoId] = @sucursalEmpleadoAlternateId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00028,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00029", "SELECT TM1.[sucursalId], TM1.[sucursalName], TM1.[sucursalAddress], TM1.[sucursalGeolocation], TM1.[sucursalAddedDate], T2.[empleadoName] AS sucursalEmpleadoHeadlineName, T3.[empleadoName] AS sucursalEmpleadoAlternateName, TM1.[sucursalEmpleadoHeadlineId] AS sucursalEmpleadoHeadlineId, TM1.[sucursalEmpleadoAlternateId] AS sucursalEmpleadoAlternateId FROM (([sucursal] TM1 INNER JOIN [empleado] T2 ON T2.[empleadoId] = TM1.[sucursalEmpleadoHeadlineId]) LEFT JOIN [empleado] T3 ON T3.[empleadoId] = TM1.[sucursalEmpleadoAlternateId]) WHERE TM1.[sucursalId] = @sucursalId ORDER BY TM1.[sucursalId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00029,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000210", "SELECT [empleadoName] AS sucursalEmpleadoHeadlineName FROM [empleado] WHERE [empleadoId] = @sucursalEmpleadoHeadlineId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000210,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000211", "SELECT [empleadoName] AS sucursalEmpleadoAlternateName FROM [empleado] WHERE [empleadoId] = @sucursalEmpleadoAlternateId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000211,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000212", "SELECT [sucursalId] FROM [sucursal] WHERE [sucursalId] = @sucursalId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000212,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000213", "SELECT TOP 1 [sucursalId] FROM [sucursal] WHERE ( [sucursalId] > @sucursalId) ORDER BY [sucursalId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000213,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000214", "SELECT TOP 1 [sucursalId] FROM [sucursal] WHERE ( [sucursalId] < @sucursalId) ORDER BY [sucursalId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000214,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000215", "INSERT INTO [sucursal]([sucursalName], [sucursalAddress], [sucursalGeolocation], [sucursalAddedDate], [sucursalEmpleadoHeadlineId], [sucursalEmpleadoAlternateId]) VALUES(@sucursalName, @sucursalAddress, @sucursalGeolocation, @sucursalAddedDate, @sucursalEmpleadoHeadlineId, @sucursalEmpleadoAlternateId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000215,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000216", "UPDATE [sucursal] SET [sucursalName]=@sucursalName, [sucursalAddress]=@sucursalAddress, [sucursalGeolocation]=@sucursalGeolocation, [sucursalAddedDate]=@sucursalAddedDate, [sucursalEmpleadoHeadlineId]=@sucursalEmpleadoHeadlineId, [sucursalEmpleadoAlternateId]=@sucursalEmpleadoAlternateId  WHERE [sucursalId] = @sucursalId", GxErrorMask.GX_NOMASK,prmT000216)
             ,new CursorDef("T000217", "DELETE FROM [sucursal]  WHERE [sucursalId] = @sucursalId", GxErrorMask.GX_NOMASK,prmT000217)
             ,new CursorDef("T000218", "SELECT [empleadoName] AS sucursalEmpleadoHeadlineName FROM [empleado] WHERE [empleadoId] = @sucursalEmpleadoHeadlineId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000218,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000219", "SELECT [empleadoName] AS sucursalEmpleadoAlternateName FROM [empleado] WHERE [empleadoId] = @sucursalEmpleadoAlternateId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000219,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000220", "SELECT TOP 1 [facturaId] FROM [factura] WHERE [sucursalId] = @sucursalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000220,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000221", "SELECT [sucursalId] FROM [sucursal] ORDER BY [sucursalId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000221,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000222", "SELECT T1.[sucursalId], T2.[productoName], T1.[productoStock], T1.[productoId] FROM ([sucursalproducto] T1 INNER JOIN [producto] T2 ON T2.[productoId] = T1.[productoId]) WHERE T1.[sucursalId] = @sucursalId and T1.[productoId] = @productoId ORDER BY T1.[sucursalId], T1.[productoId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000222,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000223", "SELECT [productoName] FROM [producto] WHERE [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000223,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000224", "SELECT [sucursalId], [productoId] FROM [sucursalproducto] WHERE [sucursalId] = @sucursalId AND [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000224,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000225", "INSERT INTO [sucursalproducto]([sucursalId], [productoStock], [productoId]) VALUES(@sucursalId, @productoStock, @productoId)", GxErrorMask.GX_NOMASK,prmT000225)
             ,new CursorDef("T000226", "UPDATE [sucursalproducto] SET [productoStock]=@productoStock  WHERE [sucursalId] = @sucursalId AND [productoId] = @productoId", GxErrorMask.GX_NOMASK,prmT000226)
             ,new CursorDef("T000227", "DELETE FROM [sucursalproducto]  WHERE [sucursalId] = @sucursalId AND [productoId] = @productoId", GxErrorMask.GX_NOMASK,prmT000227)
             ,new CursorDef("T000228", "SELECT [productoName] FROM [producto] WHERE [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000228,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000229", "SELECT [sucursalId], [productoId] FROM [sucursalproducto] WHERE [sucursalId] = @sucursalId ORDER BY [sucursalId], [productoId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000229,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000230", "SELECT [empleadoId] AS sucursalEmpleadoHeadlineId, [empleadoName] AS sucursalEmpleadoHeadlineName FROM [empleado] ORDER BY [empleadoName] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000230,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000231", "SELECT [empleadoId] AS sucursalEmpleadoAlternateId, [empleadoName] AS sucursalEmpleadoAlternateName FROM [empleado] ORDER BY [empleadoName] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000231,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000232", "SELECT [empleadoName] AS sucursalEmpleadoHeadlineName FROM [empleado] WHERE [empleadoId] = @sucursalEmpleadoHeadlineId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000232,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000233", "SELECT [empleadoName] AS sucursalEmpleadoAlternateName FROM [empleado] WHERE [empleadoId] = @sucursalEmpleadoAlternateId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000233,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 20 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 22 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 26 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 27 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 28 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 29 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 31 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
       }
    }

 }

}
