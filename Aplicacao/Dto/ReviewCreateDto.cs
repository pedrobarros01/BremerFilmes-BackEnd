namespace Application.Dto
{
    public class ReviewCreateDto
    {
        public int IdFilmeTMDB { get; set; }
        public int IdUsuario { get; set; }
        public string Comentario { get; set; }
        public decimal Nota { get; set; }
    }
}
