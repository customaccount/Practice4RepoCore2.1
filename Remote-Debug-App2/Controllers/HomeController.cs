﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Remote_Debug_App2.Models;

namespace Remote_Debug_App2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DebugAppDBContext _context;

        public HomeController(ILogger<HomeController> logger, DebugAppDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            string number = $"{Guid.NewGuid()}";
            DebugTable table = _context.DebugTables.FirstOrDefault(it => it.RandomGuid == number);
            if (table == null)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DebugSerrializedModel), null, null, new XmlRootAttribute("debug-app-model"), string.Empty);

                MemoryStream stream = new MemoryStream();

                serializer.Serialize(stream, new DebugSerrializedModel());

                stream.Position = 0;
                StreamReader reader = new StreamReader(stream);
                string text = reader.ReadToEnd();

                Random rand = new Random((int)DateTime.Now.Ticks);
                table = new DebugTable() { DateTime = DateTime.Now, Id = rand.Next(), RandomGuid = number, SerializedObject = text };
                _context.Add(table);
                _context.SaveChanges();
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
