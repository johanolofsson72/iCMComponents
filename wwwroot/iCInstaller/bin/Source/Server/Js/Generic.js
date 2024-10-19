function CheckBrowser(){
	if(getBrowser()=="other"){
		alert("You can not use this browser inside this system.");
	}
}

function getBrowser() {
    var vBrowser=navigator.appName;			
    var vVersion=navigator.appVersion;
    var sBrowser;
    try{
		//window.status = vBrowser+" "+vVersion+" "
    }
    catch(e){
		//alert("Do not support window.");
    }
    if (vBrowser.indexOf("Microsoft")>=0 && vVersion.indexOf("6.")>=0)
        {sBrowser="ie6";} 	// Microsoft Internet Explorer 6.x
    else if (vBrowser.indexOf("Microsoft")>=0 && vVersion.indexOf("5.5")>=0)
        {sBrowser="ie5.5";} // Microsoft Internet Explorer 5.5
    else if (vBrowser.indexOf("Microsoft")>=0 && vVersion.indexOf("5.0")>=0)
        {sBrowser="ie5";} 	// Microsoft Internet Explorer 5.x
    else if (vBrowser.indexOf("Microsoft")>=0 && vVersion.indexOf("4")>=0)
        {sBrowser="ie4";}	// Microsoft Internet Explorer 4.x
    else if (vBrowser.indexOf("Microsoft")>=0 && vVersion.indexOf("3")>=0)
        {sBrowser="ie3";}	// Microsoft Internet Explorer 3.x
    else if (vBrowser.indexOf("Netscape")>=0 && vVersion.indexOf("7")>=0)
        {sBrowser="ns7";}	// Netscape Navigator 7.x
    else if (vBrowser.indexOf("Netscape")>=0 && vVersion.indexOf("6")>=0)
        {sBrowser="ns6";}	// Netscape Navigator 6.x
    else if (vBrowser.indexOf("Netscape")>=0 && vVersion.indexOf("5")>=0)
        {sBrowser="ns5";}	// Netscape Navigator 5.x
    else if (vBrowser.indexOf("Netscape")>=0 && vVersion.indexOf("4")>=0)
        {sBrowser="ns4";}	// Netscape Navigator 4.x
    else if (vBrowser.indexOf("Netscape")>=0 && vVersion.indexOf("3")>=0)
        {sBrowser="ns3";}	// Netscape Navigator 3.x
    else
        {sBrowser="other";}	// All Others 
        
    try{
		//window.status += sBrowser
    }
    catch(e){
		//alert("Do not support window.");
    }	
    return(sBrowser);
}