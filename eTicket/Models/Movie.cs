using eTicket.Controllers.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }

        //RelationShip
        public List<ActorMovie> ActorMovies { get; set; }

        //Cinema Relationship
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }

        //Producer Relationship
        public int ProducerId { get; set; }
        public Producer  Producer { get; set; }

    }
}
