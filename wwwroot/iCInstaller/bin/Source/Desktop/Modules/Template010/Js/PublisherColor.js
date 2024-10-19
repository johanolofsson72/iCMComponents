

function ChangeForeColor(){
    try{
		var obj = window.open("PublisherEditForeColor.htm","Color","Height=277,Width=190");
    }
    catch(e){
        //alert(e)
    }
}
function SetForeColor(v){
    try{
        if (v != null){getIFrameDocument("ContentView").execCommand("ForeColor", false, v);}
	   document.getElementById('ContentView').contentWindow.focus();
    }
    catch(e){
        //alert(e)
    }
}

function ChangeBackColor(){
    try{
		var obj = window.open("PublisherEditBackColor.htm","Color","Height=277,Width=190");
    }
    catch(e){
        //alert(e)
    }
}
function SetBackColor(v){
    try{
        if (v != null){getIFrameDocument("ContentView").execCommand("BackColor", false, v);}
	   document.getElementById('ContentView').contentWindow.focus();
    }
    catch(e){
        //alert(e)
    }
}
