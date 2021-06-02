using Newtonsoft.Json;

namespace OmniSharp.Models.Diagnostics
{
    public interface ILocation
    {
        string FileName { get; set; }
        int Line { get; set; }
        int Column { get; set; }
        int EndLine { get; set; }
        int EndColumn { get; set; }
        string Text { get; set; }
    }

    public class CodeLocation : ILocation
    {
        public string FileName { get; set; }
        [JsonConverter(typeof(ZeroBasedIndexConverter))]
        public int Line { get; set; }
        [JsonConverter(typeof(ZeroBasedIndexConverter))]
        public int Column { get; set; }
        [JsonConverter(typeof(ZeroBasedIndexConverter))]
        public int EndLine { get; set; }
        [JsonConverter(typeof(ZeroBasedIndexConverter))]
        public int EndColumn { get; set; }
        public string Text { get; set; }

        protected bool Equals(CodeLocation other)
        {
            return FileName == other.FileName &&
                   Line == other.Line &&
                   Column == other.Column &&
                   EndLine == other.EndLine &&
                   EndColumn == other.EndColumn;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CodeLocation) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (FileName != null ? FileName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Line;
                hashCode = (hashCode * 397) ^ Column;
                hashCode = (hashCode * 397) ^ EndLine;
                hashCode = (hashCode * 397) ^ EndColumn;
                return hashCode;
            }
        }
    }
}
