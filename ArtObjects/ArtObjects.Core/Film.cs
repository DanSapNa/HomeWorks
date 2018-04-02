using System.Collections.Generic;

namespace ArtObjects.Core
{
    public class Film : ArtObject
    {
        public int Length { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
    }
}
