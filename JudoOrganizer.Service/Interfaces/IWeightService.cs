using JudoOrganizer.Data.Models;

namespace JudoOrganizer.Service.Interfaces;

public interface IWeightService
{
    Task<IEnumerable<Weight>> GetAllWeightsAsync();
    Task<Weight?> GetWeightAsync(int id);
    Task CreateWeightAsync(Weight weight);
    Task UpdateWeightAsync(int id, Weight weight);
    Task DeleteWeightAsync(int id);
}