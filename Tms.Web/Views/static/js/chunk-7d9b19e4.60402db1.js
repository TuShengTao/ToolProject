(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-7d9b19e4"],{"1bcc":function(t,e,a){"use strict";a.d(e,"d",(function(){return n})),a.d(e,"e",(function(){return l})),a.d(e,"c",(function(){return i})),a.d(e,"a",(function(){return o})),a.d(e,"b",(function(){return r}));var s=a("b775");function n(t){return Object(s["a"])({url:"/ToolManage/Junked/GetGridJson",method:"get",params:t})}function l(t){return Object(s["a"])({url:"/SystemManage/User/GetAllUser",method:"get",params:t})}function i(t){return Object(s["a"])({url:"/ToolManage/Entity/VerifyIfExist",method:"post",data:t})}function o(t){return Object(s["a"])({url:"/ToolManage/Entity/JunkedUpdateInsert",method:"post",data:t})}function r(t){return Object(s["a"])({url:"/ToolManage/Junked/Update",method:"post",data:t})}},"44db":function(t,e,a){"use strict";a.r(e);var s,n=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"mytable"},[a("b-container",{attrs:{fluid:""}},[a("b-row",[a("b-col",{staticClass:"my-1",attrs:{lg:"6"}},[a("b-form-group",{staticClass:"mb-0",attrs:{label:"字段搜索",description:"Code/Name/Type/Family/Model/PartNo","label-cols-sm":"3","label-align-sm":"right","label-size":"sm","label-for":"filterInput"}},[a("b-input-group",{attrs:{size:"sm"}},[a("b-form-input",{attrs:{id:"filterInput",type:"search",placeholder:"请输入搜索的字段值"},on:{keyup:function(e){return!e.type.indexOf("key")&&t._k(e.keyCode,"enter",13,e.key,"Enter")?null:t.userSearch()}},model:{value:t.pagination.keyword,callback:function(e){t.$set(t.pagination,"keyword","string"===typeof e?e.trim():e)},expression:"pagination.keyword"}}),t._v(" "),a("b-input-group-append",[t.searchFlag?a("b-button",{on:{click:this.clearKeyWord}},[t._v("\n                   清除\n                 ")]):a("b-button",{on:{click:this.junkedSearch}},[t._v("\n                   搜索\n                 ")])],1)],1)],1)],1),t._v(" "),a("b-col",{staticClass:"my-1",attrs:{sm:"5",md:"6"}},[a("b-form-group",{staticClass:"mb-0",attrs:{label:"每页数量","label-cols-sm":"6","label-cols-md":"4","label-cols-lg":"3","label-align-sm":"right","label-size":"sm","label-for":"perPageSelect"}},[a("b-form-select",{attrs:{size:"sm",options:t.pageOptions},model:{value:t.perPage,callback:function(e){t.perPage=e},expression:"perPage"}})],1)],1),t._v(" "),a("b-col",{staticClass:"my-1",attrs:{sm:"5",md:"6"}},["0"==t.componentFlag?a("b-form-group",{staticClass:"mb-0",attrs:{label:"记录筛选","label-cols-sm":"6","label-cols-md":"4","label-cols-lg":"3","label-align-sm":"right","label-size":"sm","label-for":"perPageSelect"}},[a("b-form-select",{attrs:{size:"sm",options:t.searchTypeOptions},model:{value:t.searchType,callback:function(e){t.searchType=e},expression:"searchType"}})],1):t._e()],1),t._v(" "),a("b-col",{staticClass:"my-1",attrs:{sm:"5",md:"6"}},[a("div",{staticClass:"mybutton-user"},[a("b-button",{staticClass:"mybutton-newuser",attrs:{size:"dm",variant:"primary"},on:{click:this.refresh}},[a("i",{staticClass:"el-icon-refresh"}),t._v("  刷新")])],1)])],1),t._v(" "),a("b-table",{attrs:{busy:t.isBusyJ,striped:t.striped,bordered:t.bordered,"show-empty":"",small:"",stacked:"md",items:t.items,fields:t.fields,"sort-by":t.sortBy,"sort-direction":t.sortDirection,"sort-desc":t.sortDesc},on:{"update:sortBy":function(e){t.sortBy=e},"update:sort-by":function(e){t.sortBy=e},"update:sortDesc":function(e){t.sortDesc=e},"update:sort-desc":function(e){t.sortDesc=e}},scopedSlots:t._u([{key:"table-busy",fn:function(){return[a("div",{staticClass:"text-center text-danger my-2"},[a("b-spinner",{staticClass:"align-middle"}),t._v(" "),a("strong",[t._v("加载中...")])],1)]},proxy:!0},{key:"cell(index)",fn:function(e){return[t._v("\n               "+t._s(e.index+1)+"\n        ")]}},{key:"cell(actions)",fn:function(e){return[a("b-button",{staticStyle:{"margin-bottom":"2.5px"},attrs:{size:"sm"},on:{click:function(a){return t.itemDetail(e.item,a.target)}}},[t._v("\n            详情\n          ")]),t._v(" "),a("b-button",{directives:[{name:"show",rawName:"v-show",value:"First"==t.componentFlag,expression:"componentFlag == 'First' "}],staticClass:"mr-1",staticStyle:{"margin-bottom":"2.5px"},attrs:{size:"sm",name:"row.item.T_Id"},on:{click:function(a){return t.passFirstButton(e.item,a.target)}}},[t._v("\n            初审\n          ")]),t._v(" "),a("b-button",{directives:[{name:"show",rawName:"v-show",value:"End"==t.componentFlag,expression:"componentFlag == 'End' "}],staticClass:"mr-1",staticStyle:{"margin-bottom":"2.5px"},attrs:{size:"sm",name:"row.item.T_Id"},on:{click:function(a){return t.passEndButton(e.item,a.target)}}},[t._v("\n            终审\n          ")]),t._v(" "),a("div",{directives:[{name:"show",rawName:"v-show",value:"All"==t.componentFlag,expression:"componentFlag == 'All'"}],attrs:{id:"junkedALL"}},[a("b-button",{directives:[{name:"show",rawName:"v-show",value:null==e.item.T_FirstDealId,expression:"row.item.T_FirstDealId == null"}],staticClass:"mr-1",staticStyle:{"margin-bottom":"2.5px"},attrs:{size:"sm",name:"row.item.T_Id"},on:{click:function(a){return t.passFirstButton(e.item,a.target)}}},[t._v("\n              初审\n            ")]),t._v(" "),a("b-button",{directives:[{name:"show",rawName:"v-show",value:null==e.item.T_LastDealId,expression:"row.item.T_LastDealId == null"}],staticClass:"mr-1",staticStyle:{"margin-bottom":"2.5px"},attrs:{size:"sm",name:"row.item.T_Id"},on:{click:function(a){return t.passEndButton(e.item,a.target)}}},[t._v("\n              终审\n            ")])],1)]}}])}),t._v(" "),a("div",{staticClass:"myPage",attrs:{align:"center"}},[a("b-col",{staticClass:"my-1",attrs:{sm:"7",md:"6"}},[a("b-pagination",{staticClass:"my-0",attrs:{"total-rows":t.totalRows,"per-page":t.perPage,align:"fill",size:"sm"},model:{value:t.currentPage,callback:function(e){t.currentPage=e},expression:"currentPage"}})],1)],1),t._v(" "),a("b-modal",{attrs:{id:t.junkedDetailModal.id,title:"报废详情:",scrollable:"","hide-footer":""}},[a("form",{ref:"form"},[a("b-form-group",{attrs:{description:"",label:"夹具代码:","label-for":"person","label-cols-sm":"3"}},[a("b-form-input",{attrs:{id:"person",trim:""},model:{value:t.junkedEntity.T_Code,callback:function(e){t.$set(t.junkedEntity,"T_Code",e)},expression:"junkedEntity.T_Code"}})],1),t._v(" "),a("b-form-group",{attrs:{description:"",label:"序列号:","label-for":"seqid","label-cols-sm":"3"}},[a("b-form-input",{attrs:{id:"seqid",trim:""},model:{value:t.junkedEntity.T_SeqId,callback:function(e){t.$set(t.junkedEntity,"T_SeqId",e)},expression:"junkedEntity.T_SeqId"}})],1),t._v(" "),a("b-form-group",{attrs:{description:"",label:"夹具名称:","label-for":"name","label-cols-sm":"3"}},[a("b-form-input",{attrs:{id:"name",trim:""},model:{value:t.junkedEntity.T_Name,callback:function(e){t.$set(t.junkedEntity,"T_Name",e)},expression:"junkedEntity.T_Name"}})],1),t._v(" "),a("b-form-group",{attrs:{"label-for":"type3","label-cols-sm":"3",label:"夹具类别:"}},[a("b-form-select",{attrs:{id:"type3",options:t.typeList},model:{value:t.junkedEntity.T_ToolType,callback:function(e){t.$set(t.junkedEntity,"T_ToolType",e)},expression:"junkedEntity.T_ToolType"}})],1),t._v(" "),a("b-form-group",{attrs:{description:"",label:"所属大类:","label-for":"F","label-cols-sm":"3"}},[a("b-form-input",{attrs:{id:"F",trim:""},model:{value:t.junkedEntity.T_Family,callback:function(e){t.$set(t.junkedEntity,"T_Family",e)},expression:"junkedEntity.T_Family"}})],1),t._v(" "),a("b-form-group",{attrs:{description:"",label:"夹具模组:","label-for":"model","label-cols-sm":"3"}},[a("b-form-input",{attrs:{id:"model",trim:""},model:{value:t.junkedEntity.T_Model,callback:function(e){t.$set(t.junkedEntity,"T_Model",e)},expression:"junkedEntity.T_Model"}})],1),t._v(" "),a("b-form-group",{attrs:{description:"",label:"夹具料号:","label-for":"partno","label-cols-sm":"3"}},[a("b-form-input",{attrs:{id:"partno",trim:""},model:{value:t.junkedEntity.T_PartNo,callback:function(e){t.$set(t.junkedEntity,"T_PartNo",e)},expression:"junkedEntity.T_PartNo"}})],1),t._v(" "),a("b-form-group",{attrs:{"label-for":"depart","label-cols-sm":"3",label:"报废原因:"}},[a("b-form-input",{attrs:{id:"depart"},model:{value:t.junkedEntity.T_JunkedReason,callback:function(e){t.$set(t.junkedEntity,"T_JunkedReason",e)},expression:"junkedEntity.T_JunkedReason"}})],1),t._v(" "),a("b-form-group",{attrs:{"label-for":"lifetime","label-cols-sm":"3",label:"夹具寿命:"}},[a("b-form-input",{attrs:{id:"lifetime"},model:{value:t.junkedEntity.T_LifeTime,callback:function(e){t.$set(t.junkedEntity,"T_LifeTime",e)},expression:"junkedEntity.T_LifeTime"}})],1),t._v(" "),a("b-form-group",{attrs:{"label-for":"toolstate","label-cols-sm":"3",label:"初审结果:"}},[a("b-form-select",{attrs:{id:"toolstate",options:t.dealResultList},model:{value:t.junkedEntity.T_FirstDealResult,callback:function(e){t.$set(t.junkedEntity,"T_FirstDealResult",e)},expression:"junkedEntity.T_FirstDealResult"}})],1),t._v(" "),a("b-form-group",{attrs:{"label-for":"toolstate","label-cols-sm":"3",label:"终审结果:"}},[a("b-form-select",{attrs:{id:"toolstate",options:t.dealResultList},model:{value:t.junkedEntity.T_LastDealResult,callback:function(e){t.$set(t.junkedEntity,"T_LastDealResult",e)},expression:"junkedEntity.T_LastDealResult"}})],1),t._v(" "),a("b-form-group",{attrs:{"label-for":"adate","label-cols-sm":"3",label:"申请时间:"}},[a("b-form-input",{attrs:{id:"adate"},model:{value:t.junkedEntity.T_ApplicantDate,callback:function(e){t.$set(t.junkedEntity,"T_ApplicantDate",e)},expression:"junkedEntity.T_ApplicantDate"}})],1),t._v(" "),a("b-form-group",{attrs:{"label-for":"aid","label-cols-sm":"3",label:"申请人:"}},[a("b-form-input",{attrs:{id:"aid"},model:{value:t.junkedEntity.T_ApplicantId,callback:function(e){t.$set(t.junkedEntity,"T_ApplicantId",e)},expression:"junkedEntity.T_ApplicantId"}})],1),t._v(" "),a("b-form-group",{attrs:{description:"",label:"报废图片:","label-for":"H","label-cols-sm":"3"}},t._l(t.imgSrcList,(function(e,s){return a("el-image",{staticStyle:{width:"100px",height:"68px","padding-right":"5px"},attrs:{src:t.imgSrcList[s],"preview-src-list":t.imgSrcList}})})),1)],1)]),t._v(" "),"myRecord"!=t.componentFlag&&"0"!=t.componentFlag?a("b-modal",{attrs:{id:t.junkedDetailModal2.id,title:"报废详情:",scrollable:"","hide-footer":""}},[a("form",{ref:"form"},[a("b-form-group",{attrs:{description:"",label:"夹具代码:","label-for":"person23","label-cols-sm":"3"}},[a("b-form-input",{attrs:{id:"person23",trim:""},model:{value:t.junkedEntity.T_Code,callback:function(e){t.$set(t.junkedEntity,"T_Code",e)},expression:"junkedEntity.T_Code"}})],1),t._v(" "),a("b-form-group",{attrs:{description:"",label:"序列号:","label-for":"seqid23","label-cols-sm":"3"}},[a("b-form-input",{attrs:{id:"seqid23",trim:""},model:{value:t.junkedEntity.T_SeqId,callback:function(e){t.$set(t.junkedEntity,"T_SeqId",e)},expression:"junkedEntity.T_SeqId"}})],1),t._v(" "),a("b-form-group",{attrs:{description:"",label:"夹具名称:","label-for":"name23","label-cols-sm":"3"}},[a("b-form-input",{attrs:{id:"name23",trim:""},model:{value:t.junkedEntity.T_Name,callback:function(e){t.$set(t.junkedEntity,"T_Name",e)},expression:"junkedEntity.T_Name"}})],1),t._v(" "),a("b-form-group",{attrs:{"label-for":"type323","label-cols-sm":"3",label:"夹具类别:"}},[a("b-form-select",{attrs:{id:"type323",options:t.typeList},model:{value:t.junkedEntity.T_ToolType,callback:function(e){t.$set(t.junkedEntity,"T_ToolType",e)},expression:"junkedEntity.T_ToolType"}})],1),t._v(" "),a("b-form-group",{attrs:{description:"",label:"所属大类:","label-for":"F23","label-cols-sm":"3"}},[a("b-form-input",{attrs:{id:"F23",trim:""},model:{value:t.junkedEntity.T_Family,callback:function(e){t.$set(t.junkedEntity,"T_Family",e)},expression:"junkedEntity.T_Family"}})],1),t._v(" "),a("b-form-group",{attrs:{description:"",label:"夹具模组:","label-for":"model23","label-cols-sm":"3"}},[a("b-form-input",{attrs:{id:"model23",trim:""},model:{value:t.junkedEntity.T_Model,callback:function(e){t.$set(t.junkedEntity,"T_Model",e)},expression:"junkedEntity.T_Model"}})],1),t._v(" "),a("b-form-group",{attrs:{description:"",label:"夹具料号:","label-for":"partno23","label-cols-sm":"3"}},[a("b-form-input",{attrs:{id:"partno23",trim:""},model:{value:t.junkedEntity.T_PartNo,callback:function(e){t.$set(t.junkedEntity,"T_PartNo",e)},expression:"junkedEntity.T_PartNo"}})],1),t._v(" "),a("b-form-group",{attrs:{"label-for":"depart23","label-cols-sm":"3",label:"报废原因:"}},[a("b-form-input",{attrs:{id:"depart23"},model:{value:t.junkedEntity.T_JunkedReason,callback:function(e){t.$set(t.junkedEntity,"T_JunkedReason",e)},expression:"junkedEntity.T_JunkedReason"}})],1),t._v(" "),a("b-form-group",{attrs:{"label-for":"lifetime23","label-cols-sm":"3",label:"夹具寿命:"}},[a("b-form-input",{attrs:{id:"lifetime23"},model:{value:t.junkedEntity.T_LifeTime,callback:function(e){t.$set(t.junkedEntity,"T_LifeTime",e)},expression:"junkedEntity.T_LifeTime"}})],1),t._v(" "),a("b-form-group",{attrs:{"label-for":"toolstate23","label-cols-sm":"3",label:"初审结果:"}},[a("b-form-select",{attrs:{id:"toolstate23",options:t.dealResultList},model:{value:t.junkedEntity.T_FirstDealResult,callback:function(e){t.$set(t.junkedEntity,"T_FirstDealResult",e)},expression:"junkedEntity.T_FirstDealResult"}})],1),t._v(" "),a("b-form-group",{attrs:{"label-for":"toolstate23","label-cols-sm":"3",label:"终审结果:"}},[a("b-form-select",{attrs:{id:"toolstate23",options:t.dealResultList},model:{value:t.junkedEntity.T_LastDealResult,callback:function(e){t.$set(t.junkedEntity,"T_LastDealResult",e)},expression:"junkedEntity.T_LastDealResult"}})],1),t._v(" "),a("b-form-group",{attrs:{"label-for":"adate23","label-cols-sm":"3",label:"申请时间:"}},[a("b-form-input",{attrs:{id:"adate23"},model:{value:t.junkedEntity.T_ApplicantDate,callback:function(e){t.$set(t.junkedEntity,"T_ApplicantDate",e)},expression:"junkedEntity.T_ApplicantDate"}})],1),t._v(" "),a("b-form-group",{attrs:{"label-for":"aid23","label-cols-sm":"3",label:"申请人:"}},[a("b-form-input",{attrs:{id:"aid23"},model:{value:t.junkedEntity.T_ApplicantId,callback:function(e){t.$set(t.junkedEntity,"T_ApplicantId",e)},expression:"junkedEntity.T_ApplicantId"}})],1),t._v(" "),a("b-form-group",{attrs:{description:"",label:"报废图片:","label-for":"H23","label-cols-sm":"3"}},t._l(t.imgSrcList,(function(e,s){return a("el-image",{staticStyle:{width:"100px",height:"68px","padding-right":"5px"},attrs:{src:t.imgSrcList[s],"preview-src-list":t.imgSrcList}})})),1)],1)]):t._e(),t._v(" "),"myRecord"!=t.componentFlag&&"0"!=t.componentFlag?a("b-modal",{attrs:{id:t.junkedPassModal.id,title:"报废审核:",scrollable:"",centered:"",okTitle:"确定",cancelTitle:"取消","no-close-on-backdrop":!0,"no-close-on-esc":!0},on:{cancel:t.modalCancel,ok:t.modalOk}},[a("form",{ref:"form",on:{submit:function(e){return e.stopPropagation(),e.preventDefault(),t.handleSubmit(e)}}},[a("b-form-group",{attrs:{"label-for":"type2","label-cols-sm":"2",label:"是否通过:","invalid-feedback":t.invalidIsPass,state:t.IsPassState}},[a("b-form-select",{attrs:{id:"type2",state:t.IsPassState,options:t.isPassList},model:{value:t.isPass,callback:function(e){t.isPass=e},expression:"isPass"}})],1),t._v(" "),a("b-form-group",{attrs:{description:"",label:"审核反馈:","label-for":"feedback","label-cols-sm":"2"}},[a("b-form-input",{attrs:{id:"feedback",trim:""},model:{value:t.feedBack,callback:function(e){t.feedBack=e},expression:"feedBack"}})],1)],1)]):t._e(),t._v(" "),"myRecord"!=t.componentFlag&&"0"!=t.componentFlag?a("b-modal",{attrs:{id:t.junkedPassModal2.id,title:"报废审核:",scrollable:"",centered:"",okTitle:"确定",cancelTitle:"取消","no-close-on-backdrop":!0,"no-close-on-esc":!0},on:{cancel:t.modalCancel,ok:t.modalOk}},[a("form",{ref:"form",on:{submit:function(e){return e.stopPropagation(),e.preventDefault(),t.handleSubmit(e)}}},[a("b-form-group",{attrs:{"label-for":"type2","label-cols-sm":"2",label:"是否通过:","invalid-feedback":t.invalidIsPass,state:t.IsPassState}},[a("b-form-select",{attrs:{id:"type2",state:t.IsPassState,options:t.isPassList},model:{value:t.isPass,callback:function(e){t.isPass=e},expression:"isPass"}})],1),t._v(" "),a("b-form-group",{attrs:{description:"",label:"审核反馈:","label-for":"feedback","label-cols-sm":"2"}},[a("b-form-input",{attrs:{id:"feedback",trim:""},model:{value:t.feedBack,callback:function(e){t.feedBack=e},expression:"feedBack"}})],1)],1)]):t._e()],1),t._v(" "),a("el-backtop",{attrs:{target:""}})],1)},l=[],i=a("bd86"),o=(a("28a5"),a("ac4d"),a("8a81"),a("ac6a"),a("5df3"),a("f400"),a("1bcc")),r=a("7b3c"),u=a("5c96"),d={props:{componentFlag:{type:String,default:"0"}},data:function(){return{searchType:"所有记录",searchTypeOptions:["所有记录","已废弃","未废弃","未初审","未终审","初审未通过","终审未通过"],dealResultList:[{text:"已通过",value:1},{text:"未通过",value:0},{text:"未处理",value:null}],isPass:null,feedBack:"",isPassList:[{text:"通过",value:1},{text:"不通过",value:0}],eventFlag:null,typeMap:null,mapType:null,typeList:[],imgSrcList:[],isBusyJ:!0,userMap:null,enabledList:[{text:"是",value:!0},{text:"否",value:!1}],updateJunkedEntity:null,junkedEntity:{Id:null,T_DefineId:null,T_Family:null,T_Model:null,T_ToolType:null,T_PartNo:null,T_Code:null,T_SeqId:null,T_Name:null,T_DepartmentId:"",T_LifeTime:null,T_JunkedReason:"",T_ApplicantId:"",T_ApplicantDate:null,T_Img:"",T_FirstDealId:"",T_FirstDealDate:null,T_LastDealId:"",T_LastDealDate:null,T_CreatorTime:null,T_Description:"",T_IsJunked:null,T_FirstFeedBack:null,T_LastFeedBack:null,T_LastDealResult:null,T_FirstDealResult:null},submitFormFlag:null,groupState:null,searchFlag:!1,totalRows:1,currentPage:1,perPage:10,pageOptions:[5,10,15,20,30],sortBy:null,sortDesc:!1,sortDirection:"asc",spinFlag:!0,pagination:{sord:"desc",page:1,rows:10,sidx:"T_CreatorTime",keyword:null,searchType:666},items:[],itemsBackUp:[],fieldsName:null,fields:[{key:"index",label:"序号"},{key:"T_Code",label:"夹具代码",sortable:!0},{key:"T_SeqId",label:"序列号",sortable:!0},{key:"T_Name",label:"夹具名称",sortable:!1},{key:"T_ToolType",label:"夹具类别",sortable:!1},{key:"T_JunkedReason",label:"报废原因"},{key:"T_LifeTime",label:"寿命",sortable:!0},{key:"T_ApplicantId",label:"申请人"},{key:"T_ApplicantDate",label:"申请时间",sortable:!0,sortByFormatted:!0,filterByFormatted:!0},{key:"actions",label:"操作"}],striped:!0,bordered:!0,junkedDetailModal:{id:"junked-modalD",title:"报废详情:",type:""},junkedDetailModal2:{id:"junked-modalD2",title:"报废详情:",type:""},junkedPassModal:{id:"junked-modalPass",title:"报废审核:",type:""},junkedPassModal2:{id:"junked-modalPass2",title:"报废审核:",type:""},isPassStateFlag:null}},watch:{searchType:function(){this.getList()},perPage:function(){this.pagination.rows=this.perPage,this.getList()},currentPage:function(){this.pagination.page=this.currentPage,this.getList()},sortBy:function(){this.pagination.sidx=this.sortBy,this.getList(),Object(u["Message"])({message:"查询根据"+this.sortBy+"排序！",type:"success",duration:5e3})},sortDesc:function(){0==this.sortDesc?this.pagination.sord="asc":this.pagination.sord="desc",this.getList(),Object(u["Message"])({message:"查询根据"+this.sortBy+"的"+this.pagination.sord+"排序！",type:"success",duration:5e3})}},created:function(){this.getUserList()},computed:{roles:function(){return this.$store.getters.roles},sortOptions:function(){return this.fields.filter((function(t){return t.sortable})).map((function(t){return{text:t.label,value:t.key}}))},IsPassState:function(){return this.isPassStateFlag=null!=this.isPass,this.isPassStateFlag},invalidIsPass:function(){return this.isPassStateFlag?"":"请选择一个选项"}},mounted:function(){},methods:(s={handleSubmit:function(){return 1==this.isPassStateFlag},modalCancel:function(){this.feedBack="",this.isPass=null,this.$bvModal.hide(this.junkedPassModal.id)},modalOk:function(t){t.preventDefault(),this.handleSubmit()&&this.showMsgBox("请确认是否继续！",null)},passFirstButton:function(t,e){this.updateJunkedEntity=JSON.parse(JSON.stringify(t)),this.eventFlag="First",this.$root.$emit("bv::show::modal",this.junkedPassModal.id,e)},passEndButton:function(t,e){this.updateJunkedEntity=JSON.parse(JSON.stringify(t)),this.eventFlag="End",this.$root.$emit("bv::show::modal",this.junkedPassModal.id,e)},showMsgBox:function(t,e){var a=this;this.$bvModal.msgBoxConfirm(t,{title:"提示",size:"sm",buttonSize:"sm",okVariant:"danger",okTitle:"确定",cancelTitle:"取消",footerClass:"p-2",hideHeaderClose:!1,centered:!0}).then((function(t){1==t&&a.submitJunkedUpdate()})).catch((function(t){}))},submitJunkedUpdate:function(){var t=this;"First"==this.eventFlag?(this.updateJunkedEntity.T_FirstDealResult=this.isPass,this.updateJunkedEntity.T_FirstFeedBack=this.feedBack):(this.updateJunkedEntity.T_LastDealResult=this.isPass,this.updateJunkedEntity.T_LastFeedBack=this.feedBack);var e={junkedViewEntity:null,type:null};e.type=this.eventFlag,e.junkedViewEntity=this.updateJunkedEntity,Object(o["b"])(e).then((function(e){t.$bvModal.hide(t.junkedPassModal.id),t.$bvModal.hide(t.junkedPassModal2.id),t.getList(),0!=e?Object(u["Message"])({message:"提交成功!",type:"success",duration:5e3}):Object(u["Message"])({message:"失败!",type:"error",duration:5e3})}))},getTypeList:function(){var t=this;Object(r["e"])().then((function(e){var a=new Map,s=new Map;t.typeMap=new Map,t.mapType=new Map;var n=!0,l=!1,i=void 0;try{for(var o,r=e[Symbol.iterator]();!(n=(o=r.next()).done);n=!0){var u=o.value,d={text:null,value:null};d.text=u.T_TypeName,d.value=u.T_Id,a.set(u.T_Id,u.T_TypeName),s.set(u.T_TypeName,u.T_Id),t.typeList.push(d)}}catch(c){l=!0,i=c}finally{try{n||null==r.return||r.return()}finally{if(l)throw i}}t.mapType=s,t.typeMap=a,t.getList()}))}},Object(i["a"])(s,"modalCancel",(function(){})),Object(i["a"])(s,"clearKeyWord",(function(){this.pagination.keyword=null,this.searchFlag=!1,this.getList()})),Object(i["a"])(s,"refresh",(function(){this.getList()})),Object(i["a"])(s,"junkedSearch",(function(){this.searchFlag=!0,""!=this.pagination.keyword&&null!=this.pagination.keyword?this.getList():(this.searchFlag=!1,Object(u["Message"])({message:"搜索字段不能为空！",type:"warning",duration:5e3}))})),Object(i["a"])(s,"judgeValue",(function(t){return 1==t?(t="是",t):0==t?(t="否",t):null==t||""==t||""==t?(t="无",t):"1"==t?(t="系统角色",t):"2"==t?(t="业务角色",t):t})),Object(i["a"])(s,"getUserList",(function(){var t=this;Object(o["e"])().then((function(e){var a=new Map,s=!0,n=!1,l=void 0;try{for(var i,o=e[Symbol.iterator]();!(s=(i=o.next()).done);s=!0){var r=i.value;a.set(r.F_Id,r.F_RealName)}}catch(u){n=!0,l=u}finally{try{s||null==o.return||o.return()}finally{if(n)throw l}}t.userMap=a,t.getTypeList()}))})),Object(i["a"])(s,"itemDetail",(function(t,e){this.junkedEntity=JSON.parse(JSON.stringify(t)),this.junkedEntity.T_ToolType=this.mapType.get(this.junkedEntity.T_ToolType),null!=this.junkedEntity.T_Img&&""!=this.junkedEntity.T_Img?this.imgSrcList=this.junkedEntity.T_Img.split(","):this.imgSrcList=[],"myRecord"!=this.componentFlag&&"0"!=this.componentFlag?this.$root.$emit("bv::show::modal",this.junkedDetailModal2.id,e):this.$root.$emit("bv::show::modal",this.junkedDetailModal.id,e)})),Object(i["a"])(s,"getList",(function(){var t=this;"0"==this.componentFlag&&("已废弃"==this.searchType?this.pagination.searchType=6:"未废弃"==this.searchType?this.pagination.searchType=7:"初审未通过"==this.searchType?this.pagination.searchType=8:"终审未通过"==this.searchType?this.pagination.searchType=9:"未初审"==this.searchType?this.pagination.searchType=10:"未终审"==this.searchType?this.pagination.searchType=11:"所有记录"==this.searchType&&(this.pagination.searchType=666)),"First"==this.componentFlag?this.pagination.searchType=1:"End"==this.componentFlag?this.pagination.searchType=2:"All"==this.componentFlag?this.pagination.searchType=3:"myRecord"==this.componentFlag&&(this.pagination.searchType=4),this.isBusyJ=!0,this.items=null;var e=null;Object(o["d"])(this.pagination).then((function(a){e=a.rows,t.itemsBackUp=a.rows;for(var s=0;s<e.length;s++)e[s].T_ApplicantId=t.userMap.get(e[s].T_ApplicantId),e[s].T_ToolType=t.typeMap.get(e[s].T_ToolType);t.totalRows=a.records,t.items=e,t.isBusyJ=!1}))})),s)},c=d,p=(a("eeb4"),a("2877")),m=Object(p["a"])(c,n,l,!1,null,null,null);e["default"]=m.exports},ba97:function(t,e,a){},eeb4:function(t,e,a){"use strict";var s=a("ba97"),n=a.n(s);n.a}}]);