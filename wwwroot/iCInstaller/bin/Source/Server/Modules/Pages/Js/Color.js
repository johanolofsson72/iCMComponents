function ChangeColor(){try{var obj = window.open("EditModulePagesColor.htm","Color","Height=272,Width=188");}catch(e){}}
function SetColor(v){try{document.getElementById("BColor").value=v;}catch(e){}}
function ChangeColor2(){try{var obj = window.open("EditPagesColor.htm","Color","Height=272,Width=188");}catch(e){}}
function SetColor2(v){try{document.getElementById("txtBackColor").value=v;}catch(e){}}

function ShowAttributes(v){
	try{
		var t = "";
		var p = 0;
		for(i in v){
			
			if(p==0){
				t+=i;
				p=1;
			}
			else if(p==1){
				t+=',  '+i;
				p=2;
			}
			else{
				t+=',  '+i+'\n';
				p=0;
			}
		}
		alert(t);
	}
	catch(e){
		alert(e)
	}
}
