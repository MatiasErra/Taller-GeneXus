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
   public class gx0040 : GXDataArea
   {
      public gx0040( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("xd2", true);
      }

      public gx0040( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_pproductoId )
      {
         this.AV12pproductoId = 0 ;
         executePrivate();
         aP0_pproductoId=this.AV12pproductoId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pproductoId");
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
               gxfirstwebparm = GetFirstPar( "pproductoId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pproductoId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               gxnrGrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               gxgrGrid1_refresh_invoke( ) ;
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
               AV12pproductoId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12pproductoId", StringUtil.LTrimStr( (decimal)(AV12pproductoId), 4, 0));
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_74 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_74"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_74_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_74_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_74_idx = GetPar( "sGXsfl_74_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         AV6cproductoId = (short)(Math.Round(NumberUtil.Val( GetPar( "cproductoId"), "."), 18, MidpointRounding.ToEven));
         AV7cproductoName = GetPar( "cproductoName");
         AV8cproductoSellPrice = NumberUtil.Val( GetPar( "cproductoSellPrice"), ".");
         AV9cproductoCostPrice = NumberUtil.Val( GetPar( "cproductoCostPrice"), ".");
         AV10cproveedorId = (short)(Math.Round(NumberUtil.Val( GetPar( "cproveedorId"), "."), 18, MidpointRounding.ToEven));
         AV11ctipoDeProductoId = (short)(Math.Round(NumberUtil.Val( GetPar( "ctipoDeProductoId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cproductoId, AV7cproductoName, AV8cproductoSellPrice, AV9cproductoCostPrice, AV10cproveedorId, AV11ctipoDeProductoId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterprompt", "GeneXus.Programs.general.ui.masterprompt", new Object[] {context});
            MasterPageObj.setDataArea(this,true);
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

      public override short ExecuteStartEvent( )
      {
         PA112( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START112( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
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
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0040.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pproductoId,4,0))}, new string[] {"pproductoId"}) +"\">") ;
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
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCPRODUCTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cproductoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPRODUCTONAME", AV7cproductoName);
         GxWebStd.gx_hidden_field( context, "GXH_vCPRODUCTOSELLPRICE", StringUtil.LTrim( StringUtil.NToC( AV8cproductoSellPrice, 10, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPRODUCTOCOSTPRICE", StringUtil.LTrim( StringUtil.NToC( AV9cproductoCostPrice, 10, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cproveedorId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCTIPODEPRODUCTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11ctipoDeProductoId), 4, 0, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPPRODUCTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pproductoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "PRODUCTOIDFILTERCONTAINER_Class", StringUtil.RTrim( divProductoidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PRODUCTONAMEFILTERCONTAINER_Class", StringUtil.RTrim( divProductonamefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PRODUCTOSELLPRICEFILTERCONTAINER_Class", StringUtil.RTrim( divProductosellpricefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PRODUCTOCOSTPRICEFILTERCONTAINER_Class", StringUtil.RTrim( divProductocostpricefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PROVEEDORIDFILTERCONTAINER_Class", StringUtil.RTrim( divProveedoridfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TIPODEPRODUCTOIDFILTERCONTAINER_Class", StringUtil.RTrim( divTipodeproductoidfiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE112( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT112( ) ;
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
         return formatLink("gx0040.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pproductoId,4,0))}, new string[] {"pproductoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0040" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List producto" ;
      }

      protected void WB110( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divProductoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divProductoidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblproductoidfilter_Internalname, "producto Id", "", "", lblLblproductoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11111_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCproductoid_Internalname, "producto Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCproductoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cproductoId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCproductoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cproductoId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cproductoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCproductoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCproductoid_Visible, edtavCproductoid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, divProductonamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divProductonamefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblproductonamefilter_Internalname, "producto Name", "", "", lblLblproductonamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12111_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCproductoname_Internalname, "producto Name", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCproductoname_Internalname, AV7cproductoName, StringUtil.RTrim( context.localUtil.Format( AV7cproductoName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCproductoname_Jsonclick, 0, "Attribute", "", "", "", "", edtavCproductoname_Visible, edtavCproductoname_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, divProductosellpricefiltercontainer_Internalname, 1, 0, "px", 0, "px", divProductosellpricefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblproductosellpricefilter_Internalname, "producto Sell Price", "", "", lblLblproductosellpricefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13111_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCproductosellprice_Internalname, "producto Sell Price", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCproductosellprice_Internalname, StringUtil.LTrim( StringUtil.NToC( AV8cproductoSellPrice, 10, 2, ",", "")), StringUtil.LTrim( ((edtavCproductosellprice_Enabled!=0) ? context.localUtil.Format( AV8cproductoSellPrice, "ZZZZZZ9.99") : context.localUtil.Format( AV8cproductoSellPrice, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCproductosellprice_Jsonclick, 0, "Attribute", "", "", "", "", edtavCproductosellprice_Visible, edtavCproductosellprice_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, divProductocostpricefiltercontainer_Internalname, 1, 0, "px", 0, "px", divProductocostpricefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblproductocostpricefilter_Internalname, "producto Cost Price", "", "", lblLblproductocostpricefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14111_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCproductocostprice_Internalname, "producto Cost Price", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCproductocostprice_Internalname, StringUtil.LTrim( StringUtil.NToC( AV9cproductoCostPrice, 10, 2, ",", "")), StringUtil.LTrim( ((edtavCproductocostprice_Enabled!=0) ? context.localUtil.Format( AV9cproductoCostPrice, "ZZZZZZ9.99") : context.localUtil.Format( AV9cproductoCostPrice, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCproductocostprice_Jsonclick, 0, "Attribute", "", "", "", "", edtavCproductocostprice_Visible, edtavCproductocostprice_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, divProveedoridfiltercontainer_Internalname, 1, 0, "px", 0, "px", divProveedoridfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblproveedoridfilter_Internalname, "proveedor Id", "", "", lblLblproveedoridfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15111_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCproveedorid_Internalname, "proveedor Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCproveedorid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cproveedorId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCproveedorid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10cproveedorId), "ZZZ9") : context.localUtil.Format( (decimal)(AV10cproveedorId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCproveedorid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCproveedorid_Visible, edtavCproveedorid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, divTipodeproductoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTipodeproductoidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltipodeproductoidfilter_Internalname, "tipo De Producto Id", "", "", lblLbltipodeproductoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16111_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtipodeproductoid_Internalname, "tipo De Producto Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtipodeproductoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11ctipoDeProductoId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCtipodeproductoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV11ctipoDeProductoId), "ZZZ9") : context.localUtil.Format( (decimal)(AV11ctipoDeProductoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtipodeproductoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtipodeproductoid_Visible, edtavCtipodeproductoid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e17111_client"+"'", TempTags, "", 2, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl74( ) ;
         }
         if ( wbEnd == 74 )
         {
            wbEnd = 0;
            nRC_GXsfl_74 = (int)(nGXsfl_74_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 74 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START112( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_1-167910", 0) ;
            }
            Form.Meta.addItem("description", "Selection List producto", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP110( ) ;
      }

      protected void WS112( )
      {
         START112( ) ;
         EVT112( ) ;
      }

      protected void EVT112( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_74_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
                              SubsflControlProps_742( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV16Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_74_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A5productoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtproductoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A25productoName = cgiGet( edtproductoName_Internalname);
                              A26productoImage = cgiGet( edtproductoImage_Internalname);
                              AssignProp("", false, edtproductoImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26productoImage)) ? A40000productoImage_GXI : context.convertURL( context.PathToRelativeUrl( A26productoImage))), !bGXsfl_74_Refreshing);
                              AssignProp("", false, edtproductoImage_Internalname, "SrcSet", context.GetImageSrcSet( A26productoImage), true);
                              A27productoSellPrice = context.localUtil.CToN( cgiGet( edtproductoSellPrice_Internalname), ",", ".");
                              A28productoCostPrice = context.localUtil.CToN( cgiGet( edtproductoCostPrice_Internalname), ",", ".");
                              A7proveedorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtproveedorId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E18112 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E19112 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cproductoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUCTOID"), ",", ".") != Convert.ToDecimal( AV6cproductoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cproductoname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPRODUCTONAME"), AV7cproductoName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cproductosellprice Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUCTOSELLPRICE"), ",", ".") != AV8cproductoSellPrice )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cproductocostprice Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUCTOCOSTPRICE"), ",", ".") != AV9cproductoCostPrice )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cproveedorid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPROVEEDORID"), ",", ".") != Convert.ToDecimal( AV10cproveedorId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctipodeproductoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTIPODEPRODUCTOID"), ",", ".") != Convert.ToDecimal( AV11ctipoDeProductoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E20112 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE112( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA112( )
      {
         if ( nDonePA == 0 )
         {
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
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_742( ) ;
         while ( nGXsfl_74_idx <= nRC_GXsfl_74 )
         {
            sendrow_742( ) ;
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        short AV6cproductoId ,
                                        string AV7cproductoName ,
                                        decimal AV8cproductoSellPrice ,
                                        decimal AV9cproductoCostPrice ,
                                        short AV10cproveedorId ,
                                        short AV11ctipoDeProductoId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF112( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A5productoId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PRODUCTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A5productoId), 4, 0, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF112( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF112( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 74;
         nGXsfl_74_idx = 1;
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         bGXsfl_74_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_742( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cproductoName ,
                                                 AV8cproductoSellPrice ,
                                                 AV9cproductoCostPrice ,
                                                 AV10cproveedorId ,
                                                 AV11ctipoDeProductoId ,
                                                 A25productoName ,
                                                 A27productoSellPrice ,
                                                 A28productoCostPrice ,
                                                 A7proveedorId ,
                                                 A6tipoDeProductoId ,
                                                 AV6cproductoId } ,
                                                 new int[]{
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV7cproductoName = StringUtil.Concat( StringUtil.RTrim( AV7cproductoName), "%", "");
            /* Using cursor H00112 */
            pr_default.execute(0, new Object[] {AV6cproductoId, lV7cproductoName, AV8cproductoSellPrice, AV9cproductoCostPrice, AV10cproveedorId, AV11ctipoDeProductoId, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A6tipoDeProductoId = H00112_A6tipoDeProductoId[0];
               A7proveedorId = H00112_A7proveedorId[0];
               A28productoCostPrice = H00112_A28productoCostPrice[0];
               A27productoSellPrice = H00112_A27productoSellPrice[0];
               A40000productoImage_GXI = H00112_A40000productoImage_GXI[0];
               AssignProp("", false, edtproductoImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26productoImage)) ? A40000productoImage_GXI : context.convertURL( context.PathToRelativeUrl( A26productoImage))), !bGXsfl_74_Refreshing);
               AssignProp("", false, edtproductoImage_Internalname, "SrcSet", context.GetImageSrcSet( A26productoImage), true);
               A25productoName = H00112_A25productoName[0];
               A5productoId = H00112_A5productoId[0];
               A26productoImage = H00112_A26productoImage[0];
               AssignProp("", false, edtproductoImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26productoImage)) ? A40000productoImage_GXI : context.convertURL( context.PathToRelativeUrl( A26productoImage))), !bGXsfl_74_Refreshing);
               AssignProp("", false, edtproductoImage_Internalname, "SrcSet", context.GetImageSrcSet( A26productoImage), true);
               /* Execute user event: Load */
               E19112 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WB110( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes112( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTOID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A5productoId), "ZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV7cproductoName ,
                                              AV8cproductoSellPrice ,
                                              AV9cproductoCostPrice ,
                                              AV10cproveedorId ,
                                              AV11ctipoDeProductoId ,
                                              A25productoName ,
                                              A27productoSellPrice ,
                                              A28productoCostPrice ,
                                              A7proveedorId ,
                                              A6tipoDeProductoId ,
                                              AV6cproductoId } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV7cproductoName = StringUtil.Concat( StringUtil.RTrim( AV7cproductoName), "%", "");
         /* Using cursor H00113 */
         pr_default.execute(1, new Object[] {AV6cproductoId, lV7cproductoName, AV8cproductoSellPrice, AV9cproductoCostPrice, AV10cproveedorId, AV11ctipoDeProductoId});
         GRID1_nRecordCount = H00113_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cproductoId, AV7cproductoName, AV8cproductoSellPrice, AV9cproductoCostPrice, AV10cproveedorId, AV11ctipoDeProductoId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cproductoId, AV7cproductoName, AV8cproductoSellPrice, AV9cproductoCostPrice, AV10cproveedorId, AV11ctipoDeProductoId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cproductoId, AV7cproductoName, AV8cproductoSellPrice, AV9cproductoCostPrice, AV10cproveedorId, AV11ctipoDeProductoId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cproductoId, AV7cproductoName, AV8cproductoSellPrice, AV9cproductoCostPrice, AV10cproveedorId, AV11ctipoDeProductoId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cproductoId, AV7cproductoName, AV8cproductoSellPrice, AV9cproductoCostPrice, AV10cproveedorId, AV11ctipoDeProductoId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP110( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E18112 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_74 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_74"), ",", "."), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCproductoid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCproductoid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPRODUCTOID");
               GX_FocusControl = edtavCproductoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cproductoId = 0;
               AssignAttri("", false, "AV6cproductoId", StringUtil.LTrimStr( (decimal)(AV6cproductoId), 4, 0));
            }
            else
            {
               AV6cproductoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCproductoid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cproductoId", StringUtil.LTrimStr( (decimal)(AV6cproductoId), 4, 0));
            }
            AV7cproductoName = cgiGet( edtavCproductoname_Internalname);
            AssignAttri("", false, "AV7cproductoName", AV7cproductoName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCproductosellprice_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCproductosellprice_Internalname), ",", ".") > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPRODUCTOSELLPRICE");
               GX_FocusControl = edtavCproductosellprice_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cproductoSellPrice = 0;
               AssignAttri("", false, "AV8cproductoSellPrice", StringUtil.LTrimStr( AV8cproductoSellPrice, 10, 2));
            }
            else
            {
               AV8cproductoSellPrice = context.localUtil.CToN( cgiGet( edtavCproductosellprice_Internalname), ",", ".");
               AssignAttri("", false, "AV8cproductoSellPrice", StringUtil.LTrimStr( AV8cproductoSellPrice, 10, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCproductocostprice_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCproductocostprice_Internalname), ",", ".") > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPRODUCTOCOSTPRICE");
               GX_FocusControl = edtavCproductocostprice_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cproductoCostPrice = 0;
               AssignAttri("", false, "AV9cproductoCostPrice", StringUtil.LTrimStr( AV9cproductoCostPrice, 10, 2));
            }
            else
            {
               AV9cproductoCostPrice = context.localUtil.CToN( cgiGet( edtavCproductocostprice_Internalname), ",", ".");
               AssignAttri("", false, "AV9cproductoCostPrice", StringUtil.LTrimStr( AV9cproductoCostPrice, 10, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCproveedorid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCproveedorid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPROVEEDORID");
               GX_FocusControl = edtavCproveedorid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cproveedorId = 0;
               AssignAttri("", false, "AV10cproveedorId", StringUtil.LTrimStr( (decimal)(AV10cproveedorId), 4, 0));
            }
            else
            {
               AV10cproveedorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCproveedorid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10cproveedorId", StringUtil.LTrimStr( (decimal)(AV10cproveedorId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCtipodeproductoid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCtipodeproductoid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCTIPODEPRODUCTOID");
               GX_FocusControl = edtavCtipodeproductoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11ctipoDeProductoId = 0;
               AssignAttri("", false, "AV11ctipoDeProductoId", StringUtil.LTrimStr( (decimal)(AV11ctipoDeProductoId), 4, 0));
            }
            else
            {
               AV11ctipoDeProductoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCtipodeproductoid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11ctipoDeProductoId", StringUtil.LTrimStr( (decimal)(AV11ctipoDeProductoId), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUCTOID"), ",", ".") != Convert.ToDecimal( AV6cproductoId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPRODUCTONAME"), AV7cproductoName) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUCTOSELLPRICE"), ",", ".") != AV8cproductoSellPrice )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUCTOCOSTPRICE"), ",", ".") != AV9cproductoCostPrice )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPROVEEDORID"), ",", ".") != Convert.ToDecimal( AV10cproveedorId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTIPODEPRODUCTOID"), ",", ".") != Convert.ToDecimal( AV11ctipoDeProductoId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E18112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18112( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "producto", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV13ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E19112( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV16Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_742( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_74_Refreshing )
         {
            DoAjaxLoad(74, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E20112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E20112( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV12pproductoId = A5productoId;
         AssignAttri("", false, "AV12pproductoId", StringUtil.LTrimStr( (decimal)(AV12pproductoId), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV12pproductoId});
         context.setWebReturnParmsMetadata(new Object[] {"AV12pproductoId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV12pproductoId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV12pproductoId", StringUtil.LTrimStr( (decimal)(AV12pproductoId), 4, 0));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA112( ) ;
         WS112( ) ;
         WE112( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20233241858771", true, true);
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
         context.AddJavascriptSource("gx0040.js", "?20233241858771", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtproductoId_Internalname = "PRODUCTOID_"+sGXsfl_74_idx;
         edtproductoName_Internalname = "PRODUCTONAME_"+sGXsfl_74_idx;
         edtproductoImage_Internalname = "PRODUCTOIMAGE_"+sGXsfl_74_idx;
         edtproductoSellPrice_Internalname = "PRODUCTOSELLPRICE_"+sGXsfl_74_idx;
         edtproductoCostPrice_Internalname = "PRODUCTOCOSTPRICE_"+sGXsfl_74_idx;
         edtproveedorId_Internalname = "PROVEEDORID_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtproductoId_Internalname = "PRODUCTOID_"+sGXsfl_74_fel_idx;
         edtproductoName_Internalname = "PRODUCTONAME_"+sGXsfl_74_fel_idx;
         edtproductoImage_Internalname = "PRODUCTOIMAGE_"+sGXsfl_74_fel_idx;
         edtproductoSellPrice_Internalname = "PRODUCTOSELLPRICE_"+sGXsfl_74_fel_idx;
         edtproductoCostPrice_Internalname = "PRODUCTOCOSTPRICE_"+sGXsfl_74_fel_idx;
         edtproveedorId_Internalname = "PROVEEDORID_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         SubsflControlProps_742( ) ;
         WB110( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_74_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_74_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_74_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A5productoId), 4, 0, ",", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_74_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV16Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV16Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtproductoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A5productoId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A5productoId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtproductoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtproductoName_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A5productoId), 4, 0, ",", "")))+"'"+"]);";
            AssignProp("", false, edtproductoName_Internalname, "Link", edtproductoName_Link, !bGXsfl_74_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtproductoName_Internalname,(string)A25productoName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtproductoName_Link,(string)"",(string)"",(string)"",(string)edtproductoName_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "ImageAttribute";
            StyleString = "";
            A26productoImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A26productoImage))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000productoImage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A26productoImage)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A26productoImage)) ? A40000productoImage_GXI : context.PathToRelativeUrl( A26productoImage));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtproductoImage_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A26productoImage_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtproductoSellPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A27productoSellPrice, 10, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A27productoSellPrice, "ZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtproductoSellPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtproductoCostPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A28productoCostPrice, 10, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A28productoCostPrice, "ZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtproductoCostPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtproveedorId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A7proveedorId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A7proveedorId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtproveedorId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes112( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         /* End function sendrow_742 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl74( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"74\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+" "+((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ImageAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Image") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Sell Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cost Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "proveedor Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Grid1Container = new GXWebGrid( context);
            }
            else
            {
               Grid1Container.Clear();
            }
            Grid1Container.SetWrapped(nGXWrapped);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "PromptGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A5productoId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A25productoName));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtproductoName_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( A26productoImage));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A27productoSellPrice, 10, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A28productoCostPrice, 10, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A7proveedorId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblLblproductoidfilter_Internalname = "LBLPRODUCTOIDFILTER";
         edtavCproductoid_Internalname = "vCPRODUCTOID";
         divProductoidfiltercontainer_Internalname = "PRODUCTOIDFILTERCONTAINER";
         lblLblproductonamefilter_Internalname = "LBLPRODUCTONAMEFILTER";
         edtavCproductoname_Internalname = "vCPRODUCTONAME";
         divProductonamefiltercontainer_Internalname = "PRODUCTONAMEFILTERCONTAINER";
         lblLblproductosellpricefilter_Internalname = "LBLPRODUCTOSELLPRICEFILTER";
         edtavCproductosellprice_Internalname = "vCPRODUCTOSELLPRICE";
         divProductosellpricefiltercontainer_Internalname = "PRODUCTOSELLPRICEFILTERCONTAINER";
         lblLblproductocostpricefilter_Internalname = "LBLPRODUCTOCOSTPRICEFILTER";
         edtavCproductocostprice_Internalname = "vCPRODUCTOCOSTPRICE";
         divProductocostpricefiltercontainer_Internalname = "PRODUCTOCOSTPRICEFILTERCONTAINER";
         lblLblproveedoridfilter_Internalname = "LBLPROVEEDORIDFILTER";
         edtavCproveedorid_Internalname = "vCPROVEEDORID";
         divProveedoridfiltercontainer_Internalname = "PROVEEDORIDFILTERCONTAINER";
         lblLbltipodeproductoidfilter_Internalname = "LBLTIPODEPRODUCTOIDFILTER";
         edtavCtipodeproductoid_Internalname = "vCTIPODEPRODUCTOID";
         divTipodeproductoidfiltercontainer_Internalname = "TIPODEPRODUCTOIDFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtproductoId_Internalname = "PRODUCTOID";
         edtproductoName_Internalname = "PRODUCTONAME";
         edtproductoImage_Internalname = "PRODUCTOIMAGE";
         edtproductoSellPrice_Internalname = "PRODUCTOSELLPRICE";
         edtproductoCostPrice_Internalname = "PRODUCTOCOSTPRICE";
         edtproveedorId_Internalname = "PROVEEDORID";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("xd2", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         edtproveedorId_Jsonclick = "";
         edtproductoCostPrice_Jsonclick = "";
         edtproductoSellPrice_Jsonclick = "";
         edtproductoName_Jsonclick = "";
         edtproductoName_Link = "";
         edtproductoId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCtipodeproductoid_Jsonclick = "";
         edtavCtipodeproductoid_Enabled = 1;
         edtavCtipodeproductoid_Visible = 1;
         edtavCproveedorid_Jsonclick = "";
         edtavCproveedorid_Enabled = 1;
         edtavCproveedorid_Visible = 1;
         edtavCproductocostprice_Jsonclick = "";
         edtavCproductocostprice_Enabled = 1;
         edtavCproductocostprice_Visible = 1;
         edtavCproductosellprice_Jsonclick = "";
         edtavCproductosellprice_Enabled = 1;
         edtavCproductosellprice_Visible = 1;
         edtavCproductoname_Jsonclick = "";
         edtavCproductoname_Enabled = 1;
         edtavCproductoname_Visible = 1;
         edtavCproductoid_Jsonclick = "";
         edtavCproductoid_Enabled = 1;
         edtavCproductoid_Visible = 1;
         divTipodeproductoidfiltercontainer_Class = "AdvancedContainerItem";
         divProveedoridfiltercontainer_Class = "AdvancedContainerItem";
         divProductocostpricefiltercontainer_Class = "AdvancedContainerItem";
         divProductosellpricefiltercontainer_Class = "AdvancedContainerItem";
         divProductonamefiltercontainer_Class = "AdvancedContainerItem";
         divProductoidfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List producto";
         subGrid1_Rows = 10;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cproductoId',fld:'vCPRODUCTOID',pic:'ZZZ9'},{av:'AV7cproductoName',fld:'vCPRODUCTONAME',pic:''},{av:'AV8cproductoSellPrice',fld:'vCPRODUCTOSELLPRICE',pic:'ZZZZZZ9.99'},{av:'AV9cproductoCostPrice',fld:'vCPRODUCTOCOSTPRICE',pic:'ZZZZZZ9.99'},{av:'AV10cproveedorId',fld:'vCPROVEEDORID',pic:'ZZZ9'},{av:'AV11ctipoDeProductoId',fld:'vCTIPODEPRODUCTOID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E17111',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLPRODUCTOIDFILTER.CLICK","{handler:'E11111',iparms:[{av:'divProductoidfiltercontainer_Class',ctrl:'PRODUCTOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPRODUCTOIDFILTER.CLICK",",oparms:[{av:'divProductoidfiltercontainer_Class',ctrl:'PRODUCTOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCproductoid_Visible',ctrl:'vCPRODUCTOID',prop:'Visible'}]}");
         setEventMetadata("LBLPRODUCTONAMEFILTER.CLICK","{handler:'E12111',iparms:[{av:'divProductonamefiltercontainer_Class',ctrl:'PRODUCTONAMEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPRODUCTONAMEFILTER.CLICK",",oparms:[{av:'divProductonamefiltercontainer_Class',ctrl:'PRODUCTONAMEFILTERCONTAINER',prop:'Class'},{av:'edtavCproductoname_Visible',ctrl:'vCPRODUCTONAME',prop:'Visible'}]}");
         setEventMetadata("LBLPRODUCTOSELLPRICEFILTER.CLICK","{handler:'E13111',iparms:[{av:'divProductosellpricefiltercontainer_Class',ctrl:'PRODUCTOSELLPRICEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPRODUCTOSELLPRICEFILTER.CLICK",",oparms:[{av:'divProductosellpricefiltercontainer_Class',ctrl:'PRODUCTOSELLPRICEFILTERCONTAINER',prop:'Class'},{av:'edtavCproductosellprice_Visible',ctrl:'vCPRODUCTOSELLPRICE',prop:'Visible'}]}");
         setEventMetadata("LBLPRODUCTOCOSTPRICEFILTER.CLICK","{handler:'E14111',iparms:[{av:'divProductocostpricefiltercontainer_Class',ctrl:'PRODUCTOCOSTPRICEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPRODUCTOCOSTPRICEFILTER.CLICK",",oparms:[{av:'divProductocostpricefiltercontainer_Class',ctrl:'PRODUCTOCOSTPRICEFILTERCONTAINER',prop:'Class'},{av:'edtavCproductocostprice_Visible',ctrl:'vCPRODUCTOCOSTPRICE',prop:'Visible'}]}");
         setEventMetadata("LBLPROVEEDORIDFILTER.CLICK","{handler:'E15111',iparms:[{av:'divProveedoridfiltercontainer_Class',ctrl:'PROVEEDORIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPROVEEDORIDFILTER.CLICK",",oparms:[{av:'divProveedoridfiltercontainer_Class',ctrl:'PROVEEDORIDFILTERCONTAINER',prop:'Class'},{av:'edtavCproveedorid_Visible',ctrl:'vCPROVEEDORID',prop:'Visible'}]}");
         setEventMetadata("LBLTIPODEPRODUCTOIDFILTER.CLICK","{handler:'E16111',iparms:[{av:'divTipodeproductoidfiltercontainer_Class',ctrl:'TIPODEPRODUCTOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTIPODEPRODUCTOIDFILTER.CLICK",",oparms:[{av:'divTipodeproductoidfiltercontainer_Class',ctrl:'TIPODEPRODUCTOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCtipodeproductoid_Visible',ctrl:'vCTIPODEPRODUCTOID',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E20112',iparms:[{av:'A5productoId',fld:'PRODUCTOID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV12pproductoId',fld:'vPPRODUCTOID',pic:'ZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cproductoId',fld:'vCPRODUCTOID',pic:'ZZZ9'},{av:'AV7cproductoName',fld:'vCPRODUCTONAME',pic:''},{av:'AV8cproductoSellPrice',fld:'vCPRODUCTOSELLPRICE',pic:'ZZZZZZ9.99'},{av:'AV9cproductoCostPrice',fld:'vCPRODUCTOCOSTPRICE',pic:'ZZZZZZ9.99'},{av:'AV10cproveedorId',fld:'vCPROVEEDORID',pic:'ZZZ9'},{av:'AV11ctipoDeProductoId',fld:'vCTIPODEPRODUCTOID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cproductoId',fld:'vCPRODUCTOID',pic:'ZZZ9'},{av:'AV7cproductoName',fld:'vCPRODUCTONAME',pic:''},{av:'AV8cproductoSellPrice',fld:'vCPRODUCTOSELLPRICE',pic:'ZZZZZZ9.99'},{av:'AV9cproductoCostPrice',fld:'vCPRODUCTOCOSTPRICE',pic:'ZZZZZZ9.99'},{av:'AV10cproveedorId',fld:'vCPROVEEDORID',pic:'ZZZ9'},{av:'AV11ctipoDeProductoId',fld:'vCTIPODEPRODUCTOID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cproductoId',fld:'vCPRODUCTOID',pic:'ZZZ9'},{av:'AV7cproductoName',fld:'vCPRODUCTONAME',pic:''},{av:'AV8cproductoSellPrice',fld:'vCPRODUCTOSELLPRICE',pic:'ZZZZZZ9.99'},{av:'AV9cproductoCostPrice',fld:'vCPRODUCTOCOSTPRICE',pic:'ZZZZZZ9.99'},{av:'AV10cproveedorId',fld:'vCPROVEEDORID',pic:'ZZZ9'},{av:'AV11ctipoDeProductoId',fld:'vCTIPODEPRODUCTOID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cproductoId',fld:'vCPRODUCTOID',pic:'ZZZ9'},{av:'AV7cproductoName',fld:'vCPRODUCTONAME',pic:''},{av:'AV8cproductoSellPrice',fld:'vCPRODUCTOSELLPRICE',pic:'ZZZZZZ9.99'},{av:'AV9cproductoCostPrice',fld:'vCPRODUCTOCOSTPRICE',pic:'ZZZZZZ9.99'},{av:'AV10cproveedorId',fld:'vCPROVEEDORID',pic:'ZZZ9'},{av:'AV11ctipoDeProductoId',fld:'vCTIPODEPRODUCTOID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Proveedorid',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV7cproductoName = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblproductoidfilter_Jsonclick = "";
         TempTags = "";
         lblLblproductonamefilter_Jsonclick = "";
         lblLblproductosellpricefilter_Jsonclick = "";
         lblLblproductocostpricefilter_Jsonclick = "";
         lblLblproveedoridfilter_Jsonclick = "";
         lblLbltipodeproductoidfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5LinkSelection = "";
         AV16Linkselection_GXI = "";
         A25productoName = "";
         A26productoImage = "";
         A40000productoImage_GXI = "";
         scmdbuf = "";
         lV7cproductoName = "";
         H00112_A6tipoDeProductoId = new short[1] ;
         H00112_A7proveedorId = new short[1] ;
         H00112_A28productoCostPrice = new decimal[1] ;
         H00112_A27productoSellPrice = new decimal[1] ;
         H00112_A40000productoImage_GXI = new string[] {""} ;
         H00112_A25productoName = new string[] {""} ;
         H00112_A5productoId = new short[1] ;
         H00112_A26productoImage = new string[] {""} ;
         H00113_AGRID1_nRecordCount = new long[1] ;
         AV13ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0040__default(),
            new Object[][] {
                new Object[] {
               H00112_A6tipoDeProductoId, H00112_A7proveedorId, H00112_A28productoCostPrice, H00112_A27productoSellPrice, H00112_A40000productoImage_GXI, H00112_A25productoName, H00112_A5productoId, H00112_A26productoImage
               }
               , new Object[] {
               H00113_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV12pproductoId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cproductoId ;
      private short AV10cproveedorId ;
      private short AV11ctipoDeProductoId ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A5productoId ;
      private short A7proveedorId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short A6tipoDeProductoId ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int nRC_GXsfl_74 ;
      private int subGrid1_Rows ;
      private int nGXsfl_74_idx=1 ;
      private int edtavCproductoid_Enabled ;
      private int edtavCproductoid_Visible ;
      private int edtavCproductoname_Visible ;
      private int edtavCproductoname_Enabled ;
      private int edtavCproductosellprice_Enabled ;
      private int edtavCproductosellprice_Visible ;
      private int edtavCproductocostprice_Enabled ;
      private int edtavCproductocostprice_Visible ;
      private int edtavCproveedorid_Enabled ;
      private int edtavCproveedorid_Visible ;
      private int edtavCtipodeproductoid_Enabled ;
      private int edtavCtipodeproductoid_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private decimal AV8cproductoSellPrice ;
      private decimal AV9cproductoCostPrice ;
      private decimal A27productoSellPrice ;
      private decimal A28productoCostPrice ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divProductoidfiltercontainer_Class ;
      private string divProductonamefiltercontainer_Class ;
      private string divProductosellpricefiltercontainer_Class ;
      private string divProductocostpricefiltercontainer_Class ;
      private string divProveedoridfiltercontainer_Class ;
      private string divTipodeproductoidfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_74_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divProductoidfiltercontainer_Internalname ;
      private string lblLblproductoidfilter_Internalname ;
      private string lblLblproductoidfilter_Jsonclick ;
      private string edtavCproductoid_Internalname ;
      private string TempTags ;
      private string edtavCproductoid_Jsonclick ;
      private string divProductonamefiltercontainer_Internalname ;
      private string lblLblproductonamefilter_Internalname ;
      private string lblLblproductonamefilter_Jsonclick ;
      private string edtavCproductoname_Internalname ;
      private string edtavCproductoname_Jsonclick ;
      private string divProductosellpricefiltercontainer_Internalname ;
      private string lblLblproductosellpricefilter_Internalname ;
      private string lblLblproductosellpricefilter_Jsonclick ;
      private string edtavCproductosellprice_Internalname ;
      private string edtavCproductosellprice_Jsonclick ;
      private string divProductocostpricefiltercontainer_Internalname ;
      private string lblLblproductocostpricefilter_Internalname ;
      private string lblLblproductocostpricefilter_Jsonclick ;
      private string edtavCproductocostprice_Internalname ;
      private string edtavCproductocostprice_Jsonclick ;
      private string divProveedoridfiltercontainer_Internalname ;
      private string lblLblproveedoridfilter_Internalname ;
      private string lblLblproveedoridfilter_Jsonclick ;
      private string edtavCproveedorid_Internalname ;
      private string edtavCproveedorid_Jsonclick ;
      private string divTipodeproductoidfiltercontainer_Internalname ;
      private string lblLbltipodeproductoidfilter_Internalname ;
      private string lblLbltipodeproductoidfilter_Jsonclick ;
      private string edtavCtipodeproductoid_Internalname ;
      private string edtavCtipodeproductoid_Jsonclick ;
      private string divGridtable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtproductoId_Internalname ;
      private string edtproductoName_Internalname ;
      private string edtproductoImage_Internalname ;
      private string edtproductoSellPrice_Internalname ;
      private string edtproductoCostPrice_Internalname ;
      private string edtproveedorId_Internalname ;
      private string scmdbuf ;
      private string AV13ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtproductoId_Jsonclick ;
      private string edtproductoName_Link ;
      private string edtproductoName_Jsonclick ;
      private string edtproductoSellPrice_Jsonclick ;
      private string edtproductoCostPrice_Jsonclick ;
      private string edtproveedorId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private bool A26productoImage_IsBlob ;
      private string AV7cproductoName ;
      private string AV16Linkselection_GXI ;
      private string A25productoName ;
      private string A40000productoImage_GXI ;
      private string lV7cproductoName ;
      private string AV5LinkSelection ;
      private string A26productoImage ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H00112_A6tipoDeProductoId ;
      private short[] H00112_A7proveedorId ;
      private decimal[] H00112_A28productoCostPrice ;
      private decimal[] H00112_A27productoSellPrice ;
      private string[] H00112_A40000productoImage_GXI ;
      private string[] H00112_A25productoName ;
      private short[] H00112_A5productoId ;
      private string[] H00112_A26productoImage ;
      private long[] H00113_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP0_pproductoId ;
      private GXWebForm Form ;
   }

   public class gx0040__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00112( IGxContext context ,
                                             string AV7cproductoName ,
                                             decimal AV8cproductoSellPrice ,
                                             decimal AV9cproductoCostPrice ,
                                             short AV10cproveedorId ,
                                             short AV11ctipoDeProductoId ,
                                             string A25productoName ,
                                             decimal A27productoSellPrice ,
                                             decimal A28productoCostPrice ,
                                             short A7proveedorId ,
                                             short A6tipoDeProductoId ,
                                             short AV6cproductoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [tipoDeProductoId], [proveedorId], [productoCostPrice], [productoSellPrice], [productoImage_GXI], [productoName], [productoId], [productoImage]";
         sFromString = " FROM [producto]";
         sOrderString = "";
         AddWhere(sWhereString, "([productoId] >= @AV6cproductoId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cproductoName)) )
         {
            AddWhere(sWhereString, "([productoName] like @lV7cproductoName)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV8cproductoSellPrice) )
         {
            AddWhere(sWhereString, "([productoSellPrice] >= @AV8cproductoSellPrice)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV9cproductoCostPrice) )
         {
            AddWhere(sWhereString, "([productoCostPrice] >= @AV9cproductoCostPrice)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV10cproveedorId) )
         {
            AddWhere(sWhereString, "([proveedorId] >= @AV10cproveedorId)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV11ctipoDeProductoId) )
         {
            AddWhere(sWhereString, "([tipoDeProductoId] >= @AV11ctipoDeProductoId)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         sOrderString += " ORDER BY [productoId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00113( IGxContext context ,
                                             string AV7cproductoName ,
                                             decimal AV8cproductoSellPrice ,
                                             decimal AV9cproductoCostPrice ,
                                             short AV10cproveedorId ,
                                             short AV11ctipoDeProductoId ,
                                             string A25productoName ,
                                             decimal A27productoSellPrice ,
                                             decimal A28productoCostPrice ,
                                             short A7proveedorId ,
                                             short A6tipoDeProductoId ,
                                             short AV6cproductoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [producto]";
         AddWhere(sWhereString, "([productoId] >= @AV6cproductoId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cproductoName)) )
         {
            AddWhere(sWhereString, "([productoName] like @lV7cproductoName)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV8cproductoSellPrice) )
         {
            AddWhere(sWhereString, "([productoSellPrice] >= @AV8cproductoSellPrice)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV9cproductoCostPrice) )
         {
            AddWhere(sWhereString, "([productoCostPrice] >= @AV9cproductoCostPrice)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV10cproveedorId) )
         {
            AddWhere(sWhereString, "([proveedorId] >= @AV10cproveedorId)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV11ctipoDeProductoId) )
         {
            AddWhere(sWhereString, "([tipoDeProductoId] >= @AV11ctipoDeProductoId)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00112(context, (string)dynConstraints[0] , (decimal)dynConstraints[1] , (decimal)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] );
               case 1 :
                     return conditional_H00113(context, (string)dynConstraints[0] , (decimal)dynConstraints[1] , (decimal)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH00112;
          prmH00112 = new Object[] {
          new ParDef("@AV6cproductoId",GXType.Int16,4,0) ,
          new ParDef("@lV7cproductoName",GXType.NVarChar,40,0) ,
          new ParDef("@AV8cproductoSellPrice",GXType.Decimal,10,2) ,
          new ParDef("@AV9cproductoCostPrice",GXType.Decimal,10,2) ,
          new ParDef("@AV10cproveedorId",GXType.Int16,4,0) ,
          new ParDef("@AV11ctipoDeProductoId",GXType.Int16,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00113;
          prmH00113 = new Object[] {
          new ParDef("@AV6cproductoId",GXType.Int16,4,0) ,
          new ParDef("@lV7cproductoName",GXType.NVarChar,40,0) ,
          new ParDef("@AV8cproductoSellPrice",GXType.Decimal,10,2) ,
          new ParDef("@AV9cproductoCostPrice",GXType.Decimal,10,2) ,
          new ParDef("@AV10cproveedorId",GXType.Int16,4,0) ,
          new ParDef("@AV11ctipoDeProductoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00112", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00112,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00113", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00113,1, GxCacheFrequency.OFF ,false,false )
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
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(5));
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
