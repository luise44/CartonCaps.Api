namespace CartonCaps.Dto
{
    public record LoginValidationDto(bool IsLoginValid, UserDto? User = null);
}
