using System.ComponentModel.DataAnnotations;

namespace api.Dtos;

public class UpdateAuthorDto
{
    public string Id { get; set; } = null!;
    [MinLength(1)] public string Name { get; set; } = null!;
}