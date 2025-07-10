namespace Cimo.Dtos
{
    public class JwtPayloadDto
    {
        public string Sub { get; set; }
        public List<string> Authorities { get; set; }
    }
}
