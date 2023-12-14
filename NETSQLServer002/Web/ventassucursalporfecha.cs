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
   public class ventassucursalporfecha : GXDataArea
   {
      public ventassucursalporfecha( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("xd2", true);
      }

      public ventassucursalporfecha( IGxContext context )
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
         PA0F2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0F2( ) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 55580), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 55580), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 55580), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("ventassucursalporfecha.aspx") +"\">") ;
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
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
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
            WE0F2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0F2( ) ;
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
         return formatLink("ventassucursalporfecha.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ventasSucursalPorFecha" ;
      }

      public override string GetPgmdesc( )
      {
         return "ventas Sucursal Por Fecha" ;
      }

      protected void WB0F0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavSucursalid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavSucursalid_Internalname, "Id de la sucursal", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSucursalid, dynavSucursalid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV7sucursalId), 4, 0)), 1, dynavSucursalid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSucursalid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,8);\"", "", true, 0, "HLP_ventasSucursalPorFecha.htm");
            dynavSucursalid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7sucursalId), 4, 0));
            AssignProp("", false, dynavSucursalid_Internalname, "Values", (string)(dynavSucursalid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavFechainicio_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFechainicio_Internalname, "Fecha de inicio", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFechainicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFechainicio_Internalname, context.localUtil.Format(AV5fechaInicio, "99/99/99"), context.localUtil.Format( AV5fechaInicio, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,14);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFechainicio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFechainicio_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_ventasSucursalPorFecha.htm");
            GxWebStd.gx_bitmap( context, edtavFechainicio_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFechainicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ventasSucursalPorFecha.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavFechafin_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFechafin_Internalname, "Fecha de fin", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFechafin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFechafin_Internalname, context.localUtil.Format(AV6fechaFin, "99/99/99"), context.localUtil.Format( AV6fechaFin, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,18);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFechafin_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFechafin_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_ventasSucursalPorFecha.htm");
            GxWebStd.gx_bitmap( context, edtavFechafin_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFechafin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ventasSucursalPorFecha.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttListarventas_Internalname, "", "Listar ventas", bttListarventas_Jsonclick, 5, "Listar ventas", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'LISTARVENTAS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ventasSucursalPorFecha.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0F2( )
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
            Form.Meta.addItem("description", "ventas Sucursal Por Fecha", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0F0( ) ;
      }

      protected void WS0F2( )
      {
         START0F2( ) ;
         EVT0F2( ) ;
      }

      protected void EVT0F2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'LISTARVENTAS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'listarVentas' */
                              E110F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E120F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
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
                              dynload_actions( ) ;
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
      }

      protected void WE0F2( )
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

      protected void PA0F2( )
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

      protected void GXDLVvSUCURSALID0F1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSUCURSALID_data0F1( ) ;
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

      protected void GXVvSUCURSALID_html0F1( )
      {
         short gxdynajaxvalue;
         GXDLVvSUCURSALID_data0F1( ) ;
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
            AV7sucursalId = (short)(Math.Round(NumberUtil.Val( dynavSucursalid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7sucursalId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7sucursalId", StringUtil.LTrimStr( (decimal)(AV7sucursalId), 4, 0));
         }
      }

      protected void GXDLVvSUCURSALID_data0F1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H000F2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H000F2_A2sucursalId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H000F2_A13sucursalName[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynavSucursalid.Name = "vSUCURSALID";
            dynavSucursalid.WebTags = "";
            dynavSucursalid.removeAllItems();
            /* Using cursor H000F3 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               dynavSucursalid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H000F3_A2sucursalId[0]), 4, 0)), H000F3_A13sucursalName[0], 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( dynavSucursalid.ItemCount > 0 )
            {
               AV7sucursalId = (short)(Math.Round(NumberUtil.Val( dynavSucursalid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7sucursalId), 4, 0))), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7sucursalId", StringUtil.LTrimStr( (decimal)(AV7sucursalId), 4, 0));
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavSucursalid.ItemCount > 0 )
         {
            AV7sucursalId = (short)(Math.Round(NumberUtil.Val( dynavSucursalid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7sucursalId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7sucursalId", StringUtil.LTrimStr( (decimal)(AV7sucursalId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSucursalid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7sucursalId), 4, 0));
            AssignProp("", false, dynavSucursalid_Internalname, "Values", dynavSucursalid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0F2( ) ;
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

      protected void RF0F2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E120F2 ();
            WB0F0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0F2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0F0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            dynavSucursalid.CurrentValue = cgiGet( dynavSucursalid_Internalname);
            AV7sucursalId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynavSucursalid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7sucursalId", StringUtil.LTrimStr( (decimal)(AV7sucursalId), 4, 0));
            if ( context.localUtil.VCDate( cgiGet( edtavFechainicio_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"fecha Inicio"}), 1, "vFECHAINICIO");
               GX_FocusControl = edtavFechainicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5fechaInicio = DateTime.MinValue;
               AssignAttri("", false, "AV5fechaInicio", context.localUtil.Format(AV5fechaInicio, "99/99/99"));
            }
            else
            {
               AV5fechaInicio = context.localUtil.CToD( cgiGet( edtavFechainicio_Internalname), 2);
               AssignAttri("", false, "AV5fechaInicio", context.localUtil.Format(AV5fechaInicio, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavFechafin_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"fecha Fin"}), 1, "vFECHAFIN");
               GX_FocusControl = edtavFechafin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6fechaFin = DateTime.MinValue;
               AssignAttri("", false, "AV6fechaFin", context.localUtil.Format(AV6fechaFin, "99/99/99"));
            }
            else
            {
               AV6fechaFin = context.localUtil.CToD( cgiGet( edtavFechafin_Internalname), 2);
               AssignAttri("", false, "AV6fechaFin", context.localUtil.Format(AV6fechaFin, "99/99/99"));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void E110F2( )
      {
         /* 'listarVentas' Routine */
         returnInSub = false;
         CallWebObject(formatLink("asucursalventas.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV7sucursalId,4,0)),UrlEncode(DateTimeUtil.FormatDateParm(AV5fechaInicio)),UrlEncode(DateTimeUtil.FormatDateParm(AV6fechaFin))}, new string[] {"sucursalId","fechaInicio","fechaFin"}) );
         context.wjLocDisableFrm = 2;
      }

      protected void nextLoad( )
      {
      }

      protected void E120F2( )
      {
         /* Load Routine */
         returnInSub = false;
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
         PA0F2( ) ;
         WS0F2( ) ;
         WE0F2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20233241858637", true, true);
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
         context.AddJavascriptSource("ventassucursalporfecha.js", "?20233241858637", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynavSucursalid.Name = "vSUCURSALID";
         dynavSucursalid.WebTags = "";
         dynavSucursalid.removeAllItems();
         /* Using cursor H000F4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            dynavSucursalid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H000F4_A2sucursalId[0]), 4, 0)), H000F4_A13sucursalName[0], 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( dynavSucursalid.ItemCount > 0 )
         {
            AV7sucursalId = (short)(Math.Round(NumberUtil.Val( dynavSucursalid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7sucursalId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7sucursalId", StringUtil.LTrimStr( (decimal)(AV7sucursalId), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         dynavSucursalid_Internalname = "vSUCURSALID";
         edtavFechainicio_Internalname = "vFECHAINICIO";
         edtavFechafin_Internalname = "vFECHAFIN";
         bttListarventas_Internalname = "LISTARVENTAS";
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
         edtavFechafin_Jsonclick = "";
         edtavFechafin_Enabled = 1;
         edtavFechainicio_Jsonclick = "";
         edtavFechainicio_Enabled = 1;
         dynavSucursalid_Jsonclick = "";
         dynavSucursalid.Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "ventas Sucursal Por Fecha";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'dynavSucursalid'},{av:'AV7sucursalId',fld:'vSUCURSALID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'LISTARVENTAS'","{handler:'E110F2',iparms:[{av:'dynavSucursalid'},{av:'AV7sucursalId',fld:'vSUCURSALID',pic:'ZZZ9'},{av:'AV5fechaInicio',fld:'vFECHAINICIO',pic:''},{av:'AV6fechaFin',fld:'vFECHAFIN',pic:''}]");
         setEventMetadata("'LISTARVENTAS'",",oparms:[]}");
         setEventMetadata("VALIDV_FECHAINICIO","{handler:'Validv_Fechainicio',iparms:[]");
         setEventMetadata("VALIDV_FECHAINICIO",",oparms:[]}");
         setEventMetadata("VALIDV_FECHAFIN","{handler:'Validv_Fechafin',iparms:[]");
         setEventMetadata("VALIDV_FECHAFIN",",oparms:[]}");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         AV5fechaInicio = DateTime.MinValue;
         AV6fechaFin = DateTime.MinValue;
         ClassString = "";
         StyleString = "";
         bttListarventas_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H000F2_A2sucursalId = new short[1] ;
         H000F2_A13sucursalName = new string[] {""} ;
         H000F3_A2sucursalId = new short[1] ;
         H000F3_A13sucursalName = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         H000F4_A2sucursalId = new short[1] ;
         H000F4_A13sucursalName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ventassucursalporfecha__default(),
            new Object[][] {
                new Object[] {
               H000F2_A2sucursalId, H000F2_A13sucursalName
               }
               , new Object[] {
               H000F3_A2sucursalId, H000F3_A13sucursalName
               }
               , new Object[] {
               H000F4_A2sucursalId, H000F4_A13sucursalName
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV7sucursalId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavFechainicio_Enabled ;
      private int edtavFechafin_Enabled ;
      private int gxdynajaxindex ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
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
      private string edtavFechainicio_Internalname ;
      private string edtavFechainicio_Jsonclick ;
      private string edtavFechafin_Internalname ;
      private string edtavFechafin_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string bttListarventas_Internalname ;
      private string bttListarventas_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private DateTime AV5fechaInicio ;
      private DateTime AV6fechaFin ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavSucursalid ;
      private IDataStoreProvider pr_default ;
      private short[] H000F2_A2sucursalId ;
      private string[] H000F2_A13sucursalName ;
      private short[] H000F3_A2sucursalId ;
      private string[] H000F3_A13sucursalName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short[] H000F4_A2sucursalId ;
      private string[] H000F4_A13sucursalName ;
      private GXWebForm Form ;
   }

   public class ventassucursalporfecha__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000F2;
          prmH000F2 = new Object[] {
          };
          Object[] prmH000F3;
          prmH000F3 = new Object[] {
          };
          Object[] prmH000F4;
          prmH000F4 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H000F2", "SELECT [sucursalId], [sucursalName] FROM [sucursal] ORDER BY [sucursalName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000F2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000F3", "SELECT [sucursalId], [sucursalName] FROM [sucursal] ORDER BY [sucursalName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000F3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000F4", "SELECT [sucursalId], [sucursalName] FROM [sucursal] ORDER BY [sucursalName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000F4,0, GxCacheFrequency.OFF ,true,false )
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
       }
    }

 }

}
