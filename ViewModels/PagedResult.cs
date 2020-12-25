using System;
using System.Collections.Generic;

namespace StudyOnlineServer.ViewModels
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Result { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool HasNext { get; set; }
    }
}
