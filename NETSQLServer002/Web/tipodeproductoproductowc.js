gx.evt.autoSkip=!1;gx.define("tipodeproductoproductowc",!0,function(n){var t,i;this.ServerClass="tipodeproductoproductowc";this.PackageName="GeneXus.Programs";this.ServerFullClass="tipodeproductoproductowc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="xd2";this.SetStandaloneVars=function(){this.AV6tipoDeProductoId=gx.fn.getIntegerValue("vTIPODEPRODUCTOID",".");this.AV6tipoDeProductoId=gx.fn.getIntegerValue("vTIPODEPRODUCTOID",".")};this.Valid_Proveedorid=function(){var n=gx.fn.currentGridRowImpl(22);return this.validCliEvt("Valid_Proveedorid",22,function(){try{if(gx.fn.currentGridRowImpl(22)===0)return!0;var n=gx.util.balloon.getNew("PROVEEDORID",gx.fn.currentGridRowImpl(22));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e110x2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e140x2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e150x2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,17,18,19,20,21,23,24,25,26,27,28,29,30,31,32,33,34,35];this.GXLastCtrlId=35;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",22,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"tipodeproductoproductowc",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridContainer;i.addSingleLineEdit(5,23,"PRODUCTOID","Id","","productoId","int",0,"px",4,4,"right",null,[],5,"productoId",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");i.addSingleLineEdit(25,24,"PRODUCTONAME","Name","","productoName","svchar",0,"px",40,40,"left",null,[],25,"productoName",!0,0,!1,!1,"attribute-description",0,"column");i.addBitmap(26,"PRODUCTOIMAGE",25,0,"px",17,"px",null,"","Image","ImageAttribute","column WWOptionalColumn");i.addSingleLineEdit(27,26,"PRODUCTOSELLPRICE","Sell Price","","productoSellPrice","decimal",0,"px",10,10,"right",null,[],27,"productoSellPrice",!0,2,!1,!1,"Attribute",0,"column WWOptionalColumn");i.addSingleLineEdit(28,27,"PRODUCTOCOSTPRICE","Cost Price","","productoCostPrice","decimal",0,"px",10,10,"right",null,[],28,"productoCostPrice",!0,2,!1,!1,"Attribute",0,"column WWOptionalColumn");i.addSingleLineEdit(7,28,"PROVEEDORID","proveedor Id","","proveedorId","int",0,"px",4,4,"right",null,[],7,"proveedorId",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");i.addSingleLineEdit(21,29,"PROVEEDORNAME","proveedor Name","","proveedorName","svchar",0,"px",40,40,"left",null,[],21,"proveedorName",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");i.addSingleLineEdit("Update",30,"vUPDATE","","","Update","char",0,"px",20,20,"left",null,[],"Update","Update",!0,0,!1,!1,"TextActionAttribute TextLikeLink",0,"WWTextActionColumn");i.addSingleLineEdit("Delete",31,"vDELETE","","","Delete","char",0,"px",20,20,"left",null,[],"Delete","Delete",!0,0,!1,!1,"TextActionAttribute TextLikeLink",0,"WWTextActionColumn");this.GridContainer.emptyText="";this.setGrid(i);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"GRIDCELL",grid:0};t[6]={id:6,fld:"GRIDTABLE",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TABLETOP",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"BTNINSERT",grid:0,evt:"e110x2_client"};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"GRIDCONTAINER",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[23]={id:23,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTOID",fmt:0,gxz:"Z5productoId",gxold:"O5productoId",gxvar:"A5productoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A5productoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z5productoId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTOID",n||gx.fn.currentGridRowImpl(22),gx.O.A5productoId,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A5productoId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTOID",n||gx.fn.currentGridRowImpl(22),".")},nac:gx.falseFn};t[24]={id:24,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTONAME",fmt:0,gxz:"Z25productoName",gxold:"O25productoName",gxvar:"A25productoName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A25productoName=n)},v2z:function(n){n!==undefined&&(gx.O.Z25productoName=n)},v2c:function(n){gx.fn.setGridControlValue("PRODUCTONAME",n||gx.fn.currentGridRowImpl(22),gx.O.A25productoName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A25productoName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTONAME",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};t[25]={id:25,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTOIMAGE",fmt:0,gxz:"Z26productoImage",gxold:"O26productoImage",gxvar:"A26productoImage",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A26productoImage=n)},v2z:function(n){n!==undefined&&(gx.O.Z26productoImage=n)},v2c:function(n){gx.fn.setGridMultimediaValue("PRODUCTOIMAGE",n||gx.fn.currentGridRowImpl(22),gx.O.A26productoImage,gx.O.A40000productoImage_GXI)},c2v:function(n){gx.O.A40000productoImage_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.A26productoImage=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTOIMAGE",n||gx.fn.currentGridRowImpl(22))},val_GXI:function(n){return gx.fn.getGridControlValue("PRODUCTOIMAGE_GXI",n||gx.fn.currentGridRowImpl(22))},gxvar_GXI:"A40000productoImage_GXI",nac:gx.falseFn};t[26]={id:26,lvl:2,type:"decimal",len:10,dec:2,sign:!1,pic:"ZZZZZZ9.99",ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTOSELLPRICE",fmt:0,gxz:"Z27productoSellPrice",gxold:"O27productoSellPrice",gxvar:"A27productoSellPrice",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A27productoSellPrice=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z27productoSellPrice=gx.fn.toDecimalValue(n,".",","))},v2c:function(n){gx.fn.setGridDecimalValue("PRODUCTOSELLPRICE",n||gx.fn.currentGridRowImpl(22),gx.O.A27productoSellPrice,2,",");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A27productoSellPrice=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("PRODUCTOSELLPRICE",n||gx.fn.currentGridRowImpl(22),".",",")},nac:gx.falseFn};t[27]={id:27,lvl:2,type:"decimal",len:10,dec:2,sign:!1,pic:"ZZZZZZ9.99",ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTOCOSTPRICE",fmt:0,gxz:"Z28productoCostPrice",gxold:"O28productoCostPrice",gxvar:"A28productoCostPrice",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A28productoCostPrice=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z28productoCostPrice=gx.fn.toDecimalValue(n,".",","))},v2c:function(n){gx.fn.setGridDecimalValue("PRODUCTOCOSTPRICE",n||gx.fn.currentGridRowImpl(22),gx.O.A28productoCostPrice,2,",");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A28productoCostPrice=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("PRODUCTOCOSTPRICE",n||gx.fn.currentGridRowImpl(22),".",",")},nac:gx.falseFn};t[28]={id:28,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:this.Valid_Proveedorid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PROVEEDORID",fmt:0,gxz:"Z7proveedorId",gxold:"O7proveedorId",gxvar:"A7proveedorId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A7proveedorId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z7proveedorId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PROVEEDORID",n||gx.fn.currentGridRowImpl(22),gx.O.A7proveedorId,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A7proveedorId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PROVEEDORID",n||gx.fn.currentGridRowImpl(22),".")},nac:gx.falseFn};t[29]={id:29,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PROVEEDORNAME",fmt:0,gxz:"Z21proveedorName",gxold:"O21proveedorName",gxvar:"A21proveedorName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A21proveedorName=n)},v2z:function(n){n!==undefined&&(gx.O.Z21proveedorName=n)},v2c:function(n){gx.fn.setGridControlValue("PROVEEDORNAME",n||gx.fn.currentGridRowImpl(22),gx.O.A21proveedorName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A21proveedorName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PROVEEDORNAME",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};t[30]={id:30,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",fmt:0,gxz:"ZV12Update",gxold:"OV12Update",gxvar:"AV12Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV12Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(22),gx.O.AV12Update,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV12Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};t[31]={id:31,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",fmt:0,gxz:"ZV13Delete",gxold:"OV13Delete",gxvar:"AV13Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV13Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(22),gx.O.AV13Delete,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};t[32]={id:32,fld:"",grid:0};t[33]={id:33,fld:"",grid:0};t[34]={id:34,fld:"",grid:0};t[35]={id:35,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPODEPRODUCTOID",fmt:0,gxz:"Z6tipoDeProductoId",gxold:"O6tipoDeProductoId",gxvar:"A6tipoDeProductoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A6tipoDeProductoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z6tipoDeProductoId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("TIPODEPRODUCTOID",gx.O.A6tipoDeProductoId,0)},c2v:function(){this.val()!==undefined&&(gx.O.A6tipoDeProductoId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("TIPODEPRODUCTOID",".")},nac:gx.falseFn};this.Z5productoId=0;this.O5productoId=0;this.Z25productoName="";this.O25productoName="";this.Z26productoImage="";this.O26productoImage="";this.Z27productoSellPrice=0;this.O27productoSellPrice=0;this.Z28productoCostPrice=0;this.O28productoCostPrice=0;this.Z7proveedorId=0;this.O7proveedorId=0;this.Z21proveedorName="";this.O21proveedorName="";this.ZV12Update="";this.OV12Update="";this.ZV13Delete="";this.OV13Delete="";this.A6tipoDeProductoId=0;this.Z6tipoDeProductoId=0;this.O6tipoDeProductoId=0;this.A6tipoDeProductoId=0;this.A40000productoImage_GXI="";this.AV6tipoDeProductoId=0;this.A5productoId=0;this.A25productoName="";this.A26productoImage="";this.A27productoSellPrice=0;this.A28productoCostPrice=0;this.A7proveedorId=0;this.A21proveedorName="";this.AV12Update="";this.AV13Delete="";this.Events={e110x2_client:["'DOINSERT'",!0],e140x2_client:["ENTER",!0],e150x2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6tipoDeProductoId",fld:"vTIPODEPRODUCTOID",pic:"ZZZ9"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms["GRID.LOAD"]=[[{av:"A5productoId",fld:"PRODUCTOID",pic:"ZZZ9",hsh:!0},{av:"A7proveedorId",fld:"PROVEEDORID",pic:"ZZZ9"}],[{av:'gx.fn.getCtrlProperty("vUPDATE","Link")',ctrl:"vUPDATE",prop:"Link"},{av:'gx.fn.getCtrlProperty("vDELETE","Link")',ctrl:"vDELETE",prop:"Link"},{av:'gx.fn.getCtrlProperty("PRODUCTONAME","Link")',ctrl:"PRODUCTONAME",prop:"Link"},{av:'gx.fn.getCtrlProperty("PROVEEDORNAME","Link")',ctrl:"PROVEEDORNAME",prop:"Link"}]];this.EvtParms["'DOINSERT'"]=[[{av:"A5productoId",fld:"PRODUCTOID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6tipoDeProductoId",fld:"vTIPODEPRODUCTOID",pic:"ZZZ9"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6tipoDeProductoId",fld:"vTIPODEPRODUCTOID",pic:"ZZZ9"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6tipoDeProductoId",fld:"vTIPODEPRODUCTOID",pic:"ZZZ9"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6tipoDeProductoId",fld:"vTIPODEPRODUCTOID",pic:"ZZZ9"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.VALID_PROVEEDORID=[[],[]];this.setVCMap("AV6tipoDeProductoId","vTIPODEPRODUCTOID",0,"int",4,0);this.setVCMap("AV6tipoDeProductoId","vTIPODEPRODUCTOID",0,"int",4,0);this.setVCMap("AV6tipoDeProductoId","vTIPODEPRODUCTOID",0,"int",4,0);i.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});i.addRefreshingVar({rfrVar:"AV6tipoDeProductoId"});i.addRefreshingVar({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});i.addRefreshingVar({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});i.addRefreshingParm({rfrVar:"AV6tipoDeProductoId"});i.addRefreshingParm({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});i.addRefreshingParm({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});this.Initialize()})