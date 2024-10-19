function CreateTablePre(){
/*
	var _TableNumberOfRows = null;
	var _TableNumberOfCols = null;
	var _TableAlign = null;
	var _TableWidth = null;
	var _TableSpacing = null;
	var _TablePadding =  null;
	var _TableForeColor = null;
	var _TableBorderWidth = null;
	var _TableBorderColor = null;
	showModalDialog("PublisherEditTable.aspx",window,"status:no; dialogWidth: 315px; dialogHeight: 375px; help: 0");
	*/
	window.open("PublisherEditTable.aspx","Color","Height=365,Width=315");
}

function CreateTableSolution(_TableNumberOfRows,_TableNumberOfCols,_TableBorderColor,_TableBorderWidth,_TableForeColor,_TablePadding,_TableSpacing,_TableAlign,_TableWidth){
	if (_TableNumberOfRows == "" || _TableNumberOfRows == "0"){
		_TableNumberOfRows = "1";
	}
	if (_TableNumberOfCols == "" || _TableNumberOfCols == "0"){
		_TableNumberOfCols = "1";
	}
	var _TRCounter=1
	var _TDCounter=1
	var _TableContent = "<TABLE BORDERCOLOR='"+_TableBorderColor+"' BORDER='"+_TableBorderWidth+"' BGCOLOR='"+_TableForeColor+"' CELLPADDING='"+_TablePadding+"' CELLSPACING='"+_TableSpacing+"' ALIGN='" + _TableAlign + "' WIDTH='" + _TableWidth + "' >"
	while (_TRCounter <= _TableNumberOfRows){
		_TRCounter=_TRCounter+1
		_TableContent = _TableContent + "<TR>"
		while (_TDCounter <= _TableNumberOfCols){
			_TableContent = _TableContent + "<TD>&nbsp;</TD>"
			_TDCounter=_TDCounter+1
		}
		_TDCounter=1
		_TableContent = _TableContent + "</TR>"
	}
	_TableContent = _TableContent + "</TABLE>"
	if(IsIE456()){
		var _MarkedRange = getIFrameDocument("ContentView").selection.createRange();
		_MarkedRange.pasteHTML(_TableContent);
	}
	else{
		getIFrameDocument("ContentView").body.innerHTML = _TableContent + getIFrameDocument("ContentView").body.innerHTML;
	}
	document.getElementById('ContentView').contentWindow.focus();
}