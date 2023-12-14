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
   public class productostock : GXDataArea
   {
      public productostock( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("xd2", true);
      }

      public productostock( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavSucursalid = new GXCombobox();
         dynavProveedorid = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
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
         nRC_GXsfl_19 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_19"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_19_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_19_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_19_idx = GetPar( "sGXsfl_19_idx");
         AV9agregarStock = GetPar( "agregarStock");
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
         dynavProveedorid.FromJSonString( GetNextPar( ));
         AV7proveedorId = (short)(Math.Round(NumberUtil.Val( GetPar( "proveedorId"), "."), 18, MidpointRounding.ToEven));
         AV9agregarStock = GetPar( "agregarStock");
         dynavSucursalid.FromJSonString( GetNextPar( ));
         AV6sucursalId = (short)(Math.Round(NumberUtil.Val( GetPar( "sucursalId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( AV7proveedorId, AV9agregarStock, AV6sucursalId) ;
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

      public override short ExecuteStartEvent( )
      {
         PA0G2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0G2( ) ;
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
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("productostock.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7proveedorId), 4, 0, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_19", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_19), 8, 0, ",", "")));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
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
            WE0G2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0G2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("productostock.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "productoStock" ;
      }

      public override string GetPgmdesc( )
      {
         return "producto Stock" ;
      }

      protected void WB0G0( )
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavSucursalid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavSucursalid_Internalname, "Id de la sucursal", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'" + sGXsfl_19_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSucursalid, dynavSucursalid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV6sucursalId), 4, 0)), 1, dynavSucursalid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSucursalid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,8);\"", "", true, 0, "HLP_productoStock.htm");
            dynavSucursalid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6sucursalId), 4, 0));
            AssignProp("", false, dynavSucursalid_Internalname, "Values", (string)(dynavSucursalid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavProveedorid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavProveedorid_Internalname, "Id del proveedor", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 12,'',false,'" + sGXsfl_19_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavProveedorid, dynavProveedorid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV7proveedorId), 4, 0)), 1, dynavProveedorid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavProveedorid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,12);\"", "", true, 0, "HLP_productoStock.htm");
            dynavProveedorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7proveedorId), 4, 0));
            AssignProp("", false, dynavProveedorid_Internalname, "Values", (string)(dynavProveedorid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCountstock_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCountstock_Internalname, "Stock a agregar", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_19_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCountstock_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5countStock), 10, 0, ",", "")), StringUtil.LTrim( ((edtavCountstock_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5countStock), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV5countStock), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCountstock_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCountstock_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Stock", "right", false, "", "HLP_productoStock.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl19( ) ;
         }
         if ( wbEnd == 19 )
         {
            wbEnd = 0;
            nRC_GXsfl_19 = (int)(nGXsfl_19_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavMensaje_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_19_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMensaje_Internalname, AV10Mensaje, StringUtil.RTrim( context.localUtil.Format( AV10Mensaje, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMensaje_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavMensaje_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_productoStock.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 19 )
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

      protected void START0G2( )
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
            Form.Meta.addItem("description", "producto Stock", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0G0( ) ;
      }

      protected void WS0G2( )
      {
         START0G2( ) ;
         EVT0G2( ) ;
      }

      protected void EVT0G2( )
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
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "VAGREGARSTOCK.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "VAGREGARSTOCK.CLICK") == 0 ) )
                           {
                              nGXsfl_19_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_19_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_19_idx), 4, 0), 4, "0");
                              SubsflControlProps_192( ) ;
                              A5productoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtproductoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A25productoName = cgiGet( edtproductoName_Internalname);
                              A26productoImage = cgiGet( edtproductoImage_Internalname);
                              AssignProp("", false, edtproductoImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26productoImage)) ? A40000productoImage_GXI : context.convertURL( context.PathToRelativeUrl( A26productoImage))), !bGXsfl_19_Refreshing);
                              AssignProp("", false, edtproductoImage_Internalname, "SrcSet", context.GetImageSrcSet( A26productoImage), true);
                              AV9agregarStock = cgiGet( edtavAgregarstock_Internalname);
                              AssignAttri("", false, edtavAgregarstock_Internalname, AV9agregarStock);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E110G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VAGREGARSTOCK.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E120G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E130G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Proveedorid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vPROVEEDORID"), ",", ".") != Convert.ToDecimal( AV7proveedorId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
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

      protected void WE0G2( )
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

      protected void PA0G2( )
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = dynavSucursalid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvPROVEEDORID0G1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvPROVEEDORID_data0G1( ) ;
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

      protected void GXVvPROVEEDORID_html0G1( )
      {
         short gxdynajaxvalue;
         GXDLVvPROVEEDORID_data0G1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavProveedorid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavProveedorid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavProveedorid.ItemCount > 0 )
         {
            AV7proveedorId = (short)(Math.Round(NumberUtil.Val( dynavProveedorid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7proveedorId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7proveedorId", StringUtil.LTrimStr( (decimal)(AV7proveedorId), 4, 0));
         }
      }

      protected void GXDLVvPROVEEDORID_data0G1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H000G2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H000G2_A7proveedorId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H000G2_A21proveedorName[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvSUCURSALID0G1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSUCURSALID_data0G1( ) ;
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

      protected void GXVvSUCURSALID_html0G1( )
      {
         short gxdynajaxvalue;
         GXDLVvSUCURSALID_data0G1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavSucursalid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavSucursalid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavSucursalid.ItemCount > 0 )
         {
            AV6sucursalId = (short)(Math.Round(NumberUtil.Val( dynavSucursalid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV6sucursalId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV6sucursalId", StringUtil.LTrimStr( (decimal)(AV6sucursalId), 4, 0));
         }
      }

      protected void GXDLVvSUCURSALID_data0G1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H000G3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H000G3_A2sucursalId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H000G3_A13sucursalName[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_192( ) ;
         while ( nGXsfl_19_idx <= nRC_GXsfl_19 )
         {
            sendrow_192( ) ;
            nGXsfl_19_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_19_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_19_idx+1);
            sGXsfl_19_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_19_idx), 4, 0), 4, "0");
            SubsflControlProps_192( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( short AV7proveedorId ,
                                        string AV9agregarStock ,
                                        short AV6sucursalId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0G2( ) ;
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
            dynavProveedorid.Name = "vPROVEEDORID";
            dynavProveedorid.WebTags = "";
            dynavProveedorid.removeAllItems();
            /* Using cursor H000G4 */
            pr_default.execute(2);
            while ( (pr_default.getStatus(2) != 101) )
            {
               dynavProveedorid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H000G4_A7proveedorId[0]), 4, 0)), H000G4_A21proveedorName[0], 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            if ( dynavProveedorid.ItemCount > 0 )
            {
               AV7proveedorId = (short)(Math.Round(NumberUtil.Val( dynavProveedorid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7proveedorId), 4, 0))), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7proveedorId", StringUtil.LTrimStr( (decimal)(AV7proveedorId), 4, 0));
            }
            dynavSucursalid.Name = "vSUCURSALID";
            dynavSucursalid.WebTags = "";
            dynavSucursalid.removeAllItems();
            /* Using cursor H000G5 */
            pr_default.execute(3);
            while ( (pr_default.getStatus(3) != 101) )
            {
               dynavSucursalid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H000G5_A2sucursalId[0]), 4, 0)), H000G5_A13sucursalName[0], 0);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( dynavSucursalid.ItemCount > 0 )
            {
               AV6sucursalId = (short)(Math.Round(NumberUtil.Val( dynavSucursalid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV6sucursalId), 4, 0))), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6sucursalId", StringUtil.LTrimStr( (decimal)(AV6sucursalId), 4, 0));
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavSucursalid.ItemCount > 0 )
         {
            AV6sucursalId = (short)(Math.Round(NumberUtil.Val( dynavSucursalid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV6sucursalId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV6sucursalId", StringUtil.LTrimStr( (decimal)(AV6sucursalId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSucursalid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6sucursalId), 4, 0));
            AssignProp("", false, dynavSucursalid_Internalname, "Values", dynavSucursalid.ToJavascriptSource(), true);
         }
         if ( dynavProveedorid.ItemCount > 0 )
         {
            AV7proveedorId = (short)(Math.Round(NumberUtil.Val( dynavProveedorid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7proveedorId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7proveedorId", StringUtil.LTrimStr( (decimal)(AV7proveedorId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavProveedorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7proveedorId), 4, 0));
            AssignProp("", false, dynavProveedorid_Internalname, "Values", dynavProveedorid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0G2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavAgregarstock_Enabled = 0;
         AssignProp("", false, edtavAgregarstock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAgregarstock_Enabled), 5, 0), !bGXsfl_19_Refreshing);
         edtavMensaje_Enabled = 0;
         AssignProp("", false, edtavMensaje_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMensaje_Enabled), 5, 0), true);
      }

      protected void RF0G2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 19;
         nGXsfl_19_idx = 1;
         sGXsfl_19_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_19_idx), 4, 0), 4, "0");
         SubsflControlProps_192( ) ;
         bGXsfl_19_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "Grid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_192( ) ;
            pr_default.dynParam(4, new Object[]{ new Object[]{
                                                 AV7proveedorId ,
                                                 A7proveedorId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor H000G6 */
            pr_default.execute(4, new Object[] {AV7proveedorId});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A7proveedorId = H000G6_A7proveedorId[0];
               A40000productoImage_GXI = H000G6_A40000productoImage_GXI[0];
               AssignProp("", false, edtproductoImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26productoImage)) ? A40000productoImage_GXI : context.convertURL( context.PathToRelativeUrl( A26productoImage))), !bGXsfl_19_Refreshing);
               AssignProp("", false, edtproductoImage_Internalname, "SrcSet", context.GetImageSrcSet( A26productoImage), true);
               A25productoName = H000G6_A25productoName[0];
               A5productoId = H000G6_A5productoId[0];
               A26productoImage = H000G6_A26productoImage[0];
               AssignProp("", false, edtproductoImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26productoImage)) ? A40000productoImage_GXI : context.convertURL( context.PathToRelativeUrl( A26productoImage))), !bGXsfl_19_Refreshing);
               AssignProp("", false, edtproductoImage_Internalname, "SrcSet", context.GetImageSrcSet( A26productoImage), true);
               /* Execute user event: Load */
               E130G2 ();
               pr_default.readNext(4);
            }
            pr_default.close(4);
            wbEnd = 19;
            WB0G0( ) ;
         }
         bGXsfl_19_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0G2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTOID"+"_"+sGXsfl_19_idx, GetSecureSignedToken( sGXsfl_19_idx, context.localUtil.Format( (decimal)(A5productoId), "ZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavAgregarstock_Enabled = 0;
         AssignProp("", false, edtavAgregarstock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAgregarstock_Enabled), 5, 0), !bGXsfl_19_Refreshing);
         edtavMensaje_Enabled = 0;
         AssignProp("", false, edtavMensaje_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMensaje_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0G0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110G2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_19 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_19"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            dynavSucursalid.Name = dynavSucursalid_Internalname;
            dynavSucursalid.CurrentValue = cgiGet( dynavSucursalid_Internalname);
            AV6sucursalId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynavSucursalid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV6sucursalId", StringUtil.LTrimStr( (decimal)(AV6sucursalId), 4, 0));
            dynavProveedorid.Name = dynavProveedorid_Internalname;
            dynavProveedorid.CurrentValue = cgiGet( dynavProveedorid_Internalname);
            AV7proveedorId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynavProveedorid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7proveedorId", StringUtil.LTrimStr( (decimal)(AV7proveedorId), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCountstock_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCountstock_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCOUNTSTOCK");
               GX_FocusControl = edtavCountstock_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5countStock = 0;
               AssignAttri("", false, "AV5countStock", StringUtil.LTrimStr( (decimal)(AV5countStock), 10, 0));
            }
            else
            {
               AV5countStock = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCountstock_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV5countStock", StringUtil.LTrimStr( (decimal)(AV5countStock), 10, 0));
            }
            AV10Mensaje = cgiGet( edtavMensaje_Internalname);
            AssignAttri("", false, "AV10Mensaje", AV10Mensaje);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E110G2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E110G2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV9agregarStock = "Agregar stock";
         AssignAttri("", false, edtavAgregarstock_Internalname, AV9agregarStock);
      }

      protected void E120G2( )
      {
         /* Agregarstock_Click Routine */
         returnInSub = false;
         AV10Mensaje = "";
         AssignAttri("", false, "AV10Mensaje", AV10Mensaje);
         if ( AV5countStock > 0 )
         {
            GXt_char1 = AV10Mensaje;
            new actustock(context ).execute(  AV6sucursalId,  AV7proveedorId,  A5productoId,  AV5countStock, out  GXt_char1) ;
            AV10Mensaje = GXt_char1;
            AssignAttri("", false, "AV10Mensaje", AV10Mensaje);
         }
         else
         {
            AV10Mensaje = "El stock tiene que ser mayor a 0";
            AssignAttri("", false, "AV10Mensaje", AV10Mensaje);
         }
         /*  Sending Event outputs  */
      }

      private void E130G2( )
      {
         /* Load Routine */
         returnInSub = false;
         sendrow_192( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_19_Refreshing )
         {
            DoAjaxLoad(19, Grid1Row);
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA0G2( ) ;
         WS0G2( ) ;
         WE0G2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20233241858666", true, true);
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
         context.AddJavascriptSource("productostock.js", "?20233241858666", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_192( )
      {
         edtproductoId_Internalname = "PRODUCTOID_"+sGXsfl_19_idx;
         edtproductoName_Internalname = "PRODUCTONAME_"+sGXsfl_19_idx;
         edtproductoImage_Internalname = "PRODUCTOIMAGE_"+sGXsfl_19_idx;
         edtavAgregarstock_Internalname = "vAGREGARSTOCK_"+sGXsfl_19_idx;
      }

      protected void SubsflControlProps_fel_192( )
      {
         edtproductoId_Internalname = "PRODUCTOID_"+sGXsfl_19_fel_idx;
         edtproductoName_Internalname = "PRODUCTONAME_"+sGXsfl_19_fel_idx;
         edtproductoImage_Internalname = "PRODUCTOIMAGE_"+sGXsfl_19_fel_idx;
         edtavAgregarstock_Internalname = "vAGREGARSTOCK_"+sGXsfl_19_fel_idx;
      }

      protected void sendrow_192( )
      {
         SubsflControlProps_192( ) ;
         WB0G0( ) ;
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
            if ( ((int)((nGXsfl_19_idx) % (2))) == 0 )
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
            context.WriteHtmlText( " class=\""+"Grid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_19_idx+"\">") ;
         }
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtproductoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A5productoId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A5productoId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtproductoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)19,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtproductoName_Internalname,(string)A25productoName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtproductoName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)19,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
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
         Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtproductoImage_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A26productoImage_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavAgregarstock_Enabled!=0)&&(edtavAgregarstock_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 23,'',false,'"+sGXsfl_19_idx+"',19)\"" : " ");
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAgregarstock_Internalname,(string)AV9agregarStock,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavAgregarstock_Enabled!=0)&&(edtavAgregarstock_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,23);\"" : " "),"'"+""+"'"+",false,"+"'"+"EVAGREGARSTOCK.CLICK."+sGXsfl_19_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavAgregarstock_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavAgregarstock_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)19,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         send_integrity_lvl_hashes0G2( ) ;
         Grid1Container.AddRow(Grid1Row);
         nGXsfl_19_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_19_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_19_idx+1);
         sGXsfl_19_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_19_idx), 4, 0), 4, "0");
         SubsflControlProps_192( ) ;
         /* End function sendrow_192 */
      }

      protected void init_web_controls( )
      {
         dynavSucursalid.Name = "vSUCURSALID";
         dynavSucursalid.WebTags = "";
         dynavSucursalid.removeAllItems();
         /* Using cursor H000G7 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            dynavSucursalid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H000G7_A2sucursalId[0]), 4, 0)), H000G7_A13sucursalName[0], 0);
            pr_default.readNext(5);
         }
         pr_default.close(5);
         if ( dynavSucursalid.ItemCount > 0 )
         {
            AV6sucursalId = (short)(Math.Round(NumberUtil.Val( dynavSucursalid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV6sucursalId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV6sucursalId", StringUtil.LTrimStr( (decimal)(AV6sucursalId), 4, 0));
         }
         dynavProveedorid.Name = "vPROVEEDORID";
         dynavProveedorid.WebTags = "";
         dynavProveedorid.removeAllItems();
         /* Using cursor H000G8 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            dynavProveedorid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H000G8_A7proveedorId[0]), 4, 0)), H000G8_A21proveedorName[0], 0);
            pr_default.readNext(6);
         }
         pr_default.close(6);
         if ( dynavProveedorid.ItemCount > 0 )
         {
            AV7proveedorId = (short)(Math.Round(NumberUtil.Val( dynavProveedorid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7proveedorId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7proveedorId", StringUtil.LTrimStr( (decimal)(AV7proveedorId), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl19( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"19\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "Grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "producto Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "producto Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ImageAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "producto Image") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
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
            Grid1Container.AddObjectProperty("Class", "Grid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A5productoId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A25productoName));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( A26productoImage));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( AV9agregarStock));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAgregarstock_Enabled), 5, 0, ".", "")));
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
         dynavSucursalid_Internalname = "vSUCURSALID";
         dynavProveedorid_Internalname = "vPROVEEDORID";
         edtavCountstock_Internalname = "vCOUNTSTOCK";
         edtproductoId_Internalname = "PRODUCTOID";
         edtproductoName_Internalname = "PRODUCTONAME";
         edtproductoImage_Internalname = "PRODUCTOIMAGE";
         edtavAgregarstock_Internalname = "vAGREGARSTOCK";
         edtavMensaje_Internalname = "vMENSAJE";
         divMaintable_Internalname = "MAINTABLE";
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
         edtavAgregarstock_Jsonclick = "";
         edtavAgregarstock_Visible = -1;
         edtavAgregarstock_Enabled = 1;
         edtproductoName_Jsonclick = "";
         edtproductoId_Jsonclick = "";
         subGrid1_Class = "Grid";
         subGrid1_Backcolorstyle = 0;
         edtavMensaje_Jsonclick = "";
         edtavMensaje_Enabled = 1;
         edtavCountstock_Jsonclick = "";
         edtavCountstock_Enabled = 1;
         dynavProveedorid_Jsonclick = "";
         dynavProveedorid.Enabled = 1;
         dynavSucursalid_Jsonclick = "";
         dynavSucursalid.Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "producto Stock";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV9agregarStock',fld:'vAGREGARSTOCK',pic:''},{av:'dynavProveedorid'},{av:'AV7proveedorId',fld:'vPROVEEDORID',pic:'ZZZ9'},{av:'dynavSucursalid'},{av:'AV6sucursalId',fld:'vSUCURSALID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VAGREGARSTOCK.CLICK","{handler:'E120G2',iparms:[{av:'AV5countStock',fld:'vCOUNTSTOCK',pic:'ZZZZZZZZZ9'},{av:'dynavSucursalid'},{av:'AV6sucursalId',fld:'vSUCURSALID',pic:'ZZZ9'},{av:'dynavProveedorid'},{av:'AV7proveedorId',fld:'vPROVEEDORID',pic:'ZZZ9'},{av:'A5productoId',fld:'PRODUCTOID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("VAGREGARSTOCK.CLICK",",oparms:[{av:'AV10Mensaje',fld:'vMENSAJE',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Agregarstock',iparms:[]");
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
         AV9agregarStock = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         AV10Mensaje = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A25productoName = "";
         A26productoImage = "";
         A40000productoImage_GXI = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H000G2_A7proveedorId = new short[1] ;
         H000G2_A21proveedorName = new string[] {""} ;
         H000G3_A2sucursalId = new short[1] ;
         H000G3_A13sucursalName = new string[] {""} ;
         H000G4_A7proveedorId = new short[1] ;
         H000G4_A21proveedorName = new string[] {""} ;
         H000G5_A2sucursalId = new short[1] ;
         H000G5_A13sucursalName = new string[] {""} ;
         H000G6_A7proveedorId = new short[1] ;
         H000G6_A40000productoImage_GXI = new string[] {""} ;
         H000G6_A25productoName = new string[] {""} ;
         H000G6_A5productoId = new short[1] ;
         H000G6_A26productoImage = new string[] {""} ;
         GXt_char1 = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         ROClassString = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         H000G7_A2sucursalId = new short[1] ;
         H000G7_A13sucursalName = new string[] {""} ;
         H000G8_A7proveedorId = new short[1] ;
         H000G8_A21proveedorName = new string[] {""} ;
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.productostock__default(),
            new Object[][] {
                new Object[] {
               H000G2_A7proveedorId, H000G2_A21proveedorName
               }
               , new Object[] {
               H000G3_A2sucursalId, H000G3_A13sucursalName
               }
               , new Object[] {
               H000G4_A7proveedorId, H000G4_A21proveedorName
               }
               , new Object[] {
               H000G5_A2sucursalId, H000G5_A13sucursalName
               }
               , new Object[] {
               H000G6_A7proveedorId, H000G6_A40000productoImage_GXI, H000G6_A25productoName, H000G6_A5productoId, H000G6_A26productoImage
               }
               , new Object[] {
               H000G7_A2sucursalId, H000G7_A13sucursalName
               }
               , new Object[] {
               H000G8_A7proveedorId, H000G8_A21proveedorName
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavAgregarstock_Enabled = 0;
         edtavMensaje_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV7proveedorId ;
      private short AV6sucursalId ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A5productoId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short A7proveedorId ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short GRID1_nEOF ;
      private int nRC_GXsfl_19 ;
      private int nGXsfl_19_idx=1 ;
      private int edtavCountstock_Enabled ;
      private int edtavMensaje_Enabled ;
      private int gxdynajaxindex ;
      private int subGrid1_Islastpage ;
      private int edtavAgregarstock_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int edtavAgregarstock_Visible ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV5countStock ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_19_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string dynavSucursalid_Internalname ;
      private string TempTags ;
      private string dynavSucursalid_Jsonclick ;
      private string dynavProveedorid_Internalname ;
      private string dynavProveedorid_Jsonclick ;
      private string edtavCountstock_Internalname ;
      private string edtavCountstock_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string edtavMensaje_Internalname ;
      private string edtavMensaje_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtproductoId_Internalname ;
      private string edtproductoName_Internalname ;
      private string edtproductoImage_Internalname ;
      private string edtavAgregarstock_Internalname ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private string sGXsfl_19_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string ROClassString ;
      private string edtproductoId_Jsonclick ;
      private string edtproductoName_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string edtavAgregarstock_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_19_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool A26productoImage_IsBlob ;
      private string AV9agregarStock ;
      private string AV10Mensaje ;
      private string A25productoName ;
      private string A40000productoImage_GXI ;
      private string A26productoImage ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavSucursalid ;
      private GXCombobox dynavProveedorid ;
      private IDataStoreProvider pr_default ;
      private short[] H000G2_A7proveedorId ;
      private string[] H000G2_A21proveedorName ;
      private short[] H000G3_A2sucursalId ;
      private string[] H000G3_A13sucursalName ;
      private short[] H000G4_A7proveedorId ;
      private string[] H000G4_A21proveedorName ;
      private short[] H000G5_A2sucursalId ;
      private string[] H000G5_A13sucursalName ;
      private short[] H000G6_A7proveedorId ;
      private string[] H000G6_A40000productoImage_GXI ;
      private string[] H000G6_A25productoName ;
      private short[] H000G6_A5productoId ;
      private string[] H000G6_A26productoImage ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short[] H000G7_A2sucursalId ;
      private string[] H000G7_A13sucursalName ;
      private short[] H000G8_A7proveedorId ;
      private string[] H000G8_A21proveedorName ;
      private GXWebForm Form ;
   }

   public class productostock__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000G6( IGxContext context ,
                                             short AV7proveedorId ,
                                             short A7proveedorId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[1];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [proveedorId], [productoImage_GXI], [productoName], [productoId], [productoImage] FROM [producto]";
         if ( ! (0==AV7proveedorId) )
         {
            AddWhere(sWhereString, "([proveedorId] = @AV7proveedorId)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [productoId]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 4 :
                     return conditional_H000G6(context, (short)dynConstraints[0] , (short)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000G2;
          prmH000G2 = new Object[] {
          };
          Object[] prmH000G3;
          prmH000G3 = new Object[] {
          };
          Object[] prmH000G4;
          prmH000G4 = new Object[] {
          };
          Object[] prmH000G5;
          prmH000G5 = new Object[] {
          };
          Object[] prmH000G7;
          prmH000G7 = new Object[] {
          };
          Object[] prmH000G8;
          prmH000G8 = new Object[] {
          };
          Object[] prmH000G6;
          prmH000G6 = new Object[] {
          new ParDef("@AV7proveedorId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000G2", "SELECT [proveedorId], [proveedorName] FROM [proveedor] ORDER BY [proveedorName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000G2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000G3", "SELECT [sucursalId], [sucursalName] FROM [sucursal] ORDER BY [sucursalName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000G3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000G4", "SELECT [proveedorId], [proveedorName] FROM [proveedor] ORDER BY [proveedorName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000G4,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000G5", "SELECT [sucursalId], [sucursalName] FROM [sucursal] ORDER BY [sucursalName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000G5,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000G6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000G6,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000G7", "SELECT [sucursalId], [sucursalName] FROM [sucursal] ORDER BY [sucursalName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000G7,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000G8", "SELECT [proveedorId], [proveedorName] FROM [proveedor] ORDER BY [proveedorName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000G8,0, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(2));
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
