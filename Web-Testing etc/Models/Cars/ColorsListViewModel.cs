namespace Web_Testing_etc.Models.Cars
{
    public class ColorsPaginationViewModel
    {
        public List<ColorModel> Colors { get; set; }
        public PaginationViewModel Pagination { get; set; }

        public string CurrentSort { get; set; }
        public string NameSortParam { get; set; }
        public string CodeSortParam { get; set; }
    }
}
