gx.evt.autoSkip=!1;gx.define("wwproducto",!1,function(){var n,t;this.ServerClass="wwproducto";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwproducto.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="xd2";this.SetStandaloneVars=function(){};this.Valid_Proveedorid=function(){var n=gx.fn.currentGridRowImpl(27);return this.validCliEvt("Valid_Proveedorid",27,function(){try{if(gx.fn.currentGridRowImpl(27)===0)return!0;var n=gx.util.balloon.getNew("PROVEEDORID",gx.fn.currentGridRowImpl(27));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Tipodeproductoid=function(){var n=gx.fn.currentGridRowImpl(27);return this.validCliEvt("Valid_Tipodeproductoid",27,function(){try{if(gx.fn.currentGridRowImpl(27)===0)return!0;var n=gx.util.balloon.getNew("TIPODEPRODUCTOID",gx.fn.currentGridRowImpl(27));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e11082_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e15082_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e16082_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,22,23,24,25,26,28,29,30,31,32,33,34,35,36,37,38];this.GXLastCtrlId=38;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",27,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"wwproducto",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridContainer;t.addSingleLineEdit(5,28,"PRODUCTOID","Id","","productoId","int",0,"px",4,4,"right",null,[],5,"productoId",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");t.addSingleLineEdit(25,29,"PRODUCTONAME","Name","","productoName","svchar",0,"px",40,40,"left",null,[],25,"productoName",!0,0,!1,!1,"attribute-description",0,"column");t.addBitmap(26,"PRODUCTOIMAGE",30,0,"px",17,"px",null,"","Image","ImageAttribute","column WWOptionalColumn");t.addSingleLineEdit(27,31,"PRODUCTOSELLPRICE","Sell Price","","productoSellPrice","decimal",0,"px",10,10,"right",null,[],27,"productoSellPrice",!0,2,!1,!1,"Attribute",0,"column WWOptionalColumn");t.addSingleLineEdit(28,32,"PRODUCTOCOSTPRICE","Cost Price","","productoCostPrice","decimal",0,"px",10,10,"right",null,[],28,"productoCostPrice",!0,2,!1,!1,"Attribute",0,"column WWOptionalColumn");t.addSingleLineEdit(7,33,"PROVEEDORID","proveedor Id","","proveedorId","int",0,"px",4,4,"right",null,[],7,"proveedorId",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");t.addSingleLineEdit(21,34,"PROVEEDORNAME","proveedor Name","","proveedorName","svchar",0,"px",40,40,"left",null,[],21,"proveedorName",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");t.addSingleLineEdit(6,35,"TIPODEPRODUCTOID","tipo De Producto Id","","tipoDeProductoId","int",0,"px",4,4,"right",null,[],6,"tipoDeProductoId",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");t.addSingleLineEdit(29,36,"TIPODEPRODUCTONAME","tipo De Producto Name","","tipoDeProductoName","svchar",0,"px",40,40,"left",null,[],29,"tipoDeProductoName",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");t.addSingleLineEdit("Update",37,"vUPDATE","","","Update","char",0,"px",20,20,"left",null,[],"Update","Update",!0,0,!1,!1,"TextActionAttribute TextLikeLink",0,"WWTextActionColumn");t.addSingleLineEdit("Delete",38,"vDELETE","","","Delete","char",0,"px",20,20,"left",null,[],"Delete","Delete",!0,0,!1,!1,"TextActionAttribute TextLikeLink",0,"WWTextActionColumn");this.GridContainer.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"GRIDCELL",grid:0};n[6]={id:6,fld:"GRIDTABLE",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TABLETOP",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"TITLETEXT",format:0,grid:0,ctrltype:"textblock"};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"BTNINSERT",grid:0,evt:"e11082_client"};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vPRODUCTONAME",fmt:0,gxz:"ZV11productoName",gxold:"OV11productoName",gxvar:"AV11productoName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11productoName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11productoName=n)},v2c:function(){gx.fn.setControlValue("vPRODUCTONAME",gx.O.AV11productoName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11productoName=this.val())},val:function(){return gx.fn.getControlValue("vPRODUCTONAME")},nac:gx.falseFn};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"GRIDCONTAINER",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[28]={id:28,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTOID",fmt:0,gxz:"Z5productoId",gxold:"O5productoId",gxvar:"A5productoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A5productoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z5productoId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTOID",n||gx.fn.currentGridRowImpl(27),gx.O.A5productoId,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A5productoId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTOID",n||gx.fn.currentGridRowImpl(27),".")},nac:gx.falseFn};n[29]={id:29,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTONAME",fmt:0,gxz:"Z25productoName",gxold:"O25productoName",gxvar:"A25productoName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A25productoName=n)},v2z:function(n){n!==undefined&&(gx.O.Z25productoName=n)},v2c:function(n){gx.fn.setGridControlValue("PRODUCTONAME",n||gx.fn.currentGridRowImpl(27),gx.O.A25productoName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A25productoName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTONAME",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[30]={id:30,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTOIMAGE",fmt:0,gxz:"Z26productoImage",gxold:"O26productoImage",gxvar:"A26productoImage",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A26productoImage=n)},v2z:function(n){n!==undefined&&(gx.O.Z26productoImage=n)},v2c:function(n){gx.fn.setGridMultimediaValue("PRODUCTOIMAGE",n||gx.fn.currentGridRowImpl(27),gx.O.A26productoImage,gx.O.A40000productoImage_GXI)},c2v:function(n){gx.O.A40000productoImage_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.A26productoImage=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTOIMAGE",n||gx.fn.currentGridRowImpl(27))},val_GXI:function(n){return gx.fn.getGridControlValue("PRODUCTOIMAGE_GXI",n||gx.fn.currentGridRowImpl(27))},gxvar_GXI:"A40000productoImage_GXI",nac:gx.falseFn};n[31]={id:31,lvl:2,type:"decimal",len:10,dec:2,sign:!1,pic:"ZZZZZZ9.99",ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTOSELLPRICE",fmt:0,gxz:"Z27productoSellPrice",gxold:"O27productoSellPrice",gxvar:"A27productoSellPrice",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A27productoSellPrice=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z27productoSellPrice=gx.fn.toDecimalValue(n,".",","))},v2c:function(n){gx.fn.setGridDecimalValue("PRODUCTOSELLPRICE",n||gx.fn.currentGridRowImpl(27),gx.O.A27productoSellPrice,2,",");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A27productoSellPrice=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("PRODUCTOSELLPRICE",n||gx.fn.currentGridRowImpl(27),".",",")},nac:gx.falseFn};n[32]={id:32,lvl:2,type:"decimal",len:10,dec:2,sign:!1,pic:"ZZZZZZ9.99",ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTOCOSTPRICE",fmt:0,gxz:"Z28productoCostPrice",gxold:"O28productoCostPrice",gxvar:"A28productoCostPrice",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A28productoCostPrice=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z28productoCostPrice=gx.fn.toDecimalValue(n,".",","))},v2c:function(n){gx.fn.setGridDecimalValue("PRODUCTOCOSTPRICE",n||gx.fn.currentGridRowImpl(27),gx.O.A28productoCostPrice,2,",");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A28productoCostPrice=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("PRODUCTOCOSTPRICE",n||gx.fn.currentGridRowImpl(27),".",",")},nac:gx.falseFn};n[33]={id:33,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:this.Valid_Proveedorid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PROVEEDORID",fmt:0,gxz:"Z7proveedorId",gxold:"O7proveedorId",gxvar:"A7proveedorId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A7proveedorId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z7proveedorId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PROVEEDORID",n||gx.fn.currentGridRowImpl(27),gx.O.A7proveedorId,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A7proveedorId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PROVEEDORID",n||gx.fn.currentGridRowImpl(27),".")},nac:gx.falseFn};n[34]={id:34,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PROVEEDORNAME",fmt:0,gxz:"Z21proveedorName",gxold:"O21proveedorName",gxvar:"A21proveedorName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A21proveedorName=n)},v2z:function(n){n!==undefined&&(gx.O.Z21proveedorName=n)},v2c:function(n){gx.fn.setGridControlValue("PROVEEDORNAME",n||gx.fn.currentGridRowImpl(27),gx.O.A21proveedorName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A21proveedorName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PROVEEDORNAME",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[35]={id:35,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:this.Valid_Tipodeproductoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPODEPRODUCTOID",fmt:0,gxz:"Z6tipoDeProductoId",gxold:"O6tipoDeProductoId",gxvar:"A6tipoDeProductoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A6tipoDeProductoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z6tipoDeProductoId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("TIPODEPRODUCTOID",n||gx.fn.currentGridRowImpl(27),gx.O.A6tipoDeProductoId,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A6tipoDeProductoId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("TIPODEPRODUCTOID",n||gx.fn.currentGridRowImpl(27),".")},nac:gx.falseFn};n[36]={id:36,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPODEPRODUCTONAME",fmt:0,gxz:"Z29tipoDeProductoName",gxold:"O29tipoDeProductoName",gxvar:"A29tipoDeProductoName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A29tipoDeProductoName=n)},v2z:function(n){n!==undefined&&(gx.O.Z29tipoDeProductoName=n)},v2c:function(n){gx.fn.setGridControlValue("TIPODEPRODUCTONAME",n||gx.fn.currentGridRowImpl(27),gx.O.A29tipoDeProductoName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A29tipoDeProductoName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("TIPODEPRODUCTONAME",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[37]={id:37,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",fmt:0,gxz:"ZV12Update",gxold:"OV12Update",gxvar:"AV12Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV12Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(27),gx.O.AV12Update,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV12Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[38]={id:38,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",fmt:0,gxz:"ZV13Delete",gxold:"OV13Delete",gxvar:"AV13Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV13Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(27),gx.O.AV13Delete,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};this.AV11productoName="";this.ZV11productoName="";this.OV11productoName="";this.Z5productoId=0;this.O5productoId=0;this.Z25productoName="";this.O25productoName="";this.Z26productoImage="";this.O26productoImage="";this.Z27productoSellPrice=0;this.O27productoSellPrice=0;this.Z28productoCostPrice=0;this.O28productoCostPrice=0;this.Z7proveedorId=0;this.O7proveedorId=0;this.Z21proveedorName="";this.O21proveedorName="";this.Z6tipoDeProductoId=0;this.O6tipoDeProductoId=0;this.Z29tipoDeProductoName="";this.O29tipoDeProductoName="";this.ZV12Update="";this.OV12Update="";this.ZV13Delete="";this.OV13Delete="";this.AV11productoName="";this.A40000productoImage_GXI="";this.A5productoId=0;this.A25productoName="";this.A26productoImage="";this.A27productoSellPrice=0;this.A28productoCostPrice=0;this.A7proveedorId=0;this.A21proveedorName="";this.A6tipoDeProductoId=0;this.A29tipoDeProductoName="";this.AV12Update="";this.AV13Delete="";this.Events={e11082_client:["'DOINSERT'",!0],e15082_client:["ENTER",!0],e16082_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11productoName",fld:"vPRODUCTONAME",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms["GRID.LOAD"]=[[{av:"A5productoId",fld:"PRODUCTOID",pic:"ZZZ9",hsh:!0},{av:"A7proveedorId",fld:"PROVEEDORID",pic:"ZZZ9"},{av:"A6tipoDeProductoId",fld:"TIPODEPRODUCTOID",pic:"ZZZ9"}],[{av:'gx.fn.getCtrlProperty("vUPDATE","Link")',ctrl:"vUPDATE",prop:"Link"},{av:'gx.fn.getCtrlProperty("vDELETE","Link")',ctrl:"vDELETE",prop:"Link"},{av:'gx.fn.getCtrlProperty("PRODUCTONAME","Link")',ctrl:"PRODUCTONAME",prop:"Link"},{av:'gx.fn.getCtrlProperty("PROVEEDORNAME","Link")',ctrl:"PROVEEDORNAME",prop:"Link"},{av:'gx.fn.getCtrlProperty("TIPODEPRODUCTONAME","Link")',ctrl:"TIPODEPRODUCTONAME",prop:"Link"}]];this.EvtParms["'DOINSERT'"]=[[{av:"A5productoId",fld:"PRODUCTOID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11productoName",fld:"vPRODUCTONAME",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11productoName",fld:"vPRODUCTONAME",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11productoName",fld:"vPRODUCTONAME",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11productoName",fld:"vPRODUCTONAME",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.VALID_PROVEEDORID=[[],[]];this.EvtParms.VALID_TIPODEPRODUCTOID=[[],[]];t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});t.addRefreshingVar(this.GXValidFnc[18]);t.addRefreshingVar({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingVar({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});t.addRefreshingParm(this.GXValidFnc[18]);t.addRefreshingParm({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingParm({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.wwproducto)})