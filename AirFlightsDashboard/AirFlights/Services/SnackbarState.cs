using System.Collections.Generic;

namespace AirFlightsDashboard.Services;

public class ApplicationSession
{
    private readonly IDictionary<string, string> _storage = new Dictionary<string, string>();

    public void SetItem(string key, string value)
    {
        _storage[key] = value;
    }

    public string GetItem(string key)
    {
        if (!_storage.ContainsKey(key))
        {
            return null;
        }

        return _storage[key];
    }
}