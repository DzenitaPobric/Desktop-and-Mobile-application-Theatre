using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ePozoriste.Model.Requests;
using ePozoriste.WebAPI.Database;
using ePozoriste.WebAPI.Filters;
using ePozoriste.WebAPI.Security;
using ePozoriste.WebAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ePozoriste.WebAPI
{
    public class BasicAuthDocumentFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            var securityRequirements = new Dictionary<string, IEnumerable<string>>()
        {
            { "basic", new string[] { } }  // in swagger you specify empty list unless using OAuth2 scopes
        };

            swaggerDoc.Security = new[] { securityRequirements };
        }
    }

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          
            services.AddMvc(x => x.Filters.Add<ErrorFilter>()).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper(typeof(Startup)); //ovo treba za verziju 7.0.0

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("basic", new BasicAuthScheme() { Type = "basic" });
                c.DocumentFilter<BasicAuthDocumentFilter>();
            });

            services.AddAuthentication("BasicAuthentication")
             .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
            services.AddScoped<IKorisnikService, KorisnikService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IPredstavaService, PredstavaService>();
            services.AddScoped<ICRUDService<Model.Grad, GradSearchRequest, GradInsertRequest, GradInsertRequest>, GradService>();
            services.AddScoped<ICRUDService<Model.Zanr, ZanrSearchRequest, ZanrInsertRequest, ZanrInsertRequest>, ZanrService>();
            services.AddScoped<ICRUDService<Model.Sponzor, SponzorSearchRequest, SponzorInsertRequest, SponzorInsertRequest>, SponzorService>();
            services.AddScoped<ICRUDService<Model.Sala, SalaSearchRequest, SalaUpsertRequest, SalaUpsertRequest>, SalaService>();
            services.AddScoped<ICRUDService<Model.Glumac, GlumacSearcRequest, GlumacUpsertRequest, GlumacUpsertRequest>, GlumacService>();
            services.AddScoped<ICRUDService<Model.Uplata, UplataSearchRequest, UplataUpsertRequest, UplataUpsertRequest>, UplataService>();
            services.AddScoped<ICRUDService<Model.Sjediste, SjedisteSearchRequest, SjedisteUpsertRequest, SjedisteUpsertRequest>, SjedisteService>();
            services.AddScoped<IPrikazivanjeService, PrikazivanjeService>();
            services.AddScoped<IService<Model.Uloga, object>, BaseService<Model.Uloga, object, Uloga>>();
            services.AddScoped<IKupacService, KupacService>();
            services.AddScoped<IPreporukaService, PreporukaService>();
            services.AddScoped<INagradnaIgraService, NagradnaIgraService>();
            services.AddScoped<ICRUDService<Model.Novosti, NovostiSearchRequest, NovostiInsertRequest, NovostiInsertRequest>, NovostiService>();
            services.AddScoped<ICRUDService<Model.Ulaznica, UlaznicaSearchRequest, UlaznicaUpsertRequest, UlaznicaUpsertRequest>, UlaznicaService>();
            services.AddScoped<IRezervacijaService, RezervacijaService>();
            services.AddScoped<ICRUDService<Model.Komentar, KomentarSearchRequest, KomentarUpsertRequest, KomentarUpsertRequest>, KomentarService>();
            services.AddScoped<ICRUDService<Model.Notifikacija, object, NotfikacijaInsertRequest, NotfikacijaInsertRequest >, NotifikacijaService>();
            services.AddScoped<ICRUDService<Model.PredstavaKupac, PredstavaKupacSearchRequest, PRedstavaKupacInsertRequest, PRedstavaKupacInsertRequest>, PredstavaKupacService>();
            services.AddScoped<ICRUDService<Model.KupacNagradnaIgra, KupacNagradnaIgraSearchRequest, KupacNagradnaIgraInsertRequest, KupacNagradnaIgraInsertRequest>, KupacNagradnaIgraService>();
            services.AddScoped<ICRUDService<Model.GlumacPredstava, GlumacPredstavaSearchRequest, GlumacPredstavaInsertRequest, GlumacPredstavaInsertRequest>, GlumacPredstavaService>();
            services.AddScoped<ICRUDService<Model.PredstavaUplata, PredstavaUplataSearchRequest, PredstavaUplataInsertRequest, PredstavaUplataInsertRequest>, PredstavaUplataServicw>();


            services.AddScoped<IDokumentService, DokumentService>();

            var connection = @"data source =.; initial catalog = 160044_160046; integrated security = True;";
            services.AddDbContext<ePozoristeContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }



            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");

            });

            app.UseAuthentication();

            app.UseMvc();


        }
    }
}







