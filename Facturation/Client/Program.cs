using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Facturation.Shared;

namespace Facturation.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            Facture facture1 = new Facture("LESTON", "00001", new DateTime(2020,12,30), new DateTime(2020, 12, 30), 104850000, 45632);
            Facture facture2 = new Facture("MADEZO", "00002", new DateTime(2020, 12, 30), new DateTime(2020, 12, 30), 154650, 42132);
            Facture facture3 = new Facture("BAZATS", "00003", new DateTime(2020, 12, 30), new DateTime(2020, 12, 30), 93, 6562);
            Facture facture4 = new Facture("BENETIER", "69420", new DateTime(2020, 12, 30), new DateTime(2020, 12, 30), 69420, 2789);

            BusinessData Factures = new BusinessData();

            Factures.addFacture(facture1);
            Factures.addFacture(facture2);
            Factures.addFacture(facture3);
            Factures.addFacture(facture4);

            builder.Services.AddSingleton<IBusinessData>(sp => new BusinessData());
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}