﻿namespace LibraryManagementSystem.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string  Adress { get; set; }
        public string  TelephoneNumber { get; set; }

        public  string State { get; set; }
    }
}
