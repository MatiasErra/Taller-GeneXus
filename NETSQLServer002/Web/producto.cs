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
   public class producto : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A7proveedorId = (short)(Math.Round(NumberUtil.Val( GetPar( "proveedorId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A7proveedorId", StringUtil.LTrimStr( (decimal)(A7proveedorId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A7proveedorId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A6tipoDeProductoId = (short)(Math.Round(NumberUtil.Val( GetPar( "tipoDeProductoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A6tipoDeProductoId", StringUtil.LTrimStr( (decimal)(A6tipoDeProductoId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A6tipoDeProductoId) ;
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
               AV7productoId = (short)(Math.Round(NumberUtil.Val( GetPar( "productoId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7productoId", StringUtil.LTrimStr( (decimal)(AV7productoId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPRODUCTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7productoId), "ZZZ9"), context));
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
            Form.Meta.addItem("description", "producto", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtproductoName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("xd2", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public producto( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("xd2", true);
      }

      public producto( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_productoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7productoId = aP1_productoId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynproveedorId = new GXCombobox();
         dyntipoDeProductoId = new GXCombobox();
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
         if ( dynproveedorId.ItemCount > 0 )
         {
            A7proveedorId = (short)(Math.Round(NumberUtil.Val( dynproveedorId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A7proveedorId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A7proveedorId", StringUtil.LTrimStr( (decimal)(A7proveedorId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynproveedorId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A7proveedorId), 4, 0));
            AssignProp("", false, dynproveedorId_Internalname, "Values", dynproveedorId.ToJavascriptSource(), true);
         }
         if ( dyntipoDeProductoId.ItemCount > 0 )
         {
            A6tipoDeProductoId = (short)(Math.Round(NumberUtil.Val( dyntipoDeProductoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A6tipoDeProductoId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A6tipoDeProductoId", StringUtil.LTrimStr( (decimal)(A6tipoDeProductoId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dyntipoDeProductoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A6tipoDeProductoId), 4, 0));
            AssignProp("", false, dyntipoDeProductoId_Internalname, "Values", dyntipoDeProductoId.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Producto", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_producto.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_producto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_producto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_producto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_producto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_producto.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtproductoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtproductoId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtproductoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A5productoId), 4, 0, ",", "")), StringUtil.LTrim( ((edtproductoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A5productoId), "ZZZ9") : context.localUtil.Format( (decimal)(A5productoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtproductoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtproductoId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_producto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtproductoName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtproductoName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtproductoName_Internalname, A25productoName, StringUtil.RTrim( context.localUtil.Format( A25productoName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtproductoName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtproductoName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_producto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgproductoImage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Image", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A26productoImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A26productoImage))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000productoImage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A26productoImage)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A26productoImage)) ? A40000productoImage_GXI : context.PathToRelativeUrl( A26productoImage));
         GxWebStd.gx_bitmap( context, imgproductoImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgproductoImage_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", "", "", 0, A26productoImage_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_producto.htm");
         AssignProp("", false, imgproductoImage_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A26productoImage)) ? A40000productoImage_GXI : context.PathToRelativeUrl( A26productoImage)), true);
         AssignProp("", false, imgproductoImage_Internalname, "IsBlob", StringUtil.BoolToStr( A26productoImage_IsBlob), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtproductoSellPrice_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtproductoSellPrice_Internalname, "Sell Price", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtproductoSellPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A27productoSellPrice, 10, 2, ",", "")), StringUtil.LTrim( ((edtproductoSellPrice_Enabled!=0) ? context.localUtil.Format( A27productoSellPrice, "ZZZZZZ9.99") : context.localUtil.Format( A27productoSellPrice, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtproductoSellPrice_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtproductoSellPrice_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_producto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtproductoCostPrice_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtproductoCostPrice_Internalname, "Cost Price", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtproductoCostPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A28productoCostPrice, 10, 2, ",", "")), StringUtil.LTrim( ((edtproductoCostPrice_Enabled!=0) ? context.localUtil.Format( A28productoCostPrice, "ZZZZZZ9.99") : context.localUtil.Format( A28productoCostPrice, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtproductoCostPrice_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtproductoCostPrice_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_producto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynproveedorId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynproveedorId_Internalname, "proveedor Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynproveedorId, dynproveedorId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A7proveedorId), 4, 0)), 1, dynproveedorId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynproveedorId.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "", true, 0, "HLP_producto.htm");
         dynproveedorId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A7proveedorId), 4, 0));
         AssignProp("", false, dynproveedorId_Internalname, "Values", (string)(dynproveedorId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dyntipoDeProductoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dyntipoDeProductoId_Internalname, "tipo De Producto Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dyntipoDeProductoId, dyntipoDeProductoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A6tipoDeProductoId), 4, 0)), 1, dyntipoDeProductoId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dyntipoDeProductoId.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "", true, 0, "HLP_producto.htm");
         dyntipoDeProductoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A6tipoDeProductoId), 4, 0));
         AssignProp("", false, dyntipoDeProductoId_Internalname, "Values", (string)(dyntipoDeProductoId.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_producto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_producto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_producto.htm");
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
         E11032 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z5productoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z5productoId"), ",", "."), 18, MidpointRounding.ToEven));
               Z25productoName = cgiGet( "Z25productoName");
               Z27productoSellPrice = context.localUtil.CToN( cgiGet( "Z27productoSellPrice"), ",", ".");
               Z28productoCostPrice = context.localUtil.CToN( cgiGet( "Z28productoCostPrice"), ",", ".");
               Z7proveedorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z7proveedorId"), ",", "."), 18, MidpointRounding.ToEven));
               Z6tipoDeProductoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z6tipoDeProductoId"), ",", "."), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N7proveedorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N7proveedorId"), ",", "."), 18, MidpointRounding.ToEven));
               N6tipoDeProductoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N6tipoDeProductoId"), ",", "."), 18, MidpointRounding.ToEven));
               AV7productoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vPRODUCTOID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_proveedorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PROVEEDORID"), ",", "."), 18, MidpointRounding.ToEven));
               AV12Insert_tipoDeProductoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_TIPODEPRODUCTOID"), ",", "."), 18, MidpointRounding.ToEven));
               A40000productoImage_GXI = cgiGet( "PRODUCTOIMAGE_GXI");
               A21proveedorName = cgiGet( "PROVEEDORNAME");
               A29tipoDeProductoName = cgiGet( "TIPODEPRODUCTONAME");
               AV14Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A5productoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtproductoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A5productoId", StringUtil.LTrimStr( (decimal)(A5productoId), 4, 0));
               A25productoName = cgiGet( edtproductoName_Internalname);
               AssignAttri("", false, "A25productoName", A25productoName);
               A26productoImage = cgiGet( imgproductoImage_Internalname);
               AssignAttri("", false, "A26productoImage", A26productoImage);
               if ( ( ( context.localUtil.CToN( cgiGet( edtproductoSellPrice_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtproductoSellPrice_Internalname), ",", ".") > 9999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTOSELLPRICE");
                  AnyError = 1;
                  GX_FocusControl = edtproductoSellPrice_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A27productoSellPrice = 0;
                  AssignAttri("", false, "A27productoSellPrice", StringUtil.LTrimStr( A27productoSellPrice, 10, 2));
               }
               else
               {
                  A27productoSellPrice = context.localUtil.CToN( cgiGet( edtproductoSellPrice_Internalname), ",", ".");
                  AssignAttri("", false, "A27productoSellPrice", StringUtil.LTrimStr( A27productoSellPrice, 10, 2));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtproductoCostPrice_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtproductoCostPrice_Internalname), ",", ".") > 9999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTOCOSTPRICE");
                  AnyError = 1;
                  GX_FocusControl = edtproductoCostPrice_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A28productoCostPrice = 0;
                  AssignAttri("", false, "A28productoCostPrice", StringUtil.LTrimStr( A28productoCostPrice, 10, 2));
               }
               else
               {
                  A28productoCostPrice = context.localUtil.CToN( cgiGet( edtproductoCostPrice_Internalname), ",", ".");
                  AssignAttri("", false, "A28productoCostPrice", StringUtil.LTrimStr( A28productoCostPrice, 10, 2));
               }
               dynproveedorId.CurrentValue = cgiGet( dynproveedorId_Internalname);
               A7proveedorId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynproveedorId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A7proveedorId", StringUtil.LTrimStr( (decimal)(A7proveedorId), 4, 0));
               dyntipoDeProductoId.CurrentValue = cgiGet( dyntipoDeProductoId_Internalname);
               A6tipoDeProductoId = (short)(Math.Round(NumberUtil.Val( cgiGet( dyntipoDeProductoId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A6tipoDeProductoId", StringUtil.LTrimStr( (decimal)(A6tipoDeProductoId), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgproductoImage_Internalname, ref  A26productoImage, ref  A40000productoImage_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"producto");
               A5productoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtproductoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A5productoId", StringUtil.LTrimStr( (decimal)(A5productoId), 4, 0));
               forbiddenHiddens.Add("productoId", context.localUtil.Format( (decimal)(A5productoId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A5productoId != Z5productoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("producto:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A5productoId = (short)(Math.Round(NumberUtil.Val( GetPar( "productoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A5productoId", StringUtil.LTrimStr( (decimal)(A5productoId), 4, 0));
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
                     sMode4 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode4;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound4 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_030( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PRODUCTOID");
                        AnyError = 1;
                        GX_FocusControl = edtproductoId_Internalname;
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
                           E11032 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12032 ();
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
            E12032 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll034( ) ;
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
            DisableAttributes034( ) ;
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
               CloseExtendedTableCursors034( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption030( )
      {
      }

      protected void E11032( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV14Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV14Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_proveedorId = 0;
         AssignAttri("", false, "AV11Insert_proveedorId", StringUtil.LTrimStr( (decimal)(AV11Insert_proveedorId), 4, 0));
         AV12Insert_tipoDeProductoId = 0;
         AssignAttri("", false, "AV12Insert_tipoDeProductoId", StringUtil.LTrimStr( (decimal)(AV12Insert_tipoDeProductoId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV14Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV15GXV1 = 1;
            AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
            while ( AV15GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV15GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "proveedorId") == 0 )
               {
                  AV11Insert_proveedorId = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_proveedorId", StringUtil.LTrimStr( (decimal)(AV11Insert_proveedorId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "tipoDeProductoId") == 0 )
               {
                  AV12Insert_tipoDeProductoId = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_tipoDeProductoId", StringUtil.LTrimStr( (decimal)(AV12Insert_tipoDeProductoId), 4, 0));
               }
               AV15GXV1 = (int)(AV15GXV1+1);
               AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
            }
         }
      }

      protected void E12032( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwproducto.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM034( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z25productoName = T00033_A25productoName[0];
               Z27productoSellPrice = T00033_A27productoSellPrice[0];
               Z28productoCostPrice = T00033_A28productoCostPrice[0];
               Z7proveedorId = T00033_A7proveedorId[0];
               Z6tipoDeProductoId = T00033_A6tipoDeProductoId[0];
            }
            else
            {
               Z25productoName = A25productoName;
               Z27productoSellPrice = A27productoSellPrice;
               Z28productoCostPrice = A28productoCostPrice;
               Z7proveedorId = A7proveedorId;
               Z6tipoDeProductoId = A6tipoDeProductoId;
            }
         }
         if ( GX_JID == -11 )
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
         edtproductoId_Enabled = 0;
         AssignProp("", false, edtproductoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoId_Enabled), 5, 0), true);
         edtproductoId_Enabled = 0;
         AssignProp("", false, edtproductoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7productoId) )
         {
            A5productoId = AV7productoId;
            AssignAttri("", false, "A5productoId", StringUtil.LTrimStr( (decimal)(A5productoId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_proveedorId) )
         {
            dynproveedorId.Enabled = 0;
            AssignProp("", false, dynproveedorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynproveedorId.Enabled), 5, 0), true);
         }
         else
         {
            dynproveedorId.Enabled = 1;
            AssignProp("", false, dynproveedorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynproveedorId.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_tipoDeProductoId) )
         {
            dyntipoDeProductoId.Enabled = 0;
            AssignProp("", false, dyntipoDeProductoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dyntipoDeProductoId.Enabled), 5, 0), true);
         }
         else
         {
            dyntipoDeProductoId.Enabled = 1;
            AssignProp("", false, dyntipoDeProductoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dyntipoDeProductoId.Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_tipoDeProductoId) )
         {
            A6tipoDeProductoId = AV12Insert_tipoDeProductoId;
            AssignAttri("", false, "A6tipoDeProductoId", StringUtil.LTrimStr( (decimal)(A6tipoDeProductoId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_proveedorId) )
         {
            A7proveedorId = AV11Insert_proveedorId;
            AssignAttri("", false, "A7proveedorId", StringUtil.LTrimStr( (decimal)(A7proveedorId), 4, 0));
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
            AV14Pgmname = "producto";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
            /* Using cursor T00035 */
            pr_default.execute(3, new Object[] {A6tipoDeProductoId});
            A29tipoDeProductoName = T00035_A29tipoDeProductoName[0];
            pr_default.close(3);
            /* Using cursor T00034 */
            pr_default.execute(2, new Object[] {A7proveedorId});
            A21proveedorName = T00034_A21proveedorName[0];
            pr_default.close(2);
         }
      }

      protected void Load034( )
      {
         /* Using cursor T00036 */
         pr_default.execute(4, new Object[] {A5productoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound4 = 1;
            A25productoName = T00036_A25productoName[0];
            AssignAttri("", false, "A25productoName", A25productoName);
            A40000productoImage_GXI = T00036_A40000productoImage_GXI[0];
            AssignProp("", false, imgproductoImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26productoImage)) ? A40000productoImage_GXI : context.convertURL( context.PathToRelativeUrl( A26productoImage))), true);
            AssignProp("", false, imgproductoImage_Internalname, "SrcSet", context.GetImageSrcSet( A26productoImage), true);
            A27productoSellPrice = T00036_A27productoSellPrice[0];
            AssignAttri("", false, "A27productoSellPrice", StringUtil.LTrimStr( A27productoSellPrice, 10, 2));
            A28productoCostPrice = T00036_A28productoCostPrice[0];
            AssignAttri("", false, "A28productoCostPrice", StringUtil.LTrimStr( A28productoCostPrice, 10, 2));
            A21proveedorName = T00036_A21proveedorName[0];
            A29tipoDeProductoName = T00036_A29tipoDeProductoName[0];
            A7proveedorId = T00036_A7proveedorId[0];
            AssignAttri("", false, "A7proveedorId", StringUtil.LTrimStr( (decimal)(A7proveedorId), 4, 0));
            A6tipoDeProductoId = T00036_A6tipoDeProductoId[0];
            AssignAttri("", false, "A6tipoDeProductoId", StringUtil.LTrimStr( (decimal)(A6tipoDeProductoId), 4, 0));
            A26productoImage = T00036_A26productoImage[0];
            AssignAttri("", false, "A26productoImage", A26productoImage);
            AssignProp("", false, imgproductoImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26productoImage)) ? A40000productoImage_GXI : context.convertURL( context.PathToRelativeUrl( A26productoImage))), true);
            AssignProp("", false, imgproductoImage_Internalname, "SrcSet", context.GetImageSrcSet( A26productoImage), true);
            ZM034( -11) ;
         }
         pr_default.close(4);
         OnLoadActions034( ) ;
      }

      protected void OnLoadActions034( )
      {
         AV14Pgmname = "producto";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
      }

      protected void CheckExtendedTable034( )
      {
         nIsDirty_4 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV14Pgmname = "producto";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         /* Using cursor T00034 */
         pr_default.execute(2, new Object[] {A7proveedorId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'proveedor'.", "ForeignKeyNotFound", 1, "PROVEEDORID");
            AnyError = 1;
            GX_FocusControl = dynproveedorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A21proveedorName = T00034_A21proveedorName[0];
         pr_default.close(2);
         /* Using cursor T00035 */
         pr_default.execute(3, new Object[] {A6tipoDeProductoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'tipo De Producto'.", "ForeignKeyNotFound", 1, "TIPODEPRODUCTOID");
            AnyError = 1;
            GX_FocusControl = dyntipoDeProductoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A29tipoDeProductoName = T00035_A29tipoDeProductoName[0];
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

      protected void gxLoad_12( short A7proveedorId )
      {
         /* Using cursor T00037 */
         pr_default.execute(5, new Object[] {A7proveedorId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'proveedor'.", "ForeignKeyNotFound", 1, "PROVEEDORID");
            AnyError = 1;
            GX_FocusControl = dynproveedorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A21proveedorName = T00037_A21proveedorName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A21proveedorName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_13( short A6tipoDeProductoId )
      {
         /* Using cursor T00038 */
         pr_default.execute(6, new Object[] {A6tipoDeProductoId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'tipo De Producto'.", "ForeignKeyNotFound", 1, "TIPODEPRODUCTOID");
            AnyError = 1;
            GX_FocusControl = dyntipoDeProductoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A29tipoDeProductoName = T00038_A29tipoDeProductoName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A29tipoDeProductoName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey034( )
      {
         /* Using cursor T00039 */
         pr_default.execute(7, new Object[] {A5productoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00033 */
         pr_default.execute(1, new Object[] {A5productoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM034( 11) ;
            RcdFound4 = 1;
            A5productoId = T00033_A5productoId[0];
            AssignAttri("", false, "A5productoId", StringUtil.LTrimStr( (decimal)(A5productoId), 4, 0));
            A25productoName = T00033_A25productoName[0];
            AssignAttri("", false, "A25productoName", A25productoName);
            A40000productoImage_GXI = T00033_A40000productoImage_GXI[0];
            AssignProp("", false, imgproductoImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26productoImage)) ? A40000productoImage_GXI : context.convertURL( context.PathToRelativeUrl( A26productoImage))), true);
            AssignProp("", false, imgproductoImage_Internalname, "SrcSet", context.GetImageSrcSet( A26productoImage), true);
            A27productoSellPrice = T00033_A27productoSellPrice[0];
            AssignAttri("", false, "A27productoSellPrice", StringUtil.LTrimStr( A27productoSellPrice, 10, 2));
            A28productoCostPrice = T00033_A28productoCostPrice[0];
            AssignAttri("", false, "A28productoCostPrice", StringUtil.LTrimStr( A28productoCostPrice, 10, 2));
            A7proveedorId = T00033_A7proveedorId[0];
            AssignAttri("", false, "A7proveedorId", StringUtil.LTrimStr( (decimal)(A7proveedorId), 4, 0));
            A6tipoDeProductoId = T00033_A6tipoDeProductoId[0];
            AssignAttri("", false, "A6tipoDeProductoId", StringUtil.LTrimStr( (decimal)(A6tipoDeProductoId), 4, 0));
            A26productoImage = T00033_A26productoImage[0];
            AssignAttri("", false, "A26productoImage", A26productoImage);
            AssignProp("", false, imgproductoImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26productoImage)) ? A40000productoImage_GXI : context.convertURL( context.PathToRelativeUrl( A26productoImage))), true);
            AssignProp("", false, imgproductoImage_Internalname, "SrcSet", context.GetImageSrcSet( A26productoImage), true);
            Z5productoId = A5productoId;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load034( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey034( ) ;
            }
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey034( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey034( ) ;
         if ( RcdFound4 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound4 = 0;
         /* Using cursor T000310 */
         pr_default.execute(8, new Object[] {A5productoId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000310_A5productoId[0] < A5productoId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000310_A5productoId[0] > A5productoId ) ) )
            {
               A5productoId = T000310_A5productoId[0];
               AssignAttri("", false, "A5productoId", StringUtil.LTrimStr( (decimal)(A5productoId), 4, 0));
               RcdFound4 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound4 = 0;
         /* Using cursor T000311 */
         pr_default.execute(9, new Object[] {A5productoId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000311_A5productoId[0] > A5productoId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000311_A5productoId[0] < A5productoId ) ) )
            {
               A5productoId = T000311_A5productoId[0];
               AssignAttri("", false, "A5productoId", StringUtil.LTrimStr( (decimal)(A5productoId), 4, 0));
               RcdFound4 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey034( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtproductoName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert034( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( A5productoId != Z5productoId )
               {
                  A5productoId = Z5productoId;
                  AssignAttri("", false, "A5productoId", StringUtil.LTrimStr( (decimal)(A5productoId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PRODUCTOID");
                  AnyError = 1;
                  GX_FocusControl = edtproductoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtproductoName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update034( ) ;
                  GX_FocusControl = edtproductoName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A5productoId != Z5productoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtproductoName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert034( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PRODUCTOID");
                     AnyError = 1;
                     GX_FocusControl = edtproductoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtproductoName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert034( ) ;
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
         if ( A5productoId != Z5productoId )
         {
            A5productoId = Z5productoId;
            AssignAttri("", false, "A5productoId", StringUtil.LTrimStr( (decimal)(A5productoId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PRODUCTOID");
            AnyError = 1;
            GX_FocusControl = edtproductoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtproductoName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency034( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00032 */
            pr_default.execute(0, new Object[] {A5productoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"producto"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z25productoName, T00032_A25productoName[0]) != 0 ) || ( Z27productoSellPrice != T00032_A27productoSellPrice[0] ) || ( Z28productoCostPrice != T00032_A28productoCostPrice[0] ) || ( Z7proveedorId != T00032_A7proveedorId[0] ) || ( Z6tipoDeProductoId != T00032_A6tipoDeProductoId[0] ) )
            {
               if ( StringUtil.StrCmp(Z25productoName, T00032_A25productoName[0]) != 0 )
               {
                  GXUtil.WriteLog("producto:[seudo value changed for attri]"+"productoName");
                  GXUtil.WriteLogRaw("Old: ",Z25productoName);
                  GXUtil.WriteLogRaw("Current: ",T00032_A25productoName[0]);
               }
               if ( Z27productoSellPrice != T00032_A27productoSellPrice[0] )
               {
                  GXUtil.WriteLog("producto:[seudo value changed for attri]"+"productoSellPrice");
                  GXUtil.WriteLogRaw("Old: ",Z27productoSellPrice);
                  GXUtil.WriteLogRaw("Current: ",T00032_A27productoSellPrice[0]);
               }
               if ( Z28productoCostPrice != T00032_A28productoCostPrice[0] )
               {
                  GXUtil.WriteLog("producto:[seudo value changed for attri]"+"productoCostPrice");
                  GXUtil.WriteLogRaw("Old: ",Z28productoCostPrice);
                  GXUtil.WriteLogRaw("Current: ",T00032_A28productoCostPrice[0]);
               }
               if ( Z7proveedorId != T00032_A7proveedorId[0] )
               {
                  GXUtil.WriteLog("producto:[seudo value changed for attri]"+"proveedorId");
                  GXUtil.WriteLogRaw("Old: ",Z7proveedorId);
                  GXUtil.WriteLogRaw("Current: ",T00032_A7proveedorId[0]);
               }
               if ( Z6tipoDeProductoId != T00032_A6tipoDeProductoId[0] )
               {
                  GXUtil.WriteLog("producto:[seudo value changed for attri]"+"tipoDeProductoId");
                  GXUtil.WriteLogRaw("Old: ",Z6tipoDeProductoId);
                  GXUtil.WriteLogRaw("Current: ",T00032_A6tipoDeProductoId[0]);
               }
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
                     /* Using cursor T000312 */
                     pr_default.execute(10, new Object[] {A25productoName, A26productoImage, A40000productoImage_GXI, A27productoSellPrice, A28productoCostPrice, A7proveedorId, A6tipoDeProductoId});
                     A5productoId = T000312_A5productoId[0];
                     AssignAttri("", false, "A5productoId", StringUtil.LTrimStr( (decimal)(A5productoId), 4, 0));
                     pr_default.close(10);
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
                           ResetCaption030( ) ;
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
                     /* Using cursor T000313 */
                     pr_default.execute(11, new Object[] {A25productoName, A27productoSellPrice, A28productoCostPrice, A7proveedorId, A6tipoDeProductoId, A5productoId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("producto");
                     if ( (pr_default.getStatus(11) == 103) )
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
            EndLevel034( ) ;
         }
         CloseExtendedTableCursors034( ) ;
      }

      protected void DeferredUpdate034( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000314 */
            pr_default.execute(12, new Object[] {A26productoImage, A40000productoImage_GXI, A5productoId});
            pr_default.close(12);
            pr_default.SmartCacheProvider.SetUpdated("producto");
         }
      }

      protected void delete( )
      {
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
                  /* Using cursor T000315 */
                  pr_default.execute(13, new Object[] {A5productoId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("producto");
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
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel034( ) ;
         Gx_mode = sMode4;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls034( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV14Pgmname = "producto";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
            /* Using cursor T000316 */
            pr_default.execute(14, new Object[] {A7proveedorId});
            A21proveedorName = T000316_A21proveedorName[0];
            pr_default.close(14);
            /* Using cursor T000317 */
            pr_default.execute(15, new Object[] {A6tipoDeProductoId});
            A29tipoDeProductoName = T000317_A29tipoDeProductoName[0];
            pr_default.close(15);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000318 */
            pr_default.execute(16, new Object[] {A5productoId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"producto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T000319 */
            pr_default.execute(17, new Object[] {A5productoId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"producto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
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
            pr_default.close(1);
            pr_default.close(14);
            pr_default.close(15);
            context.CommitDataStores("producto",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues030( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(14);
            pr_default.close(15);
            context.RollbackDataStores("producto",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart034( )
      {
         /* Scan By routine */
         /* Using cursor T000320 */
         pr_default.execute(18);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound4 = 1;
            A5productoId = T000320_A5productoId[0];
            AssignAttri("", false, "A5productoId", StringUtil.LTrimStr( (decimal)(A5productoId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext034( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound4 = 1;
            A5productoId = T000320_A5productoId[0];
            AssignAttri("", false, "A5productoId", StringUtil.LTrimStr( (decimal)(A5productoId), 4, 0));
         }
      }

      protected void ScanEnd034( )
      {
         pr_default.close(18);
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
         edtproductoId_Enabled = 0;
         AssignProp("", false, edtproductoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoId_Enabled), 5, 0), true);
         edtproductoName_Enabled = 0;
         AssignProp("", false, edtproductoName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoName_Enabled), 5, 0), true);
         imgproductoImage_Enabled = 0;
         AssignProp("", false, imgproductoImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgproductoImage_Enabled), 5, 0), true);
         edtproductoSellPrice_Enabled = 0;
         AssignProp("", false, edtproductoSellPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoSellPrice_Enabled), 5, 0), true);
         edtproductoCostPrice_Enabled = 0;
         AssignProp("", false, edtproductoCostPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtproductoCostPrice_Enabled), 5, 0), true);
         dynproveedorId.Enabled = 0;
         AssignProp("", false, dynproveedorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynproveedorId.Enabled), 5, 0), true);
         dyntipoDeProductoId.Enabled = 0;
         AssignProp("", false, dyntipoDeProductoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dyntipoDeProductoId.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes034( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues030( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("producto.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7productoId,4,0))}, new string[] {"Gx_mode","productoId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"producto");
         forbiddenHiddens.Add("productoId", context.localUtil.Format( (decimal)(A5productoId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("producto:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z5productoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z5productoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z25productoName", Z25productoName);
         GxWebStd.gx_hidden_field( context, "Z27productoSellPrice", StringUtil.LTrim( StringUtil.NToC( Z27productoSellPrice, 10, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z28productoCostPrice", StringUtil.LTrim( StringUtil.NToC( Z28productoCostPrice, 10, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z7proveedorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7proveedorId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z6tipoDeProductoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z6tipoDeProductoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N7proveedorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7proveedorId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N6tipoDeProductoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A6tipoDeProductoId), 4, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vPRODUCTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7productoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPRODUCTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7productoId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_proveedorId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_TIPODEPRODUCTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_tipoDeProductoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTOIMAGE_GXI", A40000productoImage_GXI);
         GxWebStd.gx_hidden_field( context, "PROVEEDORNAME", A21proveedorName);
         GxWebStd.gx_hidden_field( context, "TIPODEPRODUCTONAME", A29tipoDeProductoName);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV14Pgmname));
         GXCCtlgxBlob = "PRODUCTOIMAGE" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A26productoImage);
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
         return formatLink("producto.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7productoId,4,0))}, new string[] {"Gx_mode","productoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "producto" ;
      }

      public override string GetPgmdesc( )
      {
         return "producto" ;
      }

      protected void InitializeNonKey034( )
      {
         A7proveedorId = 0;
         AssignAttri("", false, "A7proveedorId", StringUtil.LTrimStr( (decimal)(A7proveedorId), 4, 0));
         A6tipoDeProductoId = 0;
         AssignAttri("", false, "A6tipoDeProductoId", StringUtil.LTrimStr( (decimal)(A6tipoDeProductoId), 4, 0));
         A25productoName = "";
         AssignAttri("", false, "A25productoName", A25productoName);
         A26productoImage = "";
         AssignAttri("", false, "A26productoImage", A26productoImage);
         AssignProp("", false, imgproductoImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26productoImage)) ? A40000productoImage_GXI : context.convertURL( context.PathToRelativeUrl( A26productoImage))), true);
         AssignProp("", false, imgproductoImage_Internalname, "SrcSet", context.GetImageSrcSet( A26productoImage), true);
         A40000productoImage_GXI = "";
         AssignProp("", false, imgproductoImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26productoImage)) ? A40000productoImage_GXI : context.convertURL( context.PathToRelativeUrl( A26productoImage))), true);
         AssignProp("", false, imgproductoImage_Internalname, "SrcSet", context.GetImageSrcSet( A26productoImage), true);
         A27productoSellPrice = 0;
         AssignAttri("", false, "A27productoSellPrice", StringUtil.LTrimStr( A27productoSellPrice, 10, 2));
         A28productoCostPrice = 0;
         AssignAttri("", false, "A28productoCostPrice", StringUtil.LTrimStr( A28productoCostPrice, 10, 2));
         A21proveedorName = "";
         AssignAttri("", false, "A21proveedorName", A21proveedorName);
         A29tipoDeProductoName = "";
         AssignAttri("", false, "A29tipoDeProductoName", A29tipoDeProductoName);
         Z25productoName = "";
         Z27productoSellPrice = 0;
         Z28productoCostPrice = 0;
         Z7proveedorId = 0;
         Z6tipoDeProductoId = 0;
      }

      protected void InitAll034( )
      {
         A5productoId = 0;
         AssignAttri("", false, "A5productoId", StringUtil.LTrimStr( (decimal)(A5productoId), 4, 0));
         InitializeNonKey034( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202332418575989", true, true);
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
         context.AddJavascriptSource("producto.js", "?202332418575989", false, true);
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
         edtproductoId_Internalname = "PRODUCTOID";
         edtproductoName_Internalname = "PRODUCTONAME";
         imgproductoImage_Internalname = "PRODUCTOIMAGE";
         edtproductoSellPrice_Internalname = "PRODUCTOSELLPRICE";
         edtproductoCostPrice_Internalname = "PRODUCTOCOSTPRICE";
         dynproveedorId_Internalname = "PROVEEDORID";
         dyntipoDeProductoId_Internalname = "TIPODEPRODUCTOID";
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
         Form.Caption = "producto";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         dyntipoDeProductoId_Jsonclick = "";
         dyntipoDeProductoId.Enabled = 1;
         dynproveedorId_Jsonclick = "";
         dynproveedorId.Enabled = 1;
         edtproductoCostPrice_Jsonclick = "";
         edtproductoCostPrice_Enabled = 1;
         edtproductoSellPrice_Jsonclick = "";
         edtproductoSellPrice_Enabled = 1;
         imgproductoImage_Enabled = 1;
         edtproductoName_Jsonclick = "";
         edtproductoName_Enabled = 1;
         edtproductoId_Jsonclick = "";
         edtproductoId_Enabled = 0;
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

      protected void GXDLATIPODEPRODUCTOID031( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLATIPODEPRODUCTOID_data031( ) ;
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

      protected void GXATIPODEPRODUCTOID_html031( )
      {
         short gxdynajaxvalue;
         GXDLATIPODEPRODUCTOID_data031( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dyntipoDeProductoId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dyntipoDeProductoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLATIPODEPRODUCTOID_data031( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000321 */
         pr_default.execute(19);
         while ( (pr_default.getStatus(19) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000321_A6tipoDeProductoId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(T000321_A29tipoDeProductoName[0]);
            pr_default.readNext(19);
         }
         pr_default.close(19);
      }

      protected void GXDLAPROVEEDORID031( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAPROVEEDORID_data031( ) ;
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

      protected void GXAPROVEEDORID_html031( )
      {
         short gxdynajaxvalue;
         GXDLAPROVEEDORID_data031( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynproveedorId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynproveedorId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAPROVEEDORID_data031( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000322 */
         pr_default.execute(20);
         while ( (pr_default.getStatus(20) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000322_A7proveedorId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(T000322_A21proveedorName[0]);
            pr_default.readNext(20);
         }
         pr_default.close(20);
      }

      protected void init_web_controls( )
      {
         dynproveedorId.Name = "PROVEEDORID";
         dynproveedorId.WebTags = "";
         dynproveedorId.removeAllItems();
         /* Using cursor T000323 */
         pr_default.execute(21);
         while ( (pr_default.getStatus(21) != 101) )
         {
            dynproveedorId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000323_A7proveedorId[0]), 4, 0)), T000323_A21proveedorName[0], 0);
            pr_default.readNext(21);
         }
         pr_default.close(21);
         if ( dynproveedorId.ItemCount > 0 )
         {
            A7proveedorId = (short)(Math.Round(NumberUtil.Val( dynproveedorId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A7proveedorId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A7proveedorId", StringUtil.LTrimStr( (decimal)(A7proveedorId), 4, 0));
         }
         dyntipoDeProductoId.Name = "TIPODEPRODUCTOID";
         dyntipoDeProductoId.WebTags = "";
         dyntipoDeProductoId.removeAllItems();
         /* Using cursor T000324 */
         pr_default.execute(22);
         while ( (pr_default.getStatus(22) != 101) )
         {
            dyntipoDeProductoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000324_A6tipoDeProductoId[0]), 4, 0)), T000324_A29tipoDeProductoName[0], 0);
            pr_default.readNext(22);
         }
         pr_default.close(22);
         if ( dyntipoDeProductoId.ItemCount > 0 )
         {
            A6tipoDeProductoId = (short)(Math.Round(NumberUtil.Val( dyntipoDeProductoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A6tipoDeProductoId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A6tipoDeProductoId", StringUtil.LTrimStr( (decimal)(A6tipoDeProductoId), 4, 0));
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

      public void Valid_Proveedorid( )
      {
         A6tipoDeProductoId = (short)(Math.Round(NumberUtil.Val( dyntipoDeProductoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A7proveedorId = (short)(Math.Round(NumberUtil.Val( dynproveedorId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000316 */
         pr_default.execute(14, new Object[] {A7proveedorId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'proveedor'.", "ForeignKeyNotFound", 1, "PROVEEDORID");
            AnyError = 1;
            GX_FocusControl = dynproveedorId_Internalname;
         }
         A21proveedorName = T000316_A21proveedorName[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A21proveedorName", A21proveedorName);
      }

      public void Valid_Tipodeproductoid( )
      {
         A6tipoDeProductoId = (short)(Math.Round(NumberUtil.Val( dyntipoDeProductoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A7proveedorId = (short)(Math.Round(NumberUtil.Val( dynproveedorId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000317 */
         pr_default.execute(15, new Object[] {A6tipoDeProductoId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'tipo De Producto'.", "ForeignKeyNotFound", 1, "TIPODEPRODUCTOID");
            AnyError = 1;
            GX_FocusControl = dyntipoDeProductoId_Internalname;
         }
         A29tipoDeProductoName = T000317_A29tipoDeProductoName[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A29tipoDeProductoName", A29tipoDeProductoName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7productoId',fld:'vPRODUCTOID',pic:'ZZZ9',hsh:true},{av:'dyntipoDeProductoId'},{av:'A6tipoDeProductoId',fld:'TIPODEPRODUCTOID',pic:'ZZZ9'},{av:'dynproveedorId'},{av:'A7proveedorId',fld:'PROVEEDORID',pic:'ZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'dyntipoDeProductoId'},{av:'A6tipoDeProductoId',fld:'TIPODEPRODUCTOID',pic:'ZZZ9'},{av:'dynproveedorId'},{av:'A7proveedorId',fld:'PROVEEDORID',pic:'ZZZ9'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7productoId',fld:'vPRODUCTOID',pic:'ZZZ9',hsh:true},{av:'A5productoId',fld:'PRODUCTOID',pic:'ZZZ9'},{av:'dyntipoDeProductoId'},{av:'A6tipoDeProductoId',fld:'TIPODEPRODUCTOID',pic:'ZZZ9'},{av:'dynproveedorId'},{av:'A7proveedorId',fld:'PROVEEDORID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dyntipoDeProductoId'},{av:'A6tipoDeProductoId',fld:'TIPODEPRODUCTOID',pic:'ZZZ9'},{av:'dynproveedorId'},{av:'A7proveedorId',fld:'PROVEEDORID',pic:'ZZZ9'}]}");
         setEventMetadata("AFTER TRN","{handler:'E12032',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'dyntipoDeProductoId'},{av:'A6tipoDeProductoId',fld:'TIPODEPRODUCTOID',pic:'ZZZ9'},{av:'dynproveedorId'},{av:'A7proveedorId',fld:'PROVEEDORID',pic:'ZZZ9'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'dyntipoDeProductoId'},{av:'A6tipoDeProductoId',fld:'TIPODEPRODUCTOID',pic:'ZZZ9'},{av:'dynproveedorId'},{av:'A7proveedorId',fld:'PROVEEDORID',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_PRODUCTOID","{handler:'Valid_Productoid',iparms:[{av:'dyntipoDeProductoId'},{av:'A6tipoDeProductoId',fld:'TIPODEPRODUCTOID',pic:'ZZZ9'},{av:'dynproveedorId'},{av:'A7proveedorId',fld:'PROVEEDORID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_PRODUCTOID",",oparms:[{av:'dyntipoDeProductoId'},{av:'A6tipoDeProductoId',fld:'TIPODEPRODUCTOID',pic:'ZZZ9'},{av:'dynproveedorId'},{av:'A7proveedorId',fld:'PROVEEDORID',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_PROVEEDORID","{handler:'Valid_Proveedorid',iparms:[{av:'A21proveedorName',fld:'PROVEEDORNAME',pic:''},{av:'dyntipoDeProductoId'},{av:'A6tipoDeProductoId',fld:'TIPODEPRODUCTOID',pic:'ZZZ9'},{av:'dynproveedorId'},{av:'A7proveedorId',fld:'PROVEEDORID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_PROVEEDORID",",oparms:[{av:'A21proveedorName',fld:'PROVEEDORNAME',pic:''},{av:'dyntipoDeProductoId'},{av:'A6tipoDeProductoId',fld:'TIPODEPRODUCTOID',pic:'ZZZ9'},{av:'dynproveedorId'},{av:'A7proveedorId',fld:'PROVEEDORID',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_TIPODEPRODUCTOID","{handler:'Valid_Tipodeproductoid',iparms:[{av:'A29tipoDeProductoName',fld:'TIPODEPRODUCTONAME',pic:''},{av:'dyntipoDeProductoId'},{av:'A6tipoDeProductoId',fld:'TIPODEPRODUCTOID',pic:'ZZZ9'},{av:'dynproveedorId'},{av:'A7proveedorId',fld:'PROVEEDORID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_TIPODEPRODUCTOID",",oparms:[{av:'A29tipoDeProductoName',fld:'TIPODEPRODUCTONAME',pic:''},{av:'dyntipoDeProductoId'},{av:'A6tipoDeProductoId',fld:'TIPODEPRODUCTOID',pic:'ZZZ9'},{av:'dynproveedorId'},{av:'A7proveedorId',fld:'PROVEEDORID',pic:'ZZZ9'}]}");
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
         pr_default.close(14);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z25productoName = "";
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
         A25productoName = "";
         A26productoImage = "";
         A40000productoImage_GXI = "";
         sImgUrl = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         A21proveedorName = "";
         A29tipoDeProductoName = "";
         AV14Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode4 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z26productoImage = "";
         Z40000productoImage_GXI = "";
         Z21proveedorName = "";
         Z29tipoDeProductoName = "";
         T00035_A29tipoDeProductoName = new string[] {""} ;
         T00034_A21proveedorName = new string[] {""} ;
         T00036_A5productoId = new short[1] ;
         T00036_A25productoName = new string[] {""} ;
         T00036_A40000productoImage_GXI = new string[] {""} ;
         T00036_A27productoSellPrice = new decimal[1] ;
         T00036_A28productoCostPrice = new decimal[1] ;
         T00036_A21proveedorName = new string[] {""} ;
         T00036_A29tipoDeProductoName = new string[] {""} ;
         T00036_A7proveedorId = new short[1] ;
         T00036_A6tipoDeProductoId = new short[1] ;
         T00036_A26productoImage = new string[] {""} ;
         T00037_A21proveedorName = new string[] {""} ;
         T00038_A29tipoDeProductoName = new string[] {""} ;
         T00039_A5productoId = new short[1] ;
         T00033_A5productoId = new short[1] ;
         T00033_A25productoName = new string[] {""} ;
         T00033_A40000productoImage_GXI = new string[] {""} ;
         T00033_A27productoSellPrice = new decimal[1] ;
         T00033_A28productoCostPrice = new decimal[1] ;
         T00033_A7proveedorId = new short[1] ;
         T00033_A6tipoDeProductoId = new short[1] ;
         T00033_A26productoImage = new string[] {""} ;
         T000310_A5productoId = new short[1] ;
         T000311_A5productoId = new short[1] ;
         T00032_A5productoId = new short[1] ;
         T00032_A25productoName = new string[] {""} ;
         T00032_A40000productoImage_GXI = new string[] {""} ;
         T00032_A27productoSellPrice = new decimal[1] ;
         T00032_A28productoCostPrice = new decimal[1] ;
         T00032_A7proveedorId = new short[1] ;
         T00032_A6tipoDeProductoId = new short[1] ;
         T00032_A26productoImage = new string[] {""} ;
         T000312_A5productoId = new short[1] ;
         T000316_A21proveedorName = new string[] {""} ;
         T000317_A29tipoDeProductoName = new string[] {""} ;
         T000318_A8facturaId = new short[1] ;
         T000318_A5productoId = new short[1] ;
         T000319_A2sucursalId = new short[1] ;
         T000319_A5productoId = new short[1] ;
         T000320_A5productoId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000321_A6tipoDeProductoId = new short[1] ;
         T000321_A29tipoDeProductoName = new string[] {""} ;
         T000322_A7proveedorId = new short[1] ;
         T000322_A21proveedorName = new string[] {""} ;
         T000323_A7proveedorId = new short[1] ;
         T000323_A21proveedorName = new string[] {""} ;
         T000324_A6tipoDeProductoId = new short[1] ;
         T000324_A29tipoDeProductoName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.producto__default(),
            new Object[][] {
                new Object[] {
               T00032_A5productoId, T00032_A25productoName, T00032_A40000productoImage_GXI, T00032_A27productoSellPrice, T00032_A28productoCostPrice, T00032_A7proveedorId, T00032_A6tipoDeProductoId, T00032_A26productoImage
               }
               , new Object[] {
               T00033_A5productoId, T00033_A25productoName, T00033_A40000productoImage_GXI, T00033_A27productoSellPrice, T00033_A28productoCostPrice, T00033_A7proveedorId, T00033_A6tipoDeProductoId, T00033_A26productoImage
               }
               , new Object[] {
               T00034_A21proveedorName
               }
               , new Object[] {
               T00035_A29tipoDeProductoName
               }
               , new Object[] {
               T00036_A5productoId, T00036_A25productoName, T00036_A40000productoImage_GXI, T00036_A27productoSellPrice, T00036_A28productoCostPrice, T00036_A21proveedorName, T00036_A29tipoDeProductoName, T00036_A7proveedorId, T00036_A6tipoDeProductoId, T00036_A26productoImage
               }
               , new Object[] {
               T00037_A21proveedorName
               }
               , new Object[] {
               T00038_A29tipoDeProductoName
               }
               , new Object[] {
               T00039_A5productoId
               }
               , new Object[] {
               T000310_A5productoId
               }
               , new Object[] {
               T000311_A5productoId
               }
               , new Object[] {
               T000312_A5productoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000316_A21proveedorName
               }
               , new Object[] {
               T000317_A29tipoDeProductoName
               }
               , new Object[] {
               T000318_A8facturaId, T000318_A5productoId
               }
               , new Object[] {
               T000319_A2sucursalId, T000319_A5productoId
               }
               , new Object[] {
               T000320_A5productoId
               }
               , new Object[] {
               T000321_A6tipoDeProductoId, T000321_A29tipoDeProductoName
               }
               , new Object[] {
               T000322_A7proveedorId, T000322_A21proveedorName
               }
               , new Object[] {
               T000323_A7proveedorId, T000323_A21proveedorName
               }
               , new Object[] {
               T000324_A6tipoDeProductoId, T000324_A29tipoDeProductoName
               }
            }
         );
         AV14Pgmname = "producto";
      }

      private short wcpOAV7productoId ;
      private short Z5productoId ;
      private short Z7proveedorId ;
      private short Z6tipoDeProductoId ;
      private short N7proveedorId ;
      private short N6tipoDeProductoId ;
      private short GxWebError ;
      private short A7proveedorId ;
      private short A6tipoDeProductoId ;
      private short AV7productoId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A5productoId ;
      private short AV11Insert_proveedorId ;
      private short AV12Insert_tipoDeProductoId ;
      private short RcdFound4 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_4 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtproductoId_Enabled ;
      private int edtproductoName_Enabled ;
      private int imgproductoImage_Enabled ;
      private int edtproductoSellPrice_Enabled ;
      private int edtproductoCostPrice_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV15GXV1 ;
      private int idxLst ;
      private int gxdynajaxindex ;
      private decimal Z27productoSellPrice ;
      private decimal Z28productoCostPrice ;
      private decimal A27productoSellPrice ;
      private decimal A28productoCostPrice ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtproductoName_Internalname ;
      private string dynproveedorId_Internalname ;
      private string dyntipoDeProductoId_Internalname ;
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
      private string edtproductoId_Internalname ;
      private string edtproductoId_Jsonclick ;
      private string edtproductoName_Jsonclick ;
      private string imgproductoImage_Internalname ;
      private string sImgUrl ;
      private string edtproductoSellPrice_Internalname ;
      private string edtproductoSellPrice_Jsonclick ;
      private string edtproductoCostPrice_Internalname ;
      private string edtproductoCostPrice_Jsonclick ;
      private string dynproveedorId_Jsonclick ;
      private string dyntipoDeProductoId_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV14Pgmname ;
      private string hsh ;
      private string sMode4 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string gxwrpcisep ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A26productoImage_IsBlob ;
      private bool returnInSub ;
      private bool gxdyncontrolsrefreshing ;
      private string Z25productoName ;
      private string A25productoName ;
      private string A40000productoImage_GXI ;
      private string A21proveedorName ;
      private string A29tipoDeProductoName ;
      private string Z40000productoImage_GXI ;
      private string Z21proveedorName ;
      private string Z29tipoDeProductoName ;
      private string A26productoImage ;
      private string Z26productoImage ;
      private IGxSession AV10WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynproveedorId ;
      private GXCombobox dyntipoDeProductoId ;
      private IDataStoreProvider pr_default ;
      private string[] T00035_A29tipoDeProductoName ;
      private string[] T00034_A21proveedorName ;
      private short[] T00036_A5productoId ;
      private string[] T00036_A25productoName ;
      private string[] T00036_A40000productoImage_GXI ;
      private decimal[] T00036_A27productoSellPrice ;
      private decimal[] T00036_A28productoCostPrice ;
      private string[] T00036_A21proveedorName ;
      private string[] T00036_A29tipoDeProductoName ;
      private short[] T00036_A7proveedorId ;
      private short[] T00036_A6tipoDeProductoId ;
      private string[] T00036_A26productoImage ;
      private string[] T00037_A21proveedorName ;
      private string[] T00038_A29tipoDeProductoName ;
      private short[] T00039_A5productoId ;
      private short[] T00033_A5productoId ;
      private string[] T00033_A25productoName ;
      private string[] T00033_A40000productoImage_GXI ;
      private decimal[] T00033_A27productoSellPrice ;
      private decimal[] T00033_A28productoCostPrice ;
      private short[] T00033_A7proveedorId ;
      private short[] T00033_A6tipoDeProductoId ;
      private string[] T00033_A26productoImage ;
      private short[] T000310_A5productoId ;
      private short[] T000311_A5productoId ;
      private short[] T00032_A5productoId ;
      private string[] T00032_A25productoName ;
      private string[] T00032_A40000productoImage_GXI ;
      private decimal[] T00032_A27productoSellPrice ;
      private decimal[] T00032_A28productoCostPrice ;
      private short[] T00032_A7proveedorId ;
      private short[] T00032_A6tipoDeProductoId ;
      private string[] T00032_A26productoImage ;
      private short[] T000312_A5productoId ;
      private string[] T000316_A21proveedorName ;
      private string[] T000317_A29tipoDeProductoName ;
      private short[] T000318_A8facturaId ;
      private short[] T000318_A5productoId ;
      private short[] T000319_A2sucursalId ;
      private short[] T000319_A5productoId ;
      private short[] T000320_A5productoId ;
      private short[] T000321_A6tipoDeProductoId ;
      private string[] T000321_A29tipoDeProductoName ;
      private short[] T000322_A7proveedorId ;
      private string[] T000322_A21proveedorName ;
      private short[] T000323_A7proveedorId ;
      private string[] T000323_A21proveedorName ;
      private short[] T000324_A6tipoDeProductoId ;
      private string[] T000324_A29tipoDeProductoName ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV13TrnContextAtt ;
   }

   public class producto__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00036;
          prmT00036 = new Object[] {
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT00034;
          prmT00034 = new Object[] {
          new ParDef("@proveedorId",GXType.Int16,4,0)
          };
          Object[] prmT00035;
          prmT00035 = new Object[] {
          new ParDef("@tipoDeProductoId",GXType.Int16,4,0)
          };
          Object[] prmT00037;
          prmT00037 = new Object[] {
          new ParDef("@proveedorId",GXType.Int16,4,0)
          };
          Object[] prmT00038;
          prmT00038 = new Object[] {
          new ParDef("@tipoDeProductoId",GXType.Int16,4,0)
          };
          Object[] prmT00039;
          prmT00039 = new Object[] {
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT00033;
          prmT00033 = new Object[] {
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT000310;
          prmT000310 = new Object[] {
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT000311;
          prmT000311 = new Object[] {
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT00032;
          prmT00032 = new Object[] {
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT000312;
          prmT000312 = new Object[] {
          new ParDef("@productoName",GXType.NVarChar,40,0) ,
          new ParDef("@productoImage",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@productoImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="producto", Fld="productoImage"} ,
          new ParDef("@productoSellPrice",GXType.Decimal,10,2) ,
          new ParDef("@productoCostPrice",GXType.Decimal,10,2) ,
          new ParDef("@proveedorId",GXType.Int16,4,0) ,
          new ParDef("@tipoDeProductoId",GXType.Int16,4,0)
          };
          Object[] prmT000313;
          prmT000313 = new Object[] {
          new ParDef("@productoName",GXType.NVarChar,40,0) ,
          new ParDef("@productoSellPrice",GXType.Decimal,10,2) ,
          new ParDef("@productoCostPrice",GXType.Decimal,10,2) ,
          new ParDef("@proveedorId",GXType.Int16,4,0) ,
          new ParDef("@tipoDeProductoId",GXType.Int16,4,0) ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT000314;
          prmT000314 = new Object[] {
          new ParDef("@productoImage",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@productoImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="producto", Fld="productoImage"} ,
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT000315;
          prmT000315 = new Object[] {
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT000318;
          prmT000318 = new Object[] {
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT000319;
          prmT000319 = new Object[] {
          new ParDef("@productoId",GXType.Int16,4,0)
          };
          Object[] prmT000320;
          prmT000320 = new Object[] {
          };
          Object[] prmT000321;
          prmT000321 = new Object[] {
          };
          Object[] prmT000322;
          prmT000322 = new Object[] {
          };
          Object[] prmT000323;
          prmT000323 = new Object[] {
          };
          Object[] prmT000324;
          prmT000324 = new Object[] {
          };
          Object[] prmT000316;
          prmT000316 = new Object[] {
          new ParDef("@proveedorId",GXType.Int16,4,0)
          };
          Object[] prmT000317;
          prmT000317 = new Object[] {
          new ParDef("@tipoDeProductoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00032", "SELECT [productoId], [productoName], [productoImage_GXI], [productoSellPrice], [productoCostPrice], [proveedorId], [tipoDeProductoId], [productoImage] FROM [producto] WITH (UPDLOCK) WHERE [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00032,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00033", "SELECT [productoId], [productoName], [productoImage_GXI], [productoSellPrice], [productoCostPrice], [proveedorId], [tipoDeProductoId], [productoImage] FROM [producto] WHERE [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00033,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00034", "SELECT [proveedorName] FROM [proveedor] WHERE [proveedorId] = @proveedorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00034,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00035", "SELECT [tipoDeProductoName] FROM [tipoDeProducto] WHERE [tipoDeProductoId] = @tipoDeProductoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00035,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00036", "SELECT TM1.[productoId], TM1.[productoName], TM1.[productoImage_GXI], TM1.[productoSellPrice], TM1.[productoCostPrice], T2.[proveedorName], T3.[tipoDeProductoName], TM1.[proveedorId], TM1.[tipoDeProductoId], TM1.[productoImage] FROM (([producto] TM1 INNER JOIN [proveedor] T2 ON T2.[proveedorId] = TM1.[proveedorId]) INNER JOIN [tipoDeProducto] T3 ON T3.[tipoDeProductoId] = TM1.[tipoDeProductoId]) WHERE TM1.[productoId] = @productoId ORDER BY TM1.[productoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00036,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00037", "SELECT [proveedorName] FROM [proveedor] WHERE [proveedorId] = @proveedorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00037,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00038", "SELECT [tipoDeProductoName] FROM [tipoDeProducto] WHERE [tipoDeProductoId] = @tipoDeProductoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00038,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00039", "SELECT [productoId] FROM [producto] WHERE [productoId] = @productoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00039,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000310", "SELECT TOP 1 [productoId] FROM [producto] WHERE ( [productoId] > @productoId) ORDER BY [productoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000310,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000311", "SELECT TOP 1 [productoId] FROM [producto] WHERE ( [productoId] < @productoId) ORDER BY [productoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000311,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000312", "INSERT INTO [producto]([productoName], [productoImage], [productoImage_GXI], [productoSellPrice], [productoCostPrice], [proveedorId], [tipoDeProductoId]) VALUES(@productoName, @productoImage, @productoImage_GXI, @productoSellPrice, @productoCostPrice, @proveedorId, @tipoDeProductoId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000312,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000313", "UPDATE [producto] SET [productoName]=@productoName, [productoSellPrice]=@productoSellPrice, [productoCostPrice]=@productoCostPrice, [proveedorId]=@proveedorId, [tipoDeProductoId]=@tipoDeProductoId  WHERE [productoId] = @productoId", GxErrorMask.GX_NOMASK,prmT000313)
             ,new CursorDef("T000314", "UPDATE [producto] SET [productoImage]=@productoImage, [productoImage_GXI]=@productoImage_GXI  WHERE [productoId] = @productoId", GxErrorMask.GX_NOMASK,prmT000314)
             ,new CursorDef("T000315", "DELETE FROM [producto]  WHERE [productoId] = @productoId", GxErrorMask.GX_NOMASK,prmT000315)
             ,new CursorDef("T000316", "SELECT [proveedorName] FROM [proveedor] WHERE [proveedorId] = @proveedorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000316,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000317", "SELECT [tipoDeProductoName] FROM [tipoDeProducto] WHERE [tipoDeProductoId] = @tipoDeProductoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000317,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000318", "SELECT TOP 1 [facturaId], [productoId] FROM [facturaproducto] WHERE [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000318,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000319", "SELECT TOP 1 [sucursalId], [productoId] FROM [sucursalproducto] WHERE [productoId] = @productoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000319,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000320", "SELECT [productoId] FROM [producto] ORDER BY [productoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000320,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000321", "SELECT [tipoDeProductoId], [tipoDeProductoName] FROM [tipoDeProducto] ORDER BY [tipoDeProductoName] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000321,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000322", "SELECT [proveedorId], [proveedorName] FROM [proveedor] ORDER BY [proveedorName] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000322,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000323", "SELECT [proveedorId], [proveedorName] FROM [proveedor] ORDER BY [proveedorName] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000323,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000324", "SELECT [tipoDeProductoId], [tipoDeProductoName] FROM [tipoDeProducto] ORDER BY [tipoDeProductoName] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000324,0, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 20 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 21 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 22 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
