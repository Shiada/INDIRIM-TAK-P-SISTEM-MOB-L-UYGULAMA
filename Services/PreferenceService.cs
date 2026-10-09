using System.Text.Json;
using Indirimci.Models;

namespace Indirimci.Services;

public class PreferenceService
{
    private const string PrefsKey = "indirimci_user_prefs";
    private Dictionary<string, UserPreference> _preferences = new();

    public PreferenceService()
    {
        LoadPreferences();
    }

    public bool IsBrandTracked(string brandId)
    {
        return _preferences.ContainsKey(brandId) && _preferences[brandId].Enabled;
    }

    public List<string> GetTrackedCategories(string brandId)
    {
        if (_preferences.TryGetValue(brandId, out var pref))
            return pref.SelectedCategories;
        return new List<string>();
    }

    public int GetTrackedBrandCount()
    {
        return _preferences.Count(p => p.Value.Enabled);
    }

    public void ToggleBrand(string brandId, List<string> allSubCategories)
    {
        if (!_preferences.ContainsKey(brandId))
        {
            _preferences[brandId] = new UserPreference
            {
                BrandId = brandId,
                Enabled = true,
                SelectedCategories = new List<string>(allSubCategories)
            };
        }
        else
        {
            _preferences[brandId].Enabled = !_preferences[brandId].Enabled;
            if (_preferences[brandId].Enabled && _preferences[brandId].SelectedCategories.Count == 0)
            {
                _preferences[brandId].SelectedCategories = new List<string>(allSubCategories);
            }
        }
        SavePreferences();
    }

    public void ToggleCategory(string brandId, string category, List<string> allSubCategories)
    {
        if (!_preferences.ContainsKey(brandId))
        {
            _preferences[brandId] = new UserPreference
            {
                BrandId = brandId,
                Enabled = true,
                SelectedCategories = new List<string> { category }
            };
        }
        else
        {
            var cats = _preferences[brandId].SelectedCategories;
            if (cats.Contains(category))
                cats.Remove(category);
            else
                cats.Add(category);

            _preferences[brandId].Enabled = cats.Count > 0;
        }
        SavePreferences();
    }

    public bool IsCategorySelected(string brandId, string category)
    {
        if (_preferences.TryGetValue(brandId, out var pref))
            return pref.SelectedCategories.Contains(category);
        return false;
    }

    private void LoadPreferences()
    {
        try
        {
            var json = Preferences.Default.Get(PrefsKey, string.Empty);
            if (!string.IsNullOrEmpty(json))
            {
                _preferences = JsonSerializer.Deserialize<Dictionary<string, UserPreference>>(json)
                    ?? new Dictionary<string, UserPreference>();
            }
        }
        catch
        {
            _preferences = new Dictionary<string, UserPreference>();
        }
    }

    private void SavePreferences()
    {
        try
        {
            var json = JsonSerializer.Serialize(_preferences);
            Preferences.Default.Set(PrefsKey, json);
        }
        catch { /* ignore */ }
    }
}
