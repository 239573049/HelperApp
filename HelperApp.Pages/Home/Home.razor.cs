using HelperApp.Applications.AppService;
using Microsoft.AspNetCore.Components;

namespace HelperApp.Pages.Home;

partial class Home
{
	[Inject] public HomeServices homeServices { get; set; }

	public async Task SaFile()
	{
		await homeServices.SaveFile();
	}
}
