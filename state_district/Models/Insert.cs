namespace state_district.Models
{
    public class Insert
    {
        public int stid { set; get; }
        public string? stname { set; get; }
        public int did { set; get; }
        public string? dname { set; get; }
        public string? sname { set; get; }
        public int sage { set; get; }
        public string? sphoto { set; get; }
    }
    public class stclass
    {
        public int stid { set; get; }
        public string? stname { set; get; }
    }
    public class dclass
    {
        public int did { set; get; }
        public string? dname { set; get; }
    }
}
