(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-743262b9"],{"0226":function(t,e,a){"use strict";a.r(e);var i,s=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"mytable"},[a("b-container",{attrs:{fluid:""}},[a("b-row",[a("b-col",{staticClass:"my-1",attrs:{lg:"6"}},[a("b-form-group",{staticClass:"mb-0",attrs:{label:"字段搜索",description:"Code/Name/Type/Family/Model/PartNo","label-cols-sm":"3","label-align-sm":"right","label-size":"sm","label-for":"filterInput"}},[a("b-input-group",{attrs:{size:"sm"}},[a("b-form-input",{attrs:{id:"filterInput",type:"search",placeholder:"请输入搜索的字段值"},on:{keyup:function(e){return!e.type.indexOf("key")&&t._k(e.keyCode,"enter",13,e.key,"Enter")?null:t.userSearch()}},model:{value:t.pagination.keyword,callback:function(e){t.$set(t.pagination,"keyword","string"===typeof e?e.trim():e)},expression:"pagination.keyword"}}),t._v(" "),a("b-input-group-append",[t.searchFlag?a("b-button",{on:{click:this.clearKeyWord}},[t._v("\n                   清除\n                 ")]):a("b-button",{on:{click:this.junkedSearch}},[t._v("\n                   搜索\n                 ")])],1)],1)],1)],1),t._v(" "),a("b-col",{staticClass:"my-1",attrs:{sm:"5",md:"6"}},[a("b-form-group",{staticClass:"mb-0",attrs:{label:"每页数量","label-cols-sm":"6","label-cols-md":"4","label-cols-lg":"3","label-align-sm":"right","label-size":"sm","label-for":"perPageSelect"}},[a("b-form-select",{attrs:{size:"sm",options:t.pageOptions},model:{value:t.perPage,callback:function(e){t.perPage=e},expression:"perPage"}})],1)],1),t._v(" "),a("b-col",{staticClass:"my-1",attrs:{sm:"5",md:"6"}},[a("b-form-group",{staticClass:"mb-0",attrs:{label:"点检类型","label-cols-sm":"6","label-cols-md":"4","label-cols-lg":"3","label-align-sm":"right","label-size":"sm","label-for":"perPageSelect"}},[a("b-form-select",{attrs:{size:"sm",options:t.checkOptions},model:{value:t.checkType,callback:function(e){t.checkType=e},expression:"checkType"}})],1)],1),t._v(" "),a("b-col",{staticClass:"my-1",attrs:{sm:"5",md:"6"}},[a("div",{staticClass:"mybutton-user"},[a("b-button",{staticClass:"mybutton-newuser",attrs:{size:"dm",variant:"primary"},on:{click:this.refresh}},[a("i",{staticClass:"el-icon-refresh"}),t._v("  刷新")])],1)])],1),t._v(" "),a("b-table",{attrs:{busy:t.isBusyJ,striped:t.striped,bordered:t.bordered,"show-empty":"",small:"",stacked:"md",items:t.items,fields:t.fields,"sort-by":t.sortBy,"sort-direction":t.sortDirection,"sort-desc":t.sortDesc},on:{"update:sortBy":function(e){t.sortBy=e},"update:sort-by":function(e){t.sortBy=e},"update:sortDesc":function(e){t.sortDesc=e},"update:sort-desc":function(e){t.sortDesc=e}},scopedSlots:t._u([{key:"table-busy",fn:function(){return[a("div",{staticClass:"text-center text-danger my-2"},[a("b-spinner",{staticClass:"align-middle"}),t._v(" "),a("strong",[t._v("加载中...")])],1)]},proxy:!0},{key:"cell(index)",fn:function(e){return[a("strong",[t._v(t._s(e.index+1))])]}},{key:"cell(actions)",fn:function(e){return[a("b-button",{staticClass:"mr-1",attrs:{size:"sm",name:"row.item.F_Id"},on:{click:function(t){}}},[t._v("\n            编辑\n          ")]),t._v(" "),a("b-button",{staticClass:"mr-1",attrs:{size:"sm",name:"row.item.F_Id"},on:{click:function(a){return t.itemDetail(e.item,a.target)}}},[t._v("\n            详情\n          ")])]}}])}),t._v(" "),a("div",{staticClass:"myPage",attrs:{align:"center"}},[a("b-col",{staticClass:"my-1",attrs:{sm:"7",md:"6"}},[a("b-pagination",{staticClass:"my-0",attrs:{"total-rows":t.totalRows,"per-page":t.perPage,align:"fill",size:"sm"},model:{value:t.currentPage,callback:function(e){t.currentPage=e},expression:"currentPage"}})],1)],1),t._v(" "),a("b-modal",{attrs:{id:t.junkedDetailModal.id,title:"夹具点检详情:",scrollable:"","hide-footer":""}},[a("form",{ref:"form"},[a("b-form-group",{attrs:{description:"",label:"夹具代码:","label-for":"person","label-cols-sm":"3"}},[a("b-form-input",{attrs:{id:"person",trim:""},model:{value:t.checkEntity.T_Code,callback:function(e){t.$set(t.checkEntity,"T_Code",e)},expression:"checkEntity.T_Code"}})],1),t._v(" "),a("b-form-group",{attrs:{description:"",label:"序列号:","label-for":"seqid","label-cols-sm":"3"}},[a("b-form-input",{attrs:{id:"seqid",trim:""},model:{value:t.checkEntity.T_SeqId,callback:function(e){t.$set(t.checkEntity,"T_SeqId",e)},expression:"checkEntity.T_SeqId"}})],1),t._v(" "),a("b-form-group",{attrs:{description:"",label:"夹具名称:","label-for":"name","label-cols-sm":"3"}},[a("b-form-input",{attrs:{id:"name",trim:""},model:{value:t.checkEntity.T_Name,callback:function(e){t.$set(t.checkEntity,"T_Name",e)},expression:"checkEntity.T_Name"}})],1),t._v(" "),a("b-form-group",{attrs:{"label-for":"type3","label-cols-sm":"3",label:"夹具类别:"}},[a("b-form-select",{attrs:{id:"type3",options:t.typeList},model:{value:t.checkEntity.T_ToolType,callback:function(e){t.$set(t.checkEntity,"T_ToolType",e)},expression:"checkEntity.T_ToolType"}})],1),t._v(" "),a("b-form-group",{attrs:{description:"",label:"所属大类:","label-for":"F","label-cols-sm":"3"}},[a("b-form-input",{attrs:{id:"F",trim:""},model:{value:t.checkEntity.T_Family,callback:function(e){t.$set(t.checkEntity,"T_Family",e)},expression:"checkEntity.T_Family"}})],1),t._v(" "),a("b-form-group",{attrs:{description:"",label:"夹具模组:","label-for":"model","label-cols-sm":"3"}},[a("b-form-input",{attrs:{id:"model",trim:""},model:{value:t.checkEntity.T_Model,callback:function(e){t.$set(t.checkEntity,"T_Model",e)},expression:"checkEntity.T_Model"}})],1),t._v(" "),a("b-form-group",{attrs:{description:"",label:"夹具料号:","label-for":"partno","label-cols-sm":"3"}},[a("b-form-input",{attrs:{id:"partno",trim:""},model:{value:t.checkEntity.T_PartNo,callback:function(e){t.$set(t.checkEntity,"T_PartNo",e)},expression:"checkEntity.T_PartNo"}})],1),t._v(" "),a("b-form-group",{attrs:{"label-for":"depart","label-cols-sm":"3",label:"问题描述:"}},[a("b-form-input",{attrs:{id:"depart"},model:{value:t.checkEntity.T_Description,callback:function(e){t.$set(t.checkEntity,"T_Description",e)},expression:"checkEntity.T_Description"}})],1),t._v(" "),a("b-form-group",{attrs:{"label-for":"toolstate","label-cols-sm":"3",label:"部门名称:"}},[a("b-form-select",{attrs:{id:"toolstate",options:t.fnameList},model:{value:t.checkEntity.T_DepartmentId,callback:function(e){t.$set(t.checkEntity,"T_DepartmentId",e)},expression:"checkEntity.T_DepartmentId"}})],1),t._v(" "),a("b-form-group",{attrs:{"label-for":"dperson","label-cols-sm":"3",label:"处理人:"}},[a("b-form-input",{attrs:{id:"dperson"},model:{value:t.checkEntity.T_Hander,callback:function(e){t.$set(t.checkEntity,"T_Hander",e)},expression:"checkEntity.T_Hander"}})],1),t._v(" "),a("b-form-group",{attrs:{"label-for":"adate","label-cols-sm":"3",label:"创建时间:"}},[a("b-form-input",{attrs:{id:"adate"},model:{value:t.checkEntity.T_CreateTime,callback:function(e){t.$set(t.checkEntity,"T_CreateTime",e)},expression:"checkEntity.T_CreateTime"}})],1),t._v(" "),a("b-form-group",{attrs:{"label-for":"aid","label-cols-sm":"3",label:"处理状态:"}},[a("b-form-input",{attrs:{id:"aid"},model:{value:t.checkEntity.T_IsChecked,callback:function(e){t.$set(t.checkEntity,"T_IsChecked",e)},expression:"checkEntity.T_IsChecked"}})],1),t._v(" "),a("b-form-group",{attrs:{"label-for":"textarea-small","label-cols-sm":"3",label:"点检项详情:"}},[a("b-form-textarea",{attrs:{id:"textarea-small",size:"sm"},model:{value:t.checkEntity.T_CheckDetails,callback:function(e){t.$set(t.checkEntity,"T_CheckDetails",e)},expression:"checkEntity.T_CheckDetails"}})],1),t._v(" "),a("b-form-group",{attrs:{description:"",label:"夹具图片:","label-for":"H","label-cols-sm":"3"}},t._l(t.imgSrcList2,(function(e,i){return a("el-image",{staticStyle:{width:"100px",height:"68px","padding-right":"5px"},attrs:{src:t.imgSrcList2[i],"preview-src-list":t.imgSrcList2}})})),1),t._v(" "),a("b-form-group",{attrs:{description:"",label:"点检图片:","label-for":"H","label-cols-sm":"3"}},t._l(t.imgSrcList,(function(e,i){return a("el-image",{staticStyle:{width:"100px",height:"68px","padding-right":"5px"},attrs:{src:t.imgSrcList[i],"preview-src-list":t.imgSrcList}})})),1)],1)])],1),t._v(" "),a("el-backtop",{attrs:{target:""}})],1)},n=[],l=a("bd86"),r=(a("ac4d"),a("8a81"),a("ac6a"),a("5df3"),a("f400"),a("28a5"),a("e8cb")),o=a("5c96"),c={props:{componentFlag:{type:String,default:"0"}},data:function(){return{checkType:"定时点检",checkOptions:["定时点检","出库点检","入库点检","预警点检"],dealResultList:[{text:"已通过",value:1},{text:"未通过",value:0},{text:"未处理",value:null}],isPass:null,feedBack:"",isPassList:[{text:"通过",value:1},{text:"不通过",value:0}],eventFlag:null,typeMap:null,mapType:null,rnameMap:null,organizeMap:null,mapOrganize:null,departmentList:[],typeList:[],fnameList:[],imgSrcList:[],imgSrcList2:[],isBusyJ:!0,userMap:null,enabledList:[{text:"是",value:!0},{text:"否",value:!1}],updateJunkedEntity:null,checkEntity:{T_CheckDetails:null,Id:null,T_Id:null,T_DefineId:null,T_Family:null,T_ThisCheckTime:null,T_Model:null,T_ToolType:null,T_PartNo:null,T_Code:null,T_SeqId:null,T_Name:null,T_DepartmentId:"",T_Hander:"",T_IsChecked:"",T_CreateTime:null,T_CheckType:null,T_Img:"",T_Description:null,T_CheckedImg:null},submitFormFlag:null,groupState:null,searchFlag:!1,totalRows:1,currentPage:1,perPage:10,pageOptions:[5,10,15,20,30],sortBy:null,sortDesc:!1,sortDirection:"asc",spinFlag:!0,pagination:{sord:"desc",page:1,rows:10,sidx:"T_Id",keyword:null,checkType:"定时点检"},items:[],itemsBackUp:[],fieldsName:null,fields:[{key:"index",label:"序号"},{key:"T_Code",label:"夹具代码",sortable:!0},{key:"T_SeqId",label:"序列号",sortable:!0},{key:"T_Name",label:"夹具名称",sortable:!1},{key:"T_ToolType",label:"夹具类别",sortable:!1},{key:"T_Description",label:"点检描述"},{key:"T_IsChecked",label:"处理状态",sortable:!0,formatter:function(t,e,a){return t?"已处理":"未处理"}},{key:"T_CreateTime",label:"创建时间",sortable:!0,sortByFormatted:!0,filterByFormatted:!0},{key:"actions",label:"操作"}],striped:!0,bordered:!0,junkedDetailModal:{id:"junked-modalD",title:"报废详情:",type:""},isPassStateFlag:null}},watch:{checkType:function(){this.getList()},perPage:function(){this.pagination.rows=this.perPage,this.getList()},currentPage:function(){this.pagination.page=this.currentPage,this.getList()},sortBy:function(){this.pagination.sidx=this.sortBy,this.getList(),Object(o["Message"])({message:"查询根据"+this.sortBy+"排序！",type:"success",duration:5e3})},sortDesc:function(){0==this.sortDesc?this.pagination.sord="asc":this.pagination.sord="desc",this.getList(),Object(o["Message"])({message:"查询根据"+this.sortBy+"的"+this.pagination.sord+"排序！",type:"success",duration:5e3})}},created:function(){this.fetchUserList()},computed:{roles:function(){return this.$store.getters.roles},sortOptions:function(){return this.fields.filter((function(t){return t.sortable})).map((function(t){return{text:t.label,value:t.key}}))}},mounted:function(){},methods:(i={handleSubmit:function(){return 1==this.isPassStateFlag},modalCancel:function(){this.feedBack="",this.isPass=null,this.$bvModal.hide(this.junkedPassModal.id)},modalOk:function(t){t.preventDefault(),this.handleSubmit()&&this.showMsgBox("请确认是否继续！",null)},showMsgBox:function(t,e){var a=this;this.$bvModal.msgBoxConfirm(t,{title:"提示",size:"sm",buttonSize:"sm",okVariant:"danger",okTitle:"确定",cancelTitle:"取消",footerClass:"p-2",hideHeaderClose:!1,centered:!0}).then((function(t){1==t&&a.submitJunkedUpdate()})).catch((function(t){}))}},Object(l["a"])(i,"modalCancel",(function(){})),Object(l["a"])(i,"clearKeyWord",(function(){this.pagination.keyword=null,this.searchFlag=!1,this.getList()})),Object(l["a"])(i,"refresh",(function(){this.getList()})),Object(l["a"])(i,"junkedSearch",(function(){this.searchFlag=!0,""!=this.pagination.keyword&&null!=this.pagination.keyword?this.getList():(this.searchFlag=!1,Object(o["Message"])({message:"搜索字段不能为空！",type:"warning",duration:5e3}))})),Object(l["a"])(i,"judgeValue",(function(t){return 1==t?(t="是",t):0==t?(t="否",t):null==t||""==t||""==t?(t="无",t):"1"==t?(t="系统角色",t):"2"==t?(t="业务角色",t):t})),Object(l["a"])(i,"itemDetail",(function(t,e){this.checkEntity=JSON.parse(JSON.stringify(t)),this.checkEntity.T_ToolType=this.mapType.get(this.checkEntity.T_ToolType),this.checkEntity.T_IsChecked=this.checkEntity.T_IsChecked?"已处理":"未处理",null!=this.checkEntity.T_CheckedImg&&""!=this.checkEntity.T_CheckedImg?this.imgSrcList=this.checkEntity.T_CheckedImg.split(","):this.imgSrcList=[],null!=this.checkEntity.T_Img&&""!=this.checkEntity.T_Img?this.imgSrcList2=this.checkEntity.T_Img.split(","):this.imgSrcList2=[],this.$root.$emit("bv::show::modal",this.junkedDetailModal.id,e)})),Object(l["a"])(i,"fetchUserList",(function(){var t=this;Object(r["g"])().then((function(e){var a=new Map;t.rnameMap=new Map,t.mapType=new Map;var i=!0,s=!1,n=void 0;try{for(var l,r=e[Symbol.iterator]();!(i=(l=r.next()).done);i=!0){var o=l.value,c={text:null,value:null};c.text=o.F_RealName,c.value=o.F_Id,a.set(o.F_Id,o.F_RealName)}}catch(u){s=!0,n=u}finally{try{i||null==r.return||r.return()}finally{if(s)throw n}}t.rnameMap=a,t.getTypeList()}))})),Object(l["a"])(i,"getTypeList",(function(){var t=this;Object(r["f"])().then((function(e){var a=new Map,i=new Map;t.typeMap=new Map,t.mapType=new Map;var s=!0,n=!1,l=void 0;try{for(var r,o=e[Symbol.iterator]();!(s=(r=o.next()).done);s=!0){var c=r.value,u={text:null,value:null};u.text=c.T_TypeName,u.value=c.T_Id,a.set(c.T_Id,c.T_TypeName),i.set(c.T_TypeName,c.T_Id),t.typeList.push(u)}}catch(p){n=!0,l=p}finally{try{s||null==o.return||o.return()}finally{if(n)throw l}}t.mapType=i,t.typeMap=a,t.getOrganizeList()}))})),Object(l["a"])(i,"getOrganizeList",(function(){var t=this;Object(r["e"])().then((function(e){var a=new Map,i=new Map;t.organizeMap=new Map,t.mapOrganize=new Map;var s=!0,n=!1,l=void 0;try{for(var r,o=e[Symbol.iterator]();!(s=(r=o.next()).done);s=!0){var c=r.value,u={text:null,value:null};u.text=c.F_FullName,u.value=c.F_Id,a.set(c.F_Id,c.F_FullName),i.set(c.F_FullName,c.F_Id),t.fnameList.push(u)}}catch(p){n=!0,l=p}finally{try{s||null==o.return||o.return()}finally{if(n)throw l}}t.mapOrganize=i,t.organizeMap=a,t.getList()}))})),Object(l["a"])(i,"getList",(function(){var t=this;this.isBusyJ=!0;var e=null;"定时点检"==this.checkType?this.pagination.checkType=0:"出库点检"==this.checkType?this.pagination.checkType=1:"预警点检"==this.checkType?this.pagination.checkType=3:this.pagination.checkType=2,Object(r["c"])(this.pagination).then((function(a){e=a.rows,t.itemsBackUp=e;for(var i=0;i<e.length;i++)e[i].T_ToolType=t.typeMap.get(e[i].T_ToolType);t.totalRows=a.records,t.items=a.rows,t.isBusyJ=!1}))})),i)},u=c,p=(a("885e"),a("2877")),d=Object(p["a"])(u,s,n,!1,null,null,null);e["default"]=d.exports},"885e":function(t,e,a){"use strict";var i=a("af41"),s=a.n(i);s.a},af41:function(t,e,a){},e8cb:function(t,e,a){"use strict";a.d(e,"d",(function(){return s})),a.d(e,"a",(function(){return n})),a.d(e,"b",(function(){return l})),a.d(e,"c",(function(){return r})),a.d(e,"f",(function(){return o})),a.d(e,"e",(function(){return c})),a.d(e,"g",(function(){return u}));var i=a("b775");function s(t){return Object(i["a"])({url:"/ToolManage/Check/GetCheckItems",method:"get",params:{typeId:t}})}function n(t){return Object(i["a"])({url:"/ToolManage/Check/Insert",method:"post",data:t})}function l(t){return Object(i["a"])({url:"/ToolManage/Entity/RepairUpdateInsert",method:"post",data:t})}function r(t){return Object(i["a"])({url:"/ToolManage/Check/GetGridJson",method:"get",params:t})}function o(){return Object(i["a"])({url:"/ToolManage/Type/Get",method:"get"})}function c(){return Object(i["a"])({url:"/SystemManage/Organize/GetGridJson",method:"get"})}function u(){return Object(i["a"])({url:"/SystemManage/User/GetAllUser",method:"get"})}},f400:function(t,e,a){"use strict";var i=a("c26b"),s=a("b39a"),n="Map";t.exports=a("e0b8")(n,(function(t){return function(){return t(this,arguments.length>0?arguments[0]:void 0)}}),{get:function(t){var e=i.getEntry(s(this,n),t);return e&&e.v},set:function(t,e){return i.def(s(this,n),0===t?0:t,e)}},i,!0)}}]);