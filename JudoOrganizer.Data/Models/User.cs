﻿using JudoOrganizer.Data.Enums;

namespace JudoOrganizer.Data.Models;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
}