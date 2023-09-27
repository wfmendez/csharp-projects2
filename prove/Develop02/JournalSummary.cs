class JournalSummary
{
    public List<Entry> _entries;

    public JournalSummary(List<Entry> entries)
    {
        _entries = entries;
    }

    public int GetTotalEntries()
    {
        return _entries.Count;
    }

    public int GetEntriesOnDate(string date)
    {
        return _entries.Count(entry => entry.Date == date);
    }

    public int GetMostActiveDay()
    {
        var groupedEntries = _entries.GroupBy(entry => entry.Date);
        var maxEntries = groupedEntries.Max(group => group.Count());
        return maxEntries;
    }
}
