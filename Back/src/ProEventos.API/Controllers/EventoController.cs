using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {

       public IEnumerable<Evento> _evento = new Evento[] {
              new Evento {
              EventoID = 1,
              Tema = "Angular",
              Local = "PT",
              Lote = "1º lote",
              QtdPessoas = 250,
              DataEvento = DateTime.Now.AddDays(2).ToString(),
              ImagemURL = "razvan.png"
            },
            new Evento {
              EventoID = 2,
              Tema = "DotNet Core",
              Local = "RO",
              Lote = "2º lote",
              QtdPessoas = 300,
              DataEvento = DateTime.Now.AddDays(2).ToString(),
              ImagemURL = "razvanPT.png"
            },
           };  
        public EventoController()
        {
           
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
           return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetByID(int id)
        {
           return _evento.Where(evento => evento.EventoID == id);
        }

        [HttpPost]
        public string Post()
        {
           return "Exemplo de Post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
           return $"Exemplo de Put =  {id}";
        }
    }
}
