function MM_CenterWindow(url,width,height) 
{
    if (document.all)
        var xMax = screen.width, yMax = screen.height;
    else 
        if (document.layers)
            var xMax = window.outerWidth, yMax = window.outerHeight;
        else
            var xMax = 640, yMax=480;
    var xOffset = (xMax - width)/2;
    var yOffset = (yMax - height)/2;
    window.open(url,'myPage', 'width=' + width +',height=' + height +', top='+yOffset+',left='+xOffset+',toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,copyhistory=yes');
}

function regQuanJiao(val) { 
				var myReg = /^[\uFF00-\uFFFF\u4e00-\u9fa5]+$/; //È«½Çºº×ÖºÍÊý×Ö 
				return myReg.test(val);  
			} 
			
function timeFormat(val)
{
    var myReg = /^((([0-1]?[0-9])|(2[0-3]))([\:])([0-5][0-9]))$/;
    if(myReg.test(val)) return true;
    return false;

}

