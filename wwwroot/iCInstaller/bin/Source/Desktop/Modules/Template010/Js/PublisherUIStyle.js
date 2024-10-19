function MouseOver(obj){
	obj.style.borderColor = 'threeddarkshadow';
	obj.style.backgroundColor = 'threedhighlight';
	obj.style.cursor = 'hand';	
}

function MouseOut(obj){
	obj.style.borderColor = 'threedface';  
	obj.style.backgroundColor = 'threedface';
}

function MouseDown(obj){
	obj.style.borderColor = 'threedface';
	obj.style.backgroundColor = 'threedface';
}

function MouseUp(obj){
	obj.style.borderColor = 'threedshadow';	
	obj.style.backgroundColor = 'threedlightshadow';
}