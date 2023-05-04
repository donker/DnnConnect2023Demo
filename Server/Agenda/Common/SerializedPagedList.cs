using System.Collections.Generic;

namespace Connect.Agenda.Agenda.Common
{
  public class SerializedPagedList<T>
  {
    public bool IsFirstPage { get; set; }
    public bool IsLastPage { get; set; }
    public int PageCount { get; set; }
    public int TotalCount { get; set; }
    public IEnumerable<T> data { get; set; }
  }
}
