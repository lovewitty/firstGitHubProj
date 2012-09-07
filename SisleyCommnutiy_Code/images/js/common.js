function getSum(){
	var sum = 0;
	$.each($(".details li>div[id^='total_']"),function(){
		var _val = parseInt(this.innerText);
		sum += _val;
	})
	return sum;
}

function getPlus(id){
	var t = $("#text_box_"+id);
	var _price = parseInt($("#price_"+id).text());
	var _val = parseInt(t.val())+1;
	var result = parseInt(_val*_price);
	t.val(_val);
	$("#total_"+id).html(result);
	$("#totalPrice").html(getSum());
}

function getMinus(id){
	var t = $("#text_box_"+id);
	var _price = parseInt($("#price_"+id).text());
	var _val = parseInt(t.val())-1;
	if(_val<=1){_val=1;alert("数量不能小于1");}
	var result = parseInt(_val*_price);
	t.val(_val);
	$("#total_"+id).html(result);
	$("#totalPrice").html(getSum());
}
 
function countChange(){
	$(".details input[name='count']").keyup(function () {
		if($(this).val()==""){$(this).val(1);}
		_this=$(".details input[name='count']").index(this);
		var priceNeed=parseInt($(".details ul:eq("+_this+") li:eq(3) div").text());
		var keyW=$(this).val();
		if(keyW.match(/[^\d]/)){$(this).val(1);keyW=1;}
		var priceSum=priceNeed*keyW;
		$(".details ul:eq("+_this+") li:eq(4) div").text(priceSum);
		$("#totalPrice").html(getSum());
	})
}
  
function countInit(){
	$("#totalPrice").html(getSum());
	_length=$(".details input[name='count']").length;
	$("#totalProd").html(_length);
} 

//
jQuery.divselect = function(divselectid,inputselectid) {
	var inputselect = $(inputselectid);
	$(divselectid+" cite").click(function(){
		var deta = $(divselectid+" .deta");
		if(deta.css("display")=="none"){
			deta.slideDown("fast");
		}else{
			deta.slideUp("fast");
		}
		selectInit();
	});
	$(divselectid+" .deta ul li a").click(function(){
		var txt = $(this).text();
		$(divselectid+" cite").html(txt);
		$(inputselect).val(txt);
		$(divselectid+" .deta").hide();
		
	});
};
//

function showUp(){
	$(".details .btnShow").click(function(){
		$(".details .showUp").show();
		return false;
	});
}
  
$(document).ready(function(){
	countInit();
	countChange();		
});