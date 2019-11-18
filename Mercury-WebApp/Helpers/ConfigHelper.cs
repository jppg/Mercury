using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mercury_WebApp.Models;

namespace Mercury_WebApp.Helpers
{
  public class ConfigHelper
  {
      private readonly MercuryContext _context;

      public ConfigHelper(MercuryContext context)
      {
          _context = context;
      }

      public decimal GetKeyValue(string key)
      {
        List<Config> confList = _context.Config.ToList();

        Config conf = confList.FirstOrDefault(x => x.Keyname == key && (x.Enddate == null || x.Enddate > DateTime.Now));

        return conf.Keyvalue;
      }
  }
}