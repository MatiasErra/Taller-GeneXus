gx.evt.autoSkip=!1;gx.define("sucursal",!1,function(){var n,i,t;this.ServerClass="sucursal";this.PackageName="GeneXus.Programs";this.ServerFullClass="sucursal.aspx";this.setObjectType("trn");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="xd2";this.SetStandaloneVars=function(){this.A17sucursalGeolocation=gx.fn.getControlValue("SUCURSALGEOLOCATION");this.AV7sucursalId=gx.fn.getIntegerValue("vSUCURSALID",".");this.AV11Insert_sucursalEmpleadoHeadlineId=gx.fn.getIntegerValue("vINSERT_SUCURSALEMPLEADOHEADLINEID",".");this.AV12Insert_sucursalEmpleadoAlternateId=gx.fn.getIntegerValue("vINSERT_SUCURSALEMPLEADOALTERNATEID",".");this.Gx_date=gx.fn.getDateValue("vTODAY");this.A19sucursalEmpleadoHeadlineName=gx.fn.getControlValue("SUCURSALEMPLEADOHEADLINENAME");this.A20sucursalEmpleadoAlternateName=gx.fn.getControlValue("SUCURSALEMPLEADOALTERNATENAME");this.AV15Pgmname=gx.fn.getControlValue("vPGMNAME");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV9TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Sucursalid=function(){return this.validCliEvt("Valid_Sucursalid",0,function(){try{var n=gx.util.balloon.getNew("SUCURSALID");this.AnyError=0;this.refreshOutputs([{ctrl:"SUCURSALEMPLEADOHEADLINEID"},{av:"A3sucursalEmpleadoHeadlineId",fld:"SUCURSALEMPLEADOHEADLINEID",pic:"ZZZ9"},{ctrl:"SUCURSALEMPLEADOALTERNATEID"},{av:"A4sucursalEmpleadoAlternateId",fld:"SUCURSALEMPLEADOALTERNATEID",pic:"ZZZ9"}])}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Sucursalname=function(){return this.validCliEvt("Valid_Sucursalname",0,function(){try{var n=gx.util.balloon.getNew("SUCURSALNAME");if(this.AnyError=0,gx.text.compare("",this.A13sucursalName)==0)try{n.setError("Falta el nombre");this.AnyError=gx.num.trunc(1,0)}catch(t){}this.refreshOutputs([{ctrl:"SUCURSALEMPLEADOHEADLINEID"},{av:"A3sucursalEmpleadoHeadlineId",fld:"SUCURSALEMPLEADOHEADLINEID",pic:"ZZZ9"},{ctrl:"SUCURSALEMPLEADOALTERNATEID"},{av:"A4sucursalEmpleadoAlternateId",fld:"SUCURSALEMPLEADOALTERNATEID",pic:"ZZZ9"}])}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Sucursaladdress=function(){return this.validCliEvt("Valid_Sucursaladdress",0,function(){try{var n=gx.util.balloon.getNew("SUCURSALADDRESS");if(this.AnyError=0,gx.text.compare("",this.A14sucursalAddress)==0)try{n.setError("Falta la direccion");this.AnyError=gx.num.trunc(1,0)}catch(t){}this.refreshOutputs([{ctrl:"SUCURSALEMPLEADOHEADLINEID"},{av:"A3sucursalEmpleadoHeadlineId",fld:"SUCURSALEMPLEADOHEADLINEID",pic:"ZZZ9"},{ctrl:"SUCURSALEMPLEADOALTERNATEID"},{av:"A4sucursalEmpleadoAlternateId",fld:"SUCURSALEMPLEADOALTERNATEID",pic:"ZZZ9"}])}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Sucursalempleadoheadlineid=function(){return this.validSrvEvt("Valid_Sucursalempleadoheadlineid",0).then(function(n){return n}.closure(this))};this.Valid_Sucursalempleadoalternateid=function(){return this.validSrvEvt("Valid_Sucursalempleadoalternateid",0).then(function(n){return n}.closure(this))};this.Valid_Productoid=function(){var t=gx.fn.currentGridRowImpl(73),n;return gx.fn.currentGridRowImpl(73)===0?!0:(n=gx.util.balloon.getNew("PRODUCTOID",gx.fn.currentGridRowImpl(73)),gx.fn.gridDuplicateKey(74))?(n.setError(gx.text.format(gx.getMessage("GXM_1004"),"producto","","","","","","","","")),this.AnyError=gx.num.trunc(1,0),n.show()):this.validSrvEvt("Valid_Productoid",73).then(function(n){try{this.sMode3=this.Gx_mode;this.Gx_mode=gx.fn.getGridRowMode(3,73);this.standaloneModal023();this.standaloneNotModal023()}finally{this.Gx_mode=this.sMode3}return n}.closure(this))};this.standaloneModal023=function(){try{gx.text.compare(this.Gx_mode,"INS")!=0?gx.fn.setCtrlProperty("PRODUCTOID","Enabled",0):gx.fn.setCtrlProperty("PRODUCTOID","Enabled",1)}catch(n){}};this.standaloneNotModal023=function(){};this.e12022_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e13022_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e14022_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,74,75,76,77,78,79,80,81,82,83,84,85,86];this.GXLastCtrlId=86;this.Gridsucursal_productoContainer=new gx.grid.grid(this,3,"producto",73,"Gridsucursal_producto","Gridsucursal_producto","Gridsucursal_productoContainer",this.CmpContext,this.IsMasterPage,"sucursal",[5],!1,1,!1,!0,5,!1,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.Gridsucursal_productoContainer;i.addSingleLineEdit(5,74,"PRODUCTOID","producto Id","","productoId","int",0,"px",4,4,"right",null,[],5,"productoId",!0,0,!1,!1,"Attribute",0,"");i.addBitmap("prompt_5","PROMPT_5",86,0,"",0,"",null,"","","gx-prompt Image","");i.addSingleLineEdit(25,75,"PRODUCTONAME","producto Name","","productoName","svchar",0,"px",40,40,"left",null,[],25,"productoName",!0,0,!1,!1,"Attribute",0,"");i.addSingleLineEdit(30,76,"PRODUCTOSTOCK","Stock","","productoStock","int",0,"px",10,10,"right",null,[],30,"productoStock",!0,0,!1,!1,"Attribute",0,"");this.Gridsucursal_productoContainer.emptyText="";this.setGrid(i);this.SUCURSALGEOLOCATIONContainer=gx.uc.getNew(this,49,34,"gxMap","SUCURSALGEOLOCATIONContainer","Sucursalgeolocation","SUCURSALGEOLOCATION");t=this.SUCURSALGEOLOCATIONContainer;t.setProp("Class","Class","","char");t.setDynProp("Enabled","Enabled",!0,"boolean");t.addV2CFunction("A17sucursalGeolocation","SUCURSALGEOLOCATION","SetAttribute");t.addC2VFunction(function(n){n.ParentObject.A17sucursalGeolocation=n.GetAttribute();gx.fn.setControlValue("SUCURSALGEOLOCATION",n.ParentObject.A17sucursalGeolocation)});this.SUCURSALGEOLOCATIONContainer.addValidFunction(this.Valid_Sucursalgeolocation,"A17sucursalGeolocation","SUCURSALGEOLOCATION");t.setProp("MapType","Maptype","Standard","str");t.setProp("MapZoom","Mapzoom",5,"num");t.setProp("MaxZoom","Maxzoom",20,"num");t.setProp("MinZoom","Minzoom",1,"num");t.setProp("GoogleApiKey","Googleapikey","","str");t.setProp("SdtItemObject","Prop_sdt_item_object","","char");t.setProp("Dimensions","Attnumdim","","char");t.setProp("BaseAttType","Baseatttype","","int");t.setProp("PROP_EXT_BASE_ATT_COLLECTION","Prop_ext_base_att_collection",!1,"boolean");t.setProp("FieldSpecifier","Fieldspecifier","","char");t.setProp("CaptionValue","Captionvalue","Geolocation","str");t.setProp("CaptionClass","Captionclass","col-sm-3 AttributeLabel","str");t.setProp("CaptionStyle","Captionstyle","","str");t.setProp("CaptionPosition","Captionposition","Left","str");t.setProp("IsAbstractLayoutControl","Isabstractlayoutcontrol",!1,"bool");t.setProp("InternalTitle","Coltitle","","char");t.setProp("TitleFont","Coltitlefont","","char");t.setProp("TitleForeColor","Coltitlecolor","","int");t.setProp("UserControlIsColumn","Usercontroliscolumn",!1,"boolean");t.setProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e15022_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e16022_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e17022_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e18022_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e19022_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Sucursalid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Gridsucursal_productoContainer],fld:"SUCURSALID",fmt:0,gxz:"Z2sucursalId",gxold:"O2sucursalId",gxvar:"A2sucursalId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2sucursalId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z2sucursalId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("SUCURSALID",gx.O.A2sucursalId,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2sucursalId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("SUCURSALID",".")},nac:gx.falseFn};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Sucursalname,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUCURSALNAME",fmt:0,gxz:"Z13sucursalName",gxold:"O13sucursalName",gxvar:"A13sucursalName",ucs:[],op:[39],ip:[39],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A13sucursalName=n)},v2z:function(n){n!==undefined&&(gx.O.Z13sucursalName=n)},v2c:function(){gx.fn.setControlValue("SUCURSALNAME",gx.O.A13sucursalName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A13sucursalName=this.val())},val:function(){return gx.fn.getControlValue("SUCURSALNAME")},nac:gx.falseFn};this.declareDomainHdlr(39,function(){});n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"svchar",len:1024,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:this.Valid_Sucursaladdress,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUCURSALADDRESS",fmt:0,gxz:"Z14sucursalAddress",gxold:"O14sucursalAddress",gxvar:"A14sucursalAddress",ucs:[],op:[44],ip:[44],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A14sucursalAddress=n)},v2z:function(n){n!==undefined&&(gx.O.Z14sucursalAddress=n)},v2c:function(){gx.fn.setControlValue("SUCURSALADDRESS",gx.O.A14sucursalAddress,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A14sucursalAddress=this.val())},val:function(){return gx.fn.getControlValue("SUCURSALADDRESS")},nac:gx.falseFn};this.declareDomainHdlr(44,function(){gx.fn.setCtrlProperty("SUCURSALADDRESS","Link",gx.fn.getCtrlProperty("SUCURSALADDRESS","Enabled")?"":"http://maps.google.com/maps?q="+encodeURIComponent(this.A14sucursalAddress))});n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUCURSALADDEDDATE",fmt:0,gxz:"Z18sucursalAddedDate",gxold:"O18sucursalAddedDate",gxvar:"A18sucursalAddedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A18sucursalAddedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z18sucursalAddedDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("SUCURSALADDEDDATE",gx.O.A18sucursalAddedDate,0)},c2v:function(){this.val()!==undefined&&(gx.O.A18sucursalAddedDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("SUCURSALADDEDDATE")},nac:gx.falseFn};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Sucursalempleadoheadlineid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUCURSALEMPLEADOHEADLINEID",fmt:0,gxz:"Z3sucursalEmpleadoHeadlineId",gxold:"O3sucursalEmpleadoHeadlineId",gxvar:"A3sucursalEmpleadoHeadlineId",ucs:[],op:[],ip:[59],nacdep:[],ctrltype:"dyncombo",v2v:function(n){n!==undefined&&(gx.O.A3sucursalEmpleadoHeadlineId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z3sucursalEmpleadoHeadlineId=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("SUCURSALEMPLEADOHEADLINEID",gx.O.A3sucursalEmpleadoHeadlineId)},c2v:function(){this.val()!==undefined&&(gx.O.A3sucursalEmpleadoHeadlineId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("SUCURSALEMPLEADOHEADLINEID",".")},nac:function(){return gx.text.compare(this.Gx_mode,"INS")==0&&!(0==this.AV11Insert_sucursalEmpleadoHeadlineId)}};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Sucursalempleadoalternateid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUCURSALEMPLEADOALTERNATEID",fmt:0,gxz:"Z4sucursalEmpleadoAlternateId",gxold:"O4sucursalEmpleadoAlternateId",gxvar:"A4sucursalEmpleadoAlternateId",ucs:[],op:[64,59],ip:[59,64],nacdep:[],ctrltype:"dyncombo",v2v:function(n){n!==undefined&&(gx.O.A4sucursalEmpleadoAlternateId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z4sucursalEmpleadoAlternateId=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("SUCURSALEMPLEADOALTERNATEID",gx.O.A4sucursalEmpleadoAlternateId)},c2v:function(){this.val()!==undefined&&(gx.O.A4sucursalEmpleadoAlternateId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("SUCURSALEMPLEADOALTERNATEID",".")},nac:function(){return gx.text.compare(this.Gx_mode,"INS")==0&&!(0==this.AV12Insert_sucursalEmpleadoAlternateId)}};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"PRODUCTOTABLE",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"TITLEPRODUCTO",format:0,grid:0,ctrltype:"textblock"};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[74]={id:74,lvl:3,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,isacc:1,grid:73,gxgrid:this.Gridsucursal_productoContainer,fnc:this.Valid_Productoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTOID",fmt:0,gxz:"Z5productoId",gxold:"O5productoId",gxvar:"A5productoId",ucs:[],op:[75],ip:[75,74],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A5productoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z5productoId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTOID",n||gx.fn.currentGridRowImpl(73),gx.O.A5productoId,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A5productoId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTOID",n||gx.fn.currentGridRowImpl(73),".")},nac:gx.falseFn};n[75]={id:75,lvl:3,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:1,grid:73,gxgrid:this.Gridsucursal_productoContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTONAME",fmt:0,gxz:"Z25productoName",gxold:"O25productoName",gxvar:"A25productoName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A25productoName=n)},v2z:function(n){n!==undefined&&(gx.O.Z25productoName=n)},v2c:function(n){gx.fn.setGridControlValue("PRODUCTONAME",n||gx.fn.currentGridRowImpl(73),gx.O.A25productoName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A25productoName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTONAME",n||gx.fn.currentGridRowImpl(73))},nac:gx.falseFn};n[76]={id:76,lvl:3,type:"int",len:10,dec:0,sign:!1,pic:"ZZZZZZZZZ9",ro:0,isacc:1,grid:73,gxgrid:this.Gridsucursal_productoContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTOSTOCK",fmt:0,gxz:"Z30productoStock",gxold:"O30productoStock",gxvar:"A30productoStock",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A30productoStock=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z30productoStock=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTOSTOCK",n||gx.fn.currentGridRowImpl(73),gx.O.A30productoStock,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A30productoStock=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTOSTOCK",n||gx.fn.currentGridRowImpl(73),".")},nac:gx.falseFn};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"",grid:0};n[79]={id:79,fld:"",grid:0};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"BTN_ENTER",grid:0,evt:"e13022_client",std:"ENTER"};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"BTN_CANCEL",grid:0,evt:"e14022_client"};n[84]={id:84,fld:"",grid:0};n[85]={id:85,fld:"BTN_DELETE",grid:0,evt:"e20022_client",std:"DELETE"};n[86]={id:86,fld:"PROMPT_5",grid:3};this.A2sucursalId=0;this.Z2sucursalId=0;this.O2sucursalId=0;this.A13sucursalName="";this.Z13sucursalName="";this.O13sucursalName="";this.A14sucursalAddress="";this.Z14sucursalAddress="";this.O14sucursalAddress="";this.A18sucursalAddedDate=gx.date.nullDate();this.Z18sucursalAddedDate=gx.date.nullDate();this.O18sucursalAddedDate=gx.date.nullDate();this.A3sucursalEmpleadoHeadlineId=0;this.Z3sucursalEmpleadoHeadlineId=0;this.O3sucursalEmpleadoHeadlineId=0;this.A4sucursalEmpleadoAlternateId=0;this.Z4sucursalEmpleadoAlternateId=0;this.O4sucursalEmpleadoAlternateId=0;this.Z5productoId=0;this.O5productoId=0;this.Z25productoName="";this.O25productoName="";this.Z30productoStock=0;this.O30productoStock=0;this.A5productoId=0;this.A25productoName="";this.A30productoStock=0;this.AV15Pgmname="";this.AV9TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV11Insert_sucursalEmpleadoHeadlineId=0;this.AV12Insert_sucursalEmpleadoAlternateId=0;this.AV16GXV1=0;this.AV13TrnContextAtt={AttributeName:"",AttributeValue:""};this.AV7sucursalId=0;this.AV10WebSession={};this.A2sucursalId=0;this.A3sucursalEmpleadoHeadlineId=0;this.A4sucursalEmpleadoAlternateId=0;this.Gx_date=gx.date.nullDate();this.A13sucursalName="";this.A14sucursalAddress="";this.A18sucursalAddedDate=gx.date.nullDate();this.A19sucursalEmpleadoHeadlineName="";this.A20sucursalEmpleadoAlternateName="";this.A17sucursalGeolocation="";this.Gx_mode="";this.Events={e12022_client:["AFTER TRN",!0],e13022_client:["ENTER",!0],e14022_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7sucursalId",fld:"vSUCURSALID",pic:"ZZZ9",hsh:!0},{ctrl:"SUCURSALEMPLEADOHEADLINEID"},{av:"A3sucursalEmpleadoHeadlineId",fld:"SUCURSALEMPLEADOHEADLINEID",pic:"ZZZ9"},{ctrl:"SUCURSALEMPLEADOALTERNATEID"},{av:"A4sucursalEmpleadoAlternateId",fld:"SUCURSALEMPLEADOALTERNATEID",pic:"ZZZ9"}],[{ctrl:"SUCURSALEMPLEADOHEADLINEID"},{av:"A3sucursalEmpleadoHeadlineId",fld:"SUCURSALEMPLEADOHEADLINEID",pic:"ZZZ9"},{ctrl:"SUCURSALEMPLEADOALTERNATEID"},{av:"A4sucursalEmpleadoAlternateId",fld:"SUCURSALEMPLEADOALTERNATEID",pic:"ZZZ9"}]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV7sucursalId",fld:"vSUCURSALID",pic:"ZZZ9",hsh:!0},{av:"A2sucursalId",fld:"SUCURSALID",pic:"ZZZ9"},{av:"A18sucursalAddedDate",fld:"SUCURSALADDEDDATE",pic:""},{ctrl:"SUCURSALEMPLEADOHEADLINEID"},{av:"A3sucursalEmpleadoHeadlineId",fld:"SUCURSALEMPLEADOHEADLINEID",pic:"ZZZ9"},{ctrl:"SUCURSALEMPLEADOALTERNATEID"},{av:"A4sucursalEmpleadoAlternateId",fld:"SUCURSALEMPLEADOALTERNATEID",pic:"ZZZ9"}],[{ctrl:"SUCURSALEMPLEADOHEADLINEID"},{av:"A3sucursalEmpleadoHeadlineId",fld:"SUCURSALEMPLEADOHEADLINEID",pic:"ZZZ9"},{ctrl:"SUCURSALEMPLEADOALTERNATEID"},{av:"A4sucursalEmpleadoAlternateId",fld:"SUCURSALEMPLEADOALTERNATEID",pic:"ZZZ9"}]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{ctrl:"SUCURSALEMPLEADOHEADLINEID"},{av:"A3sucursalEmpleadoHeadlineId",fld:"SUCURSALEMPLEADOHEADLINEID",pic:"ZZZ9"},{ctrl:"SUCURSALEMPLEADOALTERNATEID"},{av:"A4sucursalEmpleadoAlternateId",fld:"SUCURSALEMPLEADOALTERNATEID",pic:"ZZZ9"}],[{ctrl:"SUCURSALEMPLEADOHEADLINEID"},{av:"A3sucursalEmpleadoHeadlineId",fld:"SUCURSALEMPLEADOHEADLINEID",pic:"ZZZ9"},{ctrl:"SUCURSALEMPLEADOALTERNATEID"},{av:"A4sucursalEmpleadoAlternateId",fld:"SUCURSALEMPLEADOALTERNATEID",pic:"ZZZ9"}]];this.EvtParms.VALID_SUCURSALID=[[{ctrl:"SUCURSALEMPLEADOHEADLINEID"},{av:"A3sucursalEmpleadoHeadlineId",fld:"SUCURSALEMPLEADOHEADLINEID",pic:"ZZZ9"},{ctrl:"SUCURSALEMPLEADOALTERNATEID"},{av:"A4sucursalEmpleadoAlternateId",fld:"SUCURSALEMPLEADOALTERNATEID",pic:"ZZZ9"}],[{ctrl:"SUCURSALEMPLEADOHEADLINEID"},{av:"A3sucursalEmpleadoHeadlineId",fld:"SUCURSALEMPLEADOHEADLINEID",pic:"ZZZ9"},{ctrl:"SUCURSALEMPLEADOALTERNATEID"},{av:"A4sucursalEmpleadoAlternateId",fld:"SUCURSALEMPLEADOALTERNATEID",pic:"ZZZ9"}]];this.EvtParms.VALID_SUCURSALNAME=[[{av:"A13sucursalName",fld:"SUCURSALNAME",pic:""},{ctrl:"SUCURSALEMPLEADOHEADLINEID"},{av:"A3sucursalEmpleadoHeadlineId",fld:"SUCURSALEMPLEADOHEADLINEID",pic:"ZZZ9"},{ctrl:"SUCURSALEMPLEADOALTERNATEID"},{av:"A4sucursalEmpleadoAlternateId",fld:"SUCURSALEMPLEADOALTERNATEID",pic:"ZZZ9"}],[{av:"A13sucursalName",fld:"SUCURSALNAME",pic:""},{ctrl:"SUCURSALEMPLEADOHEADLINEID"},{av:"A3sucursalEmpleadoHeadlineId",fld:"SUCURSALEMPLEADOHEADLINEID",pic:"ZZZ9"},{ctrl:"SUCURSALEMPLEADOALTERNATEID"},{av:"A4sucursalEmpleadoAlternateId",fld:"SUCURSALEMPLEADOALTERNATEID",pic:"ZZZ9"}]];this.EvtParms.VALID_SUCURSALADDRESS=[[{av:"A14sucursalAddress",fld:"SUCURSALADDRESS",pic:""},{ctrl:"SUCURSALEMPLEADOHEADLINEID"},{av:"A3sucursalEmpleadoHeadlineId",fld:"SUCURSALEMPLEADOHEADLINEID",pic:"ZZZ9"},{ctrl:"SUCURSALEMPLEADOALTERNATEID"},{av:"A4sucursalEmpleadoAlternateId",fld:"SUCURSALEMPLEADOALTERNATEID",pic:"ZZZ9"}],[{av:"A14sucursalAddress",fld:"SUCURSALADDRESS",pic:""},{ctrl:"SUCURSALEMPLEADOHEADLINEID"},{av:"A3sucursalEmpleadoHeadlineId",fld:"SUCURSALEMPLEADOHEADLINEID",pic:"ZZZ9"},{ctrl:"SUCURSALEMPLEADOALTERNATEID"},{av:"A4sucursalEmpleadoAlternateId",fld:"SUCURSALEMPLEADOALTERNATEID",pic:"ZZZ9"}]];this.EvtParms.VALID_SUCURSALEMPLEADOHEADLINEID=[[{av:"A19sucursalEmpleadoHeadlineName",fld:"SUCURSALEMPLEADOHEADLINENAME",pic:""},{ctrl:"SUCURSALEMPLEADOHEADLINEID"},{av:"A3sucursalEmpleadoHeadlineId",fld:"SUCURSALEMPLEADOHEADLINEID",pic:"ZZZ9"},{ctrl:"SUCURSALEMPLEADOALTERNATEID"},{av:"A4sucursalEmpleadoAlternateId",fld:"SUCURSALEMPLEADOALTERNATEID",pic:"ZZZ9"}],[{av:"A19sucursalEmpleadoHeadlineName",fld:"SUCURSALEMPLEADOHEADLINENAME",pic:""},{ctrl:"SUCURSALEMPLEADOHEADLINEID"},{av:"A3sucursalEmpleadoHeadlineId",fld:"SUCURSALEMPLEADOHEADLINEID",pic:"ZZZ9"},{ctrl:"SUCURSALEMPLEADOALTERNATEID"},{av:"A4sucursalEmpleadoAlternateId",fld:"SUCURSALEMPLEADOALTERNATEID",pic:"ZZZ9"}]];this.EvtParms.VALID_SUCURSALEMPLEADOALTERNATEID=[[{av:"A20sucursalEmpleadoAlternateName",fld:"SUCURSALEMPLEADOALTERNATENAME",pic:""},{ctrl:"SUCURSALEMPLEADOHEADLINEID"},{av:"A3sucursalEmpleadoHeadlineId",fld:"SUCURSALEMPLEADOHEADLINEID",pic:"ZZZ9"},{ctrl:"SUCURSALEMPLEADOALTERNATEID"},{av:"A4sucursalEmpleadoAlternateId",fld:"SUCURSALEMPLEADOALTERNATEID",pic:"ZZZ9"}],[{av:"A20sucursalEmpleadoAlternateName",fld:"SUCURSALEMPLEADOALTERNATENAME",pic:""},{ctrl:"SUCURSALEMPLEADOHEADLINEID"},{av:"A3sucursalEmpleadoHeadlineId",fld:"SUCURSALEMPLEADOHEADLINEID",pic:"ZZZ9"},{ctrl:"SUCURSALEMPLEADOALTERNATEID"},{av:"A4sucursalEmpleadoAlternateId",fld:"SUCURSALEMPLEADOALTERNATEID",pic:"ZZZ9"}]];this.EvtParms.VALID_PRODUCTOID=[[{av:"A5productoId",fld:"PRODUCTOID",pic:"ZZZ9"},{av:"A25productoName",fld:"PRODUCTONAME",pic:""},{ctrl:"SUCURSALEMPLEADOHEADLINEID"},{av:"A3sucursalEmpleadoHeadlineId",fld:"SUCURSALEMPLEADOHEADLINEID",pic:"ZZZ9"},{ctrl:"SUCURSALEMPLEADOALTERNATEID"},{av:"A4sucursalEmpleadoAlternateId",fld:"SUCURSALEMPLEADOALTERNATEID",pic:"ZZZ9"}],[{av:"A25productoName",fld:"PRODUCTONAME",pic:""},{ctrl:"SUCURSALEMPLEADOHEADLINEID"},{av:"A3sucursalEmpleadoHeadlineId",fld:"SUCURSALEMPLEADOHEADLINEID",pic:"ZZZ9"},{ctrl:"SUCURSALEMPLEADOALTERNATEID"},{av:"A4sucursalEmpleadoAlternateId",fld:"SUCURSALEMPLEADOALTERNATEID",pic:"ZZZ9"}]];this.setPrompt("PROMPT_5",[74]);this.EnterCtrl=["BTN_ENTER"];this.setVCMap("A17sucursalGeolocation","SUCURSALGEOLOCATION",0,"char",50,0);this.setVCMap("AV7sucursalId","vSUCURSALID",0,"int",4,0);this.setVCMap("AV11Insert_sucursalEmpleadoHeadlineId","vINSERT_SUCURSALEMPLEADOHEADLINEID",0,"int",4,0);this.setVCMap("AV12Insert_sucursalEmpleadoAlternateId","vINSERT_SUCURSALEMPLEADOALTERNATEID",0,"int",4,0);this.setVCMap("Gx_date","vTODAY",0,"date",8,0);this.setVCMap("A19sucursalEmpleadoHeadlineName","SUCURSALEMPLEADOHEADLINENAME",0,"svchar",40,0);this.setVCMap("A20sucursalEmpleadoAlternateName","SUCURSALEMPLEADOALTERNATENAME",0,"svchar",40,0);this.setVCMap("AV15Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV9TrnContext","vTRNCONTEXT",0,"GeneralUITransactionContext",0,0);i.addPostingVar({rfrVar:"Gx_mode"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.sucursal)})