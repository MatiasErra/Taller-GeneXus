gx.evt.autoSkip=!1;gx.define("facturaproductowc",!0,function(n){var t,i;this.ServerClass="facturaproductowc";this.PackageName="GeneXus.Programs";this.ServerFullClass="facturaproductowc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="xd2";this.SetStandaloneVars=function(){this.AV6facturaId=gx.fn.getIntegerValue("vFACTURAID",".");this.AV6facturaId=gx.fn.getIntegerValue("vFACTURAID",".")};this.Valid_Productoid=function(){var n=gx.fn.currentGridRowImpl(15);return this.validCliEvt("Valid_Productoid",15,function(){try{if(gx.fn.currentGridRowImpl(15)===0)return!0;var n=gx.util.balloon.getNew("PRODUCTOID",gx.fn.currentGridRowImpl(15));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Facturaid=function(){return this.validCliEvt("Valid_Facturaid",0,function(){try{var n=gx.util.balloon.getNew("FACTURAID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e130z2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e140z2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,16,17,18,19,20,21,22,23];this.GXLastCtrlId=23;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",15,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"facturaproductowc",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridContainer;i.addSingleLineEdit(5,16,"PRODUCTOID","producto Id","","productoId","int",0,"px",4,4,"right",null,[],5,"productoId",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");i.addSingleLineEdit(25,17,"PRODUCTONAME","producto Name","","productoName","svchar",0,"px",40,40,"left",null,[],25,"productoName",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");i.addSingleLineEdit(34,18,"PRODUCTOCOUNT","Count","","productoCount","int",0,"px",4,4,"right",null,[],34,"productoCount",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");i.addSingleLineEdit(30,19,"PRODUCTOSTOCK","producto Stock","","productoStock","int",0,"px",10,10,"right",null,[],30,"productoStock",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");this.GridContainer.emptyText="";this.setGrid(i);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"GRIDCELL",grid:0};t[6]={id:6,fld:"GRIDTABLE",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"GRIDCONTAINER",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"",grid:0};t[16]={id:16,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:this.Valid_Productoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTOID",fmt:0,gxz:"Z5productoId",gxold:"O5productoId",gxvar:"A5productoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A5productoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z5productoId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTOID",n||gx.fn.currentGridRowImpl(15),gx.O.A5productoId,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A5productoId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTOID",n||gx.fn.currentGridRowImpl(15),".")},nac:gx.falseFn};t[17]={id:17,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTONAME",fmt:0,gxz:"Z25productoName",gxold:"O25productoName",gxvar:"A25productoName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A25productoName=n)},v2z:function(n){n!==undefined&&(gx.O.Z25productoName=n)},v2c:function(n){gx.fn.setGridControlValue("PRODUCTONAME",n||gx.fn.currentGridRowImpl(15),gx.O.A25productoName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A25productoName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTONAME",n||gx.fn.currentGridRowImpl(15))},nac:gx.falseFn};t[18]={id:18,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTOCOUNT",fmt:0,gxz:"Z34productoCount",gxold:"O34productoCount",gxvar:"A34productoCount",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A34productoCount=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z34productoCount=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTOCOUNT",n||gx.fn.currentGridRowImpl(15),gx.O.A34productoCount,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A34productoCount=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTOCOUNT",n||gx.fn.currentGridRowImpl(15),".")},nac:gx.falseFn};t[19]={id:19,lvl:2,type:"int",len:10,dec:0,sign:!1,pic:"ZZZZZZZZZ9",ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTOSTOCK",fmt:0,gxz:"Z30productoStock",gxold:"O30productoStock",gxvar:"A30productoStock",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A30productoStock=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z30productoStock=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTOSTOCK",n||gx.fn.currentGridRowImpl(15),gx.O.A30productoStock,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A30productoStock=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTOSTOCK",n||gx.fn.currentGridRowImpl(15),".")},nac:gx.falseFn};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Facturaid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FACTURAID",fmt:0,gxz:"Z8facturaId",gxold:"O8facturaId",gxvar:"A8facturaId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A8facturaId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z8facturaId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("FACTURAID",gx.O.A8facturaId,0)},c2v:function(){this.val()!==undefined&&(gx.O.A8facturaId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("FACTURAID",".")},nac:gx.falseFn};this.Z5productoId=0;this.O5productoId=0;this.Z25productoName="";this.O25productoName="";this.Z34productoCount=0;this.O34productoCount=0;this.Z30productoStock=0;this.O30productoStock=0;this.A8facturaId=0;this.Z8facturaId=0;this.O8facturaId=0;this.A8facturaId=0;this.AV6facturaId=0;this.A2sucursalId=0;this.A5productoId=0;this.A25productoName="";this.A34productoCount=0;this.A30productoStock=0;this.Events={e130z2_client:["ENTER",!0],e140z2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6facturaId",fld:"vFACTURAID",pic:"ZZZ9"},{av:"sPrefix"}],[]];this.EvtParms["GRID.LOAD"]=[[{av:"A5productoId",fld:"PRODUCTOID",pic:"ZZZ9"}],[{av:'gx.fn.getCtrlProperty("PRODUCTONAME","Link")',ctrl:"PRODUCTONAME",prop:"Link"}]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6facturaId",fld:"vFACTURAID",pic:"ZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6facturaId",fld:"vFACTURAID",pic:"ZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6facturaId",fld:"vFACTURAID",pic:"ZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6facturaId",fld:"vFACTURAID",pic:"ZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.VALID_FACTURAID=[[],[]];this.EvtParms.VALID_PRODUCTOID=[[],[]];this.setVCMap("AV6facturaId","vFACTURAID",0,"int",4,0);this.setVCMap("AV6facturaId","vFACTURAID",0,"int",4,0);this.setVCMap("AV6facturaId","vFACTURAID",0,"int",4,0);i.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});i.addRefreshingVar({rfrVar:"AV6facturaId"});i.addRefreshingParm({rfrVar:"AV6facturaId"});this.Initialize()})