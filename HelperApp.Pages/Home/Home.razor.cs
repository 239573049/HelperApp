namespace HelperApp.Pages.Home;

partial class Home
{
	private object _option = new
	{
		Title = new
		{
			Text = "在线日志"
		},
		Tooltip = new { },
		Legend = new
		{
			Data = new[] { "在线人数" }
		},
		XAxis = new
		{
			Data = new[] { "2022-6-10", "2022-6-11", "2022-6-12", "2022-6-13", "2022-6-14", "2022-6-15" }
		},
		YAxis = new { },
		Series = new[]
									{
			new
			{
				Name= "在线人数",
				Type= "bar",
				Data= new []{ 5, 20, 36, 10, 10, 20 }
			}
		}
	};
}
