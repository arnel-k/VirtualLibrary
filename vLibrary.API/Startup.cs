﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using vLibrary.Api.Database;
using vLibrary.API.Context;
using vLibrary.API.Filters;
using vLibrary.API.Helpers;
using vLibrary.API.Repositories;
using vLibrary.API.Repositories.Interfaces;
using vLibrary.API.Services;
using vLibrary.Model;
using vLibrary.Model.Requests;

namespace vLibrary.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            
            
            services.AddCors();
            services.AddDbContext<LibraryContext>(o => o.UseSqlServer(Configuration.GetConnectionString("LibraryContext")));
            //production : services.AddMvc(e=>e.Filters.Add<ErrorFilter>()).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new Info { Title = "vLibrary API", Version = "v1" }
                ));

            _ = services.AddAutoMapper();
            
            
            //konfiguracija "strongly typed" postavki 

            var appSettingsSection= Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            //postavke za JWT autentifikaciju
            var appSettings = appSettingsSection.Get<AppSettings>();

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            /*services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = ctx =>
                        {
                            var userService = ctx.HttpContext.RequestServices.GetRequiredService<>();
                            var userId = int.Parse(ctx.Principal.Identity.Name);
                            var user = userService.GetById(userId);
                            if (user == null)
                            {
                                //neautorizovan ako korisnik vise ne postoji
                                ctx.Fail("Unautohrized");
                            }
                            return Task.CompletedTask;
                        }
                    };
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });*/
            //Izmjenit
            
            
            services.AddScoped<IAuthorRepository<Author>, AuthorRepository>();
            services.AddScoped<IAddressRepository<Address>, AddressRepository>();
            services.AddScoped<IBookRepository<Book>, BookRepository>();
            services.AddScoped<ILibraryRepository<Library>, LibraryRepository>();
            services.AddScoped<ICategoryRepository<Category>, CategoryRepository>();
            services.AddScoped<IRackRepository<Rack>, RackRepository>();
            services.AddScoped<IPublisherRepository<Publisher>, PublisherRepository>();
            services.AddScoped<IMemberRepository<Member>, MemberRepository>();
            services.AddScoped<IEmployeeRepository<Employee>, EmployeeRepository>();

            services.AddScoped<ICRUDService<AuthorDto, AuthorsSearchRequest, AuthorInsertRequest, AuthorUpdateRequest>,AuthorService>();
            services.AddScoped<ICRUDService<AddressDto,AddressSearchRequest,AddressUpsertRequest,AddressUpsertRequest>,AddressService>();
            services.AddScoped<ICRUDService<BookDto, BookSearchRequest, BookUpsertRequest, BookUpsertRequest>, BookService>();
            services.AddScoped<ICRUDService<LibraryDto, LibrarySearchRequest, LibraryUpsertRequest, LibraryUpsertRequest>, LibraryService>();
            services.AddScoped<ICRUDService<CategoryDto, CategorySearchRequest, CategoryUpsertRequest, CategoryUpsertRequest>, CategoryService>();
            services.AddScoped<ICRUDService<RackDto, RackSearchRequest, RackUpsertRequest, RackUpsertRequest>, RackService>();
            services.AddScoped<ICRUDService<PublisherDto, PublisherSearchRequest, PublisherUpsertRequest, PublisherUpsertRequest>, PublisherService>();
            services.AddScoped<ICRUDService<MemberDto, MemberSearchRequest, MemberUpsertRequests, MemberUpsertRequests>, MemberService>();
            services.AddScoped<ICRUDService<EmployeeDto, EmployeeSearchRequest, EmployeeUpsertRequest, EmployeeUpsertRequest>, EmployeeService>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseHttpsRedirection();
            //app.UseAuthentication();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "vLibrary"));
        }
    }
}
