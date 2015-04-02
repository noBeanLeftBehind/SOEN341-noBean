$(document).ready(function(){
	
	$("input[id$='TextBox1']").on("input",function(){
		var regexp=/[^a-zA-Z_]/g;
		if($(this).val().match(regexp))
		{
			$(this).val( $(this).val().replace(regexp,'') );
		}
	});

	$("input[id$='TextBox2']").on("input",function(){
		var regexp=/\(|\)|\[|\]|\<|\>|\{|\}/g;
		if($(this).val().match(regexp))
		{
			$(this).val( $(this).val().replace(regexp,'') );
		}
	});

});