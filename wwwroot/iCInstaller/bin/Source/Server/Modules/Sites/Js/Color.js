function ChangeColor(){var obj = window.open("Color/EditSitesColor.htm","Color","Height=272,Width=188");}
function ChangeColor2(){var obj = window.open("Color/EditSitesColor2.htm","Color","Height=272,Width=188");}
function ChangeColor3(){var obj = window.open("Color/EditSitesColor3.htm","Color","Height=272,Width=188");}
function ChangeColor4(){var obj = window.open("Color/EditSitesColor4.htm","Color","Height=272,Width=188");}
function ChangeColor5(){var obj = window.open("Color/EditSitesColor5.htm","Color","Height=272,Width=188");}
function ChangeColor6(){var obj = window.open("Color/EditSitesColor6.htm","Color","Height=272,Width=188");}
function ChangeColor7(){var obj = window.open("Color/EditSitesColor7.htm","Color","Height=272,Width=188");}
function ChangeColor8(){var obj = window.open("Color/EditSitesColor8.htm","Color","Height=272,Width=188");}
function ChangeColor9(){var obj = window.open("Color/EditSitesColor9.htm","Color","Height=272,Width=188");}
function ChangeColor10(){var obj = window.open("Color/EditSitesColor10.htm","Color","Height=272,Width=188");}
function ChangeColor11(){var obj = window.open("Color/EditSitesColor11.htm","Color","Height=272,Width=188");}
function ChangeColor12(){var obj = window.open("Color/EditSitesColor12.htm","Color","Height=272,Width=188");}
function ChangeColor13(){var obj = window.open("Color/EditSitesColor13.htm","Color","Height=272,Width=188");}
function ChangeColor14(){var obj = window.open("Color/EditSitesColor14.htm","Color","Height=272,Width=188");}
function ChangeColor15(){var obj = window.open("Color/EditSitesColor15.htm","Color","Height=272,Width=188");}
function ChangeColor16(){var obj = window.open("Color/EditSitesColor16.htm","Color","Height=272,Width=188");}
function ChangeColor17(){var obj = window.open("Color/EditSitesColor17.htm","Color","Height=272,Width=188");}
function ChangeColor18(){var obj = window.open("Color/EditSitesColor18.htm","Color","Height=272,Width=188");}
function ChangeColor19(){var obj = window.open("Color/EditSitesColor19.htm","Color","Height=272,Width=188");}
function SetColor(v){document.getElementById("BColor").value=v;document.getElementById("BColor").style.backgroundColor=v;}
function SetColor2(v){document.getElementById("BColor2").value=v;document.getElementById("BColor2").style.backgroundColor=v;}
function SetColor3(v){document.getElementById("BColor3").value=v;document.getElementById("BColor3").style.backgroundColor=v;}
function SetColor4(v){document.getElementById("BColor4").value=v;document.getElementById("BColor4").style.backgroundColor=v;}
function SetColor5(v){document.getElementById("BColor5").value=v;document.getElementById("BColor5").style.backgroundColor=v;}
function SetColor6(v){document.getElementById("BColor6").value=v;document.getElementById("BColor6").style.backgroundColor=v;}
function SetColor7(v){document.getElementById("BColor7").value=v;document.getElementById("BColor7").style.backgroundColor=v;}
function SetColor8(v){document.getElementById("BColor8").value=v;document.getElementById("BColor8").style.backgroundColor=v;}
function SetColor9(v){document.getElementById("BColor9").value=v;document.getElementById("BColor9").style.backgroundColor=v;}
function SetColor10(v){document.getElementById("BColor10").value=v;document.getElementById("BColor10").style.backgroundColor=v;}
function SetColor11(v){document.getElementById("BColor11").value=v;document.getElementById("BColor11").style.backgroundColor=v;}
function SetColor12(v){document.getElementById("BColor12").value=v;document.getElementById("BColor12").style.backgroundColor=v;}
function SetColor13(v){document.getElementById("BColor13").value=v;document.getElementById("BColor13").style.backgroundColor=v;}
function SetColor14(v){document.getElementById("BColor14").value=v;document.getElementById("BColor14").style.backgroundColor=v;}
function SetColor15(v){document.getElementById("BColor15").value=v;document.getElementById("BColor15").style.backgroundColor=v;}
function SetColor16(v){document.getElementById("BColor16").value=v;document.getElementById("BColor16").style.backgroundColor=v;}
function SetColor17(v){document.getElementById("BColor17").value=v;document.getElementById("BColor17").style.backgroundColor=v;}
function SetColor18(v){document.getElementById("BColor18").value=v;document.getElementById("BColor18").style.backgroundColor=v;}
function SetColor19(v){document.getElementById("BColor19").value=v;document.getElementById("BColor19").style.backgroundColor=v;}
/*
function SetColor(v){document.getElementById("BColor").value=v;}
function SetColor2(v){document.getElementById("BColor2").value=v;}
function SetColor3(v){document.getElementById("BColor3").value=v;}
function SetColor4(v){document.getElementById("BColor4").value=v;}
function SetColor5(v){document.getElementById("BColor5").value=v;}
function SetColor6(v){document.getElementById("BColor6").value=v;}
function SetColor7(v){document.getElementById("BColor7").value=v;}
function SetColor8(v){document.getElementById("BColor8").value=v;}
function SetColor9(v){document.getElementById("BColor9").value=v;}
function SetColor10(v){document.getElementById("BColor10").value=v;}
function SetColor11(v){document.getElementById("BColor11").value=v;}
function SetColor12(v){document.getElementById("BColor12").value=v;}
function SetColor13(v){document.getElementById("BColor13").value=v;}
function SetColor14(v){document.getElementById("BColor14").value=v;}
function SetColor15(v){document.getElementById("BColor15").value=v;}
function SetColor16(v){document.getElementById("BColor16").value=v;}
function SetColor17(v){document.getElementById("BColor17").value=v;}
function SetColor18(v){document.getElementById("BColor18").value=v;}
function SetColor19(v){document.getElementById("BColor19").value=v;}
*/

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
