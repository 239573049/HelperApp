using HelperApp.Domain;
using Microsoft.AspNetCore.Components;

namespace HelperApp.Pages.Home;

partial class Function
{
    private readonly List<FunctionItem> functionItems = new List<FunctionItem>();

    [Inject] private NavigationManager navigation { get; set; }

    protected override void OnInitialized()
    {
        functionItems.Add(new FunctionItem
        {

            Title = "合并Pdf",
            Href = "/pdf-merge"
        });


        functionItems.Add(new FunctionItem
        {
            Title = "图片转Pdf",
            Href = "/img-to-pdf"
        });

        functionItems.Add(new FunctionItem
        {
            Title = "Pdf转化图片",
            Href = "/pdf-to-img"
        });
    }

    private void Href(string url)
    {
        navigation.NavigateTo(url, false);
    }
}
