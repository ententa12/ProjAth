﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPProject.Models.SecretaryViewModels
{
    public class PersonsViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Roles { get; set; }
    }
}