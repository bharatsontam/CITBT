using CITBT.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CITBT.ViewModels.Theaters.TheaterShowTimings
{
    public class TheatreShowTimingsViewModel
    {
        public Guid Id { get; set; }
        public string AvailableShowTime { get; set; }
        public Guid TheatreId { get; set; }
        public Theater Theater { get; set; }
    }

    public class CreateTheaterShowTimeViewModel : TheatreShowTimingsViewModel
    {

    }

    public class EditTheaterShowTImeViewModel : CreateTheaterShowTimeViewModel
    {

    }

    public class TheaterShowTimeDetailViewModel : TheatreShowTimingsViewModel
    {
        
    }
}