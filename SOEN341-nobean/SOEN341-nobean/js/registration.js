$(document).ready(function(){
	
	$("input[id$='TextBoxFN']").on("input",function(){
		var regexp=/[^a-zA-Z\-]/g;
		if($(this).val().match(regexp))
		{
			$(this).val( $(this).val().replace(regexp,'') );
		}
	});

	$("input[id$='TextBoxLN']").on("input",function(){
		var regexp=/[^a-zA-Z\-]/g;
		if($(this).val().match(regexp))
		{
			$(this).val( $(this).val().replace(regexp,'') );
		}
	});

	$("input[id$='TextBoxPWD']").on("input",function(){
		var regexp=/\(|\)|\[|\]|\<|\>|\{|\}/g;
		if($(this).val().match(regexp))
		{
			$(this).val( $(this).val().replace(regexp,'') );
		}
	});

	$("input[id$='TextBoxCPWD']").on("input",function(){
		var regexp=/\(|\)|\[|\]|\<|\>|\{|\}/g;
		if($(this).val().match(regexp))
		{
			$(this).val( $(this).val().replace(regexp,'') );
		}
	});

	$("input[id$='TextBoxNetN']").on("input",function(){
		var regexp=/[^a-zA-Z_]/g;
		if($(this).val().match(regexp))
		{
			$(this).val( $(this).val().replace(regexp,'') );
		}
	});

	$("input[id$='TextBoxSchoolID']").on("input",function(){
		var regexp=/[^0-9]/g;
		if($(this).val().match(regexp))
		{
			$(this).val( $(this).val().replace(regexp,'') );
		}
	});

	$("#Reset1").on("click",function(){
		$("[id*='TextBox']").each(function(){
			$(this).val('');
		});
	})

});