﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace _09_00_HelloCore.ViewModels
{
    public class KlantEditViewModel
    {
        public int KlantID { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Voornaam { get; set; }
        [DataType(DataType.Date), Display(Name = "Datum Aangemaakt")]

        public DateTime AangemaaktDatum { get; set; }
    }
}