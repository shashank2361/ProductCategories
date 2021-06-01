using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System;
using System.Collections.Generic;
 
using System.Text;

namespace ProductCategories.UI
{
    public class AuthConfig
    {
  
        public string BaseAddress { get; set; }
 
       

        public static AuthConfig ReadFromJsonFile(string path)
        {
            IConfiguration Configuration;

            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile(path);

            Configuration = builder.Build();

            return Configuration.Get<AuthConfig>();
        }
    }
}