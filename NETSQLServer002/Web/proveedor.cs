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
   public class proveedor : GXDataArea
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
               AV7proveedorId = (short)(Math.Round(NumberUtil.Val( GetPar( "proveedorId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7proveedorId", StringUtil.LTrimStr( (decimal)(AV7proveedorId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7proveedorId), "ZZZ9"), context));
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
            Form.Meta.addItem("description", "proveedor", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtproveedorName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("xd2", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public proveedor( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("xd2", true);
      }

      public proveedor( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_proveedorId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7proveedorId = aP1_proveedorId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Proveedor", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_proveedor.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_proveedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_proveedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_proveedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_proveedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_proveedor.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtproveedorId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtproveedorId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtproveedorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7proveedorId), 4, 0, ",", "")), StringUtil.LTrim( ((edtproveedorId_Enabled!=0) ? context.localUtil.Format( (decimal)(A7proveedorId), "ZZZ9") : context.localUtil.Format( (decimal)(A7proveedorId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtproveedorId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtproveedorId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_proveedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtproveedorName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtproveedorName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtproveedorName_Internalname, A21proveedorName, StringUtil.RTrim( context.localUtil.Format( A21proveedorName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtproveedorName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtproveedorName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_proveedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtproveedorAddress_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtproveedorAddress_Internalname, "Address", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtproveedorAddress_Internalname, A22proveedorAddress, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A22proveedorAddress), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtproveedorAddress_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_proveedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtproveedorPhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtproveedorPhone_Internalname, "Phone", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A23proveedorPhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtproveedorPhone_Internalname, StringUtil.RTrim( A23proveedorPhone), StringUtil.RTrim( context.localUtil.Format( A23proveedorPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtproveedorPhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtproveedorPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "left", true, "", "HLP_proveedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtproveedorEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtproveedorEmail_Internalname, "Email", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtproveedorEmail_Internalname, A24proveedorEmail, StringUtil.RTrim( context.localUtil.Format( A24proveedorEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A24proveedorEmail, "", "", "", edtproveedorEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtproveedorEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "left", true, "", "HLP_proveedor.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_proveedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_proveedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_proveedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Right", "Middle", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         E11062 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z7proveedorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z7proveedorId"), ",", "."), 18, MidpointRounding.ToEven));
               Z21proveedorName = cgiGet( "Z21proveedorName");
               Z22proveedorAddress = cgiGet( "Z22proveedorAddress");
               Z23proveedorPhone = cgiGet( "Z23proveedorPhone");
               Z24proveedorEmail = cgiGet( "Z24proveedorEmail");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7proveedorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vPROVEEDORID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A7proveedorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtproveedorId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A7proveedorId", StringUtil.LTrimStr( (decimal)(A7proveedorId), 4, 0));
               A21proveedorName = cgiGet( edtproveedorName_Internalname);
               AssignAttri("", false, "A21proveedorName", A21proveedorName);
               A22proveedorAddress = cgiGet( edtproveedorAddress_Internalname);
               AssignAttri("", false, "A22proveedorAddress", A22proveedorAddress);
               A23proveedorPhone = cgiGet( edtproveedorPhone_Internalname);
               AssignAttri("", false, "A23proveedorPhone", A23proveedorPhone);
               A24proveedorEmail = cgiGet( edtproveedorEmail_Internalname);
               AssignAttri("", false, "A24proveedorEmail", A24proveedorEmail);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"proveedor");
               A7proveedorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtproveedorId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A7proveedorId", StringUtil.LTrimStr( (decimal)(A7proveedorId), 4, 0));
               forbiddenHiddens.Add("proveedorId", context.localUtil.Format( (decimal)(A7proveedorId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A7proveedorId != Z7proveedorId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("proveedor:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A7proveedorId = (short)(Math.Round(NumberUtil.Val( GetPar( "proveedorId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A7proveedorId", StringUtil.LTrimStr( (decimal)(A7proveedorId), 4, 0));
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
                     sMode8 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode8;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound8 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_060( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PROVEEDORID");
                        AnyError = 1;
                        GX_FocusControl = edtproveedorId_Internalname;
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
                           E11062 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12062 ();
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
            E12062 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll068( ) ;
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
            DisableAttributes068( ) ;
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

      protected void CONFIRM_060( )
      {
         BeforeValidate068( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls068( ) ;
            }
            else
            {
               CheckExtendedTable068( ) ;
               CloseExtendedTableCursors068( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption060( )
      {
      }

      protected void E11062( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV11Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E12062( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwproveedor.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM068( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z21proveedorName = T00063_A21proveedorName[0];
               Z22proveedorAddress = T00063_A22proveedorAddress[0];
               Z23proveedorPhone = T00063_A23proveedorPhone[0];
               Z24proveedorEmail = T00063_A24proveedorEmail[0];
            }
            else
            {
               Z21proveedorName = A21proveedorName;
               Z22proveedorAddress = A22proveedorAddress;
               Z23proveedorPhone = A23proveedorPhone;
               Z24proveedorEmail = A24proveedorEmail;
            }
         }
         if ( GX_JID == -4 )
         {
            Z7proveedorId = A7proveedorId;
            Z21proveedorName = A21proveedorName;
            Z22proveedorAddress = A22proveedorAddress;
            Z23proveedorPhone = A23proveedorPhone;
            Z24proveedorEmail = A24proveedorEmail;
         }
      }

      protected void standaloneNotModal( )
      {
         edtproveedorId_Enabled = 0;
         AssignProp("", false, edtproveedorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproveedorId_Enabled), 5, 0), true);
         edtproveedorId_Enabled = 0;
         AssignProp("", false, edtproveedorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproveedorId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7proveedorId) )
         {
            A7proveedorId = AV7proveedorId;
            AssignAttri("", false, "A7proveedorId", StringUtil.LTrimStr( (decimal)(A7proveedorId), 4, 0));
         }
      }

      protected void standaloneModal( )
      {
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
      }

      protected void Load068( )
      {
         /* Using cursor T00064 */
         pr_default.execute(2, new Object[] {A7proveedorId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound8 = 1;
            A21proveedorName = T00064_A21proveedorName[0];
            AssignAttri("", false, "A21proveedorName", A21proveedorName);
            A22proveedorAddress = T00064_A22proveedorAddress[0];
            AssignAttri("", false, "A22proveedorAddress", A22proveedorAddress);
            A23proveedorPhone = T00064_A23proveedorPhone[0];
            AssignAttri("", false, "A23proveedorPhone", A23proveedorPhone);
            A24proveedorEmail = T00064_A24proveedorEmail[0];
            AssignAttri("", false, "A24proveedorEmail", A24proveedorEmail);
            ZM068( -4) ;
         }
         pr_default.close(2);
         OnLoadActions068( ) ;
      }

      protected void OnLoadActions068( )
      {
         AV11Pgmname = "proveedor";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
      }

      protected void CheckExtendedTable068( )
      {
         nIsDirty_8 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV11Pgmname = "proveedor";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         if ( ! ( GxRegex.IsMatch(A24proveedorEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("El valor de proveedor Email no coincide con el patrón especificado", "OutOfRange", 1, "PROVEEDOREMAIL");
            AnyError = 1;
            GX_FocusControl = edtproveedorEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors068( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey068( )
      {
         /* Using cursor T00065 */
         pr_default.execute(3, new Object[] {A7proveedorId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00063 */
         pr_default.execute(1, new Object[] {A7proveedorId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM068( 4) ;
            RcdFound8 = 1;
            A7proveedorId = T00063_A7proveedorId[0];
            AssignAttri("", false, "A7proveedorId", StringUtil.LTrimStr( (decimal)(A7proveedorId), 4, 0));
            A21proveedorName = T00063_A21proveedorName[0];
            AssignAttri("", false, "A21proveedorName", A21proveedorName);
            A22proveedorAddress = T00063_A22proveedorAddress[0];
            AssignAttri("", false, "A22proveedorAddress", A22proveedorAddress);
            A23proveedorPhone = T00063_A23proveedorPhone[0];
            AssignAttri("", false, "A23proveedorPhone", A23proveedorPhone);
            A24proveedorEmail = T00063_A24proveedorEmail[0];
            AssignAttri("", false, "A24proveedorEmail", A24proveedorEmail);
            Z7proveedorId = A7proveedorId;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load068( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey068( ) ;
            }
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey068( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey068( ) ;
         if ( RcdFound8 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound8 = 0;
         /* Using cursor T00066 */
         pr_default.execute(4, new Object[] {A7proveedorId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00066_A7proveedorId[0] < A7proveedorId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00066_A7proveedorId[0] > A7proveedorId ) ) )
            {
               A7proveedorId = T00066_A7proveedorId[0];
               AssignAttri("", false, "A7proveedorId", StringUtil.LTrimStr( (decimal)(A7proveedorId), 4, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound8 = 0;
         /* Using cursor T00067 */
         pr_default.execute(5, new Object[] {A7proveedorId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00067_A7proveedorId[0] > A7proveedorId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00067_A7proveedorId[0] < A7proveedorId ) ) )
            {
               A7proveedorId = T00067_A7proveedorId[0];
               AssignAttri("", false, "A7proveedorId", StringUtil.LTrimStr( (decimal)(A7proveedorId), 4, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey068( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtproveedorName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert068( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( A7proveedorId != Z7proveedorId )
               {
                  A7proveedorId = Z7proveedorId;
                  AssignAttri("", false, "A7proveedorId", StringUtil.LTrimStr( (decimal)(A7proveedorId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROVEEDORID");
                  AnyError = 1;
                  GX_FocusControl = edtproveedorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtproveedorName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update068( ) ;
                  GX_FocusControl = edtproveedorName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A7proveedorId != Z7proveedorId )
               {
                  /* Insert record */
                  GX_FocusControl = edtproveedorName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert068( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROVEEDORID");
                     AnyError = 1;
                     GX_FocusControl = edtproveedorId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtproveedorName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert068( ) ;
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
         if ( A7proveedorId != Z7proveedorId )
         {
            A7proveedorId = Z7proveedorId;
            AssignAttri("", false, "A7proveedorId", StringUtil.LTrimStr( (decimal)(A7proveedorId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROVEEDORID");
            AnyError = 1;
            GX_FocusControl = edtproveedorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtproveedorName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency068( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00062 */
            pr_default.execute(0, new Object[] {A7proveedorId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"proveedor"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z21proveedorName, T00062_A21proveedorName[0]) != 0 ) || ( StringUtil.StrCmp(Z22proveedorAddress, T00062_A22proveedorAddress[0]) != 0 ) || ( StringUtil.StrCmp(Z23proveedorPhone, T00062_A23proveedorPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z24proveedorEmail, T00062_A24proveedorEmail[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z21proveedorName, T00062_A21proveedorName[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"proveedorName");
                  GXUtil.WriteLogRaw("Old: ",Z21proveedorName);
                  GXUtil.WriteLogRaw("Current: ",T00062_A21proveedorName[0]);
               }
               if ( StringUtil.StrCmp(Z22proveedorAddress, T00062_A22proveedorAddress[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"proveedorAddress");
                  GXUtil.WriteLogRaw("Old: ",Z22proveedorAddress);
                  GXUtil.WriteLogRaw("Current: ",T00062_A22proveedorAddress[0]);
               }
               if ( StringUtil.StrCmp(Z23proveedorPhone, T00062_A23proveedorPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"proveedorPhone");
                  GXUtil.WriteLogRaw("Old: ",Z23proveedorPhone);
                  GXUtil.WriteLogRaw("Current: ",T00062_A23proveedorPhone[0]);
               }
               if ( StringUtil.StrCmp(Z24proveedorEmail, T00062_A24proveedorEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"proveedorEmail");
                  GXUtil.WriteLogRaw("Old: ",Z24proveedorEmail);
                  GXUtil.WriteLogRaw("Current: ",T00062_A24proveedorEmail[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"proveedor"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert068( )
      {
         BeforeValidate068( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable068( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM068( 0) ;
            CheckOptimisticConcurrency068( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm068( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert068( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00068 */
                     pr_default.execute(6, new Object[] {A21proveedorName, A22proveedorAddress, A23proveedorPhone, A24proveedorEmail});
                     A7proveedorId = T00068_A7proveedorId[0];
                     AssignAttri("", false, "A7proveedorId", StringUtil.LTrimStr( (decimal)(A7proveedorId), 4, 0));
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("proveedor");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption060( ) ;
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
               Load068( ) ;
            }
            EndLevel068( ) ;
         }
         CloseExtendedTableCursors068( ) ;
      }

      protected void Update068( )
      {
         BeforeValidate068( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable068( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency068( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm068( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate068( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00069 */
                     pr_default.execute(7, new Object[] {A21proveedorName, A22proveedorAddress, A23proveedorPhone, A24proveedorEmail, A7proveedorId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("proveedor");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"proveedor"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate068( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
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
            EndLevel068( ) ;
         }
         CloseExtendedTableCursors068( ) ;
      }

      protected void DeferredUpdate068( )
      {
      }

      protected void delete( )
      {
         BeforeValidate068( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency068( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls068( ) ;
            AfterConfirm068( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete068( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000610 */
                  pr_default.execute(8, new Object[] {A7proveedorId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("proveedor");
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
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel068( ) ;
         Gx_mode = sMode8;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls068( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV11Pgmname = "proveedor";
            AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000611 */
            pr_default.execute(9, new Object[] {A7proveedorId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"producto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel068( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete068( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("proveedor",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues060( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("proveedor",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart068( )
      {
         /* Scan By routine */
         /* Using cursor T000612 */
         pr_default.execute(10);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound8 = 1;
            A7proveedorId = T000612_A7proveedorId[0];
            AssignAttri("", false, "A7proveedorId", StringUtil.LTrimStr( (decimal)(A7proveedorId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext068( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound8 = 1;
            A7proveedorId = T000612_A7proveedorId[0];
            AssignAttri("", false, "A7proveedorId", StringUtil.LTrimStr( (decimal)(A7proveedorId), 4, 0));
         }
      }

      protected void ScanEnd068( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm068( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert068( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate068( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete068( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete068( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate068( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes068( )
      {
         edtproveedorId_Enabled = 0;
         AssignProp("", false, edtproveedorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproveedorId_Enabled), 5, 0), true);
         edtproveedorName_Enabled = 0;
         AssignProp("", false, edtproveedorName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproveedorName_Enabled), 5, 0), true);
         edtproveedorAddress_Enabled = 0;
         AssignProp("", false, edtproveedorAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproveedorAddress_Enabled), 5, 0), true);
         edtproveedorPhone_Enabled = 0;
         AssignProp("", false, edtproveedorPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproveedorPhone_Enabled), 5, 0), true);
         edtproveedorEmail_Enabled = 0;
         AssignProp("", false, edtproveedorEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproveedorEmail_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes068( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues060( )
      {
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("proveedor.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7proveedorId,4,0))}, new string[] {"Gx_mode","proveedorId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"proveedor");
         forbiddenHiddens.Add("proveedorId", context.localUtil.Format( (decimal)(A7proveedorId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("proveedor:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z7proveedorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7proveedorId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z21proveedorName", Z21proveedorName);
         GxWebStd.gx_hidden_field( context, "Z22proveedorAddress", Z22proveedorAddress);
         GxWebStd.gx_hidden_field( context, "Z23proveedorPhone", StringUtil.RTrim( Z23proveedorPhone));
         GxWebStd.gx_hidden_field( context, "Z24proveedorEmail", Z24proveedorEmail);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
         GxWebStd.gx_hidden_field( context, "vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7proveedorId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7proveedorId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV11Pgmname));
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
         return formatLink("proveedor.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7proveedorId,4,0))}, new string[] {"Gx_mode","proveedorId"})  ;
      }

      public override string GetPgmname( )
      {
         return "proveedor" ;
      }

      public override string GetPgmdesc( )
      {
         return "proveedor" ;
      }

      protected void InitializeNonKey068( )
      {
         A21proveedorName = "";
         AssignAttri("", false, "A21proveedorName", A21proveedorName);
         A22proveedorAddress = "";
         AssignAttri("", false, "A22proveedorAddress", A22proveedorAddress);
         A23proveedorPhone = "";
         AssignAttri("", false, "A23proveedorPhone", A23proveedorPhone);
         A24proveedorEmail = "";
         AssignAttri("", false, "A24proveedorEmail", A24proveedorEmail);
         Z21proveedorName = "";
         Z22proveedorAddress = "";
         Z23proveedorPhone = "";
         Z24proveedorEmail = "";
      }

      protected void InitAll068( )
      {
         A7proveedorId = 0;
         AssignAttri("", false, "A7proveedorId", StringUtil.LTrimStr( (decimal)(A7proveedorId), 4, 0));
         InitializeNonKey068( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20233241858437", true, true);
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
         context.AddJavascriptSource("proveedor.js", "?20233241858437", false, true);
         /* End function include_jscripts */
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
         edtproveedorId_Internalname = "PROVEEDORID";
         edtproveedorName_Internalname = "PROVEEDORNAME";
         edtproveedorAddress_Internalname = "PROVEEDORADDRESS";
         edtproveedorPhone_Internalname = "PROVEEDORPHONE";
         edtproveedorEmail_Internalname = "PROVEEDOREMAIL";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("xd2", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "proveedor";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtproveedorEmail_Jsonclick = "";
         edtproveedorEmail_Enabled = 1;
         edtproveedorPhone_Jsonclick = "";
         edtproveedorPhone_Enabled = 1;
         edtproveedorAddress_Enabled = 1;
         edtproveedorName_Jsonclick = "";
         edtproveedorName_Enabled = 1;
         edtproveedorId_Jsonclick = "";
         edtproveedorId_Enabled = 0;
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

      protected void init_web_controls( )
      {
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7proveedorId',fld:'vPROVEEDORID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7proveedorId',fld:'vPROVEEDORID',pic:'ZZZ9',hsh:true},{av:'A7proveedorId',fld:'PROVEEDORID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12062',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORID","{handler:'Valid_Proveedorid',iparms:[]");
         setEventMetadata("VALID_PROVEEDORID",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDOREMAIL","{handler:'Valid_Proveedoremail',iparms:[]");
         setEventMetadata("VALID_PROVEEDOREMAIL",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z21proveedorName = "";
         Z22proveedorAddress = "";
         Z23proveedorPhone = "";
         Z24proveedorEmail = "";
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
         A21proveedorName = "";
         A22proveedorAddress = "";
         gxphoneLink = "";
         A23proveedorPhone = "";
         A24proveedorEmail = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV11Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode8 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         T00064_A7proveedorId = new short[1] ;
         T00064_A21proveedorName = new string[] {""} ;
         T00064_A22proveedorAddress = new string[] {""} ;
         T00064_A23proveedorPhone = new string[] {""} ;
         T00064_A24proveedorEmail = new string[] {""} ;
         T00065_A7proveedorId = new short[1] ;
         T00063_A7proveedorId = new short[1] ;
         T00063_A21proveedorName = new string[] {""} ;
         T00063_A22proveedorAddress = new string[] {""} ;
         T00063_A23proveedorPhone = new string[] {""} ;
         T00063_A24proveedorEmail = new string[] {""} ;
         T00066_A7proveedorId = new short[1] ;
         T00067_A7proveedorId = new short[1] ;
         T00062_A7proveedorId = new short[1] ;
         T00062_A21proveedorName = new string[] {""} ;
         T00062_A22proveedorAddress = new string[] {""} ;
         T00062_A23proveedorPhone = new string[] {""} ;
         T00062_A24proveedorEmail = new string[] {""} ;
         T00068_A7proveedorId = new short[1] ;
         T000611_A5productoId = new short[1] ;
         T000612_A7proveedorId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.proveedor__default(),
            new Object[][] {
                new Object[] {
               T00062_A7proveedorId, T00062_A21proveedorName, T00062_A22proveedorAddress, T00062_A23proveedorPhone, T00062_A24proveedorEmail
               }
               , new Object[] {
               T00063_A7proveedorId, T00063_A21proveedorName, T00063_A22proveedorAddress, T00063_A23proveedorPhone, T00063_A24proveedorEmail
               }
               , new Object[] {
               T00064_A7proveedorId, T00064_A21proveedorName, T00064_A22proveedorAddress, T00064_A23proveedorPhone, T00064_A24proveedorEmail
               }
               , new Object[] {
               T00065_A7proveedorId
               }
               , new Object[] {
               T00066_A7proveedorId
               }
               , new Object[] {
               T00067_A7proveedorId
               }
               , new Object[] {
               T00068_A7proveedorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000611_A5productoId
               }
               , new Object[] {
               T000612_A7proveedorId
               }
            }
         );
         AV11Pgmname = "proveedor";
      }

      private short wcpOAV7proveedorId ;
      private short Z7proveedorId ;
      private short GxWebError ;
      private short AV7proveedorId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A7proveedorId ;
      private short RcdFound8 ;
      private short GX_JID ;
      private short nIsDirty_8 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtproveedorId_Enabled ;
      private int edtproveedorName_Enabled ;
      private int edtproveedorAddress_Enabled ;
      private int edtproveedorPhone_Enabled ;
      private int edtproveedorEmail_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z23proveedorPhone ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtproveedorName_Internalname ;
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
      private string edtproveedorId_Internalname ;
      private string edtproveedorId_Jsonclick ;
      private string edtproveedorName_Jsonclick ;
      private string edtproveedorAddress_Internalname ;
      private string edtproveedorPhone_Internalname ;
      private string gxphoneLink ;
      private string A23proveedorPhone ;
      private string edtproveedorPhone_Jsonclick ;
      private string edtproveedorEmail_Internalname ;
      private string edtproveedorEmail_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV11Pgmname ;
      private string hsh ;
      private string sMode8 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool returnInSub ;
      private string Z21proveedorName ;
      private string Z22proveedorAddress ;
      private string Z24proveedorEmail ;
      private string A21proveedorName ;
      private string A22proveedorAddress ;
      private string A24proveedorEmail ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00064_A7proveedorId ;
      private string[] T00064_A21proveedorName ;
      private string[] T00064_A22proveedorAddress ;
      private string[] T00064_A23proveedorPhone ;
      private string[] T00064_A24proveedorEmail ;
      private short[] T00065_A7proveedorId ;
      private short[] T00063_A7proveedorId ;
      private string[] T00063_A21proveedorName ;
      private string[] T00063_A22proveedorAddress ;
      private string[] T00063_A23proveedorPhone ;
      private string[] T00063_A24proveedorEmail ;
      private short[] T00066_A7proveedorId ;
      private short[] T00067_A7proveedorId ;
      private short[] T00062_A7proveedorId ;
      private string[] T00062_A21proveedorName ;
      private string[] T00062_A22proveedorAddress ;
      private string[] T00062_A23proveedorPhone ;
      private string[] T00062_A24proveedorEmail ;
      private short[] T00068_A7proveedorId ;
      private short[] T000611_A5productoId ;
      private short[] T000612_A7proveedorId ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
   }

   public class proveedor__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00064;
          prmT00064 = new Object[] {
          new ParDef("@proveedorId",GXType.Int16,4,0)
          };
          Object[] prmT00065;
          prmT00065 = new Object[] {
          new ParDef("@proveedorId",GXType.Int16,4,0)
          };
          Object[] prmT00063;
          prmT00063 = new Object[] {
          new ParDef("@proveedorId",GXType.Int16,4,0)
          };
          Object[] prmT00066;
          prmT00066 = new Object[] {
          new ParDef("@proveedorId",GXType.Int16,4,0)
          };
          Object[] prmT00067;
          prmT00067 = new Object[] {
          new ParDef("@proveedorId",GXType.Int16,4,0)
          };
          Object[] prmT00062;
          prmT00062 = new Object[] {
          new ParDef("@proveedorId",GXType.Int16,4,0)
          };
          Object[] prmT00068;
          prmT00068 = new Object[] {
          new ParDef("@proveedorName",GXType.NVarChar,40,0) ,
          new ParDef("@proveedorAddress",GXType.NVarChar,1024,0) ,
          new ParDef("@proveedorPhone",GXType.NChar,20,0) ,
          new ParDef("@proveedorEmail",GXType.NVarChar,100,0)
          };
          Object[] prmT00069;
          prmT00069 = new Object[] {
          new ParDef("@proveedorName",GXType.NVarChar,40,0) ,
          new ParDef("@proveedorAddress",GXType.NVarChar,1024,0) ,
          new ParDef("@proveedorPhone",GXType.NChar,20,0) ,
          new ParDef("@proveedorEmail",GXType.NVarChar,100,0) ,
          new ParDef("@proveedorId",GXType.Int16,4,0)
          };
          Object[] prmT000610;
          prmT000610 = new Object[] {
          new ParDef("@proveedorId",GXType.Int16,4,0)
          };
          Object[] prmT000611;
          prmT000611 = new Object[] {
          new ParDef("@proveedorId",GXType.Int16,4,0)
          };
          Object[] prmT000612;
          prmT000612 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00062", "SELECT [proveedorId], [proveedorName], [proveedorAddress], [proveedorPhone], [proveedorEmail] FROM [proveedor] WITH (UPDLOCK) WHERE [proveedorId] = @proveedorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00062,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00063", "SELECT [proveedorId], [proveedorName], [proveedorAddress], [proveedorPhone], [proveedorEmail] FROM [proveedor] WHERE [proveedorId] = @proveedorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00063,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00064", "SELECT TM1.[proveedorId], TM1.[proveedorName], TM1.[proveedorAddress], TM1.[proveedorPhone], TM1.[proveedorEmail] FROM [proveedor] TM1 WHERE TM1.[proveedorId] = @proveedorId ORDER BY TM1.[proveedorId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00064,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00065", "SELECT [proveedorId] FROM [proveedor] WHERE [proveedorId] = @proveedorId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00065,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00066", "SELECT TOP 1 [proveedorId] FROM [proveedor] WHERE ( [proveedorId] > @proveedorId) ORDER BY [proveedorId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00066,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00067", "SELECT TOP 1 [proveedorId] FROM [proveedor] WHERE ( [proveedorId] < @proveedorId) ORDER BY [proveedorId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00067,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00068", "INSERT INTO [proveedor]([proveedorName], [proveedorAddress], [proveedorPhone], [proveedorEmail]) VALUES(@proveedorName, @proveedorAddress, @proveedorPhone, @proveedorEmail); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT00068,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00069", "UPDATE [proveedor] SET [proveedorName]=@proveedorName, [proveedorAddress]=@proveedorAddress, [proveedorPhone]=@proveedorPhone, [proveedorEmail]=@proveedorEmail  WHERE [proveedorId] = @proveedorId", GxErrorMask.GX_NOMASK,prmT00069)
             ,new CursorDef("T000610", "DELETE FROM [proveedor]  WHERE [proveedorId] = @proveedorId", GxErrorMask.GX_NOMASK,prmT000610)
             ,new CursorDef("T000611", "SELECT TOP 1 [productoId] FROM [producto] WHERE [proveedorId] = @proveedorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000611,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000612", "SELECT [proveedorId] FROM [proveedor] ORDER BY [proveedorId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000612,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
