using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;
using Rplace.Models;

namespace Rplace.UseCase.CreateProfile;

public record CreateProfilePayload
{
    [Required] // fala que é obrigatório escrever tais critérios
    [MinLength(6)] // mínimo 6 caracteres
    public string Username { get; init; }
    [Required]
    [EmailAddress]
    public string Email { get; init; }
    [Required]
    [MinLength(8)]
    [NeedNumber]
    // (?=.*[a-z]): exige uma letra minúscula
    // (?=.*[A-Z]): exige uma letra maiúscula
    // (?=.*[\W_]): exige um caracter especial
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_])$",
        ErrorMessage = "The field Password must contain upper and lower cases")]
    public string Password { get; init; }
    [Required]
    [Compare("Password")]
    public string RepeatPassword { get; init; }
    public string? Link { get; init; }
    [MaxLength(200)]
    public string? Bio { get; init; }
    [Required]
    public Plan Plan { get; init; }

}