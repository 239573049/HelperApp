using BlazorComponent;

namespace HelperApp.Pages.Home;

partial class Function
{

    StringNumber model;
    Card[] _cards = new Card[]
{
         new Card
        {
            Title="PDF合并",
            Flex=3,
            Href="/pdf-merge"

        },
         new Card
        {
            Title="img转PDF",
            Flex=3,
            Href="/img-to-pdf"
        },
         new Card
        {
            Title="Pdf转化图片",
            Flex=3,
            Href="/pdf-to-img"
        }
};

    class Card
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// 大小
        /// </summary>
        public int Flex { get; set; }

        /// <summary>
        /// 路由
        /// </summary>
        public string? Href { get; set; }
    }
    protected override void OnInitialized()
    {

    }
}
