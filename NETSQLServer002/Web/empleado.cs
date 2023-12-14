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
   public class empleado : GXDataArea
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
               AV7empleadoId = (short)(Math.Round(NumberUtil.Val( GetPar( "empleadoId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7empleadoId", StringUtil.LTrimStr( (decimal)(AV7empleadoId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vEMPLEADOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7empleadoId), "ZZZ9"), context));
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
            Form.Meta.addItem("description", "empleado", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtempleadoName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("xd2", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public empleado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("xd2", true);
      }

      public empleado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_empleadoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7empleadoId = aP1_empleadoId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Empleado", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_empleado.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_empleado.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_empleado.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_empleado.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_empleado.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_empleado.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtempleadoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtempleadoId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtempleadoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1empleadoId), 4, 0, ",", "")), StringUtil.LTrim( ((edtempleadoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1empleadoId), "ZZZ9") : context.localUtil.Format( (decimal)(A1empleadoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtempleadoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtempleadoId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_empleado.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtempleadoName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtempleadoName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtempleadoName_Internalname, A9empleadoName, StringUtil.RTrim( context.localUtil.Format( A9empleadoName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtempleadoName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtempleadoName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_empleado.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtempleadoCI_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtempleadoCI_Internalname, "CI", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtempleadoCI_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10empleadoCI), 8, 0, ",", "")), StringUtil.LTrim( ((edtempleadoCI_Enabled!=0) ? context.localUtil.Format( (decimal)(A10empleadoCI), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A10empleadoCI), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtempleadoCI_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtempleadoCI_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "CI", "right", false, "", "HLP_empleado.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtempleadoEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtempleadoEmail_Internalname, "Email", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtempleadoEmail_Internalname, A11empleadoEmail, StringUtil.RTrim( context.localUtil.Format( A11empleadoEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A11empleadoEmail, "", "", "", edtempleadoEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtempleadoEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "left", true, "", "HLP_empleado.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtempleadoPhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtempleadoPhone_Internalname, "Phone", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A12empleadoPhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtempleadoPhone_Internalname, StringUtil.RTrim( A12empleadoPhone), StringUtil.RTrim( context.localUtil.Format( A12empleadoPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtempleadoPhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtempleadoPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "left", true, "", "HLP_empleado.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_empleado.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_empleado.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_empleado.htm");
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
         E11012 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z1empleadoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z1empleadoId"), ",", "."), 18, MidpointRounding.ToEven));
               Z9empleadoName = cgiGet( "Z9empleadoName");
               Z10empleadoCI = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z10empleadoCI"), ",", "."), 18, MidpointRounding.ToEven));
               Z11empleadoEmail = cgiGet( "Z11empleadoEmail");
               Z12empleadoPhone = cgiGet( "Z12empleadoPhone");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7empleadoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vEMPLEADOID"), ",", "."), 18, MidpointRounding.ToEven));
               AV12Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A1empleadoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtempleadoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1empleadoId", StringUtil.LTrimStr( (decimal)(A1empleadoId), 4, 0));
               A9empleadoName = cgiGet( edtempleadoName_Internalname);
               AssignAttri("", false, "A9empleadoName", A9empleadoName);
               if ( ( ( context.localUtil.CToN( cgiGet( edtempleadoCI_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtempleadoCI_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPLEADOCI");
                  AnyError = 1;
                  GX_FocusControl = edtempleadoCI_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A10empleadoCI = 0;
                  AssignAttri("", false, "A10empleadoCI", StringUtil.LTrimStr( (decimal)(A10empleadoCI), 8, 0));
               }
               else
               {
                  A10empleadoCI = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtempleadoCI_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A10empleadoCI", StringUtil.LTrimStr( (decimal)(A10empleadoCI), 8, 0));
               }
               A11empleadoEmail = cgiGet( edtempleadoEmail_Internalname);
               AssignAttri("", false, "A11empleadoEmail", A11empleadoEmail);
               A12empleadoPhone = cgiGet( edtempleadoPhone_Internalname);
               AssignAttri("", false, "A12empleadoPhone", A12empleadoPhone);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"empleado");
               A1empleadoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtempleadoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1empleadoId", StringUtil.LTrimStr( (decimal)(A1empleadoId), 4, 0));
               forbiddenHiddens.Add("empleadoId", context.localUtil.Format( (decimal)(A1empleadoId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A1empleadoId != Z1empleadoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("empleado:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A1empleadoId = (short)(Math.Round(NumberUtil.Val( GetPar( "empleadoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A1empleadoId", StringUtil.LTrimStr( (decimal)(A1empleadoId), 4, 0));
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
                     sMode1 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode1;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound1 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_010( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "EMPLEADOID");
                        AnyError = 1;
                        GX_FocusControl = edtempleadoId_Internalname;
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
                           E11012 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12012 ();
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
            E12012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll011( ) ;
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
            DisableAttributes011( ) ;
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

      protected void CONFIRM_010( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls011( ) ;
            }
            else
            {
               CheckExtendedTable011( ) ;
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption010( )
      {
      }

      protected void E11012( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV12Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV12Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E12012( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwempleado.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z9empleadoName = T00013_A9empleadoName[0];
               Z10empleadoCI = T00013_A10empleadoCI[0];
               Z11empleadoEmail = T00013_A11empleadoEmail[0];
               Z12empleadoPhone = T00013_A12empleadoPhone[0];
            }
            else
            {
               Z9empleadoName = A9empleadoName;
               Z10empleadoCI = A10empleadoCI;
               Z11empleadoEmail = A11empleadoEmail;
               Z12empleadoPhone = A12empleadoPhone;
            }
         }
         if ( GX_JID == -7 )
         {
            Z1empleadoId = A1empleadoId;
            Z9empleadoName = A9empleadoName;
            Z10empleadoCI = A10empleadoCI;
            Z11empleadoEmail = A11empleadoEmail;
            Z12empleadoPhone = A12empleadoPhone;
         }
      }

      protected void standaloneNotModal( )
      {
         edtempleadoId_Enabled = 0;
         AssignProp("", false, edtempleadoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtempleadoId_Enabled), 5, 0), true);
         edtempleadoId_Enabled = 0;
         AssignProp("", false, edtempleadoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtempleadoId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7empleadoId) )
         {
            A1empleadoId = AV7empleadoId;
            AssignAttri("", false, "A1empleadoId", StringUtil.LTrimStr( (decimal)(A1empleadoId), 4, 0));
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

      protected void Load011( )
      {
         /* Using cursor T00014 */
         pr_default.execute(2, new Object[] {A1empleadoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound1 = 1;
            A9empleadoName = T00014_A9empleadoName[0];
            AssignAttri("", false, "A9empleadoName", A9empleadoName);
            A10empleadoCI = T00014_A10empleadoCI[0];
            AssignAttri("", false, "A10empleadoCI", StringUtil.LTrimStr( (decimal)(A10empleadoCI), 8, 0));
            A11empleadoEmail = T00014_A11empleadoEmail[0];
            AssignAttri("", false, "A11empleadoEmail", A11empleadoEmail);
            A12empleadoPhone = T00014_A12empleadoPhone[0];
            AssignAttri("", false, "A12empleadoPhone", A12empleadoPhone);
            ZM011( -7) ;
         }
         pr_default.close(2);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
         AV12Pgmname = "empleado";
         AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
      }

      protected void CheckExtendedTable011( )
      {
         nIsDirty_1 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV12Pgmname = "empleado";
         AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A9empleadoName)) )
         {
            GX_msglist.addItem("Falta el nombre", 1, "EMPLEADONAME");
            AnyError = 1;
            GX_FocusControl = edtempleadoName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (0==A10empleadoCI) )
         {
            GX_msglist.addItem("Falta la cedula", 1, "EMPLEADOCI");
            AnyError = 1;
            GX_FocusControl = edtempleadoCI_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A11empleadoEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("El valor de empleado Email no coincide con el patrón especificado", "OutOfRange", 1, "EMPLEADOEMAIL");
            AnyError = 1;
            GX_FocusControl = edtempleadoEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A11empleadoEmail)) && String.IsNullOrEmpty(StringUtil.RTrim( A12empleadoPhone)) )
         {
            GX_msglist.addItem("Falta el email o el telefono", 1, "EMPLEADOEMAIL");
            AnyError = 1;
            GX_FocusControl = edtempleadoEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors011( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey011( )
      {
         /* Using cursor T00015 */
         pr_default.execute(3, new Object[] {A1empleadoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00013 */
         pr_default.execute(1, new Object[] {A1empleadoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 7) ;
            RcdFound1 = 1;
            A1empleadoId = T00013_A1empleadoId[0];
            AssignAttri("", false, "A1empleadoId", StringUtil.LTrimStr( (decimal)(A1empleadoId), 4, 0));
            A9empleadoName = T00013_A9empleadoName[0];
            AssignAttri("", false, "A9empleadoName", A9empleadoName);
            A10empleadoCI = T00013_A10empleadoCI[0];
            AssignAttri("", false, "A10empleadoCI", StringUtil.LTrimStr( (decimal)(A10empleadoCI), 8, 0));
            A11empleadoEmail = T00013_A11empleadoEmail[0];
            AssignAttri("", false, "A11empleadoEmail", A11empleadoEmail);
            A12empleadoPhone = T00013_A12empleadoPhone[0];
            AssignAttri("", false, "A12empleadoPhone", A12empleadoPhone);
            Z1empleadoId = A1empleadoId;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound1 = 0;
         /* Using cursor T00016 */
         pr_default.execute(4, new Object[] {A1empleadoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00016_A1empleadoId[0] < A1empleadoId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00016_A1empleadoId[0] > A1empleadoId ) ) )
            {
               A1empleadoId = T00016_A1empleadoId[0];
               AssignAttri("", false, "A1empleadoId", StringUtil.LTrimStr( (decimal)(A1empleadoId), 4, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound1 = 0;
         /* Using cursor T00017 */
         pr_default.execute(5, new Object[] {A1empleadoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00017_A1empleadoId[0] > A1empleadoId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00017_A1empleadoId[0] < A1empleadoId ) ) )
            {
               A1empleadoId = T00017_A1empleadoId[0];
               AssignAttri("", false, "A1empleadoId", StringUtil.LTrimStr( (decimal)(A1empleadoId), 4, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtempleadoName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert011( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A1empleadoId != Z1empleadoId )
               {
                  A1empleadoId = Z1empleadoId;
                  AssignAttri("", false, "A1empleadoId", StringUtil.LTrimStr( (decimal)(A1empleadoId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "EMPLEADOID");
                  AnyError = 1;
                  GX_FocusControl = edtempleadoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtempleadoName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update011( ) ;
                  GX_FocusControl = edtempleadoName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1empleadoId != Z1empleadoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtempleadoName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert011( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "EMPLEADOID");
                     AnyError = 1;
                     GX_FocusControl = edtempleadoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtempleadoName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert011( ) ;
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
         if ( A1empleadoId != Z1empleadoId )
         {
            A1empleadoId = Z1empleadoId;
            AssignAttri("", false, "A1empleadoId", StringUtil.LTrimStr( (decimal)(A1empleadoId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "EMPLEADOID");
            AnyError = 1;
            GX_FocusControl = edtempleadoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtempleadoName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00012 */
            pr_default.execute(0, new Object[] {A1empleadoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"empleado"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z9empleadoName, T00012_A9empleadoName[0]) != 0 ) || ( Z10empleadoCI != T00012_A10empleadoCI[0] ) || ( StringUtil.StrCmp(Z11empleadoEmail, T00012_A11empleadoEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z12empleadoPhone, T00012_A12empleadoPhone[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z9empleadoName, T00012_A9empleadoName[0]) != 0 )
               {
                  GXUtil.WriteLog("empleado:[seudo value changed for attri]"+"empleadoName");
                  GXUtil.WriteLogRaw("Old: ",Z9empleadoName);
                  GXUtil.WriteLogRaw("Current: ",T00012_A9empleadoName[0]);
               }
               if ( Z10empleadoCI != T00012_A10empleadoCI[0] )
               {
                  GXUtil.WriteLog("empleado:[seudo value changed for attri]"+"empleadoCI");
                  GXUtil.WriteLogRaw("Old: ",Z10empleadoCI);
                  GXUtil.WriteLogRaw("Current: ",T00012_A10empleadoCI[0]);
               }
               if ( StringUtil.StrCmp(Z11empleadoEmail, T00012_A11empleadoEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("empleado:[seudo value changed for attri]"+"empleadoEmail");
                  GXUtil.WriteLogRaw("Old: ",Z11empleadoEmail);
                  GXUtil.WriteLogRaw("Current: ",T00012_A11empleadoEmail[0]);
               }
               if ( StringUtil.StrCmp(Z12empleadoPhone, T00012_A12empleadoPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("empleado:[seudo value changed for attri]"+"empleadoPhone");
                  GXUtil.WriteLogRaw("Old: ",Z12empleadoPhone);
                  GXUtil.WriteLogRaw("Current: ",T00012_A12empleadoPhone[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"empleado"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00018 */
                     pr_default.execute(6, new Object[] {A9empleadoName, A10empleadoCI, A11empleadoEmail, A12empleadoPhone});
                     A1empleadoId = T00018_A1empleadoId[0];
                     AssignAttri("", false, "A1empleadoId", StringUtil.LTrimStr( (decimal)(A1empleadoId), 4, 0));
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("empleado");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption010( ) ;
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
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00019 */
                     pr_default.execute(7, new Object[] {A9empleadoName, A10empleadoCI, A11empleadoEmail, A12empleadoPhone, A1empleadoId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("empleado");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"empleado"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
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
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
      }

      protected void delete( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000110 */
                  pr_default.execute(8, new Object[] {A1empleadoId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("empleado");
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
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel011( ) ;
         Gx_mode = sMode1;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV12Pgmname = "empleado";
            AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000111 */
            pr_default.execute(9, new Object[] {A1empleadoId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"sucursal"+" ("+"sucursal Empleado Alternate"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T000112 */
            pr_default.execute(10, new Object[] {A1empleadoId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"sucursal"+" ("+"sucursal Empleado Headline"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("empleado",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues010( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("empleado",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart011( )
      {
         /* Scan By routine */
         /* Using cursor T000113 */
         pr_default.execute(11);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound1 = 1;
            A1empleadoId = T000113_A1empleadoId[0];
            AssignAttri("", false, "A1empleadoId", StringUtil.LTrimStr( (decimal)(A1empleadoId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound1 = 1;
            A1empleadoId = T000113_A1empleadoId[0];
            AssignAttri("", false, "A1empleadoId", StringUtil.LTrimStr( (decimal)(A1empleadoId), 4, 0));
         }
      }

      protected void ScanEnd011( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
         edtempleadoId_Enabled = 0;
         AssignProp("", false, edtempleadoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtempleadoId_Enabled), 5, 0), true);
         edtempleadoName_Enabled = 0;
         AssignProp("", false, edtempleadoName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtempleadoName_Enabled), 5, 0), true);
         edtempleadoCI_Enabled = 0;
         AssignProp("", false, edtempleadoCI_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtempleadoCI_Enabled), 5, 0), true);
         edtempleadoEmail_Enabled = 0;
         AssignProp("", false, edtempleadoEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtempleadoEmail_Enabled), 5, 0), true);
         edtempleadoPhone_Enabled = 0;
         AssignProp("", false, edtempleadoPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtempleadoPhone_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues010( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("empleado.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7empleadoId,4,0))}, new string[] {"Gx_mode","empleadoId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"empleado");
         forbiddenHiddens.Add("empleadoId", context.localUtil.Format( (decimal)(A1empleadoId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("empleado:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z1empleadoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1empleadoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z9empleadoName", Z9empleadoName);
         GxWebStd.gx_hidden_field( context, "Z10empleadoCI", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10empleadoCI), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z11empleadoEmail", Z11empleadoEmail);
         GxWebStd.gx_hidden_field( context, "Z12empleadoPhone", StringUtil.RTrim( Z12empleadoPhone));
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
         GxWebStd.gx_hidden_field( context, "vEMPLEADOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7empleadoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vEMPLEADOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7empleadoId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV12Pgmname));
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
         return formatLink("empleado.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7empleadoId,4,0))}, new string[] {"Gx_mode","empleadoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "empleado" ;
      }

      public override string GetPgmdesc( )
      {
         return "empleado" ;
      }

      protected void InitializeNonKey011( )
      {
         A9empleadoName = "";
         AssignAttri("", false, "A9empleadoName", A9empleadoName);
         A10empleadoCI = 0;
         AssignAttri("", false, "A10empleadoCI", StringUtil.LTrimStr( (decimal)(A10empleadoCI), 8, 0));
         A11empleadoEmail = "";
         AssignAttri("", false, "A11empleadoEmail", A11empleadoEmail);
         A12empleadoPhone = "";
         AssignAttri("", false, "A12empleadoPhone", A12empleadoPhone);
         Z9empleadoName = "";
         Z10empleadoCI = 0;
         Z11empleadoEmail = "";
         Z12empleadoPhone = "";
      }

      protected void InitAll011( )
      {
         A1empleadoId = 0;
         AssignAttri("", false, "A1empleadoId", StringUtil.LTrimStr( (decimal)(A1empleadoId), 4, 0));
         InitializeNonKey011( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20233241857562", true, true);
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
         context.AddJavascriptSource("empleado.js", "?20233241857562", false, true);
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
         edtempleadoId_Internalname = "EMPLEADOID";
         edtempleadoName_Internalname = "EMPLEADONAME";
         edtempleadoCI_Internalname = "EMPLEADOCI";
         edtempleadoEmail_Internalname = "EMPLEADOEMAIL";
         edtempleadoPhone_Internalname = "EMPLEADOPHONE";
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
         Form.Caption = "empleado";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtempleadoPhone_Jsonclick = "";
         edtempleadoPhone_Enabled = 1;
         edtempleadoEmail_Jsonclick = "";
         edtempleadoEmail_Enabled = 1;
         edtempleadoCI_Jsonclick = "";
         edtempleadoCI_Enabled = 1;
         edtempleadoName_Jsonclick = "";
         edtempleadoName_Enabled = 1;
         edtempleadoId_Jsonclick = "";
         edtempleadoId_Enabled = 0;
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7empleadoId',fld:'vEMPLEADOID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7empleadoId',fld:'vEMPLEADOID',pic:'ZZZ9',hsh:true},{av:'A1empleadoId',fld:'EMPLEADOID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12012',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_EMPLEADOID","{handler:'Valid_Empleadoid',iparms:[]");
         setEventMetadata("VALID_EMPLEADOID",",oparms:[]}");
         setEventMetadata("VALID_EMPLEADONAME","{handler:'Valid_Empleadoname',iparms:[]");
         setEventMetadata("VALID_EMPLEADONAME",",oparms:[]}");
         setEventMetadata("VALID_EMPLEADOCI","{handler:'Valid_Empleadoci',iparms:[]");
         setEventMetadata("VALID_EMPLEADOCI",",oparms:[]}");
         setEventMetadata("VALID_EMPLEADOEMAIL","{handler:'Valid_Empleadoemail',iparms:[]");
         setEventMetadata("VALID_EMPLEADOEMAIL",",oparms:[]}");
         setEventMetadata("VALID_EMPLEADOPHONE","{handler:'Valid_Empleadophone',iparms:[]");
         setEventMetadata("VALID_EMPLEADOPHONE",",oparms:[]}");
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
         Z9empleadoName = "";
         Z11empleadoEmail = "";
         Z12empleadoPhone = "";
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
         A9empleadoName = "";
         A11empleadoEmail = "";
         gxphoneLink = "";
         A12empleadoPhone = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV12Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode1 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         T00014_A1empleadoId = new short[1] ;
         T00014_A9empleadoName = new string[] {""} ;
         T00014_A10empleadoCI = new int[1] ;
         T00014_A11empleadoEmail = new string[] {""} ;
         T00014_A12empleadoPhone = new string[] {""} ;
         T00015_A1empleadoId = new short[1] ;
         T00013_A1empleadoId = new short[1] ;
         T00013_A9empleadoName = new string[] {""} ;
         T00013_A10empleadoCI = new int[1] ;
         T00013_A11empleadoEmail = new string[] {""} ;
         T00013_A12empleadoPhone = new string[] {""} ;
         T00016_A1empleadoId = new short[1] ;
         T00017_A1empleadoId = new short[1] ;
         T00012_A1empleadoId = new short[1] ;
         T00012_A9empleadoName = new string[] {""} ;
         T00012_A10empleadoCI = new int[1] ;
         T00012_A11empleadoEmail = new string[] {""} ;
         T00012_A12empleadoPhone = new string[] {""} ;
         T00018_A1empleadoId = new short[1] ;
         T000111_A2sucursalId = new short[1] ;
         T000112_A2sucursalId = new short[1] ;
         T000113_A1empleadoId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.empleado__default(),
            new Object[][] {
                new Object[] {
               T00012_A1empleadoId, T00012_A9empleadoName, T00012_A10empleadoCI, T00012_A11empleadoEmail, T00012_A12empleadoPhone
               }
               , new Object[] {
               T00013_A1empleadoId, T00013_A9empleadoName, T00013_A10empleadoCI, T00013_A11empleadoEmail, T00013_A12empleadoPhone
               }
               , new Object[] {
               T00014_A1empleadoId, T00014_A9empleadoName, T00014_A10empleadoCI, T00014_A11empleadoEmail, T00014_A12empleadoPhone
               }
               , new Object[] {
               T00015_A1empleadoId
               }
               , new Object[] {
               T00016_A1empleadoId
               }
               , new Object[] {
               T00017_A1empleadoId
               }
               , new Object[] {
               T00018_A1empleadoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000111_A2sucursalId
               }
               , new Object[] {
               T000112_A2sucursalId
               }
               , new Object[] {
               T000113_A1empleadoId
               }
            }
         );
         AV12Pgmname = "empleado";
      }

      private short wcpOAV7empleadoId ;
      private short Z1empleadoId ;
      private short GxWebError ;
      private short AV7empleadoId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1empleadoId ;
      private short RcdFound1 ;
      private short GX_JID ;
      private short nIsDirty_1 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z10empleadoCI ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtempleadoId_Enabled ;
      private int edtempleadoName_Enabled ;
      private int A10empleadoCI ;
      private int edtempleadoCI_Enabled ;
      private int edtempleadoEmail_Enabled ;
      private int edtempleadoPhone_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z12empleadoPhone ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtempleadoName_Internalname ;
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
      private string edtempleadoId_Internalname ;
      private string edtempleadoId_Jsonclick ;
      private string edtempleadoName_Jsonclick ;
      private string edtempleadoCI_Internalname ;
      private string edtempleadoCI_Jsonclick ;
      private string edtempleadoEmail_Internalname ;
      private string edtempleadoEmail_Jsonclick ;
      private string edtempleadoPhone_Internalname ;
      private string gxphoneLink ;
      private string A12empleadoPhone ;
      private string edtempleadoPhone_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV12Pgmname ;
      private string hsh ;
      private string sMode1 ;
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
      private string Z9empleadoName ;
      private string Z11empleadoEmail ;
      private string A9empleadoName ;
      private string A11empleadoEmail ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00014_A1empleadoId ;
      private string[] T00014_A9empleadoName ;
      private int[] T00014_A10empleadoCI ;
      private string[] T00014_A11empleadoEmail ;
      private string[] T00014_A12empleadoPhone ;
      private short[] T00015_A1empleadoId ;
      private short[] T00013_A1empleadoId ;
      private string[] T00013_A9empleadoName ;
      private int[] T00013_A10empleadoCI ;
      private string[] T00013_A11empleadoEmail ;
      private string[] T00013_A12empleadoPhone ;
      private short[] T00016_A1empleadoId ;
      private short[] T00017_A1empleadoId ;
      private short[] T00012_A1empleadoId ;
      private string[] T00012_A9empleadoName ;
      private int[] T00012_A10empleadoCI ;
      private string[] T00012_A11empleadoEmail ;
      private string[] T00012_A12empleadoPhone ;
      private short[] T00018_A1empleadoId ;
      private short[] T000111_A2sucursalId ;
      private short[] T000112_A2sucursalId ;
      private short[] T000113_A1empleadoId ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
   }

   public class empleado__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[11])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00014;
          prmT00014 = new Object[] {
          new ParDef("@empleadoId",GXType.Int16,4,0)
          };
          Object[] prmT00015;
          prmT00015 = new Object[] {
          new ParDef("@empleadoId",GXType.Int16,4,0)
          };
          Object[] prmT00013;
          prmT00013 = new Object[] {
          new ParDef("@empleadoId",GXType.Int16,4,0)
          };
          Object[] prmT00016;
          prmT00016 = new Object[] {
          new ParDef("@empleadoId",GXType.Int16,4,0)
          };
          Object[] prmT00017;
          prmT00017 = new Object[] {
          new ParDef("@empleadoId",GXType.Int16,4,0)
          };
          Object[] prmT00012;
          prmT00012 = new Object[] {
          new ParDef("@empleadoId",GXType.Int16,4,0)
          };
          Object[] prmT00018;
          prmT00018 = new Object[] {
          new ParDef("@empleadoName",GXType.NVarChar,40,0) ,
          new ParDef("@empleadoCI",GXType.Int32,8,0) ,
          new ParDef("@empleadoEmail",GXType.NVarChar,100,0) ,
          new ParDef("@empleadoPhone",GXType.NChar,20,0)
          };
          Object[] prmT00019;
          prmT00019 = new Object[] {
          new ParDef("@empleadoName",GXType.NVarChar,40,0) ,
          new ParDef("@empleadoCI",GXType.Int32,8,0) ,
          new ParDef("@empleadoEmail",GXType.NVarChar,100,0) ,
          new ParDef("@empleadoPhone",GXType.NChar,20,0) ,
          new ParDef("@empleadoId",GXType.Int16,4,0)
          };
          Object[] prmT000110;
          prmT000110 = new Object[] {
          new ParDef("@empleadoId",GXType.Int16,4,0)
          };
          Object[] prmT000111;
          prmT000111 = new Object[] {
          new ParDef("@empleadoId",GXType.Int16,4,0)
          };
          Object[] prmT000112;
          prmT000112 = new Object[] {
          new ParDef("@empleadoId",GXType.Int16,4,0)
          };
          Object[] prmT000113;
          prmT000113 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00012", "SELECT [empleadoId], [empleadoName], [empleadoCI], [empleadoEmail], [empleadoPhone] FROM [empleado] WITH (UPDLOCK) WHERE [empleadoId] = @empleadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00013", "SELECT [empleadoId], [empleadoName], [empleadoCI], [empleadoEmail], [empleadoPhone] FROM [empleado] WHERE [empleadoId] = @empleadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00014", "SELECT TM1.[empleadoId], TM1.[empleadoName], TM1.[empleadoCI], TM1.[empleadoEmail], TM1.[empleadoPhone] FROM [empleado] TM1 WHERE TM1.[empleadoId] = @empleadoId ORDER BY TM1.[empleadoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00014,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00015", "SELECT [empleadoId] FROM [empleado] WHERE [empleadoId] = @empleadoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00015,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00016", "SELECT TOP 1 [empleadoId] FROM [empleado] WHERE ( [empleadoId] > @empleadoId) ORDER BY [empleadoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00016,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00017", "SELECT TOP 1 [empleadoId] FROM [empleado] WHERE ( [empleadoId] < @empleadoId) ORDER BY [empleadoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00017,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00018", "INSERT INTO [empleado]([empleadoName], [empleadoCI], [empleadoEmail], [empleadoPhone]) VALUES(@empleadoName, @empleadoCI, @empleadoEmail, @empleadoPhone); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT00018,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00019", "UPDATE [empleado] SET [empleadoName]=@empleadoName, [empleadoCI]=@empleadoCI, [empleadoEmail]=@empleadoEmail, [empleadoPhone]=@empleadoPhone  WHERE [empleadoId] = @empleadoId", GxErrorMask.GX_NOMASK,prmT00019)
             ,new CursorDef("T000110", "DELETE FROM [empleado]  WHERE [empleadoId] = @empleadoId", GxErrorMask.GX_NOMASK,prmT000110)
             ,new CursorDef("T000111", "SELECT TOP 1 [sucursalId] FROM [sucursal] WHERE [sucursalEmpleadoAlternateId] = @empleadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000111,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000112", "SELECT TOP 1 [sucursalId] FROM [sucursal] WHERE [sucursalEmpleadoHeadlineId] = @empleadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000112,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000113", "SELECT [empleadoId] FROM [empleado] ORDER BY [empleadoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000113,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
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
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
