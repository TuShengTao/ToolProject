(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-0a1e2068"],{2017:function(n,t,e){"use strict";var s=e("b12d"),a=e.n(s);a.a},3881:function(n,t,e){"use strict";var s=e("729e"),a=e.n(s);a.a},"729e":function(n,t,e){},9067:function(n,t,e){},"9ed6":function(n,t,e){"use strict";e.r(t);var s=function(){var n=this,t=n.$createElement,e=n._self._c||t;return e("div",{staticClass:"login-container"},[e("el-form",{ref:"loginForm",staticClass:"login-form",attrs:{model:n.loginForm,rules:n.loginRules,"auto-complete":"on","label-position":"left"}},[e("div",{staticClass:"title-container"},[e("h3",{staticClass:"title"},[n._v("工夹具智能管理系统")])]),n._v(" "),e("el-form-item",{attrs:{prop:"username"}},[e("span",{staticClass:"svg-container"},[e("svg-icon",{attrs:{"icon-class":"user"}})],1),n._v(" "),e("el-input",{ref:"username",attrs:{placeholder:"请输入用户名",name:"username",type:"text",tabindex:"1","auto-complete":"on"},model:{value:n.loginForm.username,callback:function(t){n.$set(n.loginForm,"username",t)},expression:"loginForm.username"}})],1),n._v(" "),e("el-tooltip",{attrs:{content:"Caps lock is On",placement:"right",manual:""},model:{value:n.capsTooltip,callback:function(t){n.capsTooltip=t},expression:"capsTooltip"}},[e("el-form-item",{attrs:{prop:"password"}},[e("span",{staticClass:"svg-container"},[e("svg-icon",{attrs:{"icon-class":"password"}})],1),n._v(" "),e("el-input",{key:n.passwordType,ref:"password",attrs:{type:n.passwordType,placeholder:"请输入密码",name:"password",tabindex:"2","auto-complete":"on"},on:{blur:function(t){n.capsTooltip=!1}},nativeOn:{keyup:[function(t){return n.checkCapslock(t)},function(t){return!t.type.indexOf("key")&&n._k(t.keyCode,"enter",13,t.key,"Enter")?null:n.handleLogin(t)}]},model:{value:n.loginForm.password,callback:function(t){n.$set(n.loginForm,"password",t)},expression:"loginForm.password"}}),n._v(" "),e("span",{staticClass:"show-pwd",on:{click:n.showPwd}},[e("svg-icon",{attrs:{"icon-class":"password"===n.passwordType?"eye":"eye-open"}})],1)],1)],1),n._v(" "),e("el-button",{staticStyle:{width:"100%","margin-bottom":"30px"},attrs:{loading:n.loading,type:"primary"},nativeOn:{click:function(t){return t.preventDefault(),n.handleLogin(t)}}},[n._v("登录")]),n._v(" "),e("div",{staticStyle:{position:"relative"}},[e("div",{staticClass:"tips"},[e("span",[n._v("Username : admin")]),n._v(" "),e("span",[n._v("Password : any")])]),n._v(" "),e("div",{staticClass:"tips"},[e("span",{staticStyle:{"margin-right":"18px"}},[n._v("Username : editor")]),n._v(" "),e("span",[n._v("Password : any")])]),n._v(" "),e("el-button",{staticClass:"thirdparty-button",attrs:{type:"primary"},on:{click:function(t){n.showDialog=!0}}},[n._v("\n        Or connect with\n      ")])],1)],1),n._v(" "),e("el-dialog",{attrs:{title:"Or connect with",visible:n.showDialog},on:{"update:visible":function(t){n.showDialog=t}}},[n._v("\n    Can not be simulated on local, so please combine you own business simulation! ! !\n    "),e("br"),n._v(" "),e("br"),n._v(" "),e("br"),n._v(" "),e("social-sign")],1)],1)},a=[],o=(e("ac6a"),e("456d"),e("61f7")),i=function(){var n=this,t=n.$createElement,e=n._self._c||t;return e("div",{staticClass:"social-signup-container"},[e("div",{staticClass:"sign-btn",on:{click:function(t){return n.wechatHandleClick("wechat")}}},[e("span",{staticClass:"wx-svg-container"},[e("svg-icon",{staticClass:"icon",attrs:{"icon-class":"wechat"}})],1),n._v("\n    WeChat\n  ")]),n._v(" "),e("div",{staticClass:"sign-btn",on:{click:function(t){return n.tencentHandleClick("tencent")}}},[e("span",{staticClass:"qq-svg-container"},[e("svg-icon",{staticClass:"icon",attrs:{"icon-class":"qq"}})],1),n._v("\n    QQ\n  ")])])},r=[],l={name:"SocialSignin",methods:{wechatHandleClick:function(n){alert("ok")},tencentHandleClick:function(n){alert("ok")}}},c=l,u=(e("d9fb"),e("2877")),d=Object(u["a"])(c,i,r,!1,null,"7309fbbb",null),p=d.exports,g=function(){var n=this,t=n.$createElement,e=n._self._c||t;return e("el-dropdown",{staticClass:"international",attrs:{trigger:"click"},on:{command:n.handleSetLanguage}},[e("div",[e("svg-icon",{attrs:{"class-name":"international-icon","icon-class":"language"}})],1),n._v(" "),e("el-dropdown-menu",{attrs:{slot:"dropdown"},slot:"dropdown"},[e("el-dropdown-item",{attrs:{disabled:"zh"===n.language,command:"zh"}},[n._v("\n      中文\n    ")]),n._v(" "),e("el-dropdown-item",{attrs:{disabled:"zh"===n.language,command:"en"}},[n._v("\n      English\n    ")]),n._v(" "),e("el-dropdown-item",{attrs:{disabled:"zh"===n.language,command:"es"}},[n._v("\n      Español\n    ")]),n._v(" "),e("el-dropdown-item",{attrs:{disabled:"zh"===n.language,command:"ja"}},[n._v("\n      日本語\n    ")])],1)],1)},m=[],h={computed:{language:function(){return this.$store.getters.language}},methods:{handleSetLanguage:function(n){this.$i18n.locale=n,this.$store.dispatch("app/setLanguage",n),this.$message({message:"Switch Language Success",type:"success"})}}},v=h,f=Object(u["a"])(v,g,m,!1,null,null,null),w=f.exports,b={name:"Login",components:{SocialSign:p,LangSelect:w},data:function(){var n=function(n,t,e){Object(o["d"])(t)?e():e(new Error("请输入正确的用户名！"))},t=function(n,t,e){t.length<4?e(new Error("密码格式不正确！请重新填写！")):e()};return{loginForm:{username:"",password:""},loginFormFinal:{username:"",password:""},loginRules:{username:[{required:!0,trigger:"blur",validator:n}],password:[{required:!0,trigger:"blur",validator:t}]},passwordType:"password",capsTooltip:!1,loading:!1,showDialog:!1,redirect:void 0,otherQuery:{},passwordMd5:""}},watch:{$route:{handler:function(n){var t=n.query;t&&(this.redirect=t.redirect,this.otherQuery=this.getOtherQuery(t))},immediate:!0}},created:function(){},mounted:function(){""===this.loginForm.username?this.$refs.username.focus():""===this.loginForm.password&&this.$refs.password.focus()},destroyed:function(){},methods:{checkCapslock:function(){var n=arguments.length>0&&void 0!==arguments[0]?arguments[0]:{},t=n.shiftKey,e=n.key;e&&1===e.length&&(this.capsTooltip=!!(t&&e>="a"&&e<="z"||!t&&e>="A"&&e<="Z")),"CapsLock"===e&&!0===this.capsTooltip&&(this.capsTooltip=!1)},showPwd:function(){var n=this;"password"===this.passwordType?this.passwordType="":this.passwordType="password",this.$nextTick((function(){n.$refs.password.focus()}))},handleLogin:function(){var n=this;this.$refs.loginForm.validate((function(t){if(n.loginFormFinal.username=n.loginForm.username,n.loginFormFinal.password=n.$md5(n.loginForm.password.trim()),!t)return console.log("error submit!!"),!1;n.loading=!0,n.$store.dispatch("user/login",n.loginFormFinal).then((function(){n.$router.push({path:n.redirect||"/",query:n.otherQuery}),n.loading=!1})).catch((function(){n.loading=!1}))}))},getOtherQuery:function(n){return Object.keys(n).reduce((function(t,e){return"redirect"!==e&&(t[e]=n[e]),t}),{})}}},_=b,y=(e("2017"),e("3881"),Object(u["a"])(_,s,a,!1,null,"42810e8b",null));t["default"]=y.exports},b12d:function(n,t,e){},d9fb:function(n,t,e){"use strict";var s=e("9067"),a=e.n(s);a.a}}]);