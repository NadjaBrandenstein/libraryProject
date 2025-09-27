﻿using System.ComponentModel.DataAnnotations;

namespace api.Dtos;

public class CreateBookImageDto
{
    [MinLength(1)]
    [Required] 
    public required string Url { get; set; }
}