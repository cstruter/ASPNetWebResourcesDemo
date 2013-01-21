function toggle(sender, e)
{
	var content = document.getElementById(e);
	switch(content.style.display)
	{
		case "none":	content.style.display = "block";
						sender.src = '<%= WebResource("DemoControl.images.up.jpg")%>';
						break;
		case "block":	content.style.display = "none";
						sender.src = '<%= WebResource("DemoControl.images.down.jpg")%>';
						break;							
	}
}