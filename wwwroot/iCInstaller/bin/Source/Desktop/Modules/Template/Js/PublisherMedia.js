function CreateNewSymbol(){
	window.open("PublisherEditSymbol.aspx","Symbol","toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,copyhistory=yes,width=175,height=150")
}

function InsertNewSymbol(v){
	if(IsIE456()){
		var _MarkedRange = getIFrameDocument("ContentView").selection.createRange();
		_MarkedRange.pasteHTML(v);
	}
	else{
		getIFrameDocument("ContentView").body.innerHTML = v + getIFrameDocument("ContentView").body.innerHTML;
	}
	document.getElementById('ContentView').contentWindow.focus();
}
function CreateNewImage(pag,mid){
	var _ImageAltText = null;
	var _ImageSrcData = null;
	var _ImageBorderWidth = null;
	window.open("PublisherEditImage.aspx?PageId="+pag+"&ModId="+mid,"Image","toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,copyhistory=yes,width=530,height=190")
}


