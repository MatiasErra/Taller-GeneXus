System.register(["./p-810da28d.system.js"],(function(r){"use strict";var t,n,e;return{setters:[function(r){t=r.r;n=r.h;e=r.H}],execute:function(){var o=null;var f=function(){function r(){}return r}();f.render=function(r,t){o(r,t)};self.QrCreator=f;(function(r){function t(t,n,e,o){var f={},i=r(e,n);i.u(t);i.J();o=o||0;var a=i.h(),u=i.h()+2*o;f.text=t;f.level=n;f.version=e;f.O=u;f.a=function(r,t){r-=o;t-=o;return 0>r||r>=a||0>t||t>=a?!1:i.a(r,t)};return f}function n(r,t,n,e,o,f,i,a,u,l){function c(t,n,e,o,i,a,u){t?(r.lineTo(n+a,e+u),r.arcTo(n,e,o,i,f)):r.lineTo(n,e)}i?r.moveTo(t+f,n):r.moveTo(t,n);c(a,e,n,e,o,-f,0);c(u,e,o,t,o,0,-f);c(l,t,o,t,n,f,0);c(i,t,n,e,n,0,f)}function e(r,t,n,e,o,f,i,a,u,l){function c(t,n,e,o){r.moveTo(t+e,n);r.lineTo(t,n);r.lineTo(t,n+o);r.arcTo(t,n,t+e,n,f)}i&&c(t,n,f,f);a&&c(e,n,-f,f);u&&c(e,o,-f,-f);l&&c(t,o,f,-f)}function f(r,t){var n=t.fill;if("string"===typeof n)r.fillStyle=n;else{var e=n.type,o=n.colorStops;n=n.position.map((function(r){return Math.round(r*t.size)}));if("linear-gradient"===e)var f=r.createLinearGradient.apply(r,n);else if("radial-gradient"===e)f=r.createRadialGradient.apply(r,n);else throw Error("Unsupported fill");o.forEach((function(r){var t=r[0],n=r[1];f.addColorStop(t,n)}));r.fillStyle=f}}function i(r,o){r:{var i=o.text,a=o.v,u=o.N,l=o.K,c=o.P;u=Math.max(1,u||1);for(l=Math.min(40,l||40);u<=l;u+=1)try{var h=t(i,a,u,c);break r}catch(T){}h=void 0}if(!h)return null;i=r.getContext("2d");o.background&&(i.fillStyle=o.background,i.fillRect(o.left,o.top,o.size,o.size));a=h.O;l=o.size/a;i.beginPath();for(c=0;c<a;c+=1)for(u=0;u<a;u+=1){var s=i,v=o.left+u*l,d=o.top+c*l,g=c,p=u,b=h.a,y=v+l,m=d+l,M=g-1,w=g+1,x=p-1,z=p+1,A=Math.floor(Math.min(.5,Math.max(0,o.R))*l),k=b(g,p),C=b(M,x),L=b(M,p);M=b(M,z);var E=b(g,z);z=b(w,z);p=b(w,p);w=b(w,x);g=b(g,x);v=Math.round(v);d=Math.round(d);y=Math.round(y);m=Math.round(m);k?n(s,v,d,y,m,A,!L&&!g,!L&&!E,!p&&!E,!p&&!g):e(s,v,d,y,m,A,L&&g&&C,L&&E&&M,p&&E&&z,p&&g&&w)}f(i,o);i.fill();return r}var a={minVersion:1,maxVersion:40,ecLevel:"L",left:0,top:0,size:200,fill:"#000",background:null,text:"no text",radius:.5,quiet:0};o=function(r,t){var n={};Object.assign(n,a,r);n.N=n.minVersion;n.K=n.maxVersion;n.v=n.ecLevel;n.left=n.left;n.top=n.top;n.size=n.size;n.fill=n.fill;n.background=n.background;n.text=n.text;n.R=n.radius;n.P=n.quiet;if(t instanceof HTMLCanvasElement){if(t.width!==n.size||t.height!==n.size)t.width=n.size,t.height=n.size;t.getContext("2d").clearRect(0,0,t.width,t.height);i(t,n)}else r=document.createElement("canvas"),r.width=n.size,r.height=n.size,n=i(r,n),t.appendChild(n)}})(function(){function r(r){var t=n.s(r);return{S:function(){return 4},b:function(){return t.length},write:function(r){for(var n=0;n<t.length;n+=1)r.put(t[n],8)}}}function t(){var r=[],t=0,n={B:function(){return r},c:function(t){return 1==(r[Math.floor(t/8)]>>>7-t%8&1)},put:function(r,t){for(var e=0;e<t;e+=1)n.m(1==(r>>>t-e-1&1))},f:function(){return t},m:function(n){var e=Math.floor(t/8);r.length<=e&&r.push(0);n&&(r[e]|=128>>>t%8);t+=1}};return n}function n(n,i){function u(r,t){for(var n=-1;7>=n;n+=1)if(!(-1>=r+n||s<=r+n))for(var e=-1;7>=e;e+=1)-1>=t+e||s<=t+e||(h[r+n][t+e]=0<=n&&6>=n&&(0==e||6==e)||0<=e&&6>=e&&(0==n||6==n)||2<=n&&4>=n&&2<=e&&4>=e?!0:!1)}function l(r,o){for(var i=s=4*n+17,l=Array(i),g=0;g<i;g+=1){l[g]=Array(i);for(var p=0;p<i;p+=1)l[g][p]=null}h=l;u(0,0);u(s-7,0);u(0,s-7);i=f.G(n);for(l=0;l<i.length;l+=1)for(g=0;g<i.length;g+=1){p=i[l];var b=i[g];if(null==h[p][b])for(var y=-2;2>=y;y+=1)for(var m=-2;2>=m;m+=1)h[p+y][b+m]=-2==y||2==y||-2==m||2==m||0==y&&0==m}for(i=8;i<s-8;i+=1)null==h[i][6]&&(h[i][6]=0==i%2);for(i=8;i<s-8;i+=1)null==h[6][i]&&(h[6][i]=0==i%2);i=f.w(c<<3|o);for(l=0;15>l;l+=1)g=!r&&1==(i>>l&1),h[6>l?l:8>l?l+1:s-15+l][8]=g,h[8][8>l?s-l-1:9>l?15-l:14-l]=g;h[s-8][8]=!r;if(7<=n){i=f.A(n);for(l=0;18>l;l+=1)g=!r&&1==(i>>l&1),h[Math.floor(l/3)][l%3+s-8-3]=g;for(l=0;18>l;l+=1)g=!r&&1==(i>>l&1),h[l%3+s-8-3][Math.floor(l/3)]=g}if(null==v){r=a.I(n,c);i=t();for(l=0;l<d.length;l+=1)g=d[l],i.put(4,4),i.put(g.b(),f.f(4,n)),g.write(i);for(l=g=0;l<r.length;l+=1)g+=r[l].j;if(i.f()>8*g)throw Error("code length overflow. ("+i.f()+">"+8*g+")");for(i.f()+4<=8*g&&i.put(0,4);0!=i.f()%8;)i.m(!1);for(;!(i.f()>=8*g);){i.put(236,8);if(i.f()>=8*g)break;i.put(17,8)}var M=0;g=l=0;p=Array(r.length);b=Array(r.length);for(y=0;y<r.length;y+=1){var w=r[y].j,x=r[y].o-w;l=Math.max(l,w);g=Math.max(g,x);p[y]=Array(w);for(m=0;m<p[y].length;m+=1)p[y][m]=255&i.B()[m+M];M+=w;m=f.C(x);w=e(p[y],m.b()-1).l(m);b[y]=Array(m.b()-1);for(m=0;m<b[y].length;m+=1)x=m+w.b()-b[y].length,b[y][m]=0<=x?w.c(x):0}for(m=i=0;m<r.length;m+=1)i+=r[m].o;i=Array(i);for(m=M=0;m<l;m+=1)for(y=0;y<r.length;y+=1)m<p[y].length&&(i[M]=p[y][m],M+=1);for(m=0;m<g;m+=1)for(y=0;y<r.length;y+=1)m<b[y].length&&(i[M]=b[y][m],M+=1);v=i}r=v;i=-1;l=s-1;g=7;p=0;o=f.F(o);for(b=s-1;0<b;b-=2)for(6==b&&--b;;){for(y=0;2>y;y+=1)null==h[l][b-y]&&(m=!1,p<r.length&&(m=1==(r[p]>>>g&1)),o(l,b-y)&&(m=!m),h[l][b-y]=m,--g,-1==g&&(p+=1,g=7));l+=i;if(0>l||s<=l){l-=i;i=-i;break}}}var c=o[i],h=null,s=0,v=null,d=[],g={u:function(t){t=r(t);d.push(t);v=null},a:function(r,t){if(0>r||s<=r||0>t||s<=t)throw Error(r+","+t);return h[r][t]},h:function(){return s},J:function(){for(var r=0,t=0,n=0;8>n;n+=1){l(!0,n);var e=f.D(g);if(0==n||r>e)r=e,t=n}l(!1,t)}};return g}function e(r,t){if("undefined"==typeof r.length)throw Error(r.length+"/"+t);var n=function(){for(var n=0;n<r.length&&0==r[n];)n+=1;for(var e=Array(r.length-n+t),o=0;o<r.length-n;o+=1)e[o]=r[o+n];return e}(),o={c:function(r){return n[r]},b:function(){return n.length},multiply:function(r){for(var t=Array(o.b()+r.b()-1),n=0;n<o.b();n+=1)for(var f=0;f<r.b();f+=1)t[n+f]^=i.i(i.g(o.c(n))+i.g(r.c(f)));return e(t,0)},l:function(r){if(0>o.b()-r.b())return o;for(var t=i.g(o.c(0))-i.g(r.c(0)),n=Array(o.b()),f=0;f<o.b();f+=1)n[f]=o.c(f);for(f=0;f<r.b();f+=1)n[f]^=i.i(i.g(r.c(f))+t);return e(n,0).l(r)}};return o}n.s=function(r){for(var t=[],n=0;n<r.length;n++){var e=r.charCodeAt(n);128>e?t.push(e):2048>e?t.push(192|e>>6,128|e&63):55296>e||57344<=e?t.push(224|e>>12,128|e>>6&63,128|e&63):(n++,e=65536+((e&1023)<<10|r.charCodeAt(n)&1023),t.push(240|e>>18,128|e>>12&63,128|e>>6&63,128|e&63))}return t};var o={L:1,M:0,Q:3,H:2},f=function(){function r(r){for(var t=0;0!=r;)t+=1,r>>>=1;return t}var t=[[],[6,18],[6,22],[6,26],[6,30],[6,34],[6,22,38],[6,24,42],[6,26,46],[6,28,50],[6,30,54],[6,32,58],[6,34,62],[6,26,46,66],[6,26,48,70],[6,26,50,74],[6,30,54,78],[6,30,56,82],[6,30,58,86],[6,34,62,90],[6,28,50,72,94],[6,26,50,74,98],[6,30,54,78,102],[6,28,54,80,106],[6,32,58,84,110],[6,30,58,86,114],[6,34,62,90,118],[6,26,50,74,98,122],[6,30,54,78,102,126],[6,26,52,78,104,130],[6,30,56,82,108,134],[6,34,60,86,112,138],[6,30,58,86,114,142],[6,34,62,90,118,146],[6,30,54,78,102,126,150],[6,24,50,76,102,128,154],[6,28,54,80,106,132,158],[6,32,58,84,110,136,162],[6,26,54,82,110,138,166],[6,30,58,86,114,142,170]],n={w:function(t){for(var n=t<<10;0<=r(n)-r(1335);)n^=1335<<r(n)-r(1335);return(t<<10|n)^21522},A:function(t){for(var n=t<<12;0<=r(n)-r(7973);)n^=7973<<r(n)-r(7973);return t<<12|n},G:function(r){return t[r-1]},F:function(r){switch(r){case 0:return function(r,t){return 0==(r+t)%2};case 1:return function(r){return 0==r%2};case 2:return function(r,t){return 0==t%3};case 3:return function(r,t){return 0==(r+t)%3};case 4:return function(r,t){return 0==(Math.floor(r/2)+Math.floor(t/3))%2};case 5:return function(r,t){return 0==r*t%2+r*t%3};case 6:return function(r,t){return 0==(r*t%2+r*t%3)%2};case 7:return function(r,t){return 0==(r*t%3+(r+t)%2)%2};default:throw Error("bad maskPattern:"+r)}},C:function(r){for(var t=e([1],0),n=0;n<r;n+=1)t=t.multiply(e([1,i.i(n)],0));return t},f:function(r,t){if(4!=r||1>t||40<t)throw Error("mode: "+r+"; type: "+t);return 10>t?8:16},D:function(r){for(var t=r.h(),n=0,e=0;e<t;e+=1)for(var o=0;o<t;o+=1){for(var f=0,i=r.a(e,o),a=-1;1>=a;a+=1)if(!(0>e+a||t<=e+a))for(var u=-1;1>=u;u+=1)0>o+u||t<=o+u||(0!=a||0!=u)&&i==r.a(e+a,o+u)&&(f+=1);5<f&&(n+=3+f-5)}for(e=0;e<t-1;e+=1)for(o=0;o<t-1;o+=1)if(f=0,r.a(e,o)&&(f+=1),r.a(e+1,o)&&(f+=1),r.a(e,o+1)&&(f+=1),r.a(e+1,o+1)&&(f+=1),0==f||4==f)n+=3;for(e=0;e<t;e+=1)for(o=0;o<t-6;o+=1)r.a(e,o)&&!r.a(e,o+1)&&r.a(e,o+2)&&r.a(e,o+3)&&r.a(e,o+4)&&!r.a(e,o+5)&&r.a(e,o+6)&&(n+=40);for(o=0;o<t;o+=1)for(e=0;e<t-6;e+=1)r.a(e,o)&&!r.a(e+1,o)&&r.a(e+2,o)&&r.a(e+3,o)&&r.a(e+4,o)&&!r.a(e+5,o)&&r.a(e+6,o)&&(n+=40);for(o=f=0;o<t;o+=1)for(e=0;e<t;e+=1)r.a(e,o)&&(f+=1);return n+=Math.abs(100*f/t/t-50)/5*10}};return n}(),i=function(){for(var r=Array(256),t=Array(256),n=0;8>n;n+=1)r[n]=1<<n;for(n=8;256>n;n+=1)r[n]=r[n-4]^r[n-5]^r[n-6]^r[n-8];for(n=0;255>n;n+=1)t[r[n]]=n;return{g:function(r){if(1>r)throw Error("glog("+r+")");return t[r]},i:function(t){for(;0>t;)t+=255;for(;256<=t;)t-=255;return r[t]}}}(),a=function(){function r(r,n){switch(n){case o.L:return t[4*(r-1)];case o.M:return t[4*(r-1)+1];case o.Q:return t[4*(r-1)+2];case o.H:return t[4*(r-1)+3]}}var t=[[1,26,19],[1,26,16],[1,26,13],[1,26,9],[1,44,34],[1,44,28],[1,44,22],[1,44,16],[1,70,55],[1,70,44],[2,35,17],[2,35,13],[1,100,80],[2,50,32],[2,50,24],[4,25,9],[1,134,108],[2,67,43],[2,33,15,2,34,16],[2,33,11,2,34,12],[2,86,68],[4,43,27],[4,43,19],[4,43,15],[2,98,78],[4,49,31],[2,32,14,4,33,15],[4,39,13,1,40,14],[2,121,97],[2,60,38,2,61,39],[4,40,18,2,41,19],[4,40,14,2,41,15],[2,146,116],[3,58,36,2,59,37],[4,36,16,4,37,17],[4,36,12,4,37,13],[2,86,68,2,87,69],[4,69,43,1,70,44],[6,43,19,2,44,20],[6,43,15,2,44,16],[4,101,81],[1,80,50,4,81,51],[4,50,22,4,51,23],[3,36,12,8,37,13],[2,116,92,2,117,93],[6,58,36,2,59,37],[4,46,20,6,47,21],[7,42,14,4,43,15],[4,133,107],[8,59,37,1,60,38],[8,44,20,4,45,21],[12,33,11,4,34,12],[3,145,115,1,146,116],[4,64,40,5,65,41],[11,36,16,5,37,17],[11,36,12,5,37,13],[5,109,87,1,110,88],[5,65,41,5,66,42],[5,54,24,7,55,25],[11,36,12,7,37,13],[5,122,98,1,123,99],[7,73,45,3,74,46],[15,43,19,2,44,20],[3,45,15,13,46,16],[1,135,107,5,136,108],[10,74,46,1,75,47],[1,50,22,15,51,23],[2,42,14,17,43,15],[5,150,120,1,151,121],[9,69,43,4,70,44],[17,50,22,1,51,23],[2,42,14,19,43,15],[3,141,113,4,142,114],[3,70,44,11,71,45],[17,47,21,4,48,22],[9,39,13,16,40,14],[3,135,107,5,136,108],[3,67,41,13,68,42],[15,54,24,5,55,25],[15,43,15,10,44,16],[4,144,116,4,145,117],[17,68,42],[17,50,22,6,51,23],[19,46,16,6,47,17],[2,139,111,7,140,112],[17,74,46],[7,54,24,16,55,25],[34,37,13],[4,151,121,5,152,122],[4,75,47,14,76,48],[11,54,24,14,55,25],[16,45,15,14,46,16],[6,147,117,4,148,118],[6,73,45,14,74,46],[11,54,24,16,55,25],[30,46,16,2,47,17],[8,132,106,4,133,107],[8,75,47,13,76,48],[7,54,24,22,55,25],[22,45,15,13,46,16],[10,142,114,2,143,115],[19,74,46,4,75,47],[28,50,22,6,51,23],[33,46,16,4,47,17],[8,152,122,4,153,123],[22,73,45,3,74,46],[8,53,23,26,54,24],[12,45,15,28,46,16],[3,147,117,10,148,118],[3,73,45,23,74,46],[4,54,24,31,55,25],[11,45,15,31,46,16],[7,146,116,7,147,117],[21,73,45,7,74,46],[1,53,23,37,54,24],[19,45,15,26,46,16],[5,145,115,10,146,116],[19,75,47,10,76,48],[15,54,24,25,55,25],[23,45,15,25,46,16],[13,145,115,3,146,116],[2,74,46,29,75,47],[42,54,24,1,55,25],[23,45,15,28,46,16],[17,145,115],[10,74,46,23,75,47],[10,54,24,35,55,25],[19,45,15,35,46,16],[17,145,115,1,146,116],[14,74,46,21,75,47],[29,54,24,19,55,25],[11,45,15,46,46,16],[13,145,115,6,146,116],[14,74,46,23,75,47],[44,54,24,7,55,25],[59,46,16,1,47,17],[12,151,121,7,152,122],[12,75,47,26,76,48],[39,54,24,14,55,25],[22,45,15,41,46,16],[6,151,121,14,152,122],[6,75,47,34,76,48],[46,54,24,10,55,25],[2,45,15,64,46,16],[17,152,122,4,153,123],[29,74,46,14,75,47],[49,54,24,10,55,25],[24,45,15,46,46,16],[4,152,122,18,153,123],[13,74,46,32,75,47],[48,54,24,14,55,25],[42,45,15,32,46,16],[20,147,117,4,148,118],[40,75,47,7,76,48],[43,54,24,22,55,25],[10,45,15,67,46,16],[19,148,118,6,149,119],[18,75,47,31,76,48],[34,54,24,34,55,25],[20,45,15,61,46,16]],n={I:function(t,n){var e=r(t,n);if("undefined"==typeof e)throw Error("bad rs block @ typeNumber:"+t+"/errorCorrectLevel:"+n);t=e.length/3;n=[];for(var o=0;o<t;o+=1)for(var f=e[3*o],i=e[3*o+1],a=e[3*o+2],u=0;u<f;u+=1){var l=a,c={};c.o=i;c.j=l;n.push(c)}return n}};return n}();return n}());var i=QrCreator;var a=":host{display:block}";var u=r("ch_qr",function(){function r(r){t(this,r);this.text=undefined;this.radius=0;this.ecLevel="H";this.fill="black";this.background=null;this.size=128}r.prototype.componentDidLoad=function(){if(this.text){i.render({text:this.text,radius:this.radius,ecLevel:this.ecLevel,fill:this.fill,background:this.background,size:this.size},this.qrContainer)}};r.prototype.render=function(){var r=this;return n(e,null,n("div",{class:"qr-container",ref:function(t){return r.qrContainer=t}}))};return r}());u.style=a}}}));