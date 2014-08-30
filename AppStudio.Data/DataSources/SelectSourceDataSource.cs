using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class SelectSourceDataSource : IDataSource<MenuSchema>
    {
        private readonly IEnumerable<MenuSchema> _data = new MenuSchema[]
		{
            new MenuSchema
            {
                Type = "Section",
                Title = "Apple Insider",
                Icon = "/Assets/DataImages/Item-1ae7b0da-d4ae-47d6-96c4-40756ab04e34.png",
                Target = "AppleInsiderPage",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "Android Central",
                Icon = "/Assets/DataImages/Item-7d6222f9-c2e2-4329-b996-33de13ccd80c.png",
                Target = "AndroidCentralPage",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "CrackBerry",
                Icon = "/Assets/DataImages/Item-0d6aab38-9eef-4fbd-b33b-aca58c30c824.png",
                Target = "CrackBerryPage",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "CNET",
                Icon = "/Assets/DataImages/images.png",
                Target = "CNETPage",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "Engadget",
                Icon = "/Assets/DataImages/Item-ac23022b-bd40-4291-93e8-c04b0a681a56.png",
                Target = "EngadgetPage",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "Gizmodo",
                Icon = "/Assets/DataImages/Item-3034d963-e038-4a59-9dab-c18e753426c8.png",
                Target = "GizmodoPage",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "Maclife",
                Icon = "/Assets/DataImages/Item-3004bf29-1eb1-445d-b8f6-f57895344b6a.png",
                Target = "MaclifePage",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "Microsoft",
                Icon = "/Assets/DataImages/Item-3e8f5066-61b0-4696-95bb-85a2634844d8.png",
                Target = "MicrosoftPage",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "PC-TechAuthority",
                Icon = "/Assets/DataImages/Item-ebf6a6d7-c7d9-48af-9a9b-b4b9e7fcd430.png",
                Target = "PCTechAuthorityPage",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "PC-WORLD",
                Icon = "/Assets/DataImages/Item-719a0109-a926-49ec-bcc9-6a649f5cd70f.png",
                Target = "PCWORLDPage",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "TechCrunch",
                Icon = "/Assets/DataImages/Item-bb54358d-2099-4691-97e9-f8990740e537.png",
                Target = "TechCrunchPage",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "The Next Web",
                Icon = "/Assets/DataImages/Item-490c2f45-1b3d-4c05-a7e6-20e4e73efdba.png",
                Target = "TheNextWebPage",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "WebOS",
                Icon = "/Assets/DataImages/Item-e76beb6d-d682-4036-8a8d-ee3a60e2a76c.png",
                Target = "WebOSPage",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "Wired",
                Icon = "/Assets/DataImages/Item-51ff6430-bb9a-4d33-9dae-884611220418.png",
                Target = "WiredPage",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "9To5Mac",
                Icon = "/Assets/DataImages/Item-d0d20ffd-cff2-4cad-93d5-3897c4353e46.png",
                Target = "To5MacPage",
            },
            new MenuSchema
            {
                Type = "Url",
                Title = "FeedBack",
                Icon = "/Assets/DataImages/9711099022_23bbdd529a_o.png",
                Target = "mailto:theappmaker@live.com",
            },
		};

        public async Task<IEnumerable<MenuSchema>> LoadData()
        {
            return await Task.Run(() =>
            {
                return _data;
            });
        }

        public async Task<IEnumerable<MenuSchema>> Refresh()
        {
            return await LoadData();
        }
    }
}
